using CalculoViaticos.Formularios.Empleados;
using Clases;
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

namespace TecnasaApp.Formularios.General.Empleados
{
    public partial class frmJefesDirectos : Form
    {
        JefesD jefes = new JefesD();
        MetodosListados metodos = new MetodosListados();
        bool isEdit = false;

        public frmJefesDirectos()
        {
            InitializeComponent();
        }

        private void frmJefesDirectos_Load(object sender, EventArgs e)
        {
            metodos.MostrarJefes(dgDatos);
            metodos.ListarDepartamentos(cmbDepartamentos);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgDatos.Visible = false;
            MostrarControles(true, false);
            limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dgDatos.Visible = false;
            txtCodigo.Text = dgDatos.CurrentRow.Cells[0].Value.ToString();
            txtEmpleadoID.Text = dgDatos.CurrentRow.Cells[1].Value.ToString();
            txtEmpleado.Text = dgDatos.CurrentRow.Cells[2].Value.ToString();
            cmbDepartamentos.Text = dgDatos.CurrentRow.Cells[4].Value.ToString();
            picImage.Image = Image.FromStream(ByteImage());
            lblName.Text = dgDatos.CurrentRow.Cells[6].Value.ToString();
            MostrarControles(true, false);
            isEdit = true;
        }

        private MemoryStream ByteImage()
        {
            byte[] img = (byte[])dgDatos.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(img);
            return ms;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageDialog.Show("¿Quiere eliminar este registro?", "Advertencia", MessageDialogButtons.OKCancel, MessageDialogIcon.Question) == DialogResult.OK)
                {
                    var cod = dgDatos.CurrentRow.Cells[0].Value.ToString();
                    var empleado = dgDatos.CurrentRow.Cells[1].Value.ToString();
                    var departamento = dgDatos.CurrentRow.Cells[3].Value.ToString();

                    jefes.Eliminar(int.Parse(cod), int.Parse(empleado), int.Parse(departamento), ConvertirImg(), lblName.Text);
                    metodos.MostrarJefes(dgDatos);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.ToString(), "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Error);
            }
        }

        private byte[] ConvertirImg()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.GetBuffer();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lblName.Text == "No se elijio archivo")
            {
                MessageDialog.Show("Debe seleccionar una imagen con la firma", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Warning);
            } else
            {
                if (isEdit == false)
                {
                    try
                    {
                        jefes.Insertar(int.Parse(txtEmpleadoID.Text), int.Parse(cmbDepartamentos.SelectedValue.ToString()), ConvertirImg(), lblName.Text);
                        MessageDialog.Show("Datos guardados con exito", "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Information);
                        limpiar();
                        MostrarControles(false, true);
                        dgDatos.Visible = true;
                        metodos.MostrarJefes(dgDatos);
                    }
                    catch (SqlException)
                    {
                        MessageDialog.Show("No puede asignar a " + txtEmpleado.Text + " \ncomo jefe de " + cmbDepartamentos.Text + "\nporque ya esta asigando en otro departamento", "Soporte de Sistema", MessageDialogButtons.OK, MessageDialogIcon.Error);
                    }
                }

                if (isEdit == true)
                {
                    try
                    {
                        jefes.Actualizar(int.Parse(txtCodigo.Text), int.Parse(txtEmpleadoID.Text), int.Parse(cmbDepartamentos.SelectedValue.ToString()), ConvertirImg(), lblName.Text);
                        MessageDialog.Show("Datos guardados con exito", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information);
                        isEdit = false;
                        limpiar();
                        MostrarControles(false, true);
                        dgDatos.Visible = true;
                        metodos.MostrarJefes(dgDatos);
                }
                    catch (Exception)
                    {
                        MessageDialog.Show("No puede asignar a " + txtEmpleado.Text + " como jefe de " + cmbDepartamentos.Text + "\nporque ya esta asigando en otro departamento", "Soporte de Sistema", MessageDialogButtons.OK, MessageDialogIcon.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgDatos.Visible = true;
            limpiar();
            MostrarControles(false, true);
        }

        private void MostrarControles(bool isVisible, bool isEnable)
        {
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
            label1.Visible = isEnable;

            btnBuscar.Visible = isEnable;
            btnNuevo.Visible = isEnable;
            btnEditar.Visible = isEnable;
            btnEliminar.Visible = isEnable;
        }

        private void limpiar()
        {
            txtCodigo.Clear();
            txtEmpleadoID.Clear();
            txtEmpleado.Clear();
            cmbDepartamentos.StartIndex = -1;
            lblName.Text = "No se elijio archivo";
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            txtBuscar.Visible = true;
            txtBuscar.Focus();
            txtBuscar.FillColor = Color.FromArgb(26, 25, 62);
            btnBuscar.BackColor = Color.FromArgb(26, 25, 62);
        }

        private void frmJefesDirectos_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = false;
            btnBuscar.BackColor = Color.FromArgb(34, 33, 74);
        }

        private void frmJefesDirectos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtBuscar.Visible = false;
                btnBuscar.BackColor = Color.FromArgb(34, 33, 74);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Imagenes (*.jpeg;*jpg;*png)|*.jpeg;*jpg;*png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(openFileDialog1.FileName);
                lblName.Text = openFileDialog1.SafeFileName;
            }
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            Form formBG = new Form();
            using (frmEmpleados frm = new frmEmpleados())
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
                frm.lblMensaje.ForeColor = Color.Red;
                frm.lblMensaje.Text = "Doble click sobre una fila para seleccionar un empleado";
                frm.lblMensaje.Visible = true;
                AddOwnedForm(frm);
                frm.ShowDialog();

                formBG.Dispose();
            }
        }
    }
}
