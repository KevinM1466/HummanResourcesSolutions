using CalculoViaticos;
using CalculoViaticos.Formularios.Empleados;

using Clases;

using Common.cache;

using Domain;
using Domain.CRUDS;

using Guna.UI2.WinForms;

using iTextSharp.text.pdf.codec.wmf;

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

namespace TecnasaApp.Formularios.General.Empleados {
    public partial class frmEmpleados : Form {
        public string usuario = "";
        Clases.MetodosListados MetodosListados = new MetodosListados();
        EmpleadosD empleados = new EmpleadosD();
        searchModel searchModel = new searchModel();
        Validaciones validaciones = new Validaciones();
        bool isEdit = false;
        bool estadoBuscar = true;

        public frmEmpleados() {
            InitializeComponent();
        }

        private void frmEmpleados_Load( object sender, EventArgs e ) {
            MetodosListados.MostrarEmpleados( dgDatos, true );
            MetodosListados.MostrarEmpleados( dgDatos2, true );
            MetodosListados.MostrarEmpleados( dgEliminados, false );
            MetodosListados.AuditEmpleados( dgAuditoria );
            MetodosListados.ListarPuestos( cmbCargo );
            MetodosListados.ListarDepartamentos( cmbDepartamento );

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
            dgDatos2.BackgroundColor = Temas.pnlDesktop;
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
            lblApellido.ForeColor = Temas.fuenteTitulos;
            lblDepartamento.ForeColor = Temas.fuenteTitulos;
            lblIdentidad.ForeColor = Temas.fuenteTitulos;
            //lblMensaje.ForeColor = Temas.fuenteTitulos;
            lblMensajeNombre.ForeColor = Temas.fuenteTitulos;
            lblMensajeApellido.ForeColor = Temas.fuenteTitulos;
            lblMensajeCargo.ForeColor = Temas.fuenteTitulos;
            lblDepa.ForeColor = Temas.fuenteTitulos;

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
            isEdit = false;
        }

        private void btnEditar_Click( object sender, EventArgs e ) {
            if ( dgDatos.SelectedRows.Count > 0 ) {
                dgDatos.Visible = false;
                txtCodigo.Text = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
                txtNombre.Text = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
                txtApellido.Text = dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();
                cmbCargo.Text = dgDatos.CurrentRow.Cells[ 4 ].Value.ToString();
                picPerfil.Image = Image.FromStream( ByteImage() );
                MostrarControles( true, false );
                isEdit = true;
            } else {
                this.TopMost = false;
                MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Warning );
            }
        }

        private MemoryStream ByteImage() {
            byte[] img = (byte[])dgDatos.CurrentRow.Cells[ 7 ].Value;
            MemoryStream ms = new MemoryStream( img );
            return ms;
        }

        private void btnEliminar_Click( object sender, EventArgs e ) {
            if ( dgDatos.Rows.Count > 0 ) {
                try {
                    if ( MessageDialog.Show( "¿Quiere eliminar este registro?", "Advertencia", MessageDialogButtons.OKCancel, MessageDialogIcon.Question ) == DialogResult.OK ) {
                        frmContrasenia frm = new frmContrasenia();
                        AddOwnedForm( frm );
                        frm.ShowDialog();
                        if ( frm.habilitado == true ) {
                            var cod = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
                            var nombre = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
                            var apellido = dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();
                            var cargoID = dgDatos.CurrentRow.Cells[ 3 ].Value.ToString();
                            var departamentoID = dgDatos.CurrentRow.Cells[ 5 ].Value.ToString();
                            var fechaModi = DateTime.Now;
                            var estado = dgDatos.CurrentRow.Cells[ 8 ].Value.ToString();

                            empleados.Eliminar( int.Parse( cod ), int.Parse( cargoID ), int.Parse( departamentoID ), nombre, apellido, DateTime.Parse( fechaModi.ToString() ), false );
                            MetodosListados.MostrarEmpleados( dgDatos, true );
                            MetodosListados.MostrarEmpleados( dgEliminados, false );
                            MetodosListados.AuditEmpleados( dgAuditoria );
                        }
                    }
                } catch ( Exception ex ) {
                    MessageDialog.Show( ex.ToString(), "Soporte de Sistema", MessageDialogButtons.OK, MessageDialogIcon.Error );
                }
            } else {
                MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error );
            }
        }

        private void btnGuardar_Click( object sender, EventArgs e ) {
            if ( ValidarCamposVacios() ) {
                if ( ValidarCamposCorrectos() ) {
                    try {
                        if ( !isEdit ) {
                            empleados.Insertar( txtNombre.Text, txtApellido.Text, DateTime.Now.Date, int.Parse( cmbCargo.SelectedValue.ToString() ), int.Parse( cmbDepartamento.SelectedValue.ToString() ), ConvertirImg(), DateTime.Now.Date, true );
                            this.TopMost = false;
                            MessageDialog.Show( "Datos guardados correctamente", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                            limpiar();
                            MostrarControles( false, true );
                            dgDatos.Visible = true;
                            btnErrorMessage.Visible = false;
                            MetodosListados.MostrarEmpleados( dgDatos, true );
                        } else {
                            empleados.Actualizar( int.Parse( txtCodigo.Text ), txtNombre.Text, txtApellido.Text, int.Parse( cmbCargo.SelectedValue.ToString() ), int.Parse( cmbDepartamento.SelectedValue.ToString() ), ConvertirImg(), DateTime.Now.Date, true );
                            this.TopMost = false;
                            MessageDialog.Show( "Datos actualizados correctamente", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                            limpiar();
                            MostrarControles( false, true );
                            dgDatos.Visible = true;
                            btnErrorMessage.Visible = false;
                            MetodosListados.MostrarEmpleados( dgDatos, true );
                        }
                    } catch ( Exception ex ) {
                        MessageDialog.Show( "Error en el servidor: " + ex.Message, "Error", MessageDialogButtons.OK, MessageDialogIcon.Error );
                    }
                } else {
                    validaciones.msgError( "Los campos contiene un formato erroneo", btnErrorMessage );
                }
            } else {
                validaciones.msgError( "No puede dejar campos vacios", btnErrorMessage );
            }
        }

        private void btnCancelar_Click( object sender, EventArgs e ) {
            dgDatos.Visible = true;
            MostrarControles( false, true );
            ocultarErrors();
        }

        private void btnBuscar_Click_1( object sender, EventArgs e ) {
            txtBuscar.Visible = true;
            txtBuscar.Focus();
            txtBuscar.FillColor = Temas.Buscar;
            btnBuscar.BackColor = Temas.Buscar;
        }


        private void MostrarControles( bool isVisible, bool isEnable ) {
            lblTitle.Visible = isVisible;
            //lblCodigo.Visible = isVisible;
            lblDepartamento.Visible = isVisible;
            lblNombre.Visible = isVisible;
            lblIdentidad.Visible = isVisible;
            //txtCodigo.Visible = isVisible;
            txtNombre.Visible = isVisible;
            btnGuardar.Visible = isVisible;
            btnCancelar.Visible = isVisible;
            //label1.Visible = isEnable;
            txtApellido.Visible = isVisible;
            lblApellido.Visible = isVisible;
            cmbCargo.Visible = isVisible;
            cmbDepartamento.Visible = isVisible;
            picPerfil.Visible = isVisible;
            btnAddImage.Visible = isVisible;

            btnBuscar.Visible = isEnable;
            btnNuevo.Visible = isEnable;
            btnEditar.Visible = isEnable;
            btnEliminar.Visible = isEnable;
        }

        private void limpiar() {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            picPerfil.Image = picPerfil.InitialImage;
        }

        private void ocultarErrors() {
            btnErrorMessage.Visible = false;
        }

        private byte[] ConvertirImg() {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picPerfil.Image.Save( ms, System.Drawing.Imaging.ImageFormat.Jpeg );
            return ms.GetBuffer();
        }

        private void btnAddImage_Click_1( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if ( dr == DialogResult.OK ) {
                picPerfil.Image = Image.FromFile( ofd.FileName );
            }
        }

        private void frmEmpleados_Click( object sender, EventArgs e ) {
            txtBuscar.Visible = false;
            btnBuscar.BackColor = Temas.pnlDesktop;
        }

        private void frmEmpleados_KeyDown( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Escape ) {
                txtBuscar.Visible = false;
                btnBuscar.BackColor = Temas.pnlDesktop;
            }
        }

        private void txtNombre_TextChanged_1( object sender, EventArgs e ) {
            validaciones.SoloLetrasColor( txtNombre.Text, lblMensajeNombre, txtNombre );
            btnErrorMessage.Visible = false;
        }

        private void txtApellido_TextChanged_1( object sender, EventArgs e ) {
            validaciones.SoloLetrasColor( txtApellido.Text, lblMensajeApellido, txtApellido );
            btnErrorMessage.Visible = false;
        }

        private void dgDatos_CellDoubleClick( object sender, DataGridViewCellEventArgs e ) {
            try {
                frmJefesDirectos frm = (frmJefesDirectos)Owner;
                if ( frm != null ) {
                    frm.txtEmpleadoID.Text = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
                    frm.txtEmpleado.Text = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString() + " " + dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();
                    this.Close();
                }
            } catch ( Exception ) {
                MessageDialog.Show( "No puede seleccionar estos datos", "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Information );
            }
        }

        private void dgDatos2_CellDoubleClick( object sender, DataGridViewCellEventArgs e ) {
            try {
                frmUsuarios frm2 = (frmUsuarios)Owner;
                if ( frm2 != null ) {
                    frm2.txtEmpleadoID.Text = dgDatos2.CurrentRow.Cells[ 0 ].Value.ToString();
                    frm2.txtEmpleado.Text = dgDatos2.CurrentRow.Cells[ 1 ].Value.ToString() + " " + dgDatos2.CurrentRow.Cells[ 2 ].Value.ToString();
                    this.Close();
                }
            } catch ( Exception ) {
                MessageDialog.Show( "No puede seleccionar estos datos", "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Information );
            }
        }

        private void guna2ControlBox1_Click( object sender, EventArgs e ) {

        }

        private void txtBuscar_TextChanged( object sender, EventArgs e ) {
            if ( tcGeneral.SelectedIndex == 0 ) {
                searchModel.buscarEmpleado( txtBuscar.Text, txtBuscar.Text, txtBuscar.Text, true, dgDatos );
            } else {
                searchModel.buscarEmpleado( txtBuscar.Text, txtBuscar.Text, txtBuscar.Text, false, dgEliminados );
            }
        }

        private bool ValidarCamposVacios() {
            if ( !validaciones.camposVacios( txtNombre.Text, btnErrorMessage ) ) {
                txtNombre.Focus();
                return false;
            } else if ( !validaciones.camposVacios( txtApellido.Text, btnErrorMessage ) ) {
                txtApellido.Focus();
                return false;
            } else if ( !validaciones.camposVacios( cmbCargo.Text, btnErrorMessage ) ) {
                cmbCargo.Focus();
                return false;
            } else if ( !validaciones.camposVacios( cmbDepartamento.Text, btnErrorMessage ) ) {
                cmbDepartamento.Focus();
                return false;
            } else {
                return true;
            }

        }

        private bool ValidarCamposCorrectos() {
            if ( !validaciones.SoloLetrasColor( txtNombre.Text, lblMensajeNombre, txtNombre ) ) {
                return false;
            } else if ( !validaciones.SoloLetrasColor( txtApellido.Text, lblMensajeApellido, txtApellido ) ) {
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
                            var nombre = dgEliminados.CurrentRow.Cells[ 1 ].Value.ToString();
                            var apellido = dgEliminados.CurrentRow.Cells[ 2 ].Value.ToString();
                            var cargoID = dgEliminados.CurrentRow.Cells[ 3 ].Value.ToString();
                            var departamentoID = dgEliminados.CurrentRow.Cells[ 5 ].Value.ToString();
                            var fechaModi = DateTime.Now;
                            var estado = dgEliminados.CurrentRow.Cells[ 8 ].Value.ToString();

                            empleados.Actualizar( int.Parse( cod ), nombre, apellido, int.Parse( cargoID ), int.Parse( departamentoID ), ConvertirImg(), DateTime.Parse( fechaModi.ToString() ), true );
                            MetodosListados.MostrarEmpleados( dgDatos, true );
                            MetodosListados.MostrarEmpleados( dgEliminados, false );
                            MetodosListados.AuditEmpleados( dgAuditoria );
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
