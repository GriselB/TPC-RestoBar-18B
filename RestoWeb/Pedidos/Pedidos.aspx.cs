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
                    cargarFiltros();
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
        private void cargarFiltros()
        {
            cargarMesasFiltro();
            cargarMeserosFiltro();
        }
        private void cargarMesasFiltro()
        {
            MesaNegocio negocio = new MesaNegocio();
            List<Mesa> mesas = negocio.listar();

            ddlMesa.Items.Clear();
            ddlMesa.Items.Add(new ListItem("Todas", ""));

            foreach (Mesa mesa in mesas)
            {
                if (mesa.Activo)
                {
                    ddlMesa.Items.Add(new ListItem(
                        "Mesa " + mesa.Numero.ToString(),
                        mesa.Id.ToString()
                    ));
                }
            }
        }
        private void cargarMeserosFiltro()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Usuario> usuarios = negocio.listar();

            ddlMesero.Items.Clear();
            ddlMesero.Items.Add(new ListItem("Todos", ""));

            foreach (Usuario usuario in usuarios)
            {
                if (Seguridad.esMesero(usuario))
                {
                    ddlMesero.Items.Add(new ListItem(
                        usuario.Nombre + " " + usuario.Apellido,
                        usuario.Id.ToString()
                    ));
                }
            }

            if (Seguridad.esMesero(Session["usuario"]))
            {
                Usuario usuarioActual = (Usuario)Session["usuario"];

                ddlMesero.SelectedValue = usuarioActual.Id.ToString();
                ddlMesero.Enabled = false;
            }
        }
        private void cargarPedidos()
        {
            PedidoNegocio negocio = new PedidoNegocio();
            Usuario usuario = (Usuario)Session["usuario"];

            DateTime? desde = null;
            DateTime? hasta = null;

            DateTime fechaAux;

            if (!string.IsNullOrWhiteSpace(txtDesde.Text))
            {
                if (DateTime.TryParse(txtDesde.Text.Replace("T", " "), out fechaAux))
                    desde = fechaAux;
                else
                    throw new Exception("La fecha desde no es válida.");
            }

            if (!string.IsNullOrWhiteSpace(txtHasta.Text))
            {
                if (DateTime.TryParse(txtHasta.Text.Replace("T", " "), out fechaAux))
                    hasta = fechaAux;
                else
                    throw new Exception("La fecha hasta no es válida.");
            }

            if (desde.HasValue && hasta.HasValue && desde.Value > hasta.Value)
                throw new Exception("La fecha desde no puede ser mayor que la fecha hasta.");

            int? idMesa = null;

            if (ddlMesa.SelectedValue != "")
                idMesa = int.Parse(ddlMesa.SelectedValue);

            int? idMesero = null;

            if (Seguridad.esMesero(Session["usuario"]))
            {
                idMesero = usuario.Id;
            }
            else
            {
                if (ddlMesero.SelectedValue != "")
                    idMesero = int.Parse(ddlMesero.SelectedValue);
            }

            bool? activo = null;

            if (ddlEstado.SelectedValue != "")
                activo = ddlEstado.SelectedValue == "1";

            List<Pedido> lista = negocio.listarPedidos(
                desde,
                hasta,
                idMesa,
                idMesero,
                activo
            );

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
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txtDesde.Text = "";
                txtHasta.Text = "";

                ddlMesa.SelectedValue = "";
                ddlEstado.SelectedValue = "";

                if (!Seguridad.esMesero(Session["usuario"]))
                    ddlMesero.SelectedValue = "";

                cargarPedidos();
            }
            catch (Exception ex)
            {
                Session["error"] = "No se pudieron limpiar los filtros.";
                Session["paginaAnteriorError"] = Request.RawUrl;

                Response.Redirect("~/Error.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPedidos();
            }
            catch (Exception ex)
            {
                Session["error"] = "No se pudieron filtrar los pedidos.";
                Session["paginaAnteriorError"] = Request.RawUrl;

                Response.Redirect("~/Error.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}