using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AcessoDatos
{
   public class ADLibro
    {
        private string cadConexion;
        private string mensaje;
        private string Mensaje { get;}

        public ADLibro(string cadena)
        {
            cadConexion = cadena;
            mensaje = string.Empty;
        }

        public ADLibro()
        {
            cadConexion =string.Empty;
            mensaje = string.Empty;
        }

        #region Metodos
        public bool libroRepetido(Elibro libro)
        {
            bool result = false;
            //TODO: CREAR objetos de datos DE ADO.NET
            string sentencia;
            sentencia = $"Select 1 From Libro Where  titulo = '{libro.Titulo}' and claveAutor='{libro.ClaveAutor}'";
            SqlCommand comandoSQL = new SqlCommand(); // comanda
            SqlConnection connectionSQL = new SqlConnection(cadConexion); //se establece la conecion
            SqlDataReader datos; //no se instancia no tiene constructor

            //TODO: configurar el objeto de datos

            comandoSQL.Connection = connectionSQL;
            comandoSQL.CommandText = sentencia;
           
    
            try
            { 
                //Todo: establecer la conexion /EJECUTAR comand /recuperar datos;
                connectionSQL.Open();
               datos = comandoSQL.ExecuteReader(); //se asgina el resultado del COMMAND
                if (datos.HasRows)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                connectionSQL.Close();//se cierra  la concexion
            }
            catch (Exception)
            {
                connectionSQL.Close();//otro closs
                throw new Exception("ha ocurrido un error al realizar la consulta a la base de datos");
            
            }
            finally
            {        
                //TODO: limpiar la memoria (DIPOSE)
                comandoSQL.Dispose();
                connectionSQL.Dispose();
            }
            return result;
        }



        public bool claveLibroRepetida(string clave)
        {
            object obScalar;
            bool result = false;
            ///
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection(cadConexion);
            SqlDataReader datos; // no se instencia
            comando.CommandText = "Select 1 from libro  where claveLibro=@claveLibro";
            comando.Parameters.AddWithValue("@claveLibro", clave);
            comando.Connection=conexion;

;            try
            {
                conexion.Open();
                obScalar = comando.ExecuteScalar();
                if (obScalar != null)
                {
                    result = true;
                }
                else
                {

                    result = false;
                }
                conexion.Close();
                

            }
            catch (Exception)
            {
                
               
                throw new Exception("Error buscando la clave del libro");
            }
            finally
            {
                conexion.Dispose();
            }
            return result;
        }
        #endregion


        public int insertar(Elibro libro)
        {//si se delcaran atributos cantidad mas o menos
            ///INSERT into libro;  no se  necesitan parametros si calcazan los parametros y el orden;
            int result = -1;
            string sentencia = "INSERT into libro " 
                + $"values('{libro.ClaveLibro}','{libro.Titulo}','{libro.ClaveAutor}','{libro.Categoria.ClaveCategoria}')";
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia,connection); //EJECUTARA la parte de datos
            try
            {
                connection.Open();
                result = sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Error al insertar el libro en la base de datos");
            }
            finally
            {
                connection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
    }
}
