using Example.PrerenderingWithWorkers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.WebWorkers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

InternalConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress, false);

// BlazorJS.WebWorkers
await builder.Build().BlazorJSRunAsync();

static void InternalConfigureServices(IServiceCollection services, string baseAddress, bool prerendering)
{
    services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

    if (!prerendering)
    {
        // BlazorJS.WebWorkers
        services.AddBlazorJSRuntime();
        services.AddWebWorkerService();
        services.AddSingleton<IMyWorker, MyWorker>();
    }
}

static void ConfigureServices(IServiceCollection services, string baseAddress)
{
    InternalConfigureServices(services, baseAddress, true);
}