using StreamingApp.API.VTubeStudio.Props;
using StreamingAppClient.Core.VtubeStudio.Props;
using VTS.Core;

namespace StreamingApp.API.VTubeStudio;

public interface IVTubeStudioApiRequest
{
    Task Initalize();

    Task<string> GetCurrentModel();

    // Model
    Task ChangeLocaton(float x, float y, float r, float size);
    Task<ModelPosition> GetPosData();
    Task<List<Model>> GetModels();
    Task SetModel(string modelID);

    Task Live2DParameter();

    Task ChangeColour();

    // Toggles / HotKey
    Task<List<Toggle>> GetToggles();
    Task SetToggle(string hotkeyId);

    //Items
    Task<ItemsData> GetItems();
    Task SetItem(Item item);
    Task MoveItem(string itemInsanceID, float x, float y, float r, float size);
    Task RemoveItems(List<Item> items);
    Task RemoveAllItems();
}