namespace CalculoViaticos.Reportes.Formularios
{
    partial class frmReporteSolicitudesFecha
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.solicitudesReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.solicitudesListingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.netSolicitudesByPeriodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAplicar = new Guna.UI2.WinForms.Guna2Button();
            this.dtpHasta = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblHasta = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpDesde = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDesde = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCustom = new Guna.UI2.WinForms.Guna2Button();
            this.btnThisYear = new Guna.UI2.WinForms.Guna2Button();
            this.btnLast30 = new Guna.UI2.WinForms.Guna2Button();
            this.btnThisMonth = new Guna.UI2.WinForms.Guna2Button();
            this.btnLast7 = new Guna.UI2.WinForms.Guna2Button();
            this.btnHoy = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudesReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudesListingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netSolicitudesByPeriodBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // solicitudesReportBindingSource
            // 
            this.solicitudesReportBindingSource.DataSource = typeof(Domain.SqlServer.solicitudesReport);
            // 
            // solicitudesListingBindingSource
            // 
            this.solicitudesListingBindingSource.DataSource = typeof(Domain.SqlServer.SolicitudesListing);
            // 
            // netSolicitudesByPeriodBindingSource
            // 
            this.netSolicitudesByPeriodBindingSource.DataSource = typeof(Domain.SqlServer.NetSolicitudesByPeriod);
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource1.Name = "solicitudesReport";
            reportDataSource1.Value = this.solicitudesReportBindingSource;
            reportDataSource2.Name = "solicitudesListing";
            reportDataSource2.Value = this.solicitudesListingBindingSource;
            reportDataSource3.Name = "netSolicitudesByPeriod";
            reportDataSource3.Value = this.netSolicitudesByPeriodBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DisplayName = "Reporte 1";
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CalculoViaticos.Reportes.Reportes.SolicitudesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(53, 96);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1016, 795);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.btnAplicar);
            this.panel1.Controls.Add(this.dtpHasta);
            this.panel1.Controls.Add(this.lblHasta);
            this.panel1.Controls.Add(this.dtpDesde);
            this.panel1.Controls.Add(this.lblDesde);
            this.panel1.Controls.Add(this.btnCustom);
            this.panel1.Controls.Add(this.btnThisYear);
            this.panel1.Controls.Add(this.btnLast30);
            this.panel1.Controls.Add(this.btnThisMonth);
            this.panel1.Controls.Add(this.btnLast7);
            this.panel1.Controls.Add(this.btnHoy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 916);
            this.panel1.TabIndex = 1;
            // 
            // btnAplicar
            // 
            this.btnAplicar.BorderRadius = 6;
            this.btnAplicar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAplicar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAplicar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAplicar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAplicar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(195)))), ((int)(((byte)(50)))));
            this.btnAplicar.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(39, 519);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(173, 41);
            this.btnAplicar.TabIndex = 278;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.Visible = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Animated = true;
            this.dtpHasta.BorderRadius = 10;
            this.dtpHasta.Checked = true;
            this.dtpHasta.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(92, 456);
            this.dtpHasta.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHasta.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(110, 36);
            this.dtpHasta.TabIndex = 260;
            this.dtpHasta.Value = new System.DateTime(2023, 7, 8, 0, 0, 0, 0);
            this.dtpHasta.Visible = false;
            // 
            // lblHasta
            // 
            this.lblHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblHasta.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.ForeColor = System.Drawing.Color.White;
            this.lblHasta.Location = new System.Drawing.Point(32, 403);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(47, 25);
            this.lblHasta.TabIndex = 259;
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.Visible = false;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Animated = true;
            this.dtpDesde.BorderRadius = 10;
            this.dtpDesde.Checked = true;
            this.dtpDesde.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(92, 402);
            this.dtpDesde.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDesde.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(110, 36);
            this.dtpDesde.TabIndex = 258;
            this.dtpDesde.Value = new System.DateTime(2023, 7, 8, 0, 0, 0, 0);
            this.dtpDesde.Visible = false;
            // 
            // lblDesde
            // 
            this.lblDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblDesde.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.ForeColor = System.Drawing.Color.White;
            this.lblDesde.Location = new System.Drawing.Point(31, 456);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(48, 25);
            this.lblDesde.TabIndex = 6;
            this.lblDesde.Text = "Desde:";
            this.lblDesde.Visible = false;
            // 
            // btnCustom
            // 
            this.btnCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.btnCustom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustom.FillColor = System.Drawing.Color.Empty;
            this.btnCustom.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustom.ForeColor = System.Drawing.Color.White;
            this.btnCustom.Location = new System.Drawing.Point(32, 351);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(180, 45);
            this.btnCustom.TabIndex = 5;
            this.btnCustom.Text = "Personalizado";
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // btnThisYear
            // 
            this.btnThisYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThisYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.btnThisYear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThisYear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThisYear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThisYear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThisYear.FillColor = System.Drawing.Color.Empty;
            this.btnThisYear.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThisYear.ForeColor = System.Drawing.Color.White;
            this.btnThisYear.Location = new System.Drawing.Point(32, 300);
            this.btnThisYear.Name = "btnThisYear";
            this.btnThisYear.Size = new System.Drawing.Size(180, 45);
            this.btnThisYear.TabIndex = 4;
            this.btnThisYear.Text = "Este Año";
            this.btnThisYear.Click += new System.EventHandler(this.btnThisYear_Click);
            // 
            // btnLast30
            // 
            this.btnLast30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.btnLast30.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLast30.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLast30.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLast30.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLast30.FillColor = System.Drawing.Color.Empty;
            this.btnLast30.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast30.ForeColor = System.Drawing.Color.White;
            this.btnLast30.Location = new System.Drawing.Point(32, 249);
            this.btnLast30.Name = "btnLast30";
            this.btnLast30.Size = new System.Drawing.Size(180, 45);
            this.btnLast30.TabIndex = 3;
            this.btnLast30.Text = "Ultimos 30 dias";
            this.btnLast30.Click += new System.EventHandler(this.btnLast30_Click);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThisMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.btnThisMonth.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThisMonth.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThisMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThisMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThisMonth.FillColor = System.Drawing.Color.Empty;
            this.btnThisMonth.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThisMonth.ForeColor = System.Drawing.Color.White;
            this.btnThisMonth.Location = new System.Drawing.Point(32, 198);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(180, 45);
            this.btnThisMonth.TabIndex = 2;
            this.btnThisMonth.Text = "Este Mes";
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            // 
            // btnLast7
            // 
            this.btnLast7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.btnLast7.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLast7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLast7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLast7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLast7.FillColor = System.Drawing.Color.Empty;
            this.btnLast7.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast7.ForeColor = System.Drawing.Color.White;
            this.btnLast7.Location = new System.Drawing.Point(32, 147);
            this.btnLast7.Name = "btnLast7";
            this.btnLast7.Size = new System.Drawing.Size(180, 45);
            this.btnLast7.TabIndex = 1;
            this.btnLast7.Text = "Ultimos 7 dias";
            this.btnLast7.Click += new System.EventHandler(this.btnLast7_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.btnHoy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHoy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHoy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHoy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHoy.FillColor = System.Drawing.Color.Empty;
            this.btnHoy.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoy.ForeColor = System.Drawing.Color.White;
            this.btnHoy.Location = new System.Drawing.Point(32, 96);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(180, 45);
            this.btnHoy.TabIndex = 0;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(240, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1124, 916);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(46, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 39);
            this.label3.TabIndex = 326;
            this.label3.Text = "Reporte de Solicitudes Por Fecha";
            // 
            // frmReporteSolicitudesFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 916);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmReporteSolicitudesFecha";
            this.Text = "frmReporte1";
            this.Load += new System.EventHandler(this.frmReporteSolicitudesFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.solicitudesReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudesListingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netSolicitudesByPeriodBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource solicitudesReportBindingSource;
        private System.Windows.Forms.BindingSource solicitudesListingBindingSource;
        private System.Windows.Forms.BindingSource netSolicitudesByPeriodBindingSource;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnCustom;
        private Guna.UI2.WinForms.Guna2Button btnThisYear;
        private Guna.UI2.WinForms.Guna2Button btnLast30;
        private Guna.UI2.WinForms.Guna2Button btnThisMonth;
        private Guna.UI2.WinForms.Guna2Button btnLast7;
        private Guna.UI2.WinForms.Guna2Button btnHoy;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDesde;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpHasta;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHasta;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDesde;
        private Guna.UI2.WinForms.Guna2Button btnAplicar;
        private System.Windows.Forms.Label label3;
    }
}