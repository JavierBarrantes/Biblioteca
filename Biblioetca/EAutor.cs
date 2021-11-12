using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
   public class EAutor
    {
        public string ClaveAutor { get; set; }
        public string Nombre { get; set; }
        public string APPaterno{ get; set; }
        public string APMarterno { get;set;}
    
        #region Constructores
        public EAutor()
        {
            ClaveAutor = string.Empty;
            Nombre = string.Empty;
            APMarterno = string.Empty;
            APPaterno = string.Empty;
        }


        public EAutor(string claveAutor, string nombre="", string apParterno="", string apMaterno = "")
        {
            this.ClaveAutor = claveAutor;
            this.Nombre = nombre;
            this.APPaterno = apParterno;
            this.APMarterno = apMaterno;
        }
        #endregion
    }
}
