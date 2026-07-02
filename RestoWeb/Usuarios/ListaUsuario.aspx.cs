using System;
using System.Collections.Generic;
using Negocio;
using Dominio;

namespace RestoWeb.Usuarios
{
    public partial class ListaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Seguridad.esGerente(Session["usuario"]))
                {
                    Response.Redirect("~/Default.aspx", false);
                    return;
                }

                if (!IsPostBack)
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Session["listaUsuarios"] = negocio.listar();
                    filtrar();
                }

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Session["paginaAnteriorError"] = Request.RawUrl;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        private void filtrar()
        {

            try
            {
                if (Session["listaUsuarios"] == null)
                {
                    lblError.Text = "No se pudieron cargar los usuarios. Por favor hacé click en Actualizar.";
                    lblError.Visible = true;
                    dgvUsuarios.DataSource = null;
                    dgvUsuarios.DataBind();
                    return;
                }

                lblError.Visible = false;

                List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];

                string textoBusqueda = txtBusqueda.Text.ToUpper();
                string campo = ddlCampoBusqueda.SelectedValue;

                if (!string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    if (campo == "Nombre")
                        lista = lista.FindAll(x => x.Nombre.ToUpper().Contains(textoBusqueda));
                    else if (campo == "Apellido")
                        lista = lista.FindAll(x => x.Apellido.ToUpper().Contains(textoBusqueda));
                    else if (campo == "NombreUsuario")
                        lista = lista.FindAll(x => x.NombreUsuario.ToUpper().Contains(textoBusqueda));
                }

                string estado = ddlEstado.SelectedValue;
                if (estado == "Activo")
                    lista = lista.FindAll(x => x.Activo);
                else if (estado == "Inactivo")
                    lista = lista.FindAll(x => !x.Activo);

                string idRol = ddlRol.SelectedValue;
                if (idRol != "0")
                    lista = lista.FindAll(x => x.Rol.Id == int.Parse(idRol));

                dgvUsuarios.DataSource = lista;
                dgvUsuarios.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        protected void ddlCampoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Session["listaUsuarios"] = negocio.listar();
            filtrar();
        }
    }
}