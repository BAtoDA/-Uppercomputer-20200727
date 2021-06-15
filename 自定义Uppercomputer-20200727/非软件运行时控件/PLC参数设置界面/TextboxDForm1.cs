using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLC通讯规范接口;
using Sunny.UI;
namespace 自定义Uppercomputer_20200727.非软件运行时控件.PLC参数设置界面
{
    public partial class TextboxDForm1 : Sunny.UI.UIForm
    {
        int combox;
        string addeip, indx;
        public TextboxDForm1(int combox, String indx, string addeip)
        {
            InitializeComponent();
            this.combox = combox;
            this.indx = indx;
            this.addeip = addeip;
            //判断传入的PLC是否符合辅助触点

            switch (combox)
            {
                case 0:
                    if (GetEnum<Mitsubishi_D>(indx.Trim()) == false)
                    {
                        this.uiComboBox2.DataSource = Enum.GetNames(typeof(Mitsubishi_bit)).ToList();
                    }
                    break;
                case 1:
                    if (GetEnum<Siemens_D>(indx.Trim()) == false)
                    {
                        this.uiComboBox2.DataSource = Enum.GetNames(typeof(Siemens_bit)).ToList();
                    }
                    break;
                case 2:
                    if (GetEnum<Modbus_TCP_D>(indx.Trim()) == false)
                    {
                        this.uiComboBox2.DataSource = Enum.GetNames(typeof(Modbus_TCP_bit)).ToList();
                    }
                    break;
                case 4:
                case 5:
                case 6:
                    if (GetEnum<Omron_D>(indx.Trim()) == false)
                    {
                        this.uiComboBox2.DataSource = Enum.GetNames(typeof(Omron_bit)).ToList();
                    }
                    break;

            }
        }
        /// <summary>
        /// 查找指定PLC辅助触点 找到TRUE 找不到false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Name"></param>
        /// <returns></returns>
        private bool GetEnum<T>(string Name)
        {
            return Enum.Parse(typeof(T), Name) == null ? false : true;
        }
        private void ComboBoxSelecte(int data)
        {
            switch (data)
            {
                case 0:
                    this.uiComboBox2.DataSource = Enum.GetNames(typeof(Mitsubishi_D)).ToList();
                    break;
                case 1:
                    this.uiComboBox2.DataSource = Enum.GetNames(typeof(Siemens_D)).ToList();
                    break;
                case 2:
                    this.uiComboBox2.DataSource = Enum.GetNames(typeof(Modbus_TCP_D)).ToList();
                    break;
            }
            this.uiComboBox2.SelectedIndex = 0;
            this.uiComboBox2.SelectedItem = 0;
        }

        private void TextboxDForm1_Shown(object sender, EventArgs e)
        {
            ComboBoxSelecte(this.combox);
            this.uiComboBox1.SelectedIndex = combox;
            this.uiComboBox1.SelectedItem = combox;
            this.uiComboBox2.Text = this.indx;
            this.uiTextBox1.Text = addeip;
        }

        private void uiComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxSelecte(this.uiComboBox1.SelectedIndex);
        }
        public string[] PLC_parameter { get; set; }
        public PLC pLC { get; set; }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            //检查输入数据是否正确
            Regex reg = new Regex(@"^[A-Fa-z0-9]+(.[0-9]+)?$");
            if (reg.IsMatch(this.uiTextBox1.Text.Trim()) != true)
            {
                MessageBox.Show("PLC地址输入错误，输入了一个不可能访问到的地址");
                return;
            }
            PLC_parameter = new string[] { this.uiComboBox1.Text, this.uiComboBox2.Text, this.uiTextBox1.Text };
            pLC = (PLC)Enum.Parse(typeof(PLC), this.uiComboBox1.Text);
            this.Close();
        }
        private void KeyPress_reform(object sender, KeyPressEventArgs e)//键盘事件--位置与大小数据
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9') || ((TextBox)sender).Text.Length > 3)//这是允许输入0-9数字 最大数据不能大于3位数  
                {
                    if (e.KeyChar == '.') return;
                    e.Handled = true;//只能输入数字
                }
            }
        }
    }
}
