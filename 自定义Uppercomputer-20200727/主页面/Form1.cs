using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.主页面;
using System.Threading;
using 自定义Uppercomputer_20200727.手动控制页面;
using 自定义Uppercomputer_20200727.控制主页面;
using HslCommunicationDemo;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using System.Diagnostics;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.EF实体模型.XML;
using CCWin.SkinControl;
using HZH_Controls.Forms;

namespace 自定义Uppercomputer_20200727
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        ///三菱仿真COM组件对象传递
        public static AxActUtlTypeLib.AxActUtlType ActUtlType { get; set; }
        /// <summary>
        /// 数据库实例化
        /// </summary>
        public static string SQLname { get; set; } = @"DESKTOP-E3JO5HA\WINCC";
        /// <summary>
        /// 数据库名
        /// </summary>
        public static string SQLdatabase { get; set; } = "Uppercomputer";
        /// <summary>
        /// 数据库用户名
        /// </summary>
        public static string SQLuser { get; set; } = "sa";
        /// <summary>
        /// 数据库密码
        /// </summary>
        public static string SQLpassword { get; set; } = "3131458";
        private void Home_Shown(object sender, EventArgs e)
        {
            ActUtlType = this.axActUtlType1;
        }
        public void BindingProcessMsg(string strText, int intValue)
        {

            label1.Text = strText;
            this.ucProcessLineExt1.Value = intValue;
            Thread.Sleep(500);
        }
        private bool Home_examine()//主页面加载程序进程检查
        {
            Process process = Process.GetCurrentProcess();//获取系统进程
            Process[] processes = Process.GetProcessesByName("自定义Uppercomputer-20200727");//获取本地应用程序进程
            foreach(var i in processes)//遍历进程
            {
                if(i.ProcessName== "自定义Uppercomputer-20200727"&processes.Length>1)//判断是否已经打开
                {
                    i.Kill();
                    return true;//返回标志位--程序已打开
                }
            }
            return false;//返回标志位
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            //读取数据库文件
            BindingProcessMsg("正在读取XML文件", 10);
            XML xML = new XML(@Application.ExecutablePath);
            var Valiu = xML.Read_XML();//读取配置文件
            BindingProcessMsg("正在读取数据库配置文件", 15);
            if (!Valiu.IsNull() && Valiu.Count > 0 && Valiu[0].IsNull() != true)
            {
                SQLname = Valiu[0].Item1;
                SQLdatabase = Valiu[0].Item2;
                SQLuser = Valiu[0].Item3;
                SQLpassword = Valiu[0].Item4;
            }
            BindingProcessMsg("正在读取正在更改数据库配置", 30);
            //开辟设置线程池大小
            System.Threading.ThreadPool.SetMinThreads(64, 64);
            System.Threading.ThreadPool.SetMaxThreads(200, 200);
            _ = new Homepag_class(this);
            BindingProcessMsg("正在设置线程池配置", 60);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += ((object sende1r, EventArgs e1) =>
            {
                Form3 form3 = new Form3();
                form3.Text = "主画面";
                form3.Show();
                this.Hide();
                timer.Stop();
                timer.Dispose();
            });
            BindingProcessMsg("正在判断是否重复打开软件", 90);
            if (Home_examine())
            {
                MessageBox.Show("你已经打开了该应用程序--不能重复打开");
                Application.Restart();
                this.Close();//关闭窗口
                this.Dispose();//释放内存
            }
            else
                timer.Start();
            BindingProcessMsg("配置完成正在打开软件", 100);
        }
    }
}
