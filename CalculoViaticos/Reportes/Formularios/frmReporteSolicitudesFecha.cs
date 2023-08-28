using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Domain.SqlServer;

namespace CalculoViaticos.Reportes.Formularios
{
    public partial class frmReporteSolicitudesFecha : Form
    {
        public frmReporteSolicitudesFecha()
        {
            InitializeComponent();
        }

        private void frmReporteSolicitudesFecha_Load( object sender, EventArgs e ) {

            
        }

        private void getSolicitudesReport(DateTime fromDate, DateTime toDate ) {
            solicitudesReport reportModel = new solicitudesReport();
            reportModel.CreateSolicitudesReport(fromDate, toDate);

            solicitudesReportBindingSource.DataSource = reportModel;
            solicitudesListingBindingSource.DataSource = reportModel.solicitudesListings;
            netSolicitudesByPeriodBindingSource.DataSource = reportModel.netSolicitudesByPeriods;
            this.reportViewer1.RefreshReport();
        }

        private void btnHoy_Click( object sender, EventArgs e ) {
            var fromDate = DateTime.Today;
            var toDate = DateTime.Now;

            getSolicitudesReport ( fromDate, toDate );
        }

        private void btnLast7_Click( object sender, EventArgs e ) {
            var fromDate = DateTime.Today.AddDays(-7);
            var toDate = DateTime.Now;

            getSolicitudesReport( fromDate, toDate );
        }

        private void btnThisMonth_Click( object sender, EventArgs e ) {
            var fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var toDate = DateTime.Now;

            getSolicitudesReport( fromDate, toDate );
        }

        private void btnLast30_Click( object sender, EventArgs e ) {
            var fromDate = DateTime.Today.AddDays( -30 );
            var toDate = DateTime.Now;

            getSolicitudesReport( fromDate, toDate );
        }

        private void btnThisYear_Click( object sender, EventArgs e ) {
            var fromDate = new DateTime( DateTime.Now.Year, 1, 1 );
            var toDate = DateTime.Now;

            getSolicitudesReport( fromDate, toDate );
        }

        private void btnCustom_Click( object sender, EventArgs e ) {
            lblDesde.Visible = true;
            lblHasta.Visible = true;
            dtpDesde.Visible = true;
            dtpHasta.Visible = true;
            btnAplicar.Visible = true;
        }

        private void btnGuardar_Click( object sender, EventArgs e ) {
            var fromDate = dtpDesde.Value;
            var toDate = dtpHasta.Value;

            getSolicitudesReport( fromDate, new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59) );
        }
    }
}
