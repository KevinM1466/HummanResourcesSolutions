using CalculoViaticos.Formularios.ConfiiguracionInicial;
using CalculoViaticos.Formularios.Empleados;
using CalculoViaticos.Reportes.Formularios;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TecnasaApp;
using TecnasaApp.Formularios;
using TecnasaApp.Formularios.General.Empleados;

namespace CalculoViaticos
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Properties.Settings.Default.ConfiguracionInicial == false)
            {
                Application.Run(new frmConfiguracionInicial());
            } else
            {
                Application.Run(new frmLogin());
            }
        }
    }
}
