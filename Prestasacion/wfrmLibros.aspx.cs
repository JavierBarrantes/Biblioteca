using Entidades;
using LogicaNegocio;
using System;
using System.Data;
using System.Web;
using System.Web.UI;

namespace Prestasacion
{
    public partial class wfrmLibros : System.Web.UI.Page
    {
        LNLibro libro = new LNLibro(config.getCadConect);
        LNAutor autor = new LNAutor(config.getCadConect);
        LNCategoria categoria = new LNCategoria(config.getCadConect);
        Elibro elibro = new Elibro();
        HttpCookie cookie = new HttpCookie("MyCookie");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                limpiar();
                string codicion = "";
                if (Session["_claveLibro"] != null)
                {
                    codicion = $"'{Session["_claveLibro"]}'";
                    elibro = libro.buscarRegistro(codicion);
                    if (elibro != null)
                    {

                        txtClaveLibro.Text = elibro.ClaveLibro;
                        txtTitulo.Text = elibro.Titulo;
                        recuperarCates(elibro.Categoria.ClaveCategoria);
                        recuperarAutor(elibro.ClaveAutor);
                        cookie["_clave"] = elibro.ClaveLibro;
                        cookie["_titulo"] = elibro.Titulo;
                        cookie["_cate"] = elibro.Categoria.ClaveCategoria;
                        cookie["_idAutor"] = elibro.ClaveAutor;
                        //cookie["_cateN"] = elibro.Categoria.Descripcion;
                        //cookie["_autor"] =txtAutor.Text;
                        cookie.Expires = DateTime.Now.AddMinutes(20);
                        Response.Cookies.Add(cookie);
                        //if (cookie.Expires.Minute==0)
                        //{
                        //    Session["_wrn"] = $"Se expiro el tiempo";
                        //    Response.Redirect("wfrmListaLibro.aspx");
                        //}

                    }
                }
            }


        }
        private bool HayCambios(ref bool bcl, ref bool bt, ref bool bAu, ref bool bCat, HttpCookie cookie)
        {
            bool result = false;



            if (Request.Cookies["MyCookie"]["_clave"] != txtClaveLibro.Text)//Clave Vieja
            {
                bcl = true;
                elibro.ClaveLibro = txtClaveLibro.Text;
                result = true;
            }
            if (Request.Cookies["MyCookie"]["_titulo"] != txtTitulo.Text)
            {
                bt = true;
                elibro.Titulo = txtTitulo.Text;
                result = true;
            }
            if (Request.Cookies["MyCookie"]["_cate"] != txtIdCate.Text)
            {
                bCat = true;
                elibro.Categoria.ClaveCategoria = txtIdCate.Text;//la clave
                result = true;
            }
            if (Request.Cookies["MyCookie"]["_idAutor"] != txtIdAutor.Text)
            {
                bAu = true;
                elibro.ClaveAutor = txtIdAutor.Text;
                result = true;
            }
            return result;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool bcl = false;
            bool bt = false;
            bool bAu = false;
            bool bCat = false;
            bool valido = true;
            bool claveCambio = false;
            try
            {
                if (Session["_claveLibro"] != null)
                {

                    elibro.ClaveLibro = Request.Cookies["Mycookie"]["_clave"];
                    elibro.Titulo = Request.Cookies["Mycookie"]["_titulo"];
                    elibro.Categoria.ClaveCategoria = Request.Cookies["Mycookie"]["_cate"];
                    elibro.ClaveAutor = Request.Cookies["Mycookie"]["_idAutor"];
                    if (HayCambios(ref bcl, ref bt, ref bAu, ref bCat, cookie) == true)
                    {

                        if (bcl == true)
                        {
                            if (libro.claveRepetida(elibro.ClaveLibro) == false)
                            {
                                
                                claveCambio = true;
                            }
                            else
                            {
                                valido = false;
                                Session["_wrn"] = "Esa clave de libro ya esta siendo utilizada";
                                //break;
                            }

                        }
                        if (bt == true || bAu == true)
                        {

                            if (libro.libroRepetido(elibro) == false)//no hay un titulo para ese autor
                            {

                                valido = true;
                            }
                            else
                            {
                                valido = false;
                                Session["_wrn"] = "Atención el titulo ya existe para el Autor seleccionado";
                            }

                        }

                        if (valido == true)
                        {
                            if (claveCambio == false)
                            {
                                libro.modificar(elibro);
                            }
                            else
                            {
                                libro.modificar(elibro,Request.Cookies["Mycookie"]["_clave"]);
                            }
                            Session["_exito"] = $"El libro {elibro.Titulo} se actualizo se manera correcta";
                        }
             

                    }
                    else
                    {


                        libro.modificar(elibro);
                    }
                }
                else
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

            }
            catch (Exception ex)
            {

                Session["_err"] = $"{ex.Message}";
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
            catch (Exception ex)
            {
                Session["_err"] = $"error :{ex.Message}";
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


        private void limpiar()
        {
            txtAutor.Text = string.Empty;
            txtAutorModal.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtFiltrarCate.Text = string.Empty;
            txtIdCate.Text = string.Empty;
            txtClaveLibro.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            llenarGVAutor();
            llenarGVCate();

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