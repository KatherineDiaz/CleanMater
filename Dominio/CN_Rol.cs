using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

namespace Dominio
{
    public class CN_Rol
    {
        private CD_Rol objRol = new CD_Rol();

        public DataTable MostrarRol()
        {
            DataTable tabla = new DataTable();
            tabla = objRol.TraerRol();
            return tabla;
        }
    }
}
