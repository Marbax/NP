using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class ServerForm : Form
    {
        private Server _server;

        public ServerForm()
        {
            InitializeComponent();
            btnStopServer.Enabled = false;
        }


        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                _server = new Server(rtbLogs);
                Task.Factory.StartNew(() => _server.Listen());
                btnStartServer.Enabled = false;
                btnStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
                rtbLogs.Text += $"[{DateTime.Now}] - {ex.Message}\n";
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            _server.Disconnect();
            btnStopServer.Enabled = false;
            btnStartServer.Enabled = true;
        }
    }
}
