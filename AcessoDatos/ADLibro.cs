using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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
        public DataSet listarTodos(string condicion = "") //RECUPERAR UN DATASET(1 O muchas tablas)
        {
            DataSet setLibros = new DataSet();
            string sentencia = "Select claveLibro, titulo, claveAutor, claveCategoria from Libro";

            if (!string.IsNullOrEmpty(condicion))
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlDataAdapter sqlDataAdapter; // NO SE INSTANCIA AUN HASTA QUE SE USE!!!

            try
            {
                sqlDataAdapter = new SqlDataAdapter(sentencia,connection); //se instancia con el selec y la conexion a la base de datos
                sqlDataAdapter.Fill(setLibros,"Libro"); //LLENA EL DATA SET
                sqlDataAdapter.Dispose();
            }
            catch (Exception)
            {

                throw new Exception("Ha ocurrido algo");
            }
            finally
            {
                connection.Dispose();
            }
                    return setLibros;
        }



        public Elibro buscarRegistro(string condicion)
        {
            string setencia = "select clavelibro, titulo, claveAutor, claveCategoria from libro";
            Elibro libro = new Elibro();
            setencia = $"{setencia} where {condicion}";
         

            SqlConnection connection = new SqlConnection(cadConexion);
            SqlCommand sqlCommand = new SqlCommand(setencia,connection);
            SqlDataReader datos;
            try
            {
                connection.Open();
                datos = sqlCommand.ExecuteReader();
                if (datos.HasRows) // si trae datos se hace lectura los datos
                {
                    datos.Read();//hace iteracion por los datos (se necesitaria un foreach en caso de que haya muchos registros y un read debera declararse en cada iteracion del for)}
                    libro.ClaveLibro = datos.GetString(0);
                    libro.Titulo = datos.GetString(1);
                    libro.ClaveAutor = datos.GetString(2);
                    libro.Categoria.ClaveCategoria = datos.GetString(3);
                    connection.Close();
                }
                

            }
            catch (Exception)
            {

                throw new Exception("No se ha encontrado el libro");
            }
            finally
            {
                sqlCommand.Dispose();
                connection.Dispose();
            }

            return libro;
         
        }
        public int eliminar(Elibro libro)
        {
            int result = -1;
            string sentencia = $"Delete from libro where claveLibro='{libro.ClaveLibro}'";
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia, connection);

            try
            {
                connection.Open();
              result=sqlCommand.ExecuteNonQuery();
               connection.Close();
            }
            catch (Exception)
            {
                result = -1;
            }
            finally
            {
                connection.Dispose();
                sqlCommand.Dispose();
            }
            return result;
        }
        public string eliminarProcedure(Elibro libro)
        {
            string sentencia = "EliminarLibro";
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia, connection);
            //no OLVIDAR SE DEBE DECLARAR UN STOREPROCEDURE
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@clave", libro.ClaveLibro);
            //parametro dfe salida (le pertenece al sqlcomanda)
            sqlCommand.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;//mensaje de salida
            try
            {
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                mensaje = sqlCommand.Parameters["@msj"].Value.ToString();
                connection.Close();
            }
            catch (Exception)
            {

                throw new Exception("Se ha presentando un errror en el procedimiento en la base de datos");
            }
            finally
            {
                sqlCommand.Dispose();
                connection.Dispose();
            }
            return mensaje;
        }


        public int modificar(Elibro libro,string claveVieja="")
        {
            int result = -1;
            string sentencia = "";
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia,connection);
            if(string.IsNullOrEmpty(claveVieja))
                sentencia=$"'{libro.Titulo}', claveAutor = '{libro.ClaveAutor}', claveCategoria = '{libro.Categoria.ClaveCategoria}'  where claveLibro = '{libro.ClaveLibro}'";
            else
            {
                sentencia = $"'{libro.Titulo}', claveAutor = '{libro.ClaveAutor}', claveCategoria = '{libro.Categoria.ClaveCategoria}'  where claveLibro = '{claveVieja}'";
            }

            try
            {
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {

                throw new Exception("Un problema al actualizar");
            }
            finally
            {
                connection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
    }
    //LINKQ
}
