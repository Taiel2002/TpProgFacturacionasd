﻿using FormsFacturadora.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaFactura nuevo = new FrmNuevaFactura();
            nuevo.Show();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoCliente nuevo = new FrmNuevoCliente();
            nuevo.Show();
        }

        private void nuevoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulos nuevo = new FrmArticulos();
            nuevo.Show();
        }

        private void consultarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFacturas nuevo = new FrmFacturas();
            nuevo.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void desarrolladoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDesarrolladores nuevo = new FrmDesarrolladores();
            nuevo.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
