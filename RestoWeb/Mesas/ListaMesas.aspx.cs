using Dominio;
using System;
using System.Collections.Generic;
using Negocio;

namespace RestoWeb.Mesas
{
    public partial class ListaMesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.esGerente(Session["usuario"]))
                {
                    Response.Redirect("~/Default.aspx", false);
                    return;
                }

                if (!IsPostBack)
                {
                    MesaNegocio negocio = new MesaNegocio();
                    Session["listaMesas"] = negocio.listar();
                    filtrar();
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Session["paginaAnteriorError"] = Request.RawUrl;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        private void filtrar()
        {
            List<Mesa> lista = (List<Mesa>)Session["listaMesas"];

            string textoBusqueda = txtBusqueda.Text.ToUpper();
            string campo = ddlCampoBusqueda.SelectedValue;

            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                if (campo == "Numero")
                    lista = lista.FindAll(x => x.Numero.ToString().Contains(textoBusqueda));
                else if (campo == "Descripcion")
                    lista = lista.FindAll(x => x.Descripcion != null && x.Descripcion.ToUpper().Contains(textoBusqueda));
            }

            string estado = ddlEstado.SelectedValue;
            if (estado == "Activo")
                lista = lista.FindAll(x => x.Activo);
            else if (estado == "Inactivo")
                lista = lista.FindAll(x => !x.Activo);

            dgvMesas.DataSource = lista;
            dgvMesas.DataBind();
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        protected void ddlCampoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MesaNegocio negocio = new MesaNegocio();
            Session["listaMesas"] = negocio.listar();
            filtrar();
        }
    }
}