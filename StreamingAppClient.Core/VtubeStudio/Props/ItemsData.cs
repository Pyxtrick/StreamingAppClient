using StreamingApp.API.VTubeStudio.Props;

namespace StreamingAppClient.Core.VtubeStudio.Props
{
    public class ItemsData
    {
        public List<Item> AvailableItems { get; set; }

        public List<Item> ItemsInScene { get; set; }

        public int[] AvailableSpots { get; set; }
    }
}
