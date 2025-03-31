using Microsoft.Extensions.Configuration;
using VTS.Core;

namespace StreamingApp.API.VTubeStudio;

public class VTubeStudioInitialize
{
    IVTSLogger _logger;

    public CoreVTSPlugin plugin;

    //private readonly IConfiguration _configuration;

    public VTubeStudioInitialize(IVTSLogger logger)
    {
        _logger = new ConsoleVTSLoggerImpl();
        //_configuration = configuration;
    }

    public async Task InitializeWebSocketAsync(string? ip = null, int port = 8001)
    {
        try
        {
            var websocket = new WebSocketNetCoreImpl(_logger);
            var jsonUtility = new NewtonsoftJsonUtilityImpl();
            var tokenStorage = new TokenStorageImpl("");

            plugin = new CoreVTSPlugin(_logger, 100, "My first plugin", "My Name", "");

            //plugin.SetIPAddress(ip != null ? ip : _configuration["VtubeStudio:Ip"]);
            //plugin.SetPort(port != 8001 ? port : int.Parse(_configuration["VtubeStudio:Port"]));
            
            try
            {
                await plugin.InitializeAsync(websocket, jsonUtility, tokenStorage, () => _logger.LogWarning("Disconnected!"));
                _logger.Log("Connected!");
                Console.WriteLine("Connected to VTubeStudio");

                var apiState = await plugin.GetAPIStateAsync();
                _logger.Log("Using VTubeStudio " + apiState.data.vTubeStudioVersion);
                Console.WriteLine("Using VTubeStudio " + apiState.data.vTubeStudioVersion);

                var currentModel = await plugin.GetCurrentModelAsync();
                _logger.Log("The current model is: " + currentModel.data.modelName);
                Console.WriteLine("The current model is: " + currentModel.data.modelName);
            }
            catch (VTSException e)
            {
                _logger.LogError(e);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void DisconnectWebSocket()
    {
        plugin.Disconnect();
    }
}
