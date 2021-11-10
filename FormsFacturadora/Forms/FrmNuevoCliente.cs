
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

namespace Forms
{
    public partial class FrmNuevoCliente : Form
    {
        public Cliente cliente;
        public Barrio barrio;
        public FacturaService servicio;
        public FrmNuevoCliente()
        {
            InitializeComponent();
            cliente = new Cliente();
            barrio = new Barrio();
            servicio = new FacturaService(new DaoFactory());
        }

        private async void groupBox1_Enter(object sender, EventArgs e)
        {
            await CargarComboBarriosAsync();
            await MostrarClientesAsync();
            if (lblId.Text == "ID")
                btnEditar.Enabled = false;

        }

        private async Task CargarComboBarriosAsync() //en vez de llamarlo con GETBARRIOS lo llamamos del service
        {
            string url = "https://localhost:44375/api/Servicio/cargar_barrios";
            List<Barrio> lst = await ClienteSingleton.GetInstance().ConsultarBarrios(url);         

            cboBarrio.DataSource = lst;
            cboBarrio.ValueMember = "IdBarrio";
            cboBarrio.DisplayMember = "NombreBarrio";
        }

        private async void btnAgregar_Click(object sender, EventArgs e) // LLAMAMOS DESDE EL DAO
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar un apellido", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return;
            }

            cliente.NomCliente = txtNombre.Text;
            cliente.ApeCliente = txtApellido.Text;
            cliente.Barrio.IdBarrio = cboBarrio.SelectedIndex + 1;
            cliente.Calle = txtCalle.Text;
            cliente.Altura = txtAltura.Text;
            cliente.Email = txtEmail.Text;
            cliente.Tel = txtTelefono.Text;

            string data = JsonConvert.SerializeObject(cliente);
            bool success;
            string url = "https://localhost:44375/api/Servicio/cliente_nuevo";
            success = await ClienteSingleton.GetInstance().GuardarCliente(url, data);


            if (success) 
            {
                MessageBox.Show("Se guardo un nuevo cliente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Error al intentar grabar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tpProgFacturacionDataSet2.clientes' Puede moverla o quitarla según sea necesario.
           // this.clientesTableAdapter.Fill(this.tpProgFacturacionDataSet2.clientes);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)/// EN VEZ DE LLAMAR A ELIMINAR CLIENTES , LLAMAMOS AL SERVICE
        {
            if (dgvClientes.CurrentCell.ColumnIndex == 8)// Editar
            {
                Cliente EdicionCliente = new Cliente();

                EdicionCliente.IdCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells["colIDC"].Value.ToString());
                EdicionCliente.NomCliente = dgvClientes.CurrentRow.Cells["colNombreC"].Value.ToString();
                EdicionCliente.ApeCliente = dgvClientes.CurrentRow.Cells["colApeC"].Value.ToString();
                EdicionCliente.Calle = dgvClientes.CurrentRow.Cells["colCalleC"].Value.ToString();
                EdicionCliente.Altura = dgvClientes.CurrentRow.Cells["colAlturaC"].Value.ToString();
                EdicionCliente.Barrio.IdBarrio = Convert.ToInt32(dgvClientes.CurrentRow.Cells["colIDB"].Value.ToString());
                EdicionCliente.Email = dgvClientes.CurrentRow.Cells["colEmailC"].Value.ToString();
                EdicionCliente.Tel = dgvClientes.CurrentRow.Cells["colTelCel"].Value.ToString();

                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;

                lblId.Text = EdicionCliente.IdCliente.ToString();
                cboBarrio.SelectedItem = EdicionCliente.Barrio.IdBarrio;
                txtNombre.Text = EdicionCliente.NomCliente;
                txtApellido.Text = EdicionCliente.ApeCliente;
                txtCalle.Text = EdicionCliente.Calle;
                txtAltura.Text = EdicionCliente.Altura;
                txtEmail.Text = EdicionCliente.Email;
                txtTelefono.Text = EdicionCliente.Tel;


            }
            if (dgvClientes.CurrentCell.ColumnIndex == 9)  // eliminar
            {
                DataGridViewRow row = dgvClientes.CurrentRow;
                if (row != null)
                {
                    int IdCliente = Int32.Parse(row.Cells["colIDC"].Value.ToString());
                    
                    if (MessageBox.Show("Se dara de baja el Cliente seleccionado", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string url = "https://localhost:44375/api/Servicio/cliente_eliminar/" + IdCliente.ToString();
                       bool success = await ClienteSingleton.GetInstance().BorrarCliente(url);
                        if (success)
                        {
                            MessageBox.Show("Se dio de baja el articulo", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            

                        }
                        else
                        {
                            MessageBox.Show("mmm, nop", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // await MostrarArticulosAsync();
                        }
                        //servicio.EliminarCliente(IdCliente);
                       await MostrarClientesAsync();
                    }
                }
            }
        }

        private void LimpiarFormCliente()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCalle.Text = "";
            txtAltura.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

            if (txtApellido.Text == "")
            {
                MessageBox.Show("Debe ingresar un apellido", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return;
            }
            cliente.IdCliente = Convert.ToInt32(lblId.Text);
            cliente.NomCliente = txtNombre.Text;
            cliente.ApeCliente = txtApellido.Text;
            cliente.Barrio.IdBarrio = Convert.ToInt32(cboBarrio.SelectedIndex.ToString()+1);
            cliente.Calle = txtCalle.Text;
            cliente.Altura = txtAltura.Text;
            cliente.Email = txtEmail.Text;
            cliente.Tel = txtTelefono.Text;

            string data = JsonConvert.SerializeObject(cliente);
            bool success;
            string url = "https://localhost:44375/api/Servicio/cliente_edicion";
            success = await ClienteSingleton.GetInstance().EditarClientes(url, data);



            if (success)
            {
                MessageBox.Show("Se edito correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarClientesAsync();

                LimpiarFormCliente();
                lblId.Text = "ID";
            }
            else
            {
                MessageBox.Show("Error al editar el Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task MostrarClientesAsync()
        {

            string url = "https://localhost:44375/api/Servicio/cargar_clientes";
            DataTable tabla = await ClienteSingleton.GetInstance().ConsultarClientes(url); 

            //DataTable tabl = servicio.CargarClientes();
            dgvClientes.DataSource = tabla;
            dgvClientes.Show();
        }
    }
}
