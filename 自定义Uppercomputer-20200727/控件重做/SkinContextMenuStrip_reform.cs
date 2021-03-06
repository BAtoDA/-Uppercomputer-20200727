﻿using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.EF实体模型.EFtoSQL操作类重写;
using 自定义Uppercomputer_20200727.EF实体模型.工业图形控件参数;
using 自定义Uppercomputer_20200727.Nlog;
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.修改参数界面.AnalogMeter百分百表盘参数;
using 自定义Uppercomputer_20200727.修改参数界面.doughnut_Chart图形控件参数;
using 自定义Uppercomputer_20200727.修改参数界面.function_key功能键参数;
using 自定义Uppercomputer_20200727.修改参数界面.GroupBox四边形方框;
using 自定义Uppercomputer_20200727.修改参数界面.histogram_Chart柱形图控件参数;
using 自定义Uppercomputer_20200727.修改参数界面.HScrollBar移动图形参数;
using 自定义Uppercomputer_20200727.修改参数界面.ihatetheqrcode二维码与条形码控件参数;
using 自定义Uppercomputer_20200727.修改参数界面.ImageButton按钮参数;
using 自定义Uppercomputer_20200727.修改参数界面.LedBulb_指示灯参数;
using 自定义Uppercomputer_20200727.修改参数界面.LedDisplay数值显示参数;
using 自定义Uppercomputer_20200727.修改参数界面.oscillogram_Chart折线图波形图参数;
using 自定义Uppercomputer_20200727.修改参数界面.RadioButton单选按钮参数;
using 自定义Uppercomputer_20200727.修改参数界面.工业图形汇总;
using 自定义Uppercomputer_20200727.修改参数界面.报警条参数;
using 自定义Uppercomputer_20200727.控件重做.工业图形控件;
using 自定义Uppercomputer_20200727.控件重做.获取控件的全部属性;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 本类主要重写右键菜单
    /// </summary>
    [ToolboxItem(false)]
    class SkinContextMenuStrip_reform : SkinContextMenuStrip
    {
        /// <本类主要重写右键菜单的属性-事件-等>
        public string SkinContextMenuStrip_Button_ID { get; set; }//定义控件的ID
        public string SkinContextMenuStrip_Button_type { get; set; }//定义控件的类型
        public object all_purpose { get; set; }//定义通用类型_修改参数传递使用
        ToolStripMenuItem toolStrip, toolStrip_4, toolStrip_1, toolStrip_2, toolStrip_3;

        [Obsolete]
        public SkinContextMenuStrip_reform()//构造函数
        {
            /// <写入相应参数>
            toolStrip = new ToolStripMenuItem();
            toolStrip.Text = "修改参数";
            this.Items.Add(toolStrip);
            this.Back = Color.LightGray;
            toolStrip.Margin = new Padding(0, 5, 0, 5);
            toolStrip.Click += toolStrip_Click_reform;//注册修改参数事件
            //查看控件属性
            toolStrip_4 = new ToolStripMenuItem();
            toolStrip_4.Text = "查看属性";
            this.Items.Add(toolStrip_4);
            toolStrip_4.Margin = new Padding(0, 5, 0, 5);
            toolStrip_4.Click += toolStrip_Click_reform_4;//注册修改参数事件
            /// <移除控件>
            toolStrip_1 = new ToolStripMenuItem();
            toolStrip_1.Text = "移除控件";
            this.Items.Add(toolStrip_1);
            toolStrip_1.Margin = new Padding(0, 5, 0, 5);
            toolStrip_1.Click += toolStrip_Click_reform_1;//注册修改参数事件
            ///<把控件移到最上层>
            toolStrip_2 = new ToolStripMenuItem();
            toolStrip_2.Text = "控件最上层";
            this.Items.Add(toolStrip_2);
            toolStrip_2.Margin = new Padding(0, 5, 0, 5);
            toolStrip_2.Click += stratosphere;//注册修改参数事件
            ///<把控件移到最下层>
            toolStrip_3 = new ToolStripMenuItem();
            toolStrip_3.Text = "控件最下层";
            this.Items.Add(toolStrip_3);
            toolStrip_3.Margin = new Padding(0, 5, 0, 5);
            toolStrip_3.Click += orlop;//注册修改参数事件
            this.Margin = new Padding(0, 5, 0, 5);

        }
        /// <本方法重写右键点击菜单事件--触发相应修改参数操作>
        public void toolStrip_Click_reform(object sender, EventArgs e)
        {
            //LogUtils日志
            LogUtils.debugWrite($"用户执行了：{((Control)this.all_purpose).Name} 参数修改");
            switch (SkinContextMenuStrip_Button_type)//判断传递父级的类型
            {
                case "Button_reform":
                    Modification_Button modification = new Modification_Button(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    modification.ShowDialog();//弹出修改参数窗口
                    break;
                case "SkinLabel_reform":
                    Modification_label modification_Label = new Modification_label(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    modification_Label.ShowDialog();//弹出修改参数窗口
                    break;
                case "SkinTextBox_reform":
                    Modification_numerical modification_Numerical = new Modification_numerical(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    modification_Numerical.ShowDialog();//弹出修改参数窗口
                    ((SkinTextBox_reform)all_purpose).Text = "0";//修改完成初始化数据
                    break;
                case "SkinPictureBox_reform":
                    Modification_picture modification_Picture = new Modification_picture(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    modification_Picture.ShowDialog();//弹出修改参数窗口
                    break;
                case "Switch_reform":
                    Modification_Switch Switch = new Modification_Switch(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    Switch.ShowDialog();//弹出修改参数窗口
                    break;
                case "LedBulb_reform":
                    Modification_Ledbulb Ledbulb = new Modification_Ledbulb(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    Ledbulb.ShowDialog();//弹出修改参数窗口
                    break;
                case "GroupBox_reform":
                    Modification_GroupBox GroupBox = new Modification_GroupBox(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    GroupBox.ShowDialog();//弹出修改参数窗口
                    break;
                case "ImageButton_reform":
                    Modification_ImageButton ImageButton = new Modification_ImageButton(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    ImageButton.ShowDialog();//弹出修改参数窗口
                    break;
                case "ScrollingText_reform":
                    Modification_ScrollingText ScrollingText_reform = new Modification_ScrollingText(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    ScrollingText_reform.ShowDialog();//弹出修改参数窗口
                    break;
                case "doughnut_Chart_reform":
                    Modification_doughnut_Chart doughnut_Chart_reform = new Modification_doughnut_Chart(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    doughnut_Chart_reform.ShowDialog();//弹出修改参数窗口
                    break;
                case "histogram_Chart_reform":
                    Modification_histogram_Chart histogram_Chart_reform = new Modification_histogram_Chart(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    histogram_Chart_reform.ShowDialog();//弹出修改参数窗口
                    break;
                case "oscillogram_Chart_reform":
                    Modification_oscillogram_Chart oscillogram_Chart_reform = new Modification_oscillogram_Chart(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    oscillogram_Chart_reform.ShowDialog();//弹出修改参数窗口
                    break;
                case "AnalogMeter_reform":
                    Modification_AnalogMeter AnalogMeter = new Modification_AnalogMeter(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    AnalogMeter.ShowDialog();//弹出修改参数窗口
                    break;
                case "LedDisplay_reform":
                    Modification_LedDisplay LedDisplay = new Modification_LedDisplay(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    LedDisplay.ShowDialog();//弹出修改参数窗口
                    break;
                case "ihatetheqrcode_reform":
                    Modification_ihatetheqrcode ihatetheqrcode = new Modification_ihatetheqrcode(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    ihatetheqrcode.ShowDialog();//弹出修改参数窗口
                    break;
                case "function_key_reform":
                    Modification_function_key function_key = new Modification_function_key(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    function_key.ShowDialog();//弹出修改参数窗口
                    break;
                case "RadioButton_reform":
                    Modification_RadioButton RadioButton = new Modification_RadioButton(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    RadioButton.ShowDialog();//弹出修改参数窗口
                    break;
                case "pull_down_menu_reform":
                    Modification_pull_down_menu pull_down_menu = new Modification_pull_down_menu(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    pull_down_menu.ShowDialog();//弹出修改参数窗口
                    break;
                case "HScrollBar_reform":
                    Modification_HScrollBar HScrollBar = new Modification_HScrollBar(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    HScrollBar.ShowDialog();//弹出修改参数窗口
                    break;
                case "Conveyor_reform":
                    Modification_Conveyor Conveyor = new Modification_Conveyor(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    Conveyor.ShowDialog();//弹出修改参数窗口
                    break;
                case "Valve_reform":
                    Modification_Valve Valve = new Modification_Valve(SkinContextMenuStrip_Button_ID, this.all_purpose);//弹出修改参数传递
                    Valve.ShowDialog();//弹出修改参数窗口
                    break;
            }
            //LogUtils日志
            LogUtils.debugWrite($"用户修改了：{((Control)this.all_purpose).Name} 控件参数完成" );
        }
        /// <本方法重写右键点击菜单事件--触发移除控件操作>
        [Obsolete]
        private void toolStrip_Click_reform_1(object sender, EventArgs e)
        {
            switch (SkinContextMenuStrip_Button_type)//判断传递父级的类型
            {
                case "Button_reform":
                    if (MessageBox.Show("确定要删除" + ((Button_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((Button_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase button_EF = new Button_EFbase();//实例化EF对象
                    button_EF.Button_Parameter_delete<Button_parameter, Tag_common_parameters, General_parameters_of_picture, control_location, Control_layer, Button_colour>(SkinContextMenuStrip_Button_ID + "-" + ((Button_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "SkinLabel_reform":
                    if (MessageBox.Show("确定要删除" + ((SkinLabel)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((SkinLabel)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase label_EF = new Button_EFbase();//实例化EF对象
                    label_EF.Button_Parameter_delete<label_parameter, Tag_common_parameters, control_location, Control_layer>(SkinContextMenuStrip_Button_ID + "-" + ((SkinLabel)all_purpose).Name);//执行SQL删除操作
                    break;
                case "SkinTextBox_reform":
                    if (MessageBox.Show("确定要删除" + ((SkinTextBox_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((SkinTextBox_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase numerical_EF = new Button_EFbase();//实例化EF对象
                    numerical_EF.Button_Parameter_delete<numerical_parameter, Tag_common_parameters, General_parameters_of_picture, control_location, Control_layer, Button_colour>(SkinContextMenuStrip_Button_ID + "- " + ((SkinTextBox_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "SkinPictureBox_reform":
                    if (MessageBox.Show("确定要删除" + ((SkinPictureBox)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((SkinPictureBox)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase picture_EF = new Button_EFbase();//实例化EF对象
                    picture_EF.Button_Parameter_delete<picture_parameter, General_parameters_of_picture, control_location, Control_layer>(SkinContextMenuStrip_Button_ID + "-" + ((SkinPictureBox)all_purpose).Name);//执行SQL删除操作
                    break;
                case "Switch_reform":
                    if (MessageBox.Show("确定要删除" + ((Switch_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((Switch_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase Switch_EF = new Button_EFbase();//实例化EF对象
                    Switch_EF.Button_Parameter_delete<Switch_parameter, Tag_common_parameters, General_parameters_of_picture, control_location, Control_layer, Button_colour>(SkinContextMenuStrip_Button_ID + "-" + ((Switch_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "LedBulb_reform":
                    if (MessageBox.Show("确定要删除" + ((LedBulb_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((LedBulb_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase LedBulb_EF = new Button_EFbase();//实例化EF对象
                    LedBulb_EF.Button_Parameter_delete<LedBulb_parameter, Tag_common_parameters, General_parameters_of_picture, control_location, Control_layer, Button_colour>(SkinContextMenuStrip_Button_ID + "-" + ((LedBulb_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "GroupBox_reform":
                    if (MessageBox.Show("确定要删除" + ((GroupBox_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((GroupBox_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase GroupBox_EF = new Button_EFbase();//实例化EF对象
                    GroupBox_EF.Button_Parameter_delete<GroupBox_parameter, Tag_common_parameters, control_location, Control_layer, Button_colour>(SkinContextMenuStrip_Button_ID + "-" + ((GroupBox_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "ImageButton_reform":
                    if (MessageBox.Show("确定要删除" + ((ImageButton_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((ImageButton_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase ImageButton_EF = new Button_EFbase();//实例化EF对象
                    ImageButton_EF.Button_Parameter_delete<ImageButton_parameter, Tag_common_parameters ,
             General_parameters_of_picture , control_location, Control_layer> (SkinContextMenuStrip_Button_ID + "-" + ((ImageButton_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "ScrollingText_reform":
                    if (MessageBox.Show("确定要删除" + ((ScrollingText_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((ScrollingText_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase ScrollingText_EF = new Button_EFbase();//实例化EF对象
                    ScrollingText_EF.Button_Parameter_delete<ScrollingText_parameter, Tag_common_parameters, control_location, Control_layer>(SkinContextMenuStrip_Button_ID + "-" + ((ScrollingText_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "doughnut_Chart_reform":
                    if (MessageBox.Show("确定要删除" + ((doughnut_Chart_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((doughnut_Chart_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase doughnut_Chart_EF = new Button_EFbase();//实例化EF对象
                    doughnut_Chart_EF.Button_Parameter_delete<doughnut_Chart_parameter, Tag_common_parameters, control_location, Control_layer, Button_colour>(SkinContextMenuStrip_Button_ID + "- " + ((doughnut_Chart_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "histogram_Chart_reform":
                    if (MessageBox.Show("确定要删除" + ((histogram_Chart_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((histogram_Chart_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase histogram_Chart_EF = new Button_EFbase();//实例化EF对象
                    histogram_Chart_EF.Button_Parameter_delete<histogram_Chart_parameter, Tag_common_parameters, control_location, Control_layer, Button_colour>(SkinContextMenuStrip_Button_ID + "- " + ((histogram_Chart_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "oscillogram_Chart_reform":
                    if (MessageBox.Show("确定要删除" + ((oscillogram_Chart_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((oscillogram_Chart_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase oscillogram_Chart_EF = new Button_EFbase();//实例化EF对象
                    oscillogram_Chart_EF.Button_Parameter_delete<oscillogram_Chart_parameter, Tag_common_parameters, control_location, Control_layer, Button_colour>(SkinContextMenuStrip_Button_ID + "- " + ((oscillogram_Chart_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "AnalogMeter_reform":
                    if (MessageBox.Show("确定要删除" + ((AnalogMeter_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((AnalogMeter_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase AnalogMeter_EF = new Button_EFbase();//实例化EF对象
                    AnalogMeter_EF.Button_Parameter_delete<AnalogMeter_parameter, Tag_common_parameters, control_location>(SkinContextMenuStrip_Button_ID + "- " + ((AnalogMeter_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "LedDisplay_reform":
                    if (MessageBox.Show("确定要删除" + ((LedDisplay_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((LedDisplay_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase LedDisplay_EF = new Button_EFbase();//实例化EF对象
                    LedDisplay_EF.Button_Parameter_delete<LedDisplay_parameter, Tag_common_parameters, General_parameters_of_picture, control_location, Control_layer, Button_colour>(SkinContextMenuStrip_Button_ID + "- " + ((LedDisplay_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "ihatetheqrcode_reform":
                    if (MessageBox.Show("确定要删除" + ((ihatetheqrcode_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((ihatetheqrcode_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase ihatetheqrcode_EF = new Button_EFbase();//实例化EF对象
                    ihatetheqrcode_EF.Button_Parameter_delete<ihatetheqrcode_parameter, Tag_common_parameters, General_parameters_of_picture, control_location, Control_layer>(SkinContextMenuStrip_Button_ID + "- " + ((ihatetheqrcode_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "function_key_reform":
                    if (MessageBox.Show("确定要移除功能键吗？--移除前请确认跳转的页面是否存在更深层次的功能键,请先移除该功能键在移除当前功能键--否则无法彻底删除数据库的所有信息！！", "Err：移除前确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    if (MessageBox.Show("确定要删除" + ((function_key_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((function_key_reform)all_purpose).Visible = false;//隐藏控件
                    function_key_EF function_key_EF = new function_key_EF();//实例化EF对象
                    function_key_EF.function_key_Parameter_delete(SkinContextMenuStrip_Button_ID + "-" + ((function_key_reform)all_purpose).Name);//执行SQL删除操作
                    //还需要外加一段--遍历全部数据FORM是否符合的全部删除
                    function_key_EF.function_key_Parameter_Remove(((function_key_reform)all_purpose).Name);//删除所有在该窗口控件的信息
                    break;
                case "RadioButton_reform":
                    if (MessageBox.Show("确定要删除" + ((RadioButton_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((RadioButton_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase RadioButton_EF = new Button_EFbase();//实例化EF对象
                    RadioButton_EF.Button_Parameter_delete<RadioButton_parameter, Tag_common_parameters, General_parameters_of_picture, control_location, Control_layer, Button_colour>(SkinContextMenuStrip_Button_ID + "-" + ((RadioButton_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "pull_down_menu_reform":
                    if (MessageBox.Show("确定要删除" + ((pull_down_menu_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((pull_down_menu_reform)all_purpose).Visible = false;//隐藏控件
                    pull_down_menu_EF pull_down_menu_EF = new pull_down_menu_EF();//实例化EF对象
                    pull_down_menu_EF.pull_down_menu_Parameter_delete(SkinContextMenuStrip_Button_ID + "-" + ((pull_down_menu_reform)all_purpose).Name, SkinContextMenuStrip_Button_ID + "-" + ((pull_down_menu_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "HScrollBar_reform":
                    if (MessageBox.Show("确定要删除" + ((HScrollBar_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((HScrollBar_reform)all_purpose).Visible = false;//隐藏控件
                    Button_EFbase HScrollBar_EF = new Button_EFbase();//实例化EF对象
                    HScrollBar_EF.Button_Parameter_delete<HScrollBar_parameter, Tag_common_parameters, control_location>(SkinContextMenuStrip_Button_ID + "- " + ((HScrollBar_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "Conveyor_reform":
                    if (MessageBox.Show("确定要删除" + ((Conveyor_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((Conveyor_reform)all_purpose).Visible = false;//隐藏控件
                    Conveyor_EF Conveyor_F = new Conveyor_EF();//实例化EF对象
                    Conveyor_F.Conveyor_Parameter_delete(SkinContextMenuStrip_Button_ID + "- " + ((Conveyor_reform)all_purpose).Name);//执行SQL删除操作
                    break;
                case "Valve_reform":
                    if (MessageBox.Show("确定要删除" + ((Valve_reform)all_purpose).Name.Trim() + "吗？", "错误：", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    ((Valve_reform)all_purpose).Visible = false;//隐藏控件
                    Valve_EF Valve_F = new Valve_EF();//实例化EF对象
                    Valve_F.Valve_Parameter_delete(SkinContextMenuStrip_Button_ID + "- " + ((Valve_reform)all_purpose).Name);//执行SQL删除操作
                    break;
            }
            //LogUtils日志
            LogUtils.debugWrite($"用户删除了：{((Control)this.all_purpose).Name} 控件");
        }
        /// <summary>2Q
        /// 控件最上层选择
        /// </summary>
        private void stratosphere(object send, EventArgs e)
        {
            Control_layer_EF layer_EF = new Control_layer_EF();//实例化最下层EF查询对象
            switch (SkinContextMenuStrip_Button_type)//判断传递父级的类型
            {
                case "Button_reform":
                    ((Button_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层  
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((Button_reform)all_purpose).Name, ((Button_reform)all_purpose).Name, 1);
                    break;
                case "SkinLabel_reform":
                    ((SkinLabel_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层     
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((SkinLabel_reform)all_purpose).Name, ((SkinLabel_reform)all_purpose).Name, 1);
                    break;
                case "SkinTextBox_reform":
                    ((SkinTextBox_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层     
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((SkinTextBox_reform)all_purpose).Name, ((SkinTextBox_reform)all_purpose).Name, 1);
                    break;
                case "SkinPictureBox_reform":
                    ((SkinPictureBox_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((SkinPictureBox_reform)all_purpose).Name, ((SkinPictureBox_reform)all_purpose).Name, 1);
                    break;
                case "Switch_reform":
                    ((Switch_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层  
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((Switch_reform)all_purpose).Name, ((Switch_reform)all_purpose).Name, 1);
                    break;
                case "LedBulb_reform":
                    ((LedBulb_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层    
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((LedBulb_reform)all_purpose).Name, ((LedBulb_reform)all_purpose).Name, 1);
                    break;
                case "GroupBox_reform":
                    ((GroupBox_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((GroupBox_reform)all_purpose).Name, ((GroupBox_reform)all_purpose).Name, 1);
                    break;
                case "ImageButton_reform":
                    ((ImageButton_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((ImageButton_reform)all_purpose).Name, ((ImageButton_reform)all_purpose).Name, 1);
                    break;
                case "ScrollingText_reform":
                    ((ScrollingText_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层  
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((ScrollingText_reform)all_purpose).Name, ((ScrollingText_reform)all_purpose).Name, 1);
                    break;
                case "doughnut_Chart_reform":
                    ((doughnut_Chart_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((doughnut_Chart_reform)all_purpose).Name, ((doughnut_Chart_reform)all_purpose).Name, 1);
                    break;
                case "histogram_Chart_reform":
                    ((histogram_Chart_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((histogram_Chart_reform)all_purpose).Name, ((histogram_Chart_reform)all_purpose).Name, 1);
                    break;
                case "oscillogram_Chart_reform":
                    ((oscillogram_Chart_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((oscillogram_Chart_reform)all_purpose).Name, ((oscillogram_Chart_reform)all_purpose).Name, 1);
                    break;
                case "AnalogMeter_reform":
                    ((AnalogMeter_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((AnalogMeter_reform)all_purpose).Name, ((AnalogMeter_reform)all_purpose).Name, 1);
                    break;
                case "LedDisplay_reform":
                    ((LedDisplay_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((LedDisplay_reform)all_purpose).Name, ((LedDisplay_reform)all_purpose).Name, 1);
                    break;
                case "ihatetheqrcode_reform":
                    ((ihatetheqrcode_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((ihatetheqrcode_reform)all_purpose).Name, ((ihatetheqrcode_reform)all_purpose).Name, 1);
                    break;
                case "function_key_reform":
                    ((function_key_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((function_key_reform)all_purpose).Name, ((function_key_reform)all_purpose).Name, 1);
                    break;
                case "RadioButton_reform":
                    ((RadioButton_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((RadioButton_reform)all_purpose).Name, ((RadioButton_reform)all_purpose).Name, 1);
                    break;
                case "pull_down_menu_reform":
                    ((pull_down_menu_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((pull_down_menu_reform)all_purpose).Name, ((pull_down_menu_reform)all_purpose).Name, 1);
                    break;
                case "HScrollBar_reform":
                    ((HScrollBar_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((HScrollBar_reform)all_purpose).Name, ((HScrollBar_reform)all_purpose).Name, 1);
                    break;
                case "Conveyor_reform":
                    ((Conveyor_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((Conveyor_reform)all_purpose).Name, ((Conveyor_reform)all_purpose).Name, 1);
                    break;
                case "Valve_reform":
                    ((Valve_reform)all_purpose).BringToFront();//将控件放置所有控件最顶层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((Valve_reform)all_purpose).Name, ((Valve_reform)all_purpose).Name, 1);
                    break;
            }
            //LogUtils日志
            LogUtils.debugWrite($"用户把：{((Control)this.all_purpose).Name} 控件改为最上层");
        }
        /// <summary>
        /// 控件最下层选择
        /// </summary>
        private void orlop(object send, EventArgs e)
        {
            Control_layer_EF layer_EF = new Control_layer_EF();//实例化最下层EF查询对象
            switch (SkinContextMenuStrip_Button_type)//判断传递父级的类型
            {
                case "Button_reform":
                    ((Button_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((Button_reform)all_purpose).Name, ((Button_reform)all_purpose).Name, 0);
                    break;
                case "SkinLabel_reform":
                    ((SkinLabel_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((SkinLabel_reform)all_purpose).Name, ((SkinLabel_reform)all_purpose).Name, 0);
                    break;
                case "SkinTextBox_reform":
                    ((SkinTextBox_reform)all_purpose).SendToBack();//将控件放置所有控件最底层    
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((SkinTextBox_reform)all_purpose).Name, ((SkinTextBox_reform)all_purpose).Name, 0);
                    break;
                case "SkinPictureBox_reform":
                    ((SkinPictureBox_reform)all_purpose).SendToBack();//将控件放置所有控件最底层  
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((SkinPictureBox_reform)all_purpose).Name, ((SkinPictureBox_reform)all_purpose).Name, 0);
                    break;
                case "Switch_reform":
                    ((Switch_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((Switch_reform)all_purpose).Name, ((Switch_reform)all_purpose).Name, 0);
                    break;
                case "LedBulb_reform":
                    ((LedBulb_reform)all_purpose).SendToBack();//将控件放置所有控件最底层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((LedBulb_reform)all_purpose).Name, ((LedBulb_reform)all_purpose).Name, 0);
                    break;
                case "GroupBox_reform":
                    ((GroupBox_reform)all_purpose).SendToBack();//将控件放置所有控件最底层  
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((GroupBox_reform)all_purpose).Name, ((GroupBox_reform)all_purpose).Name, 0);
                    break;
                case "ImageButton_reform":
                    ((ImageButton_reform)all_purpose).SendToBack();//将控件放置所有控件最底层 
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((ImageButton_reform)all_purpose).Name, ((ImageButton_reform)all_purpose).Name, 0);
                    break;
                case "ScrollingText_reform":
                    ((ScrollingText_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "-" + ((ScrollingText_reform)all_purpose).Name, ((ScrollingText_reform)all_purpose).Name, 0);
                    break;
                case "doughnut_Chart_reform":
                    ((doughnut_Chart_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((doughnut_Chart_reform)all_purpose).Name, ((doughnut_Chart_reform)all_purpose).Name, 0);
                    break;
                case "histogram_Chart_reform":
                    ((histogram_Chart_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((histogram_Chart_reform)all_purpose).Name, ((histogram_Chart_reform)all_purpose).Name, 0);
                    break;
                case "oscillogram_Chart_reform":
                    ((oscillogram_Chart_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((oscillogram_Chart_reform)all_purpose).Name, ((oscillogram_Chart_reform)all_purpose).Name, 0);
                    break;
                case "AnalogMeter_reform":
                    ((AnalogMeter_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((AnalogMeter_reform)all_purpose).Name, ((AnalogMeter_reform)all_purpose).Name, 0);
                    break;
                case "LedDisplay_reform":
                    ((LedDisplay_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((LedDisplay_reform)all_purpose).Name, ((LedDisplay_reform)all_purpose).Name, 0);
                    break;
                case "ihatetheqrcode_reform":
                    ((ihatetheqrcode_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((ihatetheqrcode_reform)all_purpose).Name, ((ihatetheqrcode_reform)all_purpose).Name, 0);
                    break;
                case "function_key_reform":
                    ((function_key_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((function_key_reform)all_purpose).Name, ((function_key_reform)all_purpose).Name, 0);
                    break;
                case "RadioButton_reform":
                    ((RadioButton_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((RadioButton_reform)all_purpose).Name, ((RadioButton_reform)all_purpose).Name, 0);
                    break;
                case "pull_down_menu_reform":
                    ((pull_down_menu_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((pull_down_menu_reform)all_purpose).Name, ((pull_down_menu_reform)all_purpose).Name, 0);
                    break;
                case "HScrollBar_reform":
                    ((HScrollBar_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((HScrollBar_reform)all_purpose).Name, ((HScrollBar_reform)all_purpose).Name, 0);
                    break;
                case "Conveyor_reform":
                    ((Conveyor_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((Conveyor_reform)all_purpose).Name, ((Conveyor_reform)all_purpose).Name, 0);
                    break;
                case "Valve_reform":
                    ((Valve_reform)all_purpose).SendToBack();//将控件放置所有控件最底层   
                    layer_EF.all_Parameter_Query_Add(SkinContextMenuStrip_Button_ID + "- " + ((Valve_reform)all_purpose).Name, ((Valve_reform)all_purpose).Name, 0);
                    break;
            }
            //LogUtils日志
            LogUtils.debugWrite($"用户把：{((Control)this.all_purpose).Name} 控件改为最下层");
        }
        /// <summary>
        /// 查看控件属性
        /// </summary>
        private void toolStrip_Click_reform_4(object send, EventArgs e)
        {
            PropertyGrid propertyGrid = new PropertyGrid();//控件属性控件
            switch (SkinContextMenuStrip_Button_type)//判断传递父级的类型
            {
                case "Button_reform":
                    propertyGrid.SelectedObject= ((Button_reform)all_purpose);
                    break;
                case "SkinLabel_reform":
                    propertyGrid.SelectedObject = ((SkinLabel_reform)all_purpose);
                    break;
                case "SkinTextBox_reform":
                    propertyGrid.SelectedObject = ((SkinTextBox_reform)all_purpose);
                    break;
                case "SkinPictureBox_reform":
                    propertyGrid.SelectedObject = ((SkinPictureBox_reform)all_purpose);
                    break;
                case "Switch_reform":
                    propertyGrid.SelectedObject = ((Switch_reform)all_purpose);
                    break;
                case "LedBulb_reform":
                    propertyGrid.SelectedObject = ((LedBulb_reform)all_purpose);
                    break;
                case "GroupBox_reform":
                    propertyGrid.SelectedObject = ((GroupBox_reform)all_purpose);
                    break;
                case "ImageButton_reform":
                    propertyGrid.SelectedObject = ((ImageButton_reform)all_purpose);
                    break;
                case "ScrollingText_reform":
                    propertyGrid.SelectedObject = ((ScrollingText_reform)all_purpose);
                    break;
                case "doughnut_Chart_reform":
                    propertyGrid.SelectedObject = ((doughnut_Chart_reform)all_purpose);
                    break;
                case "histogram_Chart_reform":
                    propertyGrid.SelectedObject = ((histogram_Chart_reform)all_purpose);
                    break;
                case "oscillogram_Chart_reform":
                    propertyGrid.SelectedObject = ((oscillogram_Chart_reform)all_purpose);
                    break;
                case "AnalogMeter_reform":
                    propertyGrid.SelectedObject = ((AnalogMeter_reform)all_purpose);
                    break;
                case "LedDisplay_reform":
                    propertyGrid.SelectedObject = ((LedDisplay_reform)all_purpose);
                    break;
                case "ihatetheqrcode_reform":
                    propertyGrid.SelectedObject = ((ihatetheqrcode_reform)all_purpose);
                    break;
                case "function_key_reform":
                    propertyGrid.SelectedObject = ((function_key_reform)all_purpose);
                    break;
                case "RadioButton_reform":
                    propertyGrid.SelectedObject = ((RadioButton_reform)all_purpose);
                    break;
                case "pull_down_menu_reform":
                    propertyGrid.SelectedObject = ((pull_down_menu_reform)all_purpose);
                    break;
                case "HScrollBar_reform":
                    propertyGrid.SelectedObject = ((HScrollBar_reform)all_purpose);
                    break;
                case "Conveyor_reform":
                    propertyGrid.SelectedObject = ((Conveyor_reform)all_purpose);
                    break;
                case "Valve_reform":
                    propertyGrid.SelectedObject = ((Valve_reform)all_purpose);
                    break;
            }
            //LogUtils日志
            LogUtils.debugWrite($"用户查看了：{((Control)this.all_purpose).Name} 控件属性信息");
            Control_property control_Property = new Control_property(propertyGrid);
            control_Property.ShowDialog();
        }
        /// <summary>
        /// 重写Dispose方法
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            toolStrip.Click -= toolStrip_Click_reform;//注册修改参数事件
            toolStrip_4.Click -= toolStrip_Click_reform_4;//注册修改参数事件
            toolStrip_1.Click -= toolStrip_Click_reform_1;//注册修改参数事件
            toolStrip_2.Click -= stratosphere;//注册修改参数事件
            toolStrip_3.Click -= orlop;//注册修改参数事件
            toolStrip.Dispose();
            toolStrip_4.Dispose();
            toolStrip_1.Dispose();
            toolStrip_2.Dispose();
            toolStrip_3.Dispose();
            this.Items.Clear();
            base.Dispose(disposing);
        }
    }
}
