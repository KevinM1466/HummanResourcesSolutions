using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS
{
    public class EmpleadosD
    {
        private EmpleadosDA empleados = new EmpleadosDA();

        public DataTable Mostrar(bool isActive)
        {
            DataTable tabla = new DataTable();
            tabla = empleados.Mostrar(isActive);
            return tabla;
        }

        public DataTable Insertar(string nombres, string apellidos, DateTime fechaContrata, int cargoid, int departamentoID, byte[] imagen, DateTime fechaModi, bool isActive)
        {
            DataTable tabla = new DataTable();
            tabla = empleados.Insertar(nombres, apellidos, fechaContrata, cargoid, departamentoID, imagen, fechaModi, isActive);
            return tabla;
        }

        public DataTable Actualizar(int codigo, string nombres, string apellidos, int cargoid, int departamentoID, byte[] imagen, DateTime fechaModi, bool isActive)
        {
            DataTable tabla = new DataTable();
            tabla = empleados.Actualizar(codigo, nombres, apellidos, cargoid, departamentoID, imagen, fechaModi, isActive);
            return tabla;
        }

        public DataTable Eliminar(int codigo, int cargoid, int departamentoID, string nombres, string apellidos, DateTime fechaModi, bool isActive)
        {
            DataTable tabla = new DataTable();
            tabla = empleados.Eliminar(codigo, cargoid, departamentoID, nombres, apellidos, fechaModi, isActive);
            return tabla;
        }
    }
}
