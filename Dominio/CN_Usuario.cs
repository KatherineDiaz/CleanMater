using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data;
using System.Data.SqlClient;
using CapaComun.Cache;

namespace Dominio
{
    
    public class CN_Usuario
    {
        CD_DatosUsuarios DatosUsuario = new CD_DatosUsuarios();
        public bool InicioSesion(string usuario,string clave)
        {
            return DatosUsuario.IniciarSesion(usuario,clave);
        }

        public DataTable MostrarPreguntas()
        {
            DataTable tabla = new DataTable();
            tabla = DatosUsuario.MostrarPreguntas();
            return tabla;
        }
        public DataTable MostrarUsuarios()
        {
            DataTable tabla = new DataTable();
            tabla = DatosUsuario.ListarUsuarios();
            return tabla;
        }

        public void ABM_USUARIOS(string usuario, string clave, string nombre, string apellido, string telefono, string celular, string idTi, string idIf, string direccion, string rol, int id_Usuario, int id_accion)
        {
            DatosUsuario.ABM_USUARIOS(usuario, clave, nombre, apellido, Convert.ToInt32(telefono), Convert.ToInt32(celular),Convert.ToInt32(idTi), Convert.ToInt32(idIf), direccion, Convert.ToInt32(rol), id_Usuario, id_accion);
        }
        public void ModificarClave(string clave,string usuario){
            DatosUsuario.ModificarClave(clave, usuario);
        }
        public string BuscarPregunta(string usuario) {
            string pregunta = null;
            DatosUsuario.BuscarDatos(usuario);

            foreach (DataRow x in DatosUsuario.BuscarDatos(usuario).Rows)
            {
                pregunta = x["pregunta"].ToString();
            }
            return pregunta;
        }

        public string BuscarRespuesta(string usuario)
        {
            string respuesta = null;
            DatosUsuario.BuscarDatos(usuario);

            foreach (DataRow x in DatosUsuario.BuscarDatos(usuario).Rows)
            {
                respuesta = x["respuesta"].ToString();
            }
            return respuesta;
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
