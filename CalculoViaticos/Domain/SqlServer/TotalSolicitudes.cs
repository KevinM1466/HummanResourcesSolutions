using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.CRUDS;
using DataAccess.SqlServer;

namespace Domain.SqlServer {
    public class TotalSolicitudes {
        private SolicitudDao solicitudes = new SolicitudDao();

        public DataTable Mostrar() {
            DataTable tabla = new DataTable();
            tabla = solicitudes.getTotalSolicitudes();
            return tabla;
        }
    }
}
