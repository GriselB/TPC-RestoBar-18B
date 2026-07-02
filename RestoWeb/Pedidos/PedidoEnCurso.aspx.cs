using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace RestoWeb.Pedidos
{
    public partial class PedidoEnCurso : System.Web.UI.Page
    {
        private int idPedido;

        protected void Page_Load(object sender, EventArgs e)
        {
            string queryId = Request.QueryString["idPedido"] != null ? Request.QueryString["idPedido"].ToString() : "";
            int.TryParse(queryId, out idPedido);

            if (!IsPostBack)
            {
                cargarPantalla();
            }
        }

        private void cargarPantalla()
        {
            if (idPedido == 0)
            {
                Response.Redirect("~/Default.aspx", false);
                return;
            }

            cargarDatosPedido();
            cargarDetallePedido();
        }

        private void cargarDatosPedido()
        {
            lblMesa.Text = "Pedido N° " + idPedido;
            lblDatosPedido.Text = "Detalle del pedido en curso";
        }

        private void cargarDetallePedido()
        {
            DetallePedidoNegocio negocio = new DetallePedidoNegocio();

            List<DetallePedido> lista = negocio.listarPorPedido(idPedido);

            dgvPedidoEnCurso.DataSource = lista;
            dgvPedidoEnCurso.DataBind();

            decimal total = 0;

            foreach (DetallePedido item in lista)
            {
                total += item.Subtotal;
            }

            lblTotal.Text = "Total: " + total.ToString("C");
        }

        protected void txtBuscarInsumo_TextChanged(object sender, EventArgs e)
        {
            buscarInsumo();
        }

        private void buscarInsumo()
        {
            string texto = txtBuscarInsumo.Text.Trim();

            hfIdInsumoSeleccionado.Value = "";
            Session["insumoEncontrado"] = null;

            if (string.IsNullOrEmpty(texto))
            {
                lblInsumoEncontrado.Visible = false;
                return;
            }

            InsumoNegocio negocio = new InsumoNegocio();
            List<Insumo> lista = negocio.listar(texto, 0, false, false);

            lblInsumoEncontrado.Visible = true;

            if (lista.Count == 0)
            {
                lblInsumoEncontrado.CssClass = "d-block mt-1 text-danger";
                lblInsumoEncontrado.Text = "No se encontró ningún insumo con ese nombre.";
            }
            else if (lista.Count > 1)
            {
                lblInsumoEncontrado.CssClass = "d-block mt-1 text-danger";
                lblInsumoEncontrado.Text = "Hay " + lista.Count + " insumos que coinciden. Sé más específico.";
            }
            else
            {
                Insumo encontrado = lista[0];

                hfIdInsumoSeleccionado.Value = encontrado.Id.ToString();
                Session["insumoEncontrado"] = encontrado;

                lblInsumoEncontrado.CssClass = "d-block mt-1 text-success";
                lblInsumoEncontrado.Text = "✓ " + encontrado.Nombre + " — " + encontrado.Precio.ToString("C") + " (Stock: " + encontrado.Stock + ")";
            }
        }

        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(hfIdInsumoSeleccionado.Value))
                    throw new Exception("Buscá y confirmá un insumo válido antes de agregar.");

                int cantidad;
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                    throw new Exception("La cantidad debe ser un número mayor a 0.");

                Insumo insumoSeleccionado = (Insumo)Session["insumoEncontrado"];

                if (insumoSeleccionado == null || insumoSeleccionado.Id != int.Parse(hfIdInsumoSeleccionado.Value))
                    throw new Exception("Volvé a buscar el insumo, la selección no es válida.");

                if (cantidad > insumoSeleccionado.Stock)
                    throw new Exception("No hay stock suficiente. Stock disponible: " + insumoSeleccionado.Stock);

                DetallePedido nuevo = new DetallePedido();
                nuevo.Pedido = new Pedido();
                nuevo.Pedido.Id = idPedido;
                nuevo.Insumo = insumoSeleccionado;
                nuevo.Cantidad = cantidad;
                nuevo.PrecioUnitario = insumoSeleccionado.Precio;

                DetallePedidoNegocio negocio = new DetallePedidoNegocio();
                negocio.agregar(nuevo);

                InsumoNegocio insumoNegocio = new InsumoNegocio();
                insumoNegocio.descontarStock(insumoSeleccionado.Id, cantidad);

                txtBuscarInsumo.Text = "";
                txtCantidad.Text = "1";
                hfIdInsumoSeleccionado.Value = "";
                lblInsumoEncontrado.Visible = false;
                Session["insumoEncontrado"] = null;
                lblErrorInsumo.Visible = false;

                cargarDetallePedido();
            }
            catch (Exception ex)
            {
                lblErrorInsumo.Text = ex.Message;
                lblErrorInsumo.Visible = true;
            }
        }

        protected void btnQuitarInsumo_Click(object sender, EventArgs e)
        {
            int idDetalle = int.Parse(((Button)sender).CommandArgument);

            DetallePedidoNegocio negocio = new DetallePedidoNegocio();

            DetallePedido detalle = negocio.buscarPorId(idDetalle);

            negocio.eliminarInsumoDeDetalle(idDetalle);

            if (detalle != null)
            {
                InsumoNegocio insumoNegocio = new InsumoNegocio();
                insumoNegocio.devolverStock(detalle.Insumo.Id, detalle.Cantidad);
            }

            cargarDetallePedido();
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

        protected void btnCerrarPedido_Click(object sender, EventArgs e)
        {
            PedidoNegocio negocio = new PedidoNegocio();
            negocio.cerrarPedido(idPedido);

            Response.Redirect("~/Default.aspx", false);
        }
    }
}