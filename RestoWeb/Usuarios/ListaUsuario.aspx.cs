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
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var usuarios = new[]
                {
                    new { Nombre = "Maxi", Apellido = "Programa", NombreUsuario = "mPrograma", Rol = "Mesero", Activo = true, Id = 1 },
                    new { Nombre = "Regina", Apellido = "Laurentino", NombreUsuario = "rLaurentino", Rol = "Mesero", Activo = true, Id = 2 },
                    new { Nombre = "Admin", Apellido = "", NombreUsuario = "admin", Rol = "Gerente", Activo = true, Id = 3 }
                };

                dgvUsuarios.DataSource = usuarios;
                dgvUsuarios.DataBind();
            }
        }
    }
}