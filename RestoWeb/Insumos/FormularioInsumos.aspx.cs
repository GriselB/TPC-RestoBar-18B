using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace RestoWeb.Insumos
{
    public partial class FormularioInsumos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cargarCategorias();

                    if (Request.QueryString["id"] != null)
                    {
                        lblTitulo.Text = "Editar insumo";

                        int id = int.Parse(Request.QueryString["id"]);
                        cargarInsumo(id);
                    }
                    else
                    {
                        lblTitulo.Text = "Nuevo insumo";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                // Response.Redirect("Error.aspx");
            }

        }
        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            ddlCategoria.DataSource = negocio.listar();
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();

            ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoría", ""));
        }
        private void cargarInsumo(int id)
        {
            InsumoNegocio negocio = new InsumoNegocio();

            //Tuve que hacer una corrección en el código porque al llamar a .listar no se estaba pasando ningun argumento y el método exige 3, lo dejo así para que compile pero después hay que corregirlo
            Insumo insumo = negocio.listar("", 0, false).Find(x => x.Id == id);

            if (insumo != null)
            {
                txtNombre.Text = insumo.Nombre;
                txtDescripcion.Text = insumo.Descripcion;
                txtPrecio.Text = insumo.Precio.ToString();
                txtStock.Text = insumo.Stock.ToString();

                ddlCategoria.SelectedValue = insumo.Categoria.Id.ToString();

                
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
                lblError.Text = "";

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new Exception("Debe ingresar un nombre.");

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                    throw new Exception("Debe ingresar un precio válido.");

                if (!int.TryParse(txtStock.Text, out int stock))
                    throw new Exception("Debe ingresar un stock válido.");

                if (ddlCategoria.SelectedValue == "")
                    throw new Exception("Debe seleccionar una categoría.");

                Insumo nuevo = new Insumo();

                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Descripcion = txtDescripcion.Text.Trim();
                nuevo.Precio = precio;
                nuevo.Stock = stock;

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

              

                InsumoNegocio negocio = new InsumoNegocio();

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    nuevo.Nombre = txtNombre.Text.Trim();
                    negocio.modificarInsumo(nuevo);
                }
                else
                {
                    nuevo.Nombre = txtNombre.Text.Trim();
                    negocio.agregarInsumo(nuevo);
                }

                Response.Redirect("ListaInsumos.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
    }
}
