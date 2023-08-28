using DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Domain
{
    public class searchModel
    {
        searchDao searchDao = new searchDao();

        public void buscarEmpleado(string nombre, string cargo, string departamento, bool estado, DataGridView dgDatos)
        {
            searchDao.buscarEmpleado(nombre, cargo, departamento, estado, dgDatos);
        }

        //public void AutocompletarEmpleado(Guna2TextBox txtBuscar, Guna2TextBox txtID)
        //{
        //    filtroDao.AutocompletarEmpleado(txtBuscar, txtID);
        //}

        public void buscarDepartamento(bool estado, string departamento, DataGridView dgDatos)
        {
            searchDao.buscarDepartamento(estado, departamento, dgDatos);
        }

        public void buscarJefes( string empleado, bool estado, DataGridView dgDatos ) {
            searchDao.buscarJefes( empleado, estado, dgDatos );
        }

        public void buscarPuestos( bool estado, string cargo, DataGridView dgDatos ) {
            searchDao.buscarPuestos( estado, cargo, dgDatos );
        }

        public void buscarUsuarios( string cargo, string correo, DataGridView dgDatos ) {
            searchDao.buscarUsuarios( cargo, correo, dgDatos );
        }
    }
}
