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
using CCWin.SkinControl;
using HslCommunication.Profinet;
using HslCommunication.Profinet.Siemens;
using PLC通讯规范接口;
using Sunny.UI;
using 欧姆龙Fins协议.报文处理;
using 欧姆龙Fins协议.欧姆龙.报文处理;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using 自定义Uppercomputer_20200727.三菱报文;

namespace 自定义Uppercomputer_20200727.PLC选择
{
    public partial class PLCselect_Form :Skin_VS
    {
        string Mitsubishi_ree= "本软件需要提前配置Communication Setup Utility 由三菱官网下载 按照主页面提示的站号进行配置--并且要运行相应的软件模拟启动模式-方可以使用--否则软件会出现闪退等现象";
        public bool Hiel { get; set; } = false;
        public PLCselect_Form()
        {
            InitializeComponent();
        }

        private void PLCselect_Form_Load(object sender, EventArgs e)
        {
            Hiel = true;
            PLCselect_Form_class pLCselect_Form_Class = new PLCselect_Form_class();//实例化加载对象
            pLCselect_Form_Class.Load(PLC.Mitsubishi, this.skinTextBox1, this.skinTextBox2, this.skinTextBox3, this.skinComboBox1,this.uiCheckBox1);//填充三菱选项
            pLCselect_Form_Class.Load(PLC.Siemens, this.skinTextBox6, this.skinTextBox5, this.skinTextBox4, this.skinComboBox2, this.uiCheckBox2);//填充西门子选项
            pLCselect_Form_Class.Load(PLC.Modbus_TCP, this.skinTextBox9, this.skinTextBox8, this.skinTextBox7, this.skinComboBox3, this.uiCheckBox3);//填充MODBUS_TCP选项   
            pLCselect_Form_Class.Load(PLC.OmronTCP, this.skinTextBox12, this.skinTextBox11, this.skinTextBox10, this.skinComboBox4, this.uiCheckBox4);//填充欧姆龙选型
            pLCselect_Form_Class.Load(PLC.Fanuc, this.skinTextBox15, this.skinTextBox14, this.skinTextBox13, this.skinComboBox5, this.uiCheckBox5);//填充欧姆龙选型
            if (this.skinComboBox1.Text.Trim() != "在线访问")//加载时显示是否连接成功
            {
                IPLC_interface axActUtlType = new Mitsubishi_axActUtlType();//实例化三菱 仿真--无参
                if (axActUtlType.PLC_ready)
                {
                    this.skinButton1.Text = "链接成功";
                    this.skinComboBox1.Enabled = false;
                    skinButton1.BaseColor = Color.FromName("Lime");
                }
            }
            else
            {
                IPLC_interface Mitsubishi = new Mitsubishi_realize();//实例化三菱 在线--无参
                if (Mitsubishi.PLC_ready)
                {
                    this.skinButton1.Text = "链接成功";
                    this.skinComboBox1.Enabled = false;
                    skinButton1.BaseColor = Color.FromName("Lime");
                }
            }
            //西门子
            IPLC_interface Siemens = new Siemens_realize();//实例化西门子 在线--无参
            if (Siemens.PLC_ready)
            {
                this.skinButton2.Text = "链接成功";
                this.skinComboBox2.Enabled = false;
                skinButton2.BaseColor = Color.FromName("Lime");
            }
            MODBUD_TCP pLC_Interface = new MODBUD_TCP();//实例化MODBUS-TCP 在线--无参
            if (MODBUD_TCP.IPLC_interface_PLC_ready)
            {
                this.skinButton3.Text = "链接成功";
                this.skinComboBox3.Enabled = false;
                skinButton3.BaseColor = Color.FromName("Lime");
            }
            //欧姆龙PLC
            IPLC_interface Omron =new OmronFinsTcp();
            if (skinComboBox4.Text == "TCP")
            {
                Omron =new OmronFinsTcp();
            }
            if (skinComboBox4.Text == "CIP")
            {
                Omron =new OmronFinsCIP();
            }
            if (skinComboBox4.Text == "UDP")
            {
                Omron =new OmronFinsUDP();
            }
            if (Omron.PLC_ready)
            {
                this.skinButton8.Text = "链接成功";
                this.skinComboBox4.Enabled = false;
                skinButton8.BaseColor = Color.FromName("Lime");
            }
            //发那科机器人

        }
        public static string Mitsubishi = "";//三菱PLC的访问模式
        public static bool Mitsubishi_ready=false;//指示用户是否打开了PLC
        private void skinButton1_Click(object sender, EventArgs e)//链接三菱PLC
        {
            if (ip_err(this.skinTextBox1.Text) == "NG" || port_err(this.skinTextBox2.Text) == "NG") return;//返回方法

            if (this.skinComboBox1.Text.Trim() != "在线访问")//PLC模式选择
            {
                if (MessageBox.Show(Mitsubishi_ree, "Err", MessageBoxButtons.YesNo) == DialogResult.No) return;//返回方法
                if (Home.ActUtlType == null) return;//返回方法
                IPLC_interface axActUtlType = new Mitsubishi_axActUtlType(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox1.Text), int.Parse(this.skinTextBox2.Text)), "三菱", Home.ActUtlType);
                PLChandle(axActUtlType, skinButton1, skinComboBox1, uiCheckBox1);
            }
            else
            {
                //三菱3E帧在线访问
                IPLC_interface Mitsubishi = new Mitsubishi_realize(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox1.Text), int.Parse(this.skinTextBox2.Text)));//实例化
                                                                                                                                                           //改变PLC操作显示
                this.skinComboBox1.EnabledChanged += ((send1, e1) =>
                {
                    if (Mitsubishi.PLC_ready)
                        this.groupBox1.Visible = true;
                    else
                        this.groupBox1.Visible = false;
                });
                PLChandle(Mitsubishi, skinButton1, skinComboBox1, uiCheckBox1);
            }
            Mitsubishi = this.skinComboBox1.Text.Trim();//获取用户开放的方式---仿真与---在线二选一   
        }
        private void skinButton2_Click(object sender, EventArgs e)//链接西门子PLC
        {
            if (ip_err(this.skinTextBox6.Text) == "NG" || port_err(this.skinTextBox5.Text) == "NG") return;//返回方法
            //西门子S7在线访问
            IPLC_interface Siemens = new Siemens_realize(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox6.Text), int.Parse(this.skinTextBox5.Text)), SiemensPLCS(skinComboBox2.Text));//实例化
            PLChandle(Siemens, skinButton2, skinComboBox2, uiCheckBox2);
        }

        private void skinButton3_Click(object sender, EventArgs e)//链接MODBUS-TCP
        {
            if (ip_err(this.skinTextBox9.Text) == "NG" || port_err(this.skinTextBox8.Text) == "NG") return;//返回方法
            IPLC_interface pLC_Interface = new MODBUD_TCP(new IPEndPoint(IPAddress.Parse(this.skinTextBox9.Text), int.Parse(this.skinTextBox8.Text)), "MODBUD_TCP");//打开
            PLChandle(pLC_Interface,skinButton3, skinComboBox3, uiCheckBox3);
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
        public HslCommunication.Profinet.Siemens.SiemensPLCS SiemensPLCS(String Name)//遍历用户选定的PLC系列
        {
            foreach (HslCommunication.Profinet.Siemens.SiemensPLCS suit in Enum.GetValues(typeof(HslCommunication.Profinet.Siemens.SiemensPLCS)))
            {
                if (suit.ToString() == Name.Trim()) return suit;//返回系列枚举
            }
            return HslCommunication.Profinet.Siemens.SiemensPLCS.S200Smart;//查询失败--返回默认类型S200
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
                MODBUS_TCP_PLC_链接类型 = this.skinComboBox3.Text,
                发那科_IP = this.skinTextBox15.Text,
                发那科_端口 = this.skinTextBox14.Text,
                发那科_类型 = this.skinTextBox13.Text,
                发那科_链接类型 = this.skinComboBox5.Text,
                欧姆龙PLC_IP = this.skinTextBox12.Text,
                欧姆龙PLC_端口 = this.skinTextBox11.Text,
                欧姆龙PLC_类型 = this.skinTextBox10.Text,
                欧姆龙PLC链接类型 = this.skinComboBox4.Text,
                三菱链接模式 = this.uiCheckBox1.Checked,
                西门子链接模式 = this.uiCheckBox2.Checked,
                MODBUS链接模式 = this.uiCheckBox3.Checked,
                欧姆龙链接模式 = this.uiCheckBox4.Checked,
                发那科链接模式 = this.uiCheckBox5.Checked

            };                        
        }

        private void PLCselect_Form_FormClosing(object sender, FormClosingEventArgs e)//关闭窗口
        {
            Hiel = false;

        }
        /// <summary>
        /// 执行对的PLC操作 RUN STOP REST Paus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            IPLC_interface Mitsubishi = new Mitsubishi_realize();
            Mitsubishi_message mitsubishi = new Mitsubishi_message();
            Control control = sender as Control;
            if (Mitsubishi.PLC_ready)
            {
                switch (control.Text)
                {
                    case "RUN":
                        Mitsubishi_realize.melsec_net.ReadFromCoreServer(mitsubishi.PLC_Run_remote());
                        return;
                    case "STOP":
                        Mitsubishi_realize.melsec_net.ReadFromCoreServer(mitsubishi.PLC_Stop_remote());
                        return;
                    case "REST":
                        Mitsubishi_realize.melsec_net.ReadFromCoreServer(mitsubishi.PLC_Rrr_Rest_remote());
                        return;
                    case "Pause":
                        Mitsubishi_realize.melsec_net.ReadFromCoreServer(mitsubishi.PLC_Pause_remote());
                        return;
                }
            }         
        }

        private void skinButton8_Click(object sender, EventArgs e)
        {
            if (ip_err(this.skinTextBox12.Text) == "NG" || port_err(this.skinTextBox11.Text) == "NG") return;//返回方法
            //西门子S7在线访问
            IPLC_interface Omron = new OmronFinsTcp(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox12.Text), int.Parse(this.skinTextBox11.Text)), this.skinTextBox11.Text);
            if (skinComboBox4.Text == "TCP")
            {
                Omron = new OmronFinsUDP(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox12.Text), int.Parse(this.skinTextBox11.Text)), this.skinTextBox11.Text);
            }
            if (skinComboBox4.Text == "CIP")
            {
                Omron = new OmronFinsCIP(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox12.Text), int.Parse(this.skinTextBox11.Text)), this.skinTextBox11.Text);
            }
            if (skinComboBox4.Text == "UDP")
            {
                Omron = new OmronFinsUDP(new System.Net.IPEndPoint(IPAddress.Parse(this.skinTextBox12.Text), int.Parse(this.skinTextBox11.Text)), this.skinTextBox11.Text);
            }
            PLChandle(Omron, skinButton8, skinComboBox4, uiCheckBox4);
        }

        private void skinButton9_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 通用链接与切断PLC方法
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="skinButton"></param>
        /// <param name="skinCombo"></param>
        /// <param name="check"></param>
        private void PLChandle(IPLC_interface pLC,SkinButton skinButton,SkinComboBox skinCombo, UICheckBox check)
        {
            if (skinButton.Text == "链接成功")
            {
                pLC.PLC_Close();
                skinButton.Text = "链接PLC";
                skinCombo.Enabled = true;
                skinButton.Enabled = true;
                skinButton.BaseColor = Color.FromArgb(9, 163, 220);
                pLC.PLC_Reconnection = false;
                return;
            }
            pLC.PLC_open();//打开PLC
            if (pLC.PLC_ready)
            {
                skinButton.Text = "链接成功";
                skinCombo.Enabled = false;
                skinButton.BaseColor = Color.FromName("Lime");
                pLC.PLC_Reconnection = check.Checked;
                pLC.PLC_type = skinCombo.Text;

            }
            PLC_EF pLC_EF = new PLC_EF();//实例化EF对象
            if (pLC_EF.Parameter_inquire(1) == "OK") pLC_EF.Button_Parameter_modification(1, plC_Parameter());//修改参数
            else pLC_EF.PLC_Parameter_Add(plC_Parameter());//插入参数
        }
    }
}
