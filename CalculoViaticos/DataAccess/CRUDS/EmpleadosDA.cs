using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUDS
{
    public class EmpleadosDA : ConnectionToSql
    {
        private SqlDataReader leer;
        private DataTable table = new DataTable();
        private SqlCommand command = new SqlCommand();

        public DataTable Mostrar(bool isActive)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_EMPLEADOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@cargoid", 0);
                    command.Parameters.AddWithValue("@departamentoID", 0);
                    command.Parameters.AddWithValue("@nombres", "");
                    command.Parameters.AddWithValue("@apellidos", "");
                    command.Parameters.AddWithValue("@fechaContrata", null);
                    command.Parameters.AddWithValue("@imagen", null);
                    command.Parameters.AddWithValue("@fechaModi", null);
                    command.Parameters.AddWithValue("@estado", isActive);
                    command.Parameters.AddWithValue("@accion", "Mostrar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Insertar(string nombres, string apellidos, DateTime fechaContrata, int cargoid, int departamentoID, byte[] imagen, DateTime fechaModi, bool isActive)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_EMPLEADOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();                    
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@apellidos", apellidos);
                    command.Parameters.AddWithValue("@fechaContrata", fechaContrata);
                    command.Parameters.AddWithValue("@cargoid", cargoid);
                    command.Parameters.AddWithValue("@departamentoID", departamentoID);
                    command.Parameters.AddWithValue("@imagen", imagen);
                    command.Parameters.AddWithValue("@fechaModi", fechaModi);
                    command.Parameters.AddWithValue("@estado", isActive);
                    command.Parameters.AddWithValue("@accion", "Insertar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Actualizar(int codigo, string nombres, string apellidos, int cargoid, int departamentoID, byte[] imagen, DateTime fechaModi, bool isActive)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_EMPLEADOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@apellidos", apellidos);
                    command.Parameters.AddWithValue("@cargoid", cargoid);
                    command.Parameters.AddWithValue("@departamentoID", departamentoID);
                    command.Parameters.AddWithValue("@imagen", imagen);
                    command.Parameters.AddWithValue("@fechaModi", fechaModi);
                    command.Parameters.AddWithValue("@estado", isActive);
                    command.Parameters.AddWithValue("@accion", "Actualizar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Eliminar(int codigo, int cargoid, int departamentoID, string nombres, string apellidos, DateTime fechaModi, bool isActive)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_EMPLEADOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@apellidos", apellidos);
                    command.Parameters.AddWithValue("@cargoid", cargoid);
                    command.Parameters.AddWithValue("@departamentoID", departamentoID);
                    command.Parameters.AddWithValue("@fechaModi", fechaModi);
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
