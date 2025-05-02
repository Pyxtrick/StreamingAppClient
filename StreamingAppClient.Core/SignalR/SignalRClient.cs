using Microsoft.AspNetCore.SignalR.Client;
using SendKeys.BLL;
using StreamingAppClient.Core.Utility.Caching.Interface;

namespace StreamingAppClient.SignalR;

public class SignalRClient : ISignalRClient
{
    private HubConnection? _connection;

    private readonly ICache _cache;

    public SignalRClient(ICache cache)
    {
        _cache = cache;
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
