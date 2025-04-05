using StreamingApp.API.VTubeStudio.Props;

namespace StreamingAppClient.Core.VtubeStudio.Props
{
    public class ItemsData
    {
        public List<Item> availableItems { get; set; }

        public List<Item> itemsInScene { get; set; }

        public int[] availableSpots { get; set; }
    }
}
