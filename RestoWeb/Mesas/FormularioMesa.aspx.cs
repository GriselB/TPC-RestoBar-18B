using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace RestoWeb.Mesas
{
    public partial class FormularioMesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                    if (id != "")
                        lblTitulo.Text = "Editar mesa N° " + id;
                    else
                        lblTitulo.Text = "Nueva mesa";
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