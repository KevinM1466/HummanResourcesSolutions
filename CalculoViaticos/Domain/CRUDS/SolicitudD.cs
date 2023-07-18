using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS
{
    public class SolicitudD
    {
        private SolicitudDA solicitud = new SolicitudDA();

        public DataTable Mostrar(int jefeID)
        {
            DataTable tabla = new DataTable();
            tabla = solicitud.Mostrar(jefeID);
            return tabla;
        }
        public DataTable MostrarSoli(int jefeID)
        {
            DataTable tabla = new DataTable();
            tabla = solicitud.MostrarSoli(jefeID);
            return tabla;
        }
        
        public DataTable MostrarSoliEmpleado(int empleadoID)
        {
            DataTable tabla = new DataTable();
            tabla = solicitud.MostrarSoliEmpleado(empleadoID);
            return tabla;
        }

        public DataTable Insertar(string tipoSolicitud, int empleadoID, DateTime fechaEfectiva, DateTime fechaInicio, DateTime fechaFinal, DateTime fechaReingreso, bool isRemuneracion, string motivo)
        {
            DataTable tabla = new DataTable();
            tabla = solicitud.Insertar(tipoSolicitud, empleadoID, fechaEfectiva, fechaInicio, fechaFinal, fechaReingreso, isRemuneracion, motivo);
            return tabla;
        }

        public DataTable ActualizarRecursos(int solicitudID, string tipoSolicitud, int empleadoID, DateTime fechaEfectiva, DateTime fechaInicio, DateTime fechaFinal, DateTime fechaReingreso, bool isRemuneracion, string motivo)
        {
            DataTable tabla = new DataTable();
            tabla = solicitud.ActualizarRecursos(solicitudID, tipoSolicitud, empleadoID, fechaEfectiva, fechaInicio, fechaFinal, fechaReingreso, isRemuneracion, motivo);
            return tabla;
        }
        public DataTable ActualizarJefe(int solicitudID, string tipoSolicitud, int empleadoID, DateTime fechaEfectiva, DateTime fechaInicio, DateTime fechaFinal, DateTime fechaReingreso, bool isRemuneracion, string motivo)
        {
            DataTable tabla = new DataTable();
            tabla = solicitud.ActualizarJefe(solicitudID, tipoSolicitud, empleadoID, fechaEfectiva, fechaInicio, fechaFinal, fechaReingreso, isRemuneracion, motivo);
            return tabla;
        }
    }
}
