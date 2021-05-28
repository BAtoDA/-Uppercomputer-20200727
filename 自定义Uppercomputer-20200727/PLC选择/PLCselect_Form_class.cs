using CCWin.SkinControl;
using HslCommunication.Profinet;
using HslCommunication.Profinet.Siemens;
using PLC通讯规范接口;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 自定义Uppercomputer_20200727.EF实体模型;

namespace 自定义Uppercomputer_20200727.PLC选择
{
    /// <处理PLC链接窗口加载初始化>
    class PLCselect_Form_class
    {
        public  enum  PLC_configuration//定义填充的枚举
        {
            Mitsubishi, Siemens,MODBUS_TCP
        }
        private string[] Mitsubishi_type = new string[] { "GX Works3", "GX Works2", "在线访问" };//三菱PLC选项--三菱PLC无法选因为通用Q,Q-R,FX-5U-3帧通用
        private string[] Siemens_type = new string[] { "s7-200samrt", "s7-300", "s7-1200", "s7-1500" };//西门子PLC选项--s7-200samrt V区起始为DB1-其他默认按照分配
        private string[] Modbus_TCP_type = new string[] { "在线访问" };//modbus_TCP选项单通道-只能在线
        private string[] Omron_type = new string[] { "TCP","UDP","CIP" };//modbus_TCP选项单通道-只能在线
        private string[] Fanuc_type = new string[] { "在线访问" };//modbus_TCP选项单通道-只能在线
        public void Load(PLC pLC, SkinTextBox skinTextBox_IP, SkinTextBox skinTextBox_port
            , SkinTextBox skinComboBox_type, SkinComboBox skinComboBox_link, UICheckBox uICheck)
        {
            PLC_EF pLC_EF = new PLC_EF();
            skincom(ref skinComboBox_link, pLC);//填充数据
            if (pLC_EF.Parameter_inquire(1)=="OK")//该数据库有该ID
            {
                PLC_parameter pLC_Parameters = pLC_EF.Parameter_Query(1);//查询ID的参数                  
                switch (pLC)
                {
                    case PLC.Mitsubishi:                      
                        skinTextBox_IP.Text= pLC_Parameters.三菱PLC_IP.Trim();
                        skinTextBox_port.Text = pLC_Parameters.三菱PLC_端口.Trim();
                        skinComboBox_type.Text = pLC_Parameters.三菱PLC_类型.Trim();
                        skinComboBox_link.Text = pLC_Parameters.三菱PLC_链接类型.Trim();
                        uICheck.Checked = pLC_Parameters.三菱链接模式;
                        break;
                    case PLC.Siemens:
                        skinTextBox_IP.Text = pLC_Parameters.西门子PLC_IP.Trim();
                        skinTextBox_port.Text = pLC_Parameters.西门子PLC_端口.Trim();
                        skinComboBox_type.Text = pLC_Parameters.西门子PLC_类型.Trim();
                        skinComboBox_link.Text = pLC_Parameters.西门子PLC_链接类型.Trim();
                        uICheck.Checked = pLC_Parameters.西门子链接模式;
                        break;
                    case PLC.Modbus_TCP:
                        skinTextBox_IP.Text = pLC_Parameters.MODBUS_TCP_PLC_IP.Trim();
                        skinTextBox_port.Text = pLC_Parameters.MODBUS_TCP_PLC_端口11.Trim();
                        skinComboBox_type.Text = pLC_Parameters.MODBUS_TCP_PLC_类型.Trim();
                        skinComboBox_link.Text = pLC_Parameters.MODBUS_TCP_PLC_链接类型.Trim();
                        uICheck.Checked = pLC_Parameters.MODBUS链接模式;
                        break;
                    case PLC.OmronTCP:
                    case PLC.OmronUDP:
                    case PLC.OmronCIP:
                        skinTextBox_IP.Text = pLC_Parameters.欧姆龙PLC_IP.Trim();
                        skinTextBox_port.Text = pLC_Parameters.欧姆龙PLC_端口.Trim();
                        skinComboBox_type.Text = pLC_Parameters.欧姆龙PLC_类型.Trim();
                        skinComboBox_link.Text = pLC_Parameters.欧姆龙PLC链接类型.Trim();
                        uICheck.Checked = pLC_Parameters.欧姆龙链接模式;
                        break;
                    case PLC.Fanuc:
                        skinTextBox_IP.Text = pLC_Parameters.发那科_IP.Trim();
                        skinTextBox_port.Text = pLC_Parameters.发那科_端口.Trim();
                        skinComboBox_type.Text = pLC_Parameters.发那科_类型.Trim();
                        skinComboBox_link.Text = pLC_Parameters.发那科_链接类型.Trim();
                        uICheck.Checked = pLC_Parameters.发那科链接模式;
                        break;
                }

            }
        }
        private void skincom(ref SkinComboBox skinComboBox, PLC pLC_Configuration)//填充内容
        {
            skinComboBox.Items.Clear();//清空集合
            if (pLC_Configuration== PLC.Mitsubishi)
            {
                foreach (string i in Mitsubishi_type)
                {
                    skinComboBox.Items.Add(i.ToString());
                }
            }
            if (pLC_Configuration == PLC.Siemens)
            {
                foreach (SiemensPLCS i in Enum.GetValues(typeof(SiemensPLCS)))
                {
                    skinComboBox.Items.Add(i.ToString());
                }
            }
            if (pLC_Configuration == PLC.Modbus_TCP)
            {
                foreach (string i in Modbus_TCP_type)
                {
                    skinComboBox.Items.Add(i.ToString());
                }
            }
            if (pLC_Configuration == PLC.OmronTCP)
            {
                foreach (string i in Omron_type)
                {
                    skinComboBox.Items.Add(i.ToString());
                }
            }
            if (pLC_Configuration == PLC.Fanuc)
            {
                foreach (string i in Fanuc_type)
                {
                    skinComboBox.Items.Add(i.ToString());
                }
            }
            skinComboBox.SelectedIndex = 0;
            skinComboBox.SelectedItem = 0;
        }
    }
}
