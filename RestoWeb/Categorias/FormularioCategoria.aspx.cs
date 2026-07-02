using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoWeb.Categorias
{
    public partial class FormularioCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!Seguridad.esGerente(Session["usuario"]))
                    {
                        Response.Redirect("~/Default.aspx", false);
                        return;
                    }

                    if (Request.QueryString["id"] != null)
                    {
                        lblTitulo.Text = "Editar Categoria";

                        int id = int.Parse(Request.QueryString["id"]);
                        cargarCategoria(id);
                    }
                    else
                    {
                        lblTitulo.Text = "Nueva Caategoria";
                    }

                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Session["paginaAnteriorError"] = Request.RawUrl;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
                lblError.Text = "";

                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                    throw new Exception("Debe ingresar una descripción.");

                Categoria categoria = new Categoria();
                categoria.Descripcion = txtDescripcion.Text.Trim();

                CategoriaNegocio negocio = new CategoriaNegocio();

                if (Request.QueryString["id"] != null)
                {
                    categoria.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificarCategoria(categoria);
                }
                else
                {
                    negocio.agregarCategoria(categoria);
                }

                Response.Redirect("ListaCategoria.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
        private void cargarCategoria(int id)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            Categoria categoria = negocio.listar().Find(x => x.Id == id);

            if (categoria != null)
            {
                txtDescripcion.Text = categoria.Descripcion;
                


            }
        }

    }
}