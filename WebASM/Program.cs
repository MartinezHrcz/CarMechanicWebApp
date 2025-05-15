using Mechanic.Shared.Modells;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebASM.Services;

namespace WebASM;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5001") });
        builder.Services.AddScoped<IWorkService, WorkService>();
        builder.Services.AddScoped<IClientService, ClientService>();
        await builder.Build().RunAsync();
    }
}