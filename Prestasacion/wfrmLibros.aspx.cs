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
            if (!IsPostBack)
            {
                llenarGVAutor();
                llenarGVCate();
            }
           
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
        //llenarGVAutor($"nombre like '%{txtAutorModal.Text}%'");
        //string javaScript = "abrirModal();";
        //ScriptManager.RegisterStartupScript(this, this.GetType(),"script", javaScript, true);
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            llenarGVAutor($"nombre like '%{txtAutorModal.Text}%'");
            string javaScript = "abrirModal();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void btnFiltrarCate_Click(object sender, EventArgs e)
        {
            llenarGVCate($"descripcion like '%{txtFiltrarCate.Text}%'"); ;
            string javaScript = "abrirModal2();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }   
         protected void gvAutores_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvAutores.PageIndex = e.NewPageIndex;
            btnFiltrar_Click(sender, e);
        }

        protected void gvCate_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvCate.PageIndex = e.NewPageIndex;
            btnFiltrarCate_Click(sender, e);
        }

        protected void lnkSelecionarAutor_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            recuperarAutor(e.CommandArgument.ToString());
          
        }

        private void recuperarAutor(string id)
        {
            string condicion = $"claveAutor='{id}'";
            EAutor autorC;

            try
            {
                autorC = autor.BuscarRegistro(condicion);
                txtIdAutor.Text = autorC.ClaveAutor;
                txtAutor.Text = autorC.Nombre + " " + autorC.APPaterno;

            }
            catch (Exception ex )
            {

                Session["_err"]=$"error :{ex.Message}";
            }

        }

        protected void lnbSelecionarCate_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            recuperarCates(e.CommandArgument.ToString());
        }

        private void recuperarCates(string clave)
        {
            string condicion = $"claveCategoria='{clave}'";
            ECategoria cate;
            try
            {
                cate = categoria.BuscarRegistro(condicion);
                if (cate != null)
                {
                    txtIdCate.Text = cate.ClaveCategoria;
                    txtCategoria.Text = cate.Descripcion;
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error : {ex.Message}";
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTitulo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (libro.claveRepetida(txtClaveLibro.Text) == false)
                {

                    //TODO:Revisar esto para actualiza
                    ECategoria cate = new ECategoria();
                    cate.ClaveCategoria = txtIdCate.Text;
                    elibro = new Elibro(txtClaveLibro.Text, txtTitulo.Text, txtIdAutor.Text, cate, false);
                    if (libro.libroRepetido(elibro) == false) //cargar todo
                    {
                        if (libro.insertar(elibro) > 0)
                        {
                            Session["_Exito"] = $"Felidades el libro" +
                                $"Titulo :{txtTitulo.Text} Autor:               {txtAutor.Text} Categoria: {txtCategoria.Text} ";
                            limpiar();
                        }
                        else
                        {
                            Session["_wrn"] = "La accion no se ha podido llegar acabo.";
                        }
                    }
                    else
                    {
                        Session["_wrn"] = "Atención el titulo ya existe para el Autor seleccionado";
                    }
                }
                else
                {
                    Session["_wrn"] = "Atención esta clave ya esta en uso debes cambiarla";
                }
            }
            catch (Exception ex)
            {

                Session["_err"]=$"{ex.Message}";
            }
         
        }
        private void limpiar()
        {
            txtAutor.Text = string.Empty;
            txtAutorModal.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtFiltrarCate.Text = string.Empty;
            txtIdCate.Text = string.Empty;
            txtClaveLibro.Text = string.Empty;
            txtTitulo.Text = string.Empty;
        
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session.Remove("_err");
            Session.Remove("_extio");
            Session.Remove("_wrn");
            Response.Redirect("wfrmListaLibros.aspx");
        }
    }
}