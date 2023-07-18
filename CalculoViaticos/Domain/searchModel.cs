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
        
        public void buscarDepartamento(bool estado, string departamento, DataGridView dgDatos)
        {
            searchDao.buscarDepartamento(estado, departamento, dgDatos);
        }
    }
}
