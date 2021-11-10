using FacturacionBackend;
using FacturacionBackend.dominio;
using FacturacionBackend.servicio.cache;
using FacturacionBackend.servicio.implementaciones;
using FormsFacturadora.Cliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Formularios
{
    public partial class FrmNuevaFactura : Form
    {
        public Factura oFactura;
        private FacturaService servicio;
        
       // public Cliente oCliente;

        public FrmNuevaFactura()
        {
            InitializeComponent();
            oFactura = new Factura();
            servicio = new FacturaService(new DaoFactory());
            
        }

        private async void groupBox1_Enter(object sender, EventArgs e)
        {
            txtFacturaNro.Text = servicio.IdProximaFactura().ToString();
            txtFacturaNro.Enabled = false;

            lblFecha.Text = DateTime.Now.ToString();           

            await CargarComboFormasPagoAsync();
            

            txtUsuario.Text = LoginUser.UsuarioActivo.ToString();

            await CargarComboClienteAsync();
            await CargarComboArticulosAsync();




            //cboCliente.AutoCompleteCustomSource = 

            //dgvNuevaFactura.Rows.Clear();
            //foreach (DetallesFactura detallesFactura in oFactura.Detalles)
            //{
            //    dgvNuevaFactura.Rows.Add(new object[] {
            //        "",
            //        detallesFactura.Articulo.NombreArticulo,
            //        detallesFactura.Articulo.PrecioUnitario,
            //        detallesFactura.Cantidad
            //    });
            //}
            //CalcularTotal();

        }

        private async Task CargarComboClienteAsync()
        {
            string url = "https://localhost:44375/api/Servicio/cargar_clientes";
            DataTable tabla = await ClienteSingleton.GetInstance().ConsultarClientes(url);
            //servicio.CargarClientes();
           // DataTable tabla = servicio.CargarClientes();
            cboCliente.DataSource = tabla;
            cboCliente.ValueMember = tabla.Columns[0].ColumnName;//"IdCliente";
            cboCliente.DisplayMember = tabla.Columns[1].ColumnName;//"NomCliente";
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void AutocompletarCliente()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            
            SqlConnection conexion = new SqlConnection(@"Data Source = VINCENT\SQLEXPRESS; Initial Catalog = TpProgFacturacion; Integrated Security = True");
            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "pa_ConsultarClientes";

            DataTable datos = new DataTable();
            datos.Load(cmd.ExecuteReader());

            for (int i = 1; i < datos.Rows.Count; i++)
            {        
                

                lista.Add(datos.Rows[i]["nombre"].ToString() +" "+ datos.Rows[i]["apellido"].ToString());
                 //lista.Add(datos.Rows[i]["apellido"].ToString());
                //IdClientes.Add(datos.Rows[i]["id_cliente"]);
            }
            conexion.Close();
            
            //cboCliente.AutoCompleteCustomSource = lista;
            //lista.filte
            //txtCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }


        private async Task CargarComboFormasPagoAsync()
        {
            string url = "https://localhost:44375/api/Servicio/cargar_forma_pago";
            DataTable table = await ClienteSingleton.GetInstance().ConsultarFormasPago(url);
            List<FormaPago> lst = new List<FormaPago>();
            
            foreach (DataRow row in table.Rows)
            {
                FormaPago oForma = new FormaPago();
                oForma.IdFormasPago = Convert.ToInt32(row["id_forma_pago"]);
                oForma.NombreFormaPago = row["descripcion"].ToString();
                lst.Add(oForma);
            }
            //return lst;
            cboFormaPago.DataSource = lst;
            cboFormaPago.ValueMember = "idFormasPago";
            cboFormaPago.DisplayMember = "NombreFormaPago";

        }

        
        public async Task CargarComboArticulosAsync()
        {
            //string url = "https://localhost:44375/api/Servicio/cargar_articulos";
            //HttpClient cliente = new HttpClient();
            //var result = await cliente.GetAsync(url);
            //var content = await result.Content.ReadAsStringAsync();
            //List<Articulo> lst2 = JsonConvert.DeserializeObject<List<Articulo>>(content);

            string url = "https://localhost:44375/api/Servicio/cargar_articulos";
            DataTable table = await ClienteSingleton.GetInstance().ConsultarArticulos(url);
            List<Articulo> lst = new List<Articulo>();
            foreach (DataRow row in table.Rows)
            {
                Articulo oArticulo = new Articulo();
                oArticulo.IdArticulo = Convert.ToInt32(row["id_articulo"].ToString());
                oArticulo.NombreArticulo = row["descripcion"].ToString();
                oArticulo.PrecioUnitario = Convert.ToDouble(row["pre_unitario"].ToString());
                oArticulo.Stock = Convert.ToInt32(row["stock"].ToString());
                oArticulo.Costo = Convert.ToDouble(row["pre_costo"].ToString());
                lst.Add(oArticulo);
                }
            

            cboArticulo.DataSource = lst;
            cboArticulo.ValueMember = "idArticulo";
            cboArticulo.DisplayMember = "NombreArticulo";
        }

        private void FrmNuevaFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tpProgFacturacionDataSet.articulos' Puede moverla o quitarla según sea necesario.
         //   this.articulosTableAdapter.Fill(this.tpProgFacturacionDataSet.articulos);
            
            dgvNuevaFactura.Rows.Clear();
            foreach (DetallesFactura detallesFactura in oFactura.Detalles)
            {
                dgvNuevaFactura.Rows.Add(new object[] {
                    detallesFactura.Articulo.IdArticulo,
                    detallesFactura.Articulo.NombreArticulo,
                    detallesFactura.Articulo.PrecioUnitario,
                    detallesFactura.Cantidad
                });
            }
            CalcularTotal();


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

                dgvNuevaFactura.Rows.Add(new object[] { oArticulo.IdArticulo, oArticulo.NombreArticulo, oArticulo.PrecioUnitario, item.Cantidad }); ;

                CalcularTotal();
            }
        }

        private void CalcularTotal()
        {
            double total = oFactura.CalcularTotalFactura();
            txtTotal.Text = total.ToString();

        }

        private bool ExisteProductoEnGrilla(object text)
        {
            foreach (DataGridViewRow fila in dgvNuevaFactura.Rows)
            {
                if (fila.Cells["colNombreArticulo"].Value.Equals(text))
                    return true;
            }
            return false;
        }

        private async void button1_Click(object sender, EventArgs e)
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
           

            else if (dgvNuevaFactura.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar un articulo",
                                 "Control",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                cboArticulo.Focus();
                return;
            }

            await GuardarFacturaAsync();     
        }

        private async Task GuardarFacturaAsync()
        {
            oFactura.Cliente.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
            oFactura.FormaPago.IdFormasPago = Convert.ToInt32(cboFormaPago.SelectedValue);
            oFactura.FechaFactura = Convert.ToDateTime(lblFecha.Text);
            oFactura.Total = Convert.ToDouble(txtTotal.Text);
            oFactura.Usuario.IdUsuario = Convert.ToInt32(LoginUser.IdUserActivo);

            string data = JsonConvert.SerializeObject(oFactura);
            bool success;
            string url = "https://localhost:44375/api/Servicio/factura_nuevo";
            success = await ClienteSingleton.GetInstance().GuardarFactura(url,data);

            if (success)
            {
                MessageBox.Show("Se guardo una nueva Factura",
                                "Notificacion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Dispose();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvNuevaFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNuevaFactura.CurrentCell.ColumnIndex == 4)  // eliminar
            {
                oFactura.QuitarDetalle(dgvNuevaFactura.CurrentRow.Index);
                dgvNuevaFactura.Rows.Remove(dgvNuevaFactura.CurrentRow);
                CalcularTotal();
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmNuevoCliente frm = new FrmNuevoCliente();
            frm.Show();
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 14);
            int ancho = 300;
            int y = 20;

            e.Graphics.DrawString("--- Punto de Venta ---", font , Brushes.Black,
                                    new RectangleF(10,y+=20,ancho,20));
            e.Graphics.DrawString("Factura # " + txtFacturaNro.Text  , font, Brushes.Black,
                                    new RectangleF(10, y += 20, ancho, 20));
            e.Graphics.DrawString("Cliente :" + cboCliente.SelectedValue.ToString(), font, Brushes.Black,
                                    new RectangleF(10, y += 20, ancho, 20));
            e.Graphics.DrawString("--- Productos ---", font, Brushes.Black,
                                    new RectangleF(10, y += 30, ancho, 20));
           

            foreach (DataGridViewRow item in dgvNuevaFactura.Rows)
            {
                e.Graphics.DrawString(item.Cells["colNombreArticulo"].Value.ToString() +"   $ "+
                                      item.Cells["colPrecioArticulo"].Value.ToString() + "   "+ 
                                      item.Cells["colCantidad"].Value.ToString() 
                                      , font, Brushes.Black,
                                    new RectangleF(10, y += 20, ancho, 20));
            }

            e.Graphics.DrawString("--- TOTAL : $" + txtTotal.Text, font, Brushes.Black,
                                    new RectangleF(10, y += 30, ancho, 20));
            e.Graphics.DrawString("--- Gracias por su Visita ---", font, Brushes.Black,
                                    new RectangleF(10, y += 30, ancho, 20));


        }

        private async void btnImprimir_Click(object sender, EventArgs e)
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
            else if (dgvNuevaFactura.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar un articulo",
                                 "Control",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                cboArticulo.Focus();
                return;
            }
            Impresion();
            await GuardarFacturaAsync();
            

        }

        private void Impresion()
        {
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();
        }
    }
}
