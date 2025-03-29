using StreamingAppClient.SignalR;

namespace StreamingAppClient.View
{
    public partial class ClientForm : Form
    {
        private readonly ISignalRClient _signalRClient;

        public ClientForm(ISignalRClient signalRClient)
        {
            _signalRClient = signalRClient;
            InitializeComponent();
        }

        private void hubconnect_Click(object sender, EventArgs e)
        {
            _signalRClient.OnInitializedAsync();
        }
    }
}
