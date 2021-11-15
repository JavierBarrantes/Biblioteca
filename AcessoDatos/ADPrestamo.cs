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



      public DataSet listarTodos(string condicion = "") //RECUPERAR UN DATASET(1 O muchas tablas)
        {
            DataSet setLibros = new DataSet();
            string sentencia = "Select clavePrestamo, claveEjemplar, claveUsuario, fechaPrestamo, fechaDevolucion from Prestamo";

            if (!string.IsNullOrEmpty(condicion))
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            SqlConnection connection = new SqlConnection(cadConexion);
            SqlDataAdapter sqlDataAdapter; // NO SE INSTANCIA AUN HASTA QUE SE USE!!!

            try
            {
                sqlDataAdapter = new SqlDataAdapter(sentencia, connection); //se instancia con el selec y la conexion a la base de datos
                sqlDataAdapter.Fill(setLibros, "Prestamo"); //LLENA EL DATA SET
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

    public int eliminar(EPrestamo prestamo)
    {
        int result = -1;
        string sentencia = $"Delete from prestamo where clavePrestamo='{prestamo.ClavePrestamo}'";
        SqlConnection connection = new SqlConnection(cadConexion);
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

    public EPrestamo buscarRegistro(string condicion)
    {
        string setencia = "select clavePrestamo, claveEjemplar, claveUsuario, fechaPrestamo, fechaDevolucion from Prestamo";
        EPrestamo prestamo= new EPrestamo();
        setencia = $"{setencia} where {condicion}";
        SqlConnection connection = new SqlConnection(cadConexion);
        SqlCommand sqlCommand = new SqlCommand(setencia, connection);
        SqlDataReader datos;
        try
        {
            connection.Open();
            datos = sqlCommand.ExecuteReader();
            if (datos.HasRows) // si trae datos se hace lectura los datos
            {
                datos.Read();//hace iteracion por los datos (se necesitaria un foreach en caso de que haya muchos registros y un read debera declararse en cada iteracion del for)}
                prestamo.ClavePrestamo= datos.GetString(0);
                prestamo.ClaveEjemplar= datos.GetString(1);
                prestamo.ClaveUsuario = datos.GetString(2);
                prestamo.FechaPrestamo = datos.GetDateTime(3);
                prestamo.FechaDevolucion = datos.GetDateTime(4);
                connection.Close();
            }


        }
        catch (Exception)
        {

            throw new Exception("No se ha encontrado el prestamo");
        }
        finally
        {
            sqlCommand.Dispose();
            connection.Dispose();
        }

        return prestamo;

    }


    public int modificar(EPrestamo prestamo, string claveVieja = "")
    {
        int result = -1;
        string sentencia = "";
        SqlConnection connection = new SqlConnection(cadConexion);
    
        if (string.IsNullOrEmpty(claveVieja))
            sentencia = $"Update Prestamo set claveEjemplar='{prestamo.ClaveEjemplar}', claveUsuario='{prestamo.ClaveUsuario}', FechaPrestamo='{prestamo.FechaPrestamo.ToString("yyyy/MM/dd")}', fechaDevolucion='{prestamo.FechaDevolucion.ToString("yyyy/MM/dd")}' " +
                $"where clavePrestamo = '{prestamo.ClavePrestamo}'";
        else
        {
            sentencia = $"Update Prestamo set claveEjemplar='{prestamo.ClaveEjemplar}', claveUsuario='{prestamo.ClaveUsuario}', FechaPrestamo='{prestamo.FechaPrestamo.ToString("yyyy/MM/dd")}', fechaDevolucion='{prestamo.FechaDevolucion.ToString("yyyy/MM/dd")}' " +
                $"where clavePrestamo = '{claveVieja}'";
        }
        SqlCommand sqlCommand = new SqlCommand(sentencia, connection);
        try
        {
            connection.Open();
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception)
        {

            throw new Exception("Un problema al actualizar el prestamo");
        }
        finally
        {
            connection.Dispose();
            sqlCommand.Dispose();
        }

        return result;
    }

    public int unResgistro(EPrestamo ePrestamo)
    {
        int result = -1;
        string sentencia = $"Select 1 from Prestamo where clavePrestamo='{ePrestamo.ClavePrestamo}'";
        SqlConnection connection = new SqlConnection(cadConexion);
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
            connection.Close();


        }
        catch (Exception)
        {

            throw new Exception("Ha ocurrido un error al buscar un registro  de usuario en la Base de datos");
        }
        return result;

    }
    #endregion
}

