using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using Newtonsoft.Json;

namespace Frontend_Inventario.Servicios
{
    public class Movimiento_Servicio : Movimiento_Interface
    {
        private readonly HttpClient _httpClient;

        public Movimiento_Servicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Movimiento_Modelo_Respuesta>> Get_Movimientos()
        {
            var respuesta = await _httpClient.GetAsync("https://localhost:7005/api/MovimientoInventario_");

            var content = await respuesta.Content.ReadAsStringAsync();

            var Get_Mov = JsonConvert.DeserializeObject<IEnumerable<Movimiento_Modelo_Respuesta>>(content);

            return Get_Mov;
        }

        public async Task<Dictionary<string, object>> Get_Movimiento_Id(int idMovimiento)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/MovimientoInventario_/{idMovimiento}");

            var Get_Mov = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

            return Get_Mov;
        }

        public async Task<Movimiento_Modelo_Peticion> Crear_Movimiento(Movimiento_Modelo_Peticion movimiento)
        {
            var content = JsonConvert.SerializeObject(movimiento);

            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7005/api/MovimientoInventario_", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Movimiento_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<Movimiento_Modelo_Peticion> Editar_Movimiento(Movimiento_Modelo_Peticion movimiento)
        {
            var content = JsonConvert.SerializeObject(movimiento);

            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("https://localhost:7005/api/MovimientoInventario_", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Movimiento_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al editar: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> Eliminar_Movimiento(int idMovimiento)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7005/api/MovimientoInventario_/{idMovimiento}");

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
