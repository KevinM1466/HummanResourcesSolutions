using CalculoViaticos;
using Clases;
using Common.cache;
using Domain;
using Domain.CRUDS;
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

namespace TecnasaApp.Formularios.General.Empleados
{
    public partial class frmEmpleados : Form
    {
        Clases.MetodosListados MetodosListados = new MetodosListados();
        EmpleadosD EmpleadosD = new EmpleadosD();
        searchModel searchModel = new searchModel();
        Validaciones validaciones = new Validaciones();
        bool isEdit = false;

        public frmEmpleados()
        {
            InitializeComponent();
        }
        bool estadoBuscar = true;

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            MetodosListados.MostrarEmpleados(dgDatos, true);
            MetodosListados.ListarPuestos(cmbCargo);
            MetodosListados.ListarDepartamentos(cmbDepartamento);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgDatos.Visible = false;
            MostrarControles(true, false);
            limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool isEnable = bool.Parse(dgDatos.CurrentRow.Cells[8].Value.ToString());
            if (isEnable == true)
            {
                dgDatos.Visible = false;
                txtCodigo.Text = dgDatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgDatos.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dgDatos.CurrentRow.Cells[2].Value.ToString();
                cmbCargo.Text = dgDatos.CurrentRow.Cells[4].Value.ToString();
                picPerfil.Image = Image.FromStream(ByteImage());
                MostrarControles(true, false);
                swtHabilitado.Visible = false;
                isEdit = true;
            } else
            {
                dgDatos.Visible = false;
                txtCodigo.Text = dgDatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgDatos.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dgDatos.CurrentRow.Cells[2].Value.ToString();
                cmbCargo.Text = dgDatos.CurrentRow.Cells[4].Value.ToString();
                picPerfil.Image = Image.FromStream(ByteImage());
                MostrarControles(true, false);
                swtHabilitado.Visible = true;
                isEdit = true;
            }
        }

        private MemoryStream ByteImage()
        {
            byte[] img = (byte[])dgDatos.CurrentRow.Cells[7].Value;
            MemoryStream ms = new MemoryStream(img);
            return ms;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmContrasenia frm = new frmContrasenia();
            AddOwnedForm(frm);
            frm.ShowDialog();

            if (frm.habilitado == true)
            {
                try
                {
                    if (MessageDialog.Show("¿Quiere eliminar este registro?", "Advertencia", MessageDialogButtons.OKCancel, MessageDialogIcon.Question) == DialogResult.OK)
                    {
                        var cod = dgDatos.CurrentRow.Cells[0].Value.ToString();
                        var nombre = dgDatos.CurrentRow.Cells[1].Value.ToString();
                        var apellido = dgDatos.CurrentRow.Cells[2].Value.ToString();
                        var cargoID = dgDatos.CurrentRow.Cells[3].Value.ToString();
                        var departamentoID = dgDatos.CurrentRow.Cells[5].Value.ToString();
                        var fechaModi = DateTime.Now;
                        var estado = dgDatos.CurrentRow.Cells[8].Value.ToString();

                        EmpleadosD.Eliminar(int.Parse(cod), int.Parse(cargoID), int.Parse(departamentoID), nombre, apellido, DateTime.Parse(fechaModi.ToString()), false);
                        MetodosListados.MostrarEmpleados(dgDatos, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageDialog.Show(ex.ToString(), "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == string.Empty || txtApellido.Text == string.Empty)
                {
                    validaciones.msgError("No puede dejar campos vacios", btnErrorMessage);
                } else
                {
                    if (isEdit == false)
                    {
                        try
                        {
                            if (validaciones.SoloLetras(txtNombre.Text, btnErrorMessage) == true && validaciones.SoloLetras(txtApellido.Text, btnErrorMessage) == true)
                            {
                                EmpleadosD.Insertar(txtNombre.Text, txtApellido.Text, DateTime.Now, int.Parse(cmbCargo.SelectedValue.ToString()), int.Parse(cmbDepartamento.SelectedValue.ToString()), ConvertirImg(), DateTime.Now, true);
                                MessageDialog.Show("Datos guardados con exito", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information);
                                limpiar();
                                MostrarControles(false, true);
                                dgDatos.Visible = true;
                                ocultarErrors();
                                swtMostrarEliminados.Checked = false;
                                MetodosListados.MostrarEmpleados(dgDatos, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageDialog.Show(ex.ToString(), "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Error);
                        }
                    }

                    if (isEdit == true)
                    {
                        try
                        {
                            if (validaciones.SoloLetras(txtNombre.Text, btnErrorMessage) == true && validaciones.SoloLetras(txtApellido.Text, btnErrorMessage) == true)
                            {
                                frmPrincipal frm = new frmPrincipal();

                                EmpleadosD.Actualizar(int.Parse(txtCodigo.Text), txtNombre.Text, txtApellido.Text, int.Parse(cmbCargo.SelectedValue.ToString()), int.Parse(cmbDepartamento.SelectedValue.ToString()), ConvertirImg(), DateTime.Now, swtHabilitado.Checked);
                                MessageDialog.Show("Datos guardados con exito", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information);
                                isEdit = false;
                                limpiar();
                                MostrarControles(false, true);
                                dgDatos.Visible = true;
                                ocultarErrors();
                                swtMostrarEliminados.Checked = false;
                                MetodosListados.MostrarEmpleados(dgDatos, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageDialog.Show(ex.ToString(), "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgDatos.Visible = true;
            MostrarControles(false, true);
            ocultarErrors();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            txtBuscar.Visible = true;
            txtBuscar.Focus();
            txtBuscar.FillColor = Color.FromArgb(26, 25, 62);
            btnBuscar.BackColor = Color.FromArgb(26, 25, 62);
        }


        private void MostrarControles(bool isVisible, bool isEnable)
        {
            lblTitle.Visible = isVisible;
            //lblCodigo.Visible = isVisible;
            lblDepartamento.Visible = isVisible;
            lblNombre.Visible = isVisible;
            lblIdentidad.Visible = isVisible;
            //txtCodigo.Visible = isVisible;
            txtNombre.Visible = isVisible;
            btnGuardar.Visible = isVisible;
            btnCancelar.Visible = isVisible;
            label1.Visible = isEnable;
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
            swtMostrarEliminados.Visible = isEnable;
        }

        private void limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
        }
        
        private void ocultarErrors()
        {
            btnErrorMessage.Visible = false;
        }

        private byte[] ConvertirImg()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picPerfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.GetBuffer();
        }

        private void btnAddImage_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                picPerfil.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void frmEmpleados_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = false;
            btnBuscar.BackColor = Color.FromArgb(34, 33, 74);
        }

        private void frmEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtBuscar.Visible = false;
                btnBuscar.BackColor = Color.FromArgb(34, 33, 74);
            }
        }

        private void txtNombre_TextChanged_1(object sender, EventArgs e)
        {
            btnErrorMessage.Visible = false;
        }

        private void txtApellido_TextChanged_1(object sender, EventArgs e)
        {
            btnErrorMessage.Visible = false;
        }

        private void dgDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmJefesDirectos frm = (frmJefesDirectos)Owner;
                if (frm != null)
                {
                    frm.txtEmpleadoID.Text = dgDatos.CurrentRow.Cells[0].Value.ToString();
                    frm.txtEmpleado.Text = dgDatos.CurrentRow.Cells[1].Value.ToString() + " " + dgDatos.CurrentRow.Cells[2].Value.ToString();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageDialog.Show("No puede seleccionar estos datos", "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Information);
            }
        }

        private void Inactivos()

        {
            if (swtMostrarEliminados.Checked == false)
            {
                MetodosListados.MostrarEmpleados(dgDatos, true);
                estadoBuscar = true;
            }
            else
            {
                MetodosListados.MostrarEmpleados(dgDatos, false);
                estadoBuscar = false;
            }
        }

        private void swtMostrarEliminados_Click(object sender, EventArgs e)
        {
            if (swtMostrarEliminados.Checked)
            {
                frmContrasenia frm = new frmContrasenia();
                AddOwnedForm(frm);
                frm.ShowDialog();

                if (frm.habilitado == false)
                {
                    swtMostrarEliminados.Checked = false;
                }
            }
            Inactivos();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            searchModel.buscarEmpleado(txtBuscar.Text, txtBuscar.Text, txtBuscar.Text, estadoBuscar, dgDatos);
        }
    }
}
