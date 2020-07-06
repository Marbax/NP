using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TestUDP
{
    public partial class UDPMessagingForm : Form
    {
        private delegate void AddTextDelegate(String text);

        private class StateObject
        {
            public Socket workSocket = null;
            public const int BufferSize = 1024;
            public byte[] buffer = new byte[BufferSize];
        }

        private readonly StateObject _state = new StateObject();
        private Socket _socket;
        private IAsyncResult _rcptRes, _sendRes;
        private EndPoint _clientEP = new IPEndPoint(IPAddress.Any, 100);

        public UDPMessagingForm()
        {
            InitializeComponent();
        }

        private void AddText(String text) => tbMessages.Text += text;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_socket != null)
                return;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
            _socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.88.97"), 100));

            _state.workSocket = _socket;
            _rcptRes = _socket.BeginReceiveFrom
                (_state.buffer, 0, StateObject.BufferSize, SocketFlags.None, ref _clientEP, new AsyncCallback(Receive_Completed), _state);
        }

        private void Receive_Completed(IAsyncResult ia)
        {
            try
            {
                StateObject so = (StateObject)ia.AsyncState;
                Socket client = so.workSocket;
                if (_socket == null)
                    return;
                int readed = client.EndReceiveFrom(_rcptRes, ref _clientEP);

                String strClientIP = ((IPEndPoint)_clientEP).Address.ToString();
                String str = String.Format("\nПолучено от {0}\r\n{1}\r\n",
                    strClientIP, System.Text.Encoding.Unicode.GetString(so.buffer, 0, readed));

                tbMessages.BeginInvoke(new AddTextDelegate(AddText), str);

                _rcptRes = _socket.BeginReceiveFrom
                    (_state.buffer, 0, StateObject.BufferSize, SocketFlags.None, ref _clientEP, new AsyncCallback(Receive_Completed), _state);
            }
            catch (SocketException ex)
            {
                tbMessages.BeginInvoke(new AddTextDelegate(AddText), ex.Message);
            }

        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            _socket.Shutdown(SocketShutdown.Receive);
            _socket.Close();
            _socket = null;
            tbMessages.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e) => tbMessages.Clear();

        private void btnSend_Click(object sender, EventArgs e)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
            byte[] buffer = System.Text.Encoding.Unicode.GetBytes(tbMessageToSend.Text);
            _sendRes = socket.BeginSendTo
                (buffer, 0, buffer.Count(), SocketFlags.None, (EndPoint)new IPEndPoint(IPAddress.Parse("192.168.88.97"), 100), new AsyncCallback(Send_Completed), socket);
        }

        private void Send_Completed(IAsyncResult ia)
        {
            Socket socket = (Socket)ia.AsyncState;
            socket.EndSend(_sendRes);
            socket.Shutdown(SocketShutdown.Send);
            socket.Close();
        }
    }
}
