using AcessoDatos;
using Entidades;
using System;
using System.Collections.Generic;
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
        #endregion

    }
}
