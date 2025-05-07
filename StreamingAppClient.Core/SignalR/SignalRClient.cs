using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using SendKeys.BLL;
using StreamingApp.API.VTubeStudio;
using StreamingApp.API.VTubeStudio.Props;
using StreamingAppClient.Core.Utility.Caching.Interface;
using StreamingAppClient.Core.VtubeStudio.Props;
using VTS.Core;

namespace StreamingAppClient.SignalR;

public class SignalRClient : ISignalRClient
{
    private HubConnection? _connection;

    private readonly IVTubeStudioApiRequest _vTubeStudioInitialize;

    private readonly ICache _cache;

    public SignalRClient(ICache cache, IVTubeStudioApiRequest vTubeStudioInitialize)
    {
        _cache = cache;
        _vTubeStudioInitialize = vTubeStudioInitialize;
    }

    public async Task OnInitializedAsync()
    {
        try
        {
            var uri = new Uri("https://localhost:7033/clienthub");

            _connection = new HubConnectionBuilder().WithUrl(uri).WithAutomaticReconnect().Build();

            _connection.On<string>("ReciveClientMessage", (message) =>
            {
                Console.WriteLine(message);
            });

            _connection.On<string>("ReciveClientTTSMessage", (message) =>
            {
                WindowAPI.SendKeys(_cache.GetWindowHandle(), message);
            });

            _connection.On<string>("ReciveClientVtubeStudioModel",async (message) =>
            {
                MoveModelData moveData = JsonConvert.DeserializeObject<MoveModelData>(message);

                if (moveData.itemInsanceID == null)
                {
                    await _vTubeStudioInitialize.ChangeLocaton(moveData.PosX, moveData.PosY, moveData.Rotation, moveData.Size);
                }
                else
                {
                    _vTubeStudioInitialize.SetModel(moveData.itemInsanceID);
                }
            });
            _connection.On<string>("ReciveClientVtubeStudioToggle", (message) =>
            {
                _vTubeStudioInitialize.SetToggle(message);
            });
            _connection.On<string>("ReciveClientVtubeStudioItem", async (message) =>
            {
                try
                {

                    Item item = JsonConvert.DeserializeObject<Item>(message);

                    if (item.PositionX != 0)
                    {
                        await _vTubeStudioInitialize.MoveItem(item.InstanceID, item.PositionX, item.PositionY, item.Rotation, item.Size);
                    }
                    else if (item.InstanceID != null)
                    {
                        await _vTubeStudioInitialize.RemoveItems(new List<Item> { item });
                    }
                    else
                    {
                        await _vTubeStudioInitialize.SetItem(item);
                    }

                }
                catch
                {
                    MoveModelData moveData = JsonConvert.DeserializeObject<MoveModelData>(message);

                    await _vTubeStudioInitialize.MoveItem(moveData.itemInsanceID, moveData.PosX, moveData.PosY, moveData.Rotation, moveData.Size);
                }
            });
            await _connection.StartAsync();
            Console.WriteLine("Connetcted");
        }
        catch
        {
            Console.WriteLine("Connetcion Failed");
        }
    }

    public async Task SendMessages()
    {
        if (_connection == null)
        {
            await OnInitializedAsync();
        }
        
        if(_connection != null)
        {
            await _connection.SendAsync("ReciveClientMessageHub", "hello");
        }
    }
}
