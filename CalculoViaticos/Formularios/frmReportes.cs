using CalculoViaticos.Reportes.Formularios;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoViaticos.Formularios
{
    public partial class frmReportes : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public Form currentChildForm;
        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {

            
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            childForm.FormBorderStyle = FormBorderStyle.None;
            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnReporte1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReporteSolicitudes());
        }

        private void btnReporte2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReporte2());
        }

        private void btnReporte3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReporte3());
        }

        private void btnReporte4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReporte4());
        }
    }
}
