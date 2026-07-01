using Dominio;
using Negocio;
using System;
using System.Web.UI;

namespace RestoWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login))
            {
                if (!Seguridad.sessionActiva(Session["usuario"]))
                    Response.Redirect("~/Login.aspx", false);
                else
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    lblUsuario.Text = usuario.NombreCompleto;
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}