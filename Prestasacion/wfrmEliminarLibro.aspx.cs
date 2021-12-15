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
    public partial class wfrmEliminarLibro : System.Web.UI.Page
    {
        Elibro elibro;
        LNLibro libroLogica= new LNLibro(config.getCadConect);
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (Session["_claveLibro"] != null)
                { 

                    recuperarLibro(Session["_claveLibro"].ToString());
                }
                else
                {
                    Session["_wrn"] = "No se ha seleccionado ningun libro para eliminar";
                    btnEliminar.Enabled = false;
                }
                   
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error:{ex.Message}";

            }
        }

        private void recuperarLibro(string clave)
        {   
            DataTable dt;
            string condicion = $" Clave = '{clave}' ";
            dt = libroLogica.listarTodos(condicion, true);
            if (dt != null)
            {
                ViewState["_titulo"] = dt.Rows[0][1];
                ViewState["_autor"] = dt.Rows[0][2];
                ViewState["_categoria"] = dt.Rows[0][3];
            }
            else
            {
                Session["_wrn"] = "El libro selecionado ya no existe en la base de datos ";
                btnEliminar.Enabled = false;
            }
            
               
            
                ///TODO:CAMBIAR 
                
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int result = 0;
            try
            {
                if (Session["_claveLibro"] != null)
                {
                    result = libroLogica.eliminar(Session["_claveLibro"].ToString());
                    if (result > 0)
                    {
                        Session.Remove("_err");
                        Session.Remove("_wrn");
                        Session.Remove("_exito");
                        Session["_exito"] = $"El libro {Session["_titulo"]} se ha eliminado de forma correcta";
                        Response.Redirect("wfrmListaLibros.aspx", false);
                    }
                    else
                    {
                        Session["_wrn"] = $"No se ha podido eliminar el libro";
                    }
                  
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $"Error: {ex.Message}";
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("wfrmListaLibros.aspx");
        }
    }
}