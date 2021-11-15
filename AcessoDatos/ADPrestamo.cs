using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

  public class ADPrestamo
    {
       public string cadConexion;




        #region Constructores

        public ADPrestamo(string cadConexion)
        {
            this.cadConexion = cadConexion;
        }
        #endregion
        #region Metodos

        public int insertarPrestamo(EPrestamo prestamo)
        {
            int result = -1;
         
            string sentencia = "Insert into Prestamo" + $" values ('{prestamo.ClavePrestamo}'," +
                $"'{prestamo.ClaveEjemplar}','{prestamo.ClaveUsuario}','{prestamo.FechaPrestamo.ToString("yyyy/MM/dd")}','{prestamo.FechaDevolucion.ToString("yyyy/MM/dd")}')";
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia,connection);
            try
            {
                connection.Open();
                result = sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception)
            {
            connection.Close();
                throw new Exception("Error al insertar un prestamo");
            }
            finally
            {
                sqlCommand.Dispose();
                connection.Dispose();
            }
            return result;
        }
        #endregion
    }

