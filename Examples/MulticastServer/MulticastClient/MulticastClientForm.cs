using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MulticastClient
{
    public partial class MulticastClientForm : Form
    {
        private delegate void AppendText(string text);

        private void Listner()
        {
            while (true)
            {
                Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 4567);
                soc.Bind(ipep);
                IPAddress ip = IPAddress.Parse("224.5.5.5");
                soc.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip, IPAddress.Any));
                byte[] buff = new byte[1024];
                soc.Receive(buff);
                Invoke(new AppendText(AppendTextProc), Encoding.Default.GetString(buff));
                soc.Close();
            }
        }

        private readonly Thread listen;
        public MulticastClientForm()
        {
            InitializeComponent();
            listen = new Thread(new ThreadStart(Listner));
            listen.IsBackground = true;
            listen.Start();
        }

        private void AppendTextProc(string text)
        {
            dataOutput.Text = text;
        }
    }
}
