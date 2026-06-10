using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace RestoWeb.Insumos
{
    public partial class FormularioInsumos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCategorias();
            }
            
        }
        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            ddlCategoria.DataSource = negocio.listar();
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();

            ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoría", ""));
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new Exception("Debe ingresar un nombre.");

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                    throw new Exception("Debe ingresar un precio válido.");

                if (!int.TryParse(txtStock.Text, out int stock))
                    throw new Exception("Debe ingresar un stock válido.");

                if (ddlCategoria.SelectedValue == "")
                    throw new Exception("Debe seleccionar una categoría.");

                Insumo nuevo = new Insumo();

                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Descripcion = txtDescripcion.Text.Trim();
                nuevo.Precio = precio;
                nuevo.Stock = stock;

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Activo = chkActivo.Checked;

                InsumoNegocio negocio = new InsumoNegocio();
                negocio.agregarInsumo(nuevo);

                Response.Redirect("ListaInsumos.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
