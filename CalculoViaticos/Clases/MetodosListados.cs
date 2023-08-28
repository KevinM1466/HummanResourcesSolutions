using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Domain;
using Domain.ComboBox_D;
using Domain.CRUDS;
using Domain.SqlServer;

using Guna.UI2.WinForms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using ComboBox = System.Windows.Forms.ComboBox;

namespace Clases {
    public class MetodosListados {
        Font prFont = new Font( "Poppins", 12, FontStyle.Bold );
        public void MostrarCargos( DataGridView dgDatos, bool estado ) {
            PuestosD objeto = new PuestosD();
            dgDatos.DataSource = objeto.Mostrar(estado);
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 2 ].Visible = false;

            dgDatos.Columns[ 1 ].HeaderText = "Cargo";

            dgDatos.Columns[ 1 ].HeaderCell.Style.Font = prFont;
        }

        public void MostrarEmpleados( DataGridView dgEmpleados, bool isActive ) {
            EmpleadosD empleadosD = new EmpleadosD();
            dgEmpleados.DataSource = empleadosD.Mostrar( isActive );
            dgEmpleados.Columns[ 0 ].Visible = false;
            dgEmpleados.Columns[ 3 ].Visible = false;
            dgEmpleados.Columns[ 5 ].Visible = false;
            dgEmpleados.Columns[ 7 ].Visible = false;
            dgEmpleados.Columns[ 8 ].Visible = false;

            dgEmpleados.Columns[ 1 ].HeaderText = "Nombres";
            dgEmpleados.Columns[ 2 ].HeaderText = "Apellidos";
            dgEmpleados.Columns[ 4 ].HeaderText = "Cargo";
            dgEmpleados.Columns[ 6 ].HeaderText = "Departamento";

            dgEmpleados.Columns[ 1 ].HeaderCell.Style.Font = prFont;
            dgEmpleados.Columns[ 2 ].HeaderCell.Style.Font = prFont;
            dgEmpleados.Columns[ 4 ].HeaderCell.Style.Font = prFont;
            dgEmpleados.Columns[ 6 ].HeaderCell.Style.Font = prFont;
        }

        public void MostrarDepartamentos( DataGridView dgDatos, bool isEnable ) {
            DepartamentosD objeto = new DepartamentosD();
            dgDatos.DataSource = objeto.Mostrar( isEnable );
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 2 ].Visible = false;

            dgDatos.Columns[ 1 ].HeaderCell.Style.Font = prFont;
        }

        public void MostrarJefes( DataGridView dgDatos, bool isEnable ) {
            JefesD objeto = new JefesD();
            dgDatos.DataSource = objeto.Mostrar(isEnable );
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 1 ].Visible = false;
            dgDatos.Columns[ 3 ].Visible = false;
            dgDatos.Columns[ 5 ].Visible = false;
            dgDatos.Columns[ 6 ].Visible = false;
            dgDatos.Columns[ 7 ].Visible = false;

            dgDatos.Columns[ 2 ].HeaderText = "Empleado";
            dgDatos.Columns[ 4 ].HeaderText = "Departamento";

            dgDatos.Columns[ 2 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 4 ].HeaderCell.Style.Font = prFont;
        }

        public void MostrarUsuarios( DataGridView dgDatos ) {
            UsuariosD objeto = new UsuariosD();
            dgDatos.DataSource = objeto.Mostrar();
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 1 ].Visible = false;
            dgDatos.Columns[ 4 ].Visible = false;

            //dgDatos.Columns[2].HeaderText = "Empleado";
            //dgDatos.Columns[4].HeaderText = "Departamento";

            //dgDatos.Columns[2].HeaderCell.Style.Font = prFont;
            //dgDatos.Columns[4].HeaderCell.Style.Font = prFont;
        }

        public void MostrarSolicitud( DataGridView dgDatos, int jefeID ) {
            SolicitudD objeto = new SolicitudD();
            dgDatos.DataSource = objeto.Mostrar( jefeID );
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 1 ].Visible = false;
            dgDatos.Columns[ 12 ].Visible = false;
            dgDatos.Columns[ 13 ].Visible = false;
            dgDatos.Columns[ 14 ].Visible = false;
            dgDatos.Columns[ 15 ].Visible = false;
            dgDatos.Columns[ 16 ].Visible = false;

            dgDatos.Columns[ 3 ].HeaderText = "Cargo";
            dgDatos.Columns[ 4 ].HeaderText = "Departamento";
            dgDatos.Columns[ 5 ].HeaderText = "Tipo de Solicitud";
            dgDatos.Columns[ 6 ].HeaderText = "Fecha Efectiva";
            dgDatos.Columns[ 7 ].HeaderText = "Fecha de Inicio";
            dgDatos.Columns[ 8 ].HeaderText = "Fecha Final";
            dgDatos.Columns[ 9 ].HeaderText = "Fecha de Regreso";
            dgDatos.Columns[ 10 ].HeaderText = "Remuneración";
            dgDatos.Columns[ 11 ].HeaderText = "Motivo";

            dgDatos.Columns[ 2 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 3 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 4 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 5 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 6 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 7 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 8 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 9 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 10 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 11 ].HeaderCell.Style.Font = prFont;
        }

        public void MostrarSolicitudJefe( DataGridView dgDatos, int jefeID ) {
            SolicitudD objeto = new SolicitudD();
            dgDatos.DataSource = objeto.MostrarSoli( jefeID );
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 1 ].Visible = false;
            dgDatos.Columns[ 12 ].Visible = false;
            dgDatos.Columns[ 13 ].Visible = false;
            dgDatos.Columns[ 14 ].Visible = false;
            dgDatos.Columns[ 15 ].Visible = false;
            dgDatos.Columns[ 16 ].Visible = false;

            dgDatos.Columns[ 3 ].HeaderText = "Cargo";
            dgDatos.Columns[ 4 ].HeaderText = "Departamento";
            dgDatos.Columns[ 5 ].HeaderText = "Tipo de Solicitud";
            dgDatos.Columns[ 6 ].HeaderText = "Fecha Efectiva";
            dgDatos.Columns[ 7 ].HeaderText = "Fecha de Inicio";
            dgDatos.Columns[ 8 ].HeaderText = "Fecha Final";
            dgDatos.Columns[ 9 ].HeaderText = "Fecha de Regreso";
            dgDatos.Columns[ 10 ].HeaderText = "Remuneración";
            dgDatos.Columns[ 11 ].HeaderText = "Motivo";

            dgDatos.Columns[ 2 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 3 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 4 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 5 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 6 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 7 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 8 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 9 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 10 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 11 ].HeaderCell.Style.Font = prFont;
        }

        public void MostrarSolicitudEmpleado( DataGridView dgDatos, int empleadoID ) {
            SolicitudD objeto = new SolicitudD();
            dgDatos.DataSource = objeto.MostrarSoliEmpleado( empleadoID );
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 1 ].Visible = false;
            dgDatos.Columns[ 12 ].Visible = false;
            dgDatos.Columns[ 13 ].Visible = false;
            dgDatos.Columns[ 14 ].Visible = false;
            dgDatos.Columns[ 15 ].Visible = false;

            dgDatos.Columns[ 3 ].HeaderText = "Cargo";
            dgDatos.Columns[ 4 ].HeaderText = "Departamento";
            dgDatos.Columns[ 5 ].HeaderText = "Tipo de Solicitud";
            dgDatos.Columns[ 6 ].HeaderText = "Fecha Efectiva";
            dgDatos.Columns[ 7 ].HeaderText = "Fecha de Inicio";
            dgDatos.Columns[ 8 ].HeaderText = "Fecha Final";
            dgDatos.Columns[ 9 ].HeaderText = "Fecha de Regreso";
            dgDatos.Columns[ 10 ].HeaderText = "Remuneración";
            dgDatos.Columns[ 11 ].HeaderText = "Motivo";

            dgDatos.Columns[ 2 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 3 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 4 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 5 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 6 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 7 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 8 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 9 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 10 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 11 ].HeaderCell.Style.Font = prFont;
        }

        public void MostrarTotalSolicitudes( DataGridView dgDatos ) {
            TotalSolicitudes objeto = new TotalSolicitudes();
            dgDatos.DataSource = objeto.Mostrar();
            //dgDatos.Columns[ 0 ].Visible = false;
            //dgDatos.Columns[ 1 ].Visible = false;
            //dgDatos.Columns[ 6 ].Visible = false;
            //dgDatos.Columns[ 9 ].Visible = false;
            //dgDatos.Columns[ 12 ].Visible = false;
            //dgDatos.Columns[ 13 ].Visible = false;
            //dgDatos.Columns[ 14 ].Visible = false;
            //dgDatos.Columns[ 15 ].Visible = false;

            dgDatos.Columns[ 0 ].HeaderText = "Empleado";
            dgDatos.Columns[ 1 ].HeaderText = "Cargo";
            dgDatos.Columns[ 2 ].HeaderText = "Departamento";
            dgDatos.Columns[ 3 ].HeaderText = "Tipo de Solicitud";
            dgDatos.Columns[ 4 ].HeaderText = "Fecha de Inicio";
            dgDatos.Columns[ 5 ].HeaderText = "Fecha Final";
            dgDatos.Columns[ 6 ].HeaderText = "Remuneración";
            dgDatos.Columns[ 7 ].HeaderText = "Motivo";

            dgDatos.Columns[ 0 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 1 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 2 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 3 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 4 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 5 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 6 ].HeaderCell.Style.Font = prFont;
            dgDatos.Columns[ 7 ].HeaderCell.Style.Font = prFont;
        }

        public void ListarPuestos( ComboBox cmbPuesto ) {
            ComboBox_D objeto = new ComboBox_D();
            cmbPuesto.DataSource = objeto.ListarPuestos();
            cmbPuesto.DisplayMember = "nombreCargo";
            cmbPuesto.ValueMember = "cargoID";
        }

        public void ListarEmpleados( ComboBox cmbDatos ) {
            ComboBox_D objeto = new ComboBox_D();
            cmbDatos.DataSource = objeto.ListarEmpleados();
            cmbDatos.DisplayMember = "Empleado";
            cmbDatos.ValueMember = "empleadoID";
        }

        public void ListarDepartamentos( Guna2ComboBox cmbDatos ) {
            ComboBox_D objeto = new ComboBox_D();
            cmbDatos.DataSource = objeto.ListarDepartamentos();
            cmbDatos.DisplayMember = "nombreDepartamento";
            cmbDatos.ValueMember = "departamentoID";
        }

        //Audits
        public void AuditDepartamentos( DataGridView dgDatos ) {
            AuditTrailsD objeto = new AuditTrailsD();
            dgDatos.DataSource = objeto.AuditDepartamentos();
        }
        
        public void AuditEmpleados( DataGridView dgDatos ) {
            AuditTrailsD objeto = new AuditTrailsD();
            dgDatos.DataSource = objeto.AuditEmpleados();
        }

        public void AuditJefes( DataGridView dgDatos ) {
            AuditTrailsD objeto = new AuditTrailsD();
            dgDatos.DataSource = objeto.AuditJefes();
        }

        public void AuditPuestos( DataGridView dgDatos ) {
            AuditTrailsD objeto = new AuditTrailsD();
            dgDatos.DataSource = objeto.AuditPuestos();
        }

        public void AuditUsuarios( DataGridView dgDatos ) {
            AuditTrailsD objeto = new AuditTrailsD();
            dgDatos.DataSource = objeto.AuditUsuarios();
        }
    }
}
