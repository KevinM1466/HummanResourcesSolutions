using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DataAccess.SqlServer
{
    public class searchDao : ConnectionToSql
    {
        public SqlDataAdapter adaptador;
        public DataTable dt;

        public void buscarEmpleado(string nombre, string cargo, string departamento, bool estado, DataGridView dgDatos)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                // El simbolo de % se le llama comodín.
                try
                {
                    AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                    adaptador = new SqlDataAdapter(@"SELECT A.empleadoID AS Codigo, A.nombres, A.apellidos, B.cargoID, B.nombreCargo AS Puesto, C.departamentoID, C.nombreDepartamento, A.imagen, A.estado
                                                        FROM empleados a INNER JOIN puestos B
                                                        ON 
                                                        A.cargoID = B.cargoID INNER JOIN [dbo].[departamentos] C
                                                        ON A.departamentoID = C.departamentoID
                                                        WHERE A.estado = '" + estado + "' AND CONCAT_WS(' ', A.nombres, A.apellidos) LIKE '" + "%" + nombre + "%" + "' "
                                                        , connection);
                    dt = new DataTable();
                    adaptador.Fill(dt);
                    dgDatos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de servidor", "Carwash La Lima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void buscarDepartamento(bool estado, string departamento, DataGridView dgDatos)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                // El simbolo de % se le llama comodín.
                try
                {
                    adaptador = new SqlDataAdapter(@"SELECT departamentoID AS ID, nombreDepartamento AS Departamento, estado
		                                                FROM departamentos
                                                        WHERE nombreDepartamento LIKE '" + "%" + departamento + "%" + "' " +
                                                        "AND estado = '" + estado + "'"
                                                        , connection);
                    dt = new DataTable();
                    adaptador.Fill(dt);
                    dgDatos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de servidor", "Carwash La Lima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void buscarPuestos(bool estado, string cargo, DataGridView dgDatos)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                // El simbolo de % se le llama comodín.
                try
                {
                    adaptador = new SqlDataAdapter(@"SELECT departamentoID AS ID, nombreDepartamento AS Departamento, estado
		                                                FROM departamentos
                                                        WHERE nombreCargo LIKE '" + "%" + cargo + "%" + "' " +
                                                        "AND estado = '" + estado + "'"
                                                        , connection);
                    dt = new DataTable();
                    adaptador.Fill(dt);
                    dgDatos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de servidor", "Carwash La Lima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
