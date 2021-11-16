using AcessoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class LNPrestamo
    {
        string cadConexion;

        #region constructor

        public LNPrestamo(string cadConexion)
        {
            this.cadConexion = cadConexion;
        }
        #endregion
        #region Metodos

        public int insertarPrestamo(EPrestamo prestamo)
        {
            ADPrestamo prestamo1 = new ADPrestamo(cadConexion);
            int result = -1;
            try
            {
                result =prestamo1.insertarPrestamo(prestamo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public DataSet listarTodos(string condicion = "")
        {
            DataSet setlibros;
            ADPrestamo prestamo = new ADPrestamo(cadConexion);
            try
            {
                setlibros = prestamo.listarTodos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return setlibros;
        }
        #endregion
        public int eliminar(EPrestamo prestamo)
        {
            ADPrestamo aDPrestamo = new ADPrestamo(cadConexion);
            try
            {
                return aDPrestamo.eliminar(prestamo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public EPrestamo buscarRegistro(string condicion)
        {
            EPrestamo nuevo = new EPrestamo();
            ADPrestamo prestamo = new ADPrestamo(cadConexion);
            try
            {
                nuevo = prestamo.buscarRegistro(condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return nuevo;
        }
        public int modificar(EPrestamo prestamo, string claveVieja = "")
        {
            ADPrestamo aDPrestamo = new ADPrestamo(cadConexion);
            try
            {
                return aDPrestamo.modificar(prestamo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int unResgistro(EPrestamo ePrestamo)
        {
            ADPrestamo aDPrestamo = new ADPrestamo(cadConexion);
            try
            {
                return aDPrestamo.unResgistro(ePrestamo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeolverUnPrestamo(EPrestamo ePrestamo)
        {
           
            ADPrestamo prestamo = new ADPrestamo(cadConexion);
            try
            {
                return prestamo.DeolverUnPrestamo(ePrestamo);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int ClaveRepetida(EPrestamo ePrestamo)
        {
            ADPrestamo prestamo = new ADPrestamo(cadConexion);
            try
            {
                return prestamo.ClaveRepetida(ePrestamo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
