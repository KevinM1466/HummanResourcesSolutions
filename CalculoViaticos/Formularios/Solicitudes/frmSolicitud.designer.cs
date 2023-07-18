namespace TecnasaApp.Formularios.General.Vacaciones
{
    partial class frmSolicitud
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitud));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkRemunerado = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.btnErrorMessage = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpReingreso = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpFinal = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpInicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnEnviarSolicitud = new FontAwesome.Sharp.IconButton();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.txtEmpleadoID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpEfectiva = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpleado = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbTipoVacaciones = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkRemunerado);
            this.panel1.Controls.Add(this.btnErrorMessage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpReingreso);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dtpFinal);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.dtpInicio);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtMotivo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 438);
            this.panel1.TabIndex = 255;
            // 
            // chkRemunerado
            // 
            this.chkRemunerado.Animated = true;
            this.chkRemunerado.BackColor = System.Drawing.Color.Transparent;
            this.chkRemunerado.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkRemunerado.CheckedState.BorderRadius = 4;
            this.chkRemunerado.CheckedState.BorderThickness = 0;
            this.chkRemunerado.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkRemunerado.Enabled = false;
            this.chkRemunerado.Location = new System.Drawing.Point(878, 58);
            this.chkRemunerado.Name = "chkRemunerado";
            this.chkRemunerado.Size = new System.Drawing.Size(25, 25);
            this.chkRemunerado.TabIndex = 264;
            this.chkRemunerado.UncheckedState.BorderRadius = 4;
            this.chkRemunerado.UncheckedState.BorderThickness = 0;
            this.chkRemunerado.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.chkRemunerado.UseTransparentBackground = true;
            // 
            // btnErrorMessage
            // 
            this.btnErrorMessage.FlatAppearance.BorderSize = 0;
            this.btnErrorMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrorMessage.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorMessage.ForeColor = System.Drawing.Color.White;
            this.btnErrorMessage.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnErrorMessage.IconColor = System.Drawing.Color.Red;
            this.btnErrorMessage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnErrorMessage.IconSize = 22;
            this.btnErrorMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnErrorMessage.Location = new System.Drawing.Point(259, 107);
            this.btnErrorMessage.Name = "btnErrorMessage";
            this.btnErrorMessage.Size = new System.Drawing.Size(278, 30);
            this.btnErrorMessage.TabIndex = 259;
            this.btnErrorMessage.Text = "Error Message";
            this.btnErrorMessage.UseVisualStyleBackColor = true;
            this.btnErrorMessage.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(658, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 262;
            this.label2.Text = "Fecha Reintegro";
            // 
            // dtpReingreso
            // 
            this.dtpReingreso.Animated = true;
            this.dtpReingreso.BackColor = System.Drawing.Color.Transparent;
            this.dtpReingreso.BorderRadius = 10;
            this.dtpReingreso.Checked = true;
            this.dtpReingreso.Enabled = false;
            this.dtpReingreso.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtpReingreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReingreso.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpReingreso.IndicateFocus = true;
            this.dtpReingreso.Location = new System.Drawing.Point(661, 54);
            this.dtpReingreso.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpReingreso.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpReingreso.Name = "dtpReingreso";
            this.dtpReingreso.Size = new System.Drawing.Size(200, 36);
            this.dtpReingreso.TabIndex = 261;
            this.dtpReingreso.UseTransparentBackground = true;
            this.dtpReingreso.Value = new System.DateTime(2023, 5, 26, 9, 26, 10, 621);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(428, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 23);
            this.label11.TabIndex = 260;
            this.label11.Text = "Fecha Terminación";
            // 
            // dtpFinal
            // 
            this.dtpFinal.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.dtpFinal.Animated = true;
            this.dtpFinal.BorderRadius = 10;
            this.dtpFinal.Checked = true;
            this.dtpFinal.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpFinal.Enabled = false;
            this.dtpFinal.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtpFinal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFinal.Location = new System.Drawing.Point(431, 54);
            this.dtpFinal.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFinal.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(200, 36);
            this.dtpFinal.TabIndex = 259;
            this.dtpFinal.Value = new System.DateTime(2023, 5, 26, 9, 26, 10, 621);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gainsboro;
            this.label12.Location = new System.Drawing.Point(198, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 23);
            this.label12.TabIndex = 258;
            this.label12.Text = "Fecha Inicio";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Animated = true;
            this.dtpInicio.BorderRadius = 10;
            this.dtpInicio.Checked = true;
            this.dtpInicio.Enabled = false;
            this.dtpInicio.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtpInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpInicio.Location = new System.Drawing.Point(201, 54);
            this.dtpInicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpInicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 36);
            this.dtpInicio.TabIndex = 257;
            this.dtpInicio.Value = new System.DateTime(2023, 7, 8, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(199, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 254;
            this.label7.Text = "Motivo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.txtMotivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMotivo.Enabled = false;
            this.txtMotivo.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Location = new System.Drawing.Point(202, 140);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(812, 281);
            this.txtMotivo.TabIndex = 253;
            this.txtMotivo.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(904, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 23);
            this.label6.TabIndex = 252;
            this.label6.Text = "Remuneracion";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this.btnEnviarSolicitud;
            // 
            // btnEnviarSolicitud
            // 
            this.btnEnviarSolicitud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarSolicitud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(195)))), ((int)(((byte)(50)))));
            this.btnEnviarSolicitud.FlatAppearance.BorderSize = 0;
            this.btnEnviarSolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarSolicitud.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarSolicitud.ForeColor = System.Drawing.Color.White;
            this.btnEnviarSolicitud.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEnviarSolicitud.IconColor = System.Drawing.Color.Gainsboro;
            this.btnEnviarSolicitud.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnviarSolicitud.IconSize = 32;
            this.btnEnviarSolicitud.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarSolicitud.Location = new System.Drawing.Point(859, 649);
            this.btnEnviarSolicitud.Name = "btnEnviarSolicitud";
            this.btnEnviarSolicitud.Padding = new System.Windows.Forms.Padding(10, 0, 30, 0);
            this.btnEnviarSolicitud.Size = new System.Drawing.Size(167, 51);
            this.btnEnviarSolicitud.TabIndex = 201;
            this.btnEnviarSolicitud.Text = "      ENVIAR";
            this.btnEnviarSolicitud.UseVisualStyleBackColor = false;
            this.btnEnviarSolicitud.Click += new System.EventHandler(this.btnEnviarSolicitud_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 30;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 1D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.DragStartTransparencyValue = 1D;
            this.guna2BorderlessForm1.HasFormShadow = false;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // txtEmpleadoID
            // 
            this.txtEmpleadoID.BorderRadius = 8;
            this.txtEmpleadoID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmpleadoID.DefaultText = "";
            this.txtEmpleadoID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmpleadoID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmpleadoID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmpleadoID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmpleadoID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmpleadoID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpleadoID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmpleadoID.Location = new System.Drawing.Point(221, 87);
            this.txtEmpleadoID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmpleadoID.Name = "txtEmpleadoID";
            this.txtEmpleadoID.PasswordChar = '\0';
            this.txtEmpleadoID.PlaceholderText = "";
            this.txtEmpleadoID.ReadOnly = true;
            this.txtEmpleadoID.SelectedText = "";
            this.txtEmpleadoID.Size = new System.Drawing.Size(282, 34);
            this.txtEmpleadoID.TabIndex = 259;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gainsboro;
            this.label10.Location = new System.Drawing.Point(218, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 23);
            this.label10.TabIndex = 245;
            this.label10.Text = "Empleado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(216, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 42);
            this.label9.TabIndex = 247;
            this.label9.Text = "Datos Generales";
            // 
            // dtpEfectiva
            // 
            this.dtpEfectiva.BorderRadius = 10;
            this.dtpEfectiva.Checked = true;
            this.dtpEfectiva.Enabled = false;
            this.dtpEfectiva.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtpEfectiva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEfectiva.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEfectiva.Location = new System.Drawing.Point(889, 85);
            this.dtpEfectiva.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEfectiva.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEfectiva.Name = "dtpEfectiva";
            this.dtpEfectiva.Size = new System.Drawing.Size(200, 36);
            this.dtpEfectiva.TabIndex = 248;
            this.dtpEfectiva.Value = new System.DateTime(2023, 5, 26, 9, 26, 10, 621);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(886, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 23);
            this.label8.TabIndex = 249;
            this.label8.Text = "Fecha Efectiva";
            // 
            // btnHome
            // 
            this.btnHome.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(12, 13);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(163, 153);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 250;
            this.btnHome.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(532, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 254;
            this.label1.Text = "Tipo de Solicitud";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.BorderRadius = 8;
            this.txtEmpleado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmpleado.DefaultText = "";
            this.txtEmpleado.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmpleado.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmpleado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmpleado.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmpleado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmpleado.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpleado.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmpleado.Location = new System.Drawing.Point(221, 87);
            this.txtEmpleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.PasswordChar = '\0';
            this.txtEmpleado.PlaceholderText = "";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.SelectedText = "";
            this.txtEmpleado.Size = new System.Drawing.Size(282, 34);
            this.txtEmpleado.TabIndex = 256;
            // 
            // cmbTipoVacaciones
            // 
            this.cmbTipoVacaciones.BackColor = System.Drawing.Color.Transparent;
            this.cmbTipoVacaciones.BorderRadius = 8;
            this.cmbTipoVacaciones.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipoVacaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVacaciones.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTipoVacaciones.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTipoVacaciones.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.cmbTipoVacaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTipoVacaciones.ItemHeight = 30;
            this.cmbTipoVacaciones.Items.AddRange(new object[] {
            "Seleccione el tipo de solicitud",
            "Vacaciones",
            "Permisos"});
            this.cmbTipoVacaciones.Location = new System.Drawing.Point(535, 85);
            this.cmbTipoVacaciones.Name = "cmbTipoVacaciones";
            this.cmbTipoVacaciones.Size = new System.Drawing.Size(320, 36);
            this.cmbTipoVacaciones.StartIndex = 0;
            this.cmbTipoVacaciones.TabIndex = 257;
            this.cmbTipoVacaciones.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoVacaciones_SelectionChangeCommitted_1);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 15;
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1068, 10);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(32, 32);
            this.guna2ControlBox1.TabIndex = 260;
            // 
            // frmSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1112, 789);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.cmbTipoVacaciones);
            this.Controls.Add(this.txtEmpleado);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpEfectiva);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnEnviarSolicitud);
            this.Controls.Add(this.txtEmpleadoID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSolicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVacaciones";
            this.Load += new System.EventHandler(this.frmSolicitud_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public FontAwesome.Sharp.IconButton btnEnviarSolicitud;
        //private Bunifu.UI.WinForms.BunifuDropdown cmbTipoVacaciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpReingreso;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtMotivo;
        private System.Windows.Forms.Label label6;
        //private Bunifu.UI.WinForms.BunifuCheckBox chkRemunerado;
        //private Bunifu.UI.WinForms.BunifuTextBox txtEmpleado;
        //private Bunifu.UI.WinForms.BunifuTextBox txtEmpleadoID;
        private FontAwesome.Sharp.IconButton btnErrorMessage;
        private Guna.UI2.WinForms.Guna2CustomCheckBox chkRemunerado;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTipoVacaciones;
        private Guna.UI2.WinForms.Guna2TextBox txtEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEfectiva;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtEmpleadoID;
    }
}