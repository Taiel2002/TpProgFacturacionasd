using FacturacionBackend.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.accesoDatos
{
    public interface IFacturaDao
    {
        //***Load General ***
        int IdProximaFactura();
        DataTable ConsultarArticulos();
        DataTable ConsultarClientes();
        DataTable ConsultarFormaPago();
        bool CrearFactura(Factura oFactura);


        bool GuardarArticulo(Articulo oArticulo);

        bool EditarArticulo(Articulo oArticulo);
        bool EliminarArticulo(int idArticulo);

        DataTable ConsultarFacturas();
        DataTable MostrarDetallesFactura(int nroFactura);
        DataTable RecuperarFactura(int intValue);
        DataTable FiltrosFactura(int nCase, string cboFilText);
        DataTable FiltroFecha(DateTime fecha);
        DataTable FiltroFechas(DateTime fecha1, DateTime fecha2);
        DataTable BorrarFactura(int intValue);
        DataTable BorrarDetalleFactura(int intValue);
        bool EditarFactura(Factura oFactura);
        bool InsertarDetalle(Factura oFactura, DetallesFactura item);
        List<Articulo> CargarComboArticulos(DataTable dTable);
        List<FormaPago> CargarComboFormasPago(DataTable dTable);


        bool GuardarCliente(Cliente oCliente);
        bool EditarCliente(Cliente oCliente);
        List<Barrio> GetBarrios();
        bool EliminarCliente(int idCliente);


       
       







    }
}
