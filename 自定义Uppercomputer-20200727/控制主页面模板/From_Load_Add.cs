using CCWin.SkinClass;
using CCWin.SkinControl;
using CCWin.Win32.Const;
using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.图库;
using 自定义Uppercomputer_20200727.控件重做;
using 自定义Uppercomputer_20200727.控件重做.工业图形控件;
using static System.Windows.Forms.Control;

namespace 自定义Uppercomputer_20200727.控制主页面模板
{
    /// <本类主要用于窗口加载过程中同步加载数据库的控件>
    class From_Load_Add: IDisposable
    {
        List<Button_Class> skinButtons = new List<Button_Class>();//按钮类泛型表
        List<picture_Class> skinpicture = new List<picture_Class>();//图片类泛型表
        List<label_Class> skinlabel = new List<label_Class>();//标签类泛型表
        List<numerical_Class> skinnumerical = new List<numerical_Class>();//标签类泛型表
        List<Switch_Class> Switch = new List<Switch_Class>();//选择开关类泛型表
        List<LedBulb_Class> LedBulb = new List<LedBulb_Class>();//指示灯类泛型表
        List<GroupBox_Class> GroupBox = new List<GroupBox_Class>();//标签类泛型表
        List<ImageButton_Class> ImageButton = new List<ImageButton_Class>();//无图片按钮类类泛型表
        List<ScrollingText_Class> ScrollingText = new List<ScrollingText_Class>();//报警条类泛型表
        List<doughnut_Chart_Class> doughnut = new List<doughnut_Chart_Class>();//圆形图类泛型表
        List<histogram_Chart_Class> histogram = new List<histogram_Chart_Class>();//柱形图类泛型表
        List<oscillogram_Chart_Class> oscillogram = new List<oscillogram_Chart_Class>();//折线图图类泛型表
        List<AnalogMeter_Class> AnalogMeter = new List<AnalogMeter_Class>();//百分百表盘类泛型表
        List<LedDisplay_Class> LedDisplay = new List<LedDisplay_Class>();//数值显示类泛型表
        List<ihatetheqrcode_Class> ihatetheqrcode = new List<ihatetheqrcode_Class>();//二维码/条形码类泛型表
        List<function_key_Class> function_key = new List<function_key_Class>();//功能键类泛型表
        List<RadioButton_Class> RadioButton = new List<RadioButton_Class>();//单选按钮类泛型表
        List<pull_down_menu_Class> pull_down_menu = new List<pull_down_menu_Class>();//下拉菜单类泛型表
        List<HScrollBar_Class> HScrollBar = new List<HScrollBar_Class>();//纵向移动图形类泛型表
        List<Conveyor_Class> Conveyor = new List<Conveyor_Class>();//运输带类泛型表
        List<Valve_Class> Valve = new List<Valve_Class>();//液体阀门类泛型表
        ControlCollection control;//当前窗口控件集合
        List<ImageList> imageLists_1 { get; set; } //图库类集合--不可修改
        //报警条需要参数
        Form Form_event;//当前窗口
        public From_Load_Add(string From_Name, ControlCollection control, List<ImageList> imageLists_1, Form form, bool e)
        {
            Parameter_Query_Add parameter_Query_Add = new Parameter_Query_Add();//创建EF查询对象
            this.Form_event = form;//获取当前窗口
            this.control = control;
            var T = Task.Run(() =>
              {
                  this.skinButtons = parameter_Query_Add.all_Parameter_Query_Button(From_Name);//查询按钮类
                  Load_Add(this.skinButtons);
                  this.skinpicture = parameter_Query_Add.all_Parameter_Query_picture(From_Name);//查询图片类
                  this.skinlabel = parameter_Query_Add.all_Parameter_Query_label(From_Name);//查询标签类
                  this.skinnumerical = parameter_Query_Add.all_Parameter_Query_numerical(From_Name);//查询数值类
                  Load_Add(this.skinpicture);
                  Load_Add(this.skinlabel);
                  Load_Add(this.skinnumerical);
              });
            var T1 = Task.Run(() =>
            {
                this.Switch = parameter_Query_Add.all_Parameter_Query_Switch(From_Name);//查询切换开关类
                this.LedBulb = parameter_Query_Add.all_Parameter_Query_LedBulb(From_Name);//查询指示灯类
                this.GroupBox = parameter_Query_Add.all_Parameter_Query_GroupBox(From_Name);//查询四边框类
                this.ImageButton = parameter_Query_Add.all_Parameter_Query_ImageButton(From_Name);//查询无图片按钮类
                this.doughnut = parameter_Query_Add.all_Parameter_Query_doughnut_Chart(From_Name);//查询圆形图类按钮类
                Load_Add(this.Switch);
                Load_Add(this.LedBulb);
                Load_Add(this.ImageButton);
                Load_Add(this.doughnut);
            });
            var T2 = Task.Run(() =>
            {
                this.histogram = parameter_Query_Add.all_Parameter_Query_doughnut_histogram(From_Name);//查询柱形图图类按钮类
                this.oscillogram = parameter_Query_Add.all_Parameter_Query_doughnut_oscillogram(From_Name);//查询折线图图图类按钮类
                this.AnalogMeter = parameter_Query_Add.all_Parameter_Query_AnalogMeter(From_Name);//查询百分百表盘类按钮类
                this.LedDisplay = parameter_Query_Add.all_Parameter_Query_LedDisplay(From_Name);//查询数值显示类按钮类
                this.ihatetheqrcode = parameter_Query_Add.all_Parameter_Query_ihatetheqrcode(From_Name);//查询二维码/条形码类类
                this.function_key = parameter_Query_Add.all_Parameter_Query_function_key(From_Name);//查询功能键类
                this.RadioButton = parameter_Query_Add.all_Parameter_Query_RadioButton(From_Name);//查询单选按钮类
                this.pull_down_menu = parameter_Query_Add.all_Parameter_Query_pull_down_menu(From_Name);//查询下拉菜单类
                this.Conveyor = parameter_Query_Add.all_Parameter_Query_Conveyor(From_Name);//查询运输带类
                this.Valve = parameter_Query_Add.all_Parameter_Query_Valve(From_Name);//查询运输带类

                this.imageLists_1 = imageLists_1;//获取图库
                Load_Add(this.histogram);
                Load_Add(this.oscillogram);
                Load_Add(this.AnalogMeter);
                Load_Add(this.LedDisplay);
                Load_Add(this.ihatetheqrcode);
                Load_Add(this.function_key);
                Load_Add(this.RadioButton);
                Load_Add(this.pull_down_menu);
                Load_Add(this.HScrollBar);
                Load_Add(this.Conveyor);
                Load_Add(this.Valve);
            });
            Task.WaitAll(T, T1, T2);
            Load_Add(this.GroupBox);
            //改变控件上下层
            var T3 = Task.Run(() =>
            {
                Control_layer_EF layer_EF = new Control_layer_EF();//实例化最下层EF查询对象
                List<Control_layer> control_Layers = layer_EF.all_Parameter_Query_Control_layer(From_Name.Trim());//把查询到数据的保存
                for (int ix = 0; ix < 2; ix++)
                {
                    foreach (Control i in control)
                    {
                        for (int index = 0; index < control_Layers.Count; index++)
                        {
                            if (i.Name == control_Layers[index].type.Trim())
                                if (control_Layers[index].Upper_layer > 0)
                                    i.BringToFront();//将控件放置所有控件最顶层  
                                else
                                    i.SendToBack();//将控件放置所有控件最底层   
                        }
                    }
                }
            });
        }
        public From_Load_Add(string From_Name, ControlCollection control, List<ImageList> imageLists_1,Form form)
        {
            this.Form_event = form;
            this.imageLists_1 = imageLists_1;//获取图库
            this.control = control;
            Parameter_Query_Add parameter_Query_Add = new Parameter_Query_Add();//创建EF查询对象
            this.ScrollingText = parameter_Query_Add.all_Parameter_Query_ScrollingText(From_Name);//查询报警条类
            Load_Add(ScrollingText);
        }
        private void Load_Add(List<Button_Class> button_Classes)//填充按钮类
        {
            //遍历数组
            foreach (Button_Class add in button_Classes)
            {
                Button_reform reform = new Button_reform();//实例化按钮
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//设置文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(),add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
                reform.BaseColor = Color.FromName(add.colour_0.Trim());//设置样式
                reform.DownBaseColor = Color.FromName(add.colour_0.Trim());//设置样式
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<picture_Class> button_Classes)//填充图片类
        {
            //遍历数组
            foreach (picture_Class add in button_Classes)
            {
                SkinPictureBox_reform reform = new SkinPictureBox_reform();//实例化按钮
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.SizeMode= PictureBoxSizeMode.StretchImage;//显示图片方式
                reform.Image = imageLists_1[add.Control_state_0_list].Images[add.Control_state_0_picture];
                reform.Name = add.Control_type.Trim();//设置名称
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<label_Class> button_Classes)//填充标签类
        {
            //遍历数组
            foreach (label_Class add in button_Classes)
            {
                SkinLabel_reform reform = new SkinLabel_reform();//实例化按钮
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//填充文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<numerical_Class> button_Classes)//填充文本输入类
        {
            //遍历数组
            foreach (numerical_Class add in button_Classes)
            {
                SkinTextBox_reform reform = new SkinTextBox_reform();//实例化按钮
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = "0";//设置文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.TextAlign = HorizontalAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
                reform.BackColor = Color.FromName(add.colour_0.Trim());//获取数据库设置的颜色
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<Switch_Class> button_Classes)//填充切换开关类
        {
            //遍历数组
            foreach (Switch_Class add in button_Classes)
            {
                Switch_reform reform = new Switch_reform();//实例化按钮
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//设置文本
                reform.ButtonColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
                reform.BackColor = Color.FromName("Transparent");//填充背景颜色--默认
                reform.InActiveColor = Color.FromName(add.colour_0.Trim());//获取数据库中颜色名称进行设置
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<GroupBox_Class> button_Classes)//四边框类
        {
            //遍历数组
            foreach (GroupBox_Class add in button_Classes)
            {
                GroupBox_reform reform = new GroupBox_reform();//实例化按钮
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//填充文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(),FontStyle.Bold);//设置字体与大小
                reform.TitleAlignment = HorizontalAlignment.Center;//文本显示方式
                reform.Radius = 8;//圆角角度
                reform.RectColor = Color.FromName("Highlight");//边框颜色
                reform.FillColor = Color.FromName(add.colour_0.Trim());//获取数据库中颜色名称进行设置
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<LedBulb_Class> button_Classes)//填充指示灯类
        {
            //遍历数组
            foreach (LedBulb_Class add in button_Classes)
            {
                LedBulb_reform reform = new LedBulb_reform();//实例化按钮
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//设置文本
                reform.Color = Color.FromName(add.colour_0.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.BackColor = Color.FromName("Transparent");//填充背景颜色--默认
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<ImageButton_Class> button_Classes)//填充无图按钮类
        {
            //遍历数组
            foreach (ImageButton_Class add in button_Classes)
            {
                ImageButton_reform reform = new ImageButton_reform();//实例化按钮
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//设置文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
                reform.BackColor = Color.FromName("Transparent");//默认颜色
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<ScrollingText_Class> ScrollingText_Classes)//填充报警条类
        {
            //遍历数组
            foreach (ScrollingText_Class add in ScrollingText_Classes)
            {
                ScrollingText_reform reform = new ScrollingText_reform(Form_event);//实例化报警条
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//填充文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.Interval = 100;//文本刷新时间
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<doughnut_Chart_Class> doughnut_Chart_Classes)//填充圆形图条类
        {
            //遍历数组
            foreach (doughnut_Chart_Class add in doughnut_Chart_Classes)
            {
                doughnut_Chart_reform reform = new doughnut_Chart_reform();//实例化报警条
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.doughnut_Chart_Text = add.Control_state_0_content.Trim();//设置文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.color = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.doughnut_Chart_Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.doughnut_Chart_Data = point_or_Name(add.Name_Text.Trim());//获取用户设定通道名称
                reform.Load_number = add.通道数量 + 1;//加载个数
                reform.background_colo = Color.FromName(add.colour_0.Trim());//设置背景颜
                reform.doughnut_Chart_Load();//初次加载色
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<histogram_Chart_Class> doughnut_Chart_Classes)//填充柱形图条类
        {
            //遍历数组
            foreach (histogram_Chart_Class add in doughnut_Chart_Classes)
            {
                histogram_Chart_reform reform = new histogram_Chart_reform();//实例化报警条
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.headline = add.Control_state_0_content.Trim();//设置文本
                reform.colour = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.default_Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.x = point_or_Name(add.Name_Text.Trim()).ToArray();//获取用户设定通道名称
                reform.Load_number = (add.通道数量 + 1)*2;//加载个数
                reform.background_colo = Color.FromName(add.colour_0.Trim());//设置背景颜色
                reform.histogram_Chart_Load();//初次加载
                reform.histogram_Chart_refresh();//刷新UI
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<oscillogram_Chart_Class> doughnut_Chart_Classes)//折线图形图条类
        {
            //遍历数组
            foreach (oscillogram_Chart_Class add in doughnut_Chart_Classes)
            {
                oscillogram_Chart_reform reform = new oscillogram_Chart_reform();//实例化报警条
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.oscillogram_Chart_Name = add.Control_state_0_content.Trim();//设置文本
                reform.color = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.Chart_Minimum = add.Min;//设置最小值
                reform.Chart_Maximum =add.Max;//设置最大值
                reform.Chart_Interval = add.刷新时间;//设置刷新时间
                reform.waveform_ON =Convert.ToBoolean(add.折线图_曲线图);//获取用户设置
                reform.background_colo = Color.FromName(add.colour_0.Trim());//设置背景颜色
                reform.InitChart_load();//初次加载
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }

        public void Load_Add(List<AnalogMeter_Class> AnalogMeter_Classes)//百分百表盘类--参数修改
        {
            //遍历数组
            foreach (AnalogMeter_Class add in AnalogMeter_Classes)
            {
                AnalogMeter_reform reform = new AnalogMeter_reform();//实例化百分百表盘
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//设置文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
                //表盘属性
                reform.MaxValue = add.Max;//获取表盘最大值
                reform.MinValue = add.Min;//获取表盘最小值
                reform.BodyColor = Color.FromName(add.Control_state_0_colour.Trim());//获取表盘底色
                reform.NeedleColor = Color.FromName(add.Control_state_1_colour.Trim());//获取指针颜色
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        public void Load_Add(List<LedDisplay_Class> LedDisplay_Classes)//数值显示类--参数修改
        {
            //遍历数组
            foreach (LedDisplay_Class add in LedDisplay_Classes)
            {
                LedDisplay_reform reform = new LedDisplay_reform();//实例化数值显示
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = "0";//设置文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.TextAlign = HorizontalAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
                reform.BackColor = Color.FromName(add.colour_0.Trim());//获取数据库设置的颜色
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        public void Load_Add(List<ihatetheqrcode_Class> LedDisplay_Classes)//条形码/二维码类--参数修改
        {
            //遍历数组
            foreach (ihatetheqrcode_Class add in LedDisplay_Classes)
            {
                ihatetheqrcode_reform reform = new ihatetheqrcode_reform();//实例化数值显示
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.ihatetheqrcode_Size = new Size(point_or_Size(add.显示宽_高)[0], point_or_Size(add.显示宽_高)[1]);//设置生成图片大小
                reform.select = add.二维码_条形码;//设置是二维码还是条形码
                reform.Refresh_Data();//刷新生成图片二维码/条形码
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        public void Load_Add(List<function_key_Class> function_key_Classes)//功能键--参数修改
        {
            //遍历数组
            foreach (function_key_Class add in function_key_Classes)
            {
                function_key_reform reform = new function_key_reform();//实例化数值显示
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//填充文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.FillColor = Color.FromName(add.colour_0.Trim());//获取数据库中颜色名称进行设置
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<RadioButton_Class> button_Classes)//填充切换开关类
        {
            //遍历数组
            foreach (RadioButton_Class add in button_Classes)
            {
                RadioButton_reform reform = new RadioButton_reform();//实例化按钮
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//设置文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
                reform.BackColor = Color.FromName(add.colour_0.Trim());//获取数据库中颜色名称进行设置
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        private void Load_Add(List<pull_down_menu_Class> button_Classes)//填下拉菜单类
        {
            //遍历数组
            foreach (pull_down_menu_Class add in button_Classes)
            {
                pull_down_menu_reform reform = new pull_down_menu_reform();//实例化按钮
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//设置文本
                reform.BackColor = Color.FromName(add.选择背景.Trim());//默认背景颜色
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.DropBackColor = Color.FromName(add.下拉背景.Trim());//下拉颜色
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
                //开始查询数据库中的项目数据--进行遍历
                Parameter_Query_Add parameter_Query_Add = new Parameter_Query_Add();//创建EF查询对象
                List<pull_down_menuName> pull_Down_MenuNames = parameter_Query_Add.all_Parameter_Query_pull_down_menuName(reform.Parent+"-" + reform.Name);
                foreach (pull_down_menuName i in pull_Down_MenuNames)
                    reform.Items.Add(i.项目资料.Trim());
                reform.SelectedIndex = 0;
                reform.SelectedItem = 0;
            }
        }
        public void Load_Add(List<HScrollBar_Class> HScrollBar_Classes)//移动图形类--参数修改
        {
            //遍历数组
            foreach (HScrollBar_Class add in HScrollBar_Classes)
            {
                HScrollBar_reform reform = new HScrollBar_reform();//实例化百分百表盘
                reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                reform.Name = add.Control_type.Trim();//设置名称
                reform.Text = add.Control_state_0_content.Trim();//设置文本
                reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                //图形属性
                reform.Maximum = add.Max;//获取最大值
                reform.Minimum = add.Min;//获取最小值
                reform.SkinBackColor = Color.FromName(add.Control_state_0_colour.Trim());//获取底色
                reform.BorderColor = Color.FromName(add.Control_state_1_colour.Trim());//获取颜色
                Form_event.BeginInvoke((EventHandler)delegate { control.Add(reform); });
            }
        }
        public void Load_Add(List<Conveyor_Class> Conveyor_Classes)//运输带类--参数修改
        {
            //遍历数组
            foreach (Conveyor_Class add in Conveyor_Classes)
            {
                Form_event.BeginInvoke((EventHandler)delegate
                {
                    Conveyor_reform reform = new Conveyor_reform();//实例化百分百表盘
                    reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                    reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                    reform.Name = add.Control_type.Trim();//设置名称
                    reform.Text = add.Control_state_0_content.Trim();//设置文本
                    reform.ForeColor = Color.FromName("ControlText");//获取数据库中颜色名称进行设置
                    reform.BackColor = Color.FromName("Transparent");
                    reform.BackgroundImageLayout = ImageLayout.Tile;
                    reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                    //图形属性
                    reform.ConveyorColor = Color.FromName(add.运输带颜色.Trim());
                    reform.ConveyorDirection = Enumeration<ConveyorDirection>(add.运输带方向.Trim());
                    reform.ConveyorHeight = add.运输带高度;
                    reform.ConveyorSpeed = add.运输带速度;
                    reform.Inclination = add.运输带角度;
                    control.Add(reform);
                });
            }
        }
        public void Load_Add(List<Valve_Class> Valve_Classes)//液体阀门类--参数修改
        {
            //遍历数组
            foreach (Valve_Class add in Valve_Classes)
            {
                Form_event.BeginInvoke((EventHandler)delegate
                {
                    Valve_reform reform = new Valve_reform();//实例化百分百表盘
                    reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
                    reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
                    reform.Name = add.Control_type.Trim();//设置名称
                    reform.Text = add.Control_state_0_content.Trim();//设置文本
                    reform.ForeColor = Color.FromName("ActiveBorder");//获取数据库中颜色名称进行设置
                    reform.BackColor = Color.FromName("ActiveBorder");
                    reform.BackgroundImageLayout = ImageLayout.Tile;
                    reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                    //图形属性
                    reform.AsisBottomColor = Color.FromName(add.轴底座颜色.Trim());
                    reform.AxisColor = Color.FromName(add.轴颜色.Trim());
                    reform.LiquidColor = Color.FromName(add.液体颜色.Trim());
                    reform.LiquidDirection = Enumeration<LiquidDirection>(add.液体流动方向.Trim());
                    reform.LiquidSpeed = add.液体流速;
                    reform.Opened = Convert.ToBoolean(add.阀门);
                    reform.SwitchColor = Color.FromName(add.开关把手颜色.Trim());
                    reform.ValveColor = Color.FromName(add.阀门颜色.Trim());
                    reform.ValveStyle = Enumeration<ValveStyle>(add.阀门样式.Trim());
                    control.Add(reform);
                });
            }
        }
        private System.Drawing.ContentAlignment ContentAlignment_1(string Name)//获取字体的对齐方式--按钮-文本类
        {
            System.Drawing.ContentAlignment contentAlignment=System.Drawing.ContentAlignment.MiddleCenter;//定义对齐方式
            switch(Name.Trim())
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
        private PropertyInfo PropertyInfo(string Colo_Name)//获取系统颜色--遍历颜色--弃用保留代码
        {
            PropertyInfo[] propInfoList = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                if (Colo_Name.Trim().Equals(c.Name)) return c;//返回数据
            }
            return propInfoList[0];//如果查询失败返回默认
        }
        private ConveyorDirection ConveyorDirection(string Name)
        {
            ConveyorDirection Direction = HZH_Controls.Controls.ConveyorDirection.Forward;
            switch (Name.Trim())
            {
                case "None":
                    Direction = HZH_Controls.Controls.ConveyorDirection.None;
                    break;
                case "Forward":
                    Direction = HZH_Controls.Controls.ConveyorDirection.Forward;
                    break;
                case "Backward":
                    Direction = HZH_Controls.Controls.ConveyorDirection.Backward;
                    break;
            }
            return Direction;//返回数据
        }
        private T Enumeration<T>(string Name)
        {
            foreach (var suit in Enum.GetValues(typeof(T)))
            {
                if (suit.ToString() == Name.Trim())
                    return (T)suit;
            }
            return (T)Enum.GetValues(typeof(T)).GetValue(0);
        }
        private int[] point_or_Size(string Name)//分割-来自数据库的-位置与大小数据
        {
            string[] segmentation;//定义分割数组
            try
            {
                segmentation = Name.Split('-');
                return new int[] { Convert.ToInt32(segmentation[0] ?? "81"), Convert.ToInt32(segmentation[1] ?? "31") };
            }
            catch(Exception Err)
            {
                MessageBox.Show(Err.Message, "Err");
                return new int[] { Convert.ToInt32(81), Convert.ToInt32(31) };
            }
        }
        private List<string> point_or_Name(string Name)//分割-来自数据库的-用户设定名称
        {
            string[] segmentation;//定义分割数组
            segmentation = Name.Split('-');
            List<string> data = new List<string>();
            foreach (var i in segmentation) data.Add(i);
            if (segmentation.Length < 5) for (int i = segmentation.Length; i < data.Count; i++) data.Add("数据" + i);//补全数据
            return data;
        }
        //这里实现IDisposable 接口
        public From_Load_Add()
        {
            Dispose(false);
        }
        //是否回收完毕
        bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);//终结者序列
        }
        //这里的参数表示示是否需要释放那些实现IDisposable接口的托管对象
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return; //如果已经被回收，就中断执行
            if (disposing)
            {
                //TODO:释放那些实现IDisposable接口的托管对象
                skinButtons.Clear();
                skinpicture.Clear();
                skinlabel.Clear();
                skinnumerical.Clear();
                Switch.Clear();
                LedBulb.Clear();
                GroupBox.Clear();
                ImageButton.Clear();
                ScrollingText.Clear();
                doughnut.Clear();
                histogram.Clear();
                oscillogram.Clear();
                AnalogMeter.Clear();
                LedDisplay.Clear();
                ihatetheqrcode.Clear();
                RadioButton.Clear();
                pull_down_menu.Clear();
                HScrollBar.Clear();
                imageLists_1.Clear();
                Conveyor.Clear();
            }
            //TODO:释放非托管资源，设置对象为null
            _disposed = true;
        }
    }
}
