using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaComun.Cache
{
    public static class CC_Cliente
    {
        public static int id { get; set; }
        public static string Nombre { get; set; }
        public static string apellido { get; set; }
        public static int telefono { get; set; }
        public static int celular { get; set; }
        public static int Id_Tipo_Iden { get; set; }
        public static int Num_Identificacion { get; set; }
        public static string direccion { get; set; }
        public static string correo { get; set; }
        public static DateTime FechaAlta { get; set; }
        public static DateTime FechaBaja { get; set; }
        public static int Deshabilitado { get; set; }
    }
}
