using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;
using Negocio;

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
    }
}