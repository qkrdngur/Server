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
            for (int i = 0; i < host.AddressList.Length; i++)   // IP����� �迭 ������
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {           // IP�迭(Family)���� ����IPv4 �ּҸ� ����
                    textBox1.Text = host.AddressList[i].ToString(); // �ع�1�� ���� ip�ּ� �Է�
                    break;  // for�� ���
                }
            }
        }

        private void AcceptClient() // Ŭ�� ���� ��û ��� ���
        {
            // ��� ������
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                if (tcpClient.Connected)
                {
                    string str = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    listBox1.Items.Add(str);    // ����Ʈ�ڽ��� ���� Ŭ�� IP ǥ��
                }

                EchoServer echoServer = new EchoServer(tcpClient);
                Thread th = new Thread(new ThreadStart(echoServer.Process));    // ������ �ȿ� ������ ����
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
            Thread th = new Thread(new ThreadStart(AcceptClient));  // ��⽺���� ����
            th.IsBackground = true;
            th.Start(); // ��⽺���� ����
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

            public EchoServer(TcpClient Client) // �����ڿ� Ŭ���̾�Ʈ ��ü
            {
                RefClient = Client;
            }
            public void Process()   // �����͸� �޴� �����忡 ���
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
                catch (SocketException se)   // ���ͷ�Ʈ ����ó��
                {
                    br.Close();
                    bw.Close();
                    ns.Close();
                    ns = null;
                    RefClient.Close();
                    MessageBox.Show(se.Message);
                    Thread.CurrentThread.Interrupt();
                }
                catch (IOException ex)  // ���� ������ ���� ó��
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