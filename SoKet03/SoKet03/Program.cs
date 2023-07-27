using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        TcpListener tcpListener = new TcpListener(IPAddress.Any, 7);
        tcpListener.Start();
        byte[] buffer = new byte[1024];

        int ReadByteCount = 0;

        Console.WriteLine("서버");

        TcpClient tcpClient = tcpListener.AcceptTcpClient();//클라 대기
        NetworkStream ns = tcpClient.GetStream();//연결요청 오면 수락과 동시에 스트림 생성

        while(true)//에코 기능을 위한 반복
        {
            ReadByteCount = ns.Read(buffer, 0, buffer.Length);//데이터 넘어올때까지 대기하다, 수신 발생시 Read
            Console.WriteLine(ReadByteCount);
            if (ReadByteCount == 0)
                break;

            Console.WriteLine(Encoding.ASCII.GetString(buffer));
            ns.Write(buffer, 0, buffer.Length);
        }

        ns.Close();
        tcpClient.Close();
        tcpListener.Stop();
    }
}