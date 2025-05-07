using StreamingApp.API.VTubeStudio.Props;

namespace StreamingAppClient.Core.VtubeStudio.Props;
public class VtubeStudioData
{
    public List<Item>? AvailableItems { get; set; }

    public List<Item>? ItemsInScene { get; set; }

    public List<Model>? Models { get; set; }

    public List<Toggle>? ModelToggles { get; set; }
}
