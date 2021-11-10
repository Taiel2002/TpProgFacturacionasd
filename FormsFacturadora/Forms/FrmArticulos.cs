
using FacturacionBackend.dominio;
using FacturacionBackend.servicio.implementaciones;
using FormsFacturadora.Cliente;
using Newtonsoft.Json;
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

namespace Forms.Formularios
{
    public partial class FrmArticulos : Form
    {
        public Articulo oArticulo;
        public FacturaService servicio;
        
        public FrmArticulos()
        {
            InitializeComponent();
            oArticulo = new Articulo();
            servicio = new FacturaService(new DaoFactory());
        }

        private async void FrmArticulos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsArticulos.articulos' Puede moverla o quitarla según sea necesario.
           // this.articulosTableAdapter.Fill(this.dsArticulos.articulos);
           await MostrarArticulosAsync();
            if (string.IsNullOrEmpty(txtId.Text))
                btnEditar.Enabled = false;
            


        }

        private async Task MostrarArticulosAsync()
        {
            string url = "https://localhost:44375/api/Servicio/cargar_articulos";
            DataTable tabla = await ClienteSingleton.GetInstance().ConsultarArticulos(url);
            //DataTable table = servicio.CargarArticulos();
                        
            dgvArticulos.DataSource = tabla;
            
            dgvArticulos.Show();
            
        }

        private async void  btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcionArticulo.Text))
            {
                MessageBox.Show("Debe ingresar un Articulo", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcionArticulo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPrecioUnit.Text))
            {
                MessageBox.Show("Debe ingresar Precios", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioUnit.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPrecioCosto.Text))
            {
                MessageBox.Show("Debe ingresar Precios", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioUnit.Focus();
                return;
            }
            
            oArticulo.NombreArticulo = txtDescripcionArticulo.Text;
            oArticulo.PrecioUnitario = Convert.ToDouble(txtPrecioUnit.Text);
            oArticulo.Stock = Convert.ToInt32(txtStock.Text);
            oArticulo.Costo = Convert.ToDouble(txtPrecioCosto.Text);

            string data = JsonConvert.SerializeObject(oArticulo);
            bool success;
            string url = "https://localhost:44375/api/Servicio/articulo_nuevo";
            success = await ClienteSingleton.GetInstance().GuardarArticulos(url, data);

            if (success)
            {
                MessageBox.Show("Se guardo un nuevo articulo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarArticulosAsync();
            }
            else
            {
                MessageBox.Show("Error al grabar el Articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArticulos.CurrentCell.ColumnIndex == 5)
            {
                Articulo EditarArticulo = new Articulo();
                EditarArticulo.IdArticulo = Convert.ToInt32(dgvArticulos.CurrentRow.Cells["colID"].Value.ToString());
                EditarArticulo.NombreArticulo = dgvArticulos.CurrentRow.Cells["colDescripcion"].Value.ToString();
                EditarArticulo.PrecioUnitario = Convert.ToDouble(dgvArticulos.CurrentRow.Cells["colPrecio"].Value.ToString());
                EditarArticulo.Stock = Convert.ToInt32(dgvArticulos.CurrentRow.Cells["colStoc"].Value.ToString());
                EditarArticulo.Costo = Convert.ToDouble(dgvArticulos.CurrentRow.Cells["colCosto"].Value.ToString());

                btnNuevoArticulo.Enabled = false;
                txtId.Text = EditarArticulo.IdArticulo.ToString();
                txtDescripcionArticulo.Text = EditarArticulo.NombreArticulo;
                txtPrecioCosto.Text = EditarArticulo.Costo.ToString();
                txtPrecioUnit.Text = EditarArticulo.PrecioUnitario.ToString();
                txtStock.Text = EditarArticulo.Stock.ToString();

                btnEditar.Enabled = true;
            }
            if (dgvArticulos.CurrentCell.ColumnIndex ==6)
            {
                DataGridViewRow row = dgvArticulos.CurrentRow;
                if(row != null)
                {
                    int IdArticulo = Int32.Parse(row.Cells["colID"].Value.ToString());
                    if (MessageBox.Show("Se dara de baja el artículo seleccionado", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string url = "https://localhost:44375/api/Servicio/" + IdArticulo.ToString();
                       string respuesta = await ClienteSingleton.GetInstance().DeleteAsync(url);
                        //servicio.EliminarArticulo(IdArticulo);


                        if (string.IsNullOrEmpty(respuesta))
                        {
                            MessageBox.Show("mmm, nop", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            MessageBox.Show("Se dio de baja el articulo", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await MostrarArticulosAsync();
                        }

                    }
                }
            }
           
        }

        
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcionArticulo.Text))
            {
                MessageBox.Show("Debe ingresar un Articulo", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcionArticulo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPrecioUnit.Text))
            {
                MessageBox.Show("Debe ingresar Precios", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioUnit.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPrecioCosto.Text))
            {
                MessageBox.Show("Debe ingresar Precios", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioUnit.Focus();
                return;
            }

            oArticulo.IdArticulo = Convert.ToInt32(txtId.Text);
            oArticulo.NombreArticulo = txtDescripcionArticulo.Text;
            oArticulo.PrecioUnitario = Convert.ToDouble(txtPrecioUnit.Text);
            oArticulo.Stock = Convert.ToInt32(txtStock.Text);
            oArticulo.Costo = Convert.ToDouble(txtPrecioCosto.Text);

            string data = JsonConvert.SerializeObject(oArticulo);
            bool success;
            string url = "https://localhost:44375/api/Servicio/articulo_edicion";
            success = await ClienteSingleton.GetInstance().EditarArticulos(url,data);



            if (success)
            {
                MessageBox.Show("Se edito correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormArticulo();
            }
            else
            {
                MessageBox.Show("Error al editar el Articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            await MostrarArticulosAsync();


        }

        private void LimpiarFormArticulo()
        {
            txtId.Text = "";
            txtDescripcionArticulo.Text = "";
            txtPrecioCosto.Text = "";
            txtPrecioUnit.Text = "";
            txtStock.Text = "";
        }
    }
}
