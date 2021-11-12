﻿using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using AcessoDatos; 

namespace LogicaNegocio
{
    public class LNAutor // se instancia la clase en la logica

    {
        public string CadenaConexion { get; }
        public string Mensaje { get; }

        #region Constructores
        #endregion
        public LNAutor()
        {
            Mensaje = string.Empty;
            CadenaConexion = string.Empty;
        }

        public LNAutor(string cadena, string mensaje = "")
        {
            Mensaje = mensaje;
            CadenaConexion = cadena;

        }

        #region metodos


        public bool ClaveRepetida(Elibro libro)
        {
            bool result = false ;
            ADAutor autor = new ADAutor(CadenaConexion); //siempre se debe anda arrastrando la cadena de conexion atravez de las capas
            //ya que solo la capa de presetancion tiene un acceso directo a las credenciales del servidor SQL   
            try
            {

                result= autor.ClaveRepetida(libro);
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
