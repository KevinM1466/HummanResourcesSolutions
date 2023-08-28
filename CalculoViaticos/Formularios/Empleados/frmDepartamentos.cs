using Clases;
using Domain.CRUDS;
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
using Microsoft.VisualBasic;
using Common.cache;
using Domain;

namespace TecnasaApp.Formularios.General.Empleados {
    public partial class frmDepartamentos : Form {
        DepartamentosD departamentos = new DepartamentosD();
        MetodosListados metodos = new MetodosListados();
        Validaciones validaciones = new Validaciones();
        searchModel searchModel = new searchModel();
        bool isEdit;

        public frmDepartamentos() {
            InitializeComponent();
        }

        private void frmDepartamentos_Load( object sender, EventArgs e ) {
            metodos.MostrarDepartamentos( dgDatos, true );
            metodos.MostrarDepartamentos( dgEliminados, false );
            metodos.AuditDepartamentos( dgAuditoria );
            //this.dgAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgAuditoria.Columns[ 0 ].Width = 100;
            //dgAuditoria.AutoResizeColumns( DataGridViewAutoSizeColumnsMo‌​de.Fill );

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
            dgEliminados.BackgroundColor = Temas.pnlDesktop;
            tcGeneral.TabMenuBackColor = Temas.pnlDesktop;
            tpGeneral.BackColor = Temas.pnlDesktop;
            tpCuenta.BackColor = Temas.pnlDesktop;
            tpEliminados.BackColor = Temas.pnlDesktop;

            //Labels
            label1.ForeColor = Temas.fuenteTitulos;
            lblTitle.ForeColor = Temas.fuenteTitulos;
            lblNombre.ForeColor = Temas.fuenteTitulos;
            lblMensaje.ForeColor = Temas.fuenteTitulos;

            //buttons
            btnGuardar.BackColor = Temas.buttonsColor;
            btnCancelar.BackColor = Temas.buttonsColor;
            btnNuevo.BackColor = Temas.buttonsColorForm;
            btnEditar.BackColor = Temas.buttonsColorForm;
            btnEliminar.BackColor = Temas.buttonsColorForm;
            btnErrorMessage.ForeColor = Temas.buttonsColor;
            btnActivar.BackColor = Temas.buttonsColorForm;

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

        private void btnNuevo_Click( object sender, EventArgs e ) {
            dgDatos.Visible = false;
            MostrarControles( true, false );
            limpiar();
        }

        private void btnEditar_Click( object sender, EventArgs e ) {
            bool isEnable = bool.Parse( dgDatos.CurrentRow.Cells[2].Value.ToString() );
            if ( dgDatos.Rows.Count > 0 ) {
                if ( isEnable == true ) {
                    dgDatos.Visible = false;
                    txtCodigo.Text = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
                    txtDepartamento.Text = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
                    MostrarControles( true, false );
                    isEdit = true;
                } else {
                    dgDatos.Visible = false;
                    txtCodigo.Text = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
                    txtDepartamento.Text = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
                    MostrarControles( true, false );
                    isEdit = true;
                }
            } else {
                MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error );
            }
        }

        private void btnEliminar_Click( object sender, EventArgs e ) {
            if ( dgDatos.Rows.Count > 0 ) {
                if ( MessageDialog.Show( "¿Quiere eliminar este registro?", "Advertencia", MessageDialogButtons.OKCancel, MessageDialogIcon.Question ) == DialogResult.OK ) {
                    frmContrasenia frm = new frmContrasenia();
                    AddOwnedForm( frm );
                    frm.ShowDialog();
                    if ( frm.habilitado == true ) {
                        try {
                            var cod = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
                            var nombreDeparetamento = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
                            var cargoID = dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();

                            departamentos.Eliminar( int.Parse( cod ), nombreDeparetamento );
                            metodos.MostrarDepartamentos( dgDatos, true );
                            metodos.MostrarDepartamentos( dgEliminados, false );
                            metodos.AuditDepartamentos( dgAuditoria );
                        } catch ( Exception ex ) {
                            MessageDialog.Show( "Error al realizar el proceso: " + ex.Message, "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Error );
                        }
                    }
                }
            } else {
                MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error );
            }
        }

        private void btnGuardar_Click( object sender, EventArgs e ) {
            if ( ValidarCamposVacios() ) {
                if ( ValidarCamposCorrectos() ) {
                    try {
                        if ( isEdit == false ) {
                            departamentos.Insertar( txtDepartamento.Text );
                            MessageDialog.Show( "Datos guardados correctamente", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                            limpiar();
                            MostrarControles( false, true );
                            dgDatos.Visible = true;
                            btnErrorMessage.Visible = false;
                            metodos.MostrarDepartamentos( dgDatos, true );
                            metodos.AuditDepartamentos( dgAuditoria );
                        } else {
                            departamentos.Actualizar( int.Parse(txtCodigo.Text), txtDepartamento.Text, true );
                            MessageDialog.Show( "Datos Actualizados correctamente", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                            limpiar();
                            MostrarControles( false, true );
                            dgDatos.Visible = true;
                            btnErrorMessage.Visible = false;
                            metodos.MostrarDepartamentos( dgDatos, true );
                            metodos.AuditDepartamentos( dgAuditoria );
                        }
                    } catch ( Exception ex ) {
                        MessageDialog.Show("Error en el servidor: " + ex.Message, "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error);
                    }
                } else {
                    validaciones.msgError("Los campos tienen un formato incorrecto", btnErrorMessage);
                }
            } else {
                validaciones.msgError("No puede dejar los campos vacios", btnErrorMessage);
            }
        }

        private void btnCancelar_Click( object sender, EventArgs e ) {
            dgDatos.Visible = true;
            MostrarControles( false, true );
            btnErrorMessage.Visible = false;
        }

        private void MostrarControles( bool isVisible, bool isEnable ) {
            lblTitle.Visible = isVisible;
            //lblCodigo.Visible = isVisible;
            lblNombre.Visible = isVisible;
            //txtCodigo.Visible = isVisible;
            txtDepartamento.Visible = isVisible;
            btnGuardar.Visible = isVisible;
            btnCancelar.Visible = isVisible;
            label1.Visible = isEnable;

            btnBuscar.Visible = isEnable;
            btnNuevo.Visible = isEnable;
            btnEditar.Visible = isEnable;
            btnEliminar.Visible = isEnable;
        }

        private void limpiar() {
            txtCodigo.Clear();
            txtDepartamento.Clear();
        }

        private void btnBuscar_Click( object sender, EventArgs e ) {
            txtBuscar.Visible = true;
            txtBuscar.Focus();
            txtBuscar.FillColor = Temas.Buscar;
            btnBuscar.BackColor = Temas.Buscar;
        }

        private void frmDepartamentos_Click( object sender, EventArgs e ) {
            txtBuscar.Visible = false;
            btnBuscar.BackColor = Temas.pnlDesktop;
        }

        private void frmDepartamentos_KeyDown( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Escape ) {
                txtBuscar.Visible = false;
                btnBuscar.BackColor = Temas.pnlDesktop;
            }
        }

        private void txtDepartamento_TextChanged( object sender, EventArgs e ) {
            validaciones.SoloLetrasColor(txtDepartamento.Text, lblMensaje, txtDepartamento);
            btnErrorMessage.Visible = false;
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e ) {
            if ( tcGeneral.SelectedIndex == 0 ) {
                searchModel.buscarDepartamento( true, txtBuscar.Text, dgDatos );
            } else if ( tcGeneral.SelectedIndex == 1 ) {
                searchModel.buscarDepartamento( false, txtBuscar.Text, dgEliminados );
            }
        }

        private bool ValidarCamposVacios() {
            if ( !validaciones.camposVacios( txtDepartamento.Text, btnErrorMessage ) ) {
                txtDepartamento.Focus();
                return false;
            } else {
                return true;
            }

        }

        private bool ValidarCamposCorrectos() {
            if ( !validaciones.SoloLetrasColor( txtDepartamento.Text, lblMensaje, txtDepartamento ) ) {
                return false;
            }
            return true;
        }

        private void btnActivar_Click( object sender, EventArgs e ) {
            if ( dgEliminados.Rows.Count > 0 ) {
                if ( MessageDialog.Show( "¿Quieres Restaurar este registro?", "Advertencia", MessageDialogButtons.OKCancel, MessageDialogIcon.Question ) == DialogResult.OK ) {
                    frmContrasenia frm = new frmContrasenia();
                    AddOwnedForm( frm );
                    frm.ShowDialog();
                    if ( frm.habilitado == true ) {
                        try {
                            var cod = dgEliminados.CurrentRow.Cells[ 0 ].Value.ToString();
                            var nombreDeparetamento = dgEliminados.CurrentRow.Cells[ 1 ].Value.ToString();
                            var cargoID = dgEliminados.CurrentRow.Cells[ 2 ].Value.ToString();

                            departamentos.Actualizar( int.Parse( cod ), nombreDeparetamento, true );
                            metodos.MostrarDepartamentos( dgDatos, true );
                            metodos.MostrarDepartamentos( dgEliminados, false );
                            metodos.AuditDepartamentos( dgAuditoria );
                        } catch ( Exception ex ) {
                            MessageDialog.Show( "Error al realizar el proceso: " + ex.Message, "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Error );
                        }
                    }
                }
            } else {
                MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error );
            }
        }
    }
}
