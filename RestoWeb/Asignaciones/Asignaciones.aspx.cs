using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace RestoWeb.Mesas
{
    public partial class Asignaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.esGerente(Session["usuario"]))
                {
                    Response.Redirect("~/Default.aspx", false);
                    return;
                }

                if (!IsPostBack)
                    cargarGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cargarGrilla()
        {
            AsignacionNegocio negocio = new AsignacionNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            List<Asignacion> asignaciones = negocio.listarVigentes();
            List<Usuario> meseros = usuarioNegocio.listar().FindAll(x => Seguridad.esMesero(x) && x.Activo);

            var filas = new System.Collections.ArrayList();
            foreach (Asignacion a in asignaciones)
            {
                filas.Add(new
                {
                    IdMesa = a.Mesa.Id,
                    NumeroMesa = "Mesa " + a.Mesa.Numero,
                    DescripcionMesa = a.Mesa.Descripcion,
                    MeseroActual = a.Usuario != null ? a.Usuario.NombreCompleto : "Sin asignar"
                });
            }

            Session["listaMeseros"] = meseros;
            dgvAsignaciones.DataSource = filas;
            dgvAsignaciones.DataBind();

            foreach (GridViewRow fila in dgvAsignaciones.Rows)
            {
                DropDownList ddl = (DropDownList)fila.FindControl("ddlMesero");
                ddl.DataSource = meseros;
                ddl.DataTextField = "NombreCompleto";
                ddl.DataValueField = "Id";
                ddl.DataBind();
                ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione un mesero", "0"));

                string meseroActual = fila.Cells[2].Text;
                Button btnQuitar = (Button)fila.FindControl("btnQuitarAsignacion");
                btnQuitar.Visible = meseroActual != "Sin asignar";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow fila = (GridViewRow)btn.NamingContainer;
                int idMesa = int.Parse(dgvAsignaciones.DataKeys[fila.RowIndex].Value.ToString());
                DropDownList ddl = (DropDownList)fila.FindControl("ddlMesero");

                if (ddl.SelectedValue == "0")
                    throw new Exception("Debe seleccionar un mesero.");

                AsignacionNegocio negocio = new AsignacionNegocio();
                negocio.asignar(idMesa, int.Parse(ddl.SelectedValue));

                lblExito.Text = "Mesa asignada correctamente.";
                lblExito.Visible = true;
                lblError.Visible = false;

                cargarGrilla();
                
            }
            catch (Exception ex)
            {
               lblError.Text = ex.Message;
               lblError.Visible = true;
               lblExito.Visible = false;
               

            }
        }

        protected void btnQuitarAsignacion_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow fila = (GridViewRow)btn.NamingContainer;
                int idMesa = int.Parse(dgvAsignaciones.DataKeys[fila.RowIndex].Value.ToString());

                AsignacionNegocio negocio = new AsignacionNegocio();
                negocio.QuitarAsignacion(idMesa);

                lblExito.Text = "Asignación quitada correctamente.";
                lblExito.Visible = true;
                lblError.Visible = false;

                cargarGrilla();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                lblExito.Visible = false;
            }
        }
    }
}