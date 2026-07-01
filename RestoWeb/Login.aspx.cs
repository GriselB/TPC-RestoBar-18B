using System;
using Dominio;
using Negocio;

namespace RestoWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
                Response.Redirect("Default.aspx", false);
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
                    throw new Exception("El campo Usuario es obligatorio.");

                if (string.IsNullOrWhiteSpace(txtPass.Text))
                    throw new Exception("El campo Contraseña es obligatorio.");

                Usuario usuario = new Usuario();
                usuario.NombreUsuario = txtNombreUsuario.Text;
                usuario.Pass = txtPass.Text;

                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario resultado = negocio.login(usuario);

                if (resultado != null)
                {
                    Session.Add("usuario", resultado);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
    }
}