using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using Newtonsoft.Json;

namespace Frontend_Inventario.Servicios
{
    public class Usuario_Servicio : Usuario_Interface
    {
        private readonly HttpClient _httpClient;

        public  Usuario_Servicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Usuario_Modelo_Respuesta>> Get_Usuarios()
        {
            var respuesta = await _httpClient.GetAsync("https://localhost:7005/api/Usuario_");

            var content = await respuesta.Content.ReadAsStringAsync();

            var Get_User = JsonConvert.DeserializeObject<IEnumerable<Usuario_Modelo_Respuesta>>(content);

            return Get_User;
        }

        public async Task<Dictionary<string, object>> Get_Usuario_Id(int idUsuario)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/Usuario_/{idUsuario}");

            var Get_User = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

            return Get_User;
        }

        public async Task<Usuario_Modelo_Peticion> Crear_Usuario(Usuario_Modelo_Peticion usuario)
        {
            var content = JsonConvert.SerializeObject(usuario);

            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7005/api/Usuario_", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Usuario_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<Usuario_Modelo_Peticion> Editar_Usuario(Usuario_Modelo_Peticion usuario)
        {
            var content = JsonConvert.SerializeObject(usuario);

            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("https://localhost:7005/api/Usuario_", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Usuario_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> Eliminar_Usuario(int idUsuario)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7005/api/Usuario_/{idUsuario}");

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
