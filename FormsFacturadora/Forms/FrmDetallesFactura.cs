
using FacturacionBackend.accesoDatos;
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
    public partial class FrmDetallesFactura : Form
    {
        IFacturaDao _facturaDao = new FacturaDao();
        int idFactura;

        public FrmDetallesFactura(int nroFactura)
        {
            InitializeComponent();
            idFactura = nroFactura;
            SetDgv(nroFactura);
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    FrmEditarFacturas nuevo = new FrmEditarFacturas(idFactura, null);
                    nuevo.Show();
                    break;
                case 1:
                    var cellValue = dgvFacturas.Rows[e.RowIndex].Cells[2].Value;
                    int nroDetalle = Convert.ToInt32(cellValue);

                    dgvFacturas.DataSource = _facturaDao.BorrarDetalleFactura(nroDetalle);
                    SetDgv(idFactura);
                    break;
            }
        }

        private void SetDgv(int nroFactura)
        {
            dgvFacturas.DataSource = _facturaDao.MostrarDetallesFactura(nroFactura);
            getRowsRight();
        }

        private void getRowsRight()
        {
            dgvFacturas.Columns["editButton"].DisplayIndex = dgvFacturas.ColumnCount - 1;
            dgvFacturas.Columns["deleteButton"].DisplayIndex = dgvFacturas.ColumnCount - 1;
        }

        private void FrmDetallesFactura_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
