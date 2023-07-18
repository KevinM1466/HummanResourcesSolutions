using Clases;
using Domain.CRUDS;
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
        bool isEdit = false;
        public frmPuestos()
        {
            InitializeComponent();
        }

        private void frmPuestos_Load(object sender, EventArgs e)
        {
            metodos.MostrarCargos(dgDatos);
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
            txtCodigo.Text = dgDatos.CurrentRow.Cells[1].Value.ToString();
            MostrarControles(true, false);
            isEdit = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Quiere eliminar este registro?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var cod = dgDatos.CurrentRow.Cells[0].Value.ToString();
                    var cargo = dgDatos.CurrentRow.Cells[1].Value.ToString();

                    puestos.Eliminar(int.Parse(cod), cargo);
                    metodos.MostrarCargos(dgDatos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Soporte de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == string.Empty)
            {
                validaciones.msgError("No puede dejar los campos vacios", btnErrorMessage);
            } else
            {
                if (validaciones.SoloLetras(txtCodigo.Text, btnErrorMessage))
                {
                    if (isEdit == false)
                    {
                        try
                        {
                            puestos.Insertar(txtCodigo.Text);
                            MessageBox.Show("Datos guardados con exito", "Soporte de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiar();
                            MostrarControles(false, true);
                            dgDatos.Visible = true;
                            btnErrorMessage.Visible = true;
                            metodos.MostrarCargos(dgDatos);
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
                            puestos.Actualizar(int.Parse(txtCodigo.Text), txtCodigo.Text);
                            MessageBox.Show("Datos guardados con exito", "Soporte de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            isEdit = false;
                            limpiar();
                            MostrarControles(false, true);
                            dgDatos.Visible = true;
                            btnErrorMessage.Visible = true;
                            metodos.MostrarCargos(dgDatos);
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
            txtCodigo.Visible = isVisible;
            btnGuardar.Visible = isVisible;
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
            txtCodigo.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = true;
            txtBuscar.Focus();
            txtBuscar.FillColor = Color.FromArgb(26, 25, 62);
            btnBuscar.BackColor = Color.FromArgb(26, 25, 62);
        }

        private void frmPuestos_Click(object sender, EventArgs e)
        {
            txtBuscar.Visible = false;
            btnBuscar.BackColor = Color.FromArgb(34, 33, 74);
        }

        private void frmPuestos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtBuscar.Visible = false;
                btnBuscar.BackColor = Color.FromArgb(34, 33, 74);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            btnErrorMessage.Visible = false;
        }
    }
}
