using Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string destIP = "127.0.0.1";
            int destPort = 22222;

            TcpClient client = new TcpClient();
            client.Connect(destIP, destPort);
            NetworkStream ns = client.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            Car car = bf.Deserialize(ns) as Car;
            Console.WriteLine($"{car.Title}\t{car.Color}\t{car.Year}");
            StreamWriter sw = new StreamWriter(ns);
            while (true)
            {
                string s = Console.ReadLine();
                sw.WriteLine(s);
                sw.Flush();
            }
            client.Dispose();

        }
    }
}
