using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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

        public ECategoria BuscarRegistro(string condicion)
        {
            ECategoria cate = new ECategoria();
            string sentencia;

            SqlCommand comandoSQL = new SqlCommand();
            SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
            //Se requiere un objeto para recuperar los datos.
            SqlDataReader dato;//Solo se define el objeto, no hace falta instanciarlo en este momento

            sentencia = "Select claveCategoria, descripcion From Categoria";
            if (!string.IsNullOrEmpty(condicion))
                sentencia = string.Format("{0} Where {1}", sentencia, condicion);

            comandoSQL.Connection = conexionSQL;
            comandoSQL.CommandText = sentencia;

            try
            {
                conexionSQL.Open();
                dato = comandoSQL.ExecuteReader();
                if (dato.HasRows)
                {
                    dato.Read();
                    cate.ClaveCategoria = dato.GetString(0);
                    cate.Descripcion = !dato.IsDBNull(1) ? dato.GetString(1) : "";
                    //cate.ExisteRegistro = true;//Este dato es de App y solo le sirve al programador;
                }
                conexionSQL.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error al recuperar el registro!");
            }
            return cate;
        }
        public DataTable ListarRegistros(string condicion)
        {
            DataTable result = new DataTable();
            SqlDataAdapter adaptador;
            SqlConnection conexion = new SqlConnection(CadenaConexion);

            string sentencia = "Select * From Categoria";

            if (!string.IsNullOrEmpty(condicion))
                sentencia = $"{sentencia} Where {condicion}";

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion);
                adaptador.Fill(result);
            }
            catch (Exception)
            {
                throw new Exception("Se ha presentado un error extrayendo la lista de Tablas");
            }

            return result;
        }
        #endregion
    }
}
