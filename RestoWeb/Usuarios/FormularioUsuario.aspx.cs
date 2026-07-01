using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace RestoWeb.Usuarios
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    RolNegocio negocio = new RolNegocio();
                    List<Rol> lista = negocio.listar();

                    ddlRol.DataSource = lista;
                    ddlRol.DataValueField = "Id";
                    ddlRol.DataTextField = "Descripcion";
                    ddlRol.DataBind();

                    ddlRol.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione un rol", "0"));
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    lblTitulo.Text = "Editar usuario";
                    chkActivo.Visible = true;
                    btnResetearPassword.Visible = true;

                    UsuarioNegocio negocioUsuario = new UsuarioNegocio();
                    Usuario seleccionado = (negocioUsuario.listar(int.Parse(id))[0]);

                    txtNombre.Text = seleccionado.Nombre;
                    txtApellido.Text = seleccionado.Apellido;
                    txtNombreUsuario.Text = seleccionado.NombreUsuario;
                    ddlRol.SelectedValue = seleccionado.Rol.Id.ToString();
                    chkActivo.Checked = seleccionado.Activo;
                }
                else
                    lblTitulo.Text = "Nuevo usuario";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new Exception("El campo Nombre es obligatorio.");

                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                    throw new Exception("El campo Apellido es obligatorio.");

                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
                    throw new Exception("El campo Nombre de usuario es obligatorio.");

                if (ddlRol.SelectedValue == "0")
                    throw new Exception("Debe seleccionar un rol.");

                Usuario nuevo = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.NombreUsuario = txtNombreUsuario.Text;

                nuevo.Rol = new Rol();
                nuevo.Rol.Id = int.Parse(ddlRol.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    nuevo.Activo = chkActivo.Checked;
                    negocio.modificarUsuario(nuevo);
                }
                else
                    negocio.agregarUsuario(nuevo);

                Response.Redirect("ListaUsuario.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnResetearPassword_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.resetearPassword(id);
                lblError.CssClass = "alert alert-success d-block";
                lblError.Text = "Contraseña reseteada correctamente.";
                lblError.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
    }
}