using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.Nlog;
using 自定义Uppercomputer_20200727.异常界面.报警历史;
using 自定义Uppercomputer_20200727.控件重做;

namespace 自定义Uppercomputer_20200727.异常界面
{
    public partial class Form5 : Form2
    {
        Event_time event_Time;//事件刷新定时器
        Mutex mutex;//线程锁
        public Form5()
        {
            InitializeComponent();
            mutex = new Mutex();
        }

        private void refresh_Tick(object sender, EventArgs e)//定时器指示窗口是否忙
        {
            event_Time.Form_busy = Form2.edit_mode;//指示着用户是否开启编辑模式
        } 
        System.Windows.Forms.Timer refresh;//事件刷新定时器
        private void Form5_Shown(object sender, EventArgs e)//显示窗口事件
        {
            refresh = new System.Windows.Forms.Timer();//实例化刷新定时器
            refresh.Tick += refresh_Tick;//注册事件
            refresh.Enabled = true;
            refresh.Interval = 2000;//默认2秒一刷
            refresh.Start();
            event_Time = new Event_time(this.skinDataGridView1,this);//开始事件登录
            event_Time.Start();//运行定时器
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            refresh.Stop();
            refresh.Dispose();
            event_Time.Stop();
            if (event_Time.Event_thread != null) event_Time.Event_thread.Abort();//结束任务
            event_Time.Dispose();
            Thread.Sleep(200);
        }
        /// <summary>
        /// 登录事件刷新方法 不可删除
        /// </summary>
        /// <param name="register_Event_1"></param>
        public async void DataGridView(ConcurrentBag<自定义Uppercomputer_20200727.EF实体模型.Event_message> register_Event_1)//显示已经登录的事件
        {
            if (this.IsHandleCreated != true) return;//判断创建是否加载完成            
           await Task.Run(()=>
            {
                lock (this)
                {
                    //  mutex.WaitOne();
                    List<自定义Uppercomputer_20200727.EF实体模型.Event_message> register_Event = register_Event_1.ToList();//获取对象
                    if (this.skinDataGridView1.Rows.Count < 0) return;//如果控件为null直接返回
                    this.skinDataGridView1.Rows.Clear();//清除所有数据
                    this.skinDataGridView1.Rows.Add();//先添加行            
                    for (int i = 0; i < register_Event.Count; i++)
                    {
                        if (this.skinDataGridView1.Rows.Count < i) this.skinDataGridView1.Rows.Add();//先添加行 
                        this.skinDataGridView1.Rows[i].Cells[0].Value = register_Event[i].ID;
                        this.skinDataGridView1.Rows[i].Cells[1].Value = DateTime.Now.ToString();
                        this.skinDataGridView1.Rows[i].Cells[2].Value = DateTime.Now.Date.ToString();
                        this.skinDataGridView1.Rows[i].Cells[3].Value = register_Event[i].报警内容.Trim();
                        this.skinDataGridView1.Rows[i].Cells[4].Value = i.ToString();
                        this.skinDataGridView1.Rows.Add();//先添加行
                    }
                    //   mutex.ReleaseMutex();
                }
            });
        }
        /// <summary>
        /// 用户点击了事件注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton1_Click(object sender, EventArgs e)
        {
            //LogUtils日志
            LogUtils.debugWrite($"用户点击了 报警注册界面");

            Event_registration event_Registration = new Event_registration();//实例化报警注册窗口
            event_Registration.ShowDialog();//弹出窗口
            //LogUtils日志
            LogUtils.debugWrite($"用户点关闭 报警注册界面");
        }
        /// <summary>
        /// 报警历史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton2_Click(object sender, EventArgs e)
        {
            //LogUtils日志
            LogUtils.debugWrite($"用户点击了 报警历史界面");
            HistoryErr historyErr = new HistoryErr();
            historyErr.Show();
        }
    }
}
