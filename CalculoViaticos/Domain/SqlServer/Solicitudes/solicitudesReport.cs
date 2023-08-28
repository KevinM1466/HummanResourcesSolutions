using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.SqlServer;

namespace Domain.SqlServer {
    public class solicitudesReport {
        public DateTime reportDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<SolicitudesListing> solicitudesListings { get; set; }
        public List<NetSolicitudesByPeriod> netSolicitudesByPeriods { get; set; }
        public double totalNetSolicitudes { get; set; }

        //Methods
        public void CreateSolicitudesReport( DateTime fromDate, DateTime toDate ) {
            //Implement Date
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;
            //Create Solicitudes Listing
            var solicitudDao = new SolicitudDao();
            var result = solicitudDao.getSolicitudes( fromDate, toDate );

            solicitudesListings = new List<SolicitudesListing>();
            foreach ( System.Data.DataRow rows in result.Rows ) {
                var solicitudesModel = new SolicitudesListing() {
                    empleadoID = Convert.ToInt32( rows[ 0 ] ),
                    Empleado = Convert.ToString( rows[ 1 ] ),
                    Cargo = Convert.ToString( rows[ 2 ] ),
                    FechaSolicitud = Convert.ToDateTime( rows[ 3 ] ),
                    AniosLaborando = Convert.ToInt32( rows[ 4 ] ),
                    CantidadSolicitudes = Convert.ToInt32( rows[ 5 ] ),
                };
                solicitudesListings.Add( solicitudesModel );
                //Calculate total net Solicitudes
                totalNetSolicitudes += Convert.ToInt32( rows[ 5 ] );
            }
            //group period by days
            ///create temp list net solicitudes by date
            var listSolicitudesByDate = ( from solicitudes in solicitudesListings
                                          group solicitudes by solicitudes.FechaSolicitud
                                         into listSolicitudes
                                          select new {
                                              date = listSolicitudes.Key,
                                              amount = listSolicitudes.Sum( item => item.CantidadSolicitudes )
                                          } ).AsEnumerable();
            ///get number of date
            int totalDays = Convert.ToInt32((toDate - fromDate).Days);

            //group period by days
            if ( totalDays <= 7 ) {
                netSolicitudesByPeriods = (from solicitudes in listSolicitudesByDate
                                           group solicitudes by solicitudes.date.ToString("dd-MMM-yyyy")
                                           into listSolicitudes
                                           select new NetSolicitudesByPeriod {
                                               period = listSolicitudes.Key,
                                               netSolicitudes = listSolicitudes.Sum(item => item.amount)
                                           } ).ToList();
            }
            //group period by week
            else if ( totalDays <= 30 ) {
                netSolicitudesByPeriods = ( from solicitudes in listSolicitudesByDate
                                            group solicitudes by
                                            System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                    solicitudes.date,
                                                    System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday
                                                )
                                           into listSolicitudes
                                            select new NetSolicitudesByPeriod {
                                                period = "Semana " + listSolicitudes.Key.ToString(),
                                                netSolicitudes = listSolicitudes.Sum( item => item.amount )
                                            } ).ToList();
            }
            //group period by month
            else if ( totalDays <= 365 ) {
                netSolicitudesByPeriods = ( from solicitudes in listSolicitudesByDate
                                            group solicitudes by solicitudes.date.ToString( "MMM-yyyy" )
                                           into listSolicitudes
                                            select new NetSolicitudesByPeriod {
                                                period = listSolicitudes.Key,
                                                netSolicitudes = listSolicitudes.Sum( item => item.amount )
                                            } ).ToList();
            }//group period by month
            else {
                netSolicitudesByPeriods = ( from solicitudes in listSolicitudesByDate
                                            group solicitudes by solicitudes.date.ToString( "yyyy" )
                                           into listSolicitudes
                                            select new NetSolicitudesByPeriod {
                                                period = listSolicitudes.Key,
                                                netSolicitudes = listSolicitudes.Sum( item => item.amount )
                                            } ).ToList();
            }
        }
    }
}
