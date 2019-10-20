using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class CD_Clientes : CD_Conexion
    {
        public DataTable ListarClientes()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "prc_Listar_Perfil_Cliente";
                    Comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = Comando.ExecuteReader();
                    tabla.Load(leer);
                    conexion.Close();
                    return tabla;
                }
            }
        }
        public void ABM_CLIENTE(string nombre, string apellido, string direccion, int telefono, int celular, int id_tipo_iden, int num_ident, string correoElectronico, int id_Usuario, int id_Accion)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.Parameters.AddWithValue("@Nombre", nombre);
                    Comando.Parameters.AddWithValue("@Apellido", apellido);
                    Comando.Parameters.AddWithValue("@Direccion", direccion);
                    Comando.Parameters.AddWithValue("@Telefono", telefono);
                    Comando.Parameters.AddWithValue("@Celular", celular);
                    Comando.Parameters.AddWithValue("@Id_Tipo_Iden", id_tipo_iden);
                    Comando.Parameters.AddWithValue("@Num_Identificacion", num_ident);
                    Comando.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
                    Comando.Parameters.AddWithValue("@Id_Usuario", id_Usuario);
                    Comando.Parameters.AddWithValue("@Id_Accion", id_Accion);
                    Comando.CommandText = "prc_ABM_CLIENTE";
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.ExecuteNonQuery();

                }
            }
        }
     
       
    }
}
