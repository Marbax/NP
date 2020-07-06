using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Events
        private void btnParse_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => GetHostInfo(tbAdress.Text));
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _ = WgetAsync(tbAdress.Text);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanPorts(tbAdress.Text);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            GetRequest(tbAdress.Text);
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            rtbOutput.Text = rtbOutput.Text.Replace("\n\n", "\n");

            rtbOutput.Text = rtbOutput.Text.Replace("  ", " ");
        }

        private void BtnEstSyncTcpConn_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            EstabilishSyncTcpConnWithHost(tbAdress.Text);
        }

        #endregion

        #region Some Methods
        private void GetHostInfo(string str)
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry(str);

                StringBuilder outp = new StringBuilder($"Hostname : {host.HostName}");

                outp.Append("\nAliases: \n");
                foreach (string s in host.Aliases)
                    outp.Append($"{s}\n");

                outp.Append("\n\nIps:\n");
                foreach (IPAddress ip in host.AddressList)
                    outp.Append($"{ip.ToString()}\n");

                outp.Append($"========================================================");

                this.Invoke((MethodInvoker)delegate ()
                {
                    rtbOutput.Text = outp.ToString();
                });
            }
            catch (Exception ex)
            {
                PrintSomeLogInfo(ex.Message);
            }
        }

        private List<IPAddress> GetIps(string url)
        {
            List<IPAddress> ips = new List<IPAddress>();
            IPHostEntry host = Dns.GetHostEntry(url);
            foreach (IPAddress ip in host.AddressList)
                ips.Add(ip);

            return ips;
        }

        private async Task WgetAsync(string url)
        {
            WebClient client = new WebClient();
            try
            {
                rtbOutput.Clear();
                Uri uri = new Uri(url);
                string filename = "";
                if (uri.IsFile)
                    throw new ApplicationException($" {url} isn't file");
                filename = System.IO.Path.GetFileName(uri.LocalPath);

                string toDesk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\{filename}";
                await client.DownloadFileTaskAsync(new Uri(url), toDesk);
                PrintSomeLogInfo($"{url} successfully downloaded to {toDesk}");
                rtbOutput.Text += $"========================================================";
            }
            catch (Exception ex)
            {
                PrintSomeLogInfo(ex.Message);
            }
        }

        private void PrintSomeLogInfo(string str)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                rtbOutput.Text += $"\n{DateTime.Now} => {str}\n";
            });
        }

        private void ScanPorts(string host)
        {
            rtbOutput.Clear();
            try
            {
                System.Net.NetworkInformation.IPGlobalProperties properties = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] tcpEndPoints = properties.GetActiveTcpListeners();
                System.Net.NetworkInformation.TcpConnectionInformation[] tcpConnections = properties.GetActiveTcpConnections();

                tcpConnections.ToList().ForEach(p =>
                {
                    rtbOutput.Text += $"Local = [{p.LocalEndPoint.Address}:{p.LocalEndPoint.Port}]  Remote = [{p.RemoteEndPoint.Address}:{p.RemoteEndPoint.Port}] State = [{p.State}]\n";
                });

            }
            catch (Exception ex)
            {
                PrintSomeLogInfo(ex.Message);
            }
        }

        private void GetRequest(string url = "https://docs.microsoft.com")
        {
            WebResponse response = null;
            rtbOutput.Clear();
            try
            {
                WebRequest request = WebRequest.Create(url);
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.
                response = request.GetResponse();
                // Display the status.
                rtbOutput.Text += ((HttpWebResponse)response).StatusDescription;

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (System.IO.Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    rtbOutput.Text += responseFromServer;
                }
            }
            catch (Exception ex)
            {
                PrintSomeLogInfo(ex.Message);
            }
            finally
            {
                // Close the response.
                if (response != null)
                    response.Close();
            }
        }


        #endregion


        #region Establish connection methods
        private void EstabilishSyncTcpConnWithHost(string host)
        {
            List<IPAddress> ips = new List<IPAddress>();
            try
            {
                ips.Add(IPAddress.Parse(host));
            }
            catch (Exception)
            {
                ips = GetIps(host);
            }

            foreach (var ip in ips)
            {
                for (int i = 0; i < 8000; i++)
                    EstablishSycnTcpConn(ip, i);
            }
        }

        private void EstablishSycnTcpConn(IPAddress ip, int p)
        {
            IPEndPoint ep = new IPEndPoint(ip, p);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                s.Connect(ep);
                if (s.Connected)
                {
                    String strSend = "GET\r\n\r\n";
                    s.Send(System.Text.Encoding.ASCII.
                    GetBytes(strSend));
                    byte[] buffer = new byte[1024];
                    int l;
                    do
                    {
                        l = s.Receive(buffer);
                        rtbOutput.Text += System.Text.Encoding.ASCII.GetString(buffer, 0, l);
                    } while (l > 0);
                }
                else
                    rtbOutput.Text += "Error";
            }
            catch (SocketException ex)
            {
                PrintSomeLogInfo(ex.Message);
            }
            finally
            {
                s.Shutdown(SocketShutdown.Both);
                s.Close();
            }
        }

        #endregion


        #region Listen methods
        private void ListenSync(string ipIn = "127.0.0.1", int port = 1024)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPAddress ip = IPAddress.Parse(ipIn);
            IPEndPoint ep = new IPEndPoint(ip, port);
            s.Bind(ep);
            s.Listen(10);
            try
            {
                while (true)
                {
                    Socket ns = s.Accept();
                    rtbOutput.Text += ns.RemoteEndPoint.ToString();
                    ns.Send(System.Text.Encoding.ASCII.GetBytes(DateTime.Now.ToString()));
                    ns.Shutdown(SocketShutdown.Both);
                    ns.Close();
                }
            }
            catch (SocketException ex)
            {
                PrintSomeLogInfo(ex.Message);
            }
        }

        #endregion
    }
}
