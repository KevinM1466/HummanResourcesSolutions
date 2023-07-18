using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.CRUDS
{
    public class InventarioDA : ConnectionToSql
    {
        private SqlDataReader leer;
        private DataTable table = new DataTable();
        private SqlCommand command = new SqlCommand();

        public DataTable Mostrar(int localID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_INVENTARIO";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@productoID", 0/* TODO Change to default(_) if this is not a reference type */);
                    command.Parameters.AddWithValue("@stockInicial", 0/* TODO Change to default(_) if this is not a reference type */);
                    command.Parameters.AddWithValue("@entradas", 0);
                    command.Parameters.AddWithValue("@salidas", 0);
                    command.Parameters.AddWithValue("@total", 0);
                    command.Parameters.AddWithValue("@localID", localID);
                    command.Parameters.AddWithValue("@accion", "Mostrar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }
    }
}
