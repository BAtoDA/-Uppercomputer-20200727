using CCWin.SkinControl;
using HslCommunication.Profinet;
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
        public void Load(PLC_configuration pLC, SkinTextBox skinTextBox_IP, SkinTextBox skinTextBox_port
            , SkinTextBox skinComboBox_type, SkinComboBox skinComboBox_link)
        {
            PLC_EF pLC_EF = new PLC_EF();
            skincom(ref skinComboBox_link, pLC);//填充数据
            if (pLC_EF.Parameter_inquire(1)=="OK")//该数据库有该ID
            {
                PLC_parameter pLC_Parameters = pLC_EF.Parameter_Query(1);//查询ID的参数                  
                switch (pLC)
                {
                    case PLC_configuration.Mitsubishi:                      
                        skinTextBox_IP.Text= pLC_Parameters.三菱PLC_IP.Trim();
                        skinTextBox_port.Text = pLC_Parameters.三菱PLC_端口.Trim();
                        skinComboBox_type.Text = pLC_Parameters.三菱PLC_类型.Trim();
                        skinComboBox_link.Text = pLC_Parameters.三菱PLC_链接类型.Trim();
                        break;
                    case PLC_configuration.Siemens:
                        skinTextBox_IP.Text = pLC_Parameters.西门子PLC_IP.Trim();
                        skinTextBox_port.Text = pLC_Parameters.西门子PLC_端口.Trim();
                        skinComboBox_type.Text = pLC_Parameters.西门子PLC_类型.Trim();
                        skinComboBox_link.Text = pLC_Parameters.西门子PLC_链接类型.Trim();
                        break;
                    case PLC_configuration.MODBUS_TCP:
                        skinTextBox_IP.Text = pLC_Parameters.MODBUS_TCP_PLC_IP.Trim();
                        skinTextBox_port.Text = pLC_Parameters.MODBUS_TCP_PLC_端口11.Trim();
                        skinComboBox_type.Text = pLC_Parameters.MODBUS_TCP_PLC_类型.Trim();
                        skinComboBox_link.Text = pLC_Parameters.MODBUS_TCP_PLC_链接类型.Trim();
                        break;
                }

            }
        }
        private void skincom(ref SkinComboBox skinComboBox, PLC_configuration pLC_Configuration)//填充内容
        {
            skinComboBox.Items.Clear();//清空集合
            if (pLC_Configuration== PLC_configuration.Mitsubishi)
            {
                foreach (string i in Mitsubishi_type)
                {
                    skinComboBox.Items.Add(i.ToString());
                }
            }
            if (pLC_Configuration == PLC_configuration.Siemens)
            {
                foreach (SiemensPLCS i in Enum.GetValues(typeof(SiemensPLCS)))
                {
                    skinComboBox.Items.Add(i.ToString());
                }
            }
            if (pLC_Configuration == PLC_configuration.MODBUS_TCP)
            {
                foreach (string i in Modbus_TCP_type)
                {
                    skinComboBox.Items.Add(i.ToString());
                }
            }
            skinComboBox.SelectedIndex = 0;
            skinComboBox.SelectedItem = 0;
        }
    }
}
