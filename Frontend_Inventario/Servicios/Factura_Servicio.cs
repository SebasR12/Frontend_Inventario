using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using Newtonsoft.Json;

namespace Frontend_Inventario.Servicios
{
    public class Factura_Servicio:Factura_Interface
    {
        private readonly HttpClient _httpClient;

        public Factura_Servicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Factura_Modelo_Respuesta>> Get_Factura()
        {
           var respuesta = await _httpClient.GetAsync("https://localhost:7005/api/Factura_");
            var content = await respuesta.Content.ReadAsStringAsync();
            var Get_Factura = JsonConvert.DeserializeObject<IEnumerable<Factura_Modelo_Respuesta>>(content);
            return Get_Factura;
        }

        public async Task<Dictionary<string, object>> Get_Factura_Id(int idFactura)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/Factura_/{idFactura}");
            var Get_Factura = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            return Get_Factura;
        }

        public async Task<Factura_Modelo_Peticion> Crear_Factura(Factura_Modelo_Peticion factura)
        {
            var content = JsonConvert.SerializeObject(factura);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7005/api/Factura_", bodyContent);
            if(response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Factura_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<Factura_Modelo_Peticion> Editar_Factura(Factura_Modelo_Peticion factura)
        {
            var content = JsonConvert.SerializeObject(factura);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://localhost:7005/api/Factura_", bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Factura_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> Eliminar_Factura(int idFactura)
        {
            var response =  await _httpClient.DeleteAsync($"https://localhost:7005/api/Factura_/{idFactura}");
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
