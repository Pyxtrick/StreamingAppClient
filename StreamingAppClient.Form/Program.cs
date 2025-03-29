using Microsoft.Extensions.DependencyInjection;
using StreamingAppClient.SignalR;

namespace StreamingAppClient.View;

static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var services = new ServiceCollection();

        ConfigureServices(services);

        using (ServiceProvider serviceProvider = services.BuildServiceProvider())
        {
            var form1 = serviceProvider.GetRequiredService<ClientForm>();
            Application.Run(form1);
        }
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        services.AddScoped<ClientForm>();
        //services.AddLogging(configure => configure.AddConsole());
        services.AddLogging();
        services.AddScoped<ISignalRClient, SignalRClient>();
        
    }
}