using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer {
    public class SolicitudDao : ConnectionToSql {
        public DataTable getSolicitudes( DateTime fromDate, DateTime toDate ) {
            using ( var connection = GetConnection() ) {
                connection.Open();

                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "spReporteSolicitudesFecha";
                    command.Parameters.AddWithValue( "@fromDate", SqlDbType.Date ).Value = fromDate;
                    command.Parameters.AddWithValue( "@toDate", SqlDbType.Date ).Value = toDate;
                    command.Parameters.AddWithValue( "@accion", "SolicitudesFecha" );
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load( reader );
                    reader.Dispose();
                    return table;
                }
            }
        }

        public DataTable getSolicitudesDepartamentos( DateTime fromDate, DateTime toDate ) {
            using ( var connection = GetConnection() ) {
                connection.Open();

                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "spReporteSolicitudesFecha";
                    command.Parameters.AddWithValue( "@fromDate", SqlDbType.Date ).Value = fromDate;
                    command.Parameters.AddWithValue( "@toDate", SqlDbType.Date ).Value = toDate;
                    command.Parameters.AddWithValue( "@accion", "SolicitudesDepartamentos" );
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load( reader );
                    reader.Dispose();
                    return table;
                }
            }
        }
        public DataTable getTotalSolicitudes() {
            using ( var connection = GetConnection() ) {
                connection.Open();

                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "spReporteSolicitudesFecha";
                    command.Parameters.AddWithValue( "@fromDate", null );
                    command.Parameters.AddWithValue( "@toDate", null );
                    command.Parameters.AddWithValue( "@accion", "ReporteTotalSolicitudes" );
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load( reader );
                    reader.Dispose();
                    return table;
                }
            }
        }
    }
}
