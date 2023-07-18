using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS
{
    public class ReporteSolicitudD
    {
        private ReporteSolicitudDA reporte = new ReporteSolicitudDA();

        public DataTable Mostrar(int solicitudID, string tipoSolicitud, int empleadoID, string empleado, DateTime fechaEfectiva, DateTime fechaInicio, DateTime fechaFinal, DateTime fechaReingreso, bool remuneracion, string motivo)
        {
            DataTable tabla = new DataTable();
            tabla = reporte.Mostrar(solicitudID, tipoSolicitud, empleadoID, empleado, fechaEfectiva, fechaInicio, fechaFinal, fechaReingreso, remuneracion, motivo);
            return tabla;
        }
    }
}
