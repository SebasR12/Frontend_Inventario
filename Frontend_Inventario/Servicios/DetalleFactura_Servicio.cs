using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using Newtonsoft.Json;

namespace Frontend_Inventario.Servicios
{
    public class DetalleFactura_Servicio : DetalleFactura_Interface
    {
        private readonly HttpClient _httpClient;

        public DetalleFactura_Servicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Detalle_Factura_Modelo_Respuesta>> Get_DetalleFacturas()
        {
            var respuesta = await _httpClient.GetAsync("https://localhost:7005/api/DetalleFactura_");
            var content = await respuesta.Content.ReadAsStringAsync();
            var Get_DetalleFactura = JsonConvert.DeserializeObject<IEnumerable<Detalle_Factura_Modelo_Respuesta>>(content);
            return Get_DetalleFactura;
        }

        public async Task<Dictionary<string, object>> Get_DetalleFactura_Id(int idDetalle)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/DetalleFactura_/{idDetalle}");
            var Get_DetalleFactura = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            return Get_DetalleFactura;
        }

        public async Task<Dictionary<string, object>> Get_DetalleFactura_IdFactura(int idFactura)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/DetalleFactura_/{idFactura}");
            var Get_Factura = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            return Get_Factura;
        }

        public async Task<Detalle_Factura_Modelo_Peticion> Crear_DetalleFactura(Detalle_Factura_Modelo_Peticion detalleFactura)
        {
            var content = JsonConvert.SerializeObject(detalleFactura);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7005/api/DetalleFactura_", bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Detalle_Factura_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<Detalle_Factura_Modelo_Peticion> Editar_DetalleFactura(Detalle_Factura_Modelo_Peticion detalleFactura)
        {
            var content = JsonConvert.SerializeObject(detalleFactura);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://localhost:7005/api/DetalleFactura_", bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Detalle_Factura_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al editar: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> Eliminar_DetalleFactura(int idDetalle)
        {
           var response = await _httpClient.DeleteAsync($"https://localhost:7005/api/DetalleFactura_/{idDetalle}");
            if (response.IsSuccessStatusCode)
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
