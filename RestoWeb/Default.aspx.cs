using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                cargarMesas();

            repMesas.DataSource = Session["listaMesas"];
            repMesas.DataBind();
        }

        protected bool MesaTienePedido(object idMesa)
        {
            MesaNegocio negocio = new MesaNegocio();
            return negocio.mesaTienePedidoActivo((int)idMesa);
        }

        protected void btnMesa_Click(object sender, EventArgs e)
        {
            int idMesa = int.Parse(((LinkButton)sender).CommandArgument);
            MesaNegocio mesaNegocio = new MesaNegocio();
            bool tienePedido = mesaNegocio.mesaTienePedidoActivo(idMesa);

            if (tienePedido)
            {
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                int idPedido = pedidoNegocio.buscarPedidoActivoPorMesa(idMesa);
                Response.Redirect("Pedidos/PedidoEnCurso.aspx?IdPedido=" + idPedido);
            }
            else
            {
                Mesa mesa = mesaNegocio.listar(idMesa)[0];
                hfIdMesa.Value = idMesa.ToString();
                lblMesaSeleccionada.Text = "¿Desea abrir un nuevo pedido para Mesa N° " + mesa.Numero + "?";
                hfMostrarModal.Value = "1";
            }
        }

        protected void btnConfirmarApertura_Click(object sender, EventArgs e)
        {
            hfMostrarModal.Value = "0";
            int idMesa = int.Parse(hfIdMesa.Value);
            Usuario usuario = (Usuario)Session["usuario"];
            PedidoNegocio negocio = new PedidoNegocio();
            int idPedido = negocio.abrirPedido(idMesa, usuario.Id);
            Response.Redirect("Pedidos/PedidoEnCurso.aspx?IdPedido=" + idPedido);
        }

        private void cargarMesas()
        {
            MesaNegocio negocio = new MesaNegocio();
            List<Mesa> mesas = negocio.listar().FindAll(x => x.Activo);
            Session["listaMesas"] = mesas;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            hfMostrarModal.Value = "0";
            cargarMesas();
            repMesas.DataSource = Session["listaMesas"];
            repMesas.DataBind();
        }
    }
}