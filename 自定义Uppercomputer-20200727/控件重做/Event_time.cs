using CCWin.SkinClass;
using CCWin.SkinControl;
using CSEngineTest;
using Microsoft.Graph;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using 自定义Uppercomputer_20200727.异常界面;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 继承系统定时器
    /// 重写定时器控件--用于窗口的报警触发-与登录后的事件触发
    /// </summary>
    class Event_time : System.Windows.Forms.Timer
    {
        /// <summary>
        /// 指示着窗口是否开启了编辑模式--停止事件遍历
        /// </summary>
        public bool Form_busy { get; set; }//指示着窗口是否开启了编辑模式--停止事件遍历
        /// <summary>
        /// 当前事件线程--用于关闭任务
        /// </summary>
        public Thread Event_thread { get; set; }//当前事件线程--用于关闭任务
        /// <summary>
        /// 指示着已经登录的事件--已经注册的不太显示到表格中--等待事件变不成立移除事件
        /// </summary>
        public List<自定义Uppercomputer_20200727.EF实体模型.Event_message> register_Event { get; set; }//指示着已经登录的事件--已经注册的不太显示到表格中--等待事件变不成立移除事件
        /// <summary>
        /// 查询到数据库的事件表
        /// </summary>
        private List<自定义Uppercomputer_20200727.EF实体模型.Event_message> Event;//查询到数据库的事件表
        /// <summary>
        /// 创建EF对象
        /// </summary>
        private Event_EF Event_EF;//创建EF对象
        /// <summary>
        /// 创建报警表格对象
        /// </summary>
        private static DataGridView SkinDataGridView;//创建报警表格对象
        /// <summary>
        /// 指示着是否已经从数据库遍历完成
        /// </summary>
        private bool Event_ok;//指示着是否已经从数据库遍历完成
        /// <summary>
        /// 指示上次遍历已经登录的事件
        /// </summary>
        private int Event_quantity = 0;//指示上次遍历已经登录的事件
        /// <summary>
        /// 指示定时器是否正在忙
        /// </summary>
        private bool busy;//指示定时器是否正在忙
        /// <summary>
        /// 线程锁对象
        /// </summary>
        private static object ese = new object();//线程锁对象
        /// <summary>
        /// 需要显示报警的窗口对象
        /// </summary>
        public Form5 form_run;
        /// <summary>
        /// 定义安全集合
        /// </summary>
        private ConcurrentBag<自定义Uppercomputer_20200727.EF实体模型.Event_message> event_Messages;//定义安全集合

        //该参数用于报警条
        /// <summary>
        /// 用于实例化窗口委托刷新数据
        /// </summary>
        private Form form_entrust;//用于实例化窗口委托刷新数据
        /// <summary>
        /// 获取报警条
        /// </summary>
        private ScrollingText_reform scrollingText;//获取报警条
        public Event_time(DataGridView SkinDataGridView_1, Form5 form)//构造函数
        {
            //实例化一些对象
            register_Event = new List<自定义Uppercomputer_20200727.EF实体模型.Event_message>();//实例化已注册表
            Event = new List<自定义Uppercomputer_20200727.EF实体模型.Event_message>();//实例化查询表
            Event_EF = new Event_EF();//实例化EF对象
            SkinDataGridView = SkinDataGridView_1;//获取要填充与修改的表格
            form_run = form;//传递窗口
            //启用定时器
            this.Enabled = true;
            this.Interval = 1000;//默认刷新时间
            //注册刷新事件
            this.Tick += Event_Tick;//注册事件
            busy = false;//指示定时器是否正在忙
        }
        /// <summary>
        /// 无参数构造函数--用于报警条产生
        /// </summary>
        /// <param name="scrollingText"></param>
        /// <param name="form"></param>
        public Event_time(ScrollingText_reform scrollingText, Form form)//无参数构造函数--用于报警条产生
        {
            //实例化一些对象
            register_Event = new List<自定义Uppercomputer_20200727.EF实体模型.Event_message>();//实例化已注册表
            Event = new List<自定义Uppercomputer_20200727.EF实体模型.Event_message>();//实例化查询表
            Event_EF = new Event_EF();//实例化EF对象
            form_entrust = form;//获取实例化的窗口
            this.scrollingText = scrollingText;//获取报警条对象
            //启用定时器
            this.Enabled = true;
            this.Interval = 6000;//默认刷新时间
            //注册刷新事件
            this.Tick += scrollingText_Tick;//注册事件
            busy = false;//指示定时器是否正在忙
        }
        /// <summary>
        /// 事件刷新--与登录事件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Event_Tick(object send, EventArgs e)//事件刷新--与登录事件
        {

            if (Form_busy != false) { Event_ok = false; return; }//指示着窗口正忙--启用编辑模式
            if (busy != false) { return; }//指示着窗口正忙--正在遍历任务 
                                          //ThreadPool.QueueUserWorkItem((da_e) =>//加入序列线程池
            lock (ese)
            {
                Event_thread = new Thread(() =>//改为线程使用
                {
                    Thread.Sleep(100);//保证线程安全
                    busy = true;//指示定时器是否正在忙
                    if (Event_ok != true)//指示着上一次是否遍历过
                    {
                        register_Event.Clear();//清空已注册表
                        Event.Clear();//清空事件表
                                      //SkinDataGridView.Rows.Clear();//清空已经显示的报警
                        Event = Event_EF.Event_Query();//获取所有事件
                        Event_ok = true;//遍历完成指示
                    }
                    for (int i = 0; i < Event.Count; i++)//遍历事件表
                    {
                        if (Form_busy != false) { Event_ok = false; busy = false; return; }//指示着窗口正忙--启用编辑模式               
                        plc(Event[i]);//遍历事件
                    }
                    busy = false;//指示定时器是否正在忙
                });
                Event_thread.Start();//允许线程
            }
        }
        /// <summary>
        /// 按照PLC类型进行事件读取
        /// </summary>
        /// <param name="event_Message"></param>
        private void plc(自定义Uppercomputer_20200727.EF实体模型.Event_message event_Message)//按照PLC类型进行事件读取
        {
            switch (event_Message.设备.Trim())
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            switch (event_Message.类型)
                            {
                                case 0:
                                    List<bool> data = mitsubishi_AxActUtlType.PLC_read_M_bit(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim());//读取状态
                                    trigger_Bit(data[0], event_Message);//判断bit触发条件
                                    break;
                                case 1:
                                    string numerical = mitsubishi_AxActUtlType.PLC_read_D_register(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim(), numerical_format.Signed_16_Bit);//读取字数据
                                    trigger_word(numerical, event_Message);//判断字触发条件
                                    break;
                            }
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            switch (event_Message.类型)
                            {
                                case 0:
                                    List<bool> data = mitsubishi.PLC_read_M_bit(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim());//读取状态
                                    trigger_Bit(data[0], event_Message);//判断bit触发条件
                                    break;
                                case 1:
                                    string numerical = mitsubishi.PLC_read_D_register(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim(), numerical_format.Signed_16_Bit);//读取字数据
                                    trigger_word(numerical, event_Message);//判断字触发条件
                                    break;
                            }
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        switch (event_Message.类型)
                        {
                            case 0:
                                List<bool> data = Siemens.PLC_read_M_bit(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim());//读取状态
                                trigger_Bit(data[0], event_Message);//判断bit触发条件
                                break;
                            case 1:
                                string numerical = Siemens.PLC_read_D_register(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim(), numerical_format.Signed_16_Bit);//读取字数据
                                trigger_word(numerical, event_Message);//判断字触发条件
                                break;
                        }
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        switch (event_Message.类型)
                        {
                            case 0:
                                List<bool> data = MODBUD_TCP.IPLC_interface_PLC_read_M_bit(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim());//读取状态
                                trigger_Bit(data[0], event_Message);//判断bit触发条件
                                break;
                            case 1:
                                string numerical = MODBUD_TCP.IPLC_interface_PLC_read_D_register(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim(), numerical_format.Signed_16_Bit);//读取字数据
                                trigger_word(numerical, event_Message);//判断字触发条件
                                break;
                        }
                    }
                    break;
                //添加 宏指令 触发报警功能-
                case "HMI":

                    switch (event_Message.类型)
                    {
                        case 0:
                            if (macroinstruction_data<bool>.M_Data[event_Message.设备_具体地址.Trim().ToInt32()].IsNull()!=true)
                                trigger_Bit(macroinstruction_data<bool>.M_Data[event_Message.设备_具体地址.Trim().ToInt32()], event_Message);//判断bit触发条件
                            break;
                        case 1:                         
                                try
                                {
                                     if (macroinstruction_data<int>.D_Data[event_Message.设备_具体地址.Trim().ToInt32()].IsNull() != true)
                                     trigger_word((Convert.ToInt32(macroinstruction_data<int>.D_Data[event_Message.设备_具体地址.Trim().ToInt32()])).ToString() ?? "0", event_Message);//判断字触发条件
                                }
                            catch { }
                            break;
                    }
                    break;
            }
            //开始把事件显示到表中
            if (register_Event.Count == Event_quantity) return;//返回方法不做显示登录
            event_Messages = new ConcurrentBag<EF实体模型.Event_message>();
            foreach (var i in register_Event) event_Messages.Add(i);
            form_run.DataGridView(event_Messages);//事件显示登录
            Event_quantity = register_Event.Count;//记录保持     
        }
        /// <summary>
        /// 位触发条件
        /// </summary>
        /// <param name="In"></param>
        /// <param name="event_Message"></param>
        private void trigger_Bit(bool In, 自定义Uppercomputer_20200727.EF实体模型.Event_message event_Message)//位触发条件
        {
            switch (event_Message.位触发条件.Trim())
            {
                case "ON":
                    if (In & register_Event.Where(pi => pi.ID == event_Message.ID).FirstOrDefault().IsNull())
                        register_Event.Add(event_Message);//登录到事件表
                    if (In != true & register_Event.Where(pi => pi.ID == event_Message.ID).FirstOrDefault().IsNull() != true)
                    {
                        register_Event.Remove(event_Message);//移除对象
                    }
                    break;
                case "OFF":
                    if (In != true & register_Event.Where(pi => pi.ID == event_Message.ID).FirstOrDefault().IsNull())
                        register_Event.Add(event_Message);//登录到事件表
                    if (In == true & register_Event.Where(pi => pi.ID == event_Message.ID).FirstOrDefault() != null)
                    {
                        register_Event.Remove(event_Message);//移除对象
                    }
                    break;
            }
        }
        /// <summary>
        /// 字触发条件
        /// </summary>
        /// <param name="data"></param>
        /// <param name="event_Message"></param>
        private void trigger_word(string data, 自定义Uppercomputer_20200727.EF实体模型.Event_message event_Message)//字触发条件
        {
            bool condition = false;//指示是否加入已登录
            switch (event_Message.字触发条件.Trim())
            {
                case "<"://小于设定数据
                    if (Convert.ToInt32(data) < Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = true;//条件成立添加
                    if (Convert.ToInt32(data) >= Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = false;//条件不成立异常
                    break;
                case ">":
                    if (Convert.ToInt32(data) > Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = true;//条件成立添加
                    if (Convert.ToInt32(data) <= Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = false;//条件不成立异常
                    break;
                case "==":
                    if (Convert.ToInt32(data) == Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = true;//条件成立添加
                    if (Convert.ToInt32(data) != Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = false;//条件不成立异常
                    break;
                case "<>":
                    if (Convert.ToInt32(data) != Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = true;//条件成立添加
                    if (Convert.ToInt32(data) == Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = false;//条件不成立异常
                    break;
                case ">=":
                    if (Convert.ToInt32(data) >= Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = true;//条件成立添加
                    if (Convert.ToInt32(data) < Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = false;//条件不成立异常
                    break;
                case "<=":
                    if (Convert.ToInt32(data) <= Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = true;//条件成立添加
                    if (Convert.ToInt32(data) > Convert.ToInt32(event_Message.字触发条件_具体.ToInt32())) condition = false;//条件不成立异常
                    break;
            }
            //这里开始注册或者异常事件
            if (condition & register_Event.Where(pi => pi.ID == event_Message.ID).FirstOrDefault().IsNull())
                register_Event.Add(event_Message);//登录到事件表
            if (condition != true & register_Event.Where(pi => pi.ID == event_Message.ID).FirstOrDefault().IsNull() != true)
            {
                register_Event.Remove(event_Message);//移除对象
            }
        }
        /// <summary>
        /// 报警条-事件刷新--与登录事件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void scrollingText_Tick(object send, EventArgs e)//报警条-事件刷新--与登录事件
        {

            if (Form2.edit_mode != false) { Event_ok = false; return; }//指示着窗口正忙--启用编辑模式
            if (busy != false) { return; }//指示着窗口正忙--正在遍历任务 
            ThreadPool.QueueUserWorkItem((da_e) =>//加入序列线程池
            { 
            //lock (ese)
            //{
                Thread.Sleep(100);//保证线程安全
                busy = true;//指示定时器是否正在忙
                if (Event_ok != true)//指示着上一次是否遍历过
                {
                    register_Event.Clear();//清空已注册表
                    Event.Clear();//清空事件表
                                  //SkinDataGridView.Rows.Clear();//清空已经显示的报警
                    Event = Event_EF.Event_Query();//获取所有事件
                    Event_ok = true;//遍历完成指示
                }
                for (int i = 0; i < Event.Count; i++)//遍历事件表
                {
                    if (Form2.edit_mode != false) { Event_ok = false; busy = false; return; }//指示着窗口正忙--启用编辑模式               
                    plc(Event[i], scrollingText);//遍历事件
                }
                busy = false;//指示定时器是否正在忙
           // }
            });
        }
        /// <summary>
        /// 按照PLC类型进行事件读取
        /// </summary>
        /// <param name="event_Message"></param>
        /// <param name="scrollingText"></param>
        private void plc(自定义Uppercomputer_20200727.EF实体模型.Event_message event_Message, ScrollingText_reform scrollingText)//按照PLC类型进行事件读取
        {
            switch (event_Message.设备.Trim())
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            switch (event_Message.类型)
                            {
                                case 0:
                                    List<bool> data = mitsubishi_AxActUtlType.PLC_read_M_bit(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim());//读取状态
                                    trigger_Bit(data[0], event_Message);//判断bit触发条件
                                    break;
                                case 1:
                                    string numerical = mitsubishi_AxActUtlType.PLC_read_D_register(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim(), numerical_format.Signed_16_Bit);//读取字数据
                                    trigger_word(numerical, event_Message);//判断字触发条件
                                    break;
                            }
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            switch (event_Message.类型)
                            {
                                case 0:
                                    List<bool> data = mitsubishi.PLC_read_M_bit(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim());//读取状态
                                    trigger_Bit(data[0], event_Message);//判断bit触发条件
                                    break;
                                case 1:
                                    string numerical = mitsubishi.PLC_read_D_register(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim(), numerical_format.Signed_16_Bit);//读取字数据
                                    trigger_word(numerical, event_Message);//判断字触发条件
                                    break;
                            }
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        switch (event_Message.类型)
                        {
                            case 0:
                                List<bool> data = Siemens.PLC_read_M_bit(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim());//读取状态
                                trigger_Bit(data[0], event_Message);//判断bit触发条件
                                break;
                            case 1:
                                string numerical = Siemens.PLC_read_D_register(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim(), numerical_format.Signed_16_Bit);//读取字数据
                                trigger_word(numerical, event_Message);//判断字触发条件
                                break;
                        }
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        switch (event_Message.类型)
                        {
                            case 0:
                                List<bool> data = MODBUD_TCP.IPLC_interface_PLC_read_M_bit(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim());//读取状态
                                trigger_Bit(data[0], event_Message);//判断bit触发条件
                                break;
                            case 1:
                                string numerical = MODBUD_TCP.IPLC_interface_PLC_read_D_register(event_Message.设备_地址.Trim(), event_Message.设备_具体地址.Trim(), numerical_format.Signed_16_Bit);//读取字数据
                                trigger_word(numerical, event_Message);//判断字触发条件
                                break;
                        }
                    }
                    break;

            }
            //开始把事件显示到表中
            if (register_Event.Count == Event_quantity) return;//返回方法不做显示登录
            event_Messages = new ConcurrentBag<EF实体模型.Event_message>();
            foreach (var i in register_Event) event_Messages.Add(i);
            scrollingText_event(scrollingText,event_Messages);//事件显示登录
            Event_quantity = register_Event.Count;//记录保持     
        }
        /// <summary>
        /// 填充报警内容
        /// </summary>
        /// <param name="scrollingText"></param>
        /// <param name="_Messages"></param>
        private void scrollingText_event(ScrollingText_reform scrollingText, ConcurrentBag<EF实体模型.Event_message> _Messages)//填充报警内容
        {
            form_entrust.BeginInvoke((MethodInvoker)delegate//委托当前窗口执行任务
            {
                scrollingText.Text = " ";//初始化报警内容
                foreach (var i in _Messages) scrollingText.Text += i.设备.Trim()+i.报警内容.Trim() + "、、";//拼接报警内容
            });
        }
        /// <summary>
        /// 显示已经登录的事件
        /// </summary>
        /// <param name="skinDataGridView"></param>
        private void DataGridView(DataGridView skinDataGridView)//显示已经登录的事件
        {        
            if (skinDataGridView.IsNull()||skinDataGridView.Rows.Count<0) return;//如果控件为null直接返回
            skinDataGridView.Rows.Clear();//清除所有数据
            skinDataGridView.Rows.Add();//先添加行            
            for (int i = 0; i < register_Event.Count; i++)
            {
                if(skinDataGridView.Rows.Count<i) skinDataGridView.Rows.Add();//先添加行 
                skinDataGridView.Rows[i].Cells[0].Value = register_Event[i].ID;
                skinDataGridView.Rows[i].Cells[1].Value = DateTime.Now.ToString();
                skinDataGridView.Rows[i].Cells[2].Value = DateTime.Now.Date.ToString();
                skinDataGridView.Rows[i].Cells[3].Value = register_Event[i].报警内容.Trim();
                skinDataGridView.Rows[i].Cells[4].Value = i.ToString();
                skinDataGridView.Rows.Add();//先添加行
            }
            Event_quantity = register_Event.Count;//记录保持            
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //实例化一些对象
            register_Event = null;
            Event = null;
            Event_EF = null;
            //注册刷新事件
            this.Tick -= Event_Tick;//注册事件
        }
        
    }
}
