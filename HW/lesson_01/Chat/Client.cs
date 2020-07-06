using Messaging;
using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Chat
{
    internal class Client
    {
        public string UserName { get; set; }
        public readonly string Host = "127.0.0.1";
        public readonly int Port = 45541;
        public TcpClient TcpClient;
        private NetworkStream _stream;
        private readonly BinaryFormatter _bf = new BinaryFormatter();
        private readonly Control _logs = null;
        private readonly Control _output = null;

        public Client(Control output, Control logs = null)
        {
            _output = output;
            _logs = logs;
        }

        public bool StartClient(string name)
        {
            UserName = name;
            TcpClient = new TcpClient();
            try
            {
                TcpClient.Connect(Host, Port);
                _stream = TcpClient.GetStream();
                SendMessage("logginig...", $"{Host}:{Port}");
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"Client exception on starting :\n{ex.Message}");
                Disconnect();
                return false;
            }
        }

        public void SendMessage(string input, string reciever)
        {
            IMessage msg = new Messaging.Message
            {
                SenderName = UserName,
                DestinationName = reciever,
                DestinationEP = $"{Host}{Port}",
                SourceEP = TcpClient.Client.LocalEndPoint.ToString(),
                Text = input,
                SendTime = DateTime.Now
            };

            _bf.Serialize(_stream, msg);
            LogMessage(msg);
        }


        public void PullMessages()
        {
            SendMessage("PULL", "NONE");
            GetMessages();
        }

        private void GetMessages()
        {
            try
            {
                do
                {
                    IMessage tmpMsg = _bf.Deserialize(_stream) as Messaging.Message;
                    _output.Invoke((MethodInvoker)delegate { _output.Text += $"[{tmpMsg?.SendTime}]{tmpMsg?.SenderName}: {tmpMsg?.Text}\n\n"; });
                }
                while (_stream.DataAvailable);
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
        }

        public void Disconnect()
        {
            if (_stream != null)
                _stream.Close();
            if (TcpClient != null)
                TcpClient.Close();
        }

        private void LogMessage(string str)
        {
            if (_logs != null)
                _logs.Invoke((MethodInvoker)delegate { _logs.Text += str + '\n'; });
        }
        private void LogMessage(IMessage msg)
        {
            if (_logs != null)
                _logs.Invoke((MethodInvoker)delegate { _logs.Text += msg.ToString() + "\n\n"; });
        }

    }
}
