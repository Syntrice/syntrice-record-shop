using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Create a named HTTP client connecting to the RecordShop backend
// This is duplicated on the server blazor project
builder.Services.AddHttpClient("RecordShopAPI", client => client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:7196"));

await builder.Build().RunAsync();
