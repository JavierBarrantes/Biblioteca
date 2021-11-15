using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EPrestamo
    {
        public string ClavePrestamo { get; set; }
        public string ClaveEjemplar { get; set; }
        public string ClaveUsuario { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        #region Constructores

        public EPrestamo()
        {
            ClavePrestamo = string.Empty;
            ClaveEjemplar= string.Empty;
            ClaveUsuario= string.Empty;
            FechaPrestamo =DateTime.MinValue;
            FechaDevolucion = DateTime.MinValue;

            
        }
        public EPrestamo(string claveP,string claveE,string claveU,DateTime fechaPrestamo,DateTime fechaDevolucion)
        {
            
            ClavePrestamo = claveP ;
            ClaveEjemplar = claveE;
            ClaveUsuario = claveU;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaPrestamo;
        }
        #endregion
       
    }
}
