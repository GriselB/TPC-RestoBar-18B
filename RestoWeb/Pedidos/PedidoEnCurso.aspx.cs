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
            try
            {
                if (!IsPostBack)
                {
                    cargarPantalla();
                }
            }catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Session["paginaAnteriorError"] = Request.RawUrl;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        private void cargarPantalla()
        {
            if (idPedido == 0)
            {
                Response.Redirect("~/Default.aspx", false);
                return;
            }

            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            Pedido pedido = pedidoNegocio.buscarPorId(idPedido);

            if (pedido == null)
            {
                Response.Redirect("~/Default.aspx", false);
                return;
            }

            int idPedidoActivoDeLaMesa = pedidoNegocio.buscarPedidoActivoPorMesa(pedido.Mesa.Id);
            bool pedidoActivo = (idPedidoActivoDeLaMesa == idPedido);

            cargarDatosPedido(pedidoActivo);
            cargarDetallePedido(pedidoActivo);

            btnCerrarPedido.Visible = pedidoActivo;
            pnlAgregarInsumo.Visible = pedidoActivo;
        }

        private void cargarDatosPedido(bool pedidoActivo)
        {
            lblMesa.Text = "Pedido N° " + idPedido;
            lblDatosPedido.Text = pedidoActivo ? "Detalle del pedido en curso" : "Este pedido ya está cerrado.";
        }

        private void cargarDetallePedido(bool pedidoActivo)
        {
            DetallePedidoNegocio negocio = new DetallePedidoNegocio();

            List<DetallePedido> lista = negocio.listarPorPedido(idPedido);

            dgvPedidoEnCurso.DataSource = lista;
            dgvPedidoEnCurso.DataBind();

            dgvPedidoEnCurso.Columns[4].Visible = pedidoActivo;

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
            Session["insumosEncontrados"] = null;

            repInsumosEncontrados.DataSource = null;
            repInsumosEncontrados.DataBind();
            repInsumosEncontrados.Visible = false;

            if (string.IsNullOrEmpty(texto))
            {
                lblInsumoEncontrado.Visible = false;
                return;
            }

            InsumoNegocio negocio = new InsumoNegocio();
            List<Insumo> lista = negocio.listar(texto, 0, false, false);

            if (lista.Count == 0)
            {
                lblInsumoEncontrado.Visible = true;
                lblInsumoEncontrado.CssClass = "badge bg-danger-subtle text-danger-emphasis";
                lblInsumoEncontrado.Text = "Sin resultados";
            }
            else if (lista.Count == 1)
            {
                Insumo encontrado = lista[0];

                hfIdInsumoSeleccionado.Value = encontrado.Id.ToString();
                Session["insumoEncontrado"] = encontrado;

                lblInsumoEncontrado.Visible = true;
                lblInsumoEncontrado.CssClass = "badge bg-success-subtle text-success-emphasis";
                lblInsumoEncontrado.Text = "✓ " + encontrado.Nombre + " · Stock: " + encontrado.Stock;
            }
            else if (lista.Count <= 10)
            {
                Session["insumosEncontrados"] = lista;

                lblInsumoEncontrado.Visible = false;

                repInsumosEncontrados.DataSource = lista;
                repInsumosEncontrados.DataBind();
                repInsumosEncontrados.Visible = true;
            }
            else
            {
                lblInsumoEncontrado.Visible = true;
                lblInsumoEncontrado.CssClass = "badge bg-danger-subtle text-danger-emphasis";
                lblInsumoEncontrado.Text = lista.Count + " coincidencias, sé más específico";
            }
        }

        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                Pedido pedido = pedidoNegocio.buscarPorId(idPedido);

                if (pedido == null || pedidoNegocio.buscarPedidoActivoPorMesa(pedido.Mesa.Id) != idPedido)
                    throw new Exception("Este pedido ya está cerrado.");

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
                repInsumosEncontrados.Visible = false;
                Session["insumoEncontrado"] = null;
                lblErrorInsumo.Visible = false;

                cargarDetallePedido(true);
            }
            catch (Exception ex)
            {
                lblErrorInsumo.Text = ex.Message;
                lblErrorInsumo.Visible = true;
            }
        }

        protected void btnQuitarInsumo_Click(object sender, EventArgs e)
        {
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            Pedido pedido = pedidoNegocio.buscarPorId(idPedido);

            if (pedido == null || pedidoNegocio.buscarPedidoActivoPorMesa(pedido.Mesa.Id) != idPedido)
                return;

            int idDetalle = int.Parse(((Button)sender).CommandArgument);

            DetallePedidoNegocio negocio = new DetallePedidoNegocio();

            DetallePedido detalle = negocio.buscarPorId(idDetalle);

            negocio.eliminarInsumoDeDetalle(idDetalle);

            if (detalle != null)
            {
                InsumoNegocio insumoNegocio = new InsumoNegocio();
                insumoNegocio.devolverStock(detalle.Insumo.Id, detalle.Cantidad);
            }

            cargarDetallePedido(true);
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

        protected string TextoInsumo(object item)
        {
            Insumo insumo = (Insumo)item;
            return insumo.Nombre + " — " + insumo.Precio.ToString("C") + " (Stock: " + insumo.Stock + ")";
        }

        protected void btnSeleccionarInsumo_Click(object sender, EventArgs e)
        {
            int idInsumo = int.Parse(((Button)sender).CommandArgument);

            List<Insumo> lista = (List<Insumo>)Session["insumosEncontrados"];
            Insumo seleccionado = lista.FindAll(x => x.Id == idInsumo)[0];

            hfIdInsumoSeleccionado.Value = seleccionado.Id.ToString();
            Session["insumoEncontrado"] = seleccionado;

            txtBuscarInsumo.Text = seleccionado.Nombre;

            repInsumosEncontrados.Visible = false;

            lblInsumoEncontrado.Visible = true;
            lblInsumoEncontrado.CssClass = "badge bg-success-subtle text-success-emphasis";
            lblInsumoEncontrado.Text = "✓ " + seleccionado.Nombre + " · Stock: " + seleccionado.Stock;
        }

        protected void btnBuscarInsumo_Click(object sender, EventArgs e)
        {
            buscarInsumo();
        }

    }

}