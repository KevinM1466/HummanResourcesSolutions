using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoViaticos.Reportes.Datos
{
    public class DatosSolicitud : DatosEmpresa
    {
        public int solicitudID { get; set; }
        public int empleadoID { get; set; }
        public string Empleado { get; set; }
        public string nombreCargo { get; set; }
        public string nombreDepartamento { get; set; }
        public string tipoSolicitud { get; set; }
        public string fechaEfectiva { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }
        public string fechaReingreso { get; set; }
        public bool Remuneracion { get; set; }
        public string Motivo { get; set; }
        public string JefeDirecto { get; set; }
        public string CorreoJefe { get; set; }
        public byte[] firma { get; set; }
        public byte[] firmaJefe { get; set; }
        public bool isTrue { get; set; }
    }
}
