﻿using System;
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
    public partial class frmLibros : Form
    {
        ECategoria categoria = new ECategoria("C0001", "Comic");
        public frmLibros()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Elibro libro;
            LNLibro ln = new LNLibro(PConfig.getCadConexion);
            if (textosLlenos())
            {
                libro = new Elibro(txtClaveLibro.Text, txtLibro.Text, txtClaveAutor.Text,categoria, false);

                try
                {
                    //TODO:agregar acceso a la capa de logica
                    if (!ln.libroRepetido(libro))
                    {
                        
                        if (!ln.claveRepetida(libro.ClaveLibro))
                        {
                            if (ln.insertar(libro) > 0)
                            {
                                MessageBox.Show("El libro se guardo con éxito");
                                //TODO:VER
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

                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}