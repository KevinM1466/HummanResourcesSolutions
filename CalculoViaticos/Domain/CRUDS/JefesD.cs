using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS
{
    public class JefesD
    {
        private JefesDA jefes = new JefesDA();

        public DataTable Mostrar(bool isEnable)
        {
            DataTable tabla = new DataTable();
            tabla = jefes.Mostrar(isEnable);
            return tabla;
        }

        public DataTable Insertar(int empleadoID, int departamentoID, byte[] firma, string nombreFirma)
        {
            DataTable tabla = new DataTable();
            tabla = jefes.Insertar(empleadoID, departamentoID, firma, nombreFirma);
            return tabla;
        }

        public DataTable Actualizar(int codigo, int empleadoID, int departamentoID, byte[] firma, string nombreFirma)
        {
            DataTable tabla = new DataTable();
            tabla = jefes.Actualizar(codigo, empleadoID, departamentoID, firma, nombreFirma);
            return tabla;
        }

        public DataTable Eliminar(int codigo, int empleadoID, int departamentoID, byte[] firma, string nombreFirma)
        {
            DataTable tabla = new DataTable();
            tabla = jefes.Eliminar(codigo, empleadoID, departamentoID, firma, nombreFirma);
            return tabla;
        }
    }
}
