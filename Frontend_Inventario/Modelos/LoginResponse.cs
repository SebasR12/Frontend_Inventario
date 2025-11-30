using Newtonsoft.Json;

namespace Frontend_Inventario.Modelos
{
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string token { get; set; } = string.Empty;

        [JsonProperty("nombre")]
        public string nombre { get; set; } = string.Empty;

        [JsonProperty("rol")]
        public int rol { get; set; }
    }
}
