using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoWeb.Insumos
{
    public partial class ListaInsumos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cargarInsumos();
                    cargarCategorias();
                }
            }

            catch (Exception ex)
            {
                Session.Add("error", ex);
                //Response.Redirect("Error.aspx"); Hay que crear la pagina de redirección cuando da error.
            }

           

    }
        private void cargarInsumos()
        {
            InsumoNegocio negocio = new InsumoNegocio();

            string nombre = txtFiltroNombre.Text.Trim();

            int idCategoria = 0;

            if (!string.IsNullOrEmpty(ddlFiltroCategoria.SelectedValue))
                idCategoria = int.Parse(ddlFiltroCategoria.SelectedValue);

            bool soloStockCero = chkStockCero.Checked;

            dgvInsumos.DataSource = negocio.listar(nombre, idCategoria, soloStockCero);
            dgvInsumos.DataBind();
        }
        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            ddlFiltroCategoria.DataSource = negocio.listar();
            ddlFiltroCategoria.DataTextField = "Descripcion";
            ddlFiltroCategoria.DataValueField = "Id";
            ddlFiltroCategoria.DataBind();

            ddlFiltroCategoria.Items.Insert(0, new ListItem("Seleccione una categoría", ""));
        }
        protected void dgvInsumos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Baja")
            {
                int id = int.Parse(e.CommandArgument.ToString());

                InsumoNegocio negocio = new InsumoNegocio();
                negocio.eliminarInsumo(id);

                cargarInsumos();
            }
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            cargarInsumos();
        }
    }
}