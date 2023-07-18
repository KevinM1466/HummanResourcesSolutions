using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.cache;
using Domain;
using Guna.UI2.WinForms;
using Timer = System.Windows.Forms.Timer;

namespace TecnasaApp.Formularios
{
    public partial class frmRecuperarPass : Form
    {
        userModel model = new userModel();
        public frmRecuperarPass()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Random rdn = new Random();
            string contraseniaAleatoria = string.Empty;
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 10;

            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }

            var user = new userModel();
            var result = user.recoverPassword(txtCorreo.Text, contraseniaAleatoria);
            this.TopMost = false;
            MessageDialog.Show(result, "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information);

            model.ActualizarPassword(contraseniaAleatoria, contraseniaAleatoria, DateTime.Now, txtCorreo.Text);
            txtCorreo.Clear();
        }
    }
}
