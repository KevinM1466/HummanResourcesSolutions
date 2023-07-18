using DataAccess.ComboBoxDA;
using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ComboBox_D
{
    public class ComboBox_D
    {
        private ComboBox_DA objetoCD = new ComboBox_DA();

        public DataTable ListarPuestos()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarPuestos();
            return tabla;
        }

        public DataTable ListarDepartamentos()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarDepartamentos();
            return tabla;
        }

        public DataTable ListarEmpleados()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarEmpleados();
            return tabla;
        }
    }
}
