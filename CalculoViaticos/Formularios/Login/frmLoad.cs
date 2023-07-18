using Common.cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoViaticos.Formularios.Login
{
    public partial class frmLoad : Form
    {
        public frmLoad()
        {
            InitializeComponent();
        }
        int contador = 0;
        int counter = 0;
        int len = 0;
        string text;
        int counter2 = 0;
        int len2 = 0;
        string text2;

        private void tmrStart_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            contador += 1;
            if (contador >= 0 && contador <= 40)
            {
                lblInfo.Text = "Cargando...";
            }
            else if (contador >= 41 && contador <= 60)
            {
                lblInfo.Text = "Por favor espere un momento...";
            }
            else if (contador >= 61 && contador <= 81)
            {
                lblInfo.Text = "Cargando Formularios...";
            } else
            {
                lblInfo.Text = "Cargando pantalla principal...";
            }
            if (contador == 100)
            {
                tmrStart.Stop();
                tmrEnd.Start();
            }
        }

        private void tmrEnd_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                tmrEnd.Stop();
                this.Close();
            }
        }

        private void frmLoad_Load(object sender, EventArgs e)
        {
            lblUser.Text = UserLoginCache.firstName + " " + UserLoginCache.lastName;
            this.Opacity = 0.0;

            text = lblBienvenida.Text;
            len = text.Length;
            lblBienvenida.Text = "";

            text2 = lblUser.Text;
            len2 = text2.Length;
            lblUser.Text = "";

            timer1.Start();
            tmrStart.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblBienvenida.Text = text.Substring(0, counter);
            ++counter;

            if (counter > len)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblUser.Text = text2.Substring(0, counter2);
            ++counter2;

            if (counter2 > len2)
            {
                timer2.Stop();
            }
        }
    }
}
