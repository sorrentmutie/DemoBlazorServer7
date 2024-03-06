using DemoBlazor.Components.Library;
using DemoBlazor.Models.Interfaces;
using DemoBlazor.Models.Services;
using DemoBlazor.WebAssembbly.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IDatiEventi, ServizioDatiEventi>();
builder.Services.AddScoped<ICategorie, ServizioCategorieWASM>();


await builder.Build().RunAsync();
