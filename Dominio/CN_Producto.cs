using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

namespace Dominio
{
    public class CN_Producto
    {
        private CD_Productos objProducto = new CD_Productos();

        public DataTable MostrarProductos()
        {
            DataTable tabla = new DataTable();
            tabla = objProducto.ListarProductos();
            return tabla;
        }
        
        public void CargarProductos(string nombre, string descripcion, string precioCompra, string precioVenta, string cantidad)
        {
            objProducto.CargarProductos(nombre, descripcion, Convert.ToDouble(precioCompra), Convert.ToDouble(precioVenta), Convert.ToInt32(cantidad));//, Convert.ToInt32(idProveedor), Convert.ToDateTime(fAlta), Convert.ToDateTime(fBaja)

        }
    }
}
