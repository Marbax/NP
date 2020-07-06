using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestAsyncServer
{
    public class TestAsyncServer
    {
        IPEndPoint endP;
        Socket socket;

        public TestAsyncServer(string strAddr, int port)
        {
            endP = new IPEndPoint(IPAddress.Parse(strAddr), port);
        }

        void MyAcceptCallbakFunction(IAsyncResult ia)
        {
            //получаем ссылку на слушающий сокет
            Socket socket = (Socket)ia.AsyncState;

            //получаем сокет для обмена данными с клиентом
            Socket ns = socket.EndAccept(ia);

            //выводим в консоль информацию о подключении
            Console.WriteLine(ns.RemoteEndPoint.ToString());

            //отправляем клиенту текущщее время асинхронно,
            //по завершении операции отправки будет вызван метод
            //MySendCallbackFunction
            byte[] sendBufer = System.Text.Encoding.ASCII.GetBytes(DateTime.Now.ToString());
            ns.BeginSend(sendBufer, 0, sendBufer.Length, SocketFlags.None, new AsyncCallback(MySendCallbackFunction), ns);

            //возобновляем асинхронный Accept
            socket.BeginAccept(new AsyncCallback(MyAcceptCallbakFunction), socket);
        }

        void MySendCallbackFunction(IAsyncResult ia)
        {
            //по завершению отправки данных на клиента
            //закрываем сокет (если бы нам понадобился дальнейший
            //обмен данными, мы могли бы его здесь организовать)
            Socket ns = (Socket)ia.AsyncState;
            int n = ((Socket)ia.AsyncState).EndSend(ia);
            ns.Shutdown(SocketShutdown.Send);
            ns.Close();
        }

        public void StartServer()
        {
            if (socket != null)
                return;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            socket.Bind(endP);
            socket.Listen(10);
            //начинаем асинхронный Accept, при подключении
            //клиента вызовется обработчик MyAcceptCallbakFunction
            socket.BeginAccept(new AsyncCallback(MyAcceptCallbakFunction), socket);
        }
    }
}
