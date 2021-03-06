using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace AcessoDatos
{
    public class ADEjemplar
    {
        public string CadConexion { get; }

        #region construcotres 
        public ADEjemplar(string cadena)
        {
            CadConexion = cadena;
        }
        #endregion
        #region Metodos

        //TODO:HACER ENTIDADES DE EJEMPLAR Y LOGICA!
        public int unResgistro(EPrestamo ePrestamo)
        {
            int result = -1;
            string sentencia = $"Select 1 from Ejemplar where claveEjemplar='{ePrestamo.ClaveEjemplar}'";
            SqlConnection connection = new SqlConnection(CadConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia,connection);
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

                throw new Exception("Ha ocurrido un error al buscar un registro de usuario en la Base de datos");
            }
            return result;

        }

        //public int UpdateEjemplar(EPrestamo ePrestamo)
        //{
        //    int result = -1;
        //    string sentencia = $"Select 1 from Ejemplar where claveEjemplar='{ePrestamo.ClaveEjemplar}'";
        //    SqlConnection connection = new SqlConnection(CadConexion);
        //    SqlCommand sqlCommand = new SqlCommand(sentencia, connection);
        //    try
        //    {
        //        connection.Open();
        //        result=sqlCommand.ExecuteNonQuery();
        //        connection.Close();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return result;
        //}
        public int modificar(EEjemplar eEjemplar1)
        {
            int result = -1;
            string sentencia = "Update ejemplar set  ";
            SqlConnection connection = new SqlConnection(CadConexion);
            sentencia += $"claveEstado='{eEjemplar1.ClaveEstado}' where claveEjemplar = '{eEjemplar1.ClaveEjemplar}'";
            SqlCommand sqlCommand = new SqlCommand(sentencia, connection);
           
          
            try
            {
                connection.Open();
               result=sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {

                throw new Exception("Un problema al actualizar el ejemplar ");
            }
            finally
            {
                connection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }

        public int validoParaPrestamo(EPrestamo prestamo)
        {
            int result = -1;
            string sentencia = $"Select 1 from  ejemplar  where claveEjemplar = '{prestamo.ClaveEjemplar}' and claveEstado!='E002'";

            SqlConnection connection = new SqlConnection(CadConexion);
            SqlCommand sqlCommand = new SqlCommand(sentencia, connection);
            object objScalar;
            try
            {
                connection.Open();
                objScalar = sqlCommand.ExecuteScalar();
                if (objScalar != null)
                    result = 1;
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
            string sentencia = "Select claveEjemplar, e.claveLibro, claveCondicion, claveEstado, edicion, claveEditorial, numeroPaginas  " +
                "from EJEMPLAR e inner join LIBRO l on e.claveLibro = l.claveLibro";

            if (!string.IsNullOrEmpty(condicion))
                sentencia = string.Format("{0} where l.titulo like {1}", sentencia, condicion);
            SqlConnection connection = new SqlConnection(CadConexion);
            SqlDataAdapter sqlDataAdapter; // NO SE INSTANCIA AUN HASTA QUE SE USE!!!

            try
            {
                sqlDataAdapter = new SqlDataAdapter(sentencia, connection); //se instancia con el selec y la conexion a la base de datos
                sqlDataAdapter.Fill(setLibros, "Ejemplar"); //LLENA EL DATA SET
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
