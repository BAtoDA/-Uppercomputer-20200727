using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bottom_Control.基本控件;
using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using 自定义Uppercomputer_20200727.非软件运行时控件.基本控件;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.文本输入键盘
{
    public partial class keyboard_Hex:Skin_VS
    {
        string Name_1;//定义用户传入的文本
        DATextBox textBox;//获取该控件的参数
        public string O_Text { get => this.skinTextBox3.Text; } //输出文本自读---
        public keyboard_Hex(string Nmme, DATextBox textBox)//构造函数-
        {
            InitializeComponent();
            this.Name_1 = Nmme;
            this.textBox = textBox;
        }
        private void keyboard_Hex_Shown(object sender, EventArgs e)//加载控件状态
        {
            this.skinTextBox3.Text = this.Name_1.Trim();//写入上次值
            string[] data = Constraints_data(textBox.numerical.ToString());//获取最大值-最小值
            this.skinTextBox1.Text = data[0];//填充最大值
            this.skinTextBox2.Text = data[1];//填充最小值
            var skinButton_list = (from Control pi in this.Controls where pi is SkinButton select pi).ToList();//获取窗口控件集合
            foreach (SkinButton textBox in skinButton_list) textBox.Click += Button_KeyPress;//注册事件
        }
        private void Button_KeyPress(object sender, EventArgs e)//获取用户输入
        {
            SkinButton button = ((SkinButton)sender);//获取输入控件对象
            if (button.Text == "Clr") { if (this.skinTextBox3.Text.Trim() == "") return; this.skinTextBox3.Text = backspace(this.skinTextBox3.Text); }//实现移除最后一个字符
            if (button.Text == "Esc") { this.skinTextBox3.Text = Name_1; this.Close(); }//退回修改前数据
            if (button.Text == "Enter") this.Close();//关闭窗口        
            if ((button.Text != "Clr") & (button.Text != "Esc") & (button.Text != "Bs") & (button.Text != "Enter"))//判断是否功能键不录入
            this.skinTextBox3.Text = Button_text_add(sender);//添加字符
            if (button.Text == "Bs") this.skinTextBox3.Text = "0";//清空字符

        }
        private string Button_text_add(object send)//实现刻录字符
        {
            string data = this.skinTextBox3.Text + ((SkinButton)send).Text.Trim();//在最后一个添加字符
            if (textBox.Plc.ToString() == "HMI") return data;//用户使用了宏指令内部寄存器直接刻录
            if (numerical_KeyPress_import(data, textBox.numerical.ToString()))//判断数据是否溢出
            {
                return backspace(data);//移除最后一位 返回数据 
            }
            else
            {
                return data;//返回修改后数据
            }
        }
        private bool numerical_KeyPress_import(string Text, string Name)//获取用户输入的文本-与参数中的格式-判断输入是否正确
        {
            bool Handled = false;//初始化键盘输入状态
            int Hex_16_1=Convert.ToInt32(this.skinTextBox1.Text, 16),Hex_32_1= Convert.ToInt32(this.skinTextBox1.Text, 16);//short类型最大约束-与int 约束
            int data;
            if (Text.Trim().Length > 8) return true;//如果大于8直接返回方法---输入异常不合理
            switch (Name.Trim())
            {
                case "Hex_16_Bit":
                    data = Convert.ToInt32(Text,16);//把数据转换成--int
                    if ((data > 0) & (data > Hex_16_1)) Handled = true;//取消修改
                    if ((data < 0)) Handled = true;//取消修改
                    break;
                case "Hex_32_Bit":
                    data = Convert.ToInt32(Text,16);//把数据转换成--int
                    if ((data > 0) & (data > Hex_32_1)) Handled = true;//取消修改
                    if ((data < 0)) Handled = true;//取消修改
                    break;
            }
            return Handled;
        }

        private string backspace(string Name)//实现字符串移除最一个字符
        {
            return Name.Remove(Name.Length - 1, 1); //移除掉
        }
        private string[] Constraints_data(string Name)//实现约束最小值--最大值
        {
            string[] data = new string[2];//初始化最大值--最小值
            switch (Name)
            {
                case "Hex_16_Bit":
                    //最大值
                    if (textBox.Decimal_Above >= 4)
                        data[0] = "7FFF";//大于限制默认填充最大值
                    else
                        for (int i = 0; i < textBox.Decimal_Above; i++)//先填充最大值
                        {
                            data[0] += "F";
                        }
                    //最小值
                    data[1] = "0";//16进制最小值必须为0
                    break;
                    case "Hex_32_Bit":
                    //最大值
                    if (textBox.Decimal_Above >= 8)
                        data[0] = "7FFFFFFF";//大于限制默认填充最大值
                    else
                        for (int i = 0; i <textBox.Decimal_Above; i++)//先填充最大值
                        {
                            data[0] += "F";
                        }
                    //最小值
                    data[1] = "0";//16进制最小值必须为0
                    break;
                default://宏指令内部寄存器无限制
                    data[0] = "无限制";
                    data[1] = "无限制";
                    break;

            }
            return data;//返回数据
        }
        ~keyboard_Hex()//析构函数
        {
            var skinButton_list = (from Control pi in this.Controls where pi is SkinButton select pi).ToList();//获取窗口控件集合
            foreach (SkinButton textBox in skinButton_list) textBox.Click -= Button_KeyPress;//注册事件
        }
    }
}
