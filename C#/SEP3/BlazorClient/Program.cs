using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorClient;
using BlazorClient.Auth;
using BlazorClient.Services;
using BlazorClient.Services.ClientInterfaces;
using BlazorClient.Services.Http;
using BlazorClient.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri("https://localhost:7043") 
});
builder.Services.AddScoped<IProductService, ProductHttpClient>();
builder.Services.AddScoped<ICustomerService, CustomerHttpClient>();

builder.Services.AddScoped<IOrderItemService, OrderItemHttpClient>();



builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();


AuthorizationPolicies.AddPolicies(builder.Services);

await builder.Build().RunAsync();

