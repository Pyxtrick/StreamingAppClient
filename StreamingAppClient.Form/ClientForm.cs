using SendKeys.BLL;
using SendKeys.BLL.ActiveWindow;
using StreamingApp.API.VTubeStudio;
using StreamingApp.API.VTubeStudio.Props;
using StreamingAppClient.Core.Utility.Caching.Interface;
using StreamingAppClient.SignalR;
using System.Diagnostics;
using System.Globalization;
using WebSocketSharp;

namespace StreamingAppClient.View;

public partial class ClientForm : Form
{
    private readonly ISignalRClient _signalRClient;

    private readonly IVTubeStudioApiRequest _vTubeStudioInitialize;

    private readonly ICache _cache;

    private ActiveWindowWatcher activeWindowWatcher;
    private ActiveWindowModel activeWindow = ActiveWindowModel.CreateEmpty();

    private System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[.][0-9]+$|^-?[0-9]*[.]{0,1}[0-9]*$");

    public ClientForm(ISignalRClient signalRClient, IVTubeStudioApiRequest vTubeStudioInitialize, ICache cache)
    {
        _signalRClient = signalRClient;
        _vTubeStudioInitialize = vTubeStudioInitialize;
        _cache = cache;
        InitializeComponent();

        activeWindowWatcher = new ActiveWindowWatcher(TimeSpan.FromSeconds(1));
        activeWindowWatcher.ActiveWindowChanged += ActiveWindowWatcher_ActiveWindowChanged;
        activeWindowWatcher.Start();
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

        var t = await _vTubeStudioInitialize.GetPosData();

        PosX.Text = t.positionX.ToString();
        PosY.Text = t.positionY.ToString();
        PosR.Text = t.rotation.ToString();
        PosSize.Text = t.size.ToString();

        //Model
        var models = await _vTubeStudioInitialize.GetModels();

        ModelList.Items.Clear();

        foreach (var model in models)
        {
            ModelList.Items.Add($"{model.modelName}: {model.modelID}");
        }

        //Toggles
        var toggles = await _vTubeStudioInitialize.GetToggles();

        ModelToggleList.Items.Clear();

        foreach (var toggle in toggles)
        {
            ModelToggleList.Items.Add($"{toggle.name}: {toggle.hotkeyID}");
        }

        //Items
        var itemData = await _vTubeStudioInitialize.GetItems();

        ItemList.Items.Clear();

        foreach (var item in itemData.availableItems)
        {
            ItemList.Items.Add($"{item.fileName}");
        }

        foreach (var item in itemData.itemsInScene)
        {
            ActiveItemList.Items.Add($"{item.fileName}: {item.instanceID}");
        }

        await _vTubeStudioInitialize.Live2DParameter();
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        var t = !PosX.Text.IsNullOrEmpty();

        float x = !PosX.Text.IsNullOrEmpty() ? float.Parse(PosX.Text, CultureInfo.InvariantCulture) : float.NaN;
        float y = !PosY.Text.IsNullOrEmpty() ? float.Parse(PosY.Text, CultureInfo.InvariantCulture) : float.NaN;
        float r = !PosR.Text.IsNullOrEmpty() ? float.Parse(PosR.Text, CultureInfo.InvariantCulture) : float.NaN;
        float s = !PosSize.Text.IsNullOrEmpty() ? float.Parse(PosSize.Text, CultureInfo.InvariantCulture) : float.NaN;

        await _vTubeStudioInitialize.ChangeLocaton(x, y, r, s);
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

        await _vTubeStudioInitialize.SetModel(id);

        var toggles = await _vTubeStudioInitialize.GetToggles();

        ModelToggleList.Items.Clear();

        foreach (var toggle in toggles)
        {
            ModelToggleList.Items.Add($"{toggle.name}: {toggle.hotkeyID}");
        }
    }

    private async void ModelToggleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var id = ModelToggleList.Items[ModelToggleList.SelectedIndex].ToString().Split(':')[1];

        id = id.Replace(" ", "");

        await _vTubeStudioInitialize.SetToggle(id);
    }

    private async void ItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var fileName = ItemList.Items[ItemList.SelectedIndex].ToString();

        Item item = new Item()
        {
            fileName = fileName,
            instanceID = "",
            positionX = 0,
            positionY = 0,
            size = 0.3f,
            rotation = 360,
            flipped = false,
            order = 1,
            censored = false,
        };

        ActiveItemList.Items.Add(fileName);

        await _vTubeStudioInitialize.SetItem(item);
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
            fileName = fileName,
            instanceID = instanceID,
        };
        await _vTubeStudioInitialize.RemoveItems(new List<Item> { item });

        if (ActiveItemList.Items.Count > 1)
        {
            ActiveItemList.Items.RemoveAt(index);
        }
        else
        {
            ActiveItemList.Items.Clear();
        }
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
}
