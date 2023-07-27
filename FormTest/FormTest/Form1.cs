using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Drawing.Design;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace FormTest
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(IPAddress.Any, 3000);
            tcpListener.Start();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0; i < host.AddressList.Length; i++)   // IP저장된 배열 가져옴
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {           // IP배열(Family)에서 내부IPv4 주소만 구분
                    textBox1.Text = host.AddressList[i].ToString(); // 텍박1에 서버 ip주소 입력
                    break;  // for문 벗어남
                }
            }
        }

        private void AcceptClient() // 클라 연결 요청 계속 대기
        {
            // 대기 스레드
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                if (tcpClient.Connected)
                {
                    string str = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    listBox1.Items.Add(str);    // 리스트박스에 연결 클라 IP 표시
                }

                EchoServer echoServer = new EchoServer(tcpClient);
                Thread th = new Thread(new ThreadStart(echoServer.Process));    // 스레드 안에 스레드 생성
                th.IsBackground = true;
                th.Start();

                //EchoServer echoServer = new EchoServer();
                //Thread th = new Thread(new ThreadStart(echoServer.Process));
                //th.IsBackground = true;
                //th.Start();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(AcceptClient));  // 대기스레드 생성
            th.IsBackground = true;
            th.Start(); // 대기스레드 시작
        }


        private void Form1_FormClosing(object sender, EventArgs s)
        {
            if (tcpListener != null)
            {
                tcpListener.Stop();
                tcpListener = null;
            }
        }

        class EchoServer
        {
            TcpClient RefClient;
            private BinaryWriter bw = null;
            private BinaryReader br = null;
            int intValue;
            float floatValue;
            string strValue;

            public EchoServer(TcpClient Client) // 생성자에 클라이언트 객체
            {
                RefClient = Client;
            }
            public void Process()   // 데이터를 받는 스레드에 사용
            {
                NetworkStream ns = RefClient.GetStream();
                try
                {
                    br = new BinaryReader(ns);
                    bw = new BinaryWriter(ns);

                    while (true)
                    {
                        intValue = br.ReadInt32();
                        floatValue = br.ReadSingle();
                        strValue = br.ReadString();

                        bw.Write(intValue);
                        bw.Write(floatValue);
                        bw.Write(strValue);
                    }
                }
                catch (SocketException se)   // 인터럽트 예외처리
                {
                    br.Close();
                    bw.Close();
                    ns.Close();
                    ns = null;
                    RefClient.Close();
                    MessageBox.Show(se.Message);
                    Thread.CurrentThread.Interrupt();
                }
                catch (IOException ex)  // 연결 끊어짐 예외 처리
                {
                    br.Close();
                    bw.Close();
                    ns.Close();
                    ns = null;
                    RefClient.Close();
                    Thread.CurrentThread.Interrupt();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}