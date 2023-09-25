using CalculoViaticos.Formularios.Empleados;

using Clases;

using Domain;
using Domain.CRUDS;

using Guna.UI2.WinForms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TecnasaApp.Formularios.General.Empleados {
    public partial class frmJefesDirectos : Form {
        JefesD jefes = new JefesD();
        MetodosListados metodos = new MetodosListados();
        Validaciones validaciones = new Validaciones();
        searchModel search = new searchModel();
        bool isEdit = false;

        public frmJefesDirectos() {
            InitializeComponent();
        }

        private void frmJefesDirectos_Load( object sender, EventArgs e ) {
            metodos.MostrarJefes( dgDatos, true );
            metodos.MostrarJefes( dgEliminados, false );
            metodos.ListarDepartamentos( cmbDepartamentos );
            metodos.AuditJefes( dgAuditoria );

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
            label3.ForeColor = Temas.fuenteTitulos;
            lblTitle.ForeColor = Temas.fuenteTitulos;
            lblNombre.ForeColor = Temas.fuenteTitulos;
            lblImagen.ForeColor = Temas.fuenteTitulos;
            lblName.ForeColor = Temas.fuenteTitulos;

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
            bool isEnable = bool.Parse( dgDatos.CurrentRow.Cells[ 7 ].Value.ToString() );
            if ( dgDatos.Rows.Count > 0 ) {
                dgDatos.Visible = false;
                txtCodigo.Text = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
                txtEmpleadoID.Text = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
                txtEmpleado.Text = dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();
                cmbDepartamentos.Text = dgDatos.CurrentRow.Cells[ 4 ].Value.ToString();
                picImage.Image = Image.FromStream( ByteImage() );
                lblName.Text = dgDatos.CurrentRow.Cells[ 6 ].Value.ToString();
                MostrarControles( true, false );
                isEdit = true;
            } else {
                MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error );
            }
        }

        private MemoryStream ByteImage() {
            byte[] img = (byte[])dgDatos.CurrentRow.Cells[ 5 ].Value;
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
                            var empleado = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
                            var departamento = dgDatos.CurrentRow.Cells[ 3 ].Value.ToString();
                            var nombreArchivo = dgDatos.CurrentRow.Cells[ 6 ].Value.ToString();

                            jefes.Eliminar( int.Parse( cod ), int.Parse( empleado ), int.Parse( departamento ), ConvertirImg(), nombreArchivo );
                            metodos.MostrarJefes( dgDatos, true );
                            metodos.MostrarJefes( dgEliminados, false );
                            metodos.AuditJefes( dgAuditoria );
                        }
                    }
                } catch ( Exception ex ) {
                    MessageDialog.Show( ex.ToString(), "Soporte de Sistema", MessageDialogButtons.OK, MessageDialogIcon.Error );
                }
            } else {
                MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error );
            }
        }

        private byte[] ConvertirImg() {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picImage.Image.Save( ms, System.Drawing.Imaging.ImageFormat.Jpeg );
            return ms.GetBuffer();
        }

        private void btnGuardar_Click( object sender, EventArgs e ) {
            if ( txtEmpleado.Text != "" || cmbDepartamentos.Text != "" ) {
                if ( lblName.Text != "No se elijio archivo" ) {
                    try {
                        if ( isEdit == false ) {
                            jefes.Insertar( int.Parse( txtEmpleadoID.Text ), int.Parse( cmbDepartamentos.SelectedValue.ToString() ), ConvertirImg(), lblName.Text );
                            MessageDialog.Show( "Datos guardados con exito", "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Information );
                            limpiar();
                            MostrarControles( false, true );
                            dgDatos.Visible = true;
                            metodos.MostrarJefes( dgDatos, true );
                            metodos.AuditJefes( dgAuditoria );
                        } else {
                            jefes.Actualizar( int.Parse( txtCodigo.Text ), int.Parse( txtEmpleadoID.Text ), int.Parse( cmbDepartamentos.SelectedValue.ToString() ), ConvertirImg(), lblName.Text );
                            MessageDialog.Show( "Datos guardados con exito", "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Information );
                            limpiar();
                            MostrarControles( false, true );
                            dgDatos.Visible = true;
                            metodos.MostrarJefes( dgDatos, true );
                            metodos.AuditJefes( dgAuditoria );
                        }
                    } catch ( Exception ex ) {
                        MessageDialog.Show( "Error en el servidor: " + ex.Message, "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error );
                    }
                } else {
                    validaciones.msgError( "Debe elejir una imagen con la firma", btnErrorMessage );
                }
            } else {
                validaciones.msgError( "No puede dejar campos vacios", btnErrorMessage );
            }
        }

        private void btnCancelar_Click( object sender, EventArgs e ) {
            dgDatos.Visible = true;
            limpiar();
            MostrarControles( false, true );
            //swtMostrarEliminados.Checked = true;
        }

        private void MostrarControles( bool isVisible, bool isEnable ) {
            lblTitle.Visible = isVisible;
            //lblCodigo.Visible = isVisible;
            lblNombre.Visible = isVisible;
            lblName.Visible = isVisible;
            lblImagen.Visible = isVisible;
            //txtCodigo.Visible = isVisible;
            txtEmpleado.Visible = isVisible;
            btnGuardar.Visible = isVisible;
            btnBuscarEmpleado.Visible = isVisible;
            btnCancelar.Visible = isVisible;
            //label1.Visible = isEnable;

            btnBuscar.Visible = isEnable;
            btnNuevo.Visible = isEnable;
            btnEditar.Visible = isEnable;
            btnEliminar.Visible = isEnable;
        }

        private void limpiar() {
            txtCodigo.Clear();
            txtEmpleadoID.Clear();
            txtEmpleado.Clear();
            cmbDepartamentos.StartIndex = -1;
            lblName.Text = "No se elijio archivo";
        }

        private void btnBuscar_Click_1( object sender, EventArgs e ) {
            txtBuscar.Visible = true;
            txtBuscar.Focus();
            txtBuscar.FillColor = Temas.Buscar;
            btnBuscar.BackColor = Temas.Buscar;
        }

        private void frmJefesDirectos_Click( object sender, EventArgs e ) {
            txtBuscar.Visible = false;
            btnBuscar.BackColor = Temas.pnlDesktop;
        }

        private void frmJefesDirectos_KeyDown( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Escape ) {
                txtBuscar.Visible = false;
                btnBuscar.BackColor = Temas.pnlDesktop;
            }
        }

        private void btnSeleccionar_Click( object sender, EventArgs e ) {
            //openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Imagenes (*.jpeg;*jpg;*png)|*.jpeg;*jpg;*png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if ( openFileDialog1.ShowDialog() == DialogResult.OK ) {
                picImage.Image = Image.FromFile( openFileDialog1.FileName );
                lblName.Text = openFileDialog1.SafeFileName;
            }
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
                AddOwnedForm( frm );
                frm.ShowDialog();

                formBG.Dispose();
            }
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e ) {
            if ( tcGeneral.SelectedIndex == 0 ) {
                search.buscarJefes( txtBuscar.Text, true, dgDatos );
            } else {
                search.buscarJefes( txtBuscar.Text, false, dgEliminados );
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
                            var empleado = dgEliminados.CurrentRow.Cells[ 1 ].Value.ToString();
                            var departamento = dgEliminados.CurrentRow.Cells[ 3 ].Value.ToString();
                            var nombreArchivo = dgEliminados.CurrentRow.Cells[ 6 ].Value.ToString();

                            jefes.Actualizar( int.Parse( cod ), int.Parse( empleado ), int.Parse( departamento ), ConvertirImg(), nombreArchivo );
                            metodos.MostrarJefes( dgDatos, true );
                            metodos.MostrarJefes( dgEliminados, false );
                            metodos.AuditJefes( dgAuditoria );
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
