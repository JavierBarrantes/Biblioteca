using System;
using System.Collections.Generic;
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
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void recuperarLibro(string clave)
        {
            string condicion = $"claveLibro='{clave}'";
            elibro=libroLogica.buscarRegistro(clave);
                ///TODO:CAMBIAR 
                
        }
    }
}