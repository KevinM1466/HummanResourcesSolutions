using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUDS
{
    public class SolicitudDA : ConnectionToSql
    {
        private SqlDataReader leer;
        private DataTable table = new DataTable();
        private SqlCommand command = new SqlCommand();

        public DataTable Mostrar(int jefeID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_Solicitud";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@solicitudID", 0);
                    command.Parameters.AddWithValue("@tipoSolicitud", 0);
                    command.Parameters.AddWithValue("@empleadoID", 0);
                    command.Parameters.AddWithValue("@fechaEfectiva", null);
                    command.Parameters.AddWithValue("@fechaInicio", null);
                    command.Parameters.AddWithValue("@fechaFinal", null);
                    command.Parameters.AddWithValue("@fechaReingreso", null);
                    command.Parameters.AddWithValue("@remuneracion", 0);
                    command.Parameters.AddWithValue("@motivo", "");
                    command.Parameters.AddWithValue("@jefeID", jefeID);
                    command.Parameters.AddWithValue("@accion", "Mostrar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable MostrarSoli(int jefeID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_Solicitud";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@solicitudID", 0);
                    command.Parameters.AddWithValue("@tipoSolicitud", 0);
                    command.Parameters.AddWithValue("@empleadoID", 0);
                    command.Parameters.AddWithValue("@fechaEfectiva", null);
                    command.Parameters.AddWithValue("@fechaInicio", null);
                    command.Parameters.AddWithValue("@fechaFinal", null);
                    command.Parameters.AddWithValue("@fechaReingreso", null);
                    command.Parameters.AddWithValue("@remuneracion", 0);
                    command.Parameters.AddWithValue("@motivo", "");
                    command.Parameters.AddWithValue("@jefeID", jefeID);
                    command.Parameters.AddWithValue("@accion", "MostrarSoli");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }
        public DataTable MostrarSoliEmpleado(int empleadoID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_Solicitud";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@solicitudID", 0);
                    command.Parameters.AddWithValue("@tipoSolicitud", 0);
                    command.Parameters.AddWithValue("@empleadoID", empleadoID);
                    command.Parameters.AddWithValue("@fechaEfectiva", null);
                    command.Parameters.AddWithValue("@fechaInicio", null);
                    command.Parameters.AddWithValue("@fechaFinal", null);
                    command.Parameters.AddWithValue("@fechaReingreso", null);
                    command.Parameters.AddWithValue("@remuneracion", 0);
                    command.Parameters.AddWithValue("@motivo", "");
                    command.Parameters.AddWithValue("@jefeID", 0);
                    command.Parameters.AddWithValue("@accion", "MostrarSoliEmpleado");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Insertar(string tipoSolicitud, int empleadoID, DateTime fechaEfectiva, DateTime fechaInicio, DateTime fechaFinal, DateTime fechaReingreso, bool isRemuneracion, string motivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_Solicitud";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@tipoSolicitud", tipoSolicitud);
                    command.Parameters.AddWithValue("@empleadoID", empleadoID);
                    command.Parameters.AddWithValue("@fechaEfectiva", fechaEfectiva);
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                    command.Parameters.AddWithValue("@fechaReingreso", fechaReingreso);
                    command.Parameters.AddWithValue("@remuneracion", isRemuneracion);
                    command.Parameters.AddWithValue("@motivo", motivo);
                    command.Parameters.AddWithValue("@accion", "Insertar");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable ActualizarRecursos(int solicitudID, string tipoSolicitud, int empleadoID, DateTime fechaEfectiva, DateTime fechaInicio, DateTime fechaFinal, DateTime fechaReingreso, bool isRemuneracion, string motivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_Solicitud";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@solicitudID", solicitudID);
                    command.Parameters.AddWithValue("@tipoSolicitud", tipoSolicitud);
                    command.Parameters.AddWithValue("@empleadoID", empleadoID);
                    command.Parameters.AddWithValue("@fechaEfectiva", fechaEfectiva);
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                    command.Parameters.AddWithValue("@fechaReingreso", fechaReingreso);
                    command.Parameters.AddWithValue("@remuneracion", isRemuneracion);
                    command.Parameters.AddWithValue("@motivo", motivo);
                    command.Parameters.AddWithValue("@accion", "ActualizacionRecursos");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }
        
        public DataTable ActualizarJefe(int solicitudID, string tipoSolicitud, int empleadoID, DateTime fechaEfectiva, DateTime fechaInicio, DateTime fechaFinal, DateTime fechaReingreso, bool isRemuneracion, string motivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CRUD_Solicitud";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@solicitudID", solicitudID);
                    command.Parameters.AddWithValue("@tipoSolicitud", tipoSolicitud);
                    command.Parameters.AddWithValue("@empleadoID", empleadoID);
                    command.Parameters.AddWithValue("@fechaEfectiva", fechaEfectiva);
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                    command.Parameters.AddWithValue("@fechaReingreso", fechaReingreso);
                    command.Parameters.AddWithValue("@remuneracion", isRemuneracion);
                    command.Parameters.AddWithValue("@motivo", motivo);
                    command.Parameters.AddWithValue("@accion", "ActualizacionJefe");
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }
    }
}
