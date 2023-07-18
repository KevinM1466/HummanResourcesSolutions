using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccess;
using DataAccess.CRUDS;

namespace Domain.CRUDS
{
    public class InventarioD
    {
        private InventarioDA inventario = new InventarioDA();

        public DataTable Mostrar(int localID)
        {
            DataTable tabla = new DataTable();
            tabla = inventario.Mostrar(localID);
            return tabla;
        }
    }
}
