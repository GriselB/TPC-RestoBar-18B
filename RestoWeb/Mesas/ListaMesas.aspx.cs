using Dominio;
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
                var mesas = new[]
                {
                    new { Numero = 1, Descripcion = "Mesa del fondo", Activo = true, Mesero = "Maxi" },
                    new { Numero = 2, Descripcion = "Mesa terraza", Activo = true, Mesero = "Regina" },
                    new { Numero = 3, Descripcion = "Mesa ventana", Activo = false, Mesero = "Agus" },
                    new { Numero = 4, Descripcion = "Mesa patio", Activo = false, Mesero = "Gonza" }
                };

                dgvMesas.DataSource = mesas;
                dgvMesas.DataBind();
            }
        }
    }
}

