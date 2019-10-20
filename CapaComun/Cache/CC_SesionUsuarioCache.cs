using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaComun.Cache
{
    public static class CC_SesionUsuarioCache
    {
        public static int Id_Usuario { get; set; }
        public static string Usuario { get; set; }
        public static string Clave { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }    
        public static int Telefono { get; set; }
        public static int Celular { get; set; }
        public static string tipoIndentificacion { get; set; }
        public static int NumIdentificacion { get; set; }
        public static string Direccion { get; set; }
        public static int Id_Pregunta { get; set; }
        public static string Respuesta { get; set; }
        public static string Rol { get; set; }
        public static DateTime FechaAlta { get; set; }
        public static DateTime FechaBaja { get; set; }
        public static int Deshabilitado { get; set; }
        //public static int Estado { get; set; }

    }
}
