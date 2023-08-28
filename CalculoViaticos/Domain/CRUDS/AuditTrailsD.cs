using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.CRUDS;

namespace Domain.CRUDS {
    public class AuditTrailsD {
        private AuditTrailsDA audit = new AuditTrailsDA();

        public DataTable AuditDepartamentos() {
            DataTable tabla = new DataTable();
            tabla = audit.AuditDepartamentos();
            return tabla;
        }
        
        public DataTable AuditEmpleados() {
            DataTable tabla = new DataTable();
            tabla = audit.AuditEmpleados();
            return tabla;
        }

        public DataTable AuditJefes() {
            DataTable tabla = new DataTable();
            tabla = audit.AuditJefes();
            return tabla;
        }

        public DataTable AuditPuestos() {
            DataTable tabla = new DataTable();
            tabla = audit.AuditPuestos();
            return tabla;
        }

        public DataTable AuditUsuarios() {
            DataTable tabla = new DataTable();
            tabla = audit.AuditUsuarios();
            return tabla;
        }
    }
}
