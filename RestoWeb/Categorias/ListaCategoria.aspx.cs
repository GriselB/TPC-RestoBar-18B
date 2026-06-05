using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoWeb.Categorias
{
    public partial class ListaCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var detalle = new[]
                 {
                        new{Descripcion="Bebida"},
                        new{Descripcion="Plato"},
                        new{Descripcion="Postre"},
                        new{Descripcion="Entrada"}
                 };
                    dgvCategoria.DataSource = detalle;
                    dgvCategoria.DataBind();

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