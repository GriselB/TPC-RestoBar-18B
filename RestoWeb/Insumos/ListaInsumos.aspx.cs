using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoWeb.Insumos
{
    public partial class ListaInsumos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var detalle = new[]
                 {
                        new{Nombre="Milanesa", Descripcion="Carne empanada y frita", Precio="$5000", Stock=1000, Categoria="Plato", Activo = true},
                        new{Nombre="Coca Cola Zero", Descripcion="Tremenda gaseosa", Precio="$1000", Stock=7000, Categoria="Bebida", Activo = true}
                 };
                    dgvInsumos.DataSource = detalle;
                    dgvInsumos.DataBind();
                    
                }
            }

            catch (Exception ex)
            {
                Session.Add("error", ex);
                //Response.Redirect("Error.aspx"); Hay que crear la pagina de redirección cuando da error.
            }

        }
}
}