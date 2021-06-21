using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.主页面;
using System.Threading;
using 自定义Uppercomputer_20200727.控制主页面;
using System.Diagnostics;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.EF实体模型.XML;
using CCWin.SkinControl;
using 自定义Uppercomputer_20200727.Nlog;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;
using static PLC通讯规范接口.Request;
using 自定义Uppercomputer_20200727.主页面.进程通讯消息处理;
using 自定义Uppercomputer_20200727.控制主页面模板;
using 自定义Uppercomputer_20200727.控制主页面模板.模板窗口接口;
using 自定义Uppercomputer_20200727.控件重做;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace 自定义Uppercomputer_20200727
{
    public partial class Home : Form, FormIdentification
    {
        /// <summary>
        /// 标识该窗口是框架窗口
        /// 默认所有窗口都是切换完成后自动关闭
        /// </summary>
        private bool frameForm { get; set; } = false;

        public bool IsCloseForm { get => frameForm; }
        public bool IsfunctionKey { get; set; }
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
            //进程间通讯程序 启动 
            //Form1 form1 = new Form1();
            //form1.Show();
            //监听
            SocketServer socketServer = new SocketServer(new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 9500));
            socketServer.SocketLoad();
            //LogUtils日志
            LogUtils.debugWrite("开始加载程序集"+axActUtlType1.Name);
            ActUtlType = this.axActUtlType1;
            //启动报警历史记录
            History_Shown();
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

        [Obsolete]
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
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
            string newConString = $@"data source={@Path.GetFullPath("../../")}SQL数据库文件\Extent1.db;Version=3;";
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
                //判断SQL路径是否正确
                using(UppercomputerEntities2 db=new UppercomputerEntities2())
                {
                   if( db.PLC_parameter.Where(pi => true).Select(pi => pi).Count()<1)
                    {
                        if( MessageBox.Show("初步判断SQL数据库路径错误 是否尝试重启解决？","SQL数据库错误",MessageBoxButtons.YesNo)==DialogResult.Yes)
                        {
                            Application.Restart();//重启软件
                        }
                    }    
                }
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
        }
        //进程通讯上位机 使用的API函数

        [DllImport("User32.dll", EntryPoint = "SendMessage")]

        private static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCTresult lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]

        private static extern int FindWindow(string lpClassName, string lpWindowName);
        const int WM_COPYDATA = 0x004A;
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)

            {
                case WM_COPYDATA:
                    COPYDATASTRUCT cds = new COPYDATASTRUCT();
                    Type t = cds.GetType();
                    cds = (COPYDATASTRUCT)m.GetLParam(t);
                    Messagehandling messagehandling = new Messagehandling();
                    var data= messagehandling.Manage(cds);

                    //处理完成后返回 数据
                    int hWnd = FindWindow(null, @cds.characteristic);
                    if (hWnd == 0)
                    {
                        MessageBox.Show("未找到消息接受者！");
                    }
                    else
                    {
                        data.characteristic = this.Name;
                        data.cbData = messagehandling.Messagelen(data);

                        SendMessage(hWnd, WM_COPYDATA, 0, ref data);
                    }
                    break;

                default:

                    base.DefWndProc(ref m);
                    break;
            }

        }
        //报警历史登录 --实现--
        Event_time event_Time;//事件刷新定时器
        Mutex mutex;//线程锁
        System.Windows.Forms.Timer refresh;//事件刷新定时器
        SkinDataGridView HistorygridView;
        private void refresh_Tick(object sender, EventArgs e)//定时器指示窗口是否忙
        {
            event_Time.Form_busy = Form2.edit_mode;//指示着用户是否开启编辑模式
        }
        private void History_Shown()//显示窗口事件
        {
            HistorygridView = new SkinDataGridView();
            mutex = new Mutex();
            refresh = new System.Windows.Forms.Timer();//实例化刷新定时器
            refresh.Tick += refresh_Tick;//注册事件
            refresh.Enabled = true;
            refresh.Interval = 2000;//默认2秒一刷
            refresh.Start();
            event_Time = new Event_time(HistorygridView, this);//开始事件登录
            event_Time.Start();//运行定时器
            event_Time.History += HistorySQL;

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            refresh.Stop();
            refresh.Dispose();
            event_Time.Stop();
            if (event_Time.Event_thread != null) event_Time.Event_thread.Abort();//结束任务
            event_Time.Dispose();
        }
        /// <summary>
        /// 报警历史到SQL数据库中
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void HistorySQL(object send,EventArgs e)
        {

        }
        /// <summary>
        /// 登录事件刷新方法 不可删除
        /// </summary>
        /// <param name="register_Event_1"></param>
        public void DataGridView(ConcurrentBag<自定义Uppercomputer_20200727.EF实体模型.Event_message> register_Event_1)//显示已经登录的事件
        {
            if (this.IsHandleCreated != true) return;//判断创建是否加载完成            
            //this.BeginInvoke((MethodInvoker)delegate ()
            //{
            //    lock (this)
            //    {
            //        mutex.WaitOne();
            //        List<自定义Uppercomputer_20200727.EF实体模型.Event_message> register_Event = register_Event_1.ToList();//获取对象
            //        if (HistorygridView.Rows.Count < 0) return;//如果控件为null直接返回
            //        HistorygridView.Rows.Clear();//清除所有数据
            //        HistorygridView.Rows.Add();//先添加行            
            //        for (int i = 0; i < register_Event.Count; i++)
            //        {
            //            if (HistorygridView.Rows.Count < i) HistorygridView.Rows.Add();//先添加行 
            //            HistorygridView.Rows[i].Cells[0].Value = register_Event[i].ID;
            //            HistorygridView.Rows[i].Cells[1].Value = DateTime.Now.ToString();
            //            HistorygridView.Rows[i].Cells[2].Value = DateTime.Now.Date.ToString();
            //            HistorygridView.Rows[i].Cells[3].Value = register_Event[i].报警内容.Trim();
            //            HistorygridView.Rows[i].Cells[4].Value = i.ToString();
            //            HistorygridView.Rows.Add();//先添加行
            //        }
            //        mutex.ReleaseMutex();
            //    }
            //});
        }
    }
}
