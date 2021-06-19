using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSEngineTest;
using PLC通讯规范接口;
using Sunny.UI;
using 欧姆龙Fins协议.报文处理;
using 欧姆龙Fins协议.欧姆龙.报文处理;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;

namespace 自定义Uppercomputer_20200727.控件重做.控件类基.按钮__TO__PLC方法
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/17 17:20:25 
    //  文件名：Button_PLC 
    //  版本：V1.0.1  
    //  说明： 处理按钮类 点击事件写入到PLC
    //  修改者：***
    //  修改说明： 
    //==============================================================
    class Button_to_plc : IDisposable
    {
        public bool state = false;//定义标志位--复归型按钮-判断状态
        /// <summary>
        /// 写入设备
        /// </summary>
        /// <param name="pLC">链接的PLC类型</param>
        /// <param name="command">需要操作设备的命令</param>
        /// <param name="pattern">链接PLC的地址</param>
        /// <param name="specific">链接PLC的具体地址</param>
        /// <param name="different">是否读写不同地址</param>
        /// <param name="pattern1">读写不同PLC的地址</param>
        /// <param name="specific1">读写不同PLC的具体地址</param>
        /// <returns></returns>
        public string plc(string pLC, string command, string pattern, string specific, int different, string pattern1, string specific1)//根据PLC类型写入
        {
            switch (pLC)
            {
                case "Mitsubishi"://三菱有二种模式 --在线与仿真
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            Button_write_select(command, mitsubishi_AxActUtlType, pattern, specific, different, pattern1, specific1);//根据按钮模式进行写入操作
                        }
                        else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim()+ "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            Button_write_select(command, mitsubishi, pattern, specific, different, pattern1, specific1);//根据按钮模式进行写入操作
                        }
                        else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        Button_write_select(command, Siemens, pattern, specific, different, pattern1, specific1);//根据按钮模式进行写入操作
                    }
                    else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    break;
                case "Modbus_TCP":
                    IPLC_interface MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.PLC_ready)//PLC是否准备完成
                    {
                        Button_write_select(command, MODBUD_TCP, pattern, specific, different, pattern1, specific1);//根据按钮模式进行写入操作
                    }
                    else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    break;
                //访问 宏指令数据区--Data_M
                case "HMI":
                    if (different == 0)
                        state = Button_HMI_public.Button_HMI_write_select(Convert.ToInt32(specific), command);//根据按钮模式进行写入操作 
                    else
                        state = Button_HMI_public.Button_HMI_write_select(Convert.ToInt32(specific), command);//根据按钮模式进行写入操作 
                    break;
                case "OmronTCP":
                    IPLC_interface OmronTCP = new OmronFinsTcp();//实例化接口
                    if (OmronTCP.PLC_ready)//PLC是否准备完成
                    {
                        Button_write_select(command, OmronTCP, pattern, specific, different, pattern1, specific1);//根据按钮模式进行写入操作
                    }
                    else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    break;
                case "OmronUDP":
                    IPLC_interface OmronUDP =new OmronFinsUDP();//实例化接口
                    if (OmronUDP.PLC_ready)//PLC是否准备完成
                    {
                        Button_write_select(command, OmronUDP, pattern, specific, different, pattern1, specific1);//根据按钮模式进行写入操作
                    }
                    else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    break;
                case "OmronCIP":
                    IPLC_interface OmronCIP =new OmronFinsCIP();//实例化接口
                    if (OmronCIP.PLC_ready)//PLC是否准备完成
                    {
                        Button_write_select(command, OmronCIP, pattern, specific, different, pattern1, specific1);//根据按钮模式进行写入操作
                    }
                    else UINotifierHelper.ShowNotifier("未连接设备：" + pLC.Trim() + "Err", UINotifierType.WARNING, UILocalize.WarningTitle, false, 1000);//推出异常提示用户
                    break;
            }
            return "OK";
        }
        /// <summary>
        /// 写入设备
        /// </summary>
        /// <param name="pLC">链接的PLC类型</param>
        /// <param name="pattern">链接PLC的地址</param>
        /// <param name="specific">链接PLC的具体地址</param>
        /// <param name="different">是否读写不同地址</param>
        /// <param name="pattern1">读写不同PLC的地址</param>
        /// <param name="specific1">读写不同PLC的具体地址</param>
        /// <param name="state">复归型状态</param>
        /// <returns></returns>
        public string plc(string pLC, string pattern, string specific, int different, string pattern1, string specific1, bool state)//根据PLC类型写入--为复归型按钮使用
        {
            this.plc(pLC, "复归型_Off", pattern, specific, different, pattern1, specific1);
            return "OK";
        }
        /// <summary>
        /// 写入状态
        /// </summary>
        /// <param name="Name">读写取设备类型</param>
        /// <param name="pLC_Interface">通讯类型接口</param>
        /// <param name="pattern">读取设备地址</param>
        /// <param name="specific">读取设备具体地址</param>
        /// <param name="different">读写不同地址</param>
        /// <param name="pattern1">读写设备地址</param>
        /// <param name="specific1">读写设备具体地址</param>
        private void Button_write_select(string Name, IPLC_interface pLC_Interface, string pattern, string specific, int different, string pattern1, string specific1)//按照按钮模式写入
        {
            switch (Name)
            {
                case "Set_as_on"://设置常ON
                    if (different == 0)
                        pLC_Interface.PLC_write_M_bit(pattern, specific, PLC通讯规范接口.Button_state.ON);//写入常ON
                    else
                        pLC_Interface.PLC_write_M_bit(pattern1, specific1, PLC通讯规范接口.Button_state.ON);//写入常ON
                    ShowSuccessTip($"向设备:{pLC_Interface.GetType().Name} 地址:{(different==0?pattern+specific: pattern1+specific1)}写入{true} 成功",500);
                    break;
                case "Set_as_off"://设置常OFF
                    if (different == 0)
                        pLC_Interface.PLC_write_M_bit(pattern, specific, PLC通讯规范接口.Button_state.Off);//写入常Off
                    else
                        pLC_Interface.PLC_write_M_bit(pattern1, specific1, PLC通讯规范接口.Button_state.Off);//写入常Off
                    ShowSuccessTip($"向设备:{pLC_Interface.GetType().Name} 地址:{(different == 0 ? pattern + specific : pattern1 + specific1)}写入{false} 成功",500);
                    break;
                case "切换开关":
                    if (different == 0)
                    {
                        List<bool> data = pLC_Interface.PLC_read_M_bit(pattern, specific);//先读取要写入的状态
                        pLC_Interface.PLC_write_M_bit(pattern, specific, data[0] == true ? PLC通讯规范接口.Button_state.Off : PLC通讯规范接口.Button_state.ON);//根据要写入的状态进行取反
                        ShowSuccessTip($"向设备:{pLC_Interface.GetType().Name} 地址:{pattern + specific}写入{(data[0]?false:true)} 成功",500);
                    }
                    else
                    {
                        List<bool> data = pLC_Interface.PLC_read_M_bit(pattern1, specific1);//先读取要写入的状态
                        pLC_Interface.PLC_write_M_bit(pattern1, specific1, data[0] == true ? PLC通讯规范接口.Button_state.Off : PLC通讯规范接口.Button_state.ON);//根据要写入的状态进行取反
                        ShowSuccessTip($"向设备:{pLC_Interface.GetType().Name} 地址:{pattern1 + specific1}写入{(data[0] ? true : false)} 成功",500);
                    }
                    break;
                case "复归型":
                    if (different == 0)
                        pLC_Interface.PLC_write_M_bit(pattern, specific, PLC通讯规范接口.Button_state.ON);//先写入ON--后用事件复位-off
                    else
                        pLC_Interface.PLC_write_M_bit(pattern1, specific1, PLC通讯规范接口.Button_state.ON);//先写入ON--后用事件复位-off
                    state = true;//标志位
                    ShowSuccessTip($"向设备:{pLC_Interface.GetType().Name} 地址:{(different == 0 ? pattern + specific : pattern1 + specific1)}写入{true} 成功",500);
                    break;
                case "复归型_Off":
                    if (different == 0)
                        pLC_Interface.PLC_write_M_bit(pattern, specific, PLC通讯规范接口.Button_state.Off);//先写入ON--后用事件复位-off
                    else
                        pLC_Interface.PLC_write_M_bit(pattern1, specific1, PLC通讯规范接口.Button_state.Off);//先写入ON--后用事件复位-off
                    state = false;//标志位
                    break;
            }
        }
        /// <summary>
        /// 定时刷新控件
        /// </summary>
        /// <param name="button"></param>
        public Button_state Refresh(Button_base button_Base, string pLC, string pattern, string specific)//根据PLC类型读取--按钮类
        {
           Button_state button_State = Button_state.Off;//按钮状态
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            List<bool> data = mitsubishi_AxActUtlType.PLC_read_M_bit(pattern, specific);//读取状态
                            button_State = data[0] == true ?Button_state.ON : Button_state.Off;
                        }
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            List<bool> data = mitsubishi.PLC_read_M_bit(pattern, specific);//读取状态
                            button_State = data[0] == true ? Button_state.ON : Button_state.Off;
                        }
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = Siemens.PLC_read_M_bit(pattern, specific);//读取状态
                        button_State = data[0] == true ? Button_state.ON : Button_state.Off;
                    }
                    break;
                case "Modbus_TCP":
                    IPLC_interface MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = MODBUD_TCP.PLC_read_M_bit(pattern, specific);//读取状态
                        button_State = data[0] == true ? Button_state.ON : Button_state.Off;
                    }
                    break;
                case "HMI":
                    button_State = macroinstruction_data<bool>.M_Data[Convert.ToInt32(specific)] == true ? Button_state.ON : Button_state.Off;
                    break;
                case "OmronTCP":
                    IPLC_interface OmronTCP = new OmronFinsTcp();//实例化接口--实现西门子在线访问
                    if (OmronTCP.PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = OmronTCP.PLC_read_M_bit(pattern, specific);//读取状态
                        button_State = data[0] == true ?Button_state.ON :Button_state.Off;
                    }
                    break;
                case "OmronUDP":
                    IPLC_interface OmronUDP = new OmronFinsUDP();//实例化接口--实现西门子在线访问
                    if (OmronUDP.PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = OmronUDP.PLC_read_M_bit(pattern, specific);//读取状态
                        button_State = data[0] == true ? Button_state.ON : Button_state.Off;
                    }
                    break;
                case "OmronCIP":
                    IPLC_interface OmronCIP = new OmronFinsCIP();//实例化接口--实现西门子在线访问
                    if (OmronCIP.PLC_ready)//PLC是否准备完成
                    {
                        List<bool> data = OmronCIP.PLC_read_M_bit(pattern, specific);//读取状态
                        button_State = data[0] == true ? Button_state.ON : Button_state.Off;
                    }
                    break;
            }
            return button_State;
        }
        /// <summary>
        /// 获取字体的对齐方式--按钮-文本类
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public System.Drawing.ContentAlignment ContentAlignment_1(string Name)//获取字体的对齐方式--按钮-文本类
        {
            System.Drawing.ContentAlignment contentAlignment = System.Drawing.ContentAlignment.MiddleCenter;//定义对齐方式
            switch (Name.Trim())
            {
                case "左对齐":
                    contentAlignment = System.Drawing.ContentAlignment.MiddleLeft;//设置左对齐
                    break;
                case "居中对齐":
                    contentAlignment = System.Drawing.ContentAlignment.MiddleCenter;//设置居中对齐
                    break;
                case "右对齐":
                    contentAlignment = System.Drawing.ContentAlignment.MiddleRight;//设置有右对齐
                    break;
            }
            return contentAlignment;//返回数据
        }
        /// <summary>
        /// 显示成功消息
        /// </summary>
        /// <param name="text">消息文本</param>
        /// <param name="delay">消息停留时长(ms)。默认1秒</param>
        /// <param name="floating">是否漂浮</param>
        public void ShowSuccessTip(string text, int delay = 1000, bool floating = true)
            => UIMessageTip.ShowOk(text, delay, floating);
        /// <summary>
        /// 显示警告消息
        /// </summary>
        /// <param name="text">消息文本</param>
        /// <param name="delay">消息停留时长(ms)。默认1秒</param>
        /// <param name="floating">是否漂浮</param>
        public void ShowWarningTip(string text, int delay = 1000, bool floating = true)
            => UIMessageTip.ShowWarning(text, delay, floating);
        public Button_to_plc()
        {
            Dispose(false);
        }
        //是否回收完毕
        bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //这里的参数表示示是否需要释放那些实现IDisposable接口的托管对象
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return; //如果已经被回收，就中断执行
            if (disposing)
            {
                //TODO:释放那些实现IDisposable接口的托管对象
            }
            //TODO:释放非托管资源，设置对象为null
            _disposed = true;
        }
    }
}
