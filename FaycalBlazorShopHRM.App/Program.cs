using Blazored.LocalStorage;
using FaycalBlazorShopHRM.App;
using FaycalBlazorShopHRM.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add http client factory
builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
);

// Add state management
builder.Services.AddScoped<ApplicationState>();

// Add support for local storage
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
