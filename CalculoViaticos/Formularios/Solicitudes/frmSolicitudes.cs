using CalculoViaticos.Formularios;
using CalculoViaticos.Reportes.Datos;
using CalculoViaticos.Reportes.Formularios;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnasaApp.Formularios.General.Empleados;

namespace TecnasaApp.Formularios.General.Solicitudes
{
    public partial class frmSolicitudes : Form
    {
        MetodosListados metodos = new MetodosListados();
        SolicitudD solicitudes = new SolicitudD();
        userModel envioCorreo = new userModel();
        WaitFormFunc wait = new WaitFormFunc();

        private bool isTrue;
        public frmSolicitudes()
        {
            InitializeComponent();
        }

        private void frmSolicitudes_Load(object sender, EventArgs e)
        {
            
            if (UserLoginCache.isJefe == true && UserLoginCache.puesto == Cargos.Administrador)
            {
                metodos.MostrarSolicitud(dgDatos, UserLoginCache.jefeID);
            }
            else if (UserLoginCache.isJefe == true)
            {
                metodos.MostrarSolicitudJefe(dgDatos, UserLoginCache.jefeID);
            }

            if (UserLoginCache.isJefe == false)
            {
                metodos.MostrarSolicitudEmpleado(dgDatos, UserLoginCache.empleadoID);
                lblTitle.Text = "Solicitudes Confirmadas";
                btnConfirmarSolicitud.Visible = false;
            }

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
            //Labels
            lblTitle.ForeColor = Temas.fuenteTitulos;
            //buttons
            btnRevisar.FillColor = Temas.buttonsColor;
            btnConfirmarSolicitud.FillColor = Temas.buttonsColor;
        }

        private void btnRevisar_Click(object sender, EventArgs e)
        {
            frmReporteSolicitud frm = new frmReporteSolicitud();
            DatosSolicitud datos = new DatosSolicitud();

            if (UserLoginCache.puesto == "Administrador")
            {
                if ( dgDatos.Rows.Count > 0 ) {
                    wait.Show( this );
                    isTrue = false;
                    datos.solicitudID = int.Parse( dgDatos.CurrentRow.Cells[ 0 ].Value.ToString() );
                    datos.empleadoID = int.Parse( dgDatos.CurrentRow.Cells[ 1 ].Value.ToString() );
                    datos.Empleado = dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();
                    datos.nombreCargo = dgDatos.CurrentRow.Cells[ 3 ].Value.ToString();
                    datos.nombreDepartamento = dgDatos.CurrentRow.Cells[ 4 ].Value.ToString();
                    datos.tipoSolicitud = dgDatos.CurrentRow.Cells[ 5 ].Value.ToString();
                    datos.fechaEfectiva = dgDatos.CurrentRow.Cells[ 6 ].Value.ToString();
                    datos.fechaInicio = dgDatos.CurrentRow.Cells[ 7 ].Value.ToString();
                    datos.fechaFinal = dgDatos.CurrentRow.Cells[ 8 ].Value.ToString();
                    datos.fechaReingreso = dgDatos.CurrentRow.Cells[ 9 ].Value.ToString();
                    datos.Remuneracion = bool.Parse( dgDatos.CurrentRow.Cells[ 10 ].Value.ToString() );
                    datos.Motivo = dgDatos.CurrentRow.Cells[ 11 ].Value.ToString();
                    datos.JefeDirecto = dgDatos.CurrentRow.Cells[ 13 ].Value.ToString();
                    datos.CorreoJefe = dgDatos.CurrentRow.Cells[ 14 ].Value.ToString();
                    //datos.firma = (byte[])dgDatos.CurrentRow.Cells[15].Value;
                    //datos.firma = UserLoginCache.firmaAdmin;
                    datos.isTrue = isTrue;
                    frm.datosSolicitud.Add( datos );
                    frm.Show();
                    Thread.Sleep( 1000 );
                    wait.Close();
                } else {
                    MessageDialog.Show("Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information);
                }
            }
            else
            {
                if ( dgDatos.Rows.Count > 0 ) {
                    wait.Show( this );
                    isTrue = true;
                    datos.solicitudID = int.Parse( dgDatos.CurrentRow.Cells[ 0 ].Value.ToString() );
                    datos.empleadoID = int.Parse( dgDatos.CurrentRow.Cells[ 1 ].Value.ToString() );
                    datos.Empleado = dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();
                    datos.nombreCargo = dgDatos.CurrentRow.Cells[ 3 ].Value.ToString();
                    datos.nombreDepartamento = dgDatos.CurrentRow.Cells[ 4 ].Value.ToString();
                    datos.tipoSolicitud = dgDatos.CurrentRow.Cells[ 5 ].Value.ToString();
                    datos.fechaEfectiva = dgDatos.CurrentRow.Cells[ 6 ].Value.ToString();
                    datos.fechaInicio = dgDatos.CurrentRow.Cells[ 7 ].Value.ToString();
                    datos.fechaFinal = dgDatos.CurrentRow.Cells[ 8 ].Value.ToString();
                    datos.fechaReingreso = dgDatos.CurrentRow.Cells[ 9 ].Value.ToString();
                    datos.Remuneracion = bool.Parse( dgDatos.CurrentRow.Cells[ 10 ].Value.ToString() );
                    datos.Motivo = dgDatos.CurrentRow.Cells[ 11 ].Value.ToString();
                    datos.JefeDirecto = dgDatos.CurrentRow.Cells[ 13 ].Value.ToString();
                    datos.CorreoJefe = dgDatos.CurrentRow.Cells[ 14 ].Value.ToString();
                    //datos.firmaJefe = (byte[])dgDatos.CurrentRow.Cells[15].Value;
                    datos.firma = UserLoginCache.firmaAdmin;
                    datos.isTrue = isTrue;
                    frm.datosSolicitud.Add( datos );
                    frm.Show();
                    Thread.Sleep( 1000 );
                    wait.Close();
                } else {
                    MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                }
            }

            if (UserLoginCache.isJefe == false)
            {
                if ( dgDatos.Rows.Count > 0 ) {
                    wait.Show( this );
                    isTrue = true;
                    datos.solicitudID = int.Parse( dgDatos.CurrentRow.Cells[ 0 ].Value.ToString() );
                    datos.empleadoID = int.Parse( dgDatos.CurrentRow.Cells[ 1 ].Value.ToString() );
                    datos.Empleado = dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();
                    datos.nombreCargo = dgDatos.CurrentRow.Cells[ 3 ].Value.ToString();
                    datos.nombreDepartamento = dgDatos.CurrentRow.Cells[ 4 ].Value.ToString();
                    datos.tipoSolicitud = dgDatos.CurrentRow.Cells[ 5 ].Value.ToString();
                    datos.fechaEfectiva = dgDatos.CurrentRow.Cells[ 6 ].Value.ToString();
                    datos.fechaInicio = dgDatos.CurrentRow.Cells[ 7 ].Value.ToString();
                    datos.fechaFinal = dgDatos.CurrentRow.Cells[ 8 ].Value.ToString();
                    datos.fechaReingreso = dgDatos.CurrentRow.Cells[ 9 ].Value.ToString();
                    datos.Remuneracion = bool.Parse( dgDatos.CurrentRow.Cells[ 10 ].Value.ToString() );
                    datos.Motivo = dgDatos.CurrentRow.Cells[ 11 ].Value.ToString();
                    datos.JefeDirecto = dgDatos.CurrentRow.Cells[ 13 ].Value.ToString();
                    datos.CorreoJefe = dgDatos.CurrentRow.Cells[ 14 ].Value.ToString();
                    datos.firmaJefe = (byte[])dgDatos.CurrentRow.Cells[ 15 ].Value;
                    datos.firma = UserLoginCache.firmaAdmin;
                    datos.isTrue = isTrue;
                    frm.datosSolicitud.Add( datos );
                    frm.Show();
                    Thread.Sleep( 1000 );
                    wait.Close();
                }else {
                    MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                }
            }
        }

        private void btnConfirmarSolicitud_Click(object sender, EventArgs e)
        {
            const string message = "¿Está seguro de confirmar la solicitud?";
            const string caption = "Confirmacion de Solicitud";
            var result = MessageDialog.Show(message, caption,
                                         MessageDialogButtons.YesNo,
                                         MessageDialogIcon.Question);
            if ( dgDatos.Rows.Count > 0 ) {
                if ( result == DialogResult.Yes ) {
                    wait.Show( this );
                    int solicitudID = int.Parse( dgDatos.CurrentRow.Cells[ 0 ].Value.ToString() );
                    int empleadoID = int.Parse( dgDatos.CurrentRow.Cells[ 1 ].Value.ToString() );
                    string tipoSolicitud = dgDatos.CurrentRow.Cells[ 5 ].Value.ToString();
                    DateTime fechaEfectiva = DateTime.Parse( dgDatos.CurrentRow.Cells[ 6 ].Value.ToString() );
                    DateTime fechaInicio = DateTime.Parse( dgDatos.CurrentRow.Cells[ 7 ].Value.ToString() );
                    DateTime fechaFinal = DateTime.Parse( dgDatos.CurrentRow.Cells[ 8 ].Value.ToString() );
                    DateTime fechaReingreso = DateTime.Parse( dgDatos.CurrentRow.Cells[ 9 ].Value.ToString() );
                    bool isRemuneracion = bool.Parse( dgDatos.CurrentRow.Cells[ 10 ].Value.ToString() );
                    string motivo = dgDatos.CurrentRow.Cells[ 11 ].Value.ToString();
                    var correoJefe = dgDatos.CurrentRow.Cells[ 14 ].Value.ToString();
                    var correoEmpleado = dgDatos.CurrentRow.Cells[ 16 ].Value.ToString();

                    if ( UserLoginCache.puesto == "Administrador" ) {
                        solicitudes.ActualizarRecursos( solicitudID, tipoSolicitud, empleadoID, fechaEfectiva, fechaInicio, fechaFinal, fechaReingreso, isRemuneracion, motivo );
                        MessageDialog.Show( "Solicitud confirmada\n Se envio un correo electronico al jefe directo del empleado para que\nrevise su cuenta y pueda confirmar su solicitud.", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                        envioCorreo.MessageJefeDirecto( correoJefe );
                        metodos.MostrarSolicitud( dgDatos, UserLoginCache.jefeID );
                        wait.Close();
                    } else if ( UserLoginCache.isJefe == true ) {
                        solicitudes.ActualizarJefe( solicitudID, tipoSolicitud, empleadoID, fechaEfectiva, fechaInicio, fechaFinal, fechaReingreso, isRemuneracion, motivo );
                        MessageDialog.Show( "Solicitud confirmada\n Se envio un correo electronico al empleado para que \nrevise su cuenta y pueda confirmar su solicitud.", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                        envioCorreo.MessageEmpleado( correoEmpleado );
                        metodos.MostrarSolicitudJefe( dgDatos, UserLoginCache.jefeID );
                        wait.Close();
                    }
                } else {
                    //Code
                }
            } else {
                MessageDialog.Show( "Debe seleccionar una fila", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
            }
        }
    }
}
