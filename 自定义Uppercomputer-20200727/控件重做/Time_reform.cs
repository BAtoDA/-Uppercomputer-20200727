using CCWin.SkinClass;
using CCWin.SkinControl;
using CCWin.Win32.Const;
using CSEngineTest;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 继承系统定时器
    /// 重写定时器控件--用于窗口控件的刷新-文本数据刷新
    /// </summary>
    class Time_reform : System.Windows.Forms.Timer
    {
        /// <summary>
        /// 当前窗口是否允许继续遍历控件---指示着用户开启了编辑模式
        /// </summary>
        public bool read_status { get; set; }//当前窗口是否允许继续遍历控件---指示着用户开启了编辑模式
        /// <summary>
        /// 当前窗口是否允许写入按钮控件参数--可以当成正在遍历控件
        /// </summary>
        public bool Button_read_status { get; set; }//当前窗口是否允许写入按钮控件参数--可以当成正在遍历控件
        /// <summary>
        /// 当前窗口是否允许写入文本输入控件参数--可以当成正在遍历控件
        /// </summary>
        public bool TextBox_read_status { get; set; }//当前窗口是否允许写入文本输入控件参数--可以当成正在遍历控件
        /// <summary>
        /// 当前窗口是否允许写入切换开关类控件参数--可以当成正在遍历控件
        /// </summary>
        public bool Switch_read_status { get; set; }//当前窗口是否允许写入切换开关类控件参数--可以当成正在遍历控件
        /// <summary>
        /// 当前窗口是否允许写入指示灯类控件参数--可以当成正在遍历控件
        /// </summary>
        public bool LedBulb_read_status { get; set; }//当前窗口是否允许写入指示灯类控件参数--可以当成正在遍历控件
        /// <summary>
        /// 当前窗口是否允许写入无图片按钮类控件参数--可以当成正在遍历控件
        /// </summary>
        public bool ImageButton_read_status { get; set; }//当前窗口是否允许写入无图片按钮类控件参数--可以当成正在遍历控件
        /// <summary>
        /// 当前窗口是否允许写入圆形图类控件参数--可以当成正在遍历控件
        /// </summary>
        public bool doughnut_Chart_read_status { get; set; }//当前窗口是否允许写入圆形图类控件参数--可以当成正在遍历控件
        /// <summary>
        /// 当前窗口是否允许写入柱形图类控件参数--可以当成正在遍历控件
        /// </summary>
        public bool histogram_Chart_read_status { get; set; }//当前窗口是否允许写入柱形图类控件参数--可以当成正在遍历控件
        /// <summary>
        /// 当前窗口是否允许写入折线图类控件参数--可以当成正在遍历控件
        /// </summary>
        public bool oscillogram_Chart_read_status { get; set; }//当前窗口是否允许写入折线图类控件参数--可以当成正在遍历控件
        /// <summary>
        /// 当前窗口是否允许写入百分百表盘类控件参数--可以当成正在遍历控件
        /// </summary>
        public bool AnalogMeter_read_status { get; set; }//当前窗口是否允许写入百分百表盘类控件参数--可以当成正在遍历控件
        /// <summary>
        /// 当前窗口是否允许写入数值显示类控件参数--可以当成正在遍历控件
        /// </summary>
        public bool LedDisplay_read_status { get; set; }//当前窗口是否允许写入数值显示类控件参数--可以当成正在遍历控件
        /// <summary>
        /// 当前窗口是否允许写入二维码/条形码类控件参数--可以当成正在遍历控件
        /// </summary>
        public bool ihatetheqrcode_read_status { get; set; }//当前窗口是否允许写入二维码/条形码类控件参数--可以当成正在遍历控件
        /// <summary>
        /// 传入窗口属性
        /// </summary>
        public string Form { get { return Form; } set { present_Form = value; } }//传入窗口属性
        /// <summary>
        /// 传入要遍历读取状态的按钮类
        /// </summary>
        public ConcurrentBag<Button_reform> Button_list_1 { get; set; }//传入要遍历读取状态的按钮类
        List<Button_reform> Button_list = new List<Button_reform>();//传入要遍历读取状态的按钮类
        /// <summary>
        /// 传入要遍历读取数据的文本输入类ID
        /// </summary>
        public ConcurrentBag<SkinTextBox_reform> TextBox_list_1 { get; set; }//传入要遍历读取数据的文本输入类ID
        List<SkinTextBox_reform> TextBox_list = new List<SkinTextBox_reform>();//传入要遍历读取数据的文本输入类ID
        /// <summary>
        /// 传入要遍历读取数据的切换开关类ID
        /// </summary>
        public ConcurrentBag<Switch_reform> Switch_list_1 { get; set; }//传入要遍历读取数据的切换开关类ID
        List<Switch_reform> Switch_list = new List<Switch_reform>();//传入要遍历读取数据的切换开关类ID
        /// <summary>
        /// 传入要遍历读取数据的指示灯类ID
        /// </summary>
        public ConcurrentBag<LedBulb_reform> LedBulb_list_1 { get; set; }//传入要遍历读取数据的指示灯类ID
        List<LedBulb_reform> LedBulb_list = new List<LedBulb_reform>();//传入要遍历读取数据的指示灯类ID
        /// <summary>
        /// 传入要遍历读取状态的无图片按钮类
        /// </summary>
        public ConcurrentBag<ImageButton_reform> ImageButton_list_1 { get; set; }//传入要遍历读取状态的无图片按钮类
        List<ImageButton_reform> ImageButton_list = new List<ImageButton_reform>();//传入要遍历读取状态的无图片按钮类
        /// <summary>
        /// 传入要遍历读取状态的圆形图类
        /// </summary>
        public ConcurrentBag<doughnut_Chart_reform> doughnut_Chart_list_1 { get; set; }//传入要遍历读取状态的圆形图类
        List<doughnut_Chart_reform> doughnut_Chart_list = new List<doughnut_Chart_reform>();//传入要遍历读取状态的圆形图按钮类
        /// <summary>
        /// 传入要遍历读取状态的柱形图类
        /// </summary>
        public ConcurrentBag<histogram_Chart_reform> histogram_Chart_list_1 { get; set; }//传入要遍历读取状态的柱形图类
        List<histogram_Chart_reform> histogram_Chart_list = new List<histogram_Chart_reform>();//传入要遍历读取状态的柱形图按钮类
        /// <summary>
        /// 传入要遍历读取状态的折线图类
        /// </summary>
        public ConcurrentBag<oscillogram_Chart_reform> oscillogram_Chart_list_1 { get; set; }//传入要遍历读取状态的折线图类
        List<oscillogram_Chart_reform> oscillogram_Chart_list = new List<oscillogram_Chart_reform>();//传入要遍历读取状态的折线图按钮类
        /// <summary>
        /// 传入要遍历读取状态的百分百表盘类
        /// </summary>
        public ConcurrentBag<AnalogMeter_reform> AnalogMeter_list_1 { get; set; }//传入要遍历读取状态的百分百表盘类
        List<AnalogMeter_reform> AnalogMeter_list = new List<AnalogMeter_reform>();//传入要遍历读取状态的百分百表盘类
        /// <summary>
        /// 传入要遍历读取状态的数值显示类
        /// </summary>
        public ConcurrentBag<LedDisplay_reform> LedDisplay_list_1 { get; set; }//传入要遍历读取状态的数值显示类
        List<LedDisplay_reform> LedDisplay_list = new List<LedDisplay_reform>();//传入要遍历读取状态的数值显示类
        /// <summary>
        /// 
        /// </summary>
        public ConcurrentBag<ihatetheqrcode_reform> ihatetheqrcode_list_1 { get; set; }//传入要遍历读取状态的二维码/条形码类
        List<ihatetheqrcode_reform> ihatetheqrcode_list = new List<ihatetheqrcode_reform>();//传入要遍历读取状态的二维码/条形码类

        /// <summary>
        /// 控件类内部保存表
        /// </summary>
        string present_Form;//指示当前窗口
        List<Button_Class> button_Classes = new List<Button_Class>();//按钮类参数
        List<numerical_Class> numerical_Classes = new List<numerical_Class>();//文本输入类参数
        List<Switch_Class> Switch_Classes = new List<Switch_Class>();//切换开关类参数
        List<LedBulb_Class> LedBulb_Classes = new List<LedBulb_Class>();//指示灯类参数
        List<ImageButton_Class> ImageButton_Classes = new List<ImageButton_Class>();//无图片按钮类参数
        List<doughnut_Chart_Class> doughnut_Chart_Classes = new List<doughnut_Chart_Class>();//圆形图类参数
        List<histogram_Chart_Class> histogram_Chart_Classes = new List<histogram_Chart_Class>();//柱形图类参数
        List<oscillogram_Chart_Class> oscillogram_Chart_Classes = new List<oscillogram_Chart_Class>();//折线图类参数
        List<AnalogMeter_Class> AnalogMeter_Classes = new List<AnalogMeter_Class>();//百分百表盘类参数
        List<LedDisplay_Class> LedDisplay_Classes = new List<LedDisplay_Class>();//数值显示类参数
        List<ihatetheqrcode_Class> ihatetheqrcode_Classes = new List<ihatetheqrcode_Class>();//二维码/条形码类参数

        /// <summary>
        /// 控件对EF-数据库操作类
        /// </summary>
        Button_EF Button_EF;//按钮类EF对象
        numerical_EF numerical_EF;//文本输入类EF对象
        Switch_EF Switch_EF;//切换开关EF对象
        LedBulb_EF LedBulb_EF;//指示灯类EF对象
        ImageButton_EF ImageButton_EF;//无图片按钮类EF对象
        doughnut_Chart_EF doughnut_Chart_EF;//圆形图类EF对象
        histogram_Chart_EF histogram_Chart_EF;//柱形图类EF对象
        oscillogram_Chart_EF oscillogram_Chart_EF;//折线图类EF对象
        AnalogMeter_EF AnalogMeter_EF;//百分百表盘类EF对象
        LedDisplay_EF LedDisplay_EF;//数值显示类EF对象
        ihatetheqrcode_EF ihatetheqrcode_EF;//二维码/条形码类EF对象

        /// <summary>
        /// 指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool Button_EF_ok = false;//指示遍历数据库完成--不在遍历数据库
        /// <summary>
        /// 指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool numerical_EF_ok = false;//指示遍历数据库完成--不在遍历数据库
        /// <summary>
        /// 指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool Switch_EF_ok = false;//指示遍历数据库完成--不在遍历数据库
        /// <summary>
        /// 指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool LedBulb_EF_ok = false;//指示遍历数据库完成--不在遍历数据库
        /// <summary>
        /// 指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool ImageButton_EF_ok = false;//指示遍历数据库完成--不在遍历数据库
        /// <summary>
        /// //指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool doughnut_Chart_EF_ok = false;//指示遍历数据库完成--不在遍历数据库
        /// <summary>
        /// 指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool histogram_Chart_EF_ok = false;//指示遍历数据库完成--不在遍历数据库
        /// <summary>
        /// 指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool oscillogram_Chart_EF_ok = false;//指示遍历数据库完成--不在遍历数据库
        /// <summary>
        /// 指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool AnalogMeter_EF_ok = false;//指示遍历数据库完成--不在遍历数据库
        /// <summary>
        /// 指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool LedDisplay_EF_ok = false;//指示遍历数据库完成--不在遍历数据库
        /// <summary>
        /// 指示遍历数据库完成--不在遍历数据库
        /// </summary>
        bool ihatetheqrcode_EF_ok = false;//指示遍历数据库完成--不在遍历数据库

        /// <summary>
        /// 传入要刷新的窗口
        /// </summary>
        Form Form_Tick;//传入要刷新的窗口

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="form"></param>
        public Time_reform(Form form)//构造函数
        {
            this.Button_EF = new Button_EF();//实例化按钮类EF对象
            this.numerical_EF = new numerical_EF();//实例化文本输入类对象
            this.Switch_EF = new Switch_EF();//实例化切换开关类EF对象
            this.LedBulb_EF = new LedBulb_EF();//实例化指示灯类EF对象
            this.ImageButton_EF = new ImageButton_EF();//实例化无图片按钮类EF对象
            this.doughnut_Chart_EF = new doughnut_Chart_EF();//实例化圆形图类EF对象
            this.histogram_Chart_EF = new histogram_Chart_EF();//实例化圆形图EF对象
            this.oscillogram_Chart_EF = new oscillogram_Chart_EF();//实例化圆形图EF对象
            this.AnalogMeter_EF = new AnalogMeter_EF();//实例化百分百表盘EF对象
            this.LedDisplay_EF = new LedDisplay_EF();//实例化数值显示EF对象
            this.ihatetheqrcode_EF = new ihatetheqrcode_EF();//实例化二维码/条形码EF对象
            this.Form_Tick = form;//获取要刷新的窗口
            this.Tick += Time_Tick;
        }
        private void Time_Tick(object send, EventArgs e)
        {
            if (Form_Tick.IsHandleCreated != true) return;//判断创建是否加载完成   
            Form_Tick.BeginInvoke((EventHandler)delegate
            {
                Time_Tick_button(send, e);//注册按钮类刷新事件
                Time_Tick_Textbox(send, e);//注册文本输入类刷新事件
                Time_Tick_Switch(send, e);//注册切换开关类刷新事件
                Time_Tick_LedBulb(send, e);//注册指示灯类刷新事件
                Time_Tick_ImageButton(send, e);//注册无图片按钮类刷新事件
                Time_Tick_doughnut_Chart(send, e);//注册圆形图刷新事件
                Time_Tick_histogram_Chart(send, e);//注册柱形图事件
                Time_Tick_oscillogram_Chart(send, e);//注册柱形图事件
                Time_Tick_AnalogMeter(send, e);//注册百分百表盘事件
                Time_Tick_LedDisplay(send, e);//注册数值显示事件
                Time_Tick_ihatetheqrcode(send, e);//注册二维码/条形码事件
            });
        }
        /// <summary>
        /// 重写定时器事件定时器事件--刷新按钮类控件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_button(object send, EventArgs e)//定时器事件--刷新按钮类控件
        {
            if (read_status != false) { Button_EF_ok = false; return; }//窗口不允许读取
            if (this.Button_read_status != false || Button_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历this.TextBox_read_status != false || 
            Button_read_status = true;//指示着本类开始遍历控件
            if (Button_EF_ok != true)
            {
                button_Classes.Clear();//移除所有选项
                Button_list.Clear();//移除所有选项   
                foreach (Button_reform list in Button_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { Button_EF_ok = false; this.Button_read_status = false; return; }//窗口不允许读取
                    button_Classes.Add(Button_EF.Button_Parameter_Query(list.Parent + "-" + list.Name));//遍历获取参数
                    Button_list.Add(list);
                }
                Button_EF_ok = true;//遍历完成
            }
            if (button_Classes.Count != Button_list.Count) { Button_EF_ok = false; this.Button_read_status = false; return; }//窗口不允许读取
            ConcurrentBag<Tuple<Button_reform, Button_Class, Button_state>> tuples = new ConcurrentBag<Tuple<Button_reform, Button_Class, Button_state>>();//创建集合统一刷新UI
            for (int i = 0; i < button_Classes.Count; i++)
            {
                try
                {
                    if ((Button_list.Count - button_Classes.Count) < 0) { Button_list.Clear(); button_Classes.Clear(); this.Button_read_status = false; return; } //数据库读取信息与窗口不符合
                    if (read_status != false) { Button_EF_ok = false; this.Button_read_status = false; return; }//窗口不允许读取
                    if (button_Classes[i].IsNull() || Button_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (button_Classes[i].ID.Trim() != Button_list[i].Parent + "-" + Button_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    tuples.Add(plc(button_Classes[i].读写设备.Trim(), button_Classes[i], Button_list[i]));//开始遍历PLC并且写入按钮状态   
                }
                catch { return; }
            }

            Form_Tick.BeginInvoke((EventHandler)delegate
            {
                foreach (var i in tuples)
                {
                    button_state(i.Item1, i.Item2, i.Item3);//写入状态
                }
            });
            Button_read_status = false;//指示窗口可以进行遍历        
        }
        /// <summary>
        /// 根据PLC类型读取--按钮类
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="button_Class"></param>
        /// <param name="button_Reform"></param>
        /// <returns></returns>
        private Tuple<Button_reform, Button_Class, Button_state> plc(string pLC, Button_Class button_Class, Button_reform button_Reform)//根据PLC类型读取--按钮类
        {
            PLC选择.Button_state button_State = PLC选择.Button_state.Off;//按钮状态
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            List<bool> data = mitsubishi_AxActUtlType.PLC_read_M_bit(button_Class.读写设备_地址.Trim(), button_Class.读写设备_地址_具体地址.Trim());//读取状态
                            //button_state(button_Reform, button_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                            button_State = data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off;
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            List<bool> data = mitsubishi.PLC_read_M_bit(button_Class.读写设备_地址.Trim(), button_Class.读写设备_地址_具体地址.Trim());//读取状态
                            //button_state(button_Reform, button_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                            button_State = data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off;
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = Siemens.PLC_read_M_bit(button_Class.读写设备_地址.Trim(), button_Class.读写设备_地址_具体地址.Trim());//读取状态
                        //button_state(button_Reform, button_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                        button_State = data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off;
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = MODBUD_TCP.IPLC_interface_PLC_read_M_bit(button_Class.读写设备_地址.Trim(), button_Class.读写设备_地址_具体地址.Trim());//读取状态
                        //button_state(button_Reform, button_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                        button_State = data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off;
                    }
                    break;
                case "HMI":
                    //button_state(button_Reform, button_Class, macroinstruction_data<bool>.M_Data[button_Class.读写设备_地址_具体地址.Trim().ToInt32()] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                    button_State = macroinstruction_data<bool>.M_Data[button_Class.读写设备_地址_具体地址.Trim().ToInt32()] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off;
                    break;

            }
            return new Tuple<Button_reform, Button_Class, Button_state>(button_Reform, button_Class, button_State);
        }
        /// <summary>
        /// 填充按钮类
        /// </summary>
        /// <param name="button_Reform"></param>
        /// <param name="button_Classes"></param>
        /// <param name="button_State"></param>
        private void button_state(Button_reform button_Reform, Button_Class button_Classes, Button_state button_State)//填充按钮类
        {
            if (Form_Tick.IsHandleCreated != true) return;//判断创建是否加载完成   
            try
            {
                //Form_Tick.BeginInvoke((EventHandler)delegate
                //{
                switch (button_State)
                {
                    case PLC选择.Button_state.Off:
                        button_Reform.Text = button_Classes.Control_state_0_content.Trim();//设置文本
                        button_Reform.ForeColor = Color.FromName(button_Classes.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_0_typeface.Trim(), button_Classes.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.TextAlign = ContentAlignment_1(button_Classes.Control_state_0_aligning.Trim());//设置对齐方式
                        button_Reform.BaseColor = Color.FromName(button_Classes.colour_0.Trim());//设置样式
                        button_Reform.DownBaseColor = Color.FromName(button_Classes.colour_0.Trim());//设置样式
                        break;
                    case PLC选择.Button_state.ON:
                        button_Reform.Text = button_Classes.Control_state_1_content1.Trim();//设置文本
                        button_Reform.ForeColor = Color.FromName(button_Classes.Control_state_1_colour.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_1_typeface.Trim(), button_Classes.Control_state_1_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.TextAlign = ContentAlignment_1(button_Classes.Control_state_1_aligning.Trim());//设置对齐方式
                        button_Reform.BaseColor = Color.FromName(button_Classes.colour_1.Trim());//设置样式
                        button_Reform.DownBaseColor = Color.FromName(button_Classes.colour_1.Trim());//设置样式
                        break;
                }
                //});
            }
            catch { return; }
        }
        /// <summary>
        /// 定时器事件--刷新切换开关类控件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_Switch(object send, EventArgs e)//定时器事件--刷新切换开关类控件
        {
            if (read_status != false) { Switch_EF_ok = false; return; }//窗口不允许读取
            if (this.Switch_read_status != false || Switch_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历this.TextBox_read_status != false || 
                                                                                   //先开始遍历数据库切换开关的参数
            if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            Switch_read_status = true;//指示着本类开始遍历控件
            if (Switch_EF_ok != true)
            {
                Switch_Classes.Clear();//移除所有选项
                Switch_list.Clear();//移除所有选项   
                foreach (Switch_reform list in Switch_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { Switch_EF_ok = false; this.Switch_read_status = false; return; }//窗口不允许读取
                    Switch_Classes.Add(Switch_EF.Button_Parameter_Query(list.Parent + "-" + list.Name));//遍历获取参数
                    Switch_list.Add(list);
                }
                Switch_EF_ok = true;//遍历完成
            }
            if (Switch_Classes.Count != Switch_list.Count) { Switch_EF_ok = false; this.Switch_read_status = false; return; }//窗口不允许读取
                                                                                                                             //开始遍历PLC-并且写入状态
            for (int i = 0; i < Switch_Classes.Count; i++)
            {
                try
                {
                    if ((Switch_list.Count - Switch_Classes.Count) < 0) { Switch_list.Clear(); Switch_Classes.Clear(); this.Switch_read_status = false; return; } //数据库读取信息与窗口不符合
                    if (read_status != false) { Switch_EF_ok = false; this.Switch_read_status = false; return; }//窗口不允许读取
                    if (Switch_Classes[i].IsNull() || Switch_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (Switch_Classes[i].ID.Trim() != Switch_list[i].Parent + "-" + Switch_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    plc(Switch_Classes[i].读写设备.Trim(), Switch_Classes[i], Switch_list[i]);//开始遍历PLC并且写入按钮状态       
                }
                catch { return; }
            }
            Switch_read_status = false;//指示窗口可以进行遍历    
        }
        /// <summary>
        /// 根据PLC类型读取--切换开关类
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="switch_Class"></param>
        /// <param name="switch_reform"></param>
        /// <returns></returns>
        private string plc(string pLC, Switch_Class switch_Class, Switch_reform switch_reform)//根据PLC类型读取--切换开关类
        {
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            List<bool> data = mitsubishi_AxActUtlType.PLC_read_M_bit(switch_Class.读写设备_地址.Trim(), switch_Class.读写设备_地址_具体地址.Trim());//读取状态
                            button_state(switch_reform, switch_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            List<bool> data = mitsubishi.PLC_read_M_bit(switch_Class.读写设备_地址.Trim(), switch_Class.读写设备_地址_具体地址.Trim());//读取状态
                            button_state(switch_reform, switch_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = Siemens.PLC_read_M_bit(switch_Class.读写设备_地址.Trim(), switch_Class.读写设备_地址_具体地址.Trim());//读取状态
                        button_state(switch_reform, switch_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = MODBUD_TCP.IPLC_interface_PLC_read_M_bit(switch_Class.读写设备_地址.Trim(), switch_Class.读写设备_地址_具体地址.Trim());//读取状态
                        button_state(switch_reform, switch_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                    }
                    break;
                case "HMI":
                    button_state(switch_reform, switch_Class, macroinstruction_data<bool>.M_Data[switch_Class.读写设备_地址_具体地址.Trim().ToInt32()] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                    break;
            }
            return "OK";
        }
        /// <summary>
        /// 填充切换开关类
        /// </summary>
        /// <param name="button_Reform"></param>
        /// <param name="button_Classes"></param>
        /// <param name="button_State"></param>
        private void button_state(Switch_reform button_Reform, Switch_Class button_Classes, Button_state button_State)//填充切换开关类
        {
            if (Form_Tick.IsHandleCreated != true) return;//判断创建是否加载完成         
            try
            {

                switch (button_State)
                {
                    case PLC选择.Button_state.Off:
                        button_Reform.Text = button_Classes.Control_state_0_content.Trim();//设置文本
                        button_Reform.BackColor = Color.FromName(button_Classes.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_0_typeface.Trim(), button_Classes.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.TextAlign = ContentAlignment_1(button_Classes.Control_state_0_aligning.Trim());//设置对齐方式
                        button_Reform.BackColor = Color.FromName("182, 182, 182");//填充背景颜色--默认
                        button_Reform.Active = false;
                        button_Reform.InActiveColor = Color.FromName(button_Classes.colour_0.Trim());//获取数据库中颜色名称进行设置
                        break;
                    case PLC选择.Button_state.ON:
                        button_Reform.Text = button_Classes.Control_state_1_content1.Trim();//设置文本
                        button_Reform.BackColor = Color.FromName(button_Classes.Control_state_1_colour.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_1_typeface.Trim(), button_Classes.Control_state_1_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.TextAlign = ContentAlignment_1(button_Classes.Control_state_1_aligning.Trim());//设置对齐方式
                        button_Reform.BackColor = Color.FromName("182, 182, 182");//填充背景颜色--默认
                        button_Reform.Active = true;
                        button_Reform.InActiveColor = Color.FromName(button_Classes.colour_1.Trim());//获取数据库中颜色名称进行设置
                        break;
                }
            }
            catch { return; }
        }
        /// <summary>
        /// 定时器事件--刷新指示灯类控件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_LedBulb(object send, EventArgs e)//定时器事件--刷新指示灯类控件
        {
            if (read_status != false) { LedBulb_EF_ok = false; return; }//窗口不允许读取
            if (this.LedBulb_read_status != false || LedBulb_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历this.TextBox_read_status != false || 
                                                                                     //先开始遍历数据库指示灯的参数
            if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            LedBulb_read_status = true;//指示着本类开始遍历控件
            if (LedBulb_EF_ok != true)
            {
                LedBulb_Classes.Clear();//移除所有选项
                LedBulb_list.Clear();//移除所有选项   
                foreach (LedBulb_reform list in LedBulb_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { LedBulb_EF_ok = false; this.LedBulb_read_status = false; return; }//窗口不允许读取
                    LedBulb_Classes.Add(LedBulb_EF.Button_Parameter_Query(list.Parent + "-" + list.Name));//遍历获取参数
                    LedBulb_list.Add(list);
                }
                LedBulb_EF_ok = true;//遍历完成
            }
            if (LedBulb_Classes.Count != LedBulb_list.Count) { LedBulb_EF_ok = false; this.LedBulb_read_status = false; return; }//窗口不允许读取
                                                                                                                                 //开始遍历PLC-并且写入状态
            for (int i = 0; i < LedBulb_Classes.Count; i++)
            {
                try
                {
                    if ((LedBulb_list.Count - LedBulb_Classes.Count) < 0) { LedBulb_list.Clear(); LedBulb_Classes.Clear(); this.LedBulb_read_status = false; return; } //数据库读取信息与窗口不符合
                    if (read_status != false) { LedBulb_EF_ok = false; this.LedBulb_read_status = false; return; }//窗口不允许读取
                    if (LedBulb_Classes[i].IsNull() || LedBulb_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (LedBulb_Classes[i].ID.Trim() != LedBulb_list[i].Parent + "-" + LedBulb_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    plc(LedBulb_Classes[i].读写设备.Trim(), LedBulb_Classes[i], LedBulb_list[i]);//开始遍历PLC并且写入按钮状态     
                }
                catch { return; }
            }
            LedBulb_read_status = false;//指示窗口可以进行遍历
        }
        /// <summary>
        /// 根据PLC类型读取--指示灯类
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="LedBulb_Class"></param>
        /// <param name="LedBulb_reform"></param>
        /// <returns></returns>
        private string plc(string pLC, LedBulb_Class LedBulb_Class, LedBulb_reform LedBulb_reform)//根据PLC类型读取--指示灯类
        {
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            List<bool> data = mitsubishi_AxActUtlType.PLC_read_M_bit(LedBulb_Class.读写设备_地址.Trim(), LedBulb_Class.读写设备_地址_具体地址.Trim());//读取状态
                            button_state(LedBulb_reform, LedBulb_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            List<bool> data = mitsubishi.PLC_read_M_bit(LedBulb_Class.读写设备_地址.Trim(), LedBulb_Class.读写设备_地址_具体地址.Trim());//读取状态
                            button_state(LedBulb_reform, LedBulb_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = Siemens.PLC_read_M_bit(LedBulb_Class.读写设备_地址.Trim(), LedBulb_Class.读写设备_地址_具体地址.Trim());//读取状态
                        button_state(LedBulb_reform, LedBulb_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = MODBUD_TCP.IPLC_interface_PLC_read_M_bit(LedBulb_Class.读写设备_地址.Trim(), LedBulb_Class.读写设备_地址_具体地址.Trim());//读取状态
                        button_state(LedBulb_reform, LedBulb_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                    }
                    break;
                case "HMI":
                    button_state(LedBulb_reform, LedBulb_Class, macroinstruction_data<bool>.M_Data[LedBulb_Class.读写设备_地址_具体地址.Trim().ToInt32()] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                    break;
            }
            return "OK";
        }
        /// <summary>
        /// 填充指示灯类
        /// </summary>
        /// <param name="button_Reform"></param>
        /// <param name="button_Classes"></param>
        /// <param name="button_State"></param>
        private void button_state(LedBulb_reform button_Reform, LedBulb_Class button_Classes, Button_state button_State)//填充指示灯类
        {
            if (Form_Tick.IsHandleCreated != true) return;//判断创建是否加载完成       
            try
            {
                switch (button_State)
                {
                    case PLC选择.Button_state.Off:
                        button_Reform.Text = button_Classes.Control_state_0_content.Trim();//设置文本
                        button_Reform.Color = Color.FromName(button_Classes.colour_0.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_0_typeface.Trim(), button_Classes.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.BackColor = Color.FromName("182, 182, 182");//填充背景颜色--默认
                        break;
                    case PLC选择.Button_state.ON:
                        button_Reform.Text = button_Classes.Control_state_1_content1.Trim();//设置文本
                        button_Reform.Color = Color.FromName(button_Classes.colour_1.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_1_typeface.Trim(), button_Classes.Control_state_1_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.BackColor = Color.FromName("182, 182, 182");//填充背景颜色--默认
                        break;
                }
            }
            catch { return; }
        }
        /// <summary>
        /// 定时器事件--刷新无图片按钮类控件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_ImageButton(object send, EventArgs e)//定时器事件--刷新无图片按钮类控件
        {
            if (read_status != false) { ImageButton_EF_ok = false; return; }//窗口不允许读取
            if (this.ImageButton_read_status != false || ImageButton_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历this.TextBox_read_status != false || 
                                                                                             //先开始遍历数据库按钮的参数
            if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            ImageButton_read_status = true;//指示着本类开始遍历控件
            if (ImageButton_EF_ok != true)
            {
                ImageButton_Classes.Clear();//移除所有选项
                ImageButton_list.Clear();//移除所有选项   
                foreach (ImageButton_reform list in ImageButton_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { ImageButton_EF_ok = false; this.ImageButton_read_status = false; return; }//窗口不允许读取
                    ImageButton_Classes.Add(ImageButton_EF.Button_Parameter_Query(list.Parent + "-" + list.Name));//遍历获取参数
                    ImageButton_list.Add(list);
                }
                ImageButton_EF_ok = true;//遍历完成
            }
            if (ImageButton_Classes.Count != ImageButton_list.Count) { ImageButton_EF_ok = false; this.ImageButton_read_status = false; return; }//窗口不允许读取
                                                                                                                                                 //开始遍历PLC-并且写入状态
            for (int i = 0; i < ImageButton_Classes.Count; i++)
            {
                try
                {
                    if ((ImageButton_list.Count - ImageButton_Classes.Count) < 0) { ImageButton_list.Clear(); ImageButton_Classes.Clear(); this.ImageButton_read_status = false; return; } //数据库读取信息与窗口不符合
                    if (read_status != false) { ImageButton_EF_ok = false; this.ImageButton_read_status = false; return; }//窗口不允许读取
                    if (ImageButton_Classes[i].IsNull() || ImageButton_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (ImageButton_Classes[i].ID.Trim() != ImageButton_list[i].Parent + "-" + ImageButton_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    plc(ImageButton_Classes[i].读写设备.Trim(), ImageButton_Classes[i], ImageButton_list[i]);//开始遍历PLC并且写入按钮状态  
                }
                catch { return; }
            }
            ImageButton_read_status = false;//指示窗口可以进行遍历        
        }
        /// <summary>
        /// 根据PLC类型读取--按钮类
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="button_Class"></param>
        /// <param name="button_Reform"></param>
        /// <returns></returns>
        private string plc(string pLC, ImageButton_Class button_Class, ImageButton_reform button_Reform)//根据PLC类型读取--按钮类
        {
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            List<bool> data = mitsubishi_AxActUtlType.PLC_read_M_bit(button_Class.读写设备_地址.Trim(), button_Class.读写设备_地址_具体地址.Trim());//读取状态
                            button_state(button_Reform, button_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            List<bool> data = mitsubishi.PLC_read_M_bit(button_Class.读写设备_地址.Trim(), button_Class.读写设备_地址_具体地址.Trim());//读取状态
                            button_state(button_Reform, button_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = Siemens.PLC_read_M_bit(button_Class.读写设备_地址.Trim(), button_Class.读写设备_地址_具体地址.Trim());//读取状态
                        button_state(button_Reform, button_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = MODBUD_TCP.IPLC_interface_PLC_read_M_bit(button_Class.读写设备_地址.Trim(), button_Class.读写设备_地址_具体地址.Trim());//读取状态
                        button_state(button_Reform, button_Class, data[0] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                    }
                    break;
                case "HMI":
                    button_state(button_Reform, button_Class, macroinstruction_data<bool>.M_Data[button_Class.读写设备_地址_具体地址.Trim().ToInt32()] == true ? PLC选择.Button_state.ON : PLC选择.Button_state.Off);//写入状态
                    break;
            }
            return "OK";
        }
        /// <summary>
        /// 填充按钮类
        /// </summary>
        /// <param name="button_Reform"></param>
        /// <param name="button_Classes"></param>
        /// <param name="button_State"></param>
        private void button_state(ImageButton_reform button_Reform, ImageButton_Class button_Classes, Button_state button_State)//填充按钮类
        {
            if (Form_Tick.IsHandleCreated != true) return;//判断创建是否加载完成      
            try
            {
                switch (button_State)
                {
                    case PLC选择.Button_state.Off:
                        button_Reform.Text = button_Classes.Control_state_0_content.Trim();//设置文本
                        button_Reform.ForeColor = Color.FromName(button_Classes.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_0_typeface.Trim(), button_Classes.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.TextAlign = ContentAlignment_1(button_Classes.Control_state_0_aligning.Trim());//设置对齐方式
                        break;
                    case PLC选择.Button_state.ON:
                        button_Reform.Text = button_Classes.Control_state_1_content1.Trim();//设置文本
                        button_Reform.ForeColor = Color.FromName(button_Classes.Control_state_1_colour.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_1_typeface.Trim(), button_Classes.Control_state_1_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.TextAlign = ContentAlignment_1(button_Classes.Control_state_1_aligning.Trim());//设置对齐方式
                        break;
                }
            }
            catch { return; }
        }
        /// <summary>
        /// 定时器事件--刷新文本输入类控件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_Textbox(object send, EventArgs e)//定时器事件--刷新文本输入类控件
        {
            if (read_status != false) { numerical_EF_ok = false; return; }//窗口不允许读取
            if (this.TextBox_read_status != false || TextBox_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历 this.Button_read_status != false || 
                                                                                     //先开始遍历数据库按钮的参数
            if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            this.TextBox_read_status = true;//指示着本类开始遍历控件
            if (numerical_EF_ok != true)
            {
                numerical_Classes.Clear();//移除所有选项 
                TextBox_list.Clear();
                foreach (SkinTextBox_reform list in TextBox_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { numerical_EF_ok = false; this.TextBox_read_status = false; return; }//窗口不允许读取
                    numerical_Classes.Add(numerical_EF.numerical_Parameter_Query(list.Parent + "- " + list.Name));//遍历获取参数
                    TextBox_list.Add(list);
                }
                numerical_EF_ok = true;//指着遍历数据库完成
            }
            //开始遍历PLC-并且写入状态
            if (TextBox_list.Count != numerical_Classes.Count) { TextBox_list.Clear(); numerical_Classes.Clear(); this.TextBox_read_status = false; numerical_EF_ok = false; return; }//数据库读取信息与窗口不符合
            for (int i = 0; i < numerical_Classes.Count; i++)
            {
                try
                {
                    if (read_status != false) { numerical_EF_ok = false; ; this.TextBox_read_status = false; return; }//窗口不允许读取
                    if (numerical_Classes[i].IsNull() || TextBox_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (numerical_Classes[i].ID.Trim() != TextBox_list[i].Parent + "- " + TextBox_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    plc(numerical_Classes[i].读写设备.Trim(), numerical_Classes[i], TextBox_list[i]);//开始遍历PLC并且写入文本状态
                }
                catch { return; }
            }
            this.TextBox_read_status = false;//指示窗口可以进行遍历
        }
        /// <summary>
        /// 根据PLC类型读取--文本输入类
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="numerical_Class"></param>
        /// <param name="skinTextBox_Reform"></param>
        /// <returns></returns>
        private string plc(string pLC, numerical_Class numerical_Class, SkinTextBox_reform skinTextBox_Reform)//根据PLC类型读取--文本输入类
        {
            //if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            string data = mitsubishi_AxActUtlType.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                            TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            string data = mitsubishi.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                            TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        string data = Siemens.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                        TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        //由于modbus_TCP读写状态不同 读输出 写输入模式 
                        string data = MODBUD_TCP.IPLC_interface_PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                        TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "HMI":
                    if (macroinstruction_data<int>.D_Data[numerical_Class.读写设备_地址_具体地址.Trim().ToInt32()].IsNull() != true)
                        skinTextBox_Reform.Text = Convert.ToString(macroinstruction_data<int>.D_Data[numerical_Class.读写设备_地址_具体地址.Trim().ToInt32()] ?? "0");//直接填充数据
                    else
                        skinTextBox_Reform.Text = "0";
                    break;
            }
            return "OK";
        }

        /// <summary>
        /// 填充文本数据
        /// </summary>
        /// <param name="skinTextBox_Reform"></param>
        /// <param name="numerical_Class"></param>
        /// <param name="Data"></param>
        private void TextBox_state(SkinTextBox_reform skinTextBox_Reform, numerical_Class numerical_Class, string Data)//填充文本数据
        {
            try
            {
                int Inde = Data.IndexOf('.');//搜索数据是否有小数点
                if (Inde > 0 || Inde >= numerical_Class.小数点以下位数.ToInt32())//判断是否有小数点
                {
                    int In = Data.Length - 1 - numerical_Class.小数点以下位数.ToInt32() - Inde;//实现原理--先获取数据长度-后减1-小数点-在减去设定数-获取小数点位置
                    for (int i = 0; i < In; i++) Data = Data.Remove(Data.Length - 1, 1); //移除掉                
                }
                else
                    Data = complement(Data, numerical_Class);//然后位数不够--自动补码
                if (numerical_Class.小数点以下位数.ToInt32() < 1) Data = Data.Replace('.', ' ');//如果用户设定没有小数点直接去除小数点
                skinTextBox_Reform.Text = Data;//直接填充数据
            }
            catch { return; }
        }

        /// <summary>
        /// 定时器事件--刷新圆形图类控件 doughnut_Chart
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_doughnut_Chart(object send, EventArgs e)//定时器事件--刷新圆形图类控件 doughnut_Chart
        {
            if (read_status != false) { doughnut_Chart_EF_ok = false; return; }//窗口不允许读取
            if (this.doughnut_Chart_read_status != false || doughnut_Chart_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历 this.Button_read_status != false || 
                                                                                                   //先开始遍历数据库按钮的参数
            if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            this.doughnut_Chart_read_status = true;//指示着本类开始遍历控件
            if (doughnut_Chart_EF_ok != true)
            {
                doughnut_Chart_Classes.Clear();//移除所有选项 
                doughnut_Chart_list.Clear();
                foreach (doughnut_Chart_reform list in doughnut_Chart_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { doughnut_Chart_EF_ok = false; this.doughnut_Chart_read_status = false; return; }//窗口不允许读取
                    doughnut_Chart_Classes.Add(doughnut_Chart_EF.doughnut_Chart_Parameter_Query(list.Parent + "- " + list.Name));//遍历获取参数
                    doughnut_Chart_list.Add(list);
                }
                doughnut_Chart_EF_ok = true;//指着遍历数据库完成
            }
            //开始遍历PLC-并且写入状态
            if (doughnut_Chart_list.Count != doughnut_Chart_Classes.Count) { doughnut_Chart_list.Clear(); doughnut_Chart_Classes.Clear(); this.doughnut_Chart_read_status = false; doughnut_Chart_EF_ok = false; return; }//数据库读取信息与窗口不符合
            for (int i = 0; i < doughnut_Chart_Classes.Count; i++)
            {
                try
                {
                    if (read_status != false) { doughnut_Chart_EF_ok = false; ; this.doughnut_Chart_read_status = false; return; }//窗口不允许读取
                    if (doughnut_Chart_Classes[i].IsNull() || doughnut_Chart_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (doughnut_Chart_Classes[i].ID.Trim() != doughnut_Chart_list[i].Parent + "- " + doughnut_Chart_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    plc(doughnut_Chart_Classes[i].读写设备.Trim(), doughnut_Chart_Classes[i], doughnut_Chart_list[i]);//开始遍历PLC并且写入文本状态
                }
                catch { return; }
            }
            this.doughnut_Chart_read_status = false;//指示窗口可以进行遍历
        }
        /// <summary>
        /// 根据PLC类型读取--圆形图类 doughnut_Chart
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="doughnut_Chart_Class"></param>
        /// <param name="doughnut_Chart_Reform"></param>
        /// <returns></returns>
        private string plc(string pLC, doughnut_Chart_Class doughnut_Chart_Class, doughnut_Chart_reform doughnut_Chart_Reform)//根据PLC类型读取--圆形图类 doughnut_Chart
        {
            List<int> doughnut_Chart_Data = new List<int>();//指示要填充的数据--作为显示
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            doughnut_Chart_Data = mitsubishi_AxActUtlType.PLC_read_D_register_bit(doughnut_Chart_Class.读写设备_地址.Trim(), doughnut_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(doughnut_Chart_Class.资料格式), doughnut_Chart_Class.通道数量.ToString());//读取PLC数值
                            TextBox_state(doughnut_Chart_Reform, doughnut_Chart_Class, doughnut_Chart_Data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            doughnut_Chart_Data = mitsubishi.PLC_read_D_register_bit(doughnut_Chart_Class.读写设备_地址.Trim(), doughnut_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(doughnut_Chart_Class.资料格式), doughnut_Chart_Class.通道数量.ToString());//读取PLC数值
                            TextBox_state(doughnut_Chart_Reform, doughnut_Chart_Class, doughnut_Chart_Data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        doughnut_Chart_Data = Siemens.PLC_read_D_register_bit(doughnut_Chart_Class.读写设备_地址.Trim(), doughnut_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(doughnut_Chart_Class.资料格式), doughnut_Chart_Class.通道数量.ToString());//读取PLC数值
                        TextBox_state(doughnut_Chart_Reform, doughnut_Chart_Class, doughnut_Chart_Data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        //由于modbus_TCP读写状态不同 读输出 写输入模式 
                        doughnut_Chart_Data = MODBUD_TCP.IPLC_interface_PLC_read_D_register_bit(doughnut_Chart_Class.读写设备_地址.Trim(), doughnut_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(doughnut_Chart_Class.资料格式), doughnut_Chart_Class.通道数量.ToString());//读取PLC数值
                        TextBox_state(doughnut_Chart_Reform, doughnut_Chart_Class, doughnut_Chart_Data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "HMI":
                    numerical_public.Index(doughnut_Chart_Class.通道数量 + 1, doughnut_Chart_Class.读写设备_地址_具体地址.Trim().ToInt32(), doughnut_Chart_Data);//获取数据
                    //获取到数据进行填充 
                    TextBox_state(doughnut_Chart_Reform, doughnut_Chart_Class, doughnut_Chart_Data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    break;
            }
            return "OK";
        }

        /// <summary>
        /// 填充文本数据 doughnut_Chart
        /// </summary>
        /// <param name="doughnut_Chart_Reform"></param>
        /// <param name="doughnut_Chart_Class"></param>
        /// <param name="Data"></param>
        private void TextBox_state(doughnut_Chart_reform doughnut_Chart_Reform, doughnut_Chart_Class doughnut_Chart_Class, List<int> doughnut_Chart_Data)//填充文本数据
        {
            try
            {
                Form_Tick.BeginInvoke((MethodInvoker)delegate//委托当前窗口处理控件UI
                {
                    doughnut_Chart_Reform.doughnut_Chart_Data_INT = doughnut_Chart_Data;//获取要填充的数据
                    doughnut_Chart_Reform.doughnut_Chart_Load();//重新刷新UI
                });
            }
            catch { return; }
        }

        /// <summary>
        /// 定时器事件--刷新柱形图类控件 histogram_Chart
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_histogram_Chart(object send, EventArgs e)//定时器事件--刷新柱形图类控件 doughnut_Chart
        {
            if (read_status != false) { histogram_Chart_EF_ok = false; return; }//窗口不允许读取
            if (this.histogram_Chart_read_status != false || histogram_Chart_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历 this.Button_read_status != false || 
                                                                                                     //先开始遍历数据库按钮的参数
            if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            this.histogram_Chart_read_status = true;//指示着本类开始遍历控件
            if (histogram_Chart_EF_ok != true)
            {
                histogram_Chart_Classes.Clear();//移除所有选项 
                histogram_Chart_list.Clear();
                foreach (histogram_Chart_reform list in histogram_Chart_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { histogram_Chart_EF_ok = false; this.histogram_Chart_read_status = false; return; }//窗口不允许读取
                    histogram_Chart_Classes.Add(histogram_Chart_EF.histogram_Chart_Parameter_Query(list.Parent + "- " + list.Name));//遍历获取参数
                    histogram_Chart_list.Add(list);
                }
                histogram_Chart_EF_ok = true;//指着遍历数据库完成
            }
            //开始遍历PLC-并且写入状态
            if (histogram_Chart_list.Count != histogram_Chart_Classes.Count) { histogram_Chart_list.Clear(); histogram_Chart_Classes.Clear(); this.histogram_Chart_read_status = false; histogram_Chart_EF_ok = false; return; }//数据库读取信息与窗口不符合
            for (int i = 0; i < histogram_Chart_Classes.Count; i++)
            {
                try
                {
                    if (read_status != false) { histogram_Chart_EF_ok = false; ; this.histogram_Chart_read_status = false; return; }//窗口不允许读取
                    if (histogram_Chart_Classes[i].IsNull() || histogram_Chart_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (histogram_Chart_Classes[i].ID.Trim() != histogram_Chart_list[i].Parent + "- " + histogram_Chart_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    plc(histogram_Chart_Classes[i].读写设备.Trim(), histogram_Chart_Classes[i], histogram_Chart_list[i]);//开始遍历PLC并且写入文本状态
                }
                catch { return; }
            }
            this.histogram_Chart_read_status = false;//指示窗口可以进行遍历
        }
        /// <summary>
        /// 根据PLC类型读取--柱形图类 histogram_Chart
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="histogram_Chart_Class"></param>
        /// <param name="histogram_Chart_Reform"></param>
        /// <returns></returns>
        private string plc(string pLC, histogram_Chart_Class histogram_Chart_Class, histogram_Chart_reform histogram_Chart_Reform)//根据PLC类型读取--柱形图类 
        {
            List<int> histogram_Chart_Data = new List<int>();//指示要填充的数据--作为显示
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            histogram_Chart_Data = mitsubishi_AxActUtlType.PLC_read_D_register_bit(histogram_Chart_Class.读写设备_地址.Trim(), histogram_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(histogram_Chart_Class.资料格式), ((histogram_Chart_Class.通道数量+1)*2).ToString());//读取PLC数值
                            TextBox_state(histogram_Chart_Reform, histogram_Chart_Class, int_to_double(histogram_Chart_Data));//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            histogram_Chart_Data = mitsubishi.PLC_read_D_register_bit(histogram_Chart_Class.读写设备_地址.Trim(), histogram_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(histogram_Chart_Class.资料格式), ((histogram_Chart_Class.通道数量 + 1) * 2).ToString());//读取PLC数值
                            TextBox_state(histogram_Chart_Reform, histogram_Chart_Class, int_to_double(histogram_Chart_Data));//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        histogram_Chart_Data = Siemens.PLC_read_D_register_bit(histogram_Chart_Class.读写设备_地址.Trim(), histogram_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(histogram_Chart_Class.资料格式), ((histogram_Chart_Class.通道数量 + 1) * 2).ToString());//读取PLC数值
                        TextBox_state(histogram_Chart_Reform, histogram_Chart_Class, int_to_double(histogram_Chart_Data));//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        //由于modbus_TCP读写状态不同 读输出 写输入模式 
                        histogram_Chart_Data = MODBUD_TCP.IPLC_interface_PLC_read_D_register_bit(histogram_Chart_Class.读写设备_地址.Trim(), histogram_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(histogram_Chart_Class.资料格式), ((histogram_Chart_Class.通道数量 + 1) * 2).ToString());//读取PLC数值
                        TextBox_state(histogram_Chart_Reform, histogram_Chart_Class, int_to_double(histogram_Chart_Data));//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "HMI":
                    numerical_public.Index((histogram_Chart_Class.通道数量+1)* 2, histogram_Chart_Class.读写设备_地址_具体地址.Trim().ToInt32(), histogram_Chart_Data);//获取数据
                    //获取到数据进行填充 
                    TextBox_state(histogram_Chart_Reform, histogram_Chart_Class, int_to_double(histogram_Chart_Data));//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    break;
            }
            return "OK";
        }

        /// <summary>
        /// 填充文本数据 doughnut_Chart
        /// </summary>
        /// <param name="histogram_Chart_Reform"></param>
        /// <param name="histogram_Chart_Class"></param>
        /// <param name="Data"></param>
        private void TextBox_state(histogram_Chart_reform histogram_Chart_Reform, histogram_Chart_Class histogram_Chart_Class, List<double> histogram_Chart_Data)//填充文本数据
        {
            try
            {
                Form_Tick.BeginInvoke((MethodInvoker)delegate//委托当前窗口处理控件UI
                {
                histogram_Chart_Reform.y = histogram_Chart_Data.ToArray();//获取要填充的数据
                histogram_Chart_Reform.histogram_Chart_refresh();//重新刷新UI
            });
            }
            catch { return; }
        }

        /// <summary>
        /// 定时器事件--刷新折线图类控件 oscillogram_Chart
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_oscillogram_Chart(object send, EventArgs e)//定时器事件--刷新折线图类控件 
        {
            if (read_status != false) { oscillogram_Chart_EF_ok = false; return; }//窗口不允许读取
            if (this.oscillogram_Chart_read_status != false || oscillogram_Chart_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历 this.Button_read_status != false || 
                                                                                                         //先开始遍历数据库按钮的参数
            if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            this.oscillogram_Chart_read_status = true;//指示着本类开始遍历控件
            if (oscillogram_Chart_EF_ok != true)
            {
                oscillogram_Chart_Classes.Clear();//移除所有选项 
                oscillogram_Chart_list.Clear();
                foreach (oscillogram_Chart_reform list in oscillogram_Chart_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { oscillogram_Chart_EF_ok = false; this.oscillogram_Chart_read_status = false; return; }//窗口不允许读取
                    oscillogram_Chart_Classes.Add(oscillogram_Chart_EF.oscillogram_Chart_Parameter_Query(list.Parent + "- " + list.Name));//遍历获取参数
                    oscillogram_Chart_list.Add(list);
                }
                oscillogram_Chart_EF_ok = true;//指着遍历数据库完成
            }
            //开始遍历PLC-并且写入状态
            if (oscillogram_Chart_list.Count != oscillogram_Chart_Classes.Count) { oscillogram_Chart_list.Clear(); oscillogram_Chart_Classes.Clear(); this.oscillogram_Chart_read_status = false; oscillogram_Chart_EF_ok = false; return; }//数据库读取信息与窗口不符合
            for (int i = 0; i < oscillogram_Chart_Classes.Count; i++)
            {
                try
                {
                    if (read_status != false) { oscillogram_Chart_EF_ok = false; ; this.oscillogram_Chart_read_status = false; return; }//窗口不允许读取
                    if (oscillogram_Chart_Classes[i].IsNull() || oscillogram_Chart_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (oscillogram_Chart_Classes[i].ID.Trim() != oscillogram_Chart_list[i].Parent + "- " + oscillogram_Chart_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    plc(oscillogram_Chart_Classes[i].读写设备.Trim(), oscillogram_Chart_Classes[i], oscillogram_Chart_list[i]);//开始遍历PLC并且写入文本状态
                }
                catch { return; }
            }
            this.oscillogram_Chart_read_status = false;//指示窗口可以进行遍历
        }
        /// <summary>
        /// 根据PLC类型读取--折线图类 oscillogram_Chart
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="oscillogram_Chart_Class"></param>
        /// <param name="oscillogram_Chart_Reform"></param>
        /// <returns></returns>
        private string plc(string pLC, oscillogram_Chart_Class oscillogram_Chart_Class, oscillogram_Chart_reform oscillogram_Chart_Reform)//根据PLC类型读取--折线图类 
        {
            List<int> oscillogram_Chart_Data = new List<int>();//指示要填充的数据--作为显示
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            oscillogram_Chart_Data = mitsubishi_AxActUtlType.PLC_read_D_register_bit(oscillogram_Chart_Class.读写设备_地址.Trim(), oscillogram_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(oscillogram_Chart_Class.资料格式), "0");//读取PLC数值
                            TextBox_state(oscillogram_Chart_Reform, oscillogram_Chart_Class, oscillogram_Chart_Data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            oscillogram_Chart_Data = mitsubishi.PLC_read_D_register_bit(oscillogram_Chart_Class.读写设备_地址.Trim(), oscillogram_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(oscillogram_Chart_Class.资料格式), "0");//读取PLC数值
                            TextBox_state(oscillogram_Chart_Reform, oscillogram_Chart_Class, oscillogram_Chart_Data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        oscillogram_Chart_Data = Siemens.PLC_read_D_register_bit(oscillogram_Chart_Class.读写设备_地址.Trim(), oscillogram_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(oscillogram_Chart_Class.资料格式), "0");//读取PLC数值
                        TextBox_state(oscillogram_Chart_Reform, oscillogram_Chart_Class,oscillogram_Chart_Data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        //由于modbus_TCP读写状态不同 读输出 写输入模式 
                        oscillogram_Chart_Data = MODBUD_TCP.IPLC_interface_PLC_read_D_register_bit(oscillogram_Chart_Class.读写设备_地址.Trim(), oscillogram_Chart_Class.读写设备_地址_具体地址.Trim(), TextBox_format(oscillogram_Chart_Class.资料格式), "0");//读取PLC数值
                        TextBox_state(oscillogram_Chart_Reform, oscillogram_Chart_Class,oscillogram_Chart_Data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "HMI":
                    numerical_public.Index(oscillogram_Chart_Class.通道数量+1, oscillogram_Chart_Class.读写设备_地址_具体地址.Trim().ToInt32(), oscillogram_Chart_Data);//获取数据
                    //获取到数据进行填充 
                    TextBox_state(oscillogram_Chart_Reform, oscillogram_Chart_Class, oscillogram_Chart_Data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    break;
            }
            return "OK";
        }

        /// <summary>
        /// 填充文本数据 oscillogram_Chart
        /// </summary>
        /// <param name="oscillogram_Chart_Reform"></param>
        /// <param name="oscillogram_Chart_Class"></param>
        /// <param name="oscillogram_Chart_Data"></param>
        private void TextBox_state(oscillogram_Chart_reform oscillogram_Chart_Reform, oscillogram_Chart_Class oscillogram_Chart_Class, List<int> oscillogram_Chart_Data)//填充文本数据
        {
            try
            {
                Form_Tick.BeginInvoke((MethodInvoker)delegate//委托当前窗口处理控件UI
                {
                    if (oscillogram_Chart_Data.Count < 1) return;
                    oscillogram_Chart_Reform.oscillogram_Data = oscillogram_Chart_Data[0];//获取要填充的数据
                    oscillogram_Chart_Reform.oscillogram_Chart_Tick();//重新刷新UI
                });
            }
            catch { return; }
        }
        /// <summary>
        /// int泛型表转换成双精度浮点数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<double> int_to_double(List<int> data)
        {
            List<double> vs = new List<double>();
            foreach (int i in data) vs.Add(Convert.ToDouble(i));
            return vs;
        }


        /// <summary>
        /// 定时器事件--刷新百分百表盘类控件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_AnalogMeter(object send, EventArgs e)//定时器事件--刷新百分百表盘类控件
        {
            if (read_status != false) { AnalogMeter_EF_ok = false; return; }//窗口不允许读取
            if (this.AnalogMeter_read_status != false || AnalogMeter_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历 this.Button_read_status != false || 
                                                                                             //先开始遍历数据库按钮的参数
            if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            this.AnalogMeter_read_status = true;//指示着本类开始遍历控件
            if (AnalogMeter_EF_ok != true)
            {
                AnalogMeter_Classes.Clear();//移除所有选项 
                AnalogMeter_list.Clear();
                foreach (AnalogMeter_reform list in AnalogMeter_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { AnalogMeter_EF_ok = false; this.AnalogMeter_read_status = false; return; }//窗口不允许读取
                    AnalogMeter_Classes.Add(AnalogMeter_EF.AnalogMeter_Parameter_Query(list.Parent + "- " + list.Name));//遍历获取参数
                    AnalogMeter_list.Add(list);
                }
                AnalogMeter_EF_ok = true;//指着遍历数据库完成
            }
            //开始遍历PLC-并且写入状态
            if (AnalogMeter_list.Count != AnalogMeter_Classes.Count) { AnalogMeter_list.Clear(); AnalogMeter_Classes.Clear(); this.AnalogMeter_read_status = false; AnalogMeter_EF_ok = false; return; }//数据库读取信息与窗口不符合
            for (int i = 0; i < AnalogMeter_Classes.Count; i++)
            {
                try
                {
                    if (read_status != false) { AnalogMeter_EF_ok = false; ; this.AnalogMeter_read_status = false; return; }//窗口不允许读取
                    if (AnalogMeter_Classes[i].IsNull() || AnalogMeter_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (AnalogMeter_Classes[i].ID.Trim() != AnalogMeter_list[i].Parent + "- " + AnalogMeter_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    plc(AnalogMeter_Classes[i].读写设备.Trim(), AnalogMeter_Classes[i], AnalogMeter_list[i]);//开始遍历PLC并且写入文本状态
                }
                catch { return; }
            }
            this.AnalogMeter_read_status = false;//指示窗口可以进行遍历
        }
        /// <summary>
        /// 根据PLC类型读取--百分百表盘类
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="numerical_Class"></param>
        /// <param name="skinTextBox_Reform"></param>
        /// <returns></returns>
        private string plc(string pLC, AnalogMeter_Class numerical_Class, AnalogMeter_reform skinTextBox_Reform)//根据PLC类型读取--百分百表盘类
        {
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            string data = mitsubishi_AxActUtlType.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                            TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            string data = mitsubishi.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                            TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        string data = Siemens.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                        TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        //由于modbus_TCP读写状态不同 读输出 写输入模式 
                        string data = MODBUD_TCP.IPLC_interface_PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                        TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "HMI":
                    if (macroinstruction_data<int>.D_Data[numerical_Class.读写设备_地址_具体地址.Trim().ToInt32()].IsNull() != true)
                        skinTextBox_Reform.Text = Convert.ToString(macroinstruction_data<int>.D_Data[numerical_Class.读写设备_地址_具体地址.Trim().ToInt32()] ?? "0");//直接填充数据
                    else
                        skinTextBox_Reform.Text = "0";
                    break;
            }
            return "OK";
        }

        /// <summary>
        /// 填充文本数据
        /// </summary>
        /// <param name=" AnalogMeter_Reform"></param>
        /// <param name=" AnalogMeter_Class"></param>
        /// <param name="Data"></param>
        private void TextBox_state(AnalogMeter_reform AnalogMeter_Reform, AnalogMeter_Class numerical_Class, string Data)//填充文本数据
        {
            try
            {
                int Inde = Data.IndexOf('.');//搜索数据是否有小数点
                if (Inde > 0 || Inde >= numerical_Class.小数点以下位数.ToInt32())//判断是否有小数点
                {
                    int In = Data.Length - 1 - numerical_Class.小数点以下位数.ToInt32() - Inde;//实现原理--先获取数据长度-后减1-小数点-在减去设定数-获取小数点位置
                    for (int i = 0; i < In; i++) Data = Data.Remove(Data.Length - 1, 1); //移除掉                
                }
                else
                    Data = complement(Data, numerical_Class);//然后位数不够--自动补码
                if (numerical_Class.小数点以下位数.ToInt32() < 1) Data = Data.Replace('.', ' ');//如果用户设定没有小数点直接去除小数点
                AnalogMeter_Reform.Value = Data.ToInt32();//直接填充数据
            }
            catch { return; }
        }

        /// <summary>
        /// 定时器事件--刷新数值显示类控件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_LedDisplay(object send, EventArgs e)//定时器事件--刷新数值显示类控件
        {
            if (read_status != false) { LedDisplay_EF_ok = false; return; }//窗口不允许读取
            if (this.LedDisplay_read_status != false || LedDisplay_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历 this.Button_read_status != false || 
                                                                                           //先开始遍历数据库按钮的参数
            if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            this.LedDisplay_read_status = true;//指示着本类开始遍历控件
            if (LedDisplay_EF_ok != true)
            {
                LedDisplay_Classes.Clear();//移除所有选项 
                LedDisplay_list.Clear();
                foreach (LedDisplay_reform list in LedDisplay_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { LedDisplay_EF_ok = false; this.LedDisplay_read_status = false; return; }//窗口不允许读取
                    LedDisplay_Classes.Add(LedDisplay_EF.LedDisplay_Parameter_Query(list.Parent + "- " + list.Name));//遍历获取参数
                    LedDisplay_list.Add(list);
                }
                LedDisplay_EF_ok = true;//指着遍历数据库完成
            }
            //开始遍历PLC-并且写入状态
            if (LedDisplay_list.Count != LedDisplay_Classes.Count) { LedDisplay_list.Clear(); LedDisplay_Classes.Clear(); this.LedDisplay_read_status = false; LedDisplay_EF_ok = false; return; }//数据库读取信息与窗口不符合
            for (int i = 0; i < LedDisplay_Classes.Count; i++)
            {
                try
                {
                    if (read_status != false) { LedDisplay_EF_ok = false; ; this.LedDisplay_read_status = false; return; }//窗口不允许读取
                    if (LedDisplay_Classes[i].IsNull() || LedDisplay_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (LedDisplay_Classes[i].ID.Trim() != LedDisplay_list[i].Parent + "- " + LedDisplay_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    plc(LedDisplay_Classes[i].读写设备.Trim(), LedDisplay_Classes[i], LedDisplay_list[i]);//开始遍历PLC并且写入文本状态
                }
                catch { return; }
            }
            this.LedDisplay_read_status = false;//指示窗口可以进行遍历
        }
        /// <summary>
        /// 根据PLC类型读取--百分百表盘类
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="numerical_Class"></param>
        /// <param name="skinTextBox_Reform"></param>
        /// <returns></returns>
        private string plc(string pLC, LedDisplay_Class numerical_Class, LedDisplay_reform skinTextBox_Reform)//根据PLC类型读取--百分百表盘类
        {
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            string data = mitsubishi_AxActUtlType.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                            TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            string data = mitsubishi.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                            TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        string data = Siemens.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                        TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        //由于modbus_TCP读写状态不同 读输出 写输入模式 
                        string data = MODBUD_TCP.IPLC_interface_PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                        TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "HMI":
                    if (macroinstruction_data<int>.D_Data[numerical_Class.读写设备_地址_具体地址.Trim().ToInt32()].IsNull() != true)
                        skinTextBox_Reform.Text = Convert.ToString(macroinstruction_data<int>.D_Data[numerical_Class.读写设备_地址_具体地址.Trim().ToInt32()] ?? "0");//直接填充数据
                    else
                        skinTextBox_Reform.Text = "0";
                    break;
            }
            return "OK";
        }

        /// <summary>
        /// 填充文本数据
        /// </summary>
        /// <param name=" AnalogMeter_Reform"></param>
        /// <param name=" AnalogMeter_Class"></param>
        /// <param name="Data"></param>
        private void TextBox_state(LedDisplay_reform AnalogMeter_Reform, LedDisplay_Class numerical_Class, string Data)//填充文本数据
        {
            try
            { 
            int Inde = Data.IndexOf('.');//搜索数据是否有小数点
            if (Inde > 0 || Inde >= numerical_Class.小数点以下位数.ToInt32())//判断是否有小数点
            {
                int In = Data.Length - 1 - numerical_Class.小数点以下位数.ToInt32() - Inde;//实现原理--先获取数据长度-后减1-小数点-在减去设定数-获取小数点位置
                for (int i = 0; i < In; i++) Data = Data.Remove(Data.Length - 1, 1); //移除掉                
            }
            else
                Data = complement(Data, numerical_Class);//然后位数不够--自动补码
            if (numerical_Class.小数点以下位数.ToInt32() < 1) Data = Data.Replace('.', ' ');//如果用户设定没有小数点直接去除小数点
            AnalogMeter_Reform.Text = Data;//直接填充数据
            }
            catch { return; }
        }

        /// <summary>
        /// 定时器事件--刷新二维码/条形码类控件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_Tick_ihatetheqrcode(object send, EventArgs e)//定时器事件--刷新百分百表盘类控件
        {
            if (read_status != false) { ihatetheqrcode_EF_ok = false; return; }//窗口不允许读取
            if (this.ihatetheqrcode_read_status != false || ihatetheqrcode_list_1.IsNull()) return;//直接返回方法--指示当前控件正在遍历 this.Button_read_status != false || 
                                                                                                   //先开始遍历数据库按钮的参数
            if (Form_Tick.IsDisposed) return;//表示用户已经关闭窗口
            this.ihatetheqrcode_read_status = true;//指示着本类开始遍历控件
            if (ihatetheqrcode_EF_ok != true)
            {
                ihatetheqrcode_Classes.Clear();//移除所有选项 
                ihatetheqrcode_list.Clear();
                foreach (ihatetheqrcode_reform list in ihatetheqrcode_list_1)//遍历按钮类--获取数据库中的参数
                {
                    if (read_status != false) { ihatetheqrcode_EF_ok = false; this.ihatetheqrcode_read_status = false; return; }//窗口不允许读取
                    ihatetheqrcode_Classes.Add(ihatetheqrcode_EF.ihatetheqrcode_Parameter_Query(list.Parent + "- " + list.Name));//遍历获取参数
                    ihatetheqrcode_list.Add(list);
                }
                ihatetheqrcode_EF_ok = true;//指着遍历数据库完成
            }
            //开始遍历PLC-并且写入状态
            if (ihatetheqrcode_list.Count != ihatetheqrcode_Classes.Count) { ihatetheqrcode_list.Clear(); ihatetheqrcode_Classes.Clear(); this.ihatetheqrcode_read_status = false; ihatetheqrcode_EF_ok = false; return; }//数据库读取信息与窗口不符合
            for (int i = 0; i < ihatetheqrcode_Classes.Count; i++)
            {
                try
                {
                    if (read_status != false) { ihatetheqrcode_EF_ok = false; ; this.ihatetheqrcode_read_status = false; return; }//窗口不允许读取
                    if (ihatetheqrcode_Classes[i].IsNull() || ihatetheqrcode_list[i].IsNull()) continue;//跳出循环进入下一次
                    if (ihatetheqrcode_Classes[i].ID.Trim() != ihatetheqrcode_list[i].Parent + "- " + ihatetheqrcode_list[i].Name) continue;//如果ID不对直接开启下次遍历
                    plc(ihatetheqrcode_Classes[i].读写设备.Trim(), ihatetheqrcode_Classes[i], ihatetheqrcode_list[i]);//开始遍历PLC并且写入文本状态
                }
                catch { return; }
            }
            this.ihatetheqrcode_read_status = false;//指示窗口可以进行遍历
        }
        /// <summary>
        /// 根据PLC类型读取--二维码/条形码类
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="numerical_Class"></param>
        /// <param name="skinTextBox_Reform"></param>
        /// <returns></returns>
        private string plc(string pLC, ihatetheqrcode_Class numerical_Class, ihatetheqrcode_reform skinTextBox_Reform)//根据PLC类型读取--百分百表盘类
        {
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            string data = mitsubishi_AxActUtlType.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                            TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            string data = mitsubishi.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                            TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        string data = Siemens.PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                        TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        //由于modbus_TCP读写状态不同 读输出 写输入模式 
                        string data = MODBUD_TCP.IPLC_interface_PLC_read_D_register(numerical_Class.读写设备_地址.Trim(), numerical_Class.读写设备_地址_具体地址.Trim(), TextBox_format(numerical_Class.资料格式));//读取PLC数值
                        TextBox_state(skinTextBox_Reform, numerical_Class, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case "HMI":
                    if (macroinstruction_data<int>.D_Data[numerical_Class.读写设备_地址_具体地址.Trim().ToInt32()].IsNull() != true)
                        skinTextBox_Reform.Text = Convert.ToString(macroinstruction_data<int>.D_Data[numerical_Class.读写设备_地址_具体地址.Trim().ToInt32()] ?? "0");//直接填充数据
                    else
                        skinTextBox_Reform.Text = "0";
                    break;
            }
            return "OK";
        }

        /// <summary>
        /// 填充二维码/条形码数据
        /// </summary>
        /// <param name=" AnalogMeter_Reform"></param>
        /// <param name=" AnalogMeter_Class"></param>
        /// <param name="Data"></param>
        private void TextBox_state(ihatetheqrcode_reform ihatetheqrcode_Reform, ihatetheqrcode_Class numerical_Class, string Data)//填充文本数据
        {
            try
            { 
            int Inde = Data.IndexOf('.');//搜索数据是否有小数点
            if (Inde > 0 || Inde >= numerical_Class.小数点以下位数.ToInt32())//判断是否有小数点
            {
                int In = Data.Length - 1 - numerical_Class.小数点以下位数.ToInt32() - Inde;//实现原理--先获取数据长度-后减1-小数点-在减去设定数-获取小数点位置
                for (int i = 0; i < In; i++) Data = Data.Remove(Data.Length - 1, 1); //移除掉                
            }
            else
                Data = complement(Data, numerical_Class);//然后位数不够--自动补码
            if (numerical_Class.小数点以下位数.ToInt32() < 1) Data = Data.Replace('.', ' ');//如果用户设定没有小数点直接去除小数点
            Form_Tick.BeginInvoke((MethodInvoker)delegate//委托当前窗口处理控件UI
            {
                ihatetheqrcode_Reform.Data = Data;//直接填充数据
                ihatetheqrcode_Reform.Refresh_Data();//刷新数据
            });
            }
            catch { return; }
        }


        /// <summary>
        ///  下面都是-祖传代码---懒得重新写成类----凑数
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private numerical_format TextBox_format(string Name)//索引控件的资料格式
        {
            foreach (numerical_format suit in Enum.GetValues(typeof(numerical_format)))
            {
                if (suit.ToString()==Name.Trim()) return suit;//找到资料格式并返回
            }
            return numerical_format.Signed_32_Bit;//找不到直接返回默认资料格式
        }
        /// <summary>
        /// 获取字体的对齐方式--按钮-文本类
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private System.Drawing.ContentAlignment ContentAlignment_1(string Name)//获取字体的对齐方式--按钮-文本类
        {
            System.Drawing.ContentAlignment contentAlignment = System.Drawing.ContentAlignment.MiddleCenter;//定义对齐方式
            switch (Name.Trim())
            {
                case "左对齐":
                    contentAlignment = System.Drawing.ContentAlignment.MiddleLeft;//设置左对齐
                    break;
                case "居中对齐":
                    contentAlignment = System.Drawing.ContentAlignment.MiddleCenter;//设置居中对齐
                    break;
                case "右对齐":
                    contentAlignment = System.Drawing.ContentAlignment.MiddleRight;//设置有右对齐
                    break;
            }
            return contentAlignment;//返回数据
        }
        /// <summary>
        /// 实现浮点小数自动补码
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="numerical_Class"></param>
        /// <returns></returns>
        private string complement(string Name,numerical_Class numerical_Class)//实现浮点小数自动补码
        {
            int Inde = Name.IndexOf('.');//搜索数据是否有小数点
            if (Inde < 0 & numerical_Class.小数点以下位数.ToInt32() != 0) Name += ".";//自动补码小数点
            if (numerical_Class.小数点以下位数.ToInt32() > 0 & Inde < 0)
            {
                for (int i = 0; i < numerical_Class.小数点以下位数.ToInt32(); i++) Name += "0";//填充数据
            }
            if (numerical_Class.小数点以下位数.ToInt32() > 0 & Inde > 0)
            {
                int In = Name.Length - 1 - Inde;
                for (int i = 0; i < numerical_Class.小数点以下位数.ToInt32() - In; i++) Name += "0";//填充数据
            }
            return Name;//返回数据
        }
        /// <summary>
        /// 实现浮点小数自动补码
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="AnalogMeter_Class"></param>
        /// <returns></returns>
        private string complement(string Name, AnalogMeter_Class numerical_Class)//实现浮点小数自动补码
        {
            int Inde = Name.IndexOf('.');//搜索数据是否有小数点
            if (Inde < 0 & numerical_Class.小数点以下位数.ToInt32() != 0) Name += ".";//自动补码小数点
            if (numerical_Class.小数点以下位数.ToInt32() > 0 & Inde < 0)
            {
                for (int i = 0; i < numerical_Class.小数点以下位数.ToInt32(); i++) Name += "0";//填充数据
            }
            if (numerical_Class.小数点以下位数.ToInt32() > 0 & Inde > 0)
            {
                int In = Name.Length - 1 - Inde;
                for (int i = 0; i < numerical_Class.小数点以下位数.ToInt32() - In; i++) Name += "0";//填充数据
            }
            return Name;//返回数据
        }
        /// <summary>
        /// 实现浮点小数自动补码 doughnut_Chart
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="doughnut_Chart_Class"></param>
        /// <returns></returns>
        private string complement(string Name, doughnut_Chart_Class doughnut_Chart_Class)//实现浮点小数自动补码
        {
            int Inde = Name.IndexOf('.');//搜索数据是否有小数点
            if (Inde < 0 & doughnut_Chart_Class.小数点以下位数.ToInt32() != 0) Name += ".";//自动补码小数点
            if (doughnut_Chart_Class.小数点以下位数.ToInt32() > 0 & Inde < 0)
            {
                for (int i = 0; i < doughnut_Chart_Class.小数点以下位数.ToInt32(); i++) Name += "0";//填充数据
            }
            if (doughnut_Chart_Class.小数点以下位数.ToInt32() > 0 & Inde > 0)
            {
                int In = Name.Length - 1 - Inde;
                for (int i = 0; i < doughnut_Chart_Class.小数点以下位数.ToInt32() - In; i++) Name += "0";//填充数据
            }
            return Name;//返回数据
        }
        /// <summary>
        /// 实现浮点小数自动补码 doughnut_Chart
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="LedDisplay_Class"></param>
        /// <returns></returns>
        private string complement(string Name, LedDisplay_Class doughnut_Chart_Class)//实现浮点小数自动补码
        {
            int Inde = Name.IndexOf('.');//搜索数据是否有小数点
            if (Inde < 0 & doughnut_Chart_Class.小数点以下位数.ToInt32() != 0) Name += ".";//自动补码小数点
            if (doughnut_Chart_Class.小数点以下位数.ToInt32() > 0 & Inde < 0)
            {
                for (int i = 0; i < doughnut_Chart_Class.小数点以下位数.ToInt32(); i++) Name += "0";//填充数据
            }
            if (doughnut_Chart_Class.小数点以下位数.ToInt32() > 0 & Inde > 0)
            {
                int In = Name.Length - 1 - Inde;
                for (int i = 0; i < doughnut_Chart_Class.小数点以下位数.ToInt32() - In; i++) Name += "0";//填充数据
            }
            return Name;//返回数据
        }
        /// <summary>
        /// 实现浮点小数自动补码 条形码
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="LedDisplay_Class"></param>
        /// <returns></returns>
        private string complement(string Name, ihatetheqrcode_Class doughnut_Chart_Class)//实现浮点小数自动补码
        {
            int Inde = Name.IndexOf('.');//搜索数据是否有小数点
            if (Inde < 0 & doughnut_Chart_Class.小数点以下位数.ToInt32() != 0) Name += ".";//自动补码小数点
            if (doughnut_Chart_Class.小数点以下位数.ToInt32() > 0 & Inde < 0)
            {
                for (int i = 0; i < doughnut_Chart_Class.小数点以下位数.ToInt32(); i++) Name += "0";//填充数据
            }
            if (doughnut_Chart_Class.小数点以下位数.ToInt32() > 0 & Inde > 0)
            {
                int In = Name.Length - 1 - Inde;
                for (int i = 0; i < doughnut_Chart_Class.小数点以下位数.ToInt32() - In; i++) Name += "0";//填充数据
            }
            return Name;//返回数据
        }
        /// <summary>
        /// 获取字体的对齐方式--文本输入类
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private System.Windows.Forms.HorizontalAlignment HorizontalAlignment_1(string Name)//获取字体的对齐方式--文本输入类
        {
            System.Windows.Forms.HorizontalAlignment horizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;//定义对齐方式
            switch (Name.Trim())
            {
                case "左对齐":
                    horizontalAlignment = System.Windows.Forms.HorizontalAlignment.Left;//设置左对齐
                    break;
                case "居中对齐":
                    horizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;//设置居中对齐
                    break;
                case "右对齐":
                    horizontalAlignment = System.Windows.Forms.HorizontalAlignment.Right;//设置有右对齐
                    break;
            }
            return horizontalAlignment;//返回数据
        }
        /// <summary>
        /// 分割-来自数据库的-位置与大小数据
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private int[] point_or_Size(string Name)//分割-来自数据库的-位置与大小数据
        {
            string[] segmentation;//定义分割数组
            segmentation = Name.Split('-');
            return new int[] { Convert.ToInt32(segmentation[0] ?? "81"), Convert.ToInt32(segmentation[1] ?? "31") };
        }
        ~Time_reform()//析构函数
        {
            this.Tick -= Time_Tick_button;//注册按钮类刷新事件
            this.Tick -= Time_Tick_Textbox;//注册文本输入类刷新事件
            this.Tick -= Time_Tick_Switch;//注册切换开关类刷新事件
            this.Tick -= Time_Tick_LedBulb;//注册指示灯类刷新事件
            this.Tick -= Time_Tick_ImageButton;//注册无图片按钮类刷新事件
            this.Tick -= Time_Tick_doughnut_Chart;//注册圆形图刷新事件
            this.Tick -= Time_Tick_histogram_Chart;//注册柱形图事件
            this.Tick -= Time_Tick_oscillogram_Chart;//注册柱形图事件
            this.Tick -= Time_Tick_AnalogMeter;//注册百分百表盘事件
            this.Tick -= Time_Tick_LedDisplay;//注册数值显示事件
            this.Tick -= Time_Tick_ihatetheqrcode;//注册二维码/条形码事件
            this.Dispose();
        }
    }
}
