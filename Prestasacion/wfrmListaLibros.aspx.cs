using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
namespace Prestasacion
{



    public partial class wfrmListaLibros : System.Web.UI.Page
    {
        //Elibro libro = new Elibro();
        LNLibro libro = new LNLibro(config.getCadConect);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFiltrarTitulo.Text = string.Empty;
                txtFiltrarTitulo.Focus();
                    CargarDatos("");
              
            }
        
        }

        private void limpiar()
        {
            if (!IsPostBack)
            {
                txtFiltrarTitulo.Text = string.Empty;
                txtFiltrarTitulo.Focus();
                CargarDatos("");
                
            }
        }

        private void CargarDatos(string condicion="")
        {
            DataTable datos = new DataTable();
            try
                //CON APLICATION HACER EL MENSAJE DE SUSURRO  AL DIRECTOR-
            {
                datos = libro.listarTodos(condicion,true);
                if(datos!= null)
                {
                    dtvLibros.DataSource = datos;
                    dtvLibros.DataBind();
                    Session["_wrn"] = "Prueba";
                }
                else
                {
                   Session["_wrn"] ="No se encontraron libros";
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error:{ex}";
            }
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            //Session["_wrn"] = e.CommandArgument.ToString();
            
        }


        protected void dtvLibros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtvLibros.PageIndex = e.NewPageIndex;
            CargarDatos();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         
                CargarDatos($"titulo like '%{txtFiltrarTitulo.Text}'");
            
         
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void btnLibroNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmLibros.aspx");
        }
    }
}