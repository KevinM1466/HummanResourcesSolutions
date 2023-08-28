using Common.cache;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using Domain;
using TecnasaApp.Formularios.General.Empleados;
using System.IO;
using TecnasaApp.Formularios.General.Vacaciones;
using TecnasaApp.Formularios.General.Solicitudes;
using Guna.UI2.WinForms;
using CalculoViaticos.Formularios.Empleados;
using System.Diagnostics;
using CalculoViaticos.Formularios;
using Clases;
using static Guna.UI2.WinForms.Suite.Descriptions;
using CalculoViaticos.Formularios.ConfiiguracionInicial;
//using TheArtOfDev.HtmlRenderer.Adapters.Entities;
//using TecnasaApp.Formularios.General.Vacaciones;
//using TecnasaApp.Formularios.General.Solicitudes;

namespace TecnasaApp
{
    public partial class frmPrincipal : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public Form currentChildForm;
        userModel cargos = new userModel();
        userModel security = new userModel();
        int flag = -1;
        public frmPrincipal()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            pnlMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();
            cargos.AnyMethod(btnSolicitud, btnEmpleados, btnUsuarios, btnDepartamentos, btnPuestos, btnJefes, btnSolicitudes);
            security.security( UserLoginCache.userID );

            if (CalculoViaticos.Properties.Settings.Default.Tema != "")
            {
                CambiarTema(CalculoViaticos.Properties.Settings.Default.Tema);
            }
            else
            {
                CambiarTema("Tecnasa");
            }
        }

        public void CambiarTema(string tema)
        {
            Temas.ElegirTema(tema);
            pnlDesktop.BackColor = Temas.pnlDesktop;
            pnlMenu.BackColor = Temas.pnlMenu;
            pnlTitleBar.BackColor = Temas.pnlTitleBar;
            pnlLogo.BackColor = Temas.pnlMenu;
            btnHome.BackColor = Temas.pnlMenu;
            iconCurrentChildForm.BackColor = Temas.pnlTitleBar;
            btnminimice.BackColor = Temas.pnlTitleBar;
            btnSalir.BackColor = Temas.pnlTitleBar;
            btnHelp.BackColor = Temas.pnlTitleBar;
            pnlUser.BackColor = Temas.pnlTitleBar;

            btnSolicitud.ForeColor = Temas.fuenteTitulos;
            btnSolicitudes.ForeColor = Temas.fuenteTitulos;
            btnEmpleados.ForeColor = Temas.fuenteTitulos;
            btnDepartamentos.ForeColor = Temas.fuenteTitulos;
            btnPuestos.ForeColor = Temas.fuenteTitulos;
            btnJefes.ForeColor = Temas.fuenteTitulos;
            btnUsuarios.ForeColor = Temas.fuenteTitulos;
            btnReportes.ForeColor = Temas.fuenteTitulos;
            
            btnSolicitud.IconColor = Temas.fuenteTitulos;
            btnSolicitudes.IconColor = Temas.fuenteTitulos;
            btnEmpleados.IconColor = Temas.fuenteTitulos;
            btnDepartamentos.IconColor = Temas.fuenteTitulos;
            btnPuestos.IconColor = Temas.fuenteTitulos;
            btnJefes.IconColor = Temas.fuenteTitulos;
            btnUsuarios.IconColor = Temas.fuenteTitulos;
            btnReportes.IconColor = Temas.fuenteTitulos;

            btnSolicitud.FlatAppearance.MouseOverBackColor = Temas.Hover;
            btnSolicitudes.FlatAppearance.MouseOverBackColor = Temas.Hover;
            btnEmpleados.FlatAppearance.MouseOverBackColor = Temas.Hover;
            btnDepartamentos.FlatAppearance.MouseOverBackColor = Temas.Hover;
            btnPuestos.FlatAppearance.MouseOverBackColor = Temas.Hover;
            btnJefes.FlatAppearance.MouseOverBackColor = Temas.Hover;
            btnUsuarios.FlatAppearance.MouseOverBackColor = Temas.Hover;
            btnReportes.FlatAppearance.MouseOverBackColor = Temas.Hover;

            lblHora.ForeColor = Temas.fuenteTitulos;
            lblFecha.ForeColor = Temas.fuenteTitulos;
        }

        private struct RGBColors
        {
            public static Color color = Color.FromArgb(255, 204, 0);
        }

        //Methods
        private void ActiveButton(object senderBtn, Color color)
        {
            
            if (senderBtn != null) {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Temas.Hover;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left Border Button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.Transparent;
                currentBtn.ForeColor = Temas.fuenteTitulos;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Temas.fuenteTitulos;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
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
            lblTitleChildForm.Text = currentBtn.Text;

        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm == null)
            {
                //Code
            }
            else
            {
                currentChildForm.Close();
                Reset();
                pnlUser.Visible = false;
            }
        }

        public void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Inicio";
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lparam);

        private void tmrHora_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            const string message = "¿Está seguro de que desea cerrar el programa?";
            const string caption = "Cierre de formulario";
            var result = MessageDialog.Show(message, caption,
                                         MessageDialogButtons.YesNo,
                                         MessageDialogIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();                
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void btnminimice_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            pnlUser.Visible = false;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            
        }

        private MemoryStream ByteImage()
        {
                byte[] img = (byte[])UserLoginCache.imagen;
                MemoryStream ms = new MemoryStream(img);
                return ms;
        }

        public void LoadUserData()
        {
            try
            {
                btnInfoUser.Text = UserLoginCache.firstName + " " + UserLoginCache.lastName;
                lblName.Text = UserLoginCache.firstName + " " + UserLoginCache.lastName;
                lblCargo.Text = UserLoginCache.puesto;
                lblEmail.Text = UserLoginCache.email;
                picImage.Image = Image.FromStream(ByteImage());
                pbPerfil.Image = Image.FromStream(ByteImage());
                pnlUser.Size = new Size(333, 220);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos");
            }
        }

        

        private void mostrar(Panel subMenu) {
            if (subMenu.Visible == false) { 
                subMenu.Visible = true;
            } else { 
                subMenu.Visible = false;
            }
        }


        private void btnInfoUser_Click(object sender, EventArgs e)
        {
            flag *= -1;
            if (flag == 1)
            {
                pnlUser.Show();
                pnlUser.BringToFront();
            }
            else
            {
                pnlUser.Hide();
                pnlUser.BringToFront();
            }
                
        }

        private void pnlDesktop_Click(object sender, EventArgs e)
        {
            pnlUser.Visible = false;
        }

        private void pnlTitleBar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCerrarSesion_Click_1(object sender, EventArgs e)
        {
            const string message = "¿Está seguro de que desea cerrar sesión?";
            const string caption = "Cerrar Sesión";
            var result = MessageDialog.Show(message, caption,
                                         MessageDialogButtons.YesNo,
                                         MessageDialogIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            } else
            {
                pnlUser.Visible = false;
            }
        }

        private void btnEmpleados_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color);
            OpenChildForm(new frmEmpleados());
        }

        private void btnConfigProfile_Click(object sender, EventArgs e)
        {
            //frmPerfilUsuario frm = new frmPerfilUsuario();
            //if (currentChildForm != null)
            //{
            //    currentChildForm.Close();
            //}
            //currentChildForm = frm;
            //frm.TopLevel = false;
            //frm.FormBorderStyle = FormBorderStyle.None;
            //frm.Dock = DockStyle.Fill;
            //pnlDesktop.Controls.Add(frm);
            //pnlDesktop.Tag = frm;
            //frm.BringToFront();
            Form formBG = new Form();
            using (frmPerfil frm = new frmPerfil(this))
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

        private void picLogo_Click(object sender, EventArgs e)
        {
            pnlUser.Visible = false;
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {
            pnlUser.Visible = false;
        }

        private void btnSolicitud_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color);
            OpenChildForm(new frmSolicitud());
        }

        private void btnPuestos_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color);
            OpenChildForm(new frmPuestos());
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color);
            OpenChildForm(new frmDepartamentos());
        }

        private void btnJefes_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color);
            OpenChildForm(new frmJefesDirectos());
        }

        private void btnSolicitudes_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color);
            OpenChildForm(new frmSolicitudes());

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color);
            OpenChildForm(new frmUsuarios());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color);
            OpenChildForm(new frmReportes());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LoadUserData();
            pnlUser.Size = new Size(333, 220);
        }

        private void btnInfoUser_MouseHover(object sender, EventArgs e)
        {
            tpInformation.SetToolTip(btnInfoUser, "El usuario " + UserLoginCache.firstName + " " + UserLoginCache.lastName + " ha iniciado sesión");
        }

        private void pnlUser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://supporttecnasa.netlify.app");
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error);
            }
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            //frmConfiguracion childForm = new frmConfiguracion(this);
            //if (currentChildForm != null)
            //{
            //    currentChildForm.Close();
            //}
            //currentChildForm = childForm;
            //childForm.TopLevel = false;
            //childForm.Dock = DockStyle.Fill;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            //pnlDesktop.Controls.Add(childForm);
            //pnlDesktop.Tag = childForm;
            //childForm.BringToFront();
            //childForm.Show();

            Form formBG = new Form();
            using (frmConfiguracion frm = new frmConfiguracion(this))
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
    }
}
