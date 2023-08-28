using Clases;

using Domain;
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

namespace TecnasaApp.Formularios.General.Empleados
{
    public partial class frmPuestos : Form
    {
        PuestosD puestos = new PuestosD();
        MetodosListados metodos = new MetodosListados();
        Validaciones validaciones = new Validaciones();
        searchModel search = new searchModel();
        bool isEdit = false;
        public frmPuestos()
        {
            InitializeComponent();
        }

        private void frmPuestos_Load(object sender, EventArgs e)
        {
            metodos.MostrarCargos(dgDatos, true);
            metodos.MostrarCargos(dgEliminados, false);
            metodos.AuditPuestos(dgAuditoria);

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
            label2.ForeColor = Temas.fuenteTitulos;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgDatos.Visible = false;
            limpiar();
            MostrarControles(true, false);
            limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dgDatos.Visible = false;
            txtCodigo.Text = dgDatos.CurrentRow.Cells[0].Value.ToString();
            txtCargo.Text = dgDatos.CurrentRow.Cells[1].Value.ToString();
            MostrarControles(true, false);
            isEdit = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ( dgDatos.Rows.Count > 0 ) {
                try {
                    if ( MessageDialog.Show( "¿Quiere eliminar este registro?", "Advertencia", MessageDialogButtons.OKCancel, MessageDialogIcon.Question ) == DialogResult.OK ) {
                        frmContrasenia frm = new frmContrasenia();
                        AddOwnedForm( frm );
                        frm.ShowDialog();
                        if ( frm.habilitado == true ) {
                            var cod = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
                            var puesto = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
                            var estado = dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();

                            puestos.Eliminar( int.Parse( cod ), puesto );
                            metodos.MostrarCargos( dgDatos, true );
                            metodos.MostrarCargos( dgEliminados, false );
                            metodos.AuditPuestos( dgAuditoria );
                        }
                    }
                } catch ( Exception ex ) {
                    MessageDialog.Show( ex.ToString(), "Soporte de Sistema", MessageDialogButtons.OK, MessageDialogIcon.Error );
                }
            } else {
                MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error );
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ( ValidarCamposVacios() ) {
                if ( ValidarCamposCorrectos() ) {
                    try {
                        if ( isEdit == false ) {
                            puestos.Insertar(txtCargo.Text);
                            MessageDialog.Show( "Datos guardados correctamente", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                            limpiar();
                            MostrarControles( false, true );
                            dgDatos.Visible = true;
                            btnErrorMessage.Visible = false;
                            metodos.MostrarCargos( dgDatos, true );
                            metodos.AuditPuestos( dgAuditoria );
                        } else {
                            puestos.Actualizar( int.Parse(txtCodigo.Text), txtCargo.Text );
                            MessageDialog.Show( "Datos Actualizados correctamente", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                            limpiar();
                            MostrarControles( false, true );
                            dgDatos.Visible = true;
                            btnErrorMessage.Visible = false;
                            metodos.MostrarCargos( dgDatos, true );
                            metodos.AuditPuestos( dgAuditoria );
                        }
                    } catch ( Exception ex ) {
                        MessageDialog.Show( "Error en el servidor: " + ex.Message, "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error );
                    }
                } else {
                    validaciones.msgError( "Los campos tienen un formato incorrecto", btnErrorMessage );
                }
            } else {
                validaciones.msgError("No puede dejar los campos vacios", btnErrorMessage);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgDatos.Visible = true;
            MostrarControles(false, true);
            btnErrorMessage.Visible = false;
        }

        private void MostrarControles(bool isVisible, bool isEnable)
        {
            lblTitle.Visible = isVisible;
            //lblCodigo.Visible = isVisible;
            lblNombre.Visible = isVisible;
            //txtCodigo.Visible = isVisible;
            txtCodigo.Visible = isVisible;
            btnGuardar.Visible = isVisible;
            btnCancelar.Visible = isVisible;
            //label1.Visible = isEnable;

            btnBuscar.Visible = isEnable;
            btnNuevo.Visible = isEnable;
            btnEditar.Visible = isEnable;
            btnEliminar.Visible = isEnable;
        }

        private void limpiar()
        {
            txtCodigo.Clear();
            txtCargo.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = true;
            txtBuscar.Focus();
            txtBuscar.FillColor = Temas.Buscar;
            btnBuscar.BackColor = Temas.Buscar;
        }

        private void frmPuestos_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = false;
            btnBuscar.BackColor = Temas.pnlDesktop;
        }

        private void frmPuestos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtBuscar.Visible = false;
                btnBuscar.BackColor = Temas.pnlDesktop;
            }
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            btnErrorMessage.Visible = false;
        }

        private void txtCargo_TextChanged_1( object sender, EventArgs e ) {
            validaciones.SoloLetrasColor(txtCargo.Text, lblMensaje, txtCargo);
            btnErrorMessage.Visible = false;
        }

        private bool ValidarCamposVacios() {
            if ( !validaciones.camposVacios( txtCargo.Text, btnErrorMessage ) ) {
                txtCargo.Focus();
                return false;
            } else {
                return true;
            }

        }

        private bool ValidarCamposCorrectos() {
            if ( !validaciones.SoloLetrasColor( txtCargo.Text, lblMensaje, txtCargo ) ) {
                return false;
            }
            return true;
        }

        private void txtBuscar_TextChanged_1( object sender, EventArgs e ) {
            if ( tcGeneral.SelectedIndex == 0 ) {
                search.buscarPuestos( true, txtBuscar.Text, dgDatos );
            } else if ( tcGeneral.SelectedIndex == 1 ) {
                search.buscarPuestos( false, txtBuscar.Text, dgEliminados );
            }
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
                            var puesto = dgEliminados.CurrentRow.Cells[ 1 ].Value.ToString();
                            var estado = dgEliminados.CurrentRow.Cells[ 2 ].Value.ToString();

                            puestos.Actualizar( int.Parse( cod ), puesto );
                            metodos.MostrarCargos( dgDatos, true );
                            metodos.MostrarCargos( dgEliminados, false );
                            metodos.AuditPuestos( dgAuditoria );
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
