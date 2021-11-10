using FacturacionBackend.dominio;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FormsFacturadora.Cliente
{
    class ClienteSingleton
    {
        private static ClienteSingleton instancia;
        private HttpClient cliente;
        private ClienteSingleton()
        {
            cliente = new HttpClient();
        }
        public static ClienteSingleton GetInstance()
        {
            if (instancia == null)
                instancia = new ClienteSingleton();
            return instancia;
        }
        public async Task<string> GetAsync(string url)
        {
            var result = await cliente.GetAsync(url);
            var content = "";
            if (result.IsSuccessStatusCode)
                content = await result.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> PostAsync(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8,
            "application/json");
            var result = await cliente.PostAsync(url, content);
            var response = "";
            if (result.IsSuccessStatusCode)
                response = await result.Content.ReadAsStringAsync();
            return response;
        }
        public async Task<string> DeleteAsync(string url)
        {
            var result = await cliente.DeleteAsync(url);
            var content = "";
            if (result.IsSuccessStatusCode)
                content = await result.Content.ReadAsStringAsync();
            return content;
        }

        //      **********************************
        //      **          ARTICULOS           **
        //      **********************************
        public async Task<DataTable> ConsultarArticulos(string url)
        {

            var result = await cliente.GetAsync(url);
            var contenido = await result.Content.ReadAsStringAsync();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(contenido, (typeof(DataTable)));
            return dt;

        }
        public async Task<bool> GuardarArticulos(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8,
             "application/json");
            var result = await cliente.PostAsync(url, content);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> EditarArticulos(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8,
             "application/json");
            var result = await cliente.PutAsync(url, content);
            return result.IsSuccessStatusCode;
        }


        //      **********************************
        //      **         CLIENTES             **
        //      **********************************
        public async Task<List<Barrio>> ConsultarBarrios(string url)
        {
            var result = await cliente.GetAsync(url);
            List<Barrio> barrios = (List<Barrio>)JsonConvert.DeserializeObject(await result.Content.ReadAsStringAsync(), (typeof(List<Barrio>)));
            return barrios;
        }

        public async Task<bool> GuardarCliente(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8,
             "application/json");
            var result = await cliente.PostAsync(url, content);
            return result.IsSuccessStatusCode;
        }

        public async Task<DataTable> ConsultarClientes(string url)
        {

            var result = await cliente.GetAsync(url);
            var contenido = await result.Content.ReadAsStringAsync();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(contenido, (typeof(DataTable)));
            return dt;

        }
        public async Task<bool> EditarClientes(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8,
             "application/json");
            var result = await cliente.PutAsync(url, content);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> BorrarCliente(string url)
        {
            //StringContent content = new StringContent(data, Encoding.UTF8,
            // "application/json");
            var result = await cliente.DeleteAsync(url);
            return result.IsSuccessStatusCode;
        }

        //      **********************************
        //      *            FACTURA             *
        //      **********************************

        public async Task<DataTable> ConsultarFormasPago(string url)
        {

            var result = await cliente.GetAsync(url);
            var contenido = await result.Content.ReadAsStringAsync();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(contenido, (typeof(DataTable)));
            return dt;

        }

        public async Task<bool> GuardarFactura(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8,
             "application/json");
            var result = await cliente.PostAsync(url, content);
            return result.IsSuccessStatusCode;
        }


    }
}

