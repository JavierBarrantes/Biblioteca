using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;
namespace AcessoDatos
{
    public class ADAutor
    {
        private string CadenaConexion { get; }
        private string Mensaje { get; }
        #region Constructores

        public ADAutor()
        {


            CadenaConexion = string.Empty;
            Mensaje = string.Empty;
        }
        public ADAutor(string cadena)
        {
            CadenaConexion = cadena;
            Mensaje = string.Empty;
        }
        #endregion


        #region Metodos

        public bool ClaveRepetida(Elibro libro)
        {
            bool result = false;
            object obScalar;//El executesclar devulve un tipo objeto segun la consulta (un objeto con los datos de la request..)
            string sentencia =$"Select 1 from Autor where claveAutor='{libro.ClaveAutor}'"; //la consulta que debemos  a hacer a la base de datos-.. 
            SqlConnection connection = new SqlConnection(CadenaConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia,connection); //se instancia el sqlcomand

            try
            {
                connection.Open();//se abre la conecion
                obScalar=sqlCommand.ExecuteScalar();
                connection.Close();//se cierra la conexion ya que el objeto ya se encuentra con la respuesta de la consulta a la base de datos;
                if (obScalar == null)
                    result = false;
                else
                    result = true;

            }
            catch (Exception)
            {

                throw  new Exception("Error al verificar la clave de autor en la base de datos");
            }
            finally
            {
                //limpiamos la memoria de las variables
                connection.Dispose();
                sqlCommand.Dispose();

                
            }
       

            return result;
        }
        #endregion
    }
}
