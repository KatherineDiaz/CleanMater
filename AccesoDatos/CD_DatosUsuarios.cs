using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaComun.Cache;

namespace AccesoDatos
{
    public class CD_DatosUsuarios:CD_Conexion
    {
        public bool IniciarSesion(string usuario, string clave)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.Parameters.AddWithValue("@Usuario", usuario);
                    Comando.Parameters.AddWithValue("@clave", clave);
                    Comando.CommandText = "prc_ListarUsuario";
                    Comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = Comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CC_SesionUsuarioCache.Id_Usuario = reader.GetInt32(0);
                            CC_SesionUsuarioCache.Usuario = reader.GetString(1);
                            CC_SesionUsuarioCache.Clave = reader.GetString(2);
                            CC_SesionUsuarioCache.Nombre = reader.GetString(3);
                            CC_SesionUsuarioCache.Apellido = reader.GetString(4);
                            CC_SesionUsuarioCache.Telefono = reader.GetInt32(5);
                            CC_SesionUsuarioCache.Celular = reader.GetInt32(6);
                            CC_SesionUsuarioCache.tipoIndentificacion = reader.GetString(7);
                            CC_SesionUsuarioCache.NumIdentificacion = reader.GetInt32(8);
                            CC_SesionUsuarioCache.Direccion = reader.GetString(9);
                            CC_SesionUsuarioCache.Rol = reader.GetString(10);                       
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public DataTable ListarUsuarios()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "prc_ListarU";
                    Comando.CommandType = CommandType.Text;
                    SqlDataReader leer = Comando.ExecuteReader();
                    tabla.Load(leer);
                    conexion.Close();
                    return tabla;
                }
            }
        }
        
        public DataTable BuscarDatos(string usuario)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "SELECT * FROM VW_Listar_Perfil_Usuario WHERE Usuario = '" + usuario + "'";
                    Comando.CommandType = CommandType.Text;
                    SqlDataReader leer = Comando.ExecuteReader();
                    tabla.Load(leer);
                    conexion.Close();
                    return tabla;
                }
            }
        }
        public void ModificarClave(string clave, string usuario)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "UPDATE Usuario SET Clave = '" + clave + "' WHERE Usuario = '" + usuario + "'";
                    Comando.CommandType = CommandType.Text;
                    Comando.ExecuteNonQuery();

                }
            }
        }

        public DataTable MostrarPreguntas()
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "Select * from Pregunta";
                    comando.CommandType = CommandType.Text;
                    SqlDataReader leer = comando.ExecuteReader();
                    tabla.Load(leer);
                    conexion.Close();
                    return tabla;
                }
                
            }
        }

        public void ABM_USUARIOS(string usuario, string clave, string nombre, string apellido, int telefono, int celular, int idTi, int idIf, string direccion, int rol, int id_Usuario, int id_Accion)
        {
            using (var conexion = GetConnection())
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.Parameters.AddWithValue("@Usuario", usuario);
                    Comando.Parameters.AddWithValue("@Clave", clave);
                    Comando.Parameters.AddWithValue("@Nombre", nombre);
                    Comando.Parameters.AddWithValue("@Apellido", apellido);
                    Comando.Parameters.AddWithValue("@Telefono", telefono);
                    Comando.Parameters.AddWithValue("@Celular", celular);
                    Comando.Parameters.AddWithValue("@Id_Tipo_Iden", idTi);
                    Comando.Parameters.AddWithValue("@Num_Identificacion", idIf);
                    Comando.Parameters.AddWithValue("@Direccion", direccion);
                    Comando.Parameters.AddWithValue("@Id_Rol", rol);
                    Comando.Parameters.AddWithValue("@Id_Usuario", id_Usuario);
                    Comando.Parameters.AddWithValue("@Id_Accion", id_Accion);
                    Comando.CommandText = "prc_ABM_USUARIO";
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void CambiarRespuesta(string respuesta, string usuario, int idPregunta)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = conexion;
                    Comando.CommandText = "UPDATE Usuario SET Respuesta = '" + respuesta + "', Id_Pregunta = " + idPregunta + " WHERE Usuario = '" + usuario + "'";
                    Comando.CommandType = CommandType.Text;
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void Permisos()
        {
            if (CC_SesionUsuarioCache.Rol == CC_Roles.Administrador)
            {

            }
            if (CC_SesionUsuarioCache.Rol == CC_Roles.Usuario)
            {

            }
        }
    }
}
