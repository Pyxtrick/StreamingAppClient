using Microsoft.AspNetCore.SignalR.Client;

namespace StreamingAppClient.SignalR;

public class SignalRClient : ISignalRClient
{
    private HubConnection? _connection;

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
