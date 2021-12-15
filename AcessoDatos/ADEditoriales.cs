using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entidades;
namespace AcessoDatos
{
    public class ADEditoriales
    {

        private string cadenaCad { get; }
        #region Constructores

        public ADEditoriales()
        {
            cadenaCad = string.Empty;
        }
        public ADEditoriales(string cadena)
        {
            cadenaCad = cadena;
        }
        #endregion
        #region Metodos
        public EEditorial BuscarRegistro(string condicion)
        {
            EEditorial editorial= new EEditorial();
            string sentencia;

            SqlCommand comandoSQL = new SqlCommand();
            SqlConnection conexionSQL = new SqlConnection(cadenaCad);
            //Se requiere un objeto para recuperar los datos.
            SqlDataReader dato;//Solo se define el objeto, no hace falta instanciarlo en este momento

            sentencia = "Select claveEditorial,nombre From Editorial";
            if (!string.IsNullOrEmpty(condicion))
                sentencia = string.Format("{0} Where ={1}", sentencia, condicion);
            comandoSQL.Connection = conexionSQL;
            comandoSQL.CommandText = sentencia;
            try
            {
                conexionSQL.Open();
                dato = comandoSQL.ExecuteReader();
                if (dato.HasRows)
                {
                    dato.Read();
                    editorial.Clave = dato.GetString(0);
                    editorial.Nombre = !dato.IsDBNull(1) ? dato.GetString(1) : "";
                    
                }
                conexionSQL.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error al recuperar el registro de editorial!");
            }
            return editorial;
        }
        public bool claveRepetidaEditorial(string clave)
        {

            bool result = false;
            object obScalar;
            string sentencia = $"Select 1 from EDITORIAL where claveEditorial= '{clave}'"; 
            SqlConnection connection = new SqlConnection(cadenaCad);
            SqlCommand sqlCommand = new SqlCommand(sentencia, connection); 

            try
            {
                connection.Open();
                obScalar = sqlCommand.ExecuteScalar();
             
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
                connection.Dispose();
                sqlCommand.Dispose();
            }
            return result;
        }

        public int modificar(EEditorial editorial, string claveVieja = "")
        {
            int result = -1;
            string sentencia = "";
            SqlConnection connection = new SqlConnection(cadenaCad);

            if (string.IsNullOrEmpty(claveVieja))
                sentencia = $"Update editorial  set claveEditorial='{editorial.Clave}', nombre='{editorial.Nombre}' where claveEditorail='{editorial.Clave}'";
            else
            {
                sentencia = $"Update editorial set claveEditorial='{editorial.Clave}', nombre='{editorial.Nombre}' where claveEditorial='{claveVieja}'";
                SqlCommand sqlCommand = new SqlCommand(sentencia, connection);
                try
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {

                    throw new Exception("Un problema al actualizar la editorial");
                }
                finally
                {
                    connection.Dispose();
                    sqlCommand.Dispose();
                }


            }
            return result;

        }
        public DataTable listarTodos(string condicion, bool vista)
        {
            DataTable datos = new DataTable();
            SqlConnection connection = new SqlConnection(cadenaCad);
            SqlDataAdapter ad;
            string sentencia = "Select * from editorial";//cambiar
            if (!string.IsNullOrEmpty(condicion))
                sentencia = $"{sentencia} where {condicion}";
            try
            {
                ad = new SqlDataAdapter(sentencia, cadenaCad);
                ad.Fill(datos);
            }
            catch (Exception)
            {

                throw new Exception("Un error al cargar la lista de las editoriales filtrada por nombre");
            }
            finally
            {
                connection.Dispose();
            }

            return datos;
        }
        public int eliminar(string clave)
        {
            int result = -1;
            string sentencia = $" Delete from editorial where claveEditorial= '{clave}' ";
            SqlConnection connection = new SqlConnection(cadenaCad);
            SqlCommand sqlCommand = new SqlCommand(sentencia, connection);

            try
            {
                connection.Open();
                result = sqlCommand.ExecuteNonQuery();
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

        public int insertar(EEditorial editorial)
        {
            int result = -1;
            string sentencia = "INSERT into editorial "
                + $"values('{editorial.Clave}','{editorial.Nombre}')";
            SqlConnection connection = new SqlConnection(cadenaCad);
            SqlCommand sqlCommand = new SqlCommand(sentencia, connection);
            try
            {
                connection.Open();
                result = sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw new Exception("Error al insertar una editorial en la base de datos");
            }
            finally
            {
                connection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        public bool editorialRepetido(EEditorial editorial)
        {
            bool result = false;
            string sentencia;
            sentencia = $"Select 1 From editorial Where  nombre= '{editorial.Nombre}'";
            SqlCommand comandoSQL = new SqlCommand();
            SqlConnection connectionSQL = new SqlConnection(cadenaCad);
            SqlDataReader datos;
            comandoSQL.Connection = connectionSQL;
            comandoSQL.CommandText = sentencia;
            try
            {

                connectionSQL.Open();
                datos = comandoSQL.ExecuteReader();
                if (datos.HasRows)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                connectionSQL.Close();
            }
            catch (Exception)
            {
                connectionSQL.Close();
                throw new Exception("ha ocurrido un error al realizar la consulta a la base de datos");

            }
            finally
            {
                comandoSQL.Dispose();
                connectionSQL.Dispose();
            }
            return result;
        }
        public int unResgistro(EEditorial eEditorial)
        {
            int result = -1;
            string sentencia = $"select 1 from EJEMPLAR inner join EDITORIAL on EJEMPLAR.claveEditorial=EDITORIAL.claveEditorial where EDITORIAL.claveEditorial='{eEditorial.Clave}'";
            SqlConnection connection = new SqlConnection(cadenaCad);
            SqlCommand sqlCommand = new SqlCommand(sentencia, connection);
            SqlDataReader datos;

            try
            {
                connection.Open();
                datos = sqlCommand.ExecuteReader();
                if (datos.HasRows)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
                connection.Close();


            }
            catch (Exception)
            {

                throw new Exception("Ha ocurrido un error al buscar un registro de editoriales en la Base de datos");
            }
            return result;

        }
        #endregion
    }
}
