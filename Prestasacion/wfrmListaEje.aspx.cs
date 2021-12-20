using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Prestasacion
{
    public partial class wfrmListaEje : System.Web.UI.Page
    {
        LNEDitorial ediLogica = new LNEDitorial(config.getCadConect);
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos(string clave="")
        {
            DataTable datos = new DataTable();
            try
            {
                datos = ediLogica.editoriales(Session["_ClaveEdi"].ToString());
                if (datos != null)
                {
                    gvEjemplares.DataSource = datos;
                    gvEjemplares.DataBind();

                }
                else
                {
                    Session["_wrn"] = "No se encontraron Ejemplares con esa editorial";
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error:{ex}";
            }
        }
    }
}