using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using Newtonsoft.Json;

namespace Frontend_Inventario.Servicios
{
    public class Producto_Servicio : Producto_Interface
    {
        private readonly HttpClient _httpClient;

        public Producto_Servicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Producto_Modelo_Respuesta>> Get_Producto()
        {
            var respuesta = await _httpClient.GetAsync("https://localhost:7005/api/Producto");

            var content = await respuesta.Content.ReadAsStringAsync();

            var productos = JsonConvert.DeserializeObject<IEnumerable<Producto_Modelo_Respuesta>>(content);

            return productos;
        }

        public async Task<Dictionary<string, object>> Get_Producto_ID(int idProducto)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/Producto/{idProducto}");

            var producto = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

            return producto;
        }

        public async Task<Producto_Modelo_Peticion> Crear_Producto(Producto_Modelo_Peticion producto)
        {
            var content = JsonConvert.SerializeObject(producto);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7005/api/Producto", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear producto: {response.ReasonPhrase}");
            }
        }

        public async Task<Producto_Modelo_Peticion> Editar_Producto(Producto_Modelo_Peticion producto)
        {
            var content = JsonConvert.SerializeObject(producto);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("https://localhost:7005/api/Producto", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al editar producto: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> Eliminar_Producto(int idProducto)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7005/api/Producto/{idProducto}");

            return response.IsSuccessStatusCode;
        }
    }
}
