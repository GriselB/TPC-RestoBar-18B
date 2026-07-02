using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoWeb.Categorias
{
    public partial class ListaCategoria : System.Web.UI.Page
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
                    cargarCategorias();

                }
            }

            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Session["paginaAnteriorError"] = Request.RawUrl;
                Response.Redirect("~/Error.aspx", false);
            }

            
    }
        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            dgvCategoria.DataSource = negocio.listar();
            dgvCategoria.DataBind();
        }

        protected void dgvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Baja")
            {
                int id = int.Parse(e.CommandArgument.ToString());

                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.EliminarCategoria(id);

                cargarCategorias();
            }
        }
    }
}