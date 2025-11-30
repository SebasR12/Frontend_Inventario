using Blazored.LocalStorage;
using Frontend_Inventario.Servicios;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Frontend_Inventario.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private string? token;

        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Recuperar token del localStorage
            token = await _localStorage.GetItemAsync<string>("authToken");

            ClaimsIdentity identity;

            if (string.IsNullOrEmpty(token))
            {
                identity = new ClaimsIdentity(); // Usuario anónimo
            }
            else
            {
                identity = new ClaimsIdentity(
                    JwtParser.ParseClaimsFromJwt(token), "jwt"
                );
            }

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        // === LOGIN ===
        public async Task MarcarUsuarioComoAutenticado(string jwt)
        {
            token = jwt;
            await _localStorage.SetItemAsync("authToken", jwt);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        // === LOGOUT ===
        public async Task MarcarUsuarioComoLogout()
        {
            token = null;
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("userName");
            await _localStorage.RemoveItemAsync("userRol");

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
