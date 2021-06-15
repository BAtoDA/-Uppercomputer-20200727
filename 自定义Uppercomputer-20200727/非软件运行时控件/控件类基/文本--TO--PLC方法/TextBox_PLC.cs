using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLC通讯规范接口;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.文本__TO__PLC方法
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/18 16:53:45 
    //  文件名：TextBox_PLC 
    //  版本：V1.0.1  
    //  说明： 处理文本类 调出键盘写入到PLC
    //  修改者：***
    //  修改说明： 
    //==============================================================
    class TextBox_PLC
    {
        public string plc(TextBox_base textBox)//根据PLC类型写入
        {
            switch (textBox.Plc)
            {
                case PLC.Mitsubishi:
                    IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                    if (mitsubishi.PLC_ready)
                    {
                        mitsubishi.PLC_write_D_register(textBox.PLC_Contact, textBox.PLC_Address, textBox.Control_Text, textBox.numerical);
                    }
                    else MessageBox.Show("未连接设备：" + textBox.Plc.ToString(), "Err");//推出异常提示
                    break;
                case PLC.Siemens:
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)
                    {
                        Siemens.PLC_write_D_register(textBox.PLC_Contact, textBox.PLC_Address, textBox.Control_Text, textBox.numerical);
                    }
                    else MessageBox.Show("未连接设备：" + textBox.Plc.ToString(), "Err");//推出异常提示
                    break;
                case PLC.Modbus_TCP:
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)
                    {
                        MODBUD_TCP.PLC_write_D_register(textBox.PLC_Contact, textBox.PLC_Address, textBox.Control_Text, textBox.numerical);
                    }
                    else MessageBox.Show("未连接设备：" + textBox.Plc.ToString(), "Err");//推出异常提示用户
                    break;
            }
            return "OK_RUN";
        }
        private numerical_format Index(string Name)//查询索引
        {
            foreach (numerical_format suit in Enum.GetValues(typeof(numerical_format)))
            {
                if (suit.ToString() == Name.Trim()) return suit;//遍历枚举查询索引
            }
            return numerical_format.Unsigned_32_Bit;//如果不匹配则返回默认无符号类型
        }
        /// <summary>
        /// 根据PLC类型读取--文本输入类
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="numerical_Class"></param>
        /// <param name="skinTextBox_Reform"></param>
        /// <returns></returns>
        public void Refresh(TextBox_base textBox)//根据PLC类型读取--文本输入类
        {
            switch (textBox.Plc)
            {
                case PLC.Mitsubishi:
                    IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                    if (mitsubishi.PLC_ready)//PLC是否准备完成
                    {
                        string data = mitsubishi.PLC_read_D_register(textBox.PLC_Contact, textBox.PLC_Address, textBox.numerical);//读取PLC数值
                        TextBox_state(textBox, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case PLC.Siemens:
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        string data = Siemens.PLC_read_D_register(textBox.PLC_Contact, textBox.PLC_Address, textBox.numerical);//读取PLC数值
                        TextBox_state(textBox, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
                case PLC.Modbus_TCP:
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        //由于modbus_TCP读写状态不同 读输出 写输入模式 
                        string data = MODBUD_TCP.PLC_read_D_register(textBox.PLC_Contact, textBox.PLC_Address, textBox.numerical);//读取PLC数值
                        TextBox_state(textBox, data);//填充文本数据--自动判断用户设定的小数点位置--多余的异常
                    }
                    break;
            }
        }
        /// <summary>
        /// 索引该值是否在符合当前PLC
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool IsNull(string data, PLC pLC)
        {
            switch (pLC)
            {
                case PLC.Mitsubishi:
                    return Enum.GetNames(typeof(Mitsubishi_D)).Where(pi => pi.ToString() == data).FirstOrDefault() == null ? false : true;
                case PLC.Siemens:
                    return Enum.GetNames(typeof(Siemens_D)).Where(pi => pi.ToString() == data).FirstOrDefault() == null ? false : true;
                case PLC.Modbus_TCP:
                    return Enum.GetNames(typeof(Modbus_TCP_D)).Where(pi => pi.ToString() == data).FirstOrDefault() == null ? false : true;
                case PLC.OmronCIP:
                case PLC.OmronTCP:
                case PLC.OmronUDP:
                    return Enum.GetNames(typeof(Omron_D)).Where(pi => pi.ToString() == data).FirstOrDefault() == null ? false : true;
            }
            return true;
        }
        /// <summary>
        /// 填充文本数据
        /// </summary>
        /// <param name="skinTextBox_Reform"></param>
        /// <param name="numerical_Class"></param>
        /// <param name="Data"></param>
        private void TextBox_state(TextBox_base textBox, string Data)//填充文本数据
        {
            try
            {
                int Inde = Data.IndexOf('.');//搜索数据是否有小数点
                if (Inde > 0 || Inde >= textBox.Decimal_Below)//判断是否有小数点
                {
                    int In = Data.Length - 1 - textBox.Decimal_Below - Inde;//实现原理--先获取数据长度-后减1-小数点-在减去设定数-获取小数点位置
                    for (int i = 0; i < In; i++) Data = Data.Remove(Data.Length - 1, 1); //移除掉                
                }
                else
                    Data = complement(Data, textBox);//然后位数不够--自动补码
                if (textBox.Decimal_Below < 1) Data = Data.Replace('.', ' ');//如果用户设定没有小数点直接去除小数点
                textBox.Control_Text = Data;//直接填充数据
            }
            catch { return; }
        }
        public string PLCContact(PLC pLC)
        {
            switch (pLC)
            {
                case PLC.Mitsubishi:
                    return Enum.GetNames(typeof(Mitsubishi_D))[0];
                case PLC.Siemens:
                    return Enum.GetNames(typeof(Siemens_D))[0];
                case PLC.Modbus_TCP:
                    return Enum.GetNames(typeof(Modbus_TCP_D))[0];
                case PLC.OmronCIP:
                case PLC.OmronTCP:
                case PLC.OmronUDP:
                    return Enum.GetNames(typeof(Omron_D))[0];
            }
            return "D";
        }
        /// <summary>
        /// 实现浮点小数自动补码
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="numerical_Class"></param>
        /// <returns></returns>
        private string complement(string Name, TextBox_base textBox)//实现浮点小数自动补码
        {
            int Inde = Name.IndexOf('.');//搜索数据是否有小数点
            if (Inde < 0 & textBox.Decimal_Below != 0) Name += ".";//自动补码小数点
            if (textBox.Decimal_Below > 0 & Inde < 0)
            {
                for (int i = 0; i < textBox.Decimal_Below; i++) Name += "0";//填充数据
            }
            if (textBox.Decimal_Below > 0 & Inde > 0)
            {
                int In = Name.Length - 1 - Inde;
                for (int i = 0; i < textBox.Decimal_Below - In; i++) Name += "0";//填充数据
            }
            return Name;//返回数据
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
