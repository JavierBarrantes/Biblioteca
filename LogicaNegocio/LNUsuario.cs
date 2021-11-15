﻿using System;
using System.Collections.Generic;
using System.Text;
using AcessoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LNUsuario
    {
        string CadenaConexion { get; }


        #region Constructores
        public LNUsuario(string cadena)
        {
            CadenaConexion=cadena;
        }

        #endregion


        #region Metodos

        public int unResgistro(EPrestamo ePrestamo)
        {

            ADUSuario usuario= new ADUSuario(CadenaConexion);
            try
            {

                return usuario.unResgistro(ePrestamo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int validoParaPrestamo(EPrestamo prestamo)
        {
            ADUSuario usuario = new ADUSuario(CadenaConexion);
            try
            {
                return usuario.validoParaPrestamo(prestamo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
