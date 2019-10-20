using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

namespace Dominio
{
    public class CN_Categoria
    {
        private CD_Categorias objCategoria = new CD_Categorias();

        public DataTable MostrarCategorias()
        {
            DataTable tabla = new DataTable();
            tabla = objCategoria.ListarCategorias();
            return tabla;
        }
    }
}
