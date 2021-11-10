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
    public partial class FrmFacturas : Form
    {
        IFacturaDao _facturaDao = new FacturaDao();
        private int nCase;
        public FrmFacturas()
        {
            InitializeComponent();
            SetDgv();
            
        }

        private void FrmFacturas_Load(object sender, EventArgs e)
        {
            cboFiltros.Hide();
            pnlFecha.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void SetDgv()
        {
            dgvFacturas.DataSource = _facturaDao.ConsultarFacturas();
            getRowsRight();
        }

        private void cboFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboFiltrarPor.SelectedIndex)
            {
                case 0:
                    cboFiltros.Hide();
                    pnlFecha.Hide();
                    nCase = 0;
                    cboFilterData();
                    getRowsRight();
                    break;

                case 1:
                    cboFiltros.DataSource = _facturaDao.ConsultarClientes();
                    cboFiltros.DisplayMember = "Cliente";
                    cboFiltros.ValueMember = "id_cliente";
                    cboFiltros.SelectedIndex = 0;

                    cboFiltros.Show();
                    pnlFecha.Hide();
                    nCase = 1;
                    cboFilterData();
                    getRowsRight();
                    break;

                case 2:
                    cboFiltros.DataSource = _facturaDao.ConsultarFormaPago();
                    cboFiltros.DisplayMember = "descripcion";
                    cboFiltros.ValueMember = "id_forma_pago";
                    cboFiltros.SelectedIndex = 0;

                    cboFiltros.Show();
                    pnlFecha.Hide();
                    nCase = 2;
                    cboFilterData();
                    
                    break;
                case 3:
                    pnlFecha.Show();
                    filtroFecha();
                    dtpFecha.Value = DateTime.Now.AddDays(-1);
                    getRowsRight();
                    break;
            }
        }

        private void filtroFecha()
        {
           // dtpFecha.Value = DateTime.Now.AddDays(-1);
            DateTime hoy = System.DateTime.Now;
            if (dtpFecha.Value > hoy || dtpHasta.Value > hoy) //se comprueba si fecha2 no es mayor al dia de hoy
            {
                MessageBox.Show("No puede seleccionar una fecha mayor al dia de hoy");
                if (dtpFecha.Value > hoy) dtpFecha.Value = hoy;
                if (dtpHasta.Value > hoy) dtpHasta.Value = hoy;
            }
            else if (dtpFecha.Value > dtpHasta.Value && cbHasta.Checked)
            { //se comprueba que la primer fecha seleccionada no sea mayor que la segunda
                MessageBox.Show("Seleccione un rango valido");
                dtpFecha.Value = DateTime.Now.AddDays(-1);
                dtpHasta.Value = hoy;
            }
            else
            {
                if (!cbHasta.Checked)
                    dgvFacturas.DataSource = _facturaDao.FiltroFecha(dtpFecha.Value);
                else
                    dgvFacturas.DataSource = _facturaDao.FiltroFechas(dtpFecha.Value, dtpHasta.Value);
            }
            
        }

        private void cboFilterData()
        {
            switch(nCase)
            {
                case 0:
                    dgvFacturas.DataSource = _facturaDao.FiltrosFactura(0, "");
                    break;
                case 1:
                    dgvFacturas.DataSource = _facturaDao.FiltrosFactura(1, cboFiltros.Text);
                    break;
                case 2:
                    dgvFacturas.DataSource = _facturaDao.FiltrosFactura(2, cboFiltros.Text);
                    break;
            }
        }

        private void cboFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFilterData();
            getRowsRight();
        }

        private void getRowsRight()
        {
            dgvFacturas.Columns["editButton"].DisplayIndex = dgvFacturas.ColumnCount - 1;
            dgvFacturas.Columns["deleteButton"].DisplayIndex = dgvFacturas.ColumnCount - 1;
            dgvFacturas.Columns["seeMoreButton"].DisplayIndex = dgvFacturas.ColumnCount - 1;
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   
            if(e.RowIndex >= 0)
            {
                var cellValue = dgvFacturas.Rows[e.RowIndex].Cells[3].Value;
                int nroFactura = Convert.ToInt32(cellValue);

                switch (e.ColumnIndex)
                {
                    case 0:
                        FrmEditarFacturas frmEditarFactura = new FrmEditarFacturas(nroFactura, this);
                        frmEditarFactura.Show();
                        break;
                    case 1:
                        dgvFacturas.DataSource = _facturaDao.BorrarFactura(nroFactura);
                        cboFilterData();
                        getRowsRight();
                        break;
                    case 2:
                        FrmDetallesFactura frmDetalles = new FrmDetallesFactura(nroFactura);
                        frmDetalles.Show();
                        break;
                }
            }            
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e){ }

        private void dtpFecha_ValueChanged_1(object sender, EventArgs e)
        {
            filtroFecha();
        }

        private void cbHasta_CheckedChanged(object sender, EventArgs e)
        {
            filtroFecha();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            filtroFecha();
        }

        private void dgvFacturas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cellValue = dgvFacturas.Rows[e.RowIndex].Cells[3].Value;
                int nroFactura = Convert.ToInt32(cellValue);

                switch (e.ColumnIndex)
                {
                    case 0:
                        FrmEditarFacturas frmEditarFactura = new FrmEditarFacturas(nroFactura, this);
                        frmEditarFactura.Show();
                        break;
                    case 1:
                        dgvFacturas.DataSource = _facturaDao.BorrarFactura(nroFactura);
                        cboFilterData();
                        getRowsRight();
                        break;
                    case 2:
                        FrmDetallesFactura frmDetalles = new FrmDetallesFactura(nroFactura);
                        frmDetalles.Show();
                        break;
                }
            }
        }
    }
}
