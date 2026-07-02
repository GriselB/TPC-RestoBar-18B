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
                if (Seguridad.esMesero(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    cargarMesas(usuario.Id);
                    cargarAsignaciones();
                }
                else
                {
                    cargarMesas();
                    cargarAsignaciones();
                }

                repMesas.DataSource = Session["listaMesas"];
                repMesas.DataBind();
            }
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

                List<Asignacion> asignaciones = (List<Asignacion>)Session["listaAsignaciones"];
                List<Asignacion> encontradas = asignaciones.FindAll(x => x.Mesa.Id == idMesa && x.Usuario != null);

                if (encontradas.Count == 0)
                {
                    lblMesaSeleccionada.Text = "";
                    lblErrorApertura.Text = "Esta mesa no tiene mesero asignado. No se puede abrir el pedido.";
                    lblErrorApertura.Visible = true;
                    btnConfirmarApertura.Visible = false;
                    btnIrAAsignaciones.Visible = true;
                }
                else
                {
                    lblMesaSeleccionada.Text = "¿Desea abrir un nuevo pedido para Mesa N° " + mesa.Numero + "?";
                    lblErrorApertura.Visible = false;
                    btnConfirmarApertura.Visible = true;
                    btnIrAAsignaciones.Visible = false;
                }

                hfMostrarModal.Value = "1";
            }
        }

        protected void btnIrAAsignaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Asignaciones/Asignaciones.aspx", false);
        }

        protected void btnConfirmarApertura_Click(object sender, EventArgs e)
        {
            try
            {
                int idMesa = int.Parse(hfIdMesa.Value);

                List<Asignacion> asignaciones = (List<Asignacion>)Session["listaAsignaciones"];
                List<Asignacion> encontradas = asignaciones.FindAll(x => x.Mesa.Id == idMesa && x.Usuario != null);

                if (encontradas.Count == 0)
                    throw new Exception("Esta mesa no tiene mesero asignado. No se puede abrir el pedido.");

                int idMeseroAsignado = encontradas[0].Usuario.Id;

                PedidoNegocio negocio = new PedidoNegocio();
                int idPedido = negocio.abrirPedido(idMesa, idMeseroAsignado);

                hfMostrarModal.Value = "0";
                Response.Redirect("Pedidos/PedidoEnCurso.aspx?IdPedido=" + idPedido);
            }
            catch (Exception ex)
            {
                hfMostrarModal.Value = "1";
                lblErrorApertura.Text = ex.Message;
                lblErrorApertura.Visible = true;
                btnConfirmarApertura.Visible = false;
                btnIrAAsignaciones.Visible = true;
            }
        }

        private void cargarMesas()
        {
            MesaNegocio negocio = new MesaNegocio();
            List<Mesa> mesas = negocio.listar().FindAll(x => x.Activo);
            Session["listaMesas"] = mesas;
        }
        private void cargarMesas(int id)
        {
            MesaNegocio negocio = new MesaNegocio();
            List<Mesa> mesas = negocio.listarMesasPorUsuario(id);
            Session["listaMesas"] = mesas;
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            hfMostrarModal.Value = "0";

            if (Seguridad.esMesero(Session["usuario"]))
            {
                Usuario usuario = (Usuario)Session["usuario"];
                cargarMesas(usuario.Id);
            }
            else
            {
                cargarMesas();
            }

            cargarAsignaciones();

            repMesas.DataSource = Session["listaMesas"];
            repMesas.DataBind();
        }
        protected void cargarAsignaciones()
        {
            AsignacionNegocio negocio = new AsignacionNegocio();
            Session["listaAsignaciones"] = negocio.listarVigentes();
        }
        protected string ObtenerMeseroAsignado(object idMesaObj)
        {
            int idMesa = Convert.ToInt32(idMesaObj);

            List<Asignacion> asignaciones = Session["listaAsignaciones"] as List<Asignacion>;

            if (asignaciones == null)
                return "Sin asignar";

            foreach (Asignacion asignacion in asignaciones)
            {
                if (asignacion.Mesa != null && asignacion.Mesa.Id == idMesa)
                {
                    if (asignacion.Usuario != null)
                        return asignacion.Usuario.Nombre + " " + asignacion.Usuario.Apellido;

                    return "Sin asignar";
                }
            }

            return "Sin asignar";
        }
    }
}