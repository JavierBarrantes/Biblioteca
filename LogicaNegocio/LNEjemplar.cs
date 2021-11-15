using AcessoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio
{
   public class LNEjemplar
    {
        public string CadConexion { get; }

        #region Constructor
        public LNEjemplar(string cadena)
        {
            CadConexion = cadena;
        }
        #endregion

        #region Metodos

        public int unResgistro(EPrestamo ePrestamo)
        {
            
            ADEjemplar ejemplar = new ADEjemplar(CadConexion);
            try
            {
                return ejemplar.unResgistro(ePrestamo);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int modificar(EEjemplar eEjemplar1)
        {
            ADEjemplar ejemplar = new ADEjemplar(CadConexion);
            try
            {
                return ejemplar.modificar(eEjemplar1);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int validoParaPrestamo(EPrestamo prestamo)
        {
            ADEjemplar ejemplar = new ADEjemplar(CadConexion);
            try
            {
                return ejemplar.validoParaPrestamo(prestamo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
