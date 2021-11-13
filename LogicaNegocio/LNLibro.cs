using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using AcessoDatos;
using System.Data;

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
         
            return result;

        }
        public bool claveRepetida(string libro)
        {
            bool result = false;
            ADLibro adLibro = new ADLibro(cadConexion);

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

        public DataSet listarTodos(string condicion = "")
        {
            DataSet setlibros;
            ADLibro aDLibro = new ADLibro(cadConexion);
            try
            {
                setlibros = aDLibro.listarTodos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return setlibros;
        }

        public Elibro buscarRegistro(string condicion)
        {
            Elibro libro;
            ADLibro aDLibro = new ADLibro(cadConexion);
            try
            {
              libro=  aDLibro.buscarRegistro(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return libro;
        }


        public int eliminar(Elibro libro)
        {
      ;
            ADLibro aDLibro = new ADLibro(cadConexion);
            int result = -1;
            try
            {
               result= aDLibro.eliminar(libro);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
        public string eliminarProcedure(Elibro libro)
        {
            ADLibro aDLibro = new ADLibro(cadConexion);

            try
            {
                mensaje = aDLibro.eliminarProcedure(libro);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }
            return mensaje;
        }

        public int modificar(Elibro libro, string claveVieja = "")
        {
            int result;
            ADLibro aDLibro = new ADLibro(cadConexion);
            try
            {
                result= aDLibro.modificar(libro,claveVieja)
            }
            catch (Exception ex )
            {

                throw ex;
            }
            return result;
        }
        #endregion
    }
}
