using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Domain.ComboBox_D;
using Domain.CRUDS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Clases
{
    public class MetodosListados
    {
        public void MostrarCargos(DataGridView dgDatos)
        {
            PuestosD objeto = new PuestosD();
            dgDatos.DataSource = objeto.Mostrar();
            dgDatos.Columns[0].Visible = false;
            dgDatos.Columns[2].Visible = false;
        }

        public void MostrarClientes(DataGridView dgClientes)
        {
            ClientesD clientesD = new ClientesD();
            dgClientes.DataSource = clientesD.Mostrar();
        }

        public void MostrarEmpleados(DataGridView dgEmpleados, bool isActive)
        {
            EmpleadosD empleadosD = new EmpleadosD();
            dgEmpleados.DataSource = empleadosD.Mostrar(isActive);
            dgEmpleados.Columns[3].Visible = false;
            dgEmpleados.Columns[5].Visible = false;
            dgEmpleados.Columns[7].Visible = false;
            dgEmpleados.Columns[8].Visible = false;
        }

        public void MostrarDepartamentos(DataGridView dgDatos, bool isEnable)
        {
            DepartamentosD objeto = new DepartamentosD();
            dgDatos.DataSource = objeto.Mostrar(isEnable);
            dgDatos.Columns[0].Visible = false;
            dgDatos.Columns[2].Visible = false;
        }

        public void MostrarJefes(DataGridView dgDatos)
        {
            JefesD objeto = new JefesD();
            dgDatos.DataSource = objeto.Mostrar();
            dgDatos.Columns[1].Visible = false;
            dgDatos.Columns[3].Visible = false;
            dgDatos.Columns[5].Visible = false;
            dgDatos.Columns[6].Visible = false;
        }

        public void MostrarSolicitud(DataGridView dgDatos, int jefeID)
        {
            SolicitudD objeto = new SolicitudD();
            dgDatos.DataSource = objeto.Mostrar(jefeID);
            dgDatos.Columns[0].Visible = false;
            dgDatos.Columns[1].Visible = false;
            dgDatos.Columns[12].Visible = false;
            dgDatos.Columns[13].Visible = false;
            dgDatos.Columns[14].Visible = false;
        }

        public void MostrarSolicitudJefe(DataGridView dgDatos, int jefeID)
        {
            SolicitudD objeto = new SolicitudD();
            dgDatos.DataSource = objeto.MostrarSoli(jefeID);
            dgDatos.Columns[0].Visible = false;
            dgDatos.Columns[1].Visible = false;
            dgDatos.Columns[12].Visible = false;
            dgDatos.Columns[13].Visible = false;
            dgDatos.Columns[14].Visible = false;
        }
        
        public void MostrarSolicitudEmpleado(DataGridView dgDatos, int empleadoID)
        {
            SolicitudD objeto = new SolicitudD();
            dgDatos.DataSource = objeto.MostrarSoliEmpleado(empleadoID);
            dgDatos.Columns[0].Visible = false;
            dgDatos.Columns[1].Visible = false;
            dgDatos.Columns[12].Visible = false;
            dgDatos.Columns[13].Visible = false;
            dgDatos.Columns[14].Visible = false;
        }

        public void ListarPuestos(ComboBox cmbPuesto)
        {
            ComboBox_D objeto = new ComboBox_D();
            cmbPuesto.DataSource = objeto.ListarPuestos();
            cmbPuesto.DisplayMember = "nombreCargo";
            cmbPuesto.ValueMember = "cargoID";
        }

        public void ListarEmpleados(ComboBox cmbDatos)
        {
            ComboBox_D objeto = new ComboBox_D();
            cmbDatos.DataSource = objeto.ListarEmpleados();
            cmbDatos.DisplayMember = "Empleado";
            cmbDatos.ValueMember = "empleadoID";
        }

        public void ListarDepartamentos(ComboBox cmbDatos)
        {
            ComboBox_D objeto = new ComboBox_D();
            cmbDatos.DataSource = objeto.ListarDepartamentos();
            cmbDatos.DisplayMember = "nombreDepartamento";
            cmbDatos.ValueMember = "departamentoID";
        }
    }
}
