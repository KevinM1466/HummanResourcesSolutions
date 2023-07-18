using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace Clases
{
    public class Validaciones
    {
        public bool vacio = true;
        public bool resultado = true;
        //public bool SoloLetras(KeyPressEventArgs e)
        //{
        //    if (char.IsLetter(e.KeyChar))
        //        return false;
        //    else if (char.IsControl(e.KeyChar))
        //        return false;
        //    else if (char.IsSeparator(e.KeyChar))
        //        return false;
        //    else
        //        return true;
        //}

        public bool SoloLetras(string letra, Button button)
        {
            foreach (Char ch in letra)
            {
                if (!Char.IsLetter(ch) && ch != 32)
                {
                    msgError("Este campo solo permite letras", button);
                    return false;
                }
            }
            button.Visible = false;
            return true;
        }

        public void SoloNumeros(TextBox textBox, Button button)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "^[0-9]*$"))
            {
                msgError("Este campo solo permite numeros", button);
                textBox.Text = string.Empty;
            } else
            {
                button.Visible = false;
            }
        }

        public bool ValidarEmail(string comprobarEmail, Button button)
        {
            string emailFormato;
            emailFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(comprobarEmail, emailFormato))
            {
                if (Regex.Replace(comprobarEmail, emailFormato, String.Empty).Length == 0)
                {
                    msgError("Ingrese un correo electronico valido", button);
                    return true;
                }
                else
                {
                    button.Visible = false;
                    return false;
                }
            }
            else
            {
                button.Visible = false;
                return false;
            }
        }

        public bool validarTextBoxs(Form Controls)
        {
            foreach (Control item in Controls.Controls)
            {
                try
                {
                    if (item is TextBox)
                    {
                        //Codigo comprobacion  de textbox
                        if (item.Text == "")
                        {
                            MessageBox.Show("Hay campos vacios");
                            item.Focus();
                            return false;
                        }
                    }
                    else if (item is ComboBox)
                    {
                        if (item.Text == "")
                        {
                            MessageBox.Show("Debes seleccionar un item");
                            item.Focus();
                            return false;
                        }
                    }
                }
                catch { }
            }
            return true;
        }

        public bool camposVacios(string textBox, Button button)
        {
            if (string.IsNullOrWhiteSpace(textBox))
            {
                msgError("No puede dejar campos vacios", button);
                return false;
            }
            return true;
        }

        public void msgError(string msg, Button btnErrorMessage)
        {
            btnErrorMessage.Text = "    " + msg;
            btnErrorMessage.Visible = true;
        }
    }
}
