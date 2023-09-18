using Example.PrerenderingWithWorkers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.WebWorkers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);

// BlazorJS.WebWorkers
await builder.Build().BlazorJSRunAsync();

static void ConfigureServices(IServiceCollection services, string baseAddress)
{
    services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

    // BlazorJS.WebWorkers
    services.AddBlazorJSRuntime();
    services.AddWebWorkerService();

    services.AddSingleton<IMyWorker, MyWorker>();
}
