using Common.cache;
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
using TecnasaApp.Formularios.General.Empleados;

namespace TecnasaApp.Formularios.General
{
    public partial class frmContrasenia : Form
    {

        public bool habilitado = true;
        public frmContrasenia()
        {
            InitializeComponent();
        }

        private void frmContrasenia_Load(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //frmDepartamentos frm = (frmDepartamentos)Owner;
            //frm.swtMostrarEliminados.Checked = false;
            //frm.isTrue = false;
            habilitado = false;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == UserLoginCache.contrasenia)
            {
                this.Close();
            } else
            {
                this.TopMost = false;
                MessageDialog.Show("La contraseña ingresada es incorrecta", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error);
            }
        }

        private void btnMostrarOcultar_Click(object sender, EventArgs e)
        {
            string texto = txtContraseña.Text;
            txtContraseña.UseSystemPasswordChar = false;
            txtContraseña.Text = texto;
            btnMostrarOcultar.Visible = false;
            btnOcultar.Visible = true;
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            string texto = txtContraseña.Text;
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.Text = texto;
            btnMostrarOcultar.Visible = true;
            btnOcultar.Visible = true;
        }
    }
}
