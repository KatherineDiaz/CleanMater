using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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
                    Comando.CommandText = "prc_ListarProductos";
                    Comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = Comando.ExecuteReader();
                    tabla.Load(leer);
                    conexion.Close();
                    return tabla;
                }
            }
        }
        public void CargarProductos(string nombre,string descripcion, double precioCompra, double precioVenta, int cantidad)//consultar como declarar imagen y boolean disable ,int idProveedor,DateTime fAlta,DateTime fBaja
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "INSERT INTO Producto VALUES('" + nombre + "','" + descripcion + "'," + precioCompra + ","+ precioVenta +", " + cantidad + ",1,1,1,'false');";//,'" + idProveedor + "','" + fAlta + "','" + fBaja + "'
                    Comando.CommandType = CommandType.Text;
                    Comando.ExecuteNonQuery();
                    
                }
            }
        }
        public void ModificarProductos(string nombre, string descripcion, double precioCompra, double precioVenta, int cantidad)//consultar como declarar imagen y boolean disable ,int idProveedor,DateTime fAlta,DateTime fBaja
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "";
                    Comando.ExecuteNonQuery();

                }
            }
        }
    }
}
