
namespace Reportes.Forms
{
    partial class FrmReporteMontosProm
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
            this.numPromMontoMin = new System.Windows.Forms.NumericUpDown();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rvPromMontos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPromMontoMin)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numPromMontoMin);
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // numPromMontoMin
            // 
            this.numPromMontoMin.Location = new System.Drawing.Point(286, 41);
            this.numPromMontoMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPromMontoMin.Name = "numPromMontoMin";
            this.numPromMontoMin.Size = new System.Drawing.Size(120, 20);
            this.numPromMontoMin.TabIndex = 5;
            this.numPromMontoMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(492, 38);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Monto Promedio Mínimo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rvPromMontos);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 352);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reporte";
            // 
            // rvPromMontos
            // 
            this.rvPromMontos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvPromMontos.LocalReport.ReportEmbeddedResource = "Reportes.Reportes.RprtReportePMC.rdlc";
            this.rvPromMontos.Location = new System.Drawing.Point(3, 16);
            this.rvPromMontos.Name = "rvPromMontos";
            this.rvPromMontos.ServerReport.BearerToken = null;
            this.rvPromMontos.Size = new System.Drawing.Size(724, 333);
            this.rvPromMontos.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(664, 476);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmReporteMontosProm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 511);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReporteMontosProm";
            this.Text = "FrmReporteMontosProm";
            this.Load += new System.EventHandler(this.FrmReporteMontosProm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPromMontoMin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rvPromMontos;
        private System.Windows.Forms.NumericUpDown numPromMontoMin;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
    }
}