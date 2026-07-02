using Dominio;
using Negocio;
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
        private int IdPedido
        {
            get
            {
                int id;

                if (Request.QueryString["idPedido"] != null &&
                    int.TryParse(Request.QueryString["idPedido"], out id))
                {
                    return id;
                }

                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPantalla();
            }
        }

        private void cargarPantalla()
        {
            if (IdPedido == 0)
            {
                Response.Redirect("~/Default.aspx", false);
                return;
            }

            cargarDatosPedido();
            cargarDetallePedido();
        }

        private void cargarDetallePedido()
        {
            DetallePedidoNegocio negocio = new DetallePedidoNegocio();

            List<DetallePedido> lista = negocio.listarPorPedido(IdPedido);

            List<object> listaGrilla = new List<object>();

            decimal total = 0;

            foreach (DetallePedido item in lista)
            {
                decimal subtotal = item.Cantidad * item.PrecioUnitario;

                listaGrilla.Add(new
                {
                    Id = item.Id,
                    Insumo = item.Insumo.Nombre,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario,
                    Subtotal = subtotal
                });

                total += subtotal;
            }

            dgvPedidoEnCurso.DataSource = listaGrilla;
            dgvPedidoEnCurso.DataBind();

            lblTotal.Text = "Total: " + total.ToString("C");
        }

        private void cargarDatosPedido()
        {
            

            lblMesa.Text = "Pedido N° " + IdPedido;
            lblDatosPedido.Text = "Detalle del pedido en curso";
        }

        protected void dgvPedidoEnCurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int idDetalle = int.Parse(e.CommandArgument.ToString());

                DetallePedidoNegocio negocio = new DetallePedidoNegocio();
                negocio.eliminarInsumoDeDetalle(idDetalle);

                cargarDetallePedido();
            }
        }

        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarInsumoPedido.aspx?idPedido=" + IdPedido, false);
        }

        protected void btnCerrarPedido_Click(object sender, EventArgs e)
        {
           

            Response.Redirect("~/Default.aspx", false);
        }

    }
}