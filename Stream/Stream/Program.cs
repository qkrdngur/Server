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
            byte[] Buffer = new byte[1024];
            string str;
            TcpClient tcpClient = new TcpClient("localhost", 3000);
            NetworkStream ns = tcpClient.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);

            while(true)
            {
                sw.AutoFlush = true;
                str = Console.ReadLine(); //string형으로 수신
                sw.WriteLine(str);

                Console.WriteLine("받음 : {0}", sr.ReadLine());
            }
            

            ns.Close();
            tcpClient.Close();
        }
    }
}