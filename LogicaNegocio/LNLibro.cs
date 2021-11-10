using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using AcessoDatos;
namespace LogicaNegocio
{
    public class LNLibro
    {

        private string mensaje;
        private string cadConexion;

        #region Constructores
        public LNLibro()
        {
            mensaje = string.Empty;
            cadConexion = string.Empty;
        }

        public LNLibro(string cad)
        {
            mensaje = string.Empty;
            cadConexion = cad;
        }
        #endregion



        #region metodos
        public bool libroRepetido(Elibro libro)
        {
            bool result =false;
            ADLibro adLibro = new ADLibro(cadConexion);

            try
            {
                result = adLibro.libroRepetido(libro);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //Todo:implementar
            return result;

        }
        public bool claveRepetida(string libro)
        {
            bool result = false;
            ADLibro adLibro = new ADLibro(cadConexion);
            //Todo:implementar

            try
            {
                result = adLibro.claveLibroRepetida(libro);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //Todo:implementar
            return result;
        }

        public int insertar(Elibro libro)
        {
            int result;
            ADLibro adlibro = new ADLibro(cadConexion);
            try
            {
                 result=adlibro.insertar(libro);
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
