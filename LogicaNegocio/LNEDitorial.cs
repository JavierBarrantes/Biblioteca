using AcessoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entidades;
namespace LogicaNegocio
{
    public class LNEDitorial
    {
        private string CadenaConexion { get; }
        private string Mensaje { get; }
        #region Constructores

        public LNEDitorial()
        {


            CadenaConexion = string.Empty;

        }
        public LNEDitorial(string cadena)
        {
            CadenaConexion = cadena;

        }
        #endregion
        #region Metodos
        public bool editorialRepetido(EEditorial editorial)
        {
            bool result = false;
            ADEditoriales editorialDatos = new ADEditoriales(CadenaConexion);
            try
            {
                result = editorialDatos.editorialRepetido(editorial);
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
            ADEditoriales editorialDatos = new ADEditoriales(CadenaConexion);
            try
            {
                result = editorialDatos.claveRepetidaEditorial(libro);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //Todo:implementar
            return result;
        }

        public int insertar(EEditorial editorial)
        {
            int result;
            ADEditoriales editorialDatos = new ADEditoriales(CadenaConexion);
            try
            {
                result = editorialDatos.insertar(editorial);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
        public EEditorial buscarRegistro(string condicion)
        {
            EEditorial editorialE;
            ADEditoriales editorial = new ADEditoriales(CadenaConexion);
            try
            {
                editorialE = editorial.BuscarRegistro(condicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return editorialE;
        }
        public int eliminar(string clave)
        {

            ADEditoriales editorial = new ADEditoriales(CadenaConexion);
            int result = -1;
            try
            {
                result = editorial.eliminar(clave);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }


        public int modificar(EEditorial editorial, string claveVieja = "")
        {
            int result;
            ADEditoriales editorialDatos = new ADEditoriales(CadenaConexion);
            try
            {
                result = editorialDatos.modificar(editorial,claveVieja);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
        public DataTable listarTodos(string condicion, bool vista)
        {
            DataTable datos;
            ADEditoriales editorial = new ADEditoriales(CadenaConexion);
            try
            {
                datos = editorial.listarTodos(condicion, vista);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return datos;
        }
        public DataTable editoriales(string condicion)
        {
            DataTable datos;
            ADEditoriales editorial = new ADEditoriales(CadenaConexion);
            try
            {
                datos = editorial.editoriales(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return datos;
        }
        public int unResgistro(EEditorial eEditorial)
            {

            ADEditoriales editorial = new ADEditoriales(CadenaConexion);
            try
            {
                return editorial.unResgistro(eEditorial);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
    }
}
