using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinClass;
using CCWin.SkinControl;
using CSEngineTest;
using PLC通讯规范接口;
using Sunny.UI;
using 欧姆龙Fins协议.欧姆龙.报文处理;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;

namespace 自定义Uppercomputer_20200727.控件重做.控件类基.文本__TO__PLC方法
{
    class TextBox_PLC
    {
        /// <summary>
        /// 向设备写入数据
        /// </summary>
        /// <param name="pLC">设备类型</param>
        /// <param name="format">需要写入的格式</param>
        /// <param name="pattern">读写地址</param>
        /// <param name="specific">读写具体地址</param>
        /// <param name="different">是否读写不同地址</param>
        /// <param name="pattern1">写入地址</param>
        /// <param name="specific1">写入具体地址</param>
        /// <param name="Data">需要写入的数据</param>
        /// <returns></returns>
        public string plc(string pLC, string format, string pattern, string specific, int different, string pattern1, string specific1,string Data)//根据PLC类型写入
        {
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)
                        {
                            if (different == 0)
                                mitsubishi_AxActUtlType.PLC_write_D_register(pattern, specific, Data, Index(format));
                            else
                                mitsubishi_AxActUtlType.PLC_write_D_register(pattern1, specific1, Data, Index(format));
                            ShowSuccessTip($"向设备:{mitsubishi_AxActUtlType.GetType().Name} 地址:{(different == 0 ? pattern + specific : pattern1 + specific1)}写入:{ Data}",500);
                        }
                        else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)
                        {
                            if (different == 0)
                                mitsubishi.PLC_write_D_register(pattern, specific, Data, Index(format));
                            else
                                mitsubishi.PLC_write_D_register(pattern1, specific1, Data, Index(format));
                            ShowSuccessTip($"向设备:{mitsubishi.GetType().Name} 地址:{(different == 0 ? pattern + specific : pattern1 + specific1)}写入:{ Data}", 500);
                        }
                        else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)
                    {
                        if (different == 0)
                            Siemens.PLC_write_D_register(pattern, specific, Data, Index(format));
                        else
                            Siemens.PLC_write_D_register(pattern1, specific1, Data, Index(format));
                        ShowSuccessTip($"向设备:{Siemens.GetType().Name} 地址:{(different == 0 ? pattern + specific : pattern1 + specific1)}写入:{ Data}", 500);
                    }
                    else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    break;
                case "Modbus_TCP":
                    IPLC_interface MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.PLC_ready)
                    {
                        if (different == 0)
                            MODBUD_TCP.PLC_write_D_register(pattern, specific, Data, Index(format));
                        else
                            MODBUD_TCP.PLC_write_D_register(pattern1, specific1, Data, Index(format));
                        ShowSuccessTip($"向设备:{MODBUD_TCP.GetType().Name} 地址:{(different == 0 ? pattern + specific : pattern1 + specific1)}写入:{ Data}", 500);
                    }
                    else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    break;
                //写入到 宏指令 静态区D_Data
                case "HMI":
                    if (different == 0)
                        macroinstruction_data<int>.D_Data[specific.ToInt32()] = Data;
                    else
                        macroinstruction_data<int>.D_Data[specific1.ToInt32()] = Data;
                    ShowSuccessTip($"向设备:HMI 地址:{(different == 0 ? pattern + specific : pattern1 + specific1)}写入:{ Data}", 500);
                    break;
                case "OmronTCP":
                    IPLC_interface FinsTcp = new OmronFinsTcp();//实例化接口--实现OmronTCP
                    if (FinsTcp.PLC_ready)
                    {
                        if (different == 0)
                            FinsTcp.PLC_write_D_register(pattern, specific, Data, Index(format));
                        else
                            FinsTcp.PLC_write_D_register(pattern1, specific1, Data, Index(format));
                        ShowSuccessTip($"向设备:{FinsTcp.GetType().Name} 地址:{(different == 0 ? pattern + specific : pattern1 + specific1)}写入:{ Data}", 500);
                    }
                    else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    break;
                case "OmronUDP":
                    IPLC_interface FinsUdp = new OmronFinsUDP();//实例化接口--实现OmronUDP
                    if (FinsUdp.PLC_ready)
                    {
                        if (different == 0)
                            FinsUdp.PLC_write_D_register(pattern, specific, Data, Index(format));
                        else
                            FinsUdp.PLC_write_D_register(pattern1, specific1, Data, Index(format));
                        ShowSuccessTip($"向设备:{FinsUdp.GetType().Name} 地址:{(different == 0 ? pattern + specific : pattern1 + specific1)}写入:{ Data}", 500);
                    }
                    else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    break;
                case "OmronCIP":
                    IPLC_interface Finscip = new OmronFinsCIP();//实例化接口--实现OmronCIP
                    if (Finscip.PLC_ready)
                    {
                        if (different == 0)
                            Finscip.PLC_write_D_register(pattern, specific, Data, Index(format));
                        else
                            Finscip.PLC_write_D_register(pattern1, specific1, Data, Index(format));
                        ShowSuccessTip($"向设备:{Finscip.GetType().Name} 地址:{(different == 0 ? pattern + specific : pattern1 + specific1)}写入:{ Data}", 500);
                    }
                    else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    break;
            }
            return "OK_RUN";
        }
        /// <summary>
        /// 根据PLC类型读取--圆形图类 doughnut_Chart
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="doughnut_Chart_Class"></param>
        /// <param name="doughnut_Chart_Reform"></param>
        /// <returns></returns>
        public List<int> Refresh(string pLC, string format, string pattern, string specific,int aisle)//根据PLC类型读取--圆形图类 doughnut_Chart
        {
            List<int> doughnut_Chart_Data = new List<int>();//指示要填充的数据--作为显示
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            doughnut_Chart_Data = mitsubishi_AxActUtlType.PLC_read_D_register_bit(pattern, specific.Trim(), Index(format), aisle.ToString());//读取PLC数值
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            doughnut_Chart_Data = mitsubishi.PLC_read_D_register_bit(pattern, specific.Trim(), Index(format), aisle.ToString());//读取PLC数值
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        doughnut_Chart_Data = Siemens.PLC_read_D_register_bit(pattern, specific.Trim(), Index(format), aisle.ToString());//读取PLC数值
                    }
                    break;
                case "Modbus_TCP":
                    IPLC_interface MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.PLC_ready)//PLC是否准备完成
                    {
                        //由于modbus_TCP读写状态不同 读输出 写输入模式 
                        doughnut_Chart_Data = MODBUD_TCP.PLC_read_D_register_bit(pattern, specific.Trim(), Index(format), aisle.ToString());//读取PLC数值
                    }
                    break;
                case "HMI":
                    doughnut_Chart_Data = numerical_public.Index(aisle + 1, specific.ToInt32(), doughnut_Chart_Data);//获取数据
                    //获取到数据进行填充 
                    break;
                case "OmronTCP":
                    IPLC_interface FinsTcp = new OmronFinsTcp();//实例化接口--实现OmronTCP
                    if (FinsTcp.PLC_ready)
                    {
                        doughnut_Chart_Data = FinsTcp.PLC_read_D_register_bit(pattern, specific.Trim(), Index(format), aisle.ToString());//读取PLC数值
                    }
                    break;
                case "OmronUDP":
                    IPLC_interface FinsUdp = new OmronFinsUDP();//实例化接口--实现OmronUDP
                    if (FinsUdp.PLC_ready)
                    {
                        doughnut_Chart_Data = FinsUdp.PLC_read_D_register_bit(pattern, specific.Trim(), Index(format), aisle.ToString());//读取PLC数值
                    }
                    break;
                case "OmronCIP":
                    IPLC_interface Finscip = new OmronFinsCIP();//实例化接口--实现OmronCIP
                    if (Finscip.PLC_ready)
                    {
                        doughnut_Chart_Data = Finscip.PLC_read_D_register_bit(pattern, specific.Trim(), Index(format), aisle.ToString());//读取PLC数值
                    }
                    break;
            }
            return doughnut_Chart_Data;
        }
        /// <summary>
        /// int泛型表转换成双精度浮点数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<double> int_to_double(List<int> data)
        {
            List<double> vs = new List<double>();
            foreach (int i in data) vs.Add(Convert.ToDouble(i));
            return vs;
        }
        /// <summary>
        /// 查询资料格式
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public numerical_format Index(string Name)//查询索引
        {
            foreach (numerical_format suit in Enum.GetValues(typeof(numerical_format)))
            {
                if (suit.ToString() == Name.Trim()) return suit;//遍历枚举查询索引
            }
            return numerical_format.Unsigned_32_Bit;//如果不匹配则返回默认无符号类型
        }
        /// <summary>
        /// 实现浮点小数自动补码
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="numerical_Class"></param>
        /// <returns></returns>
        public string complement(string Name,int Min)//实现浮点小数自动补码
        {
            int Inde = Name.IndexOf('.');//搜索数据是否有小数点
            if (Inde < 0 & Min != 0) Name += ".";//自动补码小数点
            if (Min > 0 & Inde < 0)
            {
                for (int i = 0; i < Min; i++) Name += "0";//填充数据
            }
            if (Min > 0 & Inde > 0)
            {
                int In = Name.Length - 1 - Inde;
                for (int i = 0; i < Min - In; i++) Name += "0";//填充数据
            }
            return Name;//返回数据
        }
        /// <summary>
        /// 根据PLC类型读取--文本输入类
        /// </summary>
        /// <param name="pLC"></param>
        /// <param name="numerical_Class"></param>
        /// <param name="skinTextBox_Reform"></param>
        /// <returns></returns>
        public string Refresh(string pLC, string format, string pattern, string specific)//根据PLC类型读取--文本输入类
        {
            string data = "00";
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            data = mitsubishi_AxActUtlType.PLC_read_D_register(pattern, specific, Index(format));//读取PLC数值
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                             data = mitsubishi.PLC_read_D_register(pattern, specific, Index(format));//读取PLC数值
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        data = Siemens.PLC_read_D_register(pattern, specific, Index(format));//读取PLC数值
                    }
                    break;
                case "Modbus_TCP":
                    IPLC_interface MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.PLC_ready)//PLC是否准备完成
                    {
                        //由于modbus_TCP读写状态不同 读输出 写输入模式 
                        data = MODBUD_TCP.PLC_read_D_register(pattern, specific, Index(format));//读取PLC数值
                    }
                    break;
                case "HMI":
                    if (macroinstruction_data<int>.D_Data[specific.Trim().ToInt32()].IsNull() != true)
                        data = Convert.ToString(macroinstruction_data<int>.D_Data[specific.Trim().ToInt32()] ?? "0");//直接填充数据
                    else
                        data = "0";
                    break;
                case "OmronTCP":
                    IPLC_interface FinsTcp = new OmronFinsTcp();//实例化接口--实现"OmronTCP
                    if (FinsTcp.PLC_ready)//PLC是否准备完成
                    {
                        data = FinsTcp.PLC_read_D_register(pattern, specific, Index(format));//读取PLC数值
                    }
                    break;
                case "OmronUDP":
                    IPLC_interface FinsUDP = new OmronFinsUDP();//实例化接口--实现"OmronTCP
                    if (FinsUDP.PLC_ready)//PLC是否准备完成
                    {
                        data = FinsUDP.PLC_read_D_register(pattern, specific, Index(format));//读取PLC数值
                    }
                    break;
                case "OmronCIP":
                    IPLC_interface Finscip = new OmronFinsCIP();//实例化接口--实现"OmronTCP
                    if (Finscip.PLC_ready)//PLC是否准备完成
                    {
                        data = Finscip.PLC_read_D_register(pattern, specific, Index(format));//读取PLC数值
                    }
                    break;
            }
            return data;
        }
        /// <summary>
        /// 显示成功消息
        /// </summary>
        /// <param name="text">消息文本</param>
        /// <param name="delay">消息停留时长(ms)。默认1秒</param>
        /// <param name="floating">是否漂浮</param>
        public void ShowSuccessTip(string text, int delay = 1000, bool floating = true)
            => UIMessageTip.ShowOk(text, delay, floating);
    }
}
