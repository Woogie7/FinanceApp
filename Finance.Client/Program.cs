using Finance.Client;
using Finance.Client.Services;
using Finance.Client.Services.Interface;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7266/") });

builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

await builder.Build().RunAsync();
