using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Messaging;

namespace ChatServer
{
    public class Client
    {
        public NetworkStream Stream { get; set; }
        public string UserName { get; set; }
        public string CId { get; set; }

        private readonly TcpClient _client;
        private readonly Server _server;
        private readonly BinaryFormatter _bf = new BinaryFormatter();
        private readonly Control _logs = null;

        public Client(TcpClient tcpClient, Server serverObject, Control logs = null)
        {
            CId = Guid.NewGuid().ToString();
            _client = tcpClient;
            _server = serverObject;
            serverObject.AddConnection(this);
            if (logs != null)
                _logs = logs;
        }

        public void StartProcessingClient()
        {
            try
            {
                Stream = _client.GetStream();
                List<IMessage> msgs = GetMessages();
                UserName = msgs[0].SenderName;
                LogMessage($"{UserName} logged in.");

                while (true)
                {
                    try
                    {
                        msgs = GetMessages();
                        msgs.ForEach(m => m.WhiteSourceEP = _client.Client.RemoteEndPoint.ToString());
                        _server.Msgs.AddRange(msgs);

                        msgs.ForEach(m =>
                        {
                            if (m.Text.ToUpper() == "PULL")
                                _server.PushMessages(this.UserName);
                        });
                    }
                    catch (Exception)
                    {
                        LogMessage($"{UserName} logged out.");
                        break;
                    }
                    msgs.ForEach(m => LogMessage(m));
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Client failed:\n{ex.Message}");
            }
            finally
            {
                _server.RemoveConnection(CId);
                Close();
            }
        }

        private List<IMessage> GetMessages()
        {
            List<IMessage> msg = new List<IMessage>();

            do
                msg.Add(_bf.Deserialize(Stream) as Messaging.Message);
            while (Stream.DataAvailable);

            return msg;
        }

        public void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (_client != null)
                _client.Close();
        }

        private void LogMessage(string str)
        {
            if (_logs != null)
                _logs.Invoke((MethodInvoker)delegate { _logs.Text += DateTime.Now.ToString() + str + "\n\n"; });
        }
        private void LogMessage(IMessage msg)
        {
            if (_logs != null)
                _logs.Invoke((MethodInvoker)delegate { _logs.Text += msg.ToString() + "\n\n"; });
        }

    }
}
