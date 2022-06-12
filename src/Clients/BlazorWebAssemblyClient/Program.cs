using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWebAssemblyClient;
using CurrieTechnologies.Razor.SweetAlert2;
using BlazorWebAssemblyClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("API")["Url"].ToString()) });

builder.Services.AddHttpClient<IHttpApiService, HttpApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("API")["Url"].ToString());

}).AddHttpMessageHandler<ValidateHeaderHandler>();

builder.Services.AddTransient<ValidateHeaderHandler>();

builder.Services.AddSweetAlert2();
builder.Services.AddSingleton<ISpinnerService, SpinnerService>();
builder.Services.AddScoped<IMessageBoxService, MessageBoxService>();

await builder.Build().RunAsync();

