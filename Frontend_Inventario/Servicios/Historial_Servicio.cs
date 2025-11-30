using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using Newtonsoft.Json;

namespace Frontend_Inventario.Servicios
{
    public class Historial_Servicio : Historial_Interface
    {
        private readonly HttpClient _httpClient;

    public Historial_Servicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Historial_Modelo_Respuesta>> Get_Historial()
        {
            var respuesta = await _httpClient.GetAsync("https://localhost:7005/api/HistorialPrecios_");

            var content = await respuesta.Content.ReadAsStringAsync();

            var Get_Hist = JsonConvert.DeserializeObject<IEnumerable<Historial_Modelo_Respuesta>>(content);

            return Get_Hist;
        }

        public async Task<Dictionary<string, object>> Get_Historial_Id(int idHistorial)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/HistorialPrecios_/{idHistorial}");

            var Get_Hist = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

            return Get_Hist;
        }

        public async Task<Historial_Modelo_Peticion> Crear_Historial(Historial_Modelo_Peticion historial)
        {
            var content = JsonConvert.SerializeObject(historial);

            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7005/api/HistorialPrecios_", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Historial_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<Historial_Modelo_Peticion> Editar_Historial(Historial_Modelo_Peticion historial)
        {
            var content = JsonConvert.SerializeObject(historial);

            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("https://localhost:7005/api/HistorialPrecios_", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Historial_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al editar: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> Eliminar_Historial(int idHistorial)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7005/api/HistorialPrecios_/{idHistorial}");

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
