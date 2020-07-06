using System;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary>
/// 2. Напишите систему обмена сообщениями между клиентами.
/// Система должна использовать центральный сервер, к которому подключаются клиенты и оставляют на нём сообщения. 
/// Клиент, которому адресованы сообщения, получает их с сервера по запросу. 
/// Система должна использовать протокол, ориентированный на соединение (TCP).
/// </summary>
namespace Chat
{
    public partial class ClientForm : Form
    {
        private readonly Client _client;

        public ClientForm()
        {
            InitializeComponent();
            btnDisconnect.Enabled = btnSend.Enabled = btnPull.Enabled = false;
            _client = new Client(rtbLogs);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _client.SendMessage(rtbMessage.Text, tbReciever.Text);
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => _client.PullMessages());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_client.StartClient(tbUser.Text) == false)
                    throw new ApplicationException("Cannot connect to server.\n");
                btnDisconnect.Enabled = btnPull.Enabled = btnSend.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                _client.Disconnect();
                rtbLogs.Text += ex.Message;
                btnConnect.Enabled = true;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            rtbLogs.Clear();
            _client.Disconnect();
            btnSend.Enabled = btnPull.Enabled = btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
        }
    }
}
