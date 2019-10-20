using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

namespace Dominio
{
    public class CN_Cliente 
    {
        private CD_Clientes objCliente = new CD_Clientes();

        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();
            tabla = objCliente.ListarClientes();
            return tabla;
        }
        public void ABM_CLIENTE(string nombre, string apellido, string direccion, string telefono, string celular, string idTi, string num_iden, string correo, int id_Usuario, int id_accion)
        {
            objCliente.ABM_CLIENTE(nombre,apellido, direccion, Convert.ToInt32(telefono), Convert.ToInt32(celular), Convert.ToInt32(idTi), Convert.ToInt32(num_iden), correo, id_Usuario, id_accion);

        }
    }
}
