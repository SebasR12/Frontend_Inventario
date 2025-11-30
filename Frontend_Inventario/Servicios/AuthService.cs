using Frontend_Inventario.Modelos;
using Frontend_Inventario.Servicios.iServicios;
using System.Net.Http.Json;
using Blazored.LocalStorage;

namespace Frontend_Inventario.Servicios
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        public async Task<LoginResponse?> Login(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/Auth/login", request);

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            // 👉 Si vino el token, lo guardamos
            if (result != null && !string.IsNullOrEmpty(result.token))
            {
                await _localStorage.SetItemAsync("authToken", result.token);
                await _localStorage.SetItemAsync("userName", result.nombre);
                await _localStorage.SetItemAsync("userRol", result.rol);
            }

            return result;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("userName");
            await _localStorage.RemoveItemAsync("userRol");
        }
    }
}
