using FacturacionBackend.dominio;
using FacturacionBackend.accesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.servicio.implementaciones
{
      public class FacturaService : IFacturaService
    {
        private IFacturaDao Dao;

        public FacturaService(AbstractDaoFactory factory)
        {
            Dao = factory.CrearFactura();
        }
        public int IdProximaFactura()
        {
           return Dao.IdProximaFactura();
        }
        public DataTable CargarClientes()
        {
            return Dao.ConsultarClientes();
        }
        public DataTable CargarArticulos()
        {
            return Dao.ConsultarArticulos();
        }
        public DataTable CargarFormasPago()
        {
            return Dao.ConsultarFormaPago();
        }
        public bool CrearFactura(Factura oFactura)
        {
            return Dao.CrearFactura(oFactura);
        }



        public bool GuardarArticulo(Articulo oArticulo)
        {
            return Dao.GuardarArticulo(oArticulo);
        }

        public bool EditarArticulo(Articulo oArticulo)
        {
            return Dao.EditarArticulo(oArticulo);
        }

        public bool EliminarArticulo(int idArticulo)
        {
           return Dao.EliminarArticulo(idArticulo);
        }

        public bool GuardarCliente(Cliente oCliente)
        {
            return Dao.GuardarCliente(oCliente);
        }
        public bool EditarCliente(Cliente oCliente)
        {
            return Dao.EditarCliente(oCliente);
        }
        public List<Barrio> GetBarrios()
        {
            return Dao.GetBarrios();
        }
        public bool EliminarCliente(int idCliente)
        {
            return Dao.EliminarCliente(idCliente);

        }

        public DataTable ConsultarFacturas()
        {
            return Dao.ConsultarFacturas();
        }
        public DataTable MostrarDetallesFactura(int nroFactura)
        {
            return Dao.MostrarDetallesFactura(nroFactura);
        }
        public DataTable FiltrosFactura(int nCase, string cboFilText)
        {
            return Dao.FiltrosFactura(nCase, cboFilText);
        }
        public DataTable FiltroFecha(DateTime fecha)
        {
            return Dao.FiltroFecha(fecha);
        }
        public DataTable FiltroFechas(DateTime fecha1, DateTime fecha2)
        {
            return Dao.FiltroFechas(fecha1, fecha2);
        }
        public DataTable RecuperarFactura(int intValue)
        {
            return Dao.RecuperarFactura(intValue);
        }
        public DataTable BorrarFactura(int intValue)
        {
            return Dao.BorrarFactura(intValue);
        }
        public DataTable BorrarDetalleFactura(int intValue)
        {
            return Dao.BorrarDetalleFactura(intValue);
        }
        public bool EditarFactura(Factura oFactura)
        {
            return Dao.EditarFactura(oFactura);
        }
        public bool InsertarDetalle(Factura oFactura, DetallesFactura item)
        {
            return Dao.InsertarDetalle(oFactura, item);
        }
        public List<Articulo> CargarComboArticulos(DataTable dTable)
        {
            return Dao.CargarComboArticulos(dTable);
        }
        List<FormaPago> CargarComboFormasPago(DataTable dTable)
        {
            return Dao.CargarComboFormasPago(dTable);
        }
    }
}
