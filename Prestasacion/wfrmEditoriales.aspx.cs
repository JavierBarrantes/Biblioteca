using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Prestasacion
{
    public partial class wfrmEditoriales : System.Web.UI.Page
    {
        LNEDitorial ediLogica = new LNEDitorial(config.getCadConect);
        EEditorial editorial = new EEditorial();
        Elibro elibro = new Elibro();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarDatos("");

            }
        }

        private void CargarDatos(string clave)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = ediLogica.listarTodos(clave, false);
                if (datos != null)
                {
                    dvEditorial.DataSource = datos;
                    dvEditorial.DataBind();

                }
                else
                {
                    Session["_wrn"] = "No se encontraron Editoriales";
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error:{ex}";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos($"nombre like '%{txtFiltrarNombre.Text}'");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmEliminarEditorial.aspx");
        }

        protected void btnLibroNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmMantenimientoEditorial.aspx");
        }

        protected void dvEditorial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dvEditorial.PageIndex = e.NewPageIndex;
            CargarDatos("");
        }

        protected void lkbEliminar_Command(object sender, CommandEventArgs e)
        {
            Session["_ClaveEdi"] = e.CommandArgument.ToString();
            Response.Redirect("wfrmEliminarEditorial.aspx");
        }

        protected void lnkEjemplar_Command(object sender, CommandEventArgs e)
        {
            Session["_ClaveEdi"] = e.CommandArgument.ToString();
            Response.Redirect("wfrmListaEje.aspx");
        }

        protected void lnkModifcar_Command(object sender, CommandEventArgs e)
        {
            Session["_ClaveEdi"] = e.CommandArgument.ToString();
            Response.Redirect("wfrmMantenimientoEditorial.aspx");
        }
    }
}