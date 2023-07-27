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
            TcpListener tcpListener = new TcpListener(3000);
            tcpListener.Start();
            TcpClient tcpClient = tcpListener.AcceptTcpClient();

            byte[] buffer = new byte[1024];
            bool YesNo = false;
            int Vall = 12;
            float Pi = 3.14f;
            string Message = "Hello World";
            string ch;

            NetworkStream ns = tcpClient.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);

            while (true)
            {
                sw.AutoFlush = true;
                ch = sr.ReadLine();
                Console.WriteLine(ch);
                sw.WriteLine(ch);

                //sw.WriteLine(YesNo);
                //sw.WriteLine(Vall);
                //sw.WriteLine(Pi);
                //sw.WriteLine(Message);
               
            }
            
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}