using StreamingAppClient.Core.VtubeStudio.Props;

namespace StreamingAppClient.Core.Api;
public interface ISend
{
    Task SendToServer(VtubeStudioData vtubeStudioData);
}