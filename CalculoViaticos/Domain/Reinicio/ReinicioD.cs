using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.CRUDS;
using DataAccess.Reinicio;

namespace Domain.Reinicio {
    public class ReinicioD {
        private ReinicioDA reinicio = new ReinicioDA();

        public DataTable Mostrar() {
            DataTable tabla = new DataTable();
            tabla = reinicio.Reiniciar();
            return tabla;
        }
    }
}
