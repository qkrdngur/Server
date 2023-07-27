using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace IPAddress01
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 13);
            tcpListener.Start();
            Console.WriteLine("대기 상태 시작");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();
            byte[] ReceiveMessage = new byte[100];
            ns.Read(ReceiveMessage, 0, 100);
            string strMessage = Encoding.ASCII.GetString(ReceiveMessage);
            Console.WriteLine(strMessage);
            string EchoMessage = "Hi~~";
            byte[] SendMessage = Encoding.ASCII.GetBytes(EchoMessage);
            ns.Write(SendMessage, 0, SendMessage.Length);
            ns.Close();
            tcpListener.Stop();
            Console.ReadKey();
        }
    }
}