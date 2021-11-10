using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.Forms
{
    public partial class FrmReporteArticulos : Form
    {
        public FrmReporteArticulos()
        {
            InitializeComponent();
        }

        private void FrmReporteArticulos_Load(object sender, EventArgs e)
        {

            this.rvArticulos.RefreshReport();
            this.rvArticulos.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dtpFecDesde.Value >= DateTime.Today || dtpFecHasta.Value > DateTime.Today || dtpFecDesde.Value>dtpFecHasta.Value)
            {
                MessageBox.Show("El rango de fechas no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fecDesde = dtpFecDesde.Value;
            DateTime fecHasta = dtpFecHasta.Value;

            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\LocalDBDemo;Initial Catalog=TpProgFacturacion;User ID=sa;Password=dev789");
            cnn.Open();

            SqlCommand command = new SqlCommand("pa_CantidadArticuloFecha", cnn);
            command.Parameters.AddWithValue("@FecDesde", fecDesde.ToShortDateString());
            command.Parameters.AddWithValue("@FecHasta", fecHasta.ToShortDateString());

            command.CommandType = CommandType.StoredProcedure;

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            rvArticulos.LocalReport.DataSources.Clear();
            rvArticulos.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dsRepCantArt", table));
            rvArticulos.RefreshReport();

            cnn.Close();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
