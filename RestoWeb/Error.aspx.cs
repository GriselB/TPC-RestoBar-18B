using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoWeb
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlDetalle.Visible = false;
                lblDetalleError.Text = "";

                if (Session["error"] != null)
                {
                    lblDetalleError.Text = Session["error"].ToString();
                    pnlDetalle.Visible = true;

                    Session["error"] = null;
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (Session["paginaAnteriorError"] != null)
            {
                string paginaAnterior = Session["paginaAnteriorError"].ToString();

                Session["paginaAnteriorError"] = null;

                Response.Redirect(paginaAnterior, false);
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }
}