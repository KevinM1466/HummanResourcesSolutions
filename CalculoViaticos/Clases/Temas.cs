using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Temas
    {
        public static Color pnlMenu;
        public static Color pnlTitleBar;
        public static Color pnlDesktop;
        public static Color pnlDesktopLogin;
        public static Color Hover;
        public static Color pnlUser;

        public static Color fuenteTitulos;
        public static Color fuenteTextBox;
        public static Color fuenteTextBoxBuscar;
        public static Color fuenteComboBox;

        public static Color buttonsColor;
        public static Color buttonColorTheme;
        public static Color buttonsColorForm;
        public static Color Buscar;

        public static Color tapPageSelected;
        public static Color tapPageSelectedInner;

        //Tema Tecnasa
        public static readonly Color pnlMenuT = Color.FromArgb(31, 30, 68);
        public static readonly Color pnlTitleBarT = Color.FromArgb(26, 25, 62);
        public static readonly Color pnlDesktopT = Color.FromArgb(34, 33, 74);
        public static readonly Color HoverT = Color.FromArgb(34, 33, 74);
        public static readonly Color pnlDesktopLoginT = Color.FromArgb(26, 25, 62);
        public static readonly Color pnlUserT = Color.FromArgb(41, 45, 62);

        public static readonly Color fuenteTitulosT = Color.White;
        public static readonly Color fuenteTextBoxT = Color.Black;
        public static readonly Color fuenteTextBoxBuscarT = Color.White;
        public static readonly Color fuenteComboBoxT = Color.Black;

        public static readonly Color buttonsColorT = Color.FromArgb(243, 195, 50);
        public static readonly Color buttonColorThemeT = Color.Transparent;
        public static readonly Color buttonsColorFormT = Color.FromArgb( 44, 44, 44);
        public static readonly Color BuscarT = Color.FromArgb( 26, 25, 62);

        public static readonly Color tapPageSelectedT = Color.FromArgb( 26, 25, 62 );
        public static readonly Color tapPageSelectedInnerT = Color.FromArgb( 76, 132, 255);

        //Tema Oscuro
        public static readonly Color pnlMenuO = Color.FromArgb(10, 10, 10);
        public static readonly Color pnlTitleBarO = Color.FromArgb(10, 10, 10);
        public static readonly Color pnlDesktopO = Color.FromArgb(31, 31, 31);
        public static readonly Color HoverO = Color.FromArgb(31, 31, 31);
        public static readonly Color pnlDesktopLoginO = Color.FromArgb(31, 31, 31);
        public static readonly Color pnlUserO = Color.FromArgb(18, 18, 18);

        public static readonly Color fuenteTitulosO = Color.White;
        public static readonly Color fuenteTextBoxO = Color.Black;
        public static readonly Color fuenteTextBoxBuscarO = Color.White;
        public static readonly Color fuenteComboBoxO = Color.Black;

        public static readonly Color buttonsColorO = Color.FromArgb(64, 64, 64);
        public static readonly Color buttonColorThemeO = Color.FromArgb(64, 64, 64);
        public static readonly Color buttonsColorFormO = Color.FromArgb(64, 64, 64);
        public static readonly Color BuscarO = Color.FromArgb(18, 18, 18);

        public static readonly Color tapPageSelectedO = Color.FromArgb( 10, 10, 10 );
        public static readonly Color tapPageSelectedInnerO = Color.FromArgb( 76, 132, 255 );

        //Tema Claro
        public static readonly Color pnlMenuC = Color.FromArgb(245, 245, 245);
        public static readonly Color pnlTitleBarC = Color.FromArgb(70, 71, 117);
        public static readonly Color pnlDesktopC = Color.FromArgb(235, 235, 235);
        public static readonly Color HoverC = Color.FromArgb(235, 235, 235);
        public static readonly Color pnlDesktopLoginC = Color.FromArgb(245, 245, 245);
        public static readonly Color pnlUserC = Color.FromArgb(218, 218, 227);

        public static readonly Color fuenteTitulosC = Color.Black;
        public static readonly Color fuenteTextBoxC = Color.Black;
        public static readonly Color fuenteTextBoxBuscarC = Color.Black;
        public static readonly Color fuenteComboBoxC = Color.Black;

        public static readonly Color buttonsColorC = Color.Black;
        public static readonly Color buttonsColorFormC = Color.Black;
        public static readonly Color buttonColorThemeC = Color.Gainsboro;
        public static readonly Color BuscarC = Color.FromArgb(218, 218, 227);

        public static readonly Color tapPageSelectedC = Color.FromArgb( 70, 71, 117 );
        public static readonly Color tapPageSelectedInnerC = Color.FromArgb( 76, 132, 255 );

        public static void ElegirTema(string tema)
        {
            if (tema == "Tecnasa")
            {
                pnlMenu = pnlMenuT;
                pnlTitleBar = pnlTitleBarT;
                pnlDesktop = pnlDesktopT;
                Hover = HoverT;
                pnlDesktopLogin = pnlDesktopLoginT;
                pnlUser = pnlUserT;
                fuenteTitulos = fuenteTitulosT;
                fuenteTextBox = fuenteTextBoxT;
                fuenteTextBoxBuscar = fuenteTextBoxBuscarT;
                fuenteComboBox = fuenteComboBoxT;
                buttonsColor = buttonsColorT;
                buttonColorTheme = buttonColorThemeT;
                Buscar = BuscarT;
                tapPageSelected = tapPageSelectedT;
                tapPageSelectedInner = tapPageSelectedInnerT;
                buttonsColorForm = buttonsColorFormT;
            }
            if (tema == "Oscuro")
            {
                pnlMenu = pnlMenuO;
                pnlTitleBar = pnlTitleBarO;
                pnlDesktop = pnlDesktopO;
                Hover = HoverO;
                pnlDesktopLogin = pnlDesktopLoginO;
                pnlUser = pnlUserO;
                fuenteTitulos = fuenteTitulosO;
                fuenteTextBox = fuenteTextBoxT;
                fuenteTextBoxBuscar = fuenteTextBoxBuscarO;
                fuenteComboBox = fuenteComboBoxO;
                buttonsColor = buttonsColorO;
                buttonColorTheme = buttonColorThemeO;
                Buscar = BuscarO;
                tapPageSelected = tapPageSelectedO;
                tapPageSelectedInner= tapPageSelectedInnerO;
                buttonsColorForm = buttonsColorFormO;
            }
            if (tema == "Claro")
            {
                pnlMenu = pnlMenuC;
                pnlTitleBar = pnlTitleBarC;
                pnlDesktop = pnlDesktopC;
                Hover = HoverC;
                pnlDesktopLogin = pnlDesktopLoginC;
                pnlUser = pnlUserC;
                fuenteTitulos = fuenteTitulosC;
                fuenteTextBox = fuenteTextBoxC;
                fuenteTextBoxBuscar = fuenteTextBoxBuscarC;
                fuenteComboBox = fuenteComboBoxC;
                buttonsColor = buttonsColorC;
                buttonColorTheme = buttonColorThemeC;
                Buscar = BuscarC;
                tapPageSelected = tapPageSelectedC;
                tapPageSelectedInner = tapPageSelectedInnerC;
                buttonsColorForm = buttonsColorFormC;
            }
        }
    }
}
