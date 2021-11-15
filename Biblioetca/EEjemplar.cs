using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
     public  class EEjemplar
    {

        public string ClaveEjemplar { get; set;}
        public string ClaveLibro { get; set; }
        public string ClaveCondicion{ get; set; }
        public string ClaveEstado{ get; set; }
        public string Edicion{ get; set; }
        public string ClaveEditorial { get; set; }
        public int  NumeroPaginas{ get; set; }

        #region Construcotres

        public EEjemplar()
        {
            ClaveEjemplar = string.Empty;
            ClaveLibro = string.Empty;
            ClaveCondicion = string.Empty;
            ClaveEstado = string.Empty;
            ClaveEditorial = string.Empty;
            NumeroPaginas = 0;
        }

        public EEjemplar(string claveEjemplar, string claveEstado, string claveLibro="",string claveCondicion="",string claveEditorial="",int numero=0)

        {
           
            ClaveEjemplar= claveEjemplar;
            ClaveLibro = claveLibro;
            ClaveCondicion = claveCondicion;
            ClaveEstado = claveEstado;
            ClaveEditorial = claveEditorial;
            NumeroPaginas = numero;
                

        }
        #endregion
    }
}
