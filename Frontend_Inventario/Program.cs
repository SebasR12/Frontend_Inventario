using Frontend_Inventario;
using Frontend_Inventario.Auth;
using Frontend_Inventario.Servicios;
using Frontend_Inventario.Servicios.iServicios;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Frontend_Inventario.Servicios.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseUrl = "https://localhost:7005/";

// Blazored LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Registramos el handler
builder.Services.AddTransient<AuthMessageHandler>();

// HttpClient principal usando el handler
builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<AuthMessageHandler>();
    handler.InnerHandler = new HttpClientHandler();  // ← IMPORTANTE

    return new HttpClient(handler)
    {
        BaseAddress = new Uri(apiBaseUrl)
    };
});

// Servicios
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(
    sp => sp.GetRequiredService<CustomAuthStateProvider>()
);

builder.Services.AddScoped<Usuario_Interface, Usuario_Servicio>();
builder.Services.AddScoped<Producto_Interface, Producto_Servicio>();
builder.Services.AddScoped<Proveedor_Interface, Proveedor_Servicio>();
builder.Services.AddScoped<Cliente_Interface, Cliente_Servicio>();
builder.Services.AddScoped<DetalleFactura_Interface, DetalleFactura_Servicio>();
builder.Services.AddScoped<Factura_Interface, Factura_Servicio>();
builder.Services.AddScoped<Movimiento_Interface, Movimiento_Servicio>();
builder.Services.AddScoped<Historial_Interface, Historial_Servicio>();
builder.Services.AddScoped<Rol_Interface, Rol_Servicio>();
builder.Services.AddScoped<Categoria_Interface, Categoria_Servicio>();

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
