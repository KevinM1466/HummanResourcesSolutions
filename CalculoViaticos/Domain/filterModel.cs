using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataAccess.SqlServer;

using Guna.UI2.WinForms;

namespace Domain {
    public class filterModel {
        filtrosDao filtroDao = new filtrosDao();

        public void FiltrarGeneral( string departamento, string estado, string tipo, string nombre, string cargo, Guna2DataGridView dgDatos ) {
            filtroDao.FiltrarGeneral( departamento, estado, tipo, nombre, cargo, dgDatos );
        }
        public void FiltrarDepartamentos( string departamento, string estado, string tipo, Guna2DataGridView dgDatos ) {
            filtroDao.FiltrarDepartamentos( departamento, estado, tipo, dgDatos );
        }

        public void FiltrarEstado( string estado, string departamento, string tipo, Guna2DataGridView dgDatos ) {
            filtroDao.FiltrarEstado( estado, departamento, tipo, dgDatos );
        }

        public void FiltrarTipo( string tipo, string departamento, string estado, Guna2DataGridView dgDatos ) {
            filtroDao.FiltrarTipo( tipo, departamento, estado, dgDatos );
        }
    }
}
