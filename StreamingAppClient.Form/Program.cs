using Microsoft.Extensions.DependencyInjection;
using StreamingApp.API.VTubeStudio;
using StreamingAppClient.Core;

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

        //IConfigurationRoot configuration = builder.Build();

        using (ServiceProvider serviceProvider = services.BuildServiceProvider())
        {
            var vTubeStudioInitialize = serviceProvider.GetRequiredService<IVTubeStudioApiRequest>();
            Task task = vTubeStudioInitialize.Initalize();

            var form1 = serviceProvider.GetRequiredService<ClientForm>();
            Application.Run(form1);
        }
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        //var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        
        services.AddScoped<ClientForm>();
        //services.AddLogging(configure => configure.AddConsole());
        services.AddLogging();
       

        services.AddCoreOptions();


    }
}