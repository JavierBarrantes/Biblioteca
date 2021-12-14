using Entidades;
using LogicaNegocio;
using System;
using System.Data;
using System.Web.UI;

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
            llenarGVCate();
        }
        private void llenarGVAutor(string condicion = "")
        {
            DataTable datos;
            try
            {
                datos = autor.ListarRegistros(condicion);
                if (datos != null)
                {
                    gvAutores.DataSource = datos;
                    gvAutores.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $"error: {ex.Message}";
            }
        }
        private void llenarGVCate(string condicion = "")
        {
            DataTable datos;
            try
            {
                datos = categoria.ListarRegistros(condicion);
                if (datos != null)
                {
                    gvCate.DataSource = datos;
                    gvCate.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $"error: {ex.Message}";
            }
        }

        private void llenarDGV()
        {
            llenarGVCate($"nombre like '%{txtCategoria.Text}%'");

        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            llenarGVAutor($"nombre like '%{txtAutorModal.Text}%'");
            string javaScript = "abrirModal();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }
    }
}