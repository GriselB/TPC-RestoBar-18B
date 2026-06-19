using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace RestoWeb.Usuarios
{
        public partial class ListaUsuario : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    cargarUsuarios();
                }
            }

            private void cargarUsuarios()
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                List<Usuario> usuarios = negocio.listar();

                dgvUsuarios.DataSource = usuarios;
                dgvUsuarios.DataBind();
            }
        }
    }