using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;
using CCWin;
using HslCommunication.Profinet;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;

namespace 自定义Uppercomputer_20200727.PLC选择
{
    public partial class PLCselect_Form :Skin_VS
    {
        string Mitsubishi_ree= "本软件需要提前配置Communication Setup Utility 由三菱官网下载 按照主页面提示的站号进行配置--并且要运行相应的软件模拟启动模式-方可以使用--否则软件会出现闪退等现象";

        public PLCselect_Form()
        {
            InitializeComponent();
        }

        private void PLCselect_Form_Load(object sender, EventArgs e)
        {
            PLCselect_Form_class pLCselect_Form_Class = new PLCselect_Form_class();//实例化加载对象
            pLCselect_Form_Class.Load(PLCselect_Form_class.PLC_configuration.Mitsubishi, this.skinTextBox1, this.skinTextBox2, this.skinTextBox3, this.skinComboBox1);//填充三菱选项
            pLCselect_Form_Class.Load(PLCselect_Form_class.PLC_configuration.Siemens, this.skinTextBox6, this.skinTextBox5, this.skinTextBox4, this.skinComboBox2);//填充西门子选项
            pLCselect_Form_Class.Load(PLCselect_Form_class.PLC_configuration.MODBUS_TCP, this.skinTextBox9, this.skinTextBox8, this.skinTextBox7, this.skinComboBox3);//填充MODBUS_TCP选项   
            if (this.skinComboBox1.Text.Trim() != "在线访问")//加载时显示是否连接成功
            {
                IPLC_interface axActUtlType = new Mitsubishi_axActUtlType();//实例化三菱 仿真--无参
                if (axActUtlType.PLC_ready)
                {
                    this.skinButton1.Text = "链接成功";
                    this.skinComboBox1.Enabled = false;
                    this.skinButton1.Enabled = false;
                }
            }
            else
            {
                IPLC_interface Mitsubishi = new Mitsubishi_realize();//实例化三菱 在线--无参
                if (Mitsubishi.PLC_ready)
                {
                    this.skinButton1.Text = "链接成功";
                    this.skinComboBox1.Enabled = false;
                    this.skinButton1.Enabled = false;
                }
            }
            //预留未实现西门子
            IPLC_interface Siemens = new Siemens_realize();//实例化西门子 在线--无参
            if (Siemens.PLC_ready)
            {
                this.skinButton2.Text = "链接成功";
                this.skinComboBox2.Enabled = false;
                this.skinButton2.Enabled = false;
            }
            MODBUD_TCP pLC_Interface = new MODBUD_TCP();//实例化MODBUS-TCP 在线--无参
            if (MODBUD_TCP.IPLC_interface_PLC_ready)
            {
                this.skinButton3.Text = "链接成功";
                this.skinComboBox3.Enabled = false;
                this.skinButton3.Enabled = false;
            }
        }
        public static string Mitsubishi = "";//三菱PLC的访问模式
        public static bool Mitsubishi_ready=false;//指示用户是否打开了PLC
        private void skinButton1_Click(object sender, EventArgs e)//链接三菱PLC
        {
            if (ip_err(this.skinTextBox1.Text) == "NG" || port_err(this.skinTextBox2.Text) == "NG") return;//返回方法
            if (this.skinComboBox1.Text.Trim() != "在线访问")//PLC模式选择
            {
                if (MessageBox.Show(Mitsubishi_ree, "Err", MessageBoxButtons.YesNo) == DialogResult.No) return;//返回方法
                if (axActUtlType1 == null) return;//返回方法
                IPLC_interface axActUtlType = new Mitsubishi_axActUtlType(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox1.Text), int.Parse(this.skinTextBox2.Text)), "三菱", this.axActUtlType1);
                axActUtlType.PLC_open();//打开端口
                if (axActUtlType.PLC_ready)
                {
                    this.skinButton1.Text = "链接成功";
                    this.skinComboBox1.Enabled = false;
                    this.skinButton1.Enabled = false;
                }
            }
            else
            {
                //三菱3E帧在线访问
                IPLC_interface Mitsubishi = new Mitsubishi_realize(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox1.Text), int.Parse(this.skinTextBox2.Text)));//实例化
                Mitsubishi.PLC_open();//打开open--PLC
                if (Mitsubishi.PLC_ready)
                {
                    this.skinButton1.Text = "链接成功";
                    this.skinComboBox1.Enabled = false;
                    this.skinButton1.Enabled = false;
                }
            }
            Mitsubishi = this.skinComboBox1.Text.Trim();//获取用户开放的方式---仿真与---在线二选一
            PLC_EF pLC_EF = new PLC_EF();//实例化EF对象
            if (pLC_EF.Parameter_inquire(1) == "OK") pLC_EF.Button_Parameter_modification(1, plC_Parameter());//修改参数
            else pLC_EF.PLC_Parameter_Add(plC_Parameter());//插入参数   
        }
        private void skinButton2_Click(object sender, EventArgs e)//链接西门子PLC
        {
            if (ip_err(this.skinTextBox6.Text) == "NG" || port_err(this.skinTextBox5.Text) == "NG") return;//返回方法
            //未实现西门子S7在线访问
            IPLC_interface Siemens = new Siemens_realize(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox6.Text), int.Parse(this.skinTextBox5.Text)), SiemensPLCS(skinComboBox2.Text));//实例化
            Siemens.PLC_open();//打开open--PLC
            if (Siemens.PLC_ready)
            {
                this.skinButton2.Text = "链接成功";
                this.skinComboBox2.Enabled = false;
                this.skinButton2.Enabled = false;
            }
            PLC_EF pLC_EF = new PLC_EF();//实例化EF对象
            if (pLC_EF.Parameter_inquire(1) == "OK") pLC_EF.Button_Parameter_modification(1, plC_Parameter());//修改参数
            else pLC_EF.PLC_Parameter_Add(plC_Parameter());//插入参数
        }

        private void skinButton3_Click(object sender, EventArgs e)//链接MODBUS-TCP
        {
            if (ip_err(this.skinTextBox9.Text) == "NG" || port_err(this.skinTextBox8.Text) == "NG") return;//返回方法
            MODBUD_TCP pLC_Interface = new MODBUD_TCP(new IPEndPoint(IPAddress.Parse(this.skinTextBox9.Text), int.Parse(this.skinTextBox8.Text)), "MODBUD_TCP");//打开
            MODBUD_TCP.IPLC_interface_PLC_open();//打开PLC
            if (MODBUD_TCP.IPLC_interface_PLC_ready)
            {
                this.skinButton3.Text = "链接成功";
                this.skinComboBox3.Enabled = false;
                this.skinButton3.Enabled = false;
            }
            PLC_EF pLC_EF = new PLC_EF();//实例化EF对象
            if (pLC_EF.Parameter_inquire(1) == "OK") pLC_EF.Button_Parameter_modification(1, plC_Parameter());//修改参数
            else pLC_EF.PLC_Parameter_Add(plC_Parameter());//插入参数
        }
        private string ip_err(string ip)//检查IP
        {
            if (!System.Net.IPAddress.TryParse(ip, out System.Net.IPAddress address))
            {
                MessageBox.Show("Ip地址输入不正确！");
                return "NG";
            }
            return "OK";
        }
        private string port_err(string port)//检查端口
        {
            if (!int.TryParse(port, out int port_1))
            {
                MessageBox.Show("端口输入格式不正确！");
                return "NG";
            }
            return "OK";
        }
        public SiemensPLCS SiemensPLCS(String Name)//遍历用户选定的PLC系列
        {
            foreach (SiemensPLCS suit in Enum.GetValues(typeof(SiemensPLCS)))
            {
                if (suit.ToString() == Name.Trim()) return suit;//返回系列枚举
            }
            return HslCommunication.Profinet.SiemensPLCS.S200Smart;//查询失败--返回默认类型S200
        }
        private PLC_parameter plC_Parameter()//获取写个参数设置
        {
            return new PLC_parameter
            {
                ID = 1,
                三菱PLC_IP = this.skinTextBox1.Text,
                三菱PLC_端口 = this.skinTextBox2.Text,
                三菱PLC_类型 = this.skinTextBox3.Text,
                三菱PLC_链接类型 = this.skinComboBox1.Text,
                西门子PLC_IP = this.skinTextBox6.Text,
                西门子PLC_端口 = this.skinTextBox5.Text,
                西门子PLC_类型 = this.skinTextBox4.Text,
                西门子PLC_链接类型 = this.skinComboBox2.Text,
                MODBUS_TCP_PLC_IP = this.skinTextBox9.Text,
                MODBUS_TCP_PLC_端口11 = this.skinTextBox8.Text,
                MODBUS_TCP_PLC_类型 = this.skinTextBox7.Text,
                MODBUS_TCP_PLC_链接类型 = this.skinComboBox3.Text
            };                        
        }
    }
}
