
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        TcpClient client;
        public ClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //создание экземпляра класса IPEndPoint
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(tbIp.Text), Convert.ToInt32(tbIp.Text));
                client = new TcpClient();

                //установка соединения с использованием данных IP и номера порта
                client.Connect(endPoint);

                //получение сетевого потока
                NetworkStream nstream = client.GetStream();

                //преобразование строки сообщения в массив байт
                byte[] barray = Encoding.Unicode.GetBytes(tbMessage.Text);

                //запись в сетевой поток всего массива 
                nstream.Write(barray, 0, barray.Length);

                //закрытие клиента
                client.Close();
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show("Ошибка сокета:" + sockEx.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка :" + Ex.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null)
                client.Close();
        }
    }
}
