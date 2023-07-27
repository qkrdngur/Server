using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace IPAddress01
{
    class Program
    {
        static void Main(string[] args)
        {
            //string Address = Console.ReadLine();
            //IPAddress[] IP = Dns.GetHostAddresses("www.naver.com");
            //foreach (IPAddress HostIp in IP)
            //{ 
            //    Console.WriteLine("{0} ", HostIp);
            //}
            //Console.WriteLine("ip : {0}", IP.ToString());

            IPHostEntry hostInfo = Dns.GetHostEntry("www.naver.com");

            foreach (IPAddress ip in hostInfo.AddressList)
            {
                Console.WriteLine("{0} ", ip);
            }

            Console.WriteLine("{0} ", hostInfo.HostName);
        }
    }
}