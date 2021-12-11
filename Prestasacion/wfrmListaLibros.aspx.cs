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
            txtFiltrarTitulo.Text = string.Empty;
            txtFiltrarTitulo.Focus();
            CargarDatos();
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
    }
}