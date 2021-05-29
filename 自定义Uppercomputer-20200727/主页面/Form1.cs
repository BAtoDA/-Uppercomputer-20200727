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
using 自定义Uppercomputer_20200727.Nlog;
using System.Xml;
using 自定义Uppercomputer_20200727.EF实体模型.EFtoSQL操作类重写;

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
        public static string SQLname { get; set; } = @"LAPTOP-INNCV6MO";
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
            //LogUtils日志
            LogUtils.debugWrite("开始加载程序集"+axActUtlType1.Name);
            ActUtlType = this.axActUtlType1;        
        }
        public void BindingProcessMsg(string strText, int intValue)
        {
            label1.Text = strText;
            this.ucProcessLineExt1.Value = intValue;
            //LogUtils日志
            LogUtils.debugWrite($"{this.Name}  正在加载配置文件：" + strText+intValue.ToString());
            Thread.Sleep(200);
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
            //测试代码------------
           //var SS= Button_EFbase.Button_Parameter_inquire<Button_Class>("自定义Uppercomputer_20200727.控制主页面.Form3, Text: 主画面-Button_reform1");
           //var button_EFbase = new Button_EFbase().Button_Parameter_Add<Button_colour>(new Button_colour() { ID= "自定义Uppercomputer_20200727.控制主页面.Form3, Text: 主画面-Button_reform20", FORM= "Form3", colour_0= "DarkGray", colour_1= "GreenYellow" });

            XmlClick();
            LogUtils.deleteLogFile(@Application.StartupPath);//检查是否有超过2个月的日志 进行删除操作
            //LogUtils日志
            LogUtils.debugWrite(DateTime.Now+"  运行了"+Application.ProductName+"  版本号："+ System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            timer1.Stop();
            //读取数据库文件
            BindingProcessMsg("正在读取XML文件", 10);
            XML xML = new XML(@Application.StartupPath);
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
            timer.Interval = 200;
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
        [Obsolete]
        protected void XmlClick()
        {
            string newName = "SqliteTest";
            string newConString = $@"data source={@Application.StartupPath}\Extent1.db;Version=3;";
            //首先要登录进xml中也就是appconfig
            XmlDataDocument doc = new XmlDataDocument();
            string nowpath = System.Windows.Forms.Application.ExecutablePath + ".config";
            doc.Load(nowpath);
            XmlNode node = doc.SelectSingleNode("//connectionStrings");//获取connectionStrings节点
            try
            {
                XmlElement element = (XmlElement)node.SelectSingleNode("//add[@name='" + newName + "']");
                if (element != null)
                {
                    //存在更新子节点
                    element.SetAttribute("connectionString", newConString);
                }
                doc.Save(nowpath);
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
        }
    }
}
