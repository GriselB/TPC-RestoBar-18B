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
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    lblTitulo.Text = "Editar usuario";
                    chkActivo.Visible = true;
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
                Usuario nuevo = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.NombreUsuario = txtNombreUsuario.Text;
                nuevo.Pass = txtPass.Text;

                nuevo.Rol = new Rol();
                nuevo.Rol.Id = int.Parse(ddlRol.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    //negocio.modificarUsuario(nuevo); 
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
    }
}