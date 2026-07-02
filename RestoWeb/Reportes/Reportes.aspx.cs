using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoWeb.Reportes
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esGerente(Session["usuario"]))
            {
                Response.Redirect("~/Default.aspx", false);
                return;
            }

            try
            {
                if (!IsPostBack)
                {

                }  
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
        }
    }
}