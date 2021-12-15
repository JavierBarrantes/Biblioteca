using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
   public class EEditorial
    {

        public string Clave { get; set; }
        public string Nombre { get; set; }

        #region  Constructores

        public EEditorial()
        {
            Clave = string.Empty;
            Nombre = string.Empty;
        }
        public EEditorial(string  claveE, string nombre)
        {
            Clave = claveE;
            Nombre = nombre ;
        }
        #endregion
    }
}
