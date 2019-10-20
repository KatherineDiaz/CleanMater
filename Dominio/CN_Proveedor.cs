using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

namespace Dominio
{
    public class CN_Proveedor
    {
        private CD_Proveedores objProveedor = new CD_Proveedores();

        public DataTable MostrarProveedores()
        {
            DataTable tabla = new DataTable();
            tabla = objProveedor.ListarProveedores();
            return tabla;
        }
        public void ABM_PROVEEDORES(string nombre, string direccion, string telefono, string celular, string idTi, string num_iden, string correo, int id_Usuario, int id_accion)
        {
            objProveedor.ABM_PROVEEDORES(nombre, direccion, Convert.ToInt32(telefono), Convert.ToInt32(celular), Convert.ToInt32(idTi), Convert.ToInt32(num_iden), correo, id_Usuario, id_accion);

        }
     
    }
}
