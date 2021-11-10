using Reportes.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmReporteArticulos().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrmReporteClientesMontosFormasPago().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FrmReporteMontosProm().ShowDialog();
        }
    }
}
