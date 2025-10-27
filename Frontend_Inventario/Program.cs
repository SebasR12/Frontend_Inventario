using Frontend_Inventario;
using Frontend_Inventario.Servicios;
using Frontend_Inventario.Servicios.iServicios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<Usuario_Interface, Usuario_Servicio>();
builder.Services.AddScoped<Producto_Interface, Producto_Servicio>();
builder.Services.AddScoped<Proveedor_Interface, Proveedor_Servicio>();
builder.Services.AddScoped<Cliente_Interface, Cliente_Servicio>();


await builder.Build().RunAsync();
