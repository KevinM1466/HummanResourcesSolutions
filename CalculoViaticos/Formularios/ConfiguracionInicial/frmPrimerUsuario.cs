using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnasaApp.Formularios;
using TecnasaApp;

namespace CalculoViaticos.Formularios.ConfiiguracionInicial
{
    public partial class frmPrimerUsuario : Form
    {
        public frmPrimerUsuario()
        {
            InitializeComponent();
        }

        private void frmPrimerUsuario_Load(object sender, EventArgs e)
        {
            CambiarTema(Properties.Settings.Default.Tema);
        }

        private void CambiarTema(string tema)
        {
            //Temas.ElegirTema(tema);
            //lblInformacion.ForeColor = Temas.fuenteTitulos;
            //lblNombres.ForeColor = Temas.fuenteB;
            //lblApellidos.ForeColor = Temas.fuenteB;
            //lblCorreo.ForeColor = Temas.fuenteB;
            //lblContra.ForeColor = Temas.fuenteB;
            //lblConfirmarContra.ForeColor = Temas.fuenteB;
            //lblCargo.ForeColor = Temas.fuenteB;
            //lblDepartamento.ForeColor = Temas.fuenteB;
            //lblInfo2.ForeColor = Temas.fuenteB;
            //BackColor = Temas.pnlDesktop;
            //txtNombre.ForeColor = Temas.fuenteComboBox;
            //txtApellido.ForeColor = Temas.fuenteComboBox;
            //txtCorreo.ForeColor = Temas.fuenteComboBox;
            //txtContrasenia.ForeColor = Temas.fuenteComboBox;
            //txtConfirmarContra.ForeColor = Temas.fuenteComboBox;
            //cmbCargo.ForeColor = Temas.fuenteComboBox;
            //cmbDepartamento.ForeColor = Temas.fuenteComboBox;
        }


        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
