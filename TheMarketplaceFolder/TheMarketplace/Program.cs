using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TheMarketplace;
using Blazored.LocalStorage;
using TheMarketplace.Services.ListingsService;
using TheMarketplace.Services.UserService;
using TheMarketplace.Services.OfferService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IUserService, UserServiceMock>();

builder.Services.AddScoped<ILisitingService, ListingsServiceMock >();

builder.Services.AddSingleton<IOfferService, OfferServiceMock>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
