using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DataAccess.SqlServer {
    public class filtrosDao : ConnectionToSql {
        public SqlDataAdapter adaptador;
        public DataTable dt;

        public SqlCommand comman;
        public SqlDataReader dr;

        public void FiltrarGeneral( string departamento, string estado, string tipo, string nombre, string cargo, Guna2DataGridView dgDatos ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                // El simbolo de % se le llama comodín.
                try {
                    //AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                    adaptador = new SqlDataAdapter( @"SELECT CONCAT_WS(' ', B.nombres, B.apellidos)Empleado, C.nombreCargo AS Cargo, D.nombreDepartamento AS Departamento, A.tipoSolicitud AS [Tipo de Solicitud], A.fechaInicio AS [Fecha de Inicio], A.fechaFinal AS [Fecha Final], A.remuneracion AS Remuneracion, A.motivo AS Motivo
                                                        FROM [dbo].[solicitudes] A INNER JOIN [dbo].[empleados] B
                                                        ON
                                                        A.empleadoID = B.empleadoID INNER JOIN [dbo].[puestos] C
                                                        ON B.cargoID = C.cargoID INNER JOIN [dbo].[departamentos] D
                                                        ON B.departamentoID = D.departamentoID INNER JOIN [dbo].[jefes] E
                                                        ON D.departamentoID = E.departamentoID INNER JOIN [dbo].[empleados] F
                                                        ON F.empleadoID = E.empleadoID LEFT JOIN [dbo].[users] G
                                                        ON F.empleadoID = G.empleadoID
                                                        WHERE D.nombreDepartamento LIKE '" + "%" + departamento + "%" + "' OR " +
                                                        "A.estado LIKE '" + "%" + estado + "%" + "' OR " +
                                                        "A.tipoSolicitud LIKE '" + "%" + tipo + "%" + "' OR " +
                                                        "CONCAT_WS(' ', B.nombres, B.apellidos) LIKE '" + "%" + nombre + "%" + "' OR " +
                                                        "C.nombreCargo LIKE '" + "%" + cargo + "%" + "'", connection );
                    dt = new DataTable();
                    adaptador.Fill( dt );
                    dgDatos.DataSource = dt;
                } catch ( Exception ex ) {
                    MessageBox.Show( "Error de servidor", "Tecnasa Honduras", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        public void FiltrarDepartamentos( string departamento, string estado, string tipo, Guna2DataGridView dgDatos ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                // El simbolo de % se le llama comodín.
                try {
                    //AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                    adaptador = new SqlDataAdapter( @"SELECT CONCAT_WS(' ', B.nombres, B.apellidos)Empleado, C.nombreCargo AS Cargo, D.nombreDepartamento AS Departamento, A.tipoSolicitud AS [Tipo de Solicitud], A.fechaInicio AS [Fecha de Inicio], A.fechaFinal AS [Fecha Final], A.remuneracion AS Remuneracion, A.motivo AS Motivo
                                                        FROM [dbo].[solicitudes] A INNER JOIN [dbo].[empleados] B
                                                        ON
                                                        A.empleadoID = B.empleadoID INNER JOIN [dbo].[puestos] C
                                                        ON B.cargoID = C.cargoID INNER JOIN [dbo].[departamentos] D
                                                        ON B.departamentoID = D.departamentoID INNER JOIN [dbo].[jefes] E
                                                        ON D.departamentoID = E.departamentoID INNER JOIN [dbo].[empleados] F
                                                        ON F.empleadoID = E.empleadoID LEFT JOIN [dbo].[users] G
                                                        ON F.empleadoID = G.empleadoID
                                                        WHERE D.nombreDepartamento LIKE '" + "%" + departamento + "%" + "' AND " +
                                                        "A.estado LIKE '" + "%" + estado + "%" + "' AND " +
                                                        "A.tipoSolicitud LIKE '" + "%" + tipo + "%" + "'", connection );
                    dt = new DataTable();
                    adaptador.Fill( dt );
                    dgDatos.DataSource = dt;
                } catch ( Exception ex ) {
                    MessageBox.Show( "Error de servidor", "Tecnasa Honduras", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        public void FiltrarEstado( string estado, string departamento, string tipo, Guna2DataGridView dgDatos ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                // El simbolo de % se le llama comodín.
                try {
                    //AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                    adaptador = new SqlDataAdapter( @"SELECT CONCAT_WS(' ', B.nombres, B.apellidos)Empleado, C.nombreCargo AS Cargo, D.nombreDepartamento AS Departamento, A.tipoSolicitud AS [Tipo de Solicitud], A.fechaInicio AS [Fecha de Inicio], A.fechaFinal AS [Fecha Final], A.remuneracion AS Remuneracion, A.motivo AS Motivo
                                                        FROM [dbo].[solicitudes] A INNER JOIN [dbo].[empleados] B
                                                        ON
                                                        A.empleadoID = B.empleadoID INNER JOIN [dbo].[puestos] C
                                                        ON B.cargoID = C.cargoID INNER JOIN [dbo].[departamentos] D
                                                        ON B.departamentoID = D.departamentoID INNER JOIN [dbo].[jefes] E
                                                        ON D.departamentoID = E.departamentoID INNER JOIN [dbo].[empleados] F
                                                        ON F.empleadoID = E.empleadoID LEFT JOIN [dbo].[users] G
                                                        ON F.empleadoID = G.empleadoID
                                                        WHERE A.estado LIKE '" + "%" + estado + "%" + "' AND " +
                                                        "D.nombreDepartamento LIKE '" + "%" + departamento + "%" + "' AND " +
                                                        "A.tipoSolicitud LIKE '" + "%" + tipo + "%" + "'", connection );
                    dt = new DataTable();
                    adaptador.Fill( dt );
                    dgDatos.DataSource = dt;
                } catch ( Exception ex ) {
                    MessageBox.Show( "Error de servidor", "Tecnasa Honduras", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        public void FiltrarTipo( string tipo, string departamento, string estado, Guna2DataGridView dgDatos ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                // El simbolo de % se le llama comodín.
                try {
                    //AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                    adaptador = new SqlDataAdapter( @"SELECT CONCAT_WS(' ', B.nombres, B.apellidos)Empleado, C.nombreCargo AS Cargo, D.nombreDepartamento AS Departamento, A.tipoSolicitud AS [Tipo de Solicitud], A.fechaInicio AS [Fecha de Inicio], A.fechaFinal AS [Fecha Final], A.remuneracion AS Remuneracion, A.motivo AS Motivo
                                                        FROM [dbo].[solicitudes] A INNER JOIN [dbo].[empleados] B
                                                        ON
                                                        A.empleadoID = B.empleadoID INNER JOIN [dbo].[puestos] C
                                                        ON B.cargoID = C.cargoID INNER JOIN [dbo].[departamentos] D
                                                        ON B.departamentoID = D.departamentoID INNER JOIN [dbo].[jefes] E
                                                        ON D.departamentoID = E.departamentoID INNER JOIN [dbo].[empleados] F
                                                        ON F.empleadoID = E.empleadoID LEFT JOIN [dbo].[users] G
                                                        ON F.empleadoID = G.empleadoID
                                                        WHERE A.tipoSolicitud LIKE '" + "%" + tipo + "%" + "' AND " +
                                                        "D.nombreDepartamento LIKE '" + "%" + departamento + "%" + "' AND " +
                                                        "A.estado LIKE '" + "%" + estado + "%" + "'", connection );
                    dt = new DataTable();
                    adaptador.Fill( dt );
                    dgDatos.DataSource = dt;
                } catch ( Exception ex ) {
                    MessageBox.Show( "Error de servidor", "Tecnasa Honduras", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }
    }
}
