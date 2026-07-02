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

            dgvPedidoEnCurso.DataSource = lista;
            dgvPedidoEnCurso.DataBind();

            decimal total = 0;

            foreach (DetallePedido item in lista)
            {
                total += item.Subtotal;
            }

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

        protected void btnSumarCantidad_Click(object sender, EventArgs e)
        {
            int valor;
            if (!int.TryParse(txtCantidad.Text, out valor))
                valor = 0;

            txtCantidad.Text = (valor + 1).ToString();
        }

        protected void btnRestarCantidad_Click(object sender, EventArgs e)
        {
            int valor;
            if (!int.TryParse(txtCantidad.Text, out valor))
                valor = 0;

            if (valor > 1)
                txtCantidad.Text = (valor - 1).ToString();
        }

    }
}