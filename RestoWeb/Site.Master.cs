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

                    bool esGerente = Seguridad.esGerente(Session["usuario"]);

                    lnkMesas.Visible = esGerente;
                    lnkAsignaciones.Visible = esGerente;
                    navAdministracion.Visible = esGerente;
                    lnkUsuarios.Visible = esGerente;
                    lnkInsumos.Visible = esGerente;
                    lnkCategorias.Visible = esGerente;
                    navReportes.Visible = esGerente;
                    lnkReportes.Visible = esGerente;
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