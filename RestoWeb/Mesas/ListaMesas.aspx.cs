using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace RestoWeb.Mesas
{
    public partial class ListaMesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MesaNegocio negocio = new MesaNegocio();
                Session["listaMesas"] = negocio.listar();
                cargarGrilla();
            }
        }

        private void cargarGrilla()
        {
            dgvMesas.DataSource = Session["listaMesas"];
            dgvMesas.DataBind();
        }
    }
}

