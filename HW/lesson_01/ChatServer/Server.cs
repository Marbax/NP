using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messaging;

namespace ChatServer
{
    public class Server
    {
        public TcpListener Listener;
        public List<Client> Clients { get; set; } = new List<Client>();
        private readonly int _port = 45541;
        private Control _logs = null;
        private readonly BinaryFormatter _bf = new BinaryFormatter();
        public List<IMessage> Msgs = new List<IMessage>();

        public Server(Control logs = null)
        {
            _logs = logs;
        }

        public void AddConnection(Client clientObject) => Clients.Add(clientObject);

        public void RemoveConnection(string id)
        {
            Client client = Clients.FirstOrDefault(c => c.CId == id);
            if (client != null)
                Clients.Remove(client);
        }

        public void Listen()
        {
            try
            {
                Listener = new TcpListener(IPAddress.Any, _port);
                Listener.Start();
                LogMessage($"Starting listening on [{Listener.LocalEndpoint.ToString()}]");
                while (true)
                {
                    TcpClient tcpClient = Listener.AcceptTcpClient();
                    Client clientObject = new Client(tcpClient, this, _logs);
                    Task.Factory.StartNew(() => clientObject.StartProcessingClient());
                }
            }
            catch (Exception ex)
            {
                LogMessage($"{ex.Message}");
                Disconnect();
            }
        }

        public void PushMessages(string reciever)
        {
            List<Client> cl = Clients.Where(c => c.UserName == reciever).ToList();
            List<IMessage> msgs = Msgs.Where(m => m.DestinationName == reciever).ToList();
            cl.ForEach(c =>
            {
                msgs.ForEach(m => _bf.Serialize(c.Stream, m));
            });
            msgs.ForEach(m => Msgs.Remove(m));
        }

        public void Disconnect()
        {
            Listener.Stop();

            for (int i = 0; i < Clients.Count; i++)
                Clients[i].Close();
        }

        private void LogMessage(string str)
        {
            if (_logs != null)
                _logs.Invoke((MethodInvoker)delegate { _logs.Text += DateTime.Now.ToString() + str + "\n\n"; });
        }


    }
}
