using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using Newtonsoft.Json;

namespace Frontend_Inventario.Servicios
{
    public class Rol_Servicio : Rol_Interface
    {
        private readonly HttpClient _httpClient;

        public Rol_Servicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Rol_Modelo_Respuesta>> Get_Roles()
        {
            var respuesta = await _httpClient.GetAsync("https://localhost:7005/api/Rol_");

            var content = await respuesta.Content.ReadAsStringAsync();

            var Get_Rol = JsonConvert.DeserializeObject<IEnumerable<Rol_Modelo_Respuesta>>(content);

            return Get_Rol;
        }

        public async Task<Dictionary<string, object>> Get_Rol_Id(int idRol)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/Rol_/{idRol}");

            var Get_Rol = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

            return Get_Rol;
        }

        public async Task<Rol_Modelo_Peticion> Crear_Rol(Rol_Modelo_Peticion rol)
        {
            var content = JsonConvert.SerializeObject(rol);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7005/api/Rol_", bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Rol_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<Rol_Modelo_Peticion> Editar_Rol(Rol_Modelo_Peticion rol)
        {
            var content = JsonConvert.SerializeObject(rol);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://localhost:7005/api/Rol_", bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Rol_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al editar: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> Eliminar_Rol(int idRol)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7005/api/Rol_/{idRol}");
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
