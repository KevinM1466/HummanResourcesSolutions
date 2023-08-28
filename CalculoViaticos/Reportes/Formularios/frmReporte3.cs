using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Clases;
using Domain;
using Domain.SqlServer;
using Guna.UI2.WinForms;
using Application = Microsoft.Office.Interop.Excel.Application;
//using System.IO;
using Common.cache;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Diagnostics;
using CalculoViaticos.Formularios;
using System.Threading;

namespace CalculoViaticos.Reportes.Formularios {
    public partial class frmReporte3 : Form {
        MetodosListados MetodosListados = new MetodosListados();
        filterModel filterModel = new filterModel();
        string ruta = Environment.GetFolderPath( Environment.SpecialFolder.Desktop );
        WaitFormFunc waitForm = new WaitFormFunc();

        public frmReporte3() {
            InitializeComponent();
        }

        private void frmReporte3_Load( object sender, EventArgs e ) {
            MetodosListados.MostrarTotalSolicitudes( dgDatos );
            MetodosListados.ListarDepartamentos(cmbFiltrarDepartamentos);
            cmbFiltrarDepartamentos.StartIndex = -1;
        }

        private void cmbFiltrarDepartamentos_SelectionChangeCommitted( object sender, EventArgs e ) {
            filterModel.FiltrarDepartamentos( cmbFiltrarDepartamentos.Text, cmbFiltroEstado.Text, cmbFiltroTipo.Text, dgDatos );
        }

        private void cmbFiltroTipo_SelectionChangeCommitted( object sender, EventArgs e ) {
            filterModel.FiltrarTipo(cmbFiltroTipo.Text, cmbFiltrarDepartamentos.Text, cmbFiltroEstado.Text, dgDatos );
        }

        private void cmbFiltroEstado_SelectionChangeCommitted( object sender, EventArgs e ) {
            filterModel.FiltrarEstado(cmbFiltroEstado.Text, cmbFiltrarDepartamentos.Text, cmbFiltroTipo.Text, dgDatos );
        }

        private void btnClear_Click( object sender, EventArgs e ) {
            cmbFiltrarDepartamentos.SelectedIndex = -1;
            cmbFiltrarDepartamentos.StartIndex = -1;
            cmbFiltroEstado.SelectedIndex = -1;
            cmbFiltroTipo.SelectedIndex = -1;
            MetodosListados.MostrarTotalSolicitudes( dgDatos );
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e ) {
            filterModel.FiltrarGeneral( txtBuscar.Text, txtBuscar.Text, txtBuscar.Text, txtBuscar.Text, txtBuscar.Text, dgDatos );
        }

        private void btnExcel_Click( object sender, EventArgs e ) {
            exportarExcel( dgDatos );
        }

        private void exportarExcel(Guna2DataGridView dgDatos ) {
            try {
                if ( txtNombreArchivo.Text != "" ) {
                    waitForm.Show( this );
                    int indiceColumna = 0;
                    int indiceFila = 0;
                    Microsoft.Office.Interop.Excel._Application exportar = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = exportar.Workbooks.Add( Type.Missing );
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    exportar.Visible = false;
                    worksheet = workbook.Sheets[ "Hoja1" ];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Reporte";
                    // Cabeceras
                    foreach ( DataGridViewColumn columna in dgDatos.Columns ) {
                        indiceColumna++;

                        exportar.Cells[ 1, indiceColumna ] = columna.Name;
                    }

                    foreach ( DataGridViewRow fila in dgDatos.Rows ) {
                        indiceFila++;
                        indiceColumna = 0;

                        foreach ( DataGridViewColumn columna in dgDatos.Columns ) {
                            indiceColumna++;
                            exportar.Cells[ indiceFila + 1, indiceColumna ] = fila.Cells[ columna.Name ].Value;
                        }
                    }
                    
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Archivos de Excel|*.xlsx";
                    saveFileDialog.Title = "Guardar archivo";
                    saveFileDialog.FileName = string.Format( "{0}.xlsx", txtNombreArchivo.Text );

                    if ( saveFileDialog.ShowDialog() == DialogResult.OK ) {
                        Console.WriteLine( "Ruta en: " + saveFileDialog.FileName );
                        workbook.SaveAs( saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing );
                        //exportar.Quit();
                        txtNombreArchivo.Clear();
                        Thread.Sleep(3000);
                        MessageDialog.Show( "Archivo de excel creado con exito!", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                        exportar.Visible = true;
                        waitForm.Close();
                    } else {
                        txtNombreArchivo.Clear();
                        waitForm.Close();
                    }
                } else {
                    MessageDialog.Show( "Debe ingresar un nombre para el archivo", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Warning );
                    txtNombreArchivo.Focus();
                }
            } catch ( Exception ex ) {
                throw;
            }
        }

        private void btnPdf_Click( object sender, EventArgs e ) {
            //MessageDialog.Show("Documento generado satisfactoriamente");
            try {
                if ( txtNombreArchivo.Text != "" ) {
                    waitForm.Show( this );
                    SaveFileDialog savefile = new SaveFileDialog();
                    savefile.AddExtension = true;
                    savefile.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                    savefile.FilterIndex = 1;
                    savefile.FileName = string.Format( "{0}.pdf", txtNombreArchivo.Text);

                    txtNombreArchivo.Clear();

                    //string PaginaHTML_Texto = "<table border=\"1\"><tr><td>HOLA MUNDO</td></tr></table>";
                    string PaginaHTML_Texto = Properties.Resources.Plantilla.ToString();
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace( "@ENCARGADO", UserLoginCache.firstName + " " + UserLoginCache.lastName );
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace( "@CARGO", UserLoginCache.puesto );
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace( "@CORREO", UserLoginCache.email );
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace( "@FECHA", DateTime.Now.ToString( "dd/MM/yyyy" ) );

                    string filas = string.Empty;

                    foreach ( DataGridViewRow row in dgDatos.Rows ) {
                        filas += "<tr>";
                        filas += "<th>" + row.Cells[ "EMPLEADO" ].Value.ToString() + "</th>";
                        filas += "<th>" + row.Cells[ "DEPARTAMENTO" ].Value.ToString() + "</th>";
                        filas += "<th>" + row.Cells[ "TIPO DE SOLICITUD" ].Value.ToString() + "</th>";
                        filas += "<th>" + row.Cells[ "FECHA DE INICIO" ].Value.ToString() + "</th>";
                        filas += "<th>" + row.Cells[ "FECHA FINAL" ].Value.ToString() + "</th>";
                        filas += "</tr>";
                    }
                    PaginaHTML_Texto = PaginaHTML_Texto.Replace( "@FILAS", filas );



                    if ( savefile.ShowDialog() == DialogResult.OK ) {
                        using ( FileStream stream = new FileStream( savefile.FileName, FileMode.Create ) ) {
                            //Creamos un nuevo documento y lo definimos como PDF
                            Document pdfDoc = new Document( PageSize.LETTER, 25, 25, 25, 25 );

                            PdfWriter writer = PdfWriter.GetInstance( pdfDoc, stream );
                            pdfDoc.Open();
                            pdfDoc.Add( new Phrase( "" ) );
                            pdfDoc.AddAuthor( UserLoginCache.lastName + ", " + UserLoginCache.firstName );

                            //Agregamos la imagen del banner al documento
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance( Properties.Resources.TecnasaLogo, System.Drawing.Imaging.ImageFormat.Png );
                            img.ScaleToFit( 60, 60 );
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;

                            //img.SetAbsolutePosition( 10, 100 );
                            img.SetAbsolutePosition( pdfDoc.LeftMargin, pdfDoc.Top - 60 );
                            pdfDoc.Add( img );


                            //pdfDoc.Add(new Phrase("Hola Mundo"));
                            using ( StringReader sr = new StringReader( PaginaHTML_Texto ) ) {
                                XMLWorkerHelper.GetInstance().ParseXHtml( writer, pdfDoc, sr );
                            }

                            pdfDoc.Close();
                            stream.Close();
                        }
                        Thread.Sleep( 5000 );
                        waitForm.Close();
                        MessageDialog.Show( "Pdf creado con exito!", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
                    } else {
                        txtNombreArchivo.Clear();
                        waitForm.Close();
                    }
                } else {
                    MessageDialog.Show( "Debe ingresar un nombre para el archivo", "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Warning );
                    txtNombreArchivo.Focus();
                }
            } catch ( Exception ex ) {
                MessageBox.Show( ex.ToString() );
            }

        }
    }
}
