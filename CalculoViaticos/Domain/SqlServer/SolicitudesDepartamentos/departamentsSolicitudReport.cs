using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.SqlServer;

namespace Domain.SqlServer {
    public class departamentsSolicitudReport {
        public DateTime reportDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<DepartamentosListing> departamentosListing { get; set; }
        public double totalNetSolicitudes { get; set; }

        //Methods
        public void CreateSolicitudesDepartamentos( DateTime fromDate, DateTime toDate ) {
            //Implement Date
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;
            //Create Solicitudes Listing
            var solicitudDao = new SolicitudDao();
            var result = solicitudDao.getSolicitudesDepartamentos( fromDate, toDate );

            departamentosListing = new List<DepartamentosListing>();
            foreach ( System.Data.DataRow rows in result.Rows ) {
                var departamentosModel = new DepartamentosListing() {
                    departamentoID = Convert.ToInt32( rows[ 0 ] ),
                    nombreDepartamento = Convert.ToString( rows[ 1 ] ),
                    JefeDirecto = Convert.ToString( rows[ 2 ] ),
                    CantidadSolicitudes = Convert.ToInt32( rows[ 3 ] ),
                };
                departamentosListing.Add( departamentosModel );
                //Calculate total net Solicitudes
                totalNetSolicitudes += Convert.ToInt32( rows[ 3 ] );
            }
        }
    }
}
