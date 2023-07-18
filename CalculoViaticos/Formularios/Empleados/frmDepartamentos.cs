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

namespace TecnasaApp.Formularios.General.Empleados
{
    public partial class frmDepartamentos : Form
    {
        DepartamentosD departamentos = new DepartamentosD();
        MetodosListados metodos = new MetodosListados();
        Validaciones validaciones = new Validaciones();
        searchModel searchModel = new searchModel();
        bool isEdit;

        public frmDepartamentos()
        {
            InitializeComponent();
        }
        bool estado = true;
        private void frmDepartamentos_Load(object sender, EventArgs e)
        {
            metodos.MostrarDepartamentos(dgDatos, true);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgDatos.Visible = false;
            MostrarControles(true, false);
            limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool isEnable = bool.Parse(dgDatos.CurrentRow.Cells[2].Value.ToString());
            if (isEnable == true)
            {
                dgDatos.Visible = false;
                txtCodigo.Text = dgDatos.CurrentRow.Cells[0].Value.ToString();
                txtDepartamento.Text = dgDatos.CurrentRow.Cells[1].Value.ToString();
                MostrarControles(true, false);
                isEdit = true;
            } else
            {
                dgDatos.Visible = false;
                txtCodigo.Text = dgDatos.CurrentRow.Cells[0].Value.ToString();
                txtDepartamento.Text = dgDatos.CurrentRow.Cells[1].Value.ToString();
                MostrarControles(true, false);
                swtHabilitar.Visible = true;
                isEdit = true;
            }
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
                        var nombreDeparetamento = dgDatos.CurrentRow.Cells[1].Value.ToString();
                        var cargoID = dgDatos.CurrentRow.Cells[2].Value.ToString();

                        departamentos.Eliminar(int.Parse(cod), nombreDeparetamento);
                        metodos.MostrarDepartamentos(dgDatos, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageDialog.Show("Error al realizar el proceso", "Soporte Tecnasa", MessageDialogButtons.OK, MessageDialogIcon.Error);
                }
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDepartamento.Text == string.Empty)
            {
                validaciones.msgError("No puede dejar los campos vacios", btnErrorMessage);
            } else
            {
                if (validaciones.SoloLetras(txtDepartamento.Text, btnErrorMessage))
                {
                    if (isEdit == false)
                    {
                        try
                        {
                            departamentos.Insertar(txtDepartamento.Text);
                            MessageBox.Show("Datos guardados con exito", "Soporte de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiar();
                            MostrarControles(false, true);
                            dgDatos.Visible = true;
                            btnErrorMessage.Visible = false;
                            metodos.MostrarDepartamentos(dgDatos, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Soporte de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (isEdit == true)
                    {
                        try
                        {
                            departamentos.Actualizar(int.Parse(txtCodigo.Text), txtDepartamento.Text, swtHabilitar.Checked);
                            MessageBox.Show("Datos guardados con exito", "Soporte de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isEdit = false;
                            limpiar();
                            MostrarControles(false, true);
                            dgDatos.Visible = true;
                            btnErrorMessage.Visible = false;
                            metodos.MostrarDepartamentos(dgDatos, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Soporte de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
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
            txtDepartamento.Visible = isVisible;
            btnGuardar.Visible = isVisible;
            btnCancelar.Visible = isVisible;
            label1.Visible = isEnable;

            btnBuscar.Visible = isEnable;
            btnNuevo.Visible = isEnable;
            btnEditar.Visible = isEnable;
            btnEliminar.Visible = isEnable;
            swtMostrarEliminados.Visible = isEnable;
            swtMostrarEliminados.Checked = false;
        }

        private void limpiar()
        {
            txtCodigo.Clear();
            txtDepartamento.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = true;
            txtBuscar.Focus();
            txtBuscar.FillColor = Color.FromArgb(26, 25, 62);
            btnBuscar.BackColor = Color.FromArgb(26, 25, 62);
        }

        private void frmDepartamentos_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = false;
            btnBuscar.BackColor = Color.FromArgb(34, 33, 74);
        }

        private void frmDepartamentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtBuscar.Visible = false;
                btnBuscar.BackColor = Color.FromArgb(34, 33, 74);
            }
        }

        private void swtMostrarEliminados_CheckedChanged(object sender, EventArgs e)
        {
            
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
            DepartamentosInactivos();
        }

        private void txtDepartamento_TextChanged(object sender, EventArgs e)
        {
            btnErrorMessage.Visible = false;
        }

        private void DepartamentosInactivos()
        {
            if (swtMostrarEliminados.Checked == false)
            {
                metodos.MostrarDepartamentos(dgDatos, true);
                estado = true;
            } else
            {
                metodos.MostrarDepartamentos(dgDatos, false);
                estado = false;
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
            searchModel.buscarDepartamento(estado, txtBuscar.Text, dgDatos);
        }
    }
}
