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

        //Options
        services.AddAutoMapper(typeof(CoreMappingProfile));
    }
}
