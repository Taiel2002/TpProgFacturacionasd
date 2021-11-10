﻿using FacturacionBackend.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.accesoDatos
{
    public class FacturaDao : IFacturaDao
    {
        public int IdProximaFactura()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=VINCENT\SQLEXPRESS;Initial Catalog=TpProgFacturacion;Integrated Security=True");
            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "pa_ProximoIdFactura";

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@prox";
            param.SqlDbType = SqlDbType.Int;
            param.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(param);

            cmd.ExecuteReader();
            conexion.Close();

            return Convert.ToInt32(param.Value);
        }
        public DataTable ConsultarClientes()
        { 
            HelperDao helper = HelperDao.InstanciaHelperDao();
            return helper.SqlConsulta("pa_ConsultarClientes"); 
        }

        public DataTable ConsultarArticulos()
        {
            HelperDao helper = HelperDao.InstanciaHelperDao();
            return helper.SqlConsulta("pa_ConsultarArticulos");            
        }

        public DataTable ConsultarFormaPago()
        {
            HelperDao helper = HelperDao.InstanciaHelperDao();
            return helper.SqlConsulta("pa_ConsultarFormasPago");
            
        }
        


        public bool CrearFactura(Factura oFactura)
        {
            SqlTransaction transaction = null;
            SqlConnection conexion = new SqlConnection(@"Data Source = VINCENT\SQLEXPRESS; Initial Catalog = TpProgFacturacion; Integrated Security = True");

            bool flag = true;

            try
            {
                conexion.Open();
                 transaction = conexion.BeginTransaction();

                SqlCommand cmd = new SqlCommand("pa_InsertarMaestro", conexion, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_forma_pago", oFactura.FormaPago.IdFormasPago);
                cmd.Parameters.AddWithValue("@id_cliente", oFactura.Cliente.IdCliente);
                cmd.Parameters.AddWithValue("@id_usuario", oFactura.Usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@fecha", oFactura.FechaFactura);
                cmd.Parameters.AddWithValue("@total", oFactura.Total);

                SqlParameter param = new SqlParameter();
                param.ParameterName = ("@facturaNro");
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int nroFactura = (int)param.Value;
                int nroDetalle = 0;

                foreach (DetallesFactura item in oFactura.Detalles)
                {
                    SqlCommand cmd2 = new SqlCommand("pa_InsertarDetalle", conexion,transaction);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@nroFactura", nroFactura);
                    cmd2.Parameters.AddWithValue("@idArticulo", item.Articulo.IdArticulo);
                    cmd2.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmd2.Parameters.AddWithValue("@nroDetalle", ++nroDetalle);
                      cmd2.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return flag;
        }




        public bool GuardarArticulo(Articulo oArticulo)
        {
            SqlTransaction transaction = null;
            SqlConnection conexion = new SqlConnection(@"Data Source = VINCENT\SQLEXPRESS; Initial Catalog = TpProgFacturacion; Integrated Security = True");
            bool flag = true;
            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_InsertarArticulo", conexion, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idArticulo", oArticulo.IdArticulo);
                cmd.Parameters.AddWithValue("@descripcion", oArticulo.NombreArticulo);
                cmd.Parameters.AddWithValue("@preUnitario", oArticulo.PrecioUnitario);
                cmd.Parameters.AddWithValue("@stock", oArticulo.Costo);
                cmd.Parameters.AddWithValue("@preCosto", oArticulo.Costo);

                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return flag;
        }

        public bool EditarArticulo(Articulo oArticulo)
        {
            SqlTransaction transaction = null;
            SqlConnection conexion = new SqlConnection(@"Data Source = VINCENT\SQLEXPRESS; Initial Catalog = TpProgFacturacion; Integrated Security = True");
            bool flag = true;
            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_EditarArticulos", conexion, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idArticulo", oArticulo.IdArticulo);
                cmd.Parameters.AddWithValue("@descripcion", oArticulo.NombreArticulo);
                cmd.Parameters.AddWithValue("@preUnitario", oArticulo.PrecioUnitario);
                cmd.Parameters.AddWithValue("@stock", oArticulo.Stock);
                cmd.Parameters.AddWithValue("@preCosto", oArticulo.Costo);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return flag;
        }

        public bool EliminarArticulo(int idArticulo)
        {
            SqlTransaction transaction = null;
            SqlConnection conexion = new SqlConnection(@"Data Source = VINCENT\SQLEXPRESS; Initial Catalog = TpProgFacturacion; Integrated Security = True");
            int retorno = 0;
            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_EliminarArticulo", conexion, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idArticulo", idArticulo);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException)
            {
                transaction.Rollback();
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return retorno == 1;
        }





        public bool GuardarCliente(Cliente oCliente)
        {
            SqlTransaction transaction = null;
            SqlConnection conexion = new SqlConnection(@"Data Source = VINCENT\SQLEXPRESS; Initial Catalog = TpProgFacturacion; Integrated Security = True");
            bool flag = true;
            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();
                SqlCommand cmdMaestro = new SqlCommand("pa_InsertarCliente", conexion, transaction);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.Parameters.AddWithValue("@nombre", oCliente.NomCliente);
                cmdMaestro.Parameters.AddWithValue("@apellido", oCliente.ApeCliente);
                cmdMaestro.Parameters.AddWithValue("@calle", oCliente.Calle);
                cmdMaestro.Parameters.AddWithValue("@idBarrio", oCliente.Barrio.IdBarrio);
                cmdMaestro.Parameters.AddWithValue("@email", oCliente.Email);
                cmdMaestro.Parameters.AddWithValue("@tel", oCliente.Tel);
                cmdMaestro.Parameters.AddWithValue("@altura", oCliente.Altura);

                cmdMaestro.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return flag;
        }

        public bool EditarCliente(Cliente oCliente)
        {
            SqlTransaction transaction = null;
            SqlConnection conexion = new SqlConnection(@"Data Source = VINCENT\SQLEXPRESS; Initial Catalog = TpProgFacturacion; Integrated Security = True");
            bool flag = true;
            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_EditarCliente", conexion, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", oCliente.IdCliente);
                cmd.Parameters.AddWithValue("@nombre", oCliente.NomCliente);
                cmd.Parameters.AddWithValue("@apellido", oCliente.ApeCliente);
                cmd.Parameters.AddWithValue("@calle", oCliente.Calle);
                cmd.Parameters.AddWithValue("@email", oCliente.Email);
                cmd.Parameters.AddWithValue("@telefono", oCliente.Tel);
                cmd.Parameters.AddWithValue("@altura", oCliente.Altura);
                cmd.Parameters.AddWithValue("@idBarrio", oCliente.Barrio.IdBarrio);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return flag;
        }

        public List<Barrio> GetBarrios()
        {
            List<Barrio> lst = new List<Barrio>();
            SqlConnection conexion = new SqlConnection(@"Data Source = VINCENT\SQLEXPRESS; Initial Catalog = TpProgFacturacion; Integrated Security = True");
            conexion.Open();
            SqlCommand cmd = new SqlCommand("pa_ConsultarBarrios", conexion);

            cmd.CommandType = CommandType.StoredProcedure;
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());

            conexion.Close();

            foreach (DataRow row in table.Rows)
            {
                Barrio oBarrio = new Barrio();
                oBarrio.IdBarrio = Convert.ToInt32(row["id_barrio"].ToString());
                oBarrio.NombreBarrio = row["barrio"].ToString();

                lst.Add(oBarrio);
            }

            return lst;
        }

        public bool EliminarCliente(int idCliente)
        {
            SqlTransaction transaction = null;
            SqlConnection conexion = new SqlConnection(@"Data Source = VINCENT\SQLEXPRESS; Initial Catalog = TpProgFacturacion; Integrated Security = True");
            bool retorno = true;
            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();

                SqlCommand cmd = new SqlCommand("pa_EliminarCliente", conexion, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                cmd.ExecuteNonQuery();
                transaction.Commit();

            }
            catch (SqlException)
            {
                transaction.Rollback();
                retorno = false;

            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return retorno;
        }

        public DataTable ConsultarFacturas()
        {
            HelperDao helper = HelperDao.InstanciaHelperDao();
            return helper.SqlConsulta("pa_ConsultarFactura");
        }

        public DataTable MostrarDetallesFactura(int intValue)
        {
            return sqlConsParInt("pa_MostrarDetallesDeFactura", "@nroFactura", intValue);
        }

        public DataTable RecuperarFactura(int intValue)
        {
            return sqlConsParInt("pa_RecuperarFactura", "@nroFactura", intValue);
        }

        public DataTable FiltrosFactura(int nCase, string cboFilText)
        {
            HelperDao helper = HelperDao.InstanciaHelperDao();
            switch (nCase)
            {
                case 0:
                    return helper.SqlConsulta("pa_ConsultarFactura");
                case 1:
                    return sqlConsPar("pa_FiltrarPorCliente", "@cliente", cboFilText);
                case 2:
                    return sqlConsPar("pa_FiltrarPorFormaDePago", "formaPago", cboFilText);
            }
            return helper.SqlConsulta("pa_ConsultarFactura");
        }

        public DataTable FiltroFecha(DateTime fecha)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(@"Data Source=VINCENT\SQLEXPRESS;Initial Catalog=TpProgFacturacion;Integrated Security=True");
                DataTable table = new DataTable();
                SqlCommand cmd = new SqlCommand();

                conexion.Open();

                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_FiltrarPorFecha";
                cmd.Parameters.AddWithValue("@fecha", fecha);

                table.Load(cmd.ExecuteReader());
                conexion.Close();

                return table;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public DataTable FiltroFechas(DateTime fecha1, DateTime fecha2)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=VINCENT\SQLEXPRESS;Initial Catalog=TpProgFacturacion;Integrated Security=True");
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand();

            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "set dateformat dmy";
            comando.ExecuteNonQuery();

            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "pa_FiltrarPorFechas";
            cmd.Parameters.AddWithValue("@fecha1", fecha1);
            cmd.Parameters.AddWithValue("@fecha2", fecha2);

            table.Load(cmd.ExecuteReader());
            conexion.Close();

            return table;
        }

        public DataTable BorrarFactura(int intValue)
        {
            return sqlConsParInt("pa_BorrarFactura", "@nroFactura", intValue);
        }

        public DataTable BorrarDetalleFactura(int intValue)
        {
            return sqlConsParInt("pa_BorrarDetalleFactura", "@nroDetalle", intValue);
        }

        public bool EditarFactura(Factura oFactura)
        {
            SqlTransaction transaction = null;
            SqlConnection conexion = new SqlConnection(@"Data Source=VINCENT\SQLEXPRESS;Initial Catalog=TpProgFacturacion;Integrated Security=True");

            bool flag = true;

            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();

                SqlCommand cmd = new SqlCommand("pa_EditarFactura", conexion, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroFactura", oFactura.IdFactura);
                cmd.Parameters.AddWithValue("@formaPago", oFactura.FormaPago.IdFormasPago);
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente.IdCliente);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return flag;
        }

        public bool InsertarDetalle(Factura oFactura, DetallesFactura item)
        {
            SqlTransaction transaction = null;
            SqlConnection conexion = new SqlConnection(@"Data Source=VINCENT\SQLEXPRESS;Initial Catalog=TpProgFacturacion;Integrated Security=True");

            bool flag = true;

            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();

                SqlCommand cmdMaestro = new SqlCommand("pa_InsertarDetalle", conexion, transaction);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.Parameters.AddWithValue("@nroFactura", oFactura.IdFactura);
                cmdMaestro.Parameters.AddWithValue("@idArticulo", item.Articulo.IdArticulo);
                cmdMaestro.Parameters.AddWithValue("@cantidad", item.Cantidad);
                cmdMaestro.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                flag = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return flag;
        }

        public DataTable sqlConsParInt(string sqlQuery, string param, int intValue)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=VINCENT\SQLEXPRESS;Initial Catalog=TpProgFacturacion;Integrated Security=True");
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand();

            conexion.Open();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlQuery;
            cmd.Parameters.AddWithValue(param, intValue);

            table.Load(cmd.ExecuteReader());
            conexion.Close();

            return table;
        }

        public DataTable sqlConsPar(string sqlQuery, string param, string cboFilText)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=VINCENT\SQLEXPRESS;Initial Catalog=TpProgFacturacion;Integrated Security=True");
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand();

            conexion.Open();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlQuery;
            cmd.Parameters.AddWithValue(param, cboFilText);

            table.Load(cmd.ExecuteReader());
            conexion.Close();

            return table;
        }
        public List<FormaPago> CargarComboFormasPago(DataTable dTable)
        {
            List<FormaPago> lst = new List<FormaPago>();
            DataTable table = dTable;

            foreach (DataRow row in table.Rows)
            {
                FormaPago oForma = new FormaPago();
                oForma.IdFormasPago = Convert.ToInt32(row["id_forma_pago"]);
                oForma.NombreFormaPago = row["descripcion"].ToString();
                lst.Add(oForma);
            }

            return lst;
        }

        public List<Articulo> CargarComboArticulos(DataTable dTable)
        {
            List<Articulo> lst = new List<Articulo>();
            DataTable table = dTable;
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
            return lst;
        }
    }
}
