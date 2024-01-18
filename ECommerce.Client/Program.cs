using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ECommerce.Client;
using ECommerce.Client.Auth;
using Blazored.LocalStorage;
using ECommerce.Client.Contracts;
using ECommerce.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.Toast;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});
builder.Services.AddBlazoredToast();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CustomStateProvider>();
//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

builder.Services.AddHttpClient<IOrderService, OrderService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5255/");
});
builder.Services.AddHttpClient<IManufacturerDataService, ManufacturerDataService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5255/");
});

builder.Services.AddHttpClient<IProductDataService, ProductDataService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5255/");
});

builder.Services.AddHttpClient<ICategoryDataService, CategoryDataService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5255/");
});
builder.Services.AddHttpClient<IWishlistDataService, WishlistDataService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5255/");
});

builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5255/");
});



await builder.Build().RunAsync();




