
namespace StreamingAppClient.SignalR;

public interface ISignalRClient
{
    Task OnInitializedAsync();
    Task SendMessages();
}