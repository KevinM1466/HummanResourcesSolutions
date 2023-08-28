using Clases;
using Common.cache;
using Domain;
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

namespace CalculoViaticos.Formularios.Empleados
{
    public partial class frmPerfil : Form
    {
        private frmPrincipal formularioPrincipal;
        public frmPerfil(frmPrincipal formularioPrincipal)
        {
            InitializeComponent();
            this.formularioPrincipal = formularioPrincipal;
        }

        Validaciones validaciones = new Validaciones();
        private void frmPerfil_Load(object sender, EventArgs e)
        {
            loadUser();
            initializePassEditControl();

            if ( CalculoViaticos.Properties.Settings.Default.Tema != "" ) {
                CambiarTema( CalculoViaticos.Properties.Settings.Default.Tema );
            } else {
                CambiarTema( "Tecnasa" );
            }
        }

        public void CambiarTema( string tema ) {
            Temas.ElegirTema( tema );
            this.BackColor = Temas.pnlDesktop;
            //Labels
            lbl1.ForeColor = Temas.fuenteTitulos;
            lbl2.ForeColor = Temas.fuenteTitulos;
            lbl3.ForeColor = Temas.fuenteTitulos;
            lbl4.ForeColor = Temas.fuenteTitulos;
            lbl5.ForeColor = Temas.fuenteTitulos;
            lbl6.ForeColor = Temas.fuenteTitulos;
            lbl7.ForeColor = Temas.fuenteTitulos;
            lblInfo.ForeColor = Temas.fuenteTitulos;
            lblEditarContra.LinkColor = Temas.fuenteTitulos;

            //buttons
            btnGuardar.FillColor = Temas.buttonsColor;
            btnErrorMessage.ForeColor = Temas.fuenteTitulos;
        }

        private void loadUser()
        {
            txtNombre.Text = UserLoginCache.firstName;
            txtApellido.Text = UserLoginCache.lastName;
            txtCorreo.Text = UserLoginCache.email;
            //lblPuesto.Text = UserLoginCache.puesto;

            txtNombre.Text = UserLoginCache.firstName;
            txtApellido.Text = UserLoginCache.lastName;
            txtCorreo.Text = UserLoginCache.email;
            txtContrasenia.Text = UserLoginCache.contrasenia;
            txtConfirmarContra.Text = UserLoginCache.contrasenia;
            txtContraActual.Text = "";
            picImage.Image = Image.FromStream(ByteImage());
        }

        private void initializePassEditControl()
        {
            lblEditarContra.Text = "Editar";
            txtContrasenia.Enabled = false;
            txtContrasenia.UseSystemPasswordChar = true;
            txtConfirmarContra.Enabled = false;
            txtConfirmarContra.UseSystemPasswordChar = true;
        }

        private void reset()
        {
            loadUser();
            initializePassEditControl();
        }

        private void lblEditarContra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblEditarContra.Text == "Editar")
            {
                lblEditarContra.Text = "Cancelar";
                txtContrasenia.Enabled = true;
                txtContrasenia.Text = "";
                txtConfirmarContra.Enabled = true;
                txtConfirmarContra.Text = "";
            }
            else if (lblEditarContra.Text == "Cancelar")
            {
                reset();
                initializePassEditControl();
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.InitialDirectory = "C:\\";
            ofd.Filter = "Imagenes (*.jpeg;*jpg;*png)|*.jpeg;*jpg;*png";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(ofd.FileName);
            }
        }

        private byte[] ConvertirImg()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.GetBuffer();
        }

        private MemoryStream ByteImage()
        {
            byte[] img = (byte[])UserLoginCache.imagen;
            MemoryStream ms = new MemoryStream(img);
            return ms;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validaciones.camposVacios(txtNombre.Text, btnErrorMessage) == false || validaciones.camposVacios(txtApellido.Text, btnErrorMessage) == false || validaciones.camposVacios(txtCorreo.Text, btnErrorMessage) == false)
            {

            }
            else
            {
                if (txtContrasenia.Text.Length >= 8)
                {
                    if (txtContrasenia.Text == txtConfirmarContra.Text)
                    {
                        if (txtContraActual.Text == UserLoginCache.contrasenia)
                        {
                            if (validaciones.SoloLetras(txtNombre.Text, btnErrorMessage) && validaciones.SoloLetras(txtApellido.Text, btnErrorMessage))
                            {
                                var userModel = new userModel(
                                _userID: UserLoginCache.userID,
                                _correo: txtCorreo.Text,
                                _contrasenia: txtContrasenia.Text,
                                _confirmarContrasenia: txtConfirmarContra.Text,
                                _fechaModi: DateTime.Now,
                                _empleadoID: UserLoginCache.empleadoID,
                                _nombres: txtNombre.Text,
                                _apellidos: txtApellido.Text,
                                _imagen: ConvertirImg());
                                var resultado = userModel.editProfile();
                                this.TopMost = false;
                                MessageDialog.Show(resultado, "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information);
                                reset();
                                //pnlPerfil.Visible = false;
                                btnAddImage.Visible = false;
                                formularioPrincipal.Refresh();
                                formularioPrincipal.LoadUserData();
                            }
                        }
                        else
                        {
                            //MessageBox.Show("La contraseña actual es incorrecta, intentelo de nuevo");
                            validaciones.msgError("La contraseña actual es incorrecta, intentelo de nuevo", btnErrorMessage);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Las contraseñas no son iguales, intente de nuevo");
                        validaciones.msgError("Las contraseñas no son iguales, intentelo de nuevo", btnErrorMessage);
                    }
                }
                else
                {
                    //MessageBox.Show("La contraseña debe tener minimo 8 caracteres", "Tecnasa Honduras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    validaciones.msgError("La contraseña debe tener minimo 8 caracteres", btnErrorMessage);
                }
            }
        }
    }
}
