using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUDS
{
    public class ClientesDA : ConnectionToSql
    {
        private SqlDataReader leer;
        private DataTable table = new DataTable();
        private SqlCommand command = new SqlCommand();

        public DataTable Mostrar()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_CLIENTES";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@codigo", 0);
                    command.Parameters.AddWithValue("@nombres", "");
                    command.Parameters.AddWithValue("@identidad", "");
                    command.Parameters.AddWithValue("@estado", true);
                    command.Parameters.AddWithValue("@accion", "Mostrar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Insertar(string nombres, string identidad, bool isActive)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_CLIENTES";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@identidad", identidad);
                    command.Parameters.AddWithValue("@estado", isActive);
                    command.Parameters.AddWithValue("@accion", "Insertar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Actualizar(int id, string nombres, string identidad, bool isActive)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_CLIENTES";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@identidad", identidad);
                    command.Parameters.AddWithValue("@estado", isActive);
                    command.Parameters.AddWithValue("@codigo", id);
                    command.Parameters.AddWithValue("@accion", "Actualizar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Eliminar(int id, string nombres, string identidad, bool isActive)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_CLIENTES";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@identidad", identidad);
                    command.Parameters.AddWithValue("@codigo", id);
                    command.Parameters.AddWithValue("@estado", isActive);
                    command.Parameters.AddWithValue("@accion", "Eliminar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }
    }
}
