using Clases;
using Common.cache;

using Domain.Reinicio;

using Guna.UI2.WinForms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnasaApp;
using TecnasaApp.Formularios.General.Vacaciones;

namespace CalculoViaticos.Formularios.ConfiiguracionInicial
{
    public partial class frmConfiguracion : Form
    {
        private frmPrincipal frmPrincipal;
        private frmSolicitud frmSolicitud;
        public frmConfiguracion(frmPrincipal frmPrincipal)
        {
            InitializeComponent();
            this.frmPrincipal = frmPrincipal;
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            loadUser();
            if (Properties.Settings.Default.Tema != "")
            {
                CambiarTema(Properties.Settings.Default.Tema);
                if (Properties.Settings.Default.Seleccionado == "Tecnasa")
                {
                    btnTemaTecnasa.Checked = true;
                    btnClaro.Checked = false;
                    btnOscuro.Checked = false;
                }
                else if (Properties.Settings.Default.Seleccionado == "Claro")
                {
                    btnClaro.Checked = true;
                    btnOscuro.Checked = false;
                    btnTemaTecnasa.Checked = false;
                }
                else
                {
                    btnOscuro.Checked = true;
                    btnClaro.Checked = false;
                    btnTemaTecnasa.Checked = false;
                }
            }
            else
            {
                CambiarTema("Tecnasa");
            }
        }

        private void CambiarTema(string tema)
        {
            Temas.ElegirTema(tema);
            this.BackColor = Temas.pnlDesktop;
            tcGeneral.TabMenuBackColor = Temas.pnlDesktop;
            tpGeneral.BackColor = Temas.pnlDesktop;
            tpCuenta.BackColor = Temas.pnlDesktop;
            tpInfo.BackColor = Temas.pnlDesktop;
            tcGeneral.TabButtonIdleState.FillColor = Temas.pnlDesktop;
            tcGeneral.TabButtonIdleState.InnerColor = Temas.pnlDesktop;
            tcGeneral.TabButtonSelectedState.FillColor = Temas.buttonsColor;

            lblTema.ForeColor = Temas.fuenteTitulos;
            lbl1.ForeColor = Temas.fuenteTitulos;
            lbl2.ForeColor = Temas.fuenteTitulos;
            lbl3.ForeColor = Temas.fuenteTitulos;
            lbl4.ForeColor = Temas.fuenteTitulos;
            lbl5.ForeColor = Temas.fuenteTitulos;
            lbl6.ForeColor = Temas.fuenteTitulos;
            lbl7.ForeColor = Temas.fuenteTitulos;
            lbl8.ForeColor = Temas.fuenteTitulos;
            lbl9.ForeColor = Temas.fuenteTitulos;
            lbl10.ForeColor = Temas.fuenteTitulos;
            lbl11.ForeColor = Temas.fuenteTitulos;
            lbl12.ForeColor = Temas.fuenteTitulos;
            lbl13.ForeColor = Temas.fuenteTitulos;
            lbl14.ForeColor = Temas.fuenteTitulos;
            lbl15.ForeColor = Temas.fuenteTitulos;
            lblNombre.ForeColor = Temas.fuenteTitulos;
            lblCorreo.ForeColor = Temas.fuenteTitulos;
            lblPuesto.ForeColor = Temas.fuenteTitulos;

            btnClaro.ForeColor = Temas.fuenteTitulos;
            btnTemaTecnasa.ForeColor = Temas.fuenteTitulos;
            btnOscuro.ForeColor = Temas.fuenteTitulos;
            btnTemaTecnasa.FillColor = Temas.buttonColorTheme;
            btnClaro.FillColor = Temas.buttonColorTheme;
            btnOscuro.FillColor = Temas.buttonColorTheme;

            btnRestaurar.ForeColor = Temas.fuenteTitulos;
        }

        private void loadUser()
        {
            lblNombre.Text = UserLoginCache.firstName + " " + UserLoginCache.lastName;
            lblCorreo.Text = UserLoginCache.email;
            lblPuesto.Text = UserLoginCache.puesto;

            picImage.Image = Image.FromStream( ByteImage() );
        }

        private MemoryStream ByteImage()
        {
            byte[] img = (byte[])UserLoginCache.imagen;
            MemoryStream ms = new MemoryStream(img);
            return ms;
        }

        private void btnTemaTecnasa_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Tema = "Tecnasa";
            Properties.Settings.Default.Seleccionado = "Tecnasa";
            Properties.Settings.Default.Save();
            CambiarTema(Properties.Settings.Default.Tema);

            frmPrincipal.CambiarTema("Tecnasa");
        }

        private void btnClaro_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Tema = "Claro";
            Properties.Settings.Default.Seleccionado = "Claro";
            Properties.Settings.Default.Save();
            CambiarTema(Properties.Settings.Default.Tema);
            frmPrincipal.CambiarTema("Claro");
        }

        private void btnOscuro_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Tema = "Oscuro";
            Properties.Settings.Default.Seleccionado = "Oscuro";
            Properties.Settings.Default.Save();
            CambiarTema(Properties.Settings.Default.Tema);
            frmPrincipal.CambiarTema("Oscuro");
        }

        private void btnRestaurar_Click( object sender, EventArgs e ) {
            this.TopMost = false;
            var resultado = MessageDialog.Show("¿Estas seguro de reestablecer los valores predeterminados del sistema?\n" +
                "Se borraran todos tus datos de forma permanente. \n" +
                "Haz una copia de seguridad antes de continuar.", "Tecnasa Honduras", MessageDialogButtons.YesNo, MessageDialogIcon.Warning);

            if ( resultado == DialogResult.Yes) {
                ReinicioD reinicio = new ReinicioD();

                reinicio.Mostrar();
                //Properties.Settings.Default.ConfiguracionInicial = false;
                //Properties.Settings.Default.Tema = "Tecnasa";
                //Properties.Settings.Default.Save();
                Properties.Settings.Default.Reset();
                Application.Exit();
            }
        }
    }
}
