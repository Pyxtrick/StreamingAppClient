using AutoMapper;
using StreamingApp.API.VTubeStudio.Props;
using StreamingAppClient.Core.VtubeStudio.Props;
using VTS.Core;

namespace StreamingApp.API.VTubeStudio;

public class VTubeStudioApiRequest : IVTubeStudioApiRequest
{
    //private readonly IConfiguration _configuration;

    //private string Port = _configuration["VtubeStudio:Port"];
    //private string IP = _configuration["VtubeStudio:Ip"];

    private readonly VTubeStudioInitialize _vTubeStudioInitialize;

    private readonly IMapper _mapper;

    private string CurrentModelID = "";

    public VTubeStudioApiRequest(VTubeStudioInitialize vTubeStudioInitialize, IMapper mapper)//IConfiguration configuration)
    {
        //_configuration = configuration;
        _vTubeStudioInitialize = vTubeStudioInitialize;
        _mapper = mapper;
    }

    public async Task Initalize()
    {
        await _vTubeStudioInitialize.InitializeWebSocketAsync("192.168.111.148", 8001);

        await GetCurrentModel();
    }

    #region Model
    private async Task GetCurrentModel()
    {
        //await _vTubeStudioInitialize.Data();

        var currentModelData = await _vTubeStudioInitialize.plugin.GetCurrentModelAsync();

        CurrentModelID = currentModelData.data.modelID;
    }

    public async Task<ModelPosition> GetPosData()
    {
        var currentModelData = await _vTubeStudioInitialize.plugin.GetCurrentModelAsync();

        var modelPos = currentModelData.data.modelPosition;

        return modelPos;
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

    public async Task<List<Model>> GetModels()
    {
        VTSAvailableModelsData availableModels = await _vTubeStudioInitialize.plugin.GetAvailableModelsAsync();

        List<Model> models = availableModels.data.availableModels.Select(_mapper.Map<Model>).ToList();

        return models;
    }
    
    /// <summary>
    /// Change Vtube Stuido Model with ModelID
    /// Only able To change Model Every 2 Seconds
    /// </summary>
    /// <param name="modelID"></param>
    /// <returns></returns>
    public async Task SetModel(string modelID)
    {
        try
        {
            await _vTubeStudioInitialize.plugin.LoadModelAsync(modelID);
            CurrentModelID = modelID;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public async Task ChangeColour()
    {
        var t = await _vTubeStudioInitialize.plugin.GetArtMeshListAsync();
    }

    public async Task Live2DParameter()
    {
        var name = "akari_vts";

        
        var m = await _vTubeStudioInitialize.plugin.GetLive2DParameterListAsync();// => Model

        var itemToggles = await _vTubeStudioInitialize.plugin.GetHotkeysInLive2DItemAsync(name);

        var i = await GetItems();

        await _vTubeStudioInitialize.plugin.TriggerHotkeyForLive2DItemAsync(i.itemsInScene.FirstOrDefault(t => t.fileName.Equals(name)).instanceID, itemToggles.data.availableHotkeys[5].name);

        Console.WriteLine(m);

        //var t = await _vTubeStudioInitialize.plugin.GetHotkeysInLive2DItemAsync(m.dat)

        
    }

    #endregion

    #region Toggles / hotKey
    public async Task<List<Toggle>> GetToggles()
    {
        VTSHotkeysInCurrentModelData CurrentModelToggles = await _vTubeStudioInitialize.plugin.GetHotkeysInCurrentModelAsync(CurrentModelID);

        List<Toggle> toggles = CurrentModelToggles.data.availableHotkeys.Select(_mapper.Map<Toggle>).ToList();

        return toggles;
    }

    public async Task SetToggle(string hotkeyId)
    {
        try
        {
            await _vTubeStudioInitialize.plugin.TriggerHotkeyAsync(hotkeyId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
    #endregion

    #region Items
    public async Task<ItemsData> GetItems()
    {
        VTSItemListOptions option = new VTSItemListOptions()
        {
            includeAvailableSpots = true,
            includeItemInstancesInScene = true,
            includeAvailableItemFiles = true,
            onlyItemsWithFileName = string.Empty,
            onlyItemsWithInstanceID = string.Empty,
        };

        VTSItemListResponseData itemData = await _vTubeStudioInitialize.plugin.GetItemListAsync(option);

        var newItemData = new ItemsData()
        {
            availableItems = itemData.data.availableItemFiles.Select(_mapper.Map<Item>).ToList(),
            itemsInScene = itemData.data.itemInstancesInScene.Select(_mapper.Map<Item>).ToList(),
            availableSpots = itemData.data.availableSpots
        };

        return newItemData;
    }

    public async Task SetItem(Item item)
    {
        VTSItemLoadOptions option = new VTSItemLoadOptions()
        {
            positionX = item.positionX,
            positionY = item.positionY,
            size = item.size,
            rotation = item.rotation,
            fadeTime = 0f,
            order = item.order,
            failIfOrderTaken = false,
            smoothing = 0f,
            censored = item.censored,
            flipped = item.flipped,
            locked = false,
            unloadWhenPluginDisconnects = true,
        };
        try
        {
            await _vTubeStudioInitialize.plugin.LoadItemAsync(item.fileName, option);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task RemoveItems(List<Item> items)
    {
        VTSItemUnloadOptions unloadOption = new VTSItemUnloadOptions()
        {
            itemInstanceIDs = items.Select(t => t.instanceID).ToArray(),
            fileNames = items.Select(t => t.fileName).ToArray(),
            unloadAllInScene = false,
            unloadAllLoadedByThisPlugin = false,
            allowUnloadingItemsLoadedByUserOrOtherPlugins = true,
        };

        await _vTubeStudioInitialize.plugin.UnloadItemAsync(unloadOption);
    }

    public async Task RemoveAllItems()
    {
        VTSItemUnloadOptions unloadOption = new VTSItemUnloadOptions()
        {
            itemInstanceIDs = Array.Empty<string>(),
            fileNames = Array.Empty<string>(),
            unloadAllInScene = true,
            unloadAllLoadedByThisPlugin = false,
            allowUnloadingItemsLoadedByUserOrOtherPlugins = true,
        };

        await _vTubeStudioInitialize.plugin.UnloadItemAsync(unloadOption);
    }

    public async Task<List<Toggle>> GetItemToggles(string itemName)
    {
        var itemToggles = await _vTubeStudioInitialize.plugin.GetHotkeysInLive2DItemAsync(itemName);

        List<Toggle> toggles = itemToggles.data.availableHotkeys.Select(_mapper.Map<Toggle>).ToList();

        return toggles;
    }

    public async Task ToggleItem()
    {
        

        //var t = _vTubeStudioInitialize.plugin.TriggerHotkeyForLive2DItemAsync(itemInstanceId, hotkeyId)
    }
    #endregion
}