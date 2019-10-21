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

        public DataTable BusquedaProductos(string busqueda)
        {
            DataTable tabla = new DataTable();
            tabla = objProducto.BusquedaProductos(busqueda);
            return tabla;
        }
        public void ABM_PRODUCTOS(string nombre, string descripcion, string precioCompra, string precioVenta, string cantidad,
        string stockMin, string stockMax,string Id_Categoria, string Id_Proveedor, int id_Usuario, int id_Accion)
        {
            objProducto.ABM_PRODUCTOS(nombre, descripcion, Convert.ToDouble(precioCompra), Convert.ToDouble(precioVenta), Convert.ToInt32(cantidad),
            Convert.ToInt32(stockMin),Convert.ToInt32(stockMax),Convert.ToInt32(Id_Categoria),Convert.ToInt32(Id_Proveedor),id_Usuario,id_Accion);

        }
    }
}
