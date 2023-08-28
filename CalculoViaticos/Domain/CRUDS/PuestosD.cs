using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain.CRUDS
{
    public class PuestosD
    {
        private PuestosDA puestos = new PuestosDA();

        public DataTable Mostrar(bool estado)
        {
            DataTable tabla = new DataTable();
            tabla = puestos.Mostrar(estado);
            return tabla;
        }

        public DataTable Insertar(string nombreCargo)
        {
            DataTable tabla = new DataTable();
            tabla = puestos.Insertar(nombreCargo);
            return tabla;
        }

        public DataTable Actualizar(int cargoID, string nombreCargo)
        {
            DataTable tabla = new DataTable();
            tabla = puestos.Actualizar(cargoID, nombreCargo);
            return tabla;
        }

        public DataTable Eliminar(int cargoID, string nombreCargo)
        {
            DataTable tabla = new DataTable();
            tabla = puestos.Eliminar(cargoID, nombreCargo);
            return tabla;
        }
    }
}
