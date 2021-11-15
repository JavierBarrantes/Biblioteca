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
            
            ePrestamo = new EPrestamo(txtClavePrestamo.Text,
            txtEjemplar.Text, txtClaveUsuario.Text,dtpPrestamo.Value, dtpDevolucion.Value);
            textosLlenos();
            try
          
            {
             
                if (usuario.unResgistro(ePrestamo)>0)
                {
                    if (usuario.validoParaPrestamo(ePrestamo)!=1)
                    {
                        entidadesEjemplar = new EEjemplar(txtEjemplar.Text, "ES002");
                        if (ejemplar.unResgistro(ePrestamo) > 0)
                        {
                            if(ejemplar.validoParaPrestamo(ePrestamo) > 0)
                            ejemplar.modificar(entidadesEjemplar);
                            lNPrestamo.insertarPrestamo(ePrestamo);
                            MessageBox.Show("El prestamo se inserto correctamente!");
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

        private void dtpPrestamo_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
