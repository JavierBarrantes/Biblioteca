using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    class EUsuario
    {
        public string ClaveUsario { get; set; }
        public string Curp { get; set; }
        public string Nombre { get; set; }
        public string ApParterno { get; set; }
        public string ApMaterno { get; set; }
        public DateTime  FechaNacimiento { get; set;}
        public string Email { get; set; }
        public string Direccion { get; set;}
        #region Constructores 
        public EUsuario()
        {
            ClaveUsario = string.Empty;
            Curp = string.Empty;
            Nombre = string.Empty;
            ApParterno = string.Empty;
            ApMaterno = string.Empty;
            FechaNacimiento = DateTime.MinValue;
            Email = string.Empty;
            Direccion = string.Empty;
           

        }

       public EUsuario(string claveU,string curp,string nombre,string apPaterno,string apMaterno, DateTime fecha,string email,string direcion)
        {
            ClaveUsario = claveU;
            Curp = curp;
            Nombre = nombre;
            ApParterno = apPaterno;
            ApMaterno = apMaterno;
            FechaNacimiento = fecha;
            Email = email;
            Direccion = direcion;
            
        }
        #endregion





    }
}
