using Guna.UI2.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public bool SoloLetrasColor(string letra, Guna2HtmlLabel lblMensaje, Guna2TextBox txtCampo)
        {
            foreach (Char ch in letra)
            {
                if (!Char.IsLetter(ch) && ch != 32)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Este campo solo permite letras";
                    txtCampo.BorderThickness = 2;
                    txtCampo.BorderColor = Color.Red;
                    txtCampo.HoverState.BorderColor = Color.Red;
                    txtCampo.FocusedState.BorderColor = Color.Red;
                    return false;
                }
            }
            if (txtCampo.Text == "")
            {
                lblMensaje.Visible = false;
                txtCampo.BorderThickness = 1;
                txtCampo.BorderColor = Color.FromArgb(94, 148, 255);
                txtCampo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
                txtCampo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
                return false;
            }
            lblMensaje.Visible = false;
            txtCampo.BorderThickness = 2;
            txtCampo.BorderColor = Color.Green;
            txtCampo.HoverState.BorderColor = Color.Green;
            txtCampo.FocusedState.BorderColor = Color.Green;
            return true;
        }

        public void SoloNumeros(TextBox textBox, Button button)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "^[0-9]*$"))
            {
                msgError("Este campo solo permite numeros", button);
                textBox.Text = string.Empty;
            }
            else
            {
                button.Visible = false;
            }
        }

        public bool ValidarEmail(string comprobarEmail, Guna2HtmlLabel lblMensaje, Guna2TextBox txtCampo)
        {
            string emailFormato;
            emailFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(comprobarEmail, emailFormato))
            {
                if (Regex.Replace(comprobarEmail, emailFormato, String.Empty).Length == 0)
                {
                    lblMensaje.Visible = false;
                    txtCampo.BorderThickness = 2;
                    txtCampo.BorderColor = Color.Green;
                    txtCampo.HoverState.BorderColor = Color.Green;
                    txtCampo.FocusedState.BorderColor = Color.Green;
                    return true;
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Ingrese una dorección de correo electrónico válido";
                    txtCampo.BorderThickness = 2;
                    txtCampo.BorderColor = Color.Red;
                    txtCampo.HoverState.BorderColor = Color.Red;
                    txtCampo.FocusedState.BorderColor = Color.Red;
                    return false;
                }
            }
            else if (txtCampo.Text == "")
            {
                lblMensaje.Visible = false;
                txtCampo.BorderThickness = 1;
                txtCampo.BorderColor = Color.FromArgb(94, 148, 255);
                txtCampo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
                txtCampo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
                return true;
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Ingrese una dorección de correo electrónico válido";
                txtCampo.BorderThickness = 2;
                txtCampo.BorderColor = Color.Red;
                txtCampo.HoverState.BorderColor = Color.Red;
                txtCampo.FocusedState.BorderColor = Color.Red;
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

        public bool AlgoritmoContraseñaSegura(string password, Guna2CheckBox minimo, Guna2CheckBox mayuscula, Guna2CheckBox minuscula, Guna2CheckBox numero, Guna2HtmlLabel lblMensaje, Guna2TextBox txtCampo)
        {
            mayuscula.Checked = false; minuscula.Checked = false; numero.Checked = false; minimo.Checked = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (password.Length >= 8)
                {
                    minimo.Checked = true;
                }
                if (Char.IsUpper(password, i))
                {
                    mayuscula.Checked = true;
                }
                if (Char.IsLower(password, i))
                {
                    minuscula.Checked = true;
                }
                if (Char.IsDigit(password, i))
                {
                    numero.Checked = true;
                }
            }
            if (mayuscula.Checked && minuscula.Checked && numero.Checked && password.Length >= 8)
            {
                lblMensaje.Visible = false;
                txtCampo.BorderThickness = 2;
                txtCampo.BorderColor = Color.Green;
                txtCampo.HoverState.BorderColor = Color.Green;
                txtCampo.FocusedState.BorderColor = Color.Green;
                return true;
            } else if (txtCampo.Text == "")
            {
                lblMensaje.Visible = false;
                txtCampo.BorderThickness = 1;
                txtCampo.BorderColor = Color.FromArgb(94, 148, 255);
                txtCampo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
                txtCampo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
                return false;
            }
            lblMensaje.Visible = true;
            lblMensaje.ForeColor = Color.Red;
            lblMensaje.Text = "Formato de contraseña incorrecto";
            txtCampo.BorderThickness = 2;
            txtCampo.BorderColor = Color.Red;
            txtCampo.HoverState.BorderColor = Color.Red;
            txtCampo.FocusedState.BorderColor = Color.Red;
            return false;
        }

        public void msgError(string msg, Button btnErrorMessage)
        {
            btnErrorMessage.Text = "    " + msg;
            btnErrorMessage.Visible = true;
        }
    }
}
