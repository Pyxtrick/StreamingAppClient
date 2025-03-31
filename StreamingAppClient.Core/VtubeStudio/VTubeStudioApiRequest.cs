using Microsoft.Extensions.Configuration;
using VTS.Core;

namespace StreamingApp.API.VTubeStudio;

public class VTubeStudioApiRequest : IVTubeStudioApiRequest
{
    //private readonly IConfiguration _configuration;

    //private string Port = _configuration["VtubeStudio:Port"];
    //private string IP = _configuration["VtubeStudio:Ip"];

    private readonly VTubeStudioInitialize _vTubeStudioInitialize;

    public VTubeStudioApiRequest(VTubeStudioInitialize vTubeStudioInitialize)//IConfiguration configuration)
    {
        //_configuration = configuration;
        _vTubeStudioInitialize = vTubeStudioInitialize;
    }

    public async Task Initalize()
    {
        await _vTubeStudioInitialize.InitializeWebSocketAsync("192.168.111.148", 8001);
    }

    public async Task SendRequest()
    {
        //await _vTubeStudioInitialize.Data();

        var currentModelData = await _vTubeStudioInitialize.plugin.GetCurrentModelAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x">Min -1 Max +1</param>
    /// <param name="y">Min -1 Max +1</param>
    /// <param name="r"></param>
    /// <param name="size">Min -100 Max +100</param>
    /// <returns></returns>
    public async Task ChangeLocaton(float x = float.NaN, float y = float.NaN, float r = float.NaN, float size = float.NaN)
    {
        // TODO: change position of the Character / Model

        var currentModelData = await _vTubeStudioInitialize.plugin.GetCurrentModelAsync();

        var modelPos = currentModelData.data.modelPosition;

        VTSMoveModelData data = new VTSMoveModelData()
        {
            data = {
                timeInSeconds = 2,
                valuesAreRelativeToModel = false,

                positionX = x == float.NaN ? modelPos.positionX : x,
                positionY = y == float.NaN ? modelPos.positionY : y,
                rotation = r == float.NaN ? modelPos.rotation : r,
                size = size == float.NaN ? modelPos.size : size,
            }
        };

        await _vTubeStudioInitialize.plugin.MoveModelAsync(data.data);
    }

    public async Task<ModelPosition> GetPosData()
    {
        var currentModelData = await _vTubeStudioInitialize.plugin.GetCurrentModelAsync();

        var modelPos = currentModelData.data.modelPosition;

        return modelPos;
    }

    public async Task AddItem()
    {
        // TODO: add Item with a timer
    }

    public async Task ChangeColour()
    {
        // TODO: change colour of the Character / Model
    }
}
