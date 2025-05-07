using SendKeys.BLL;
using SendKeys.BLL.ActiveWindow;
using StreamingApp.API.VTubeStudio;
using StreamingApp.API.VTubeStudio.Props;
using StreamingAppClient.Core.Api;
using StreamingAppClient.Core.Utility.Caching.Interface;
using StreamingAppClient.Core.VtubeStudio.Props;
using StreamingAppClient.SignalR;
using System.Globalization;
using WebSocketSharp;

namespace StreamingAppClient.View;

public partial class ClientForm : Form
{
    private readonly ISignalRClient _signalRClient;

    private readonly IVTubeStudioApiRequest _vTubeStudioApiRequest;

    private readonly ICache _cache;

    private readonly ISend _send;

    private ActiveWindowWatcher activeWindowWatcher;
    private ActiveWindowModel activeWindow = ActiveWindowModel.CreateEmpty();

    private System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[.][0-9]+$|^-?[0-9]*[.]{0,1}[0-9]*$");

    public ClientForm(ISignalRClient signalRClient, IVTubeStudioApiRequest vTubeStudioApiRequest, ICache cache, ISend send)
    {
        _signalRClient = signalRClient;
        _vTubeStudioApiRequest = vTubeStudioApiRequest;
        _cache = cache;
        InitializeComponent();

        activeWindowWatcher = new ActiveWindowWatcher(TimeSpan.FromSeconds(1));
        activeWindowWatcher.ActiveWindowChanged += ActiveWindowWatcher_ActiveWindowChanged;
        activeWindowWatcher.Start();
        _send = send;
    }

    private void ActiveWindowWatcher_ActiveWindowChanged(object sender, ActiveWindowChangedEventArgs e)
    {
        activeWindow = ActiveWindowModel.Create(e.WindowHandle, e.WindowTitle);
    }

    private void hubconnect_Click(object sender, EventArgs e)
    {
        _signalRClient.OnInitializedAsync();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        //await _vTubeStudioInitialize.Initalize();

        var t = await _vTubeStudioApiRequest.GetPosData();

        PosX.Text = t.positionX.ToString();
        PosY.Text = t.positionY.ToString();
        PosR.Text = t.rotation.ToString();
        PosSize.Text = t.size.ToString();

        //Model
        var models = await _vTubeStudioApiRequest.GetModels();

        ModelList.Items.Clear();

        foreach (var model in models)
        {
            ModelList.Items.Add($"{model.ModelName}: {model.ModelID}");
        }

        //Toggles
        var toggles = await _vTubeStudioApiRequest.GetToggles();

        ModelToggleList.Items.Clear();

        foreach (var toggle in toggles)
        {
            ModelToggleList.Items.Add($"{toggle.Name}: {toggle.HotkeyID}");
        }

        //Items
        var itemData = await _vTubeStudioApiRequest.GetItems();

        ItemList.Items.Clear();

        foreach (var item in itemData.AvailableItems)
        {
            ItemList.Items.Add($"{item.FileName}");
        }

        foreach (var item in itemData.ItemsInScene)
        {
            ActiveItemList.Items.Add($"{item.FileName}: {item.InstanceID}");
        }

        await _vTubeStudioApiRequest.Live2DParameter();
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        var t = !PosX.Text.IsNullOrEmpty();

        float x = !PosX.Text.IsNullOrEmpty() ? float.Parse(PosX.Text, CultureInfo.InvariantCulture) : float.NaN;
        float y = !PosY.Text.IsNullOrEmpty() ? float.Parse(PosY.Text, CultureInfo.InvariantCulture) : float.NaN;
        float r = !PosR.Text.IsNullOrEmpty() ? float.Parse(PosR.Text, CultureInfo.InvariantCulture) : float.NaN;
        float s = !PosSize.Text.IsNullOrEmpty() ? float.Parse(PosSize.Text, CultureInfo.InvariantCulture) : float.NaN;

        await _vTubeStudioApiRequest.ChangeLocaton(x, y, r, s);
    }

    private void PosX_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !regex.IsMatch(PosX.Text);
    }

    private void PosY_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !regex.IsMatch(PosY.Text);
    }

    private void PosR_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !regex.IsMatch(PosR.Text);
    }

    private void PosSize_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !regex.IsMatch(PosSize.Text);
    }

    private async void ModelList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var id = ModelList.Items[ModelList.SelectedIndex].ToString().Split(':')[1];

        id = id.Replace(" ", "");

        await _vTubeStudioApiRequest.SetModel(id);

        var toggles = await _vTubeStudioApiRequest.GetToggles();

        ModelToggleList.Items.Clear();

        foreach (var toggle in toggles)
        {
            ModelToggleList.Items.Add($"{toggle.Name}: {toggle.HotkeyID}");
        }

        var models = await _vTubeStudioApiRequest.GetModels();

        var modelID = await _vTubeStudioApiRequest.GetCurrentModel();
        var index = models.FindIndex(m => m.ModelID == modelID);
        models[index].IsActive = true;

        VtubeStudioData vtubeStudioData = new()
        {
            AvailableItems = null,
            ItemsInScene = null,
            Models = models,
            ModelToggles = toggles
        };

        await _send.SendToServer(vtubeStudioData);
    }

    private async void ModelToggleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var id = ModelToggleList.Items[ModelToggleList.SelectedIndex].ToString().Split(':')[1];

        id = id.Replace(" ", "");

        await _vTubeStudioApiRequest.SetToggle(id);
    }

    private async void ItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var fileName = ItemList.Items[ItemList.SelectedIndex].ToString();

        Item item = new Item()
        {
            FileName = fileName,
            InstanceID = "",
            PositionX = 0,
            PositionY = 0,
            Size = 0.3f,
            Rotation = 360,
            Flipped = false,
            Order = 1,
            Censored = false,
        };

        ActiveItemList.Items.Add(fileName);

        await _vTubeStudioApiRequest.SetItem(item);

        var itemData = await _vTubeStudioApiRequest.GetItems();
        VtubeStudioData vtubeStudioData = new()
        {
            AvailableItems = null,
            ItemsInScene = itemData.ItemsInScene,
            Models = null,
            ModelToggles = null
        };

        await _send.SendToServer(vtubeStudioData);
    }

    private async void ActiveItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var index = ActiveItemList.SelectedIndex;

        if (index == -1)
        {
            return;
        }

        var data = ActiveItemList.Items[index].ToString().Split(':');

        var fileName = string.Empty;
        var instanceID = string.Empty;
        if (data.Length > 1)
        {
            fileName = data[0];
            instanceID = data[1].Replace(" ", "");
        }
        else
        {
            fileName = ActiveItemList.Items[index].ToString();
        }

        Item item = new Item()
        {
            FileName = fileName,
            InstanceID = instanceID,
        };
        await _vTubeStudioApiRequest.RemoveItems(new List<Item> { item });

        if (ActiveItemList.Items.Count > 1)
        {
            ActiveItemList.Items.RemoveAt(index);
        }
        else
        {
            ActiveItemList.Items.Clear();
        }

        var itemData = await _vTubeStudioApiRequest.GetItems();
        VtubeStudioData vtubeStudioData = new()
        {
            AvailableItems = null,
            ItemsInScene = itemData.ItemsInScene,
            Models = null,
            ModelToggles = null
        };

        await _send.SendToServer(vtubeStudioData);
    }

    private void TestSend_Click(object sender, EventArgs e)
    {
        WindowAPI.SendKeys(activeWindow.WindowHandle, "[mmaa<200,22>mmaa<1000,22>uw<400,20>uw<200,22>uw<200,23>uw<600,22]~");
    }

    private void setWindow_Click(object sender, EventArgs e)
    {
        activeWindowWatcher.Stop();
        Console.WriteLine(activeWindow.WindowHandle.ToString());
        WindowAPI.SendKeys(activeWindow.WindowHandle, "[:phoneme on]~");

        _cache.AddWindowHandle(activeWindow.WindowHandle);
    }

    private async void GetInfo_Click(object sender, EventArgs e)
    {
        var itemData = await _vTubeStudioApiRequest.GetItems();

        var models = await _vTubeStudioApiRequest.GetModels();

        var modelID = await _vTubeStudioApiRequest.GetCurrentModel();
        var index = models.FindIndex(m => m.ModelID == modelID);
        models[index].IsActive = true;

        var toggles = await _vTubeStudioApiRequest.GetToggles();

        VtubeStudioData vtubeStudioData = new()
        {
            AvailableItems = itemData.AvailableItems,
            ItemsInScene = itemData.ItemsInScene,
            Models = models,
            ModelToggles = toggles
        };

        await _send.SendToServer(vtubeStudioData);
    }
}
