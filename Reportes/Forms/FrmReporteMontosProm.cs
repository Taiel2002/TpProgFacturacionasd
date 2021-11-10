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
    public partial class FrmReporteMontosProm : Form
    {
        public FrmReporteMontosProm()
        {
            InitializeComponent();
        }

        private void FrmReporteMontosProm_Load(object sender, EventArgs e)
        {

            this.rvPromMontos.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\LocalDBDemo;Initial Catalog=TpProgFacturacion;User ID=sa;Password=dev789");
            cnn.Open();

            SqlCommand command = new SqlCommand("pa_PromMontoCliente", cnn);
            command.Parameters.AddWithValue("@Monto", numPromMontoMin.Value);

            command.CommandType = CommandType.StoredProcedure;

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            rvPromMontos.LocalReport.DataSources.Clear();
            rvPromMontos.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dsRepPMC", table));
            rvPromMontos.RefreshReport();

            cnn.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
