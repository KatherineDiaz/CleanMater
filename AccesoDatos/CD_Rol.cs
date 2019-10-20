using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class CD_Rol:CD_Conexion
    {
        public DataTable TraerRol()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "SELECT Id_Rol, rol FROM Rol";
                    Comando.CommandType = CommandType.Text;
                    SqlDataReader leer = Comando.ExecuteReader();
                    tabla.Load(leer);
                    conexion.Close();
                    return tabla;
                }
            }
        }
    }
}
