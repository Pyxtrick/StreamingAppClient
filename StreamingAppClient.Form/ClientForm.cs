using StreamingApp.API.VTubeStudio;
using StreamingAppClient.SignalR;
using System.Globalization;
using WebSocketSharp;

namespace StreamingAppClient.View
{
    public partial class ClientForm : Form
    {
        private readonly ISignalRClient _signalRClient;

        private readonly IVTubeStudioApiRequest _vTubeStudioInitialize;

        private System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[.][0-9]+$|^-?[0-9]*[.]{0,1}[0-9]*$");

        public ClientForm(ISignalRClient signalRClient, IVTubeStudioApiRequest vTubeStudioInitialize)
        {
            _signalRClient = signalRClient;
            _vTubeStudioInitialize = vTubeStudioInitialize;
            InitializeComponent();
        }

        private void hubconnect_Click(object sender, EventArgs e)
        {
            _signalRClient.OnInitializedAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await _vTubeStudioInitialize.Initalize();

            var t = await _vTubeStudioInitialize.GetPosData();

            PosX.Text = t.positionX.ToString();
            PosY.Text = t.positionY.ToString();
            PosR.Text = t.rotation.ToString();
            PosSize.Text = t.size.ToString();
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
    }
}
