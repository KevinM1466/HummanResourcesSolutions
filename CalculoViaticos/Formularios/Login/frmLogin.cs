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
using CalculoViaticos.Formularios.Empleados;
using CalculoViaticos.Formularios.Login;
using Common.cache;
using Domain;
using Guna.UI2.WinForms;
//using TecnasaApp.Formularios.Components;
using Timer = System.Windows.Forms.Timer;

namespace TecnasaApp.Formularios
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private int contador = 0;
        private int tiempo = 0;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    userModel user = new userModel();
                    user.CargarAdmin();
                    user.CargarJefe(txtUsuario.Text, txtPassword.Text);
                    var validLogin = user.isLoginUser(txtUsuario.Text, txtPassword.Text);
                    if (validLogin == true)
                    {
                        this.Hide();
                        frmLoad frmLoad = new frmLoad();
                        frmLoad.ShowDialog();
                        frmPrincipal frmPrincipal = new frmPrincipal();
                        frmPrincipal.Show();
                        frmPrincipal.FormClosed += Logout;
                        //this.Hide();
                    }
                    else
                    {
                        msgError("Correo o Contraseña incorrectos");
                        txtUsuario.Focus();
                        txtPassword.Clear();
                        contador += 1;

                        if (contador == 5)
                        {
                            timer1.Start();
                            MessageBox.Show("Lo siento ha hecho demasiados intentos por favor espere 10 segundos", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //AlertBoxArtan(Color.LightGreen, Color.SeaGreen, "Success", "Operation completed Successfully", Properties.Resources.check);
                            //AlertBoxArtan(Color.LightPink, Color.DarkRed, "Error", "Operation encountered problem!!", Properties.Resources.cancelar);
                            //AlertBoxArtan(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "Are you confident in the operation?", Properties.Resources.peligro);
                            //AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Information", "Operation is in progress", Properties.Resources.information);

                        }
                        else if (contador == 6)
                        {
                            timer2.Start();
                            MessageBox.Show("Lo siento ha hecho demasiados intentos por favor espere 20 segundos", "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    msgError("Por favor ingrese su contraseña");
                }
            }
            else
            {
                msgError("Por favor ingrese su correo");
            }
        }

        private void msgError(string msg)
        {
            btnErrorMessage.Text = "    " + msg;
            btnErrorMessage.Visible = true;
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            limpiar();
            btnErrorMessage.Visible = false;
            this.Show();
            txtUsuario.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void limpiar()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
        }

        private void IntentosErroneos(bool isActive)
        {
            txtUsuario.Enabled = isActive;
            txtPassword.Enabled = isActive;
            btnIniciarSesion.Enabled = isActive;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int tiempo = Convert.ToInt32(txtTiempo.Text);
            
            IntentosErroneos(false);
            

            tiempo += 1;
            if (tiempo == 35) //100=30 20=6
            {
                timer1.Stop();
                IntentosErroneos(true);
                tiempo = 0;
                limpiar();
                btnErrorMessage.Visible = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void lblRecuperarPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form formBG = new Form();
            using (frmRecuperarPass frm = new frmRecuperarPass())
            {
                formBG.StartPosition = FormStartPosition.Manual;
                formBG.FormBorderStyle = FormBorderStyle.None;
                formBG.Opacity = .70d;
                formBG.BackColor = Color.Black;
                formBG.WindowState = FormWindowState.Maximized;
                formBG.TopMost = true;
                formBG.Location = this.Location;
                formBG.ShowInTaskbar = false;
                formBG.Show();

                frm.Owner = formBG;
                frm.ShowDialog();

                formBG.Dispose();
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMostrarOcultar_Click(object sender, EventArgs e)
        {
            string texto = txtPassword.Text;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Text = texto;
            btnMostrarOcultar.Visible = false;
            btnOcultar.Visible = true;
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            string texto = txtPassword.Text;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Text = texto;
            btnMostrarOcultar.Visible = true;
            btnOcultar.Visible = false;
        }
    }
}
