using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MulticastServer
{
    public partial class MulticastServerForm : Form
    {
        private static string message = "Hello network!!!";
        private static readonly int Interval = 1000;

        private static void multicastSend()
        {
            while (true)
            {
                Thread.Sleep(Interval);
                Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                soc.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
                IPAddress dest = IPAddress.Parse("224.5.5.5");
                soc.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(dest));
                IPEndPoint ipep = new IPEndPoint(dest, 4567);
                soc.Connect(ipep);
                soc.Send(Encoding.Default.GetBytes($"{DateTime.Now.ToString()} \n {message}"));
                soc.Close();
            }
        }

        private readonly Thread Sender = new Thread(new ThreadStart(multicastSend));
        public MulticastServerForm()
        {
            InitializeComponent();
            Sender.IsBackground = true;
            Sender.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            message = textBox1.Text;
        }
    }
}
