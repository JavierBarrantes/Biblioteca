using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using LogicaNegocio;

namespace Prestasacion
{
    public partial class wfrmLibros : System.Web.UI.Page
    {
        LNLibro libro = new LNLibro(config.getCadConect);
        LNAutor autor = new LNAutor(config.getCadConect);
        LNCategoria categoria = new LNCategoria(config.getCadConect);
        Elibro elibro;
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGVAutor();
        }
        private void llenarGVAutor(string condicion="")
        {
            DataTable datos;
            try
            {
                datos = autor.ListarRegistros(condicion);
                if (datos != null)
                {
                    gvAutores.DataSource =datos;
                    gvAutores.DataBind();                    
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $"error: {ex.Message}";
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            llenarGVAutor($"nombre like '%{txtAutorModal.Text}%'");
            string javaScript = "abrirModal();";
            ScriptManager.RegisterStartupScript(this,this.GetType(),"script",javaScript,true);
        }
    }
}