using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public abstract class CD_Conexion //Esta clase no puede ser instanciada solo se usa de clase base
    {
        public readonly string CadenaConexion;
        public CD_Conexion()
        {
            //CAMBIAR LA CADENA DE CONEXION DEPENDIENDO DEL TIPO DE SERVIDOR SQL
            CadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=CleanMaster;Integrated Security=True";

            //CadenaConexion = "Data Source=localhost;Initial Catalog=stockDB;Integrated Security=True";
        }
        protected SqlConnection GetConnection() {
            return new SqlConnection(CadenaConexion);
        }
    }
}
