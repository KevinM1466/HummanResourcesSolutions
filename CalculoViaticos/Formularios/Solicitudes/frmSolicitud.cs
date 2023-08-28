using CalculoViaticos.Formularios;

using Clases;
using Common.cache;
using Domain;
using Domain.CRUDS;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TecnasaApp.Formularios.General.Vacaciones
{
    public partial class frmSolicitud : Form
    {
        MetodosListados metodos = new MetodosListados();
        SolicitudD solicitud = new SolicitudD();
        Validaciones validaciones = new Validaciones();
        userModel envioSolicitud = new userModel();
        WaitFormFunc wait = new WaitFormFunc(); 
        public frmSolicitud()
        {
            InitializeComponent();
        }

        private void frmSolicitud_Load(object sender, EventArgs e)
        {
            txtEmpleado.Text = UserLoginCache.firstName + " " + UserLoginCache.lastName;
            txtEmpleadoID.Text = UserLoginCache.empleadoID.ToString();
            dtpEfectiva.Value = DateTime.Today;
            dtpInicio.Value = DateTime.Today;
            dtpFinal.Value = DateTime.Today;
            dtpReingreso.Value = DateTime.Today;

            if ( CalculoViaticos.Properties.Settings.Default.Tema != "" ) {
                CambiarTema( CalculoViaticos.Properties.Settings.Default.Tema );
            } else {
                CambiarTema( "Tecnasa" );
            }
        }

        public void CambiarTema( string tema ) {
            Temas.ElegirTema( tema );
            this.BackColor = Temas.pnlDesktop;
            //Labels
            label1.ForeColor = Temas.fuenteTitulos;
            label8.ForeColor = Temas.fuenteTitulos;
            label9.ForeColor = Temas.fuenteTitulos;
            label10.ForeColor = Temas.fuenteTitulos;
            label11.ForeColor = Temas.fuenteTitulos;
            label12.ForeColor = Temas.fuenteTitulos;
            label2.ForeColor = Temas.fuenteTitulos;
            label7.ForeColor = Temas.fuenteTitulos;
            label6.ForeColor = Temas.fuenteTitulos;

            //buttons
            btnEnviarSolicitud.BackColor = Temas.buttonsColor;
            btnErrorMessage.ForeColor = Temas.fuenteTitulos;
        }

        private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoVacaciones.SelectedIndex == 0)
                {
                    MessageDialog.Show("Debe seleccionar el tipo de solicitud\n que desea procesar", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information);
                } else
                {
                    if (dtpInicio.Value <= DateTime.Today)
                    {
                        MessageDialog.Show("La fecha de inicio no puede ser menor o igual a la fecha actual", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error);
                    }
                    else if (dtpInicio.Value > dtpFinal.Value || dtpInicio.Value >= dtpReingreso.Value)
                    {
                        MessageDialog.Show("La fecha de inicio no puede ser mayor a la fecha final \n ni mayor o igual a la fecha de regreso", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error);
                    }
                    else if (dtpFinal.Value < dtpInicio.Value || dtpFinal.Value >= dtpReingreso.Value)
                    {
                        MessageDialog.Show("La fecha final no puede ser menor a la fecha de inicio \n ni tampoco puede ser mayor o igual regreso", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error);
                    }
                    else if (dtpReingreso.Value <= dtpInicio.Value || dtpReingreso.Value <= dtpFinal.Value)
                    {
                        MessageDialog.Show("La fecha de regreso no puede ser menor o igual a la fecha de inicio \n ni tampoco menor o igual a la fecha final", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Error);
                    } else
                    {
                        if (cmbTipoVacaciones.SelectedIndex == 2)
                        {
                            if (validaciones.camposVacios(txtMotivo.Text, btnErrorMessage))
                            {
                                solicitud.Insertar(cmbTipoVacaciones.Text, int.Parse(txtEmpleadoID.Text), dtpEfectiva.Value, dtpInicio.Value, dtpFinal.Value, dtpReingreso.Value, chkRemunerado.Checked, txtMotivo.Text);
                                envioSolicitud.MessageRecursosHumanos(UserLoginCache.correoAdmin.ToString());
                                MessageDialog.Show("Datos guardados con exito", "Soporte de Sistema", MessageDialogButtons.OK, MessageDialogIcon.Information);
                            }
                        }
                        else
                        {
                            solicitud.Insertar(cmbTipoVacaciones.Text, int.Parse(txtEmpleadoID.Text), dtpEfectiva.Value, dtpInicio.Value, dtpFinal.Value, dtpReingreso.Value, chkRemunerado.Checked, txtMotivo.Text);
                            envioSolicitud.MessageRecursosHumanos(UserLoginCache.correoAdmin.ToString());
                            MessageDialog.Show("Datos guardados con exito", "Soporte de Sistema", MessageDialogButtons.OK, MessageDialogIcon.Information);
                        }
                    }
                }
                
            }
            catch (SqlException ex)
            {
                var mensage = ex.Message;
                MessageDialog.Show(mensage, "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Warning);
            }
        }

        private void cmbTipoVacaciones_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (cmbTipoVacaciones.SelectedIndex == 0)
            {
                dtpInicio.Enabled = false;
                dtpFinal.Enabled = false;
                dtpReingreso.Enabled = false;

                txtMotivo.Enabled = false;
            }
            if (cmbTipoVacaciones.SelectedIndex == 1)
            {
                dtpInicio.Enabled = true;
                dtpFinal.Enabled = true;
                dtpReingreso.Enabled = true;

                txtMotivo.Enabled = false;
            }
            else if (cmbTipoVacaciones.SelectedIndex == 2)
            {
                dtpInicio.Enabled = true;
                dtpFinal.Enabled = true;
                dtpReingreso.Enabled = true;
                txtMotivo.Enabled = true;
            }


        }
    }
}
