using Microsoft.Extensions.DependencyInjection;
using StreamingApp.API.VTubeStudio;
using StreamingApp.Core.Utility;
using StreamingAppClient.SignalR;
using VTS.Core;

namespace StreamingAppClient.Core;

public static class Registrar
{
    public static void AddCoreOptions(this IServiceCollection services)
    {
        //SignalR
        services.AddScoped<ISignalRClient, SignalRClient>();

        //VTube Studio
        services.AddSingleton<VTubeStudioInitialize>();
        services.AddSingleton<CoreVTSPlugin>();
        services.AddScoped<IVTubeStudioApiRequest, VTubeStudioApiRequest>();
        services.AddScoped<IVTSLogger, ConsoleVTSLoggerImpl>();

        //Options
        services.AddAutoMapper(typeof(CoreMappingProfile));
    }
}
