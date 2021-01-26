using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using CCWin.SkinControl;
using HslCommunicationDemo;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.修改参数界面.doughnut_Chart图形控件参数;
using 自定义Uppercomputer_20200727.修改参数界面.GroupBox四边形方框;
using 自定义Uppercomputer_20200727.修改参数界面.histogram_Chart柱形图控件参数;
using 自定义Uppercomputer_20200727.修改参数界面.ImageButton按钮参数;
using 自定义Uppercomputer_20200727.修改参数界面.LedBulb_指示灯参数;
using 自定义Uppercomputer_20200727.修改参数界面.oscillogram_Chart折线图波形图参数;
using 自定义Uppercomputer_20200727.修改参数界面.报警条参数;
using 自定义Uppercomputer_20200727.参数设置画面;
using 自定义Uppercomputer_20200727.异常界面;
using 自定义Uppercomputer_20200727.手动控制页面;
using 自定义Uppercomputer_20200727.控件重做;
using 自定义Uppercomputer_20200727.控制主页面;
using 自定义Uppercomputer_20200727.控制主页面模板;
using 自定义Uppercomputer_20200727.生产设置画面;
using 自定义Uppercomputer_20200727.监视画面;
using 自定义Uppercomputer_20200727.运转控制画面;
using 自定义Uppercomputer_20200727.宏指令实现与对接;
using CSEngineTest;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using 自定义Uppercomputer_20200727.修改参数界面.LedDisplay数值显示参数;
using 自定义Uppercomputer_20200727.修改参数界面.AnalogMeter百分百表盘参数;
using 自定义Uppercomputer_20200727.修改参数界面.ihatetheqrcode二维码与条形码控件参数;
using 自定义Uppercomputer_20200727.修改参数界面.function_key功能键参数;
using 自定义Uppercomputer_20200727.修改参数界面.RadioButton单选按钮参数;
using 自定义Uppercomputer_20200727.软件说明;
using 自定义Uppercomputer_20200727.修改参数界面.HScrollBar移动图形参数;
using HZH_Controls.Controls;
using 自定义Uppercomputer_20200727.控制主页面模板.工业图形ADD;
using 自定义Uppercomputer_20200727.控件重做.工业图形控件;
using 自定义Uppercomputer_20200727.修改参数界面.工业图形汇总;

namespace 自定义Uppercomputer_20200727
{
    public partial class Form2 : CCWin.Skin_Mac
    {
        /// <该页面是模板通用页面->
        Time_reform time_Reform;//读取PLC与修改控件--定时器
                                //1.声明自适应类实例
        AutoSizeFormClass asc = new AutoSizeFormClass();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            time_Reform = new Time_reform(this);//实例化读取定时器--开启读取PLC
            ////开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.ResizeRedraw
                 | ControlStyles.Selectable
                 | ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.UserPaint
                 | ControlStyles.SupportsTransparentBackColor,
               true);

        }
        private void skinButton1_Click(object sender, EventArgs e)//公用页面处理
        {
            SkinButton skinButton = (SkinButton)sender;
            if (skinButton.Text == this.skinLabel1.Text) return;
            string Data = this.skinLabel1.Text;
            using (Windowclass windowclass = new Windowclass(this, new SkinButton[] { this.skinButton1, this.skinButton2, this.skinButton3,
                this.skinButton4, this.skinButton5, this.skinButton6,this.skinButton7}, new Form[] {new Form3(), new Form4(),new Form5()
                , new Form6(),new Form7(), new 生产设置画面.Form8(), new 参数设置画面.Form9()}, this.skinLabel1, skinButton))
            {
            }
        }
        private void skinContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        int X = 0, Y = 0;//窗口与鼠标的相对位置

        private void buttton按钮ToolStripMenuItem_Click(object sender, EventArgs e)//添加按钮
        {
            Button_Add button = new Button_Add();
            Button_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层     
            Modification_Button modification_Button = new Modification_Button(skinButton.Parent.ToString(), skinButton);
            modification_Button.ShowDialog();
            if (modification_Button.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }

        private void label文本ToolStripMenuItem_Click(object sender, EventArgs e)//添加系统文本
        {
            Skinlabel_Add skinlabel = new Skinlabel_Add();
            SkinLabel skinLabel = skinlabel.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinLabel);
            skinLabel.BringToFront();//将控件放置所有控件最顶层     
            Modification_label modification_Label = new Modification_label(skinLabel.Parent.ToString(), skinLabel);
            modification_Label.ShowDialog();
            if (modification_Label.Add_to_allow == false) this.Controls.Remove(skinLabel);//不允许添加异常对象
        }

        private void texebox数值ToolStripMenuItem_Click(object sender, EventArgs e)//添加系统输入文本
        {
            SkinTextBox_Add skinTextBox = new SkinTextBox_Add();
            TextBox skinTextBox1 = skinTextBox.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinTextBox1);
            skinTextBox1.BringToFront();//将控件放置所有控件最顶层   
            Modification_numerical modification_Numerical = new Modification_numerical(skinTextBox1.Parent.ToString(), skinTextBox1);
            modification_Numerical.ShowDialog();
            skinTextBox1.Text = "00";
            if (modification_Numerical.Add_to_allow == false) this.Controls.Remove(skinTextBox1);//不允许添加异常对象
        }

        private void lmage图片ToolStripMenuItem_Click(object sender, EventArgs e)//添加系统图片
        {
            SkinPictureBox_Add skinPicture = new SkinPictureBox_Add();
            SkinPictureBox skinPictureBox = skinPicture.Add(this.Controls, new Point(X, Y), this.imageList1.Images[0]);
            this.Controls.Add(skinPictureBox);
            skinPictureBox.BringToFront();//将控件放置所有控件最顶层   
            Modification_picture modification_Picture = new Modification_picture(skinPictureBox.Parent.ToString(), skinPictureBox);
            modification_Picture.ShowDialog();
            skinPictureBox.Image = modification_Picture.Image;
            if (modification_Picture.Add_to_allow == false) this.Controls.Remove(skinPictureBox);//不允许添加异常对象
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)//添加切换开关
        {
            Switch_Add button = new Switch_Add();
            Switch_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_Switch modification_Button = new Modification_Switch(skinButton.Parent.ToString(), skinButton);
            modification_Button.ShowDialog();
            if (modification_Button.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem13_Click(object sender, EventArgs e)//添加指示灯
        {
            LedBulb_Add button = new LedBulb_Add();
            LedBulb_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_Ledbulb modification_Button = new Modification_Ledbulb(skinButton.Parent.ToString(), skinButton);
            modification_Button.ShowDialog();
            if (modification_Button.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)//添加四边形方框
        {
            GroupBox_Add GroupBox = new GroupBox_Add();
            GroupBox_reform GroupBoxl = GroupBox.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(GroupBoxl);
            GroupBoxl.SendToBack();//将控件放置所有控件最底层
            Modification_GroupBox modification_GroupBox = new Modification_GroupBox(GroupBoxl.Parent.ToString(), GroupBoxl);
            modification_GroupBox.ShowDialog();
            if (modification_GroupBox.Add_to_allow == false) this.Controls.Remove(GroupBoxl);//不允许添加异常对象
        }
        private void toolStripMenuItem12_Click(object sender, EventArgs e)//添加无图片按钮类三
        {
            ImageButton_Add button = new ImageButton_Add();
            ImageButton_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_ImageButton modification_ImageButton = new Modification_ImageButton(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)//添加报警条
        {
            ScrollingText_Add button = new ScrollingText_Add(this);
            ScrollingText_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_ScrollingText modification_ImageButton = new Modification_ScrollingText(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem11_Click(object sender, EventArgs e)//添加圆形图
        {
            doughnut_Chart_Add button = new doughnut_Chart_Add();
            doughnut_Chart_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_doughnut_Chart modification_ImageButton = new Modification_doughnut_Chart(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem10_Click(object sender, EventArgs e)//柱形图
        {
            histogram_Chart_Add button = new histogram_Chart_Add();
            histogram_Chart_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_histogram_Chart modification_ImageButton = new Modification_histogram_Chart(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem14_Click(object sender, EventArgs e)//波形图
        {
            oscillogram_Chart_Add button = new oscillogram_Chart_Add();
            oscillogram_Chart_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_oscillogram_Chart modification_ImageButton = new Modification_oscillogram_Chart(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem17_Click(object sender, EventArgs e)//数值显示
        {
            LedDisplay_Add button = new LedDisplay_Add();
            LedDisplay_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_LedDisplay modification_ImageButton = new Modification_LedDisplay(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem18_Click(object sender, EventArgs e)//百分百表盘
        {
            AnalogMeter_Add button = new AnalogMeter_Add();
            AnalogMeter_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_AnalogMeter modification_ImageButton = new Modification_AnalogMeter(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem19_Click(object sender, EventArgs e)//添加二维码/条形码
        {
            ihatetheqrcode_Add button = new ihatetheqrcode_Add();
            ihatetheqrcode_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_ihatetheqrcode modification_ihatetheqrcode = new Modification_ihatetheqrcode(skinButton.Parent.ToString(), skinButton);
            modification_ihatetheqrcode.ShowDialog();
            if (modification_ihatetheqrcode.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem20_Click(object sender, EventArgs e)//添加画面切换
        {
            function_key_Add button = new function_key_Add();
            function_key_reform skinButton = button.Add(this.Name, this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_function_key modification_function_key = new Modification_function_key(skinButton.Parent.ToString(), skinButton);
            modification_function_key.ShowDialog();
            if (modification_function_key.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem22_Click(object sender, EventArgs e)//添加单选按钮
        {
            RadioButton_Add button = new RadioButton_Add();
            RadioButton_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_RadioButton modification_RadioButton = new Modification_RadioButton(skinButton.Parent.ToString(), skinButton);
            modification_RadioButton.ShowDialog();
            if (modification_RadioButton.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem21_Click(object sender, EventArgs e)//添加下拉菜单
        {
            pull_down_menu_Add button = new pull_down_menu_Add();
            pull_down_menu_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_pull_down_menu modification_pull_down_menu = new Modification_pull_down_menu(skinButton.Parent.ToString(), skinButton);
            modification_pull_down_menu.ShowDialog();
            if (modification_pull_down_menu.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem23_Click(object sender, EventArgs e)//添加纵向移动图形
        {
            HScrollBar_Add button = new HScrollBar_Add();
            HScrollBar_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_HScrollBar modification_HScrollBar = new Modification_HScrollBar(skinButton.Parent.ToString(), skinButton);
            modification_HScrollBar.ShowDialog();
            if (modification_HScrollBar.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem25_Click(object sender, EventArgs e)//添加Conveyor运输带
        {
            Conveyor_Add button = new Conveyor_Add();
            Conveyor_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_Conveyor modification_Conveyor = new Modification_Conveyor(skinButton.Parent.ToString(), skinButton);
            modification_Conveyor.ShowDialog();
            if (modification_Conveyor.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void toolStripMenuItem26_Click(object sender, EventArgs e)//添加Valve流体阀门
        {
            Valve_Add button = new Valve_Add();
            Valve_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_Valve modification_Valve = new Modification_Valve(skinButton.Parent.ToString(), skinButton);
            modification_Valve.ShowDialog();
            if (modification_Valve.Add_to_allow == false) this.Controls.Remove(skinButton);//不允许添加异常对象
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            X = e.X; Y = e.Y;//获取屏幕位置
        }
        #region 窗体关闭效果
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果
        #endregion

        private void Form2_Load(object sender, EventArgs e)//加载窗口
        {
            this.BeginInvoke((EventHandler)delegate
            {
                UI_Schedule("开始加载控件", 30, true);
                var se = Task.Run(() =>
                  {
                      using (From_Load_Add load_Add = new From_Load_Add(this.Name, this.Controls, new List<ImageList>() { this.imageList1, this.imageList2, this.imageList3 }, this)) ;//添加报警条
                      using (From_Load_Add add = new From_Load_Add(this.Name, this.Controls, new List<ImageList>() { this.imageList1, this.imageList2, this.imageList3 }, this, true)) ;//添加普通文本
                      UI_Schedule("开始正在显示UI", 90, true);
                  });            
                se.Wait();
                this.timer3.Start();
                timer3.Interval = 10;
                time_Reform.Form = this.Name;//获取当前窗口名称
                time_Reform.Interval = 100;//遍历控件时间
                time_Reform.Start();//运行定时器
                asc.RenewControlRect(this);
                //传递PLC参数到宏指令
                if (!CSEngineTest.PLC.Mitsubishi_axActUtlType.IsNull()) return;
                CSEngineTest.PLC.Mitsubishi_axActUtlType = new Mitsubishi_axActUtlType();//实例化接口
                CSEngineTest.PLC.Mitsubishi = new Mitsubishi_realize();//实例化接口
                CSEngineTest.PLC.MODBUD_TCP = new MODBUD_TCP();//实例化接口
                CSEngineTest.PLC.Siemens = new Siemens_realize();//实例化接口;            
            });
        }

        private void Form2_Shown(object sender, EventArgs e)//添加控件
        {
            this.timer2.Start();//运行定时器监控
            //UI_Schedule("开始正在显示UI", 90, true);
            if (edit_mode) this.toolStripMenuItem5.Text = "退出编辑模式"; else this.toolStripMenuItem5.Text = "开启编辑模式";//改变显示文本  
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)//调用测试工具
        {
            FormLoad formLoad = new FormLoad();
            if (MessageBox.Show("该测试软件调用来源于：Git", "错误：ERR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                formLoad.ShowDialog();
        }
        PLCselect_Form pLCselect_Form;
        private void toolStripMenuItem4_Click(object sender, EventArgs e)//开始链接设备--PLC
        {
            if (!pLCselect_Form.IsNull())
            {
                if (pLCselect_Form.Hiel)
                {
                    pLCselect_Form.Activate();
                    return;
                }
            }
            pLCselect_Form = new PLCselect_Form();
            pLCselect_Form.Show();
        }
        public static bool edit_mode = false;//指示用户是否进入编辑模式
        private void toolStripMenuItem5_Click(object sender, EventArgs e)//用户进入编辑模式
        {
            if (edit_mode) edit_mode = false; else edit_mode = true;//改变状态
            if (edit_mode) this.toolStripMenuItem5.Text = "退出编辑模式"; else this.toolStripMenuItem5.Text = "开启编辑模式";//改变显示文本
            this.toolStripMenuItem1.Enabled = edit_mode;
            this.toolStripMenuItem6.Enabled = edit_mode;
            this.toolStripMenuItem16.Enabled = edit_mode;
            this.ucNavigationMenu1.Enabled = false;
            this.ucNavigationMenu1.Items[6].TipText = edit_mode == true ? "开" : "关";//改变状态栏提示文字
            this.ucNavigationMenu1.Enabled = true;
        }
        private void timer2_Tick(object sender, EventArgs e)//实时刷新用户是否进入 与退出编辑模式
        {
            if (edit_mode) this.toolStripMenuItem5.Text = "退出编辑模式"; else this.toolStripMenuItem5.Text = "开启编辑模式";//改变显示文本
            this.toolStripMenuItem1.Enabled = edit_mode;
            this.toolStripMenuItem6.Enabled = edit_mode;
            this.toolStripMenuItem16.Enabled = edit_mode;
            this.ucNavigationMenu1.Enabled = false;
            this.ucNavigationMenu1.Items[6].TipText = edit_mode == true ? "开" : "关";//改变状态栏提示文字
            this.ucNavigationMenu1.Enabled = true;
            if (PLC_read_Tick & edit_mode != true) time_Reform.read_status = false; else time_Reform.read_status = true; //指示定时器可以开始遍历
            if (edit_mode) { PLC_read_ok = false; PLC_read_Tick = false; };//指示用户开始了编辑模式
            asc.RenewControlRect(this);//实时保存控件大小与位置
            //判断用户是否没进入编辑模式--并且没有连接设备
        }
        bool PLC_read_Tick = false;//指示是否遍历窗口完成
        bool PLC_read_ok = false;//指示是否遍历控件是否完成--
        private void PLC_circulation_read_Tick(object sender, EventArgs e)//PLC循环读取定时器
        {
            Task.Run(() =>
               {
                   if (time_Reform.TextBox_read_status != false || time_Reform.Button_read_status != false || time_Reform.Switch_read_status != false
                   || time_Reform.LedBulb_read_status != false || time_Reform.doughnut_Chart_read_status != false || time_Reform.histogram_Chart_read_status != false
                   || time_Reform.oscillogram_Chart_read_status != false || time_Reform.AnalogMeter_read_status != false ||
                   time_Reform.LedDisplay_read_status != false || time_Reform.ihatetheqrcode_read_status != false || edit_mode) return;//直接返回方法--指示当前控件正在遍历
                   if (PLC_read_ok != true)
                   {
                       PLC_read_Tick = false;//指示定时器不可以开始遍历
                       ConcurrentBag<Button_reform> button_Reforms = new ConcurrentBag<Button_reform>();//按钮类集合
                       ConcurrentBag<SkinTextBox_reform> skinTextBox_Reforms = new ConcurrentBag<SkinTextBox_reform>();//文本输入类集合
                       ConcurrentBag<Switch_reform> Switch_reforms = new ConcurrentBag<Switch_reform>();//切换开关类集合
                       ConcurrentBag<LedBulb_reform> LedBulb_reforms = new ConcurrentBag<LedBulb_reform>();//指示灯类集合
                       ConcurrentBag<ImageButton_reform> ImageButton_reforms = new ConcurrentBag<ImageButton_reform>();//指示灯类集合
                       ConcurrentBag<doughnut_Chart_reform> doughnut_Chart_reforms = new ConcurrentBag<doughnut_Chart_reform>();//圆形图类集合
                       ConcurrentBag<histogram_Chart_reform> histogram_Chart_reforms = new ConcurrentBag<histogram_Chart_reform>();//柱形图图类集合
                       ConcurrentBag<oscillogram_Chart_reform> oscillogram_Chart_reforms = new ConcurrentBag<oscillogram_Chart_reform>();//折线图类集合
                       ConcurrentBag<AnalogMeter_reform> AnalogMeter_reforms = new ConcurrentBag<AnalogMeter_reform>();//百分百表盘类集合
                       ConcurrentBag<LedDisplay_reform> LedDisplay_reforms = new ConcurrentBag<LedDisplay_reform>();//数值显示类集合
                       ConcurrentBag<ihatetheqrcode_reform> ihatetheqrcode_reforms = new ConcurrentBag<ihatetheqrcode_reform>();//二维码/条形码类集合

                       foreach (var In in this.Controls)//遍历窗口控件
                       {
                           if (In is Button_reform) button_Reforms.Add((Button_reform)In);//添加按钮对象
                           if (In is SkinTextBox_reform) skinTextBox_Reforms.Add((SkinTextBox_reform)In);//添加文本输入对象
                           if (In is Switch_reform) Switch_reforms.Add((Switch_reform)In);//切换开关对象
                           if (In is LedBulb_reform) LedBulb_reforms.Add((LedBulb_reform)In);//添加对象
                           if (In is ImageButton_reform) ImageButton_reforms.Add((ImageButton_reform)In);//添加对象
                           if (In is doughnut_Chart_reform) doughnut_Chart_reforms.Add((doughnut_Chart_reform)In);//添加对象
                           if (In is histogram_Chart_reform) histogram_Chart_reforms.Add((histogram_Chart_reform)In);//添加对象
                           if (In is oscillogram_Chart_reform) oscillogram_Chart_reforms.Add((oscillogram_Chart_reform)In);//添加对象
                           if (In is AnalogMeter_reform) AnalogMeter_reforms.Add((AnalogMeter_reform)In);//添加对象
                           if (In is LedDisplay_reform) LedDisplay_reforms.Add((LedDisplay_reform)In);//添加对象
                           if (In is ihatetheqrcode_reform) ihatetheqrcode_reforms.Add((ihatetheqrcode_reform)In);//添加对象

                       }
                       time_Reform.Button_list_1 = button_Reforms;//获取集合
                       time_Reform.TextBox_list_1 = skinTextBox_Reforms;//获取集合
                       time_Reform.Switch_list_1 = Switch_reforms;//获取集合
                       time_Reform.LedBulb_list_1 = LedBulb_reforms;//获取集合
                       time_Reform.ImageButton_list_1 = ImageButton_reforms;//获取集合
                       time_Reform.doughnut_Chart_list_1 = doughnut_Chart_reforms;//获取集合
                       time_Reform.histogram_Chart_list_1 = histogram_Chart_reforms;//获取集合
                       time_Reform.oscillogram_Chart_list_1 = oscillogram_Chart_reforms;//获取集合
                       time_Reform.AnalogMeter_list_1 = AnalogMeter_reforms;//获取集合
                       time_Reform.LedDisplay_list_1 = LedDisplay_reforms;//获取集合
                       time_Reform.ihatetheqrcode_list_1 = ihatetheqrcode_reforms;//获取集合
                       PLC_read_ok = true;
                       PLC_read_Tick = true;//指示定时器可以开始遍历
                       button_Reforms = null;
                   }
             });

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)//用户点击了报警注册
        {
            Event_registration event_Registration = new Event_registration();//实例化报警注册窗口
            event_Registration.ShowDialog();//弹出窗口
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)//用户点击编辑宏指令--
        {
            macroinstruction_Form macroinstruction_Form = new macroinstruction_Form();
            macroinstruction_Form.ShowDialog();//弹出宏窗口
        }
        public static bool Size_Max = false;//指示窗口是否开启最大值或者最小值
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            //如果不是在控件上面最大化--不进行标志位记录       
            if (this.Capture != true || this.CanSelect != true || this.CanFocus != true) return;
            //处理窗口最大化与最小化标志位
            //if (this.Size.Height > 900)
            //    Size_Max = true;
            //else
            //    Size_Max = false;
            //this.BeginInvoke((MethodInvoker)delegate
            //{
            //    asc.ControlAutoSize(this);
            //});

        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Software_specifications software = new Software_specifications();
            software.ShowDialog();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //模糊查询导航栏固定功能键
            var inr = (from Control pi in this.Controls where pi.Name.Contains("skinButton") select pi).Select(pi => pi).ToList();
            foreach (var i in inr)
            {
                i.Enabled = true;
                i.SendToBack();
            }
            UI_Schedule("加载完成", 100, true);
            Thread.Sleep(50);
            UI_Schedule("加载完成", 100, false);
            this.timer3.Stop();
        }
        public void UI_Schedule(string Text, int Vaule, bool Visible)//加载UI控件控制
        {
            this.userControl11.Display = Visible;
            this.userControl11.Schedule = Vaule;
            this.userControl11.Schedule_Text = Text;
        }
        /// <summary>
        /// 新增菜单栏点击项事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucNavigationMenu1_ClickItemed(object sender, EventArgs e)
        {
            #region 不需要开启编辑模式的功能
            switch (this.ucNavigationMenu1.SelectItem.Text)
            {
                case "链接设备":
                    toolStripMenuItem4_Click(sender, e);
                    return;
                case "通讯测试":
                    toolStripMenuItem2_Click(sender, e);
                    return;
                case "编辑模式":
                    toolStripMenuItem5_Click(sender, e);
                    return;
                case "关于":
                    toolStripMenuItem15_Click(sender, e);
                    return;
            }
            #endregion
            //判断用户选择的功能
            if (!edit_mode)
            {
                MessageBox.Show("未进入编辑模式：请开启编辑模式", "Err");
                return;
            }
            #region 添加控件选项判断需要开启编辑模式
            switch (this.ucNavigationMenu1.SelectItem.Text)
            {
                case "Button_按钮":
                    buttton按钮ToolStripMenuItem_Click(sender, e);
                    break;
                case "Label_文本":
                    label文本ToolStripMenuItem_Click(sender, e);
                    break;
                case "Texebox_数值":
                    texebox数值ToolStripMenuItem_Click(sender, e);
                    break;
                case "LedDisplay数值显示":
                    toolStripMenuItem17_Click(sender, e);
                    break;
                case "lmage_图片":
                    lmage图片ToolStripMenuItem_Click(sender, e);
                    break;
                case "Switch_切换开关":
                    toolStripMenuItem7_Click(sender, e);
                    break;
                case "ScrollingText报警滚动条":
                    toolStripMenuItem8_Click(sender, e);
                    break;
                case "GroupBox四方边框条":
                    toolStripMenuItem9_Click(sender, e);
                    break;
                case "histogram_Chart柱形图":
                    toolStripMenuItem10_Click(sender, e);
                    break;
                case "doughnut_Chart圆形图":
                    toolStripMenuItem11_Click(sender, e);
                    break;
                case "oscillogram_Chart波形图":
                    toolStripMenuItem14_Click(sender, e);
                    break;
                case "透明化_Button":
                    toolStripMenuItem12_Click(sender, e);
                    break;
                case "LedBulb指示灯":
                    toolStripMenuItem13_Click(sender, e);
                    break;
                case "AnalogMeter百分百表盘":
                    toolStripMenuItem18_Click(sender, e);
                    break;
                case "二维码/条形码":
                    toolStripMenuItem19_Click(sender, e);
                    break;
                case "功能键_画面切换":
                    toolStripMenuItem20_Click(sender, e);
                    break;
                case "ComboBox下拉菜单":
                    toolStripMenuItem21_Click(sender, e);
                    break;
                case "CheckBox 单选按钮":
                    toolStripMenuItem22_Click(sender, e);
                    break;
                case "HScrollBar_纵向移动图形":
                    toolStripMenuItem23_Click(sender, e);
                    break;
                case "VScrollBar_横向移动图形":
                    MessageBox.Show("未开发改功能");
                    break;
                case "Conveyor运输带":
                    toolStripMenuItem25_Click(sender, e);
                    break;
                case "Valve流体阀门":
                    toolStripMenuItem26_Click(sender, e);
                    break;

            }
            #endregion
            #region 其他功能选项需要开启编辑模式
            switch (this.ucNavigationMenu1.SelectItem.Text)
            {
                case "报警注册":
                    toolStripMenuItem6_Click(sender, e);
                    break;
                case "宏指令":
                    toolStripMenuItem16_Click(sender, e);
                    break;
            }
            #endregion
            //#region 控件对齐模式
            //switch (this.ucNavigationMenu1.SelectItem.TipText)
            //{
            //    case "左对齐":

            //        this.ucNavigationMenu1.SelectItem.Icon = this.Aligning.Images[0];

            //        return;
            //}
            //#endregion
        }


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                if (!this.Capture) return;
                if (MessageBox.Show("该窗口是主窗口是否要退出程序？", "Err", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();//关闭所有窗口
                }
                else
                {
                    e.Cancel = true;//取消
                    return;//返回方法
                }
            }
            catch { }
        }
    }
}
