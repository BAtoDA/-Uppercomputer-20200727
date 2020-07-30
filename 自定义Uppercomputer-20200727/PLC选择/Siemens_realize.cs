using CCWin.SkinClass;
using CSEngineTest;
using HslCommunication;
using HslCommunication.Profinet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口
{

    /// <summary>
    /// 采用S7通讯协议--默认端口102--open-读取-写入--继承接口IPLC_interface
    /// </summary>
    class Siemens_realize : PLC_public_Class, IPLC_interface, macroinstruction_PLC_interface
    {
        public IPEndPoint IPEndPoint { get; set; }//IP地址
        static private bool PLC_ready;//内部PLC状态
        static private int PLCerr_code;//内部报警代码
        static private string PLCerr_content;//内部报警内容
        //西门子S7通讯类--
        private static SiemensTcpNet siemensTcpNet = null;
        //互斥锁(Mutex)，用于多线程中防止两条线程同时对一个公共资源进行读写的机制。
        static Mutex mutex;//定义互斥锁名称
        //实现接口的属性
        /// <summary>
        /// 西门子 Siemens PLC状态
        /// </summary>
        bool IPLC_interface.PLC_ready { get => PLC_ready; } //PLC状态
        /// <summary>
        /// 宏指令 西门子 Siemens PLC状态
        /// </summary>
        bool macroinstruction_PLC_interface.PLC_ready { get => PLC_ready; } //PLC状态
        /// <summary>
        /// 西门子 Siemens PLC报警代码
        /// </summary>
        int IPLC_interface.PLCerr_code { get => PLCerr_code; }//PLC报警代码
        /// <summary>
        /// 宏指令 西门子 Siemens PLC报警代码
        /// </summary>
        int macroinstruction_PLC_interface.PLCerr_code { get => PLCerr_code; }//PLC报警代码
        /// <summary>
        /// 西门子 Siemens  PLC报警内容
        /// </summary>
        string IPLC_interface.PLCerr_content { get => PLCerr_content; }//PLC报警内容
        /// <summary>
        /// 宏指令 西门子 Siemens  PLC报警内容
        /// </summary>
        string macroinstruction_PLC_interface.PLCerr_content { get => PLCerr_content; }//PLC报警内容
        /// <summary>
        ///  西门子 Siemens   初始化---open--并且判断用户选择的类型
        /// </summary>
        /// <param name="iPEndPoint"></param>
        /// <param name="siemensPLCS"></param>
        public Siemens_realize(IPEndPoint iPEndPoint, SiemensPLCS siemensPLCS)//构造函数---初始化---open--并且判断用户选择的类型
        {
            this.IPEndPoint = iPEndPoint;//获取IP地址
            this.IPEndPoint.Port = int.Parse("102");//西门子S7默认端口
            siemensTcpNet = new SiemensTcpNet(siemensPLCS);//实例化对象
            mutex = new Mutex();//实例化互斥锁(Mutex)
        }
        public Siemens_realize()//无参数
        {
        }
        /// <summary>
        ///  西门子 Siemens 打开PLC
        /// </summary>
        /// <returns></returns>
        string IPLC_interface.PLC_open()//打开PLC
        {
            try
            {
                //利用西门子S7协议实现
                siemensTcpNet.PLCIpAddress = IPEndPoint.Address;//获取设置的IP
                siemensTcpNet.ConnectTimeout = 2000;//超时时间
                OperateResult connect = siemensTcpNet.ConnectServer();//获取操作结果
                if (connect.IsSuccess)//判断是否连接成功
                {
                    PLC_ready = true;//PLC开放正常
                    Message_run = false;//复位标志位
                    return "已成功链接到" + this.IPEndPoint.Address;
                }
                else
                {
                    PLC_ready = false;//PLC开放异常
                    // 切断连接
                    siemensTcpNet.ConnectClose();
                    MessageBox.Show("链接PLC" + this.IPEndPoint.Address.ToString() + "异常--请检查下位机状态");
                    return "链接PLC异常";//尝试连接PLC，如果连接成功则返回值为0
                }

            }
            catch (Exception e)
            {
                err(e);//异常处理
                return "链接PLC异常";//尝试连接PLC，如果连接成功则返回值为0
            }
        }
        /// <summary>
        /// 西门子 Siemens 读取PLC 位状态 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        List<bool> IPLC_interface.PLC_read_M_bit(string Name, string id)//读取PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        {
            string result = "FALSE";//定义获取数据变量
            lock (this)
            {
                try
                {
                    mutex.WaitOne(3000);//加锁
                                        // 读取bool变量
                    readResultRender(siemensTcpNet.ReadBoolFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);//读取自定地址变量状态
                    mutex.ReleaseMutex();//解锁
                }
                catch { }
            }
            return new List<bool>() { Convert.ToBoolean(result ?? "FALSE") };//返回数据
        }
        /// <summary>
        /// 宏指令 西门子 Siemens 读取PLC 位状态 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        List<bool> macroinstruction_PLC_interface.PLC_read_M_bit(string Name, string id)//读取PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        {
            string result = "FALSE";//定义获取数据变量
            if (PLC_ready != true) return new List<bool>() { Convert.ToBoolean(result ?? "FALSE") };//PLC未准备好返回数据
            IPLC_interface pLC_Interface = this;//实例化接口
            return pLC_Interface.PLC_read_M_bit(Name, id);//返回数据
        }
        /// <summary>
        ///  西门子 Siemens 写入PLC 位状态 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="button_State"></param>
        /// <returns></returns>
        List<bool> IPLC_interface.PLC_write_M_bit(string Name, string id, Button_state button_State)//写入PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        {
            string result = "FALSE";//定义获取数据变量
            lock (this)
            {
                try
                {
                    mutex.WaitOne(3000);//加锁
                                        // 写bool变量
                    writeResultRender(siemensTcpNet.WriteIntoPLC(Name.Trim() + id.Trim(), Convert.ToBoolean(button_State.ToInt32())), Name.Trim() + id.Trim());//写入自定地址变量状态
                    mutex.ReleaseMutex();//解锁
                }
                catch { }
            }
            return new List<bool>() { Convert.ToBoolean(result ?? "FALSE") };//返回数据
        }
        /// <summary>
        /// 宏指令 西门子 Siemens 写入PLC 位状态 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="button_State"></param>
        /// <returns></returns>
        List<bool> macroinstruction_PLC_interface.PLC_write_M_bit(string Name, string id, bool on_off)//写入PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        {
            string result = "FALSE";//定义获取数据变量
            if (PLC_ready != true) return new List<bool>() { Convert.ToBoolean(result ?? "FALSE") };//PLC未准备好返回数据
            IPLC_interface pLC_Interface = this;//实例化接口
            return pLC_Interface.PLC_write_M_bit(Name, id, on_off ? Button_state.ON : Button_state.Off);//返回数据
        }
        /// <summary>
        /// 西门子 Siemens 读寄存器--转换相应类型
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string IPLC_interface.PLC_read_D_register(string Name, string id, numerical_format format)//读寄存器--转换相应类型
        {
            string result = "0";//定义获取数据变量        
            lock (this)
            {
                try
                {
                    mutex.WaitOne(3000);
                    switch (format)
                    {
                        case numerical_format.Signed_16_Bit:
                        case numerical_format.BCD_16_Bit:
                            // 读取short变量
                            readResultRender(siemensTcpNet.ReadShortFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Signed_32_Bit:
                        case numerical_format.BCD_32_Bit:
                            // 读取int变量
                            readResultRender(siemensTcpNet.ReadIntFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Binary_16_Bit:
                            // 读取16位二进制数
                            String data_1 = Convert.ToString(result.ToInt32(), 2);
                            readResultRender(siemensTcpNet.ReadShortFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Binary_32_Bit:
                            // 读取32位二进制数
                            String data_2 = Convert.ToString(result.ToInt32(), 2);
                            readResultRender(siemensTcpNet.ReadIntFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Float_32_Bit:
                            // 读取float变量
                            readResultRender(siemensTcpNet.ReadFloatFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Hex_16_Bit:
                            // 读取short变量
                            readResultRender(siemensTcpNet.ReadShortFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            result = Convert.ToInt32(result).ToString("X");
                            break;
                        case numerical_format.Hex_32_Bit:
                            // 读取int变量
                            readResultRender(siemensTcpNet.ReadIntFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            result = Convert.ToInt32(result).ToString("X");
                            break;
                        case numerical_format.Unsigned_16_Bit:
                            // 读取ushort变量
                            readResultRender(siemensTcpNet.ReadUShortFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Unsigned_32_Bit:
                            // 读取uint变量
                            readResultRender(siemensTcpNet.ReadUIntFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                    }
                    mutex.ReleaseMutex();
                }
                catch { }
            }
            return result;//返回数据
        }
        /// <summary>
        /// 宏指令 西门子 Siemens 读寄存器--转换相应类型
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string macroinstruction_PLC_interface.PLC_read_D_register(string Name, string id, string format)//读寄存器--转换相应类型
        {
            if (PLC_ready != true) return "0";//PLC-未准备好返回数据
            IPLC_interface pLC_Interface = this;//创建接口本类数据
            return pLC_Interface.PLC_read_D_register(Name, id, inquire_numerical(format));//返回数据
        }
        /// <summary>
        /// 西门子 Siemens 写寄存器--转换类型--并且写入
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string IPLC_interface.PLC_write_D_register(string Name, string id, string content, numerical_format format)//写寄存器--转换类型--并且写入
        {
            string result = "0";//定义获取数据变量           
            lock (this)
            {
                try
                {
                    mutex.WaitOne(3000);
                    switch (format)
                    {
                        case numerical_format.Signed_16_Bit:
                        case numerical_format.BCD_16_Bit:
                            writeResultRender(siemensTcpNet.WriteIntoPLC(Name.Trim() + id.Trim(), short.Parse(content)), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Signed_32_Bit:
                        case numerical_format.BCD_32_Bit:
                            writeResultRender(siemensTcpNet.WriteIntoPLC(Name.Trim() + id.Trim(), int.Parse(content)), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Binary_16_Bit:
                            writeResultRender(siemensTcpNet.WriteIntoPLC(Name.Trim() + id.Trim(), short.Parse(Convert.ToInt32(content, 2).ToString())), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Binary_32_Bit:
                            writeResultRender(siemensTcpNet.WriteIntoPLC(Name.Trim() + id.Trim(), int.Parse(Convert.ToInt32(content, 2).ToString())), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Float_32_Bit:
                            writeResultRender(siemensTcpNet.WriteIntoPLC(Name.Trim() + id.Trim(), float.Parse(content)), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Hex_16_Bit:
                            writeResultRender(siemensTcpNet.WriteIntoPLC(Name.Trim() + id.Trim(), short.Parse(Convert.ToInt32(content, 16).ToString())), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Hex_32_Bit:
                            writeResultRender(siemensTcpNet.WriteIntoPLC(Name.Trim() + id.Trim(), int.Parse(Convert.ToInt32(content, 16).ToString())), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Unsigned_16_Bit:
                            writeResultRender(siemensTcpNet.WriteIntoPLC(Name.Trim() + id.Trim(), int.Parse(content)), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Unsigned_32_Bit:
                            writeResultRender(siemensTcpNet.WriteIntoPLC(Name.Trim() + id.Trim(), int.Parse(content)), Name.Trim() + id.Trim());
                            break;
                    }
                    mutex.ReleaseMutex();
                }
                catch { }
            }
            return result;//返回数据
        }
        /// <summary>
        /// 宏指令 西门子 Siemens 写寄存器
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string macroinstruction_PLC_interface.PLC_write_D_register(string Name, string id, string content, string format)//写寄存器--转换类型--并且写入
        {
            if (PLC_ready != true) return "0";//PLC-未准备好返回数据
            IPLC_interface pLC_Interface = this;//创建接口本类数据
            return pLC_Interface.PLC_write_D_register(Name, id, content, inquire_numerical(format));//返回数据
        }
        /// <summary>
        /// 西门子 Siemens 批量读取寄存器
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        List<int> IPLC_interface.PLC_read_D_register_bit(string Name, string id, numerical_format format, string Index)//批量读取寄存器
        {
            List<int> Data = new List<int>();
            lock (this)
            {
                try
                {
                    mutex.WaitOne(3000);
                    Data = Mitsubishi_to_Index_numerical(Name, id.ToInt32(), format, Index.ToInt32(), this);//批量读取寄存器并且返回数据
                    mutex.ReleaseMutex();
                }
                catch { }
                return Data;
            }
        }
        /// <summary>
        /// 宏指令西门子 Siemens 批量读取寄存器
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        List<int> macroinstruction_PLC_interface.PLC_read_D_register_bit(string Name, string id, string format, string Index)//批量读取寄存器
        {
            if (PLC_ready != true) return new List<int>() { 0 };//PLC-未准备好返回数据
            IPLC_interface pLC_Interface = this;//创建接口本类数据
            return pLC_Interface.PLC_read_D_register_bit(Name, id, inquire_numerical(format), Index);//返回数据
        }
        /// <summary>
        /// 西门子 Siemens 批量写入寄存器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> IPLC_interface.PLC_write_D_register_bit(string id)//批量写入寄存器
        {
            return new List<int>() { 1 };
        }
        /// <summary>
        /// 宏指令 西门子 Siemens  批量写入寄存器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> macroinstruction_PLC_interface.PLC_write_D_register_bit(string id)
        {
            return new List<int>() { 1 };
        }
        static bool Message_run = false;//定义消息以弹出不在弹窗
        /// <summary>
        /// 统一的读取结果的数据解析，显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="address"></param>
        /// <param name="textBox"></param>
        private void readResultRender<T>(OperateResult<T> result, string address, ref string data)
        {
            if (result.IsSuccess)
            {
                data = result.Content.ToString();//获取回传的数据
            }
            else
            {
                PLC_ready = false;//读取异常
                PLCerr_content = DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 读取失败{Environment.NewLine}原因：{result.ToMessageShowString()}";
                if (Message_run != true)
                {
                    MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 读取失败{Environment.NewLine}原因：{result.ToMessageShowString()}");
                    Message_run = true;
                }
            }
        }

        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="address"></param>
        private void writeResultRender(OperateResult result, string address)
        {
            if (result.IsSuccess != true)
            {
                PLC_ready = false;//读取异常
                PLCerr_content = DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 写入失败{Environment.NewLine}原因：{result.ToMessageShowString()}";
                if (Message_run != true)
                {
                    MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 写入失败{Environment.NewLine}原因：{result.ToMessageShowString()}");
                    Message_run = true;
                }
            }
        }
        private void err(Exception e)
        {
            PLC_ready = false;//PLC开放异常
            PLCerr_code = e.HResult;
            PLCerr_content = e.Message;
            Message_run = true;
            MessageBox.Show("链接PLC异常");
        }
    }
}
