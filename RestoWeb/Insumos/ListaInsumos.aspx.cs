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

            dgvInsumos.DataSource = negocio.listar();
            dgvInsumos.DataBind();
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
    }
}