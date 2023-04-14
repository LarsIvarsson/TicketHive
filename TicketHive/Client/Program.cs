using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TicketHive.Client;
using TicketHive.Client.Managers;
using TicketHive.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("TicketHive.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
	.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddBlazoredLocalStorage();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TicketHive.ServerAPI"));
builder.Services.AddScoped<IAppService, AppService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<CurrencyManager>();
builder.Services.AddApiAuthorization();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ICartService, CartService>();

await builder.Build().RunAsync();