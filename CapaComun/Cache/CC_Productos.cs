using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaComun.Cache
{
    public static class CC_Productos
    {
        public static int id { get; set; }
        public static string Nombre { get; set; }
        public static string descripcion { get; set; }
        public static double precioCompra { get; set; }
        public static double precioVenta { get; set; }
        public static int stockMin { get; set; }
        public static int stockMax { get; set; }
        public static int cantidad { get; set; }
        public static int idProveedor { get; set; }
        public static DateTime FechaAlta { get; set; }
        public static DateTime FechaBaja { get; set; }
        public static int idCategoria { get; set; }
        public static int Deshabilitado { get; set; }

    }
}
