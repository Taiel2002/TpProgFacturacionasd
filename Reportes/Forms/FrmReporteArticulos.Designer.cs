
namespace Reportes.Forms
{
    partial class FrmReporteArticulos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFecDesde = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rvArticulos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFecHasta);
            this.groupBox1.Controls.Add(this.dtpFecDesde);
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha desde:";
            // 
            // dtpFecHasta
            // 
            this.dtpFecHasta.Location = new System.Drawing.Point(413, 39);
            this.dtpFecHasta.Name = "dtpFecHasta";
            this.dtpFecHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpFecHasta.TabIndex = 2;
            // 
            // dtpFecDesde
            // 
            this.dtpFecDesde.Location = new System.Drawing.Point(88, 39);
            this.dtpFecDesde.Name = "dtpFecDesde";
            this.dtpFecDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpFecDesde.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(660, 39);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rvArticulos);
            this.groupBox2.Location = new System.Drawing.Point(13, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 319);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reporte";
            // 
            // rvArticulos
            // 
            this.rvArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvArticulos.LocalReport.ReportEmbeddedResource = "Reportes.Reportes.RptReporteCantidadArticulo.rdlc";
            this.rvArticulos.Location = new System.Drawing.Point(3, 16);
            this.rvArticulos.Name = "rvArticulos";
            this.rvArticulos.ServerReport.BearerToken = null;
            this.rvArticulos.Size = new System.Drawing.Size(769, 300);
            this.rvArticulos.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(713, 444);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmReporteArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReporteArticulos";
            this.Text = "FrmReporteArticulos";
            this.Load += new System.EventHandler(this.FrmReporteArticulos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rvArticulos;
        private System.Windows.Forms.DateTimePicker dtpFecHasta;
        private System.Windows.Forms.DateTimePicker dtpFecDesde;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}