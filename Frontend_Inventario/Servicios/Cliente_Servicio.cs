using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using Newtonsoft.Json;

namespace Frontend_Inventario.Servicios
{
    public class Cliente_Servicio : Cliente_Interface
    {
        private readonly HttpClient _httpClient;

        public  Cliente_Servicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Cliente_Modelo_Respuesta>> Get_Clientes()
        {
            var respuesta =  _httpClient.GetAsync("https://localhost:7005/api/Cliente_");

            var content = await respuesta.Result.Content.ReadAsStringAsync();

            var Get_Cliente = JsonConvert.DeserializeObject<IEnumerable<Cliente_Modelo_Respuesta>>(content);
            
            return Get_Cliente;
        }

        public async Task<Dictionary<string, object>> Get_Cliente_Id(int idCliente)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/Cliente_/{idCliente}");
            
            var Get_Cliente = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            
            return Get_Cliente;
        }

        public async Task<Cliente_Modelo_Peticion> Crear_Cliente(Cliente_Modelo_Peticion cliente)
        {
            var content = JsonConvert.SerializeObject(cliente);

            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7005/api/Cliente_", bodyContent);

            if(response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<Cliente_Modelo_Peticion> Editar_Cliente(Cliente_Modelo_Peticion cliente)
        {
            var content = JsonConvert.SerializeObject(cliente);

            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("https://localhost:7005/api/Cliente_", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> Eliminar_Cliente(int idCliente)
        {
           var response = await _httpClient.DeleteAsync($"https://localhost:7005/api/Cliente_/{idCliente}");
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
