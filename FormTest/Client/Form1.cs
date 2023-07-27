using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.Http;


namespace Client
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;
        private TcpClient tcpClient = null;
        private BinaryWriter bw = null;
        private BinaryReader br = null;
        private NetworkStream ns;
        private int intvalue;
        private int floatvalue;
        private string strvalue;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient(textBox1.Text, 3000);
            if (tcpClient.Connected)
            {
                ns = tcpClient.GetStream();
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);
                MessageBox.Show("서버 접속 성공");
            }
            else
            {
                MessageBox.Show("서버 접속 실패");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bw.Write(int.Parse(textBox2.Text));
            bw.Write(float.Parse(textBox2.Text));
            bw.Write(textBox4.Text);

            intvalue = br.ReadInt32();
            floatvalue = br.ReadInt32();
            strvalue = br.ReadString();

            String str = intvalue + "/" + floatvalue + "/" + strvalue;
            MessageBox.Show(str);
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            bw.Write(-1);
            bw.Close();
            br.Close();
            ns.Close();
            tcpClient.Close();
        }
    }
}