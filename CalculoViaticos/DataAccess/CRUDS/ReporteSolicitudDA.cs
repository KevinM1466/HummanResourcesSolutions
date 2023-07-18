using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUDS
{
    public class ReporteSolicitudDA : ConnectionToSql
    {
        private SqlDataReader leer;
        private DataTable table = new DataTable();
        private SqlCommand command = new SqlCommand();

        public DataTable Mostrar(int solicitudID, string tipoSolicitud, int empleadoID, string empleado, DateTime fechaEfectiva, DateTime fechaInicio, DateTime fechaFinal, DateTime fechaReingreso, bool remuneracion, string motivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ReporteGeneral";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@solicitudID", solicitudID);
                    command.Parameters.AddWithValue("@tipoSolicitud", tipoSolicitud);
                    command.Parameters.AddWithValue("@empleadoID", empleadoID);
                    command.Parameters.AddWithValue("@empleado", empleado);
                    command.Parameters.AddWithValue("@fechaEfectiva", fechaEfectiva);
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                    command.Parameters.AddWithValue("@fechaReingreso", fechaReingreso);
                    command.Parameters.AddWithValue("@remuneracion", remuneracion);
                    command.Parameters.AddWithValue("@motivo", motivo);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                }
            }
            return table;
        }
    }
}
