using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUDS
{
    public class JefesDA : ConnectionToSql
    {
        private SqlDataReader leer;
        private DataTable table = new DataTable();
        private SqlCommand command = new SqlCommand();

        public DataTable Mostrar( bool isEnable )
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_JEFES";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@codigo", 0);
                    command.Parameters.AddWithValue("@empleadoID", 0);
                    command.Parameters.AddWithValue("@departamentoID", 0);
                    command.Parameters.AddWithValue("@firma", null);
                    command.Parameters.AddWithValue("@nombreFirma", "");
                    command.Parameters.AddWithValue("@estado", isEnable);
                    command.Parameters.AddWithValue("@accion", "Mostrar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Insertar(int empleadoID, int departamentoID, byte[] firma, string nombreFirma)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_JEFES";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@empleadoID", empleadoID);
                    command.Parameters.AddWithValue("@departamentoID", departamentoID);
                    command.Parameters.AddWithValue("@firma", firma);
                    command.Parameters.AddWithValue("@nombreFirma", nombreFirma);
                    command.Parameters.AddWithValue("@accion", "Insertar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Actualizar(int codigo, int empleadoID, int departamentoID, byte[] firma, string nombreFirma)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_JEFES";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.Parameters.AddWithValue("@empleadoID", empleadoID);
                    command.Parameters.AddWithValue("@departamentoID", departamentoID);
                    command.Parameters.AddWithValue("@firma", firma);
                    command.Parameters.AddWithValue("@nombreFirma", nombreFirma);
                    command.Parameters.AddWithValue("@accion", "Actualizar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Eliminar(int codigo, int empleadoID, int departamentoID, byte[] firma, string nombreFirma)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_JEFES";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.Parameters.AddWithValue("@empleadoID", empleadoID);
                    command.Parameters.AddWithValue("@departamentoID", departamentoID);
                    command.Parameters.AddWithValue("@firma", firma);
                    command.Parameters.AddWithValue("@nombreFirma", nombreFirma);
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
