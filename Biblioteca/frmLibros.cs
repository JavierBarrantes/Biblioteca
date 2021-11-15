using System;
using System.Data;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;
namespace Biblioteca
{
    public partial class frmLibros : Form
    {
        Elibro libro;
        EAutor autor;
        ECategoria categoria;
        LNCategoria lNCategoria = new LNCategoria(PConfig.getCadConexion);//SIEMPRE ARRASTRAR LA CADENA POR LAS DIFF CAPAS
        LNLibro ln = new LNLibro(PConfig.getCadConexion);
        LNAutor lnAutor = new LNAutor(PConfig.getCadConexion);
        public frmLibros()
        {
           
         
            InitializeComponent();
        }
       
      

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
        private void limpiarTextos()
        {
            txtClaveAutor.Text = string.Empty;
            txtLibro.Text = string.Empty;
            txtClaveCategoria.Text = string.Empty;
            txtClaveLibro.Text = string.Empty;
            txtClaveLibro.Focus();
            libro = null;
            ln = null;
            lnAutor = null;
            lNCategoria = null;
            categoria = null;
            autor = null;
            llenarDGV();
        }
        private bool textosLlenos()
        {
            string msj = "";
            bool result = false ;
            if(string.IsNullOrEmpty(txtClaveLibro.Text))
            {
                        msj = "Debe agregar una clave de libro";
            }
            else if(string.IsNullOrEmpty(txtLibro.Text))
            {
                msj = "Debe agregar un titulo";
                txtLibro.Focus();
            }else if (string.IsNullOrEmpty(txtClaveAutor.Text))
            {
                msj = "Debe agregar una clave de autor";
                txtClaveAutor.Focus();
            }else if (string.IsNullOrEmpty(txtClaveCategoria.Text))
            {
                msj = "Debe agregar una clave de categoria";
                txtClaveCategoria.Focus();
            }
            else
            {
                result = true;
              
            }
            if (!result)
            {
                MessageBox.Show(msj, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return result;
        }




        //*****************************************************
        #region Metodos
        private void llenarDGV(string condicion="")
        {
            LNLibro ln = new LNLibro(PConfig.getCadConexion);
           
            DataSet ds;
            try
            {
                ds = ln.listarTodos(condicion);
                //ds = ln.listarTodos(); ///like se usa como comparador % comodines para buscar por filtros en el where
                dvLibros.DataSource = ds.Tables[0]; // se carga el data grid view  con el indice 0 del data set;
            }
            catch (Exception ex) 
            {

                mensajesError(ex);
            }
            dvLibros.Columns[0].HeaderText = "Clave de libro";
            dvLibros.Columns[1].HeaderText = "Titulo";
            dvLibros.Columns[2].HeaderText = "Clave Autor";
            dvLibros.Columns[3].HeaderText = "Clave Categoria";
            dvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // se ordena

        }

        private void mensajesError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            categoria = new ECategoria(txtClaveCategoria.Text, "Poo");

            if (textosLlenos())
            {
                if(libro==null)
                libro = new Elibro(txtClaveLibro.Text, txtLibro.Text, txtClaveAutor.Text,categoria, false);
                else
                {
                     //TODO: LLENAR UN LIST Y VER LINKQ
                     //2: METERLE CABEZA A MODIFICAR
                     //3: 
                }
                if (libro.Existe)
                    insertarLibro();
           
            }
        }

        private void insertarLibro()
        {

            try
            {
                //TODO:agregar acceso a la capa de logica
                if (!ln.libroRepetido(libro))
                {

                    if (!ln.claveRepetida(libro.ClaveLibro))
                    {
                        if (!lnAutor.ClaveRepetida(libro))
                        {

                            MessageBox.Show("La clave de autor no existe !");
                            txtClaveAutor.Focus();
                        }
                        else
                        {
                            if (!lNCategoria.ClaveRepetida(libro))
                            {
                                MessageBox.Show("La clave de la categoria no existe");
                            }
                            else
                            {
                                if (ln.insertar(libro) > 0)
                                {
                                    MessageBox.Show("El libro se guardo con éxito");
                                    //TODO:VER
                                }
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("La clave del libro ya se encuentra en uso! ");
                        txtClaveLibro.Focus();

                    }
                }
                else
                {

                    MessageBox.Show("El nombre del titulo ya se encuentra en uso!");
                    txtLibro.Focus();
                }

            }
            catch (Exception ex)
            {

                mensajesError(ex);
            }

        }
        private void frmLibros_Load(object sender, EventArgs e)
        {
            llenarDGV();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
    }

        private void dvLibros_DoubleClick(object sender, EventArgs e)
        {

            int fila = dvLibros.CurrentRow.Index;//fila del data grid view (DEVUELVE EL INDICE DONDE dieron click en el datagrid)
            string clave = dvLibros[0, fila].Value.ToString();
            string condicion = $"claveLibro='{clave}'";
            try
            {
                libro = ln.buscarRegistro(condicion);
                if (libro != null)
                {
                    libro.Existe = true;
                    txtClaveLibro.Text = libro.ClaveLibro;
                    txtLibro.Text = libro.Titulo;
                    txtClaveAutor.Text = libro.ClaveAutor;
                    txtClaveCategoria.Text = libro.Categoria.ClaveCategoria;

                    btnBuscar.Enabled = true;//es el boton de eliminar :/   
                }
            }
            catch (Exception ex)
            {
                mensajesError(ex);
            }
        }

        private void dvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int resultado;
            DialogResult resp;
            if(libro!=null && libro.Existe)
            {
                resp = MessageBox.Show($"Estas seguro que quieres borrar el libro que pertenece a la clave de libro{libro.ClaveLibro}?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    MessageBox.Show(ln.eliminarProcedure(libro));
                    limpiarTextos();

                    //resultado = ln.eliminar(libro);
                    //if (resultado> 0)
                    //{
                    //    MessageBox.Show("El libro se elimino exitosamente");
                    //    limpiarTextos();
                    //}
                    //else if (resultado == -1)
                    //    MessageBox.Show("Un error al eliminar el libro en la base de datos");
                        
                    
                }
                else
                    limpiarTextos();
               
            }
        }
    }
    }
