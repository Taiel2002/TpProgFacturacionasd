using FacturacionBackend;
using FacturacionBackend.accesoDatos;
using FacturacionBackend.dominio;
using FacturacionBackend.servicio.cache;
using FacturacionBackend.servicio.implementaciones;
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
    public partial class FrmEditarFacturas : Form
    {
        IFacturaDao _facturaDao = new FacturaDao();

        public Factura oFactura;
        private FacturaService servicio;

        private FrmFacturas frmFactura = null;

        public FrmEditarFacturas(int nroFactura, FrmFacturas frmFacturas)
        {
            frmFactura = frmFacturas;

            InitializeComponent();
            SetDgv(nroFactura);

            oFactura = new Factura();
            servicio = new FacturaService(new DaoFactory());

            RecuperarFactura(nroFactura);

            CargarComboCliente();
            CargarComboArticulos();
            CargarComboFormasPago();

            RecuperarDetallesFactura(nroFactura);
            CalcularTotal();
        }
        private void getRowsRight()
        {
            dgvDetallesFacturas.Columns["deleteButton"].DisplayIndex = dgvDetallesFacturas.ColumnCount - 1;
        }

        private void RecuperarFactura(int nroFactura)
        {
            DataTable table = servicio.RecuperarFactura(nroFactura);
            foreach (DataRow row in table.Rows)
            {
                oFactura.IdFactura = Convert.ToInt32(row["nroFactura"].ToString());
                oFactura.Usuario.NombreUsuario = row["usuario"].ToString();
                oFactura.Cliente.NomCliente = row["nombre"].ToString();
                oFactura.Cliente.ApeCliente = row["apellido"].ToString();
                oFactura.FormaPago.NombreFormaPago = row["formaPago"].ToString();
            }

            txtUsuario.Text = oFactura.Usuario.NombreUsuario;
            txtFacturaNro.Text = oFactura.IdFactura.ToString();
        }

        private void RecuperarDetallesFactura(int nroFactura)
        {
            DetallesFactura oDetallesFactura = new DetallesFactura();
            DataTable table = servicio.MostrarDetallesFactura(nroFactura);
            foreach (DataRow row in table.Rows)
            {
                oDetallesFactura.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                oDetallesFactura.Articulo.NombreArticulo = row["Articulo"].ToString();
                oFactura.AgregarDetalle(oDetallesFactura);
            }
        }
        
        private void SetDgv(int nroFactura)
        {
            dgvDetallesFacturas.DataSource = _facturaDao.MostrarDetallesFactura(nroFactura);
            getRowsRight();
        }

        private void CargarComboCliente()
        {
            DataTable tabla = servicio.CargarClientes();
            cboCliente.DataSource = tabla;
            cboCliente.ValueMember = tabla.Columns[0].ColumnName;//"IdCliente";
            cboCliente.DisplayMember = tabla.Columns[8].ColumnName;//"NomCliente";
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;

            cboCliente.Text = oFactura.Cliente.NomCliente +" "+ oFactura.Cliente.ApeCliente;

        }

        private void CargarComboFormasPago()
        {
            List<FormaPago> lst = _facturaDao.CargarComboFormasPago(servicio.CargarFormasPago());

            cboFormaPago.DataSource = lst;
            cboFormaPago.ValueMember = "idFormasPago";
            cboFormaPago.DisplayMember = "NombreFormaPago";

            cboFormaPago.Text = oFactura.FormaPago.NombreFormaPago;
        }

        private void CargarComboArticulos()
        {
            List<Articulo> lst = _facturaDao.CargarComboArticulos(servicio.CargarArticulos());

            cboArticulo.DataSource = lst;
            cboArticulo.ValueMember = "idArticulo";
            cboArticulo.DisplayMember = "NombreArticulo";
        }

        private bool ExisteProductoEnGrilla(object text)
        {
            foreach (DataGridViewRow fila in dgvDetallesFacturas.Rows)
            {
                if (fila.Cells["Articulo"].Value.Equals(text))
                    return true;
            }
            return false;
        }

        private void CalcularTotal()
        {
            double totalItem = 0;
            double total = 0;

            DataTable table = servicio.MostrarDetallesFactura(oFactura.IdFactura);
            foreach (DataRow row in table.Rows)
            {
                totalItem = Convert.ToDouble(row["Total"]);
                total += totalItem;
            }
            lblTotal.Text = total.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ExisteProductoEnGrilla(cboArticulo.Text))
            {
                MessageBox.Show("Producto ya agregado como detalle", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (nudCantidadArticulo.Value == 0)
            {
                MessageBox.Show("Debe insertar una CANTIDAD VALIDA",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                nudCantidadArticulo.Focus();
                return;
            }
            else
            {
                DetallesFactura item = new DetallesFactura();

                Articulo oArticulo = (Articulo)cboArticulo.SelectedItem;
                item.Articulo = oArticulo;
                item.Cantidad = (int)nudCantidadArticulo.Value;
                oFactura.AgregarDetalle(item);
                double total = item.Cantidad * item.Articulo.PrecioUnitario;

                _facturaDao.InsertarDetalle(oFactura, item);
                dgvDetallesFacturas.DataSource = _facturaDao.MostrarDetallesFactura(oFactura.IdFactura);
                getRowsRight();

                CalcularTotal();
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FrmEditarFacturas_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cboCliente.SelectedValue.Equals(""))
            {
                MessageBox.Show("Debe Agregar un CLIENTE",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                cboCliente.Focus();
                return;
            }


            else if (dgvDetallesFacturas.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar un articulo",
                                 "Control",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                cboArticulo.Focus();
                return;
            }

            EditarFactura();
            frmFactura.SetDgv();
            this.Dispose();
        }

        private void EditarFactura()
        {
            oFactura.Cliente.IdCliente = (int)cboCliente.SelectedValue;
            oFactura.FormaPago.IdFormasPago = (int)cboFormaPago.SelectedValue;
            oFactura.Total = Convert.ToDouble(lblTotal.Text);
            oFactura.Usuario.IdUsuario = Convert.ToInt32(LoginUser.IdUserActivo);

            if (servicio.EditarFactura(oFactura) == true)
            {
                MessageBox.Show("Factura editada con exito",
                                "Notificacion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrio un problema",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
        }

        private void dgvDetallesFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var cellValue = dgvDetallesFacturas.Rows[e.RowIndex].Cells[1].Value;
                int nroDetalle = Convert.ToInt32(cellValue);

                dgvDetallesFacturas.DataSource = _facturaDao.BorrarDetalleFactura(nroDetalle);
                SetDgv(oFactura.IdFactura);
            }
        }
    }
}
