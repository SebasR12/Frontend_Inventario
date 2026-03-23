using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using Newtonsoft.Json;

namespace Frontend_Inventario.Servicios
{
    public class Categoria_Servicio : Categoria_Interface
    {
        private readonly HttpClient _httpClient;

        public Categoria_Servicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Categoria_Modelo_Respuesta>> Get_Categorias()
        {
            var respuesta = await _httpClient.GetAsync("https://localhost:7005/api/Categoria_");

            var content = await respuesta.Content.ReadAsStringAsync();

            var Get_Categoria = JsonConvert.DeserializeObject<IEnumerable<Categoria_Modelo_Respuesta>>(content);

            return Get_Categoria;
        }

        public async Task<Dictionary<string, object>> Get_Categoria_Id(int idCategoria)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7005/api/Categoria_/{idCategoria}");

            var Get_Categoria = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

            return Get_Categoria;
        }

        public async Task<Categoria_Modelo_Peticion> Crear_Categoria(Categoria_Modelo_Peticion categoria)
        {
            var content = JsonConvert.SerializeObject(categoria);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7005/api/Categoria_", bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contenidoRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Categoria_Modelo_Peticion>(contenidoRespuesta);
                return resultado;
            }
            else
            {
                throw new Exception($"Error al crear: {response.ReasonPhrase}");
            }
        }

        public async Task<Categoria_Modelo_Peticion> Editar_Categoria(Categoria_Modelo_Peticion categoria)
        {
            if (categoria == null || categoria.idCategoria <= 0)
                throw new Exception("La categoría es inválida");

            var content = JsonConvert.SerializeObject(categoria);
            var bodyContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            // URL corregida: quitar el guion bajo
            var response = await _httpClient.PutAsync("https://localhost:7005/api/Categoria_", bodyContent);

            // Lanza excepción si algo falla
            response.EnsureSuccessStatusCode();

            var contenidoRespuesta = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Categoria_Modelo_Peticion>(contenidoRespuesta);
        }


        public async Task<bool> Eliminar_Categoria(int idCategoria)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7005/api/Categoria_/{idCategoria}");
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
