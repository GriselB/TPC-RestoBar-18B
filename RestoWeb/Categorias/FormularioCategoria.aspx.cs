using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoWeb.Categorias
{
    public partial class FormularioCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                   
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                //Response.Redirect("Error.aspx"); Hay que crear la pagina de redirección cuando da error.
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
        }

    }
}