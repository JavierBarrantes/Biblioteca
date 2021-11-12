using AcessoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio
{
  public  class LNCategoria
    {
        public string CadenaConexion { get; }
        public string Mensaje { get; }

        #region Constructores
        #endregion
        public LNCategoria()
        {
            Mensaje = string.Empty;
            CadenaConexion = string.Empty;
        }

        public LNCategoria(string cadena, string mensaje = "")
        {
            Mensaje = mensaje;
            CadenaConexion = cadena;

        }

        #region metodos


        public bool ClaveRepetida(Elibro libro)
        {
            bool result = false;
            ADCategoria categoria = new ADCategoria(CadenaConexion); //siempre se debe anda arrastrando la cadena de conexion atravez de las capas
            //ya que solo la capa de presetancion tiene un acceso directo a las credenciales del servidor SQL   
            try
            {

                result = categoria.ClaveRepetida(libro);
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
