using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Nancy.Json;
using System.Net.Sockets;
using System.Net;
using 服务器端.上位机通讯报文处理;
namespace 服务器端
{
    public partial class Form1 : Form
    {
        //Win32 API函数

        [DllImport("User32.dll", EntryPoint = "SendMessage")]

        private static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);



        [DllImport("User32.dll", EntryPoint = "FindWindow")]

        private static extern int FindWindow(string lpClassName, string lpWindowName);



        const int WM_COPYDATA = 0x004A;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var HMIM= socket_Client.ReadHmi_Bool(Name, 1, 1);

        }
        protected override void DefWndProc(ref Message m)

        {

            switch (m.Msg)

            {

                case WM_COPYDATA:

                    COPYDATASTRUCTresult cds = new COPYDATASTRUCTresult();

                    Type t = cds.GetType();

                    cds = (COPYDATASTRUCTresult)m.GetLParam(t);

                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string jsonStr = jss.Serialize(cds);
                    richTextBox1.AppendText( jsonStr + "\r\n");

                    //处理完成后返回 数据
                    int hWnd = FindWindow(null, @cds.characteristic);

                    break;

                default:

                    base.DefWndProc(ref m);

                    break;

            }

        }
        public void socketread()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    byte[] data = new byte[1024];
                    socket.Receive(data);
                    string Data = Encoding.UTF8.GetString(data, 0, data.Length);
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    var da = jss.Deserialize<COPYDATASTRUCTresult>(Data);
                    richTextBox1.AppendText($"\r\n来自：{da .characteristic}回复的消息：" +Data+"\r\n");
                    if (da.result)
                    {
                        var d33 = jss.Deserialize<bool[]>(da.Data);
                    }
                }
            });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        Socket socket;
        Socket_Client socket_Client;
        private void button2_Click(object sender, EventArgs e)
        {
            socket_Client = new Socket_Client(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9500));
            var DW= socket_Client.Open();
            socket_Client.Readmessage += ((es, q) =>
              {
                  richTextBox1.AppendText(es.ToString());
              });
            socket_Client.Writemessage += ((es, q) =>
            {
                richTextBox1.AppendText(es.ToString());
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            socket_Client.ReadHmiD<string>(Name, 1, 1, HmiType.Hex);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            socket_Client.WriteHmi_Bool(Name, 1, true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            socket_Client.WriteHmi_Bool(Name, 1, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            socket_Client.WriteHmi_D(Name, 1, HmiType.Hex, "FFFFF");
        }
    }
}
