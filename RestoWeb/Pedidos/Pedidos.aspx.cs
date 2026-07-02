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
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cargarPedidos();
                }
            }
            catch (Exception ex)
            {
                Session["error"] = "No se pudo cargar el listado de pedidos.";
                Session["paginaAnteriorError"] = Request.RawUrl;

                Response.Redirect("~/Error.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        private void cargarPedidos()
        {
            PedidoNegocio negocio = new PedidoNegocio();
            Usuario usuario = (Usuario)Session["usuario"];

            List<Pedido> lista = new List<Pedido>();

            if (Seguridad.esMesero(Session["usuario"]))
            {
                lista = negocio.listarPedidos(usuario.Id);
            }
            else
            {
                lista = negocio.listarPedidos();
            }



            dgvPedidos.DataSource = lista;
            dgvPedidos.DataBind();
        }

        protected void dgvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "VerPedido")
                {
                    int idPedido;

                    if (!int.TryParse(e.CommandArgument.ToString(), out idPedido))
                        throw new Exception("El pedido seleccionado no es válido.");

                    Response.Redirect("~/Pedidos/PedidoEnCurso.aspx?IdPedido=" + idPedido, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                Session["error"] = "No se pudo abrir el pedido seleccionado.";
                Session["paginaAnteriorError"] = Request.RawUrl;

                Response.Redirect("~/Error.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}