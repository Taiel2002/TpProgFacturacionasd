
namespace Forms.Formularios
{
    partial class FrmFacturas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFiltrarPor = new System.Windows.Forms.Label();
            this.cboFiltrarPor = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.editButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.seeMoreButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cboFiltros = new System.Windows.Forms.ComboBox();
            this.pnlFecha = new System.Windows.Forms.Panel();
            this.cbHasta = new System.Windows.Forms.CheckBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.pnlFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFiltrarPor
            // 
            this.lblFiltrarPor.AutoSize = true;
            this.lblFiltrarPor.Location = new System.Drawing.Point(20, 30);
            this.lblFiltrarPor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(93, 25);
            this.lblFiltrarPor.TabIndex = 13;
            this.lblFiltrarPor.Text = "Filtrar por:";
            // 
            // cboFiltrarPor
            // 
            this.cboFiltrarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltrarPor.FormattingEnabled = true;
            this.cboFiltrarPor.Items.AddRange(new object[] {
            "Ninguno",
            "Clientes",
            "Tipo de pago",
            "Fecha"});
            this.cboFiltrarPor.Location = new System.Drawing.Point(119, 22);
            this.cboFiltrarPor.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cboFiltrarPor.Name = "cboFiltrarPor";
            this.cboFiltrarPor.Size = new System.Drawing.Size(198, 33);
            this.cboFiltrarPor.TabIndex = 12;
            this.cboFiltrarPor.SelectedIndexChanged += new System.EventHandler(this.cboFiltrarPor_SelectedIndexChanged);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Location = new System.Drawing.Point(953, 22);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(154, 45);
            this.btnVolver.TabIndex = 11;
            this.btnVolver.Text = "Volver a inicio";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvFacturas);
            this.panel1.Location = new System.Drawing.Point(20, 77);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 683);
            this.panel1.TabIndex = 16;
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvFacturas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editButton,
            this.deleteButton,
            this.seeMoreButton});
            this.dgvFacturas.Location = new System.Drawing.Point(0, 0);
            this.dgvFacturas.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvFacturas.Size = new System.Drawing.Size(1089, 683);
            this.dgvFacturas.TabIndex = 11;
            this.dgvFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellContentClick_1);
            // 
            // editButton
            // 
            this.editButton.HeaderText = "";
            this.editButton.MinimumWidth = 8;
            this.editButton.Name = "editButton";
            this.editButton.ReadOnly = true;
            this.editButton.Text = "Editar";
            this.editButton.UseColumnTextForButtonValue = true;
            // 
            // deleteButton
            // 
            this.deleteButton.HeaderText = "";
            this.deleteButton.MinimumWidth = 8;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.ReadOnly = true;
            this.deleteButton.Text = "Eliminar";
            this.deleteButton.UseColumnTextForButtonValue = true;
            // 
            // seeMoreButton
            // 
            this.seeMoreButton.HeaderText = "";
            this.seeMoreButton.MinimumWidth = 8;
            this.seeMoreButton.Name = "seeMoreButton";
            this.seeMoreButton.ReadOnly = true;
            this.seeMoreButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seeMoreButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.seeMoreButton.Text = "Ver mas";
            this.seeMoreButton.UseColumnTextForButtonValue = true;
            // 
            // cboFiltros
            // 
            this.cboFiltros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltros.FormattingEnabled = true;
            this.cboFiltros.Location = new System.Drawing.Point(330, 22);
            this.cboFiltros.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cboFiltros.Name = "cboFiltros";
            this.cboFiltros.Size = new System.Drawing.Size(198, 33);
            this.cboFiltros.TabIndex = 14;
            this.cboFiltros.SelectedIndexChanged += new System.EventHandler(this.cboFiltros_SelectedIndexChanged);
            // 
            // pnlFecha
            // 
            this.pnlFecha.Controls.Add(this.cbHasta);
            this.pnlFecha.Controls.Add(this.dtpHasta);
            this.pnlFecha.Controls.Add(this.lblDesde);
            this.pnlFecha.Controls.Add(this.dtpFecha);
            this.pnlFecha.Location = new System.Drawing.Point(331, 22);
            this.pnlFecha.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFecha.Name = "pnlFecha";
            this.pnlFecha.Size = new System.Drawing.Size(611, 40);
            this.pnlFecha.TabIndex = 17;
            // 
            // cbHasta
            // 
            this.cbHasta.AutoSize = true;
            this.cbHasta.Location = new System.Drawing.Point(266, 5);
            this.cbHasta.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cbHasta.Name = "cbHasta";
            this.cbHasta.Size = new System.Drawing.Size(87, 29);
            this.cbHasta.TabIndex = 24;
            this.cbHasta.Text = "Hasta:";
            this.cbHasta.UseVisualStyleBackColor = true;
            this.cbHasta.CheckedChanged += new System.EventHandler(this.cbHasta_CheckedChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(360, 0);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(130, 31);
            this.dtpHasta.TabIndex = 23;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(6, 8);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(66, 25);
            this.lblDesde.TabIndex = 22;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(79, 0);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(135, 31);
            this.dtpFecha.TabIndex = 21;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged_1);
            // 
            // FrmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 783);
            this.Controls.Add(this.pnlFecha);
            this.Controls.Add(this.cboFiltros);
            this.Controls.Add(this.lblFiltrarPor);
            this.Controls.Add(this.cboFiltrarPor);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFacturas";
            this.Load += new System.EventHandler(this.FrmFacturas_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.pnlFecha.ResumeLayout(false);
            this.pnlFecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFiltrarPor;
        private System.Windows.Forms.ComboBox cboFiltrarPor;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.DataGridViewButtonColumn editButton;
        private System.Windows.Forms.DataGridViewButtonColumn deleteButton;
        private System.Windows.Forms.DataGridViewButtonColumn seeMoreButton;
       // private DsClientesTableAdapters.clientesTableAdapter clientesTableAdapter1;
        private System.Windows.Forms.ComboBox cboFiltros;
        private System.Windows.Forms.Panel pnlFecha;
        private System.Windows.Forms.CheckBox cbHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}