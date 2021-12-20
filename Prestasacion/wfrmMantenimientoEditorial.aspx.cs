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
        EEditorial entiEdi = new EEditorial();
        HttpCookie cookie = new HttpCookie("MyCookieEditorial");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["_ClaveEdi"] != null)
                {

                    entiEdi = ediLogica.buscarRegistro(Session["_ClaveEdi"].ToString());
                    txtClaveEditorial.Text = entiEdi.Clave;
                    txtNombre.Text = entiEdi.Nombre;
                    cookie["_clave"] = entiEdi.Clave;
                    cookie["_nombre"] = entiEdi.Nombre;
                    cookie.Expires = DateTime.Now.AddMinutes(20);
                    Response.Cookies.Add(cookie);
                }
            }
           
        
        }

        private bool haycambios(ref bool bcl,ref bool bn)
        {
            bool result = false;
            if (Request.Cookies["MyCookieEditorial"]["_clave"] != txtClaveEditorial.Text)//Clave Vieja
            {
                bcl = true;
                entiEdi.Clave=txtClaveEditorial.Text;
                result = true;
            }
            if (Request.Cookies["MyCookieEditorial"]["_nombre"] != txtNombre.Text)
            {
                bn = true;
                entiEdi.Nombre = txtNombre.Text;
                result = true;
            }
            return result;
        }

        protected void btnGuardarE_Click(object sender, EventArgs e)
        {
            bool bcl = false;
            bool bn = false;
            bool claveCambio = false;
            bool valido = false;

            try
            {
                if (Session["_ClaveEdi"] != null)
                {
                    entiEdi.Clave = Request.Cookies["MyCookieEditorial"]["_clave"]; ;
                    entiEdi.Nombre = Request.Cookies["MyCookieEditorial"]["_nombre"]; ;
                    if(haycambios(ref bcl,ref bn)==true)
                    {
                        if (bcl ==true)
                        {
                            if(ediLogica.claveRepetida(entiEdi.Clave) == false)
                            {
                                valido = true;
                                claveCambio = true;
                            }
                            else
                            {
                                valido = true;
                                Session["_wrn"] = "Esta clave ya existe para una editorial.";
                            }
                        }
                        if(bn==true)
                        {
                            if (ediLogica.editorialRepetido(entiEdi) == false)
                            {

                                valido = true;
                            }
                            else
                            {
                                valido = true;
                                Session["_wrn"] = "Este nombre  ya existe para una editorial.";
                            }
                        }
                        if (valido == true && claveCambio==true)
                        {
                            if (ediLogica.modificar(entiEdi, Session["_ClaveEdi"].ToString()) > 0)
                            {

                                Session["_exito"] = "La editorial se actualizo de forma correcta.";
                            }
                            else
                            {
                                Session["_wrn"] = "error al actualizar una editorial.";
                            }
                        }
                        else if (valido == true)
                        {
                            if (ediLogica.modificar(entiEdi) > 0)
                            {

                                Session["_exito"] = "La editorial se actualizo de forma correcta.";
                            }
                            else
                            {
                                Session["_wrn"] = "error al actualizar una editorial.";
                            }
                        }
                      
                    }
                    else
                    {
                        if (ediLogica.modificar(entiEdi) > 0)
                        {

                            Session["_exito"] = "La editorial se actualizo de forma correcta.";
                        }
                        else
                        {
                            Session["_wrn"] = "error al actualizar una editorial.";
                        }
                    }
                
                }
                else
                {
                    entiEdi.Clave = txtClaveEditorial.Text;
                    entiEdi.Nombre = txtNombre.Text;
                    if (ediLogica.claveRepetida(entiEdi.Clave) == false)
                    {
                        if (ediLogica.editorialRepetido(entiEdi) == false)
                        {
                            if (ediLogica.insertar(entiEdi) > 0)
                            {
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



            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error: {ex.Message}";
            }
        }

        protected void btnRegresarE_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmEditoriales.aspx");
        }
    }
}