using CCWin.SkinClass;
using CCWin.SkinControl;
using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.控件重做;
using 自定义Uppercomputer_20200727.控件重做.工业图形控件;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    /// <本类用于处理修控件的通用属性修改-文字样式--文字大小--文字对齐--等>       
    class Public_attributeCalss
    {
        public void attributeCalss(Button_reform reform, Button_Class add)//按钮类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = add.Control_state_0_content.Trim();//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
            reform.BaseColor = Color.FromName(add.colour_0.Trim());//设置样式
            reform.DownBaseColor = Color.FromName(add.colour_0.Trim());//设置样式
        }
        public void attributeCalss(SkinLabel_reform reform, label_Class add)//系统标签类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = add.Control_state_0_content.Trim();//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
        }
        public void attributeCalss(SkinTextBox_reform reform, numerical_Class add)//文本输入类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = "0";//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            reform.TextAlign = HorizontalAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
            reform.BackColor = Color.FromName(add.colour_0.Trim());//获取数据库设置的颜色
        }
        public void attributeCalss(Switch_reform reform, Switch_Class add)//切换开关类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = add.Control_state_0_content.Trim();//设置文本
            reform.ButtonColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
            reform.BackColor = Color.FromName("182, 182, 182");//填充背景颜色--默认
            reform.InActiveColor = Color.FromName(add.colour_0.Trim());//获取数据库中颜色名称进行设置
        }
        public void attributeCalss(LedBulb_reform reform, LedBulb_Class add)//指示灯类类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = add.Control_state_0_content.Trim();//设置文本
            reform.Color = Color.FromName(add.colour_0.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小    
            reform.BackColor = Color.FromName("182, 182, 182");//填充背景颜色--默认
        }
        public void attributeCalss(GroupBox_reform reform, GroupBox_Class add)//四边形方框类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = add.Control_state_0_content.Trim();//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            reform.TitleAlignment = HorizontalAlignment.Center;//文本显示方式
            reform.Radius = 8;//圆角角度
            reform.RectColor = Color.FromName("Highlight");//边框颜色
            reform.FillColor = Color.FromName(add.colour_0.Trim());//获取数据库中颜色名称进行设置
        }
        public void attributeCalss(ImageButton_reform reform, ImageButton_Class add)//无图片按钮类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = add.Control_state_0_content.Trim();//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
            reform.BackColor = Color.FromName("Transparent");//默认颜色
        }
        public void attributeCalss(ScrollingText_reform reform, ScrollingText_Class add)//文本输入类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = "0";//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
        }
        public void attributeCalss(doughnut_Chart_reform reform, doughnut_Chart_Class add)//图形类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Name = add.Control_type.Trim();//设置名称
            reform.doughnut_Chart_Text = add.Control_state_0_content.Trim();//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.color = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.doughnut_Chart_Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小   
            reform.background_colo = Color.FromName(add.colour_0.Trim());//设置背景颜色
            reform.doughnut_Chart_Load();//初次加载UI
        }
        public void attributeCalss(histogram_Chart_reform reform, histogram_Chart_Class add)//图形类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Name = add.Control_type.Trim();//设置名称
            reform.headline = add.Control_state_0_content.Trim();//设置文本
            reform.colour = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.default_Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小   
            reform.background_colo = Color.FromName(add.colour_0.Trim());//设置背景颜色
            reform.histogram_Chart_refresh();//初次加载UI
        }
        public void attributeCalss(oscillogram_Chart_reform reform, oscillogram_Chart_Class add)//图形类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Name = add.Control_type.Trim();//设置名称
            reform.oscillogram_Chart_Name = add.Control_state_0_content.Trim();//设置文本
            reform.color = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小 
            reform.background_colo = Color.FromName(add.colour_0.Trim());//设置背景颜色
            reform.InitChart_load();//初次加载UI
        }
        public void AnalogMeter(AnalogMeter_reform reform, AnalogMeter_Class add)//百分百表盘类--参数修改
        {
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
        }
        public void LedDisplay(LedDisplay_reform reform, LedDisplay_Class add)//数值显示类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = "0";//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            reform.TextAlign = HorizontalAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
            reform.BackColor = Color.FromName(add.colour_0.Trim());//获取数据库设置的颜色
        }
        public void ihatetheqrcode(ihatetheqrcode_reform reform, ihatetheqrcode_Class add)//二维码/条形码类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = add.Control_state_0_content.Trim();//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            reform.ihatetheqrcode_Size = new Size(point_or_Size(add.显示宽_高)[0], point_or_Size(add.显示宽_高)[1]);//设置生成图片大小
            reform.select = add.二维码_条形码;//设置是二维码还是条形码
            reform.Refresh_Data();//刷新生成图片二维码/条形码
        }
        public void attributeCalss(function_key_reform reform, function_key_Class add)//文本输入类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = add.Control_state_0_content.Trim();//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            reform.FillColor= Color.FromName(add.colour_0.Trim());//获取数据库中颜色名称进行设置
        }
        public void attributeCalss(RadioButton_reform reform, RadioButton_Class add)//切换开关类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = add.Control_state_0_content.Trim();//设置文本
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            reform.TextAlign = ContentAlignment_1(add.Control_state_0_aligning.Trim());//设置对齐方式
            reform.BackColor = Color.FromName("182, 182, 182");//填充背景颜色--默认
            reform.BackColor = Color.FromName(add.colour_0.Trim());//获取数据库中颜色名称进行设置
        }
        public void attributeCalss(pull_down_menu_reform reform, pull_down_menu_Class add)//切换开关类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.BackColor = Color.FromName(add.选择背景.Trim());//默认背景颜色
            reform.ForeColor = Color.FromName(add.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
            reform.DropBackColor = Color.FromName(add.下拉背景.Trim());//下拉颜色
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
        }
        public void HScrollBar(HScrollBar_reform reform, HScrollBar_Class add)//纵向移动图形类--参数修改
        {
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
        }
        public void Conveyor(Conveyor_reform reform, Conveyor_Class add)//百分百表盘类--参数修改
        {
            reform.Size = new Size(point_or_Size(add.size)[0], point_or_Size(add.size)[1]);//设置大小
            reform.Location = new Point(point_or_Size(add.location)[0], point_or_Size(add.location)[1]);//设置按钮位置
            reform.Name = add.Control_type.Trim();//设置名称
            reform.Text = add.Control_state_0_content.Trim();//设置文本
            reform.ForeColor = Color.FromName("ActiveBorder");//获取数据库中颜色名称进行设置
            reform.BackColor = Color.FromName("ActiveBorder");
            reform.BackgroundImageLayout = ImageLayout.Tile;
            reform.Font = new Font(add.Control_state_0_typeface.Trim(), add.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
            //图形属性
            reform.ConveyorColor = Color.FromName(add.运输带颜色.Trim());
            reform.ConveyorDirection = ConveyorDirection(add.运输带方向.Trim());
            reform.ConveyorHeight = add.运输带高度;
            reform.ConveyorSpeed = add.运输带速度;
            reform.Inclination = add.运输带角度;
        }
        public void Valve(Valve_reform reform, Valve_Class add)//百分百表盘类--参数修改
        {
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
            reform.ValveStyle= Enumeration<ValveStyle>(add.阀门样式.Trim());

        }
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
                MessageBox.Show(Err.Message, "Err");//写入异常
                return new int[] { Convert.ToInt32(81), Convert.ToInt32(31) };
            }
        }
    }
}
