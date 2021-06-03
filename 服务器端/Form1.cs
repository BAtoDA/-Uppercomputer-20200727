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
using static PLC通讯规范接口.Request;
using System.Net.Sockets;
using System.Net;
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
            int hWnd = FindWindow(null, this.textBox1.Text??"null");

            if (hWnd == 0)

            {

                MessageBox.Show("555，未找到消息接受者！");

            }

            else

            {
                //获取所有的字节长度
                byte[] sarr = System.Text.Encoding.Default.GetBytes(this.textBox6.Text+ this.textBox2.Text+ this.textBox3.Text+ this.textBox4.Text+ this.textBox5.Text+ this.textBox6.Text+ this.Name+ this.textBox7.Text);
                //获取长度
                int len = sarr.Length;
                //实例化消息封装器
                COPYDATASTRUCT cds =new COPYDATASTRUCT();
                //发送者名称
                 cds.characteristic =this.Name;
                //功能码
                cds.function = Convert.ToInt16(this.textBox2.Text);//可以是任意值
                //设备功能码
                cds.Equipmenttype = this.textBox3.Text;
                //访问设备的具体地址
                 cds.Address = this.textBox4.Text;
                //访问设备的类型
                 cds.Type = this.textBox5.Text;
                //访问设备的长度
                cds.length = this.textBox6.Text;
                //字节数
                cds.cbData = len+2 ;//指定lpData内存区域的字节数

                cds.lpData =this.textBox7.Text;//发送给目标窗口所在进程的数据
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string jsonStr = jss.Serialize(cds);
                socket.Send(Encoding.UTF8.GetBytes(jsonStr));


                //SendMessage(hWnd, WM_COPYDATA, 0, ref cds);

            }


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
        private void button2_Click(object sender, EventArgs e)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse("192.168.250.90"), 9500));
            socketread();
        }
    }
}
