using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PetanqueProSuite.AppLogic.Services;
using PetanqueProSuite.PWA;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IGameSessionManager, GameSessionManager>();
builder.Services.AddSingleton<ICompetitionSessionManager, CompetitionSessionManager>();
builder.Services.AddScoped<IApiService, ApiService>();

await builder.Build().RunAsync();
