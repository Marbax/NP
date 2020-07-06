using Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 22222;
            TcpListener server = new TcpListener(IPAddress.Parse(ip), port);
            server.Start();
            Console.WriteLine("Server started...");
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                Task.Factory.StartNew(() => ProcessClient(client));

            }

        }

        private static void ProcessClient(TcpClient client)
        {
            Car car = new Car
            {
                Title = "Honda",
                Year = 2012,
                Color = "Black"
            };

            NetworkStream stream = client.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, car);

            while (true)
            {
                try
                {
                  
                    StreamReader sr = new StreamReader(stream);
                    string message = sr.ReadLine();
                    Console.WriteLine($"{client.Client.RemoteEndPoint.ToString()} - {message}");
                }
                catch (Exception ex)
                {

                }

            }
        }
    }
}
