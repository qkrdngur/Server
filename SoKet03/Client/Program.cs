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
            TcpClient tcpClient = new TcpClient("localhost", 7);
            NetworkStream ns = tcpClient.GetStream();
            Console.WriteLine("클라이언트");
            byte[] Buffer = new byte[1024];
            byte[] SendMessage = Encoding.ASCII.GetBytes("Hello World");
            ns.Write(SendMessage, 0, SendMessage.Length);
            int TotalByteCount = 0;
            int ReadByteCount = 0;

            while (true)
            {
                ReadByteCount = ns.Read(Buffer, 0, Buffer.Length);
                Console.WriteLine("RBC : {0}", ReadByteCount);
                TotalByteCount += ReadByteCount;
                Console.WriteLine("TBC : {0}", TotalByteCount);
                string RecvMessage = Encoding.ASCII.GetString(Buffer);
                if (TotalByteCount > 900)
                {
                    break;
                }
                ns.Write(Buffer, 0, ReadByteCount);
            }

            Console.WriteLine("받은 문자열 바이트 수 : {0}", TotalByteCount);
            ns.Close();
            tcpClient.Close();
        }
    }
}