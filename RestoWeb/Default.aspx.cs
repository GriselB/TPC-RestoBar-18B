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
            {
                MesaNegocio negocio = new MesaNegocio();
                List<Mesa> mesas = negocio.listar();

                repMesas.DataSource = mesas;
                repMesas.DataBind();
            }
        }

        protected void repMesas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarMesa")
            {
                int idMesa = int.Parse(e.CommandArgument.ToString());
                MesaNegocio negocio = new MesaNegocio();
                bool tienepedido = negocio.mesaTienePedidoActivo(idMesa);
                int idPedido;

                if (tienepedido)
                {
                    PedidoNegocio pedido = new PedidoNegocio();
                    idPedido = pedido.buscarPedidoActivoPorMesa(idMesa);

                }
                else
                {
                    PedidoNegocio pedido = new PedidoNegocio();
                    Usuario usuario = (Usuario)Session["usuario"];

                    pedido.abrirPedido(idMesa, usuario.Id);


                idPedido = pedido.buscarPedidoActivoPorMesa(idMesa);
                }
                Response.Redirect("Pedidos/PedidoEnCurso.aspx?idMesa=" + idMesa);
            }
        }
    }
}
