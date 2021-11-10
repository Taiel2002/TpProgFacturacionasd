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
    public partial class FrmReporteClientesMontosFormasPago : Form
    {
        public FrmReporteClientesMontosFormasPago()
        {
            InitializeComponent();
        }

        private void FrmReporteClientesMontosFormasPago_Load(object sender, EventArgs e)
        {

            this.rvClientesMontos.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbFormaPago.SelectedItem is null)
            {
                MessageBox.Show("Debe seleccionar una forma de pago.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idFormaPago = 1;

            switch (cmbFormaPago.Text)
            {
                case "Efectivo":
                    idFormaPago = 1;
                    break;
                case "Tarjeta de Crédito":
                    idFormaPago = 2;
                    break;
                case "Tarjeta de Débito":
                    idFormaPago = 3;
                    break;
            }
            

            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\LocalDBDemo;Initial Catalog=TpProgFacturacion;User ID=sa;Password=dev789");
            cnn.Open();

            SqlCommand command = new SqlCommand("pa_ClienteMontoFormaPago", cnn);
            command.Parameters.AddWithValue("@FormaPago", idFormaPago);

            command.CommandType = CommandType.StoredProcedure;

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            rvClientesMontos.LocalReport.DataSources.Clear();
            rvClientesMontos.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dsClienteMonto", table));
            rvClientesMontos.RefreshReport();

            cnn.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
