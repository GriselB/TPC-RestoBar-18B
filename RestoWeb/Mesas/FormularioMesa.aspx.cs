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
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumero.Text))
                    throw new Exception("El campo Número de mesa es obligatorio.");

                if (!int.TryParse(txtNumero.Text, out int numero))
                    throw new Exception("El número de mesa debe ser un número entero.");

                if (numero <= 0)
                    throw new Exception("El número de mesa debe ser mayor a cero.");

                Mesa mesa = new Mesa();
                MesaNegocio negocio = new MesaNegocio();

                mesa.Numero = numero;
                mesa.Descripcion = txtDescripcion.Text;

                if (Request.QueryString["id"] != null)
                {
                    mesa.Id = int.Parse(Request.QueryString["id"]);
                    mesa.Activo = chkActivo.Checked;
                    //negocio.modificarMesa(mesa);
                }
                else
                    negocio.agregarMesa(mesa);

                Response.Redirect("ListaMesas.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
    }
}