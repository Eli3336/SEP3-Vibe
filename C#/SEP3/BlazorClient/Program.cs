using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorClient;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri("https://localhost:7043") 
});
builder.Services.AddScoped<IProductService, ProductHttpClient>();
builder.Services.AddScoped<IOrderItemService, OrderItemHttpClient>();

await builder.Build().RunAsync();

