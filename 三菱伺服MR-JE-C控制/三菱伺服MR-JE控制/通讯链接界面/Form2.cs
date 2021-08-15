using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using 命令处理;

namespace 三菱伺服MR_JE控制.通讯链接界面
{
    public partial class Form2 :Skin_VS
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (MODBUD_TCP.IPLC_interface_PLC_ready)
                skinButton1.Text = "已链接伺服";
            else
                skinButton1.Text = "未链接伺服";
        }
        //链接伺服驱动器
        Command command;
        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (!IsIPv4(this.skinTextBox1.Text))
            {
                MessageBox.Show(skinTextBox1.Text + "不是有效IP地址");
                return;
            }
            if(!int.TryParse(skinTextBox2.Text, out int port_1))
            {
                MessageBox.Show(skinTextBox2.Text + "不是有效端口");
                return;
            }
            command = new Command(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox1.Text), int.Parse(skinTextBox2.Text)));
            command.Servo_Open();
            if (MODBUD_TCP.IPLC_interface_PLC_ready)
                skinButton1.Text = "已链接伺服";
            else
                skinButton1.Text = "未链接伺服";
        }
        /// <summary>  
        /// 验证IPv4地址  
        /// [第一位和最后一位数字不能是0或255；允许用0补位]  
        /// </summary>  
        /// <param name="input">待验证的字符串</param>  
        /// <returns>是否匹配</returns>  
        public static bool IsIPv4(string input)
        {
            //string pattern = @"^(25[0-4]|2[0-4]\d]|[01]?\d{2}|[1-9])\.(25[0-5]|2[0-4]\d]|[01]?\d?\d)\.(25[0-5]|2[0-4]\d]|[01]?\d?\d)\.(25[0-4]|2[0-4]\d]|[01]?\d{2}|[1-9])$";  
            //return IsMatch(input, pattern);  
            string[] IPs = input.Split('.');
            if (IPs.Length != 4)
                return false;
            int n = -1;
            for (int i = 0; i < IPs.Length; i++)
            {
                if (i == 0 || i == 3)
                {
                    if (int.TryParse(IPs[i], out n) && n > 0 && n < 255)
                        continue;
                    else
                        return false;
                }
                else
                {
                    if (int.TryParse(IPs[i], out n) && n >= 0 && n <= 255)
                        continue;
                    else
                        return false;
                }
            }
            return true;
        }
    }
}
