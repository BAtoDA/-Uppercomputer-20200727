using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLC通讯规范接口;
using 欧姆龙Fins协议.欧姆龙.报文处理;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.表格控件__TO__PLC
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/20 22:14:07 
    //  文件名：DataGridView_PLC 
    //  版本：V1.0.1  
    //  说明： 实现DataGridView表格控件读取PLC数据
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现DataGridView表格控件读取PLC数据
    /// </summary>
    class DataGridView_PLC
    {
        public List<string> plc(TextBox_base textBox, DataGridViewPLC_base dataGridView,int Idx)//根据PLC类型写入
        {
            List<string> Data = new List<string>();
            switch (textBox.Plc)
            {
                case PLC.Mitsubishi:
                    IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                    if (mitsubishi.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(mitsubishi.PLC_read_D_register(textBox.PLC_Contact, dataGridView.PLC_address[i].ToString(), dataGridView.DataGridView_numerical[i]));
                    }                  
                    break;
                case PLC.Siemens:
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(Siemens.PLC_read_D_register(textBox.PLC_Contact, dataGridView.PLC_address[i].ToString(), dataGridView.DataGridView_numerical[i]));
                    }
                    break;
                case PLC.Modbus_TCP:
                    IPLC_interface MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(MODBUD_TCP.PLC_read_D_register(textBox.PLC_Contact, dataGridView.PLC_address[i].ToString(), dataGridView.DataGridView_numerical[i]));
                    }
                    break;
                case PLC.OmronTCP:
                    IPLC_interface OmronFinsTCP = new OmronFinsCIP();//实例化接口
                    if (OmronFinsTCP.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(OmronFinsTCP.PLC_read_D_register(textBox.PLC_Contact, dataGridView.PLC_address[i].ToString(), dataGridView.DataGridView_numerical[i]));
                    }
                    break;
                case PLC.OmronUDP:
                    IPLC_interface OmronFinsUDP = new OmronFinsUDP();//实例化接口
                    if (OmronFinsUDP.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(OmronFinsUDP.PLC_read_D_register(textBox.PLC_Contact, dataGridView.PLC_address[i].ToString(), dataGridView.DataGridView_numerical[i]));
                    }
                    break;
                case PLC.OmronCIP:
                    IPLC_interface OmronFinsCIP = new OmronFinsCIP();//实例化接口
                    if (OmronFinsCIP.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(OmronFinsCIP.PLC_read_D_register(textBox.PLC_Contact, dataGridView.PLC_address[i].ToString(), dataGridView.DataGridView_numerical[i]));
                    }
                    break;
            }
            return Data;
        }
        public List<string> plc(TextBox_base textBox, Histogram_base dataGridView, int Idx)//根据PLC类型写入
        {
            List<string> Data = new List<string>();
            switch (textBox.Plc)
            {
                case PLC.Mitsubishi:
                    IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                    if (mitsubishi.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(mitsubishi.PLC_read_D_register(textBox.PLC_Contact, dataGridView.Total_address[i].ToString(), dataGridView.Histogram_numerical[i]));
                    }
                    break;
                case PLC.Siemens:
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(Siemens.PLC_read_D_register(textBox.PLC_Contact, dataGridView.Total_address[i].ToString(), dataGridView.Histogram_numerical[i]));
                    }
                    break;
                case PLC.Modbus_TCP:
                    IPLC_interface MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(MODBUD_TCP.PLC_read_D_register(textBox.PLC_Contact, dataGridView.Total_address[i].ToString(), dataGridView.Histogram_numerical[i]));
                    }
                    break;
                case PLC.OmronTCP:
                    IPLC_interface OmronFinsTCP = new OmronFinsCIP();//实例化接口
                    if (OmronFinsTCP.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(OmronFinsTCP.PLC_read_D_register(textBox.PLC_Contact, dataGridView.Total_address[i].ToString(), dataGridView.Histogram_numerical[i]));
                    }
                    break;
                case PLC.OmronUDP:
                    IPLC_interface OmronFinsUDP = new OmronFinsUDP();//实例化接口
                    if (OmronFinsUDP.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(OmronFinsUDP.PLC_read_D_register(textBox.PLC_Contact, dataGridView.Total_address[i].ToString(), dataGridView.Histogram_numerical[i]));
                    }
                    break;
                case PLC.OmronCIP:
                    IPLC_interface OmronFinsCIP = new OmronFinsCIP();//实例化接口
                    if (OmronFinsCIP.PLC_ready)
                    {
                        for (int i = 0; i < Idx; i++)
                            Data.Add(OmronFinsCIP.PLC_read_D_register(textBox.PLC_Contact, dataGridView.Total_address[i].ToString(), dataGridView.Histogram_numerical[i]));
                    }
                    break;
            }
            return Data;
        }
        /// <summary>
        /// 判断程序是否在运行
        /// true 该程序在电脑进程运行中  false 表示不在进程运行
        /// 该方法主要用于避免继承过程中CLR 进入SQL数据库 查询数据从而卡死软件
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool GetPidByProcess(string Name = "自定义Uppercomputer-20200727")
        {
            return System.Diagnostics.Process.GetProcessesByName(Name).ToList().Count > 0 ? true : false;
        }
    }
}
