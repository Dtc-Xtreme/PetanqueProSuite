using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PetanqueProSuite.AppLogic.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<CompetitionSessionManager>();

await builder.Build().RunAsync();
