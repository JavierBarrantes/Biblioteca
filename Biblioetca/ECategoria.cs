using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
   public class ECategoria
    {
        string claveCategoria;
        string descripcion;

        public string ClaveCategoria { get; set; }

        public string Descripcion { get; set; }

        public ECategoria()
        {
            ClaveCategoria = string.Empty;
            Descripcion = string.Empty;
        }
        public ECategoria(string clave,string descripcion)
        {
            this.ClaveCategoria = clave;
            this.Descripcion = descripcion;
        }

        #region Cnstructores 
       
        #endregion
    }
}
