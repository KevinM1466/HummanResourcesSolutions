using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SqlServer {
    public class DepartamentosListing {
        public int departamentoID { get; set; }
        public string nombreDepartamento { get; set; }
        public string JefeDirecto { get; set; }
        public int CantidadSolicitudes { get; set; }
    }
}
