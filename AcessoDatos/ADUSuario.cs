using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades;
namespace AcessoDatos

{
   public class ADUSuario
    {
        string cadConexion;


        #region constructor
        public ADUSuario(string cade)
        {
            cadConexion = cade;
        }
        #endregion
        #region Metodos


        public int unResgistro(EPrestamo ePrestamo)
        {
            int result = -1;
            string sentencia=$"Select 1 from Usuario where claveUsuario='{ePrestamo.ClaveUsuario}'";
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia,connection);
            SqlDataReader datos;

            try
            {
                connection.Open();
               datos= sqlCommand.ExecuteReader();
                if (datos.HasRows)
                {
                    result = 1;
                }
                connection.Close();
               

            }
            catch (Exception)
            {
               
                throw new Exception("Ha ocurrido un error al buscar un registro de usuario en la Base de datos");
            }
            finally
            {
                sqlCommand.Dispose();
                connection.Dispose();
            }
            return result;

        }

        public int validoParaPrestamo(EPrestamo prestamo)
        {
            int result = -1;
            string sentencia = $"Select USUARIO.nombre from USUARIO right join PRESTAMO  on USUARIO.claveUsuario=PRESTAMO.claveUsuario " +
                $" where  prestamo.claveUsuario ='{prestamo.ClaveUsuario}'";

            SqlConnection connection = new  SqlConnection(cadConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia,connection);
            object objScalar;
            try
            {
                connection.Open();
                objScalar = sqlCommand.ExecuteScalar();
                if (objScalar != null)
                {
                    result = 1;
                }
                connection.Close();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar verificar los prestamos del usario");
            }
            finally
            {
                sqlCommand.Dispose();
                connection.Dispose();
            }
            return result;
        }


        public DataSet listarTodos(string condicion = "") //RECUPERAR UN DATASET(1 O muchas tablas)
        {
            DataSet setLibros = new DataSet();
            string sentencia = "Select claveUsuario, curp, nombre, apMaterno, apPaterno, fechaNacimiento, email, direccion from Usuario";

            if (!string.IsNullOrEmpty(condicion))
                sentencia = string.Format("{0} where claveUsuario='{1}'", sentencia, condicion);
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlDataAdapter sqlDataAdapter; // NO SE INSTANCIA AUN HASTA QUE SE USE!!!

            try
            {
                sqlDataAdapter = new SqlDataAdapter(sentencia, connection); //se instancia con el selec y la conexion a la base de datos
                sqlDataAdapter.Fill(setLibros, "Usuario"); //LLENA EL DATA SET
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
        #endregion 
    }
}
