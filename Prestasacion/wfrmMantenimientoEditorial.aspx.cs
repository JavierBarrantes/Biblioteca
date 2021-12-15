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
    public partial class wfrmListaEditorial : System.Web.UI.Page
    {
        LNEDitorial ediLogica = new LNEDitorial(config.getCadConect);
        EEditorial entiEdi=new EEditorial();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnGuardarE_Click(object sender, EventArgs e)
        {
            try
            {
                entiEdi.Clave = txtClaveEditorial.Text;
                entiEdi.Nombre = txtNombre.Text;
                if (ediLogica.claveRepetida(entiEdi.Clave) == false)
                {
                    if (ediLogica.editorialRepetido(entiEdi)==false)
                    {
                        if (ediLogica.insertar(entiEdi) > 0) {
                            Session["_exito"] = "Se inserto correctamente.";
                        }
                        else
                        {
                            Session["_wrn"] = "Un problema al insertar una editorial.";
                        };
                    }
                    else
                    {
                        Session["_wrn"] = "Este nombre  ya existe para una editorial."; 
                    }
                }
                else
                {
                    Session["_wrn"] = "Esta clave ya existe para una editorial.";
                }


            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error: {ex.Message}";
            }
        }

        protected void btnRegresarE_Click(object sender, EventArgs e)
        {
            Response.Redirect(".aspx");
        }
    }
}