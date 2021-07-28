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
using 自定义Uppercomputer_20200727.Nlog;
using 自定义Uppercomputer_20200727.控件复制粘贴API;
using 自定义Uppercomputer_20200727.控件重做.复制粘贴接口;
using 自定义Uppercomputer_20200727.EF实体模型;
using System.Data.Entity;
using CCWin.Win32.Const;
using 自定义Uppercomputer_20200727.控制主页面模板.控件添加类重写;
using 欧姆龙Fins协议.欧姆龙.报文处理;
using 自定义Uppercomputer_20200727.数据查询界面;
using 自定义Uppercomputer_20200727.控制主页面模板.模板窗口接口;
using 自定义Uppercomputer_20200727.角色权限管理;

namespace 自定义Uppercomputer_20200727
{
    public partial class Form2 : CCWin.Skin_DevExpress, FormIdentification
    {
        /// <该页面是模板通用页面->
        //1.声明自适应类实例
        AutoSizeFormClass asc = new AutoSizeFormClass();
        /// <summary>
        /// 标识该窗口是框架窗口
        /// 默认所有窗口都是切换完成后自动关闭
        /// </summary>
        private bool frameForm { get; set; } = true;

        public bool IsCloseForm { get => frameForm; }
        public bool IsfunctionKey { get; set; } = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            ////开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.ResizeRedraw
                 | ControlStyles.Selectable
                 | ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.UserPaint
                 | ControlStyles.SupportsTransparentBackColor,
               true);
            ToolStripManager.Renderer = new HZH_Controls.Controls.ProfessionalToolStripRendererEx();
        }
        private void skinButton1_Click(object sender, EventArgs e)//公用页面处理
        {
            lock (this)
            {
                SkinButton skinButton = (SkinButton)sender;
                if (skinButton.Text == this.skinLabel1.Text || IsfunctionKey == false) return;
                string Data = this.skinLabel1.Text;
                using (Windowclass windowclass = new Windowclass(this, new Form[] {new Form3(), new Form4(),new Form5()
                , new Form6(),new Form7(), new 生产设置画面.Form8(), new 参数设置画面.Form9()}, skinButton))
                {
                }
            }
        }
        private void skinContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        int X = 0, Y = 0;//窗口与鼠标的相对位置

        private void buttton按钮ToolStripMenuItem_Click(object sender, EventArgs e)//添加按钮
        {
            ControlAddBase controlAdd = new ControlAddBase();
            Button_reform skinButton = controlAdd.Add<Button_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加："+skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层     
            Modification_Button modification_Button = new Modification_Button(skinButton.Parent.ToString(), skinButton);
            modification_Button.ShowDialog();
            if (modification_Button.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }

        }

        private void label文本ToolStripMenuItem_Click(object sender, EventArgs e)//添加系统文本
        {
            ControlAddBase skinlabel = new ControlAddBase();
            SkinLabel skinLabel = skinlabel.Add<SkinLabel_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinLabel);
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinLabel.Name);

            skinLabel.BringToFront();//将控件放置所有控件最顶层     
            Modification_label modification_Label = new Modification_label(skinLabel.Parent.ToString(), skinLabel);
            modification_Label.ShowDialog();
            if (modification_Label.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinLabel.Name);
                this.Controls.Remove(skinLabel);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinLabel.Name);
            }
        }

        private void texebox数值ToolStripMenuItem_Click(object sender, EventArgs e)//添加系统输入文本
        {
            ControlAddBase skinTextBox = new ControlAddBase();
            TextBox skinTextBox1 = skinTextBox.Add<SkinTextBox_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinTextBox1);
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinTextBox1.Name);

            skinTextBox1.BringToFront();//将控件放置所有控件最顶层   
            Modification_numerical modification_Numerical = new Modification_numerical(skinTextBox1.Parent.ToString(), skinTextBox1);
            modification_Numerical.ShowDialog();
            skinTextBox1.Text = "00";
            if (modification_Numerical.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinTextBox1.Name);
                this.Controls.Remove(skinTextBox1);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinTextBox1.Name);
            }

        }

        private void lmage图片ToolStripMenuItem_Click(object sender, EventArgs e)//添加系统图片
        {

            SkinPictureBox_Add skinPicture = new SkinPictureBox_Add();
            SkinPictureBox skinPictureBox = skinPicture.Add(this.Controls, new Point(X, Y), this.imageList1.Images[0]);
            this.Controls.Add(skinPictureBox);
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinPictureBox.Name);

            skinPictureBox.BringToFront();//将控件放置所有控件最顶层   
            Modification_picture modification_Picture = new Modification_picture(skinPictureBox.Parent.ToString(), skinPictureBox);
            modification_Picture.ShowDialog();
            skinPictureBox.Image = modification_Picture.Image;
            if (modification_Picture.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinPictureBox.Name);
                this.Controls.Remove(skinPictureBox);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinPictureBox.Name);
            }
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)//添加切换开关
        {
            ControlAddBase button = new ControlAddBase();
            Switch_reform skinButton = button.Add<Switch_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_Switch modification_Button = new Modification_Switch(skinButton.Parent.ToString(), skinButton);
            modification_Button.ShowDialog();
            if (modification_Button.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem13_Click(object sender, EventArgs e)//添加指示灯
        {
            ControlAddBase button = new ControlAddBase();
            LedBulb_reform skinButton = button.Add<LedBulb_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_Ledbulb modification_Button = new Modification_Ledbulb(skinButton.Parent.ToString(), skinButton);
            modification_Button.ShowDialog();
            if (modification_Button.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)//添加四边形方框
        {
            ControlAddBase GroupBox = new ControlAddBase();
            GroupBox_reform GroupBoxl = GroupBox.Add<GroupBox_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(GroupBoxl);
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + GroupBoxl.Name);

            GroupBoxl.SendToBack();//将控件放置所有控件最底层
            Modification_GroupBox modification_GroupBox = new Modification_GroupBox(GroupBoxl.Parent.ToString(), GroupBoxl);
            modification_GroupBox.ShowDialog();
            if (modification_GroupBox.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + GroupBoxl.Name);
                this.Controls.Remove(GroupBoxl);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + GroupBoxl.Name);
            }
        }
        private void toolStripMenuItem12_Click(object sender, EventArgs e)//添加无图片按钮类三
        {
            ControlAddBase button = new ControlAddBase();
            ImageButton_reform skinButton = button.Add<ImageButton_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_ImageButton modification_ImageButton = new Modification_ImageButton(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)//添加报警条
        {
            ScrollingText_Add button = new ScrollingText_Add(this);
            ScrollingText_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_ScrollingText modification_ImageButton = new Modification_ScrollingText(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem11_Click(object sender, EventArgs e)//添加圆形图
        {
            doughnut_Chart_Add button = new doughnut_Chart_Add();
            doughnut_Chart_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_doughnut_Chart modification_ImageButton = new Modification_doughnut_Chart(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem10_Click(object sender, EventArgs e)//柱形图
        {
            histogram_Chart_Add button = new histogram_Chart_Add();
            histogram_Chart_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_histogram_Chart modification_ImageButton = new Modification_histogram_Chart(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem14_Click(object sender, EventArgs e)//波形图
        {
            oscillogram_Chart_Add button = new oscillogram_Chart_Add();
            oscillogram_Chart_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_oscillogram_Chart modification_ImageButton = new Modification_oscillogram_Chart(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem17_Click(object sender, EventArgs e)//数值显示
        {
            ControlAddBase button = new ControlAddBase();
            LedDisplay_reform skinButton = button.Add<LedDisplay_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_LedDisplay modification_ImageButton = new Modification_LedDisplay(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem18_Click(object sender, EventArgs e)//百分百表盘
        {
            ControlAddBase button = new ControlAddBase();
            AnalogMeter_reform skinButton = button.Add<AnalogMeter_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_AnalogMeter modification_ImageButton = new Modification_AnalogMeter(skinButton.Parent.ToString(), skinButton);
            modification_ImageButton.ShowDialog();
            if (modification_ImageButton.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem19_Click(object sender, EventArgs e)//添加二维码/条形码
        {
            ihatetheqrcode_Add button = new ihatetheqrcode_Add();
            ihatetheqrcode_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_ihatetheqrcode modification_ihatetheqrcode = new Modification_ihatetheqrcode(skinButton.Parent.ToString(), skinButton);
            modification_ihatetheqrcode.ShowDialog();
            if (modification_ihatetheqrcode.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem20_Click(object sender, EventArgs e)//添加画面切换
        {
            ControlAddBase button = new ControlAddBase();
            function_key_reform skinButton = button.Add<function_key_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_function_key modification_function_key = new Modification_function_key(skinButton.Parent.ToString(), skinButton);
            modification_function_key.ShowDialog();
            if (modification_function_key.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem22_Click(object sender, EventArgs e)//添加单选按钮
        {
            ControlAddBase button = new ControlAddBase();
            RadioButton_reform skinButton = button.Add<RadioButton_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_RadioButton modification_RadioButton = new Modification_RadioButton(skinButton.Parent.ToString(), skinButton);
            modification_RadioButton.ShowDialog();
            if (modification_RadioButton.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem21_Click(object sender, EventArgs e)//添加下拉菜单
        {
            pull_down_menu_Add button = new pull_down_menu_Add();
            pull_down_menu_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_pull_down_menu modification_pull_down_menu = new Modification_pull_down_menu(skinButton.Parent.ToString(), skinButton);
            modification_pull_down_menu.ShowDialog();
            if (modification_pull_down_menu.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem23_Click(object sender, EventArgs e)//添加纵向移动图形
        {
            ControlAddBase button = new ControlAddBase();
            HScrollBar_reform skinButton = button.Add<HScrollBar_reform>(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_HScrollBar modification_HScrollBar = new Modification_HScrollBar(skinButton.Parent.ToString(), skinButton);
            modification_HScrollBar.ShowDialog();
            if (modification_HScrollBar.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem25_Click(object sender, EventArgs e)//添加Conveyor运输带
        {
            Conveyor_Add button = new Conveyor_Add();
            Conveyor_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_Conveyor modification_Conveyor = new Modification_Conveyor(skinButton.Parent.ToString(), skinButton);
            modification_Conveyor.ShowDialog();
            if (modification_Conveyor.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem26_Click(object sender, EventArgs e)//添加Valve流体阀门
        {
            Valve_Add button = new Valve_Add();
            Valve_reform skinButton = button.Add(this.Controls, new Point(X, Y));
            this.Controls.Add(skinButton);//添加控件
            //LogUtils日志
            LogUtils.debugWrite("用户选择添加：" + skinButton.Name);

            skinButton.BringToFront();//将控件放置所有控件最顶层   
            Modification_Valve modification_Valve = new Modification_Valve(skinButton.Parent.ToString(), skinButton);
            modification_Valve.ShowDialog();
            if (modification_Valve.Add_to_allow == false)
            {
                //LogUtils日志
                LogUtils.debugWrite("用户取消添加控件：" + skinButton.Name);
                this.Controls.Remove(skinButton);//不允许添加异常对象
            }
            else
            {
                //LogUtils日志
                LogUtils.debugWrite("用户添加控件：" + skinButton.Name);
            }
        }
        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            //打开权限登录界面窗口
            jurisdiction jurisdiction = new jurisdiction();
            jurisdiction.ShowDialog();
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

        private  async void Form2_Load(object sender, EventArgs e)//加载窗口
        {
            if (!GetPidByProcess()) return;
            //判断主窗口是否在运行
            if (!Program.OPENCLOASE) return;
            ToolStripManager.Renderer = new HZH_Controls.Controls.ProfessionalToolStripRendererEx();
            Form2_Leave(this, new EventArgs());
            UI_Schedule("开始加载控件", 30, true);
            await NewMethod();
            //测试代码
            this.timer2.Enabled = true;
            this.timer2.Start();
            this.timer3.Enabled = true;
            this.timer3.Start();
            timer3.Interval = 10;
            //asc.RenewControlRect(this);
            //传递PLC参数到宏指令
            if (!CSEngineTest.PLC.Mitsubishi_axActUtlType.IsNull()) return;
            //LogUtils日志
            LogUtils.debugWrite("用户添加控件： 实例化宏指令对象");

            CSEngineTest.PLC.Mitsubishi_axActUtlType = new Mitsubishi_axActUtlType();//实例化接口
            CSEngineTest.PLC.Mitsubishi = new Mitsubishi_realize();//实例化接口
            CSEngineTest.PLC.MODBUD_TCP = new MODBUD_TCP();//实例化接口
            CSEngineTest.PLC.Siemens = new Siemens_realize();//实例化接口;
            CSEngineTest.PLC.OmronCip = new OmronFinsCIP();//实例化接口;
            CSEngineTest.PLC.OmronTcp = new OmronFinsTcp();//实例化接口;
            CSEngineTest.PLC.OmronUdp = new OmronFinsUDP();//实例化接口;
        }

        private async Task NewMethod()
        {
            await Task.Run(() =>
            {
                From_Load_Add.imageLists_1 = new List<ImageList>() { this.imageList1, this.imageList2, this.imageList3 };
                using (dynamic load_Add = new From_Load_Add(this.Name, this.Controls, new List<ImageList>() { this.imageList1, this.imageList2, this.imageList3 }, this)) ;//添加报警条
                using (dynamic add = new From_Load_Add(this.Name, this.Controls, new List<ImageList>() { this.imageList1, this.imageList2, this.imageList3 }, this, true)) ;//添加普通文本
                asc.RenewControlRect(this);
               // UI_Schedule("开始正在显示UI", 90, true);
                return 1;

            });
          
        }

        private void Form2_Shown(object sender, EventArgs e)//添加控件
        {
            this.timer2.Start();//运行定时器监控
            //UI_Schedule("开始正在显示UI", 90, true);
            if (edit_mode) this.toolStripMenuItem5.Text = "退出编辑模式"; else this.toolStripMenuItem5.Text = "开启编辑模式";//改变显示文本  
            // 编辑模式 在记录日志
            this.toolStripMenuItem5.TextChanged += ((send1, e1) =>
              {
                  //LogUtils日志
                  LogUtils.debugWrite($"用户打开了：{this.toolStripMenuItem5.Text}");
              });
            ///注册API
            WinMonitoring.RegisterHotKey(Handle, 103, WinMonitoring.KeyModifiers.Ctrl, Keys.C);

            WinMonitoring.RegisterHotKey(Handle, 104, WinMonitoring.KeyModifiers.Ctrl, Keys.V);
            UI_Schedule("显示完成 后台任务正在运行中", 100, false);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)//调用SQL数据查询工具
        {
            //LogUtils日志
            LogUtils.debugWrite("用户调用了 SQL查询工具");
            SQLquery lquery = new SQLquery();
            lquery.ShowDialog();
            //LogUtils日志
            LogUtils.debugWrite("用户关闭了 SQL查询工具");
        }
        PLCselect_Form pLCselect_Form;
        private void toolStripMenuItem4_Click(object sender, EventArgs e)//开始链接设备--PLC
        {

            if (!pLCselect_Form.IsNull())
            {
                if (pLCselect_Form.Hiel)
                {
                    //LogUtils日志
                    LogUtils.debugWrite("用户激活了 链接设备界面");
                    pLCselect_Form.Activate();
                    return;
                }
            }
            //LogUtils日志
            LogUtils.debugWrite("用户调用了 链接设备界面");
            pLCselect_Form = new PLCselect_Form();
            pLCselect_Form.Show();
        }
        public static bool edit_mode = false;//指示用户是否进入编辑模式
        private void toolStripMenuItem5_Click(object sender, EventArgs e)//用户进入编辑模式
        {
            if (edit_mode) edit_mode = false; else edit_mode = true;//改变状态
            if (edit_mode)this.toolStripMenuItem5.Text = "退出编辑模式"; else this.toolStripMenuItem5.Text = "开启编辑模式";//改变显示文本
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
            //if (edit_mode) { PLC_read_ok = false; PLC_read_Tick = false; };//指示用户开始了编辑模式
            asc.RenewControlRect(this);//实时保存控件大小与位置

            try
            {
                if (GetForegroundWindow() == this.Handle)
                {
                    Form2_Activated(this, new EventArgs());
                }
                else
                {
                    Form2_Leave(this, new EventArgs());
                }
            }
            catch { }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)//用户点击了报警注册
        {
            //LogUtils日志
            LogUtils.debugWrite($"用户点击了 报警注册界面");

            Event_registration event_Registration = new Event_registration();//实例化报警注册窗口
            event_Registration.ShowDialog();//弹出窗口
            //LogUtils日志
            LogUtils.debugWrite($"用户点关闭 报警注册界面");
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)//用户点击编辑宏指令--
        {
            //LogUtils日志
            LogUtils.debugWrite($"用户点击了 宏指令界面");
            macroinstruction_Form macroinstruction_Form = new macroinstruction_Form();
            macroinstruction_Form.ShowDialog();//弹出宏窗口
            //LogUtils日志
            LogUtils.debugWrite($"用户点关闭 宏指令界面");
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

            //LogUtils日志
            LogUtils.debugWrite($"用户改变了{this.Text+this.Name}窗口的Size大小");
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)//软件说明
        {
            //LogUtils日志
            LogUtils.debugWrite($"用户点击了 软件说明界面");
            Software_specifications software = new Software_specifications();
            software.ShowDialog();
            //LogUtils日志
            LogUtils.debugWrite($"用户关闭了 软件说明界面");
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
            UI_Schedule("加载完成", 100, false);
            IsfunctionKey = true;
            this.timer4.Enabled = true;
            this.timer4.Start();
            this.timer3.Stop();

        }
        public void UI_Schedule(string Text, int Vaule, bool Visible)//加载UI控件控制
        {
            this.userControl11.Display = Visible;
            this.userControl11.Schedule = Vaule;
            this.userControl11.Schedule_Text = Text;
            //LogUtils日志
            LogUtils.debugWrite( this.Text+this.Name+Text+$"进度{Vaule}");
        }
        三菱伺服MR_JE控制.Form1 Servo_Form;
        /// <summary>
        /// 新增菜单栏点击项事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucNavigationMenu1_ClickItemed(object sender, EventArgs e)
        {
            //LogUtils日志
            LogUtils.debugWrite($"用户点击了："+ this.ucNavigationMenu1.SelectItem.Text);

            #region 不需要开启编辑模式的功能
            switch (this.ucNavigationMenu1.SelectItem.Text)
            {
                case "链接设备":
                    toolStripMenuItem4_Click(sender, e);
                    return;
                case "数据查询"://
                    toolStripMenuItem2_Click(sender, e);
                    return;
                case "编辑模式":
                    toolStripMenuItem5_Click(sender, e);
                    return;
                case "伺服控制":
                    if (!Servo_Form.IsNull())
                    {
                        if (Servo_Form.Hiel)
                        {
                            Servo_Form.Activate();
                            return;
                        }
                    }
                    Servo_Form = new 三菱伺服MR_JE控制.Form1();
                    Servo_Form.Show();
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
        }
        /// <summary>
        /// 控件热键注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Activated(object sender, EventArgs e)
        {
            WinMonitoring.RegisterHotKey(Handle, 103, WinMonitoring.KeyModifiers.Ctrl, Keys.C);

            WinMonitoring.RegisterHotKey(Handle, 104, WinMonitoring.KeyModifiers.Ctrl, Keys.V);
        }
        /// <summary>
        /// 注销控件热键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Leave(object sender, EventArgs e)
        {
            WinMonitoring.UnregisterHotKey(Handle, 103);

            WinMonitoring.UnregisterHotKey(Handle, 104);
        }
        /// <summary>
        /// 粘贴板
        /// </summary>
        public static Control control;
        /// <summary>
        /// 监视Windows消息 重载WndProc方法，用于实现热键响应
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 103:     //按下的是Ctrl+C 触发了复制控件
                            var conrt = GetFocusedControl();//获取控件
                            if (conrt == null|| !edit_mode) return;
                            //判断改控件是否实现接口
                            if ((conrt as ControlCopy) != null)
                            {
                                control = GetFocusedControl();//获取需要复制的控件
                                CopyControl copyControl = new CopyControl($"Copy 控件:{control.Name}成功", this);
                                copyControl.Location = new Point(this.Size.Width / 2 - 150, 80);
                                this.Controls.Add(copyControl);
                            }
                            else
                            {
                                CopyControl copyControl = new CopyControl($"Copy 控件:{conrt.Name}失败", this);
                                copyControl.Location = new Point(this.Size.Width / 2 - 150, 80);
                                this.Controls.Add(copyControl);
                            }
                            break;
                        case 104:     //按下的是Ctrl+V 触发了粘贴控件
                            //判断粘贴板是否有控件
                            if (control != null|| !edit_mode)
                            {
                                //遍历当前窗口--改控件的编号
                                var cont = (from Control pi in this.Controls where pi.GetType().UnderlyingSystemType.Name == control.GetType().UnderlyingSystemType.Name select pi).ToList();
                                int dex = 0;
                            inedx:
                                dex += 1;
                                string Name = control.GetType().Name + dex;//先定义名称
                                foreach (Control i in this.Controls)//遍历窗口是否有该名称存在
                                {
                                    if (i.Name == Name) goto inedx;
                                }
                                CopyControl copyControl = new CopyControl($"粘贴控件:{control.Name}成功", this);
                                copyControl.Location = new Point(this.Size.Width / 2 - 150, 80);
                                this.Controls.Add(copyControl);
                                //产生新的控件
                                var contrs = (control as ControlCopy).Objectproperty(Name, this);
                                this.Controls.Add(contrs);
                                contrs.BringToFront();
                            }
                            else
                            {
                                CopyControl copyControl = new CopyControl($"粘贴控件:失败", this);
                                copyControl.Location = new Point(this.Size.Width / 2 - 100, 80);
                                this.Controls.Add(copyControl);
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        //API声明：获取当前焦点控件句柄      

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]

        internal static extern IntPtr GetFocus();

        /// <summary>
        /// 获取 当前窗口拥有焦点的控件
        /// </summary>
        /// <returns></returns>
        private Control GetFocusedControl()
        {
            Control focusedControl = null;
            IntPtr focusedHandle = GetFocus();
            if (focusedHandle != IntPtr.Zero)
                focusedControl = Control.FromChildHandle(focusedHandle);
            return focusedControl;
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
          
        }
        //监控当前是否活动窗口
        [DllImport("user32.dll")]

        private static extern IntPtr GetForegroundWindow();
        //判断当前窗口是否运行键盘鼠标输入
        [DllImport("user32")]
        private static extern int IsWindowEnabled(IntPtr hWnd);

        public  bool IsEnabled(IntPtr hWnd)
        {
            if (IsWindowEnabled(hWnd) == 0)
                return false;
            else
                return true;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //加载完成 开始布局控件上下层
            this.timer4.Stop();
            if(GetPidByProcess())
            From_Load_Add.Stratum(this.Name, this);
            //开始判断是否重连 机制
            this.plCreconnectionTime1.Enabled =  true;
            this.plCreconnectionTime1.Start();
      
        }
        /// <summary>
        /// 判断程序是否在运行
        /// true 该程序在电脑进程运行中  false 表示不在进程运行
        /// 该方法主要用于避免继承过程中CLR 进入SQL数据库 查询数据从而卡死软件
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private bool GetPidByProcess(string Name= "自定义Uppercomputer-20200727")
        {
            return System.Diagnostics.Process.GetProcessesByName(Name).ToList().Count > 0 ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            非软件运行时控件.控件测试界面.TestForm testForm = new 非软件运行时控件.控件测试界面.TestForm();
            testForm.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            WinMonitoring.UnregisterHotKey(Handle, 103);

            WinMonitoring.UnregisterHotKey(Handle, 104);
            this.plCreconnectionTime1.Dispose();
            try
            {
                if (!this.Capture) return;
                if (MessageBox.Show("该窗口是主窗口是否要退出程序？", "Err", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //LogUtils日志
                    LogUtils.debugWrite($"用户关闭了软件");
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
