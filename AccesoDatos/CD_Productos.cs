using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaComun.Cache;

namespace AccesoDatos
{
    public class CD_Productos:CD_Conexion
    {
        public DataTable ListarProductos()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "prc_Listar_Producto";
                    Comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = Comando.ExecuteReader();
                    tabla.Load(leer);
                    conexion.Close();
                    return tabla;
                }
            }
        }
        public void ABM_PRODUCTOS(string nombre, string descripcion,double precioCompra, double precioVenta, int cantidad,int stockMin,int stockMax,int Id_Categoria, int Id_Proveedor, int id_Usuario,int id_Accion)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.Parameters.AddWithValue("@Nombre", nombre);
                    Comando.Parameters.AddWithValue("@Descripcion", descripcion);
                    Comando.Parameters.AddWithValue("@PrecioCompra", precioCompra);
                    Comando.Parameters.AddWithValue("@PrecioVenta", precioVenta);
                    Comando.Parameters.AddWithValue("@Cantidad", cantidad);
                    Comando.Parameters.AddWithValue("@StockMin", stockMin);
                    Comando.Parameters.AddWithValue("@StockMax", stockMax);
                    Comando.Parameters.AddWithValue("@Id_Categoria", Id_Categoria);
                    Comando.Parameters.AddWithValue("@Id_Proveedor", Id_Proveedor);
                    Comando.Parameters.AddWithValue("@Id_Usuario", id_Usuario);
                    Comando.Parameters.AddWithValue("@Id_Accion", id_Accion);
                    Comando.CommandText = "prc_ABM_PRODUCTO";
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.ExecuteNonQuery();

                }
            }
        }
        public DataTable BusquedaProductos(string busqueda)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();

                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.Parameters.AddWithValue("@Busqueda", busqueda);
                    Comando.CommandText = "prc_Listar_Busqueda_Producto";
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.ExecuteNonQuery();
                    conexion.Close();
                }

                return tabla;
            }
        }
    }
}
