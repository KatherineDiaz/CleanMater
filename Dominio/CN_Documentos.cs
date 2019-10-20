using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

namespace Dominio
{
    public class CN_Documento
    {
        private CD_Documentos objDocumento = new CD_Documentos();

        public DataTable MostrarDocumentos()
        {
            DataTable tabla = new DataTable();
            tabla = objDocumento.ListarDocumentos();
            return tabla;
        }
    }
}
