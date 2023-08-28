using System;

namespace Domain.SqlServer {
    public class SolicitudesListing {
        public int empleadoID {  get; set; }
        public string Empleado { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int AniosLaborando { get; set; }
        public int CantidadSolicitudes { get; set; }
    }
}