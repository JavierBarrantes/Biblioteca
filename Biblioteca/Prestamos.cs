using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;
namespace Biblioteca
{
    public partial class Prestamos : Form
    {
        EAutor autor = new EAutor();
        EPrestamo ePrestamo;
        EEjemplar entidadesEjemplar;
        LNAutor lNAutor = new LNAutor();
        LNPrestamo lNPrestamo = new LNPrestamo(PConfig.getCadConexion);
        LNUsuario usuario = new LNUsuario(PConfig.getCadConexion);
        frmLibros nuevo = new frmLibros();
        LNEjemplar ejemplar = new LNEjemplar(PConfig.getCadConexion);
        public Prestamos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            textosLlenos();
            ePrestamo = new EPrestamo(txtClavePrestamo.Text,
            txtEjemplar.Text, txtClaveUsuario.Text,dtpPrestamo.Value, dtpDevolucion.Value);
            
            try
          
            {
             
                if (usuario.unResgistro(ePrestamo)>0)
                {
                    if (usuario.validoParaPrestamo(ePrestamo)!=1)
                    {
                        
                        if (ejemplar.unResgistro(ePrestamo) > 0)
                        {
                            entidadesEjemplar = new EEjemplar(txtEjemplar.Text, "ES002");
                            if (ejemplar.validoParaPrestamo(ePrestamo) >0) {
                                ejemplar.modificar(entidadesEjemplar);
                                lNPrestamo.insertarPrestamo(ePrestamo);
                                MessageBox.Show("El prestamo se inserto correctamente!");
                            }

                        }
                        else
                        {
                            MessageBox.Show("El ejemplar no existe");
                        }
                               
                    }
                    else
                    {
                        MessageBox.Show($"El usuario ya tiene un ejemplar en renta!");
                    }     
                }
                else
                {
                    //TODO: AGREGAR FORMULARIO PARA INSERT DE USUARIOS
                    MessageBox.Show("El usuario no existe!");
                }
              
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
            //lNPrestamo.insertarPrestamo(ePrestamo);

        }
        private bool textosLlenos()
        {
            string msj = "";
            bool result = false;
            if (string.IsNullOrEmpty(txtClavePrestamo.Text))
            {
                msj = "Debe agregar una clave de libro";
                txtClavePrestamo.Focus();
            }
            else if (string.IsNullOrEmpty(txtEjemplar.Text))
            {
                msj = "Debe agregar una clave de ejemplar";
                txtEjemplar.Focus();
               
            }
            else if (string.IsNullOrEmpty(txtClaveUsuario.Text))
            {
                msj = "Debe agregar una clave de Usuario";
                txtClaveUsuario.Focus();
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



        private void llenarDGV(string condicion = "")
        {
            
            
            DataSet ds;//data set
            try
            {
                ds = lNPrestamo.listarTodos(condicion);
                //ds = ln.listarTodos(); ///like se usa como comparador % comodines para buscar por filtros en el where
               dgvPrestamo.DataSource = ds.Tables[0]; // se carga el data grid view  con el indice 0 del data set;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); 
            }
            dgvPrestamo.Columns[0].HeaderText = "ClavePrestamo";
            dgvPrestamo.Columns[1].HeaderText = "Clave Ejemplar";
            dgvPrestamo.Columns[2].HeaderText = "ClaveUsuario";
            dgvPrestamo.Columns[3].HeaderText = "Fecha Prestamo";
            dgvPrestamo.Columns[3].HeaderText = "Fecha Devolucion";
            dgvPrestamo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // se ordena

        }
        private void llenarDGVEjemplar(string condicion="")
        {

            
            DataSet ds;//data set
            try
            {
                ds = ejemplar.listarTodos(condicion);
                //ds = ln.listarTodos(); ///like se usa como comparador % comodines para buscar por filtros en el where
              dgvEjemplarDatos.DataSource = ds.Tables[0]; // se carga el data grid view  con el indice 0 del data set;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            dgvEjemplarDatos.Columns[0].HeaderText = "Clave Ejemplar";
            dgvEjemplarDatos.Columns[1].HeaderText = "Clave Libro";
            dgvEjemplarDatos.Columns[2].HeaderText = "Clave Condicion";
            dgvEjemplarDatos.Columns[3].HeaderText = "Clave Estado";
            dgvEjemplarDatos.Columns[3].HeaderText = "Edicion";
            dgvEjemplarDatos.Columns[3].HeaderText = "ClaveEditorial";
            dgvEjemplarDatos.Columns[3].HeaderText = "Numero Paginas";
            dgvEjemplarDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // se ordena

        }
        private void llenarDGVUsuario(string condicion="")
        {

           
            DataSet ds;//data set
            try
            {
                ds =usuario.listarTodos(condicion);
                //ds = ln.listarTodos(); ///like se usa como comparador % comodines para buscar por filtros en el where
               dgvUsuario.DataSource = ds.Tables[0]; // se carga el data grid view  con el indice 0 del data set;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            dgvUsuario.Columns[0].HeaderText = "Clave Usuario";
            dgvUsuario.Columns[1].HeaderText = "CURP";
            dgvUsuario.Columns[2].HeaderText = "nombre";
            dgvUsuario.Columns[3].HeaderText = "ap Materno";
            dgvUsuario.Columns[3].HeaderText = "ap Paterno";
            dgvUsuario.Columns[3].HeaderText = "Fecha Nacimiento";
            dgvUsuario.Columns[3].HeaderText = "Email";
            dgvUsuario.Columns[3].HeaderText = "Direccion";
            dgvUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // se ordena

        }
        private void dtpPrestamo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Prestamos_Load(object sender, EventArgs e)
        {
            string condicionUsuario = txtClaveUsuario.Text;
            string condicion = txtEjemplar.Text;
            llenarDGV();
            llenarDGVEjemplar(condicion);
            llenarDGVUsuario(condicionUsuario);
        }

        private void txtEjemplar_TextChanged(object sender, EventArgs e)
        {
            string condicion = txtEjemplar.Text;
            llenarDGVEjemplar(condicion);
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ePrestamo = new EPrestamo(txtClavePrestamo.Text,
                       txtEjemplar.Text, txtClaveUsuario.Text, dtpPrestamo.Value, dtpDevolucion.Value);
            textosLlenos();
            try
            {
                if (lNPrestamo.eliminar(ePrestamo) > 0)
                {
                    MessageBox.Show("El prestamo se eliminado correctamente");
                    llenarDGV();
                }
                else if (lNPrestamo.eliminar(ePrestamo) != -1)
                {
                    MessageBox.Show("El registro que desea eliminar no existe");
                    llenarDGV();
                };
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtClavePrestamo_TextChanged(object sender, EventArgs e)
        {
            llenarDGV();
            btnEliminar.Enabled = true;
        }

        private void dgvPrestamo_DoubleClick(object sender, EventArgs e)
        {
            int fila = dgvPrestamo.CurrentRow.Index;//fila del data grid view (DEVUELVE EL INDICE DONDE dieron click en el datagrid)
            string clave = dgvPrestamo[0, fila].Value.ToString();
            string condicion = $"clavePrestamo='{clave}'";
            try
            {
                ePrestamo = lNPrestamo.buscarRegistro(condicion);
                if (ePrestamo != null)
                {

                    txtClavePrestamo.Text = ePrestamo.ClavePrestamo;
                    txtEjemplar.Text = ePrestamo.ClaveEjemplar;
                    txtClaveUsuario.Text = ePrestamo.ClaveUsuario;
                    dtpDevolucion.Value = ePrestamo.FechaDevolucion;
                    dtpPrestamo.Value = ePrestamo.FechaPrestamo;
                 
                    btnEliminar.Enabled = true;//es el boton de eliminar :/   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            textosLlenos();
            ePrestamo = new EPrestamo(txtClavePrestamo.Text,
            txtEjemplar.Text, txtClaveUsuario.Text, dtpPrestamo.Value, dtpDevolucion.Value);
            try
            {

                if (lNPrestamo.unResgistro(ePrestamo) > 0)
                {
                    if (lNPrestamo.modificar(ePrestamo) > 0)
                    {
                        MessageBox.Show("Se actulizo corractamente");
                    }
                    

                }
                else
                {
                    MessageBox.Show("El registro no existe");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
