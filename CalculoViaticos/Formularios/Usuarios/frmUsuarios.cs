using Clases;

using Domain;
using Domain.CRUDS;

using Guna.UI2.WinForms;

using Org.BouncyCastle.Utilities.Collections;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TecnasaApp;
using TecnasaApp.Formularios.General;
using TecnasaApp.Formularios.General.Empleados;

namespace CalculoViaticos.Formularios.Empleados {
    public partial class frmUsuarios : Form {
        UsuariosD usuarios = new UsuariosD();
        MetodosListados metodos = new MetodosListados();
        Validaciones validaciones = new Validaciones();
        searchModel search = new searchModel();
        bool isEdit = false;
        public frmUsuarios() {
            InitializeComponent();
        }

        private void frmUsuarios_Load( object sender, EventArgs e ) {
            txtContrasenia.UseSystemPasswordChar = true;
            txtConfirmarContra.UseSystemPasswordChar = true;
            metodos.MostrarUsuarios( dgDatos );
            metodos.AuditUsuarios( dgAuditoria );

            if ( CalculoViaticos.Properties.Settings.Default.Tema != "" ) {
                CambiarTema( CalculoViaticos.Properties.Settings.Default.Tema );
            } else {
                CambiarTema( "Tecnasa" );
            }
        }

        public void CambiarTema( string tema ) {
            Temas.ElegirTema( tema );
            this.BackColor = Temas.pnlDesktop;
            dgDatos.BackgroundColor = Temas.pnlDesktop;
            dgAuditoria.BackgroundColor = Temas.pnlDesktop;
            tcGeneral.TabMenuBackColor = Temas.pnlDesktop;
            tpGeneral.BackColor = Temas.pnlDesktop;
            tpCuenta.BackColor = Temas.pnlDesktop;

            //Labels
            label2.ForeColor = Temas.fuenteTitulos;
            lblTitle.ForeColor = Temas.fuenteTitulos;
            lblNombre.ForeColor = Temas.fuenteTitulos;
            lblCorreo.ForeColor = Temas.fuenteTitulos;
            lblContrasenia.ForeColor = Temas.fuenteTitulos;
            lblConfirmar.ForeColor = Temas.fuenteTitulos;
            lblMensajeCorreo.ForeColor = Temas.fuenteTitulos;
            lblMensajeContra.ForeColor = Temas.fuenteTitulos;
            lblMensajeConfirmar.ForeColor = Temas.fuenteTitulos;

            chkMinCaracteres.ForeColor = Temas.fuenteTitulos;
            chkMayus.ForeColor = Temas.fuenteTitulos;
            chkMinus.ForeColor = Temas.fuenteTitulos;
            chkNumero.ForeColor = Temas.fuenteTitulos;

            //buttons
            btnGuardar.FillColor = Temas.buttonsColor;
            btnCancelar.FillColor = Temas.buttonsColor;
            btnNuevo.BackColor = Temas.buttonsColorForm;
            btnEditar.BackColor = Temas.buttonsColorForm;
            btnEliminar.BackColor = Temas.buttonsColorForm;
            btnErrorMessage.ForeColor = Temas.buttonsColor;

            //Search
            txtBuscar.BackColor = Temas.pnlDesktop;
            txtBuscar.FillColor = Temas.pnlDesktop;
            txtBuscar.BorderColor = Temas.pnlDesktop;
            txtBuscar.ForeColor = Temas.fuenteTextBoxBuscar;
            btnBuscar.BackColor = Temas.pnlDesktop;
            btnBuscar.IconColor = Temas.fuenteTitulos;
            btnBuscar.FlatAppearance.MouseOverBackColor = Temas.pnlMenu;
            btnBuscar.FlatAppearance.MouseDownBackColor = Temas.pnlMenu;

            tcGeneral.TabButtonIdleState.FillColor = Temas.pnlDesktop;
            tcGeneral.TabButtonIdleState.InnerColor = Temas.pnlDesktop;
            tcGeneral.TabButtonSelectedState.FillColor = Temas.tapPageSelected;
            tcGeneral.TabButtonSelectedState.InnerColor = Temas.tapPageSelectedInner;
        }

        private void btnBuscarEmpleado_Click( object sender, EventArgs e ) {
            Form formBG = new Form();
            using ( frmEmpleados frm = new frmEmpleados() ) {
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
                frm.lblMensaje.ForeColor = Color.Red;
                frm.lblMensaje.Text = "Doble click sobre una fila para seleccionar un empleado";
                frm.lblMensaje.Visible = true;
                frm.dgDatos2.Visible = true;
                frm.dgDatos2.BringToFront();
                frm.dgDatos.Visible = false;
                AddOwnedForm( frm );
                frm.ShowDialog();

                formBG.Dispose();
            }
        }

        private void btnNuevo_Click( object sender, EventArgs e ) {
            dgDatos.Visible = false;
            MostrarControles( true, false );
            limpiar();
        }

        private void btnEditar_Click( object sender, EventArgs e ) {
            dgDatos.Visible = false;
            txtUserID.Text = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
            txtEmpleadoID.Text = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
            txtEmpleado.Text = dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();
            txtCorreo.Text = dgDatos.CurrentRow.Cells[ 3 ].Value.ToString();
            txtContrasenia.Text = dgDatos.CurrentRow.Cells[ 4 ].Value.ToString();
            txtConfirmarContra.Text = dgDatos.CurrentRow.Cells[ 4 ].Value.ToString();
            MostrarControles( true, false );
            isEdit = true;
        }

        private void btnEliminar_Click( object sender, EventArgs e ) {

        }

        private void btnGuardar_Click( object sender, EventArgs e ) {
            if ( ValidarCamposVacios() ) {
                if ( txtEmpleado.Text != "" || txtCorreo.Text != "" || txtContrasenia.Text != "" || txtConfirmarContra.Text != "" ) {
                    if ( chkMayus.Checked && chkMinCaracteres.Checked && chkMinus.Checked && chkNumero.Checked ) {
                        if ( txtContrasenia.Text == txtConfirmarContra.Text ) {
                            if ( isEdit == false ) {
                                try {
                                    usuarios.Insertar( int.Parse( txtEmpleadoID.Text ), txtCorreo.Text, txtContrasenia.Text, txtConfirmarContra.Text );
                                    MessageDialog.Show( "Datos guardados con exito", "Soporte de Sistema", MessageDialogButtons.OK, MessageDialogIcon.Information );
                                    limpiar();
                                    MostrarControles( false, true );
                                    pnlMenu.Visible = false;
                                    dgDatos.Visible = true;
                                    btnErrorMessage.Visible = false;
                                    metodos.MostrarUsuarios( dgDatos );
                                    metodos.AuditUsuarios( dgAuditoria );
                                } catch ( Exception ex ) {
                                    MessageDialog.Show( ex.Message, "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error );
                                }
                            }

                            if ( isEdit == true ) {
                                try {
                                    usuarios.Actualizar( int.Parse( txtUserID.Text ), int.Parse( txtEmpleadoID.Text ), txtCorreo.Text, txtContrasenia.Text, txtConfirmarContra.Text );
                                    MessageDialog.Show( "Datos guardados con exito", "Soporte de Sistema", MessageDialogButtons.OK, MessageDialogIcon.Information );
                                    isEdit = false;
                                    limpiar();
                                    MostrarControles( false, true );
                                    pnlMenu.Visible = false;
                                    dgDatos.Visible = true;
                                    btnErrorMessage.Visible = false;
                                    metodos.MostrarUsuarios( dgDatos );
                                    metodos.AuditUsuarios( dgAuditoria );
                                } catch ( Exception ex ) {
                                    MessageBox.Show( ex.ToString(), "Soporte de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error );
                                }
                            }
                        } else {
                            validaciones.msgError( "Las contraseñas no coinciden", btnErrorMessage );
                        }
                    } else {
                        validaciones.msgError( "La contraseña tiene formato incorrecto", btnErrorMessage );
                    }
                } else {
                    validaciones.msgError( "No puede dejar los campos vacios", btnErrorMessage );
                }
            }
        }

        private void btnCancelar_Click( object sender, EventArgs e ) {
            dgDatos.Visible = true;
            MostrarControles( false, true );
            ocultarErrors();
        }

        private void btnBuscar_Click( object sender, EventArgs e ) {
            txtBuscar.Visible = true;
            txtBuscar.Focus();
            txtBuscar.FillColor = Temas.Buscar;
            btnBuscar.BackColor = Temas.Buscar;
        }

        private void MostrarControles( bool isVisible, bool isEnable ) {
            lblTitle.Visible = isVisible;
            lblNombre.Visible = isVisible;
            lblCorreo.Visible = isVisible;
            lblContrasenia.Visible = isVisible;
            lblConfirmar.Visible = isVisible;
            //txtCodigo.Visible = isVisible;
            btnGuardar.Visible = isVisible;
            btnCancelar.Visible = isVisible;
            //label1.Visible = isEnable;
            txtEmpleado.Visible = isVisible;
            txtCorreo.Visible = isVisible;
            txtContrasenia.Visible = isVisible;
            txtConfirmarContra.Visible = isVisible;

            btnBuscar.Visible = isEnable;
            btnNuevo.Visible = isEnable;
            btnEditar.Visible = isEnable;
        }

        private void limpiar() {
            txtEmpleadoID.Clear();
            txtEmpleado.Clear();
            txtCorreo.Clear();
            txtContrasenia.Clear();
            txtConfirmarContra.Clear();
        }

        private void ocultarErrors() {
            btnErrorMessage.Visible = false;
        }

        private void txtCorreo_TextChanged( object sender, EventArgs e ) {
            validaciones.ValidarEmail( txtCorreo.Text, lblMensajeCorreo, txtCorreo );
        }

        private void txtContrasenia_TextChanged( object sender, EventArgs e ) {
            pnlMenu.Visible = true;
            validaciones.AlgoritmoContraseñaSegura( txtContrasenia.Text, chkMinCaracteres, chkMayus, chkMinus, chkNumero, lblMensajeContra, txtContrasenia );
            if ( chkMayus.Checked && chkMinCaracteres.Checked && chkMinus.Checked && chkNumero.Checked ) {
                pnlMenu.Visible = false;
            }
        }

        private void txtConfirmarContra_TextChanged( object sender, EventArgs e ) {
            if ( txtContrasenia.Text != txtConfirmarContra.Text ) {
                lblMensajeConfirmar.Visible = true;
                lblMensajeConfirmar.ForeColor = Color.Red;
                lblMensajeConfirmar.Text = "Las contraseñas no coinciden";
                txtConfirmarContra.BorderThickness = 2;
                txtConfirmarContra.BorderColor = Color.Red;
                txtConfirmarContra.HoverState.BorderColor = Color.Red;
                txtConfirmarContra.FocusedState.BorderColor = Color.Red;
            } else {
                lblMensajeConfirmar.Visible = false;
                txtConfirmarContra.BorderThickness = 2;
                txtConfirmarContra.BorderColor = Color.Green;
                txtConfirmarContra.HoverState.BorderColor = Color.Green;
                txtConfirmarContra.FocusedState.BorderColor = Color.Green;
            }
        }

        private bool ValidarCamposVacios() {
            if ( !validaciones.camposVacios( txtEmpleado.Text, btnErrorMessage ) ) {
                txtEmpleado.Focus();
                return false;
            } else if ( !validaciones.camposVacios( txtCorreo.Text, btnErrorMessage ) ) {
                txtCorreo.Focus();
                return false;
            } else if ( !validaciones.camposVacios( txtContrasenia.Text, btnErrorMessage ) ) {
                txtContrasenia.Focus();
                return false;
            } else if ( !validaciones.camposVacios( txtConfirmarContra.Text, btnErrorMessage ) ) {
                txtConfirmarContra.Focus();
                return false;
            } else {
                return true;
            }

        }

        private void txtBuscar_TextChanged( object sender, EventArgs e ) {
            search.buscarUsuarios( txtBuscar.Text, txtBuscar.Text, dgDatos );
        }

        private void frmUsuarios_Click( object sender, EventArgs e ) {
            txtBuscar.Visible = false;
            btnBuscar.BackColor = Temas.pnlDesktop;
        }

        private void frmUsuarios_KeyDown( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Escape ) {
                txtBuscar.Visible = false;
                btnBuscar.BackColor = Temas.pnlDesktop;
            }
        }
    }
}
