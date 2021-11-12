using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AcessoDatos
{
   public class ADCategoria
    {
        private string CadenaConexion { get; }
        private string Mensaje { get; }
        #region Constructores

        public ADCategoria()
        {


            CadenaConexion = string.Empty;
            Mensaje = string.Empty;
        }
        public ADCategoria(string cadena)
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
            string sentencia = $"Select 1 from categoria where claveCategoria='{libro.Categoria.ClaveCategoria}'"; //la consulta que debemos  a hacer a la base de datos-.. 
            SqlConnection connection = new SqlConnection(CadenaConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia, connection); //se instancia el sqlcomand

            try
            {
                connection.Open();//se abre la conecion
                obScalar = sqlCommand.ExecuteScalar();
               //se cierra la conexion ya que el objeto ya se encuentra con la respuesta de la consulta a la base de datos;
                if (obScalar == null)
                    result = false;
                else
                    result = true;
                connection.Close();

            }
            catch (Exception)
            {

                throw new Exception("Error al verificar la clave de la categoria en la base de datos");
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
