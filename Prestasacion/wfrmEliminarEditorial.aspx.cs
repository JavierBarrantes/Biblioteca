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
    public partial class wfrmEliminarEditorial : System.Web.UI.Page
    {
        LNEDitorial editorialLogica = new LNEDitorial(config.getCadConect);
        EEditorial ediEnti = new EEditorial();
        protected void Page_Load(object sender, EventArgs e)
        {
            RecueperarEditorial();
        }
        private void RecueperarEditorial()
        {
            try
            {
                
                    DataTable dt;
                    string condicion = $" ClaveEditorial = '{Session["_ClaveEdi"].ToString()}' ";
                    dt = editorialLogica.listarTodos(condicion,true);
                    if (dt != null)
                    {
                        ViewState["_nombre"] = dt.Rows[0][1];
                      
                    }
                    else
                    {
                        Session["_wrn"] = "La editorial selecionada ya no existe en la base de datos ";
                        btnEliminarEditorial.Enabled = false;
                    }

            }
            catch (Exception ex)
            {

                Session["_err"]=$"Error: {ex.Message}";
            }
        }
        private void eliminar() {
            if (editorialLogica.unResgistro(ediEnti) < 1)
            {

                Session["_exito"] = "Se ha eliminado de manera correcta";
            }
            else
            {
                Session["_wrn"] = "Algo salio mal intenta de nuevo";
            };
        }

        protected void btnEliminarEditorial_Click(object sender, EventArgs e)
        {

            int result;

            if (Session["_ClaveEdi"] != null)
            {
                ediEnti.Clave = Session["_ClaveEdi"].ToString();
                 if (editorialLogica.unResgistro(ediEnti)<=0)
                {
                    result = editorialLogica.eliminar(Session["_ClaveEdi"].ToString());
                    if (result > 0)
                    {
                        Session.Remove("_err");
                        Session.Remove("_wrn");
                        Session.Remove("_exito");
                        Session["_exito"] = $"La editorial se ha eliminado de forma exitosa";
                        Response.Redirect("wfrmEditoriales.aspx",false);
                    }
                    else
                    {
                        Session["_wrn"] = $"No se ha podido eliminar la editorial";
                    }
                }
                else
                {
                    Session["_wrn"] = $"No se ha podido eliminar la editorial por que esta ligada a un ejemplar";
                    Response.Redirect("wfrmEditoriales.aspx", false);
                }
               

            }
        }
    }
}