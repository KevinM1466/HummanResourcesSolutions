using Clases;
using Common.cache;
using Domain.CRUDS;
using Guna.UI2.WinForms;
using Microsoft.Win32;

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
using TecnasaApp.Formularios;

namespace CalculoViaticos.Formularios.ConfiiguracionInicial
{
    public partial class frmConfiguracionInicial : Form
    {
        Validaciones validaciones = new Validaciones();
        private Panel leftBorderBtn;
        public Form currentChildForm;
        bool isImage = false;

        bool isTrue;
        public frmConfiguracionInicial()
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }

        private void frmConfiguracionInicial_Load(object sender, EventArgs e)
        {
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
            } else
            {
                CambiarTema("Tecnasa");
            }
        }

        private void CambiarTema(string tema)
        {
            Temas.ElegirTema(tema);
            this.BackColor = Temas.pnlDesktop;
            lbl1.ForeColor = Temas.fuenteTitulos;
            lblTema.ForeColor = Temas.fuenteTitulos;
            btnSiguiente.FillColor = Temas.buttonsColor;
            btnRegresar.FillColor = Temas.buttonsColor;
            btnGuardar.FillColor = Temas.buttonsColor;
            btnClaro.ForeColor = Temas.fuenteTitulos;
            btnTemaTecnasa.ForeColor = Temas.fuenteTitulos;
            btnOscuro.ForeColor = Temas.fuenteTitulos;
            btnTemaTecnasa.FillColor = Temas.buttonColorTheme;
            btnClaro.FillColor = Temas.buttonColorTheme;
            btnOscuro.FillColor = Temas.buttonColorTheme;
            tpTemas.BackColor = Temas.pnlDesktop;
            tpUsuario.BackColor = Temas.pnlDesktop;

            lblInformacion.ForeColor = Temas.fuenteTitulos;
            lblNombres.ForeColor = Temas.fuenteTitulos;
            lblApellidos.ForeColor = Temas.fuenteTitulos;
            lblCorreo.ForeColor = Temas.fuenteTitulos;
            lblContra.ForeColor = Temas.fuenteTitulos;
            lblConfirmarContra.ForeColor = Temas.fuenteTitulos;
            lblCargo.ForeColor = Temas.fuenteTitulos;
            lblDepartamento.ForeColor = Temas.fuenteTitulos;
            lblInfo2.ForeColor = Temas.fuenteTitulos;
            lblFirma.ForeColor = Temas.fuenteTitulos;
            lblImagen.ForeColor = Temas.fuenteTitulos;
            lblName.ForeColor = Temas.fuenteTitulos;

            BackColor = Temas.pnlDesktop;
            txtNombre.ForeColor = Temas.fuenteTextBox;
            txtApellido.ForeColor = Temas.fuenteTextBox;
            txtCorreo.ForeColor = Temas.fuenteTextBox;
            txtContrasenia.ForeColor = Temas.fuenteTextBox;
            txtConfirmarContra.ForeColor = Temas.fuenteTextBox;
            cmbCargo.ForeColor = Temas.fuenteComboBox;
            cmbDepartamento.ForeColor = Temas.fuenteComboBox;
            btnErrorMessage.ForeColor = Temas.fuenteTitulos;
            chkMayus.ForeColor = Temas.fuenteTitulos;
            chkMinCaracteres.ForeColor = Temas.fuenteTitulos;
            chkMinus.ForeColor = Temas.fuenteTitulos;
            chkNumero.ForeColor = Temas.fuenteTitulos;
        }

        private void btnTemaTecnasa_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Tema = "Tecnasa";
            Properties.Settings.Default.Seleccionado = "Tecnasa";
            Properties.Settings.Default.Save();
            CambiarTema(Properties.Settings.Default.Tema);
        }

        private void btnClaro_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Tema = "Claro";
            Properties.Settings.Default.Seleccionado = "Claro";
            Properties.Settings.Default.Save();
            CambiarTema(Properties.Settings.Default.Tema);
        }

        private void btnOscuro_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Tema = "Oscuro";
            Properties.Settings.Default.Seleccionado = "Oscuro";
            Properties.Settings.Default.Save();
            CambiarTema(Properties.Settings.Default.Tema);
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
            tpUsuario.Controls.Add(childForm);
            tpUsuario.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            tcConfiguracion.SelectedIndex += 1;

            if (tcConfiguracion.SelectedIndex == 0)
            {
                btnRegresar.Visible = false;
                btnGuardar.Visible = false;
            }
            else
            {
                btnRegresar.Visible = true;
            }

            if (tcConfiguracion.SelectedIndex == 1)
            {
                btnGuardar.Visible = true;
                btnSiguiente.Visible = false;
                AcceptButton = btnGuardar;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            tcConfiguracion.SelectedIndex -= 1;
            this.Refresh();

            if (tcConfiguracion.SelectedIndex == 0)
            {
                btnSiguiente.Visible = true;
                btnRegresar.Visible = false;
                btnGuardar.Visible = false;
            }
            else
            {
                btnSiguiente.Visible = true;
            }
        }

        private byte[] ConvertirFirma() {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picFirma.Image.Save( ms, System.Drawing.Imaging.ImageFormat.Jpeg );
            return ms.GetBuffer();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposVacios())
            {
                if (txtNombre.Text != "" || txtApellido.Text != "" || txtCorreo.Text != "" || txtContrasenia.Text != "" || txtConfirmarContra.Text != "")
                {
                    if (chkMayus.Checked && chkMinCaracteres.Checked && chkMinus.Checked && chkNumero.Checked)
                    {
                        if ( validaciones.ValidarEmail( txtCorreo.Text, lblMensajeCorreo, txtCorreo ) == true ) {
                            if ( validaciones.SoloLetrasColor( txtNombre.Text, lblMensaje, txtNombre ) == true ) {
                                if ( validaciones.SoloLetrasColor( txtApellido.Text, lblMensajeApellido, txtApellido ) == true ) {
                                    if ( txtContrasenia.Text == txtConfirmarContra.Text ) {
                                        if ( lblName.Text != "No se elijio Archivo" ) {
                                            if ( isImage == true ) {
                                                EmpleadosD empleado = new EmpleadosD();
                                                UsuariosD usuarios = new UsuariosD();
                                                PuestosD puestos = new PuestosD();
                                                DepartamentosD departamentos = new DepartamentosD();
                                                JefesD jefes = new JefesD();
                                                frmLogin login = new frmLogin();

                                                empleado.Insertar( txtNombre.Text, txtApellido.Text, DateTime.Now, 1, 1, ConvertirImg(), DateTime.Now, true );
                                                usuarios.Insertar( 1, txtCorreo.Text, txtContrasenia.Text, txtConfirmarContra.Text );
                                                puestos.Insertar( cmbCargo.Text );
                                                departamentos.Insertar( cmbDepartamento.Text );
                                                jefes.Insertar( 1, 1, ConvertirFirma(), lblName.Text );
                                                Properties.Settings.Default.ConfiguracionInicial = true;
                                                Properties.Settings.Default.Save();

                                                this.Hide();
                                                login.Show();
                                                login.FormClosed += Logout;
                                            } else {
                                                MessageDialog.Show( "Debes seleccionar una imagen", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Warning );
                                            }
                                        } else {
                                            validaciones.msgError( "Debe seleccionar una imagen con la firma", btnErrorMessage );
                                        }
                                    } else {
                                        validaciones.msgError( "Las contraseñas no coinciden", btnErrorMessage );
                                    }
                                } else {
                                    validaciones.msgError( "Uno o más campos tienen un formato incorrecto", btnErrorMessage );
                                }
                            } else {
                                validaciones.msgError( "Uno o más campos tienen un formato incorrecto", btnErrorMessage );
                            }
                        } else {
                            validaciones.msgError( "El correo no es válido", btnErrorMessage );
                        }
                    } else {
                        validaciones.msgError("La contraseña tiene formato incorrecto", btnErrorMessage);
                    }
                } else {
                    validaciones.msgError("No puede dejar los campos vacios", btnErrorMessage);
                }
            }
        }

        private void txtContrasenia_Click(object sender, EventArgs e)
        {
            
        }

        private void tpUsuario_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = false;
            txtConfirmarContra.Visible = true;
            lblConfirmarContra.Visible = true;
            lblInformacion.Focus();
            btnErrorMessage.Visible = false;
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            pnlMenu.Visible = true;
            txtConfirmarContra.Visible = false;
            lblConfirmarContra.Visible = false;

            validaciones.AlgoritmoContraseñaSegura(txtContrasenia.Text, chkMinCaracteres, chkMayus, chkMinus, chkNumero, lblMensajeContra, txtContrasenia);
            btnErrorMessage.Visible = false;
            if ( chkMayus.Checked && chkMinCaracteres.Checked && chkMinus.Checked && chkNumero.Checked ) {
                pnlMenu.Visible = false;
                txtConfirmarContra.Visible = true;
                lblConfirmarContra.Visible = true;
            }
        }

        private bool ValidarCamposVacios()
        {
            if (!validaciones.camposVacios(txtNombre.Text, btnErrorMessage)) {
                txtNombre.Focus();
                return false;
            } else if (!validaciones.camposVacios(txtApellido.Text, btnErrorMessage)) { 
                txtApellido.Focus();
                return false;
            } else if (!validaciones.camposVacios(txtCorreo.Text, btnErrorMessage)) {
                txtCorreo.Focus();
                return false;
            } else if (!validaciones.camposVacios(txtContrasenia.Text, btnErrorMessage)) {
                txtContrasenia.Focus();
                return false;
            } else if (!validaciones.camposVacios(txtConfirmarContra.Text, btnErrorMessage)) {
                txtConfirmarContra.Focus();
                return false;
            } else
            {
                return true;
            }
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validaciones.SoloLetrasColor(txtNombre.Text, lblMensaje, txtNombre);
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            validaciones.SoloLetrasColor(txtApellido.Text, lblMensajeApellido, txtApellido);
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            validaciones.ValidarEmail(txtCorreo.Text, lblMensajeCorreo, txtCorreo);
        }

        private void txtConfirmarContra_TextChanged(object sender, EventArgs e)
        {
            if (txtContrasenia.Text != txtConfirmarContra.Text)
            {
                lblMensajeConfirmar.Visible = true;
                lblMensajeConfirmar.ForeColor = Color.Red;
                lblMensajeConfirmar.Text = "Las contraseñas no coinciden";
                txtConfirmarContra.BorderThickness = 2;
                txtConfirmarContra.BorderColor = Color.Red;
                txtConfirmarContra.HoverState.BorderColor = Color.Red;
                txtConfirmarContra.FocusedState.BorderColor = Color.Red;
            } else
            {
                lblMensajeConfirmar.Visible = false;
                txtConfirmarContra.BorderThickness = 2;
                txtConfirmarContra.BorderColor = Color.Green;
                txtConfirmarContra.HoverState.BorderColor = Color.Green;
                txtConfirmarContra.FocusedState.BorderColor = Color.Green;
            }
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.AddExtension = true;
            ofd.InitialDirectory = "C:\\";
            ofd.Filter = "Imagenes (*.jpeg;*jpg;*png)|*.jpeg;*jpg;*png";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(ofd.FileName);
                isImage = true;
            }
        }

        private byte[] ConvertirImg()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.GetBuffer();
        }

        private void btnSeleccionar_Click( object sender, EventArgs e ) {
            openFileDialog1.Filter = "Imagenes (*.jpeg;*jpg;*png)|*.jpeg;*jpg;*png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if ( openFileDialog1.ShowDialog() == DialogResult.OK ) {
                picFirma.Image = Image.FromFile( openFileDialog1.FileName );
                lblName.Text = openFileDialog1.SafeFileName;
            }
        }
    }
}
