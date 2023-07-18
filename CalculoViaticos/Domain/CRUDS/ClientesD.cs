using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS
{
    public class ClientesD
    {
        private ClientesDA clientes = new ClientesDA();

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = clientes.Mostrar();
            return tabla;
        }

        public DataTable Insertar(string nombres, string identidad, bool isActive)
        {
            DataTable tabla = new DataTable();
            tabla = clientes.Insertar(nombres, identidad, isActive);
            return tabla;
        }

        public DataTable Actualizar(int id, string nombres, string identidad, bool isActive)
        {
            DataTable tabla = new DataTable();
            tabla = clientes.Actualizar(id, nombres, identidad, isActive);
            return tabla;
        }

        public DataTable Eliminar(int id, string nombres, string identidad, bool isActive)
        {
            DataTable tabla = new DataTable();
            tabla = clientes.Eliminar(id, nombres, identidad, isActive);
            return tabla;
        }
    }
}
