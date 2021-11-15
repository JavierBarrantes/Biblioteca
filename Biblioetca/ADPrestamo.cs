
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entidades;
namespace AcessoDatos
{
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

        //public int insertarPrestamo(EPrestamo prestamo)
        //{
        //    //int result = -1;
        //    //string sentencia = "Insert into Prestamo" + $"values'{prestamo.ClavePrestamo}'," +
        //    //    $"'{prestamo.ClaveEjemplar}','{prestamo.ClaveUsuario}','{prestamo.FechaPrestamo}','{prestamo.FechaDevolucion}'";
        //    //SqlConnection connection = new SqlConnection(cadConexion);
        //    //SqlCommand sqlCommand = new SqlCommand(sentencia,connection);
        //    //try
        //    //{
        //    //    connection.Open();
        //    //    result = sqlCommand.ExecuteNonQuery();

        //    //}
        //    //catch (Exception)
        //    //{

        //    //    throw new Exception("Error al insertar un prestamo");
        //    //}
        //    //finally
        //    //{
        //    //    sqlCommand.Dispose();
        //    //    connection.Dispose();
        //    //}
        //    //return result;
        //}
        #endregion
    }

}
