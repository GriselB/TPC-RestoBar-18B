using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoWeb.Pedidos
{
    public partial class PedidoEnCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var detalle = new[]
                 {
                        new{Insumo="Milanesa", Cantidad=5, PrecioUnitario="$5000", Subtotal="$25000"},
                        new{Insumo="Coca Cola Zero", Cantidad=7, PrecioUnitario="$1000", Subtotal="$7000"}
                 };
                    dgvPedidoEnCurso.DataSource = detalle;
                    dgvPedidoEnCurso.DataBind();
                    lblTotal.Text = "Total: $32000";
                }
            }

            catch (Exception ex)
            {
                Session.Add("error", ex);
                //Response.Redirect("Error.aspx"); Hay que crear la pagina de redirección cuando da error.
            }
        }
        protected void btnCerrarPedido_Click(object sender, EventArgs e)
        {
        }
        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
        }

    }
}