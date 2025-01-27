using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RecordShop.Frontend.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Create a named HTTP client connecting to the RecordShop backend
// This is duplicated on the server blazor project
builder.Services.AddHttpClient("RecordShopAPI", client => client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:7196"));

// Local storage - useful for storing theme preferences
builder.Services.AddBlazoredLocalStorage();

// Add client side profile service for storing user preferences. 
// This needs to be on the server as well, using a different implementation.
builder.Services.AddScoped<IProfileService, ProfileService>();

await builder.Build().RunAsync();
