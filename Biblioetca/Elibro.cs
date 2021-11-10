using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
  public  class Elibro
    {
        #region Atributos
        string claveLibro;
        string titulo;
        string claveAutor;
        bool existe;
        ECategoria categoria;
        //propiedades con get y set
        public string ClaveLibro { get; set; }
        public string Titulo { get; set; }
        public string ClaveAutor { get; set; }
        public ECategoria Categoria { get; set; }
        public bool Existe { get; set; }
        
        #endregion
        #region Constructores
        public Elibro()
        {
            ClaveLibro = string.Empty;
            Titulo = string.Empty;
            ClaveAutor = string.Empty;
            Categoria = new ECategoria();
            Existe = false;
        }



        public Elibro(string claveLibroP,string tituloP,string claveAutorP,ECategoria cate,bool bandera)
        {
            ClaveLibro = claveLibroP;
            Titulo = tituloP;
            ClaveAutor = claveAutorP;
            Categoria = cate;
            Existe = bandera;

        }
        #endregion

    }
}
