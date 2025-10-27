using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using Newtonsoft.Json;

namespace Frontend_Inventario.Servicios
{
    public class Proveedor_Servicio : Proveedor_Interface
    {
        private readonly HttpClient _httpClient;

        public Proveedor_Servicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Proveedor_Modelo_Respuesta>> Get_Proveedores()
        {
            var respuesta = await _httpClient.GetAsync("https://localhost:7005/api/Proveedor_");

            var content = await respuesta.Content.ReadAsStringAsync();
            
            var Get_Proveedor = JsonConvert.DeserializeObject<IEnumerable<Proveedor_Modelo_Respuesta>>(content);

            return Get_Proveedor;
        }

        public async Task<Dictionary<string, object>> Get_Proveedor_Id(int idProveedor)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/Proveedor_/{idProveedor}");
            
            var Get_Proveedor = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            
            return Get_Proveedor;
        }

        public async Task<Proveedor_Modelo_Peticion> Crear_Proveedor(Proveedor_Modelo_Peticion proveedor)
        {
            var content = JsonConvert.SerializeObject(proveedor);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7005/api/Proveedor_", bodyContent);
            if(response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Proveedor_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<Proveedor_Modelo_Peticion> Editar_Proveedor(Proveedor_Modelo_Peticion proveedor)
        {
            var content = JsonConvert.SerializeObject(proveedor);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://localhost:7005/api/Proveedor_", bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Proveedor_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> Eliminar_Proveedor(int idProveedor)
        {
            var response =await _httpClient.DeleteAsync($"https://localhost:7005/api/Proveedor_/{idProveedor}");
            if (response.IsSuccessStatusCode) {
                return true;
            }
            else
            {
                return false;
            }
        }        
    }
}
