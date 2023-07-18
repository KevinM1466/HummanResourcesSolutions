using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS
{
    public class DepartamentosD
    {
        private DepartamentosDA departamento = new DepartamentosDA();

        public DataTable Mostrar(bool isEnable)
        {
            DataTable tabla = new DataTable();
            tabla = departamento.Mostrar(isEnable);
            return tabla;
        }

        public DataTable Insertar(string nombreDepartamento)
        {
            DataTable tabla = new DataTable();
            tabla = departamento.Insertar(nombreDepartamento);
            return tabla;
        }

        public DataTable Actualizar(int codigo, string nombreDepartamento, bool isEnable)
        {
            DataTable tabla = new DataTable();
            tabla = departamento.Actualizar(codigo, nombreDepartamento, isEnable);
            return tabla;
        }

        public DataTable Eliminar(int codigo, string nombreDepartamento)
        {
            DataTable tabla = new DataTable();
            tabla = departamento.Eliminar(codigo, nombreDepartamento);
            return tabla;
        }
    }
}
