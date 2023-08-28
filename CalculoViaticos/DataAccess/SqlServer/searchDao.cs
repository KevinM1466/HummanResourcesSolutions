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

        public SqlCommand comman;
        public SqlDataReader dr;

        public void buscarEmpleado(string nombre, string cargo, string departamento, bool estado, DataGridView dgDatos)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                // El simbolo de % se le llama comodín.
                try
                {
                    //AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                    adaptador = new SqlDataAdapter(@"SELECT A.empleadoID AS Codigo, A.nombres, A.apellidos, B.cargoID, B.nombreCargo AS Puesto, C.departamentoID, C.nombreDepartamento, A.imagen, A.estado
                                                        FROM empleados a INNER JOIN puestos B
                                                        ON 
                                                        A.cargoID = B.cargoID INNER JOIN [dbo].[departamentos] C
                                                        ON A.departamentoID = C.departamentoID
                                                        WHERE A.estado = '" + estado + "' AND CONCAT_WS(' ', A.nombres, A.apellidos) LIKE '" + "%" + nombre + "%" + "' AND C.nombreDepartamento <> 'Recursos Humanos' "
                                                        , connection);
                    dt = new DataTable();
                    adaptador.Fill(dt);
                    dgDatos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de servidor", "Tecnasa Honduras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //public void AutocompletarEmpleado(Guna2TextBox txtBuscar, Guna2TextBox txtID)
        //{
        //    using (var connection = GetConnection())
        //    {
        //        connection.Open();

        //        try
        //        {
        //            comman = new SqlCommand(@"SELECT empleadoID, CONCAT_WS(' ', nombres, apellidos)Empleado FROM empleados WHERE estado = 1"
        //                                        , connection);
        //            dr = comman.ExecuteReader();
        //            while (dr.Read()) {
        //                txtBuscar.AutoCompleteCustomSource.Add(dr["Empleado"].ToString());
        //            }
        //            dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

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
                                                        "AND estado = '" + estado + "' AND nombreDepartamento <> 'Recursos Humanos'"
                                                        , connection);
                    dt = new DataTable();
                    adaptador.Fill(dt);
                    dgDatos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de servidor", "Tecnasa Honduras", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    adaptador = new SqlDataAdapter( @"SELECT cargoID AS ID, nombreCargo AS Puesto, estado
		                                                FROM puestos
                                                        WHERE nombreCargo LIKE '" + "%" + cargo + "%" + "' " +
                                                        "AND estado = '" + estado + "' AND nombreCargo <> 'Administrador'"
                                                        , connection);
                    dt = new DataTable();
                    adaptador.Fill(dt);
                    dgDatos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de servidor", "Tecnasa Honduras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void buscarJefes( string empleado ,bool estado, DataGridView dgDatos ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                // El simbolo de % se le llama comodín.
                try {
                    adaptador = new SqlDataAdapter( @"SELECT a.jefeID as Codigo, b.empleadoID, CONCAT_WS(' ', b.nombres, b.apellidos) AS Empleado, c.departamentoID, c.nombreDepartamento AS Departamento, A.firma, A.nombreFirma
		                                                FROM jefes a inner join empleados b
		                                                on
		                                                a.empleadoID = b.empleadoID inner join departamentos c
		                                                on
		                                                a.departamentoID = c.departamentoID
		                                                WHERE CONCAT_WS(' ', B.nombres, b.apellidos) LIKE '" + "%" + empleado + "%" + "' " +
                                                        //"OR C.nombreDepartamento LIKE '" + "%" + departamento + "%" + "' " +
                                                        "AND a.estado = '" + estado + "' AND c.nombreDepartamento <> 'Recursos Humanos'", connection );
                    dt = new DataTable();
                    adaptador.Fill( dt );
                    dgDatos.DataSource = dt;
                } catch ( Exception ex ) {
                    MessageBox.Show( "Error de servidor", "Tecnasa Honduras", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        public void buscarUsuarios( string empleado, string correo, DataGridView dgDatos ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                // El simbolo de % se le llama comodín.
                try {
                    adaptador = new SqlDataAdapter( @"SELECT A.userID, B.empleadoID, CONCAT_WS(' ', B.nombres, B.apellidos)Empleado, A.correo, [dbo].[Desencriptar](A.contrasenia)Contrasenia
                                                    FROM [dbo].[users] A INNER JOIN [dbo].[empleados] B
                                                    ON
	                                                    A.empleadoID = B.empleadoID
                                                    WHERE CONCAT_WS(' ', B.nombres, B.apellidos) LIKE '" + "%" + empleado + "%" + "' OR " +
                                                    "A.correo LIKE '" + "%" + correo + "%" + "'", connection );
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
