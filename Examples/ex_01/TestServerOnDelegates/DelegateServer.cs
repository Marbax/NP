using System;
using System.Net;
using System.Net.Sockets;

namespace TestServerOnDelegates
{
    public class DelegateServer
    {
        private delegate void ConnectDelegate(Socket s);

        private delegate void StartNetwork(Socket s);

        private Socket socket;
        private readonly IPEndPoint endP;

        public DelegateServer(string strAddr, int port)
        {
            endP = new IPEndPoint(IPAddress.Parse(strAddr), port);
        }

        private void Server_Connect(Socket s)
        {
            s.Send(System.Text.Encoding.ASCII.GetBytes(DateTime.Now.ToString()));
            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }

        private void Server_Begin(Socket s)
        {
            while (true)
            {
                try
                {
                    while (s != null)
                    {
                        Socket ns = s.Accept();
                        Console.WriteLine(ns.RemoteEndPoint.ToString());
                        ConnectDelegate cd = new ConnectDelegate(Server_Connect);
                        cd.BeginInvoke(ns, null, null);
                    }
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Start()
        {
            if (socket != null)
                return;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            socket.Bind(endP);
            socket.Listen(10);
            StartNetwork start = new StartNetwork(Server_Begin);
            start.BeginInvoke(socket, null, null);
        }

        public void Stop()
        {
            if (socket != null)
            {
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    socket = null;
                }
                catch (SocketException)
                {
                }
            }
        }

    }
}
