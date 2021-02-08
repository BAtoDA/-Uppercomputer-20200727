using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinClass;
using CSEngineTest;
using HslCommunication;
using HslCommunication.Profinet;

namespace 自定义Uppercomputer_20200727.PLC选择
{
    /// <summary>
    /// 采用3E帧通讯协议--open-读取-写入--继承接口IPLC_interface
    /// </summary>
    class Mitsubishi_realize : PLC_public_Class, IPLC_interface, macroinstruction_PLC_interface
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public IPEndPoint IPEndPoint { get; set; }//IP地址
        static private bool PLC_ready;//内部PLC状态
        static private int PLCerr_code;//内部报警代码
        static private string PLCerr_content;//内部报警内容
        //三菱3E帧类--
        /// <summary>
        /// 三菱3E帧类
        /// </summary>
        public static MelsecNet melsec_net = null;
        //互斥锁(Mutex)，用于多线程中防止两条线程同时对一个公共资源进行读写的机制。
        /// <summary>
        /// 互斥锁(Mutex)，用于多线程中防止两条线程同时对一个公共资源进行读写的机制
        /// </summary>
        static Mutex mutex;//定义互斥锁名称
        //实现接口的属性
        /// <summary>
        ///  三菱 Mitsubishi PLC状态
        /// </summary>
        bool IPLC_interface.PLC_ready { get => PLC_ready; } //PLC状态
        /// <summary>
        /// 宏指令  三菱 Mitsubishi PLC状态
        /// </summary>
        bool macroinstruction_PLC_interface.PLC_ready { get => PLC_ready; } //PLC状态
        /// <summary>
        ///  三菱 Mitsubishi  PLC报警代码
        /// </summary>
        int IPLC_interface.PLCerr_code { get => PLCerr_code; }//PLC报警代码
        /// <summary>
        /// 宏指令 三菱 Mitsubishi  PLC报警代码
        /// </summary>
        int macroinstruction_PLC_interface.PLCerr_code { get => PLCerr_code; }//PLC报警代码
        /// <summary>
        /// 三菱 Mitsubishi   PLC报警内容
        /// </summary>
        string IPLC_interface.PLCerr_content { get => PLCerr_content; }//PLC报警内容
        /// <summary>
        /// 宏指令 三菱 Mitsubishi   PLC报警内容
        /// </summary>
        string macroinstruction_PLC_interface.PLCerr_content { get => PLCerr_content; }//PLC报警内容
        /// <summary>
        /// 三菱 Mitsubishi 初始化---open
        /// </summary>
        /// <param name="iPEndPoint"></param>
        public Mitsubishi_realize(IPEndPoint iPEndPoint)//构造函数---初始化---open
        {
            this.IPEndPoint = iPEndPoint;//获取IP地址
            melsec_net = new MelsecNet();//实例化对象
            mutex = new Mutex();//实例化互斥锁(Mutex)
        }
        public Mitsubishi_realize()//构造函数---多态
        {

        }
        /// <summary>
        /// 三菱 Mitsubishi 链接PLC
        /// </summary>
        /// <returns></returns>
        string IPLC_interface.PLC_open()
        {
            try
            {
                //利用三菱3E帧实现
                melsec_net.PLCIpAddress = IPEndPoint.Address;//获取设置的IP
                melsec_net.PortRead = IPEndPoint.Port;//获取设置的端口
                melsec_net.ConnectClose();//切换通讯模式
                melsec_net.ConnectTimeout = 500;
                OperateResult connect = melsec_net.ConnectServer();//获取操作结果
                retry = 0;
                if (connect.IsSuccess)//判断是否连接成功
                {
                    PLC_ready = true;//PLC开放正常
                    return "已成功链接到" + this.IPEndPoint.Address;
                }
                else
                {
                    PLC_ready = false;//PLC开放异常
                    // 切断连接
                    melsec_net.ConnectClose();
                    MessageBox.Show("链接PLC"+ this.IPEndPoint.Address.ToString()+"异常--请检查下位机状态");
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
        ///   三菱 Mitsubishi /读取PLC
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
                    mutex.WaitOne(100);
                    // 读取bool变量 重写方法
                    if (Name != "Y")
                        readResultRender(melsec_net.ReadBoolFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);//读取自定地址变量状态
                    else
                    {
                        OperateResult<byte[]> read = melsec_net.ReadFromServerCore(this.Read_bit(三菱报文.message_bit.Y, Convert.ToInt32(id), 1));
                        readResultRender(read, Name.Trim() + id.Trim(), ref result);
                        if (read.IsSuccess)
                            result = this.Analysis(read.Content, Convert.ToInt32(id)) ? "TRUE" : "FALSE";
                    }
                    mutex.ReleaseMutex();//解锁
                }
                catch { }
            }
            return new List<bool>() { Convert.ToBoolean(result ?? "FALSE") };//返回数据
        }
        /// <summary>
        /// 宏指令 三菱 Mitsubishi /读取PLC
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        List<bool> macroinstruction_PLC_interface.PLC_read_M_bit(string Name, string id)
        {
            if (PLC_ready!=true) return new List<bool>() { false };//PLC-未准备好返回数据
            IPLC_interface pLC_Interface = this;//创建接口本类数据
            return pLC_Interface.PLC_read_M_bit(Name,id);//返回数据
        }
        /// <summary>
        ///  三菱 Mitsubishi  写入PLC
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
                    mutex.WaitOne(100);
                    // 写bool变量
                    if (Name != "Y")
                        writeResultRender(melsec_net.WriteIntoPLC(Name.Trim() + id.Trim(), Convert.ToBoolean(button_State.ToInt32())), Name.Trim() + id.Trim());//写入自定地址变量状态
                    else
                    {
                        //Q系列不需要转换-如果需要对接Q系列 需要把这个判断注释掉
                        OperateResult<byte[]> read = melsec_net.ReadFromServerCore(this.Write_bit(三菱报文.message_bit.Y, Convert.ToInt32(id), button_State==Button_state.ON?true:false));
                        readResultRender(read, Name.Trim() + id.Trim(), ref result);
                        result = read.IsSuccess ? "TRUE" : "FALSE";
                    }
                    mutex.ReleaseMutex();//解锁
                }
                catch { }
            }
            return new List<bool>() { Convert.ToBoolean(result ?? "FALSE") };//返回数据
        }
        /// <summary>
        /// 宏指令 三菱 Mitsubishi  写入PLC
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="on_off"></param>
        /// <returns></returns>
        List<bool> macroinstruction_PLC_interface.PLC_write_M_bit(string Name, string id, bool on_off)
        {
            if (PLC_ready != true) return new List<bool>() { Convert.ToBoolean("FALSE") };//PLC-未准备好返回数据
            IPLC_interface pLC_Interface = this;//创建接口本类数据
            return pLC_Interface.PLC_write_M_bit(Name,id, on_off? Button_state.ON: Button_state.Off);//返回数据
        }
        /// <summary>
        ///  三菱 Mitsubishi 读寄存器
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
                    mutex.WaitOne(100);
                    switch (format)
                    {
                        case numerical_format.Signed_16_Bit:
                        case numerical_format.BCD_16_Bit:
                            // 读取short变量
                            readResultRender(melsec_net.ReadShortFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Signed_32_Bit:
                        case numerical_format.BCD_32_Bit:
                            // 读取int变量
                            readResultRender(melsec_net.ReadIntFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Binary_16_Bit:
                            // 读取16位二进制数
                            String data_1 = Convert.ToString(result.ToInt32(), 2);
                            readResultRender(melsec_net.ReadShortFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Binary_32_Bit:
                            // 读取32位二进制数
                            String data_2 = Convert.ToString(result.ToInt32(), 2);
                            readResultRender(melsec_net.ReadIntFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Float_32_Bit:
                            // 读取float变量
                            readResultRender(melsec_net.ReadFloatFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Hex_16_Bit:
                            // 读取short变量
                            readResultRender(melsec_net.ReadShortFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            result = Convert.ToInt32(result).ToString("X");
                            break;
                        case numerical_format.Hex_32_Bit:
                            // 读取int变量
                            readResultRender(melsec_net.ReadIntFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            result = Convert.ToInt32(result).ToString("X");
                            break;
                        case numerical_format.Unsigned_16_Bit:
                            // 读取ushort变量
                            readResultRender(melsec_net.ReadUShortFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                        case numerical_format.Unsigned_32_Bit:
                            // 读取uint变量
                            readResultRender(melsec_net.ReadUIntFromPLC(Name.Trim() + id.Trim()), Name.Trim() + id.Trim(), ref result);
                            break;
                    }
                    mutex.ReleaseMutex();
                }
                catch { }
            }
            return result;//返回数据
        }
        /// <summary>
        /// 宏指令 三菱 Mitsubishi 读寄存器
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string macroinstruction_PLC_interface.PLC_read_D_register(string Name, string id, string format)
        {
            if (PLC_ready != true) return "0";//PLC-未准备好返回数据
            IPLC_interface pLC_Interface = this;//创建接口本类数据
            return pLC_Interface.PLC_read_D_register(Name, id, inquire_numerical(format));//返回数据
        }
        /// <summary>
        /// 三菱 Mitsubishi 写寄存器
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
                    mutex.WaitOne(100);
                    switch (format)
                    {
                        case numerical_format.Signed_16_Bit:
                        case numerical_format.BCD_16_Bit:
                            writeResultRender(melsec_net.WriteIntoPLC(Name.Trim() + id.Trim(), short.Parse(content)), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Signed_32_Bit:
                        case numerical_format.BCD_32_Bit:
                            writeResultRender(melsec_net.WriteIntoPLC(Name.Trim() + id.Trim(), int.Parse(content)), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Binary_16_Bit:
                            writeResultRender(melsec_net.WriteIntoPLC(Name.Trim() + id.Trim(), short.Parse(Convert.ToInt32(content, 2).ToString())), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Binary_32_Bit:
                            writeResultRender(melsec_net.WriteIntoPLC(Name.Trim() + id.Trim(), int.Parse(Convert.ToInt32(content, 2).ToString())), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Float_32_Bit:
                            writeResultRender(melsec_net.WriteIntoPLC(Name.Trim() + id.Trim(), float.Parse(content)), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Hex_16_Bit:
                            writeResultRender(melsec_net.WriteIntoPLC(Name.Trim() + id.Trim(), short.Parse(Convert.ToInt32(content, 16).ToString())), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Hex_32_Bit:
                            writeResultRender(melsec_net.WriteIntoPLC(Name.Trim() + id.Trim(), int.Parse(Convert.ToInt32(content, 16).ToString())), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Unsigned_16_Bit:
                            writeResultRender(melsec_net.WriteIntoPLC(Name.Trim() + id.Trim(), int.Parse(content)), Name.Trim() + id.Trim());
                            break;
                        case numerical_format.Unsigned_32_Bit:
                            writeResultRender(melsec_net.WriteIntoPLC(Name.Trim() + id.Trim(), int.Parse(content)), Name.Trim() + id.Trim());
                            break;
                    }
                    mutex.ReleaseMutex();
                }
                catch {  }
            }
            return result;//返回数据
        }
        /// <summary>
        /// 宏指令 三菱 Mitsubishi 写寄存器
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
            return pLC_Interface.PLC_write_D_register(Name, id,content, inquire_numerical(format));//返回数据
        }
        /// <summary>
        ///  三菱 Mitsubishi 批量读取寄存器
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
                    mutex.WaitOne(500);
                    Data = Mitsubishi_to_Index_numerical(Name, id.ToInt32(), format, Index.ToInt32(), this);//批量读取寄存器并且返回数据
                    mutex.ReleaseMutex();
                }
                catch { }
            }
            return Data;
        }
        /// <summary>
        /// 宏指令 三菱 Mitsubishi 批量读取寄存器
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        List<int> macroinstruction_PLC_interface.PLC_read_D_register_bit(string Name, string id, string format, string Index)//批量读取寄存器
        {
            if (PLC_ready != true) return new List<int>() { 0};//PLC-未准备好返回数据
            IPLC_interface pLC_Interface = this;//创建接口本类数据
            return pLC_Interface.PLC_read_D_register_bit(Name, id,  inquire_numerical(format),Index);//返回数据
        }
        /// <summary>
        /// 三菱 Mitsubishi  批量写入寄存器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> IPLC_interface.PLC_write_D_register_bit(string id)
        {
            return new List<int>() { 1 };
        }
        /// <summary>
        /// 宏指令 三菱 Mitsubishi  批量写入寄存器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> macroinstruction_PLC_interface.PLC_write_D_register_bit(string id)
        {
            return new List<int>() { 1 };
        }
        /// <summary>
        /// 定义消息以弹出不在弹窗
        /// </summary>
        static bool Message_run = false;
        static int retry;
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
               data=result.Content.ToString();//获取回传的数据
               retry = 0;
            }
            else
            {
                retry += 1;//重试次数
                if (retry < 3)
                {
                    melsec_net.ConnectClose();//切断链接
                    PLC_ready = melsec_net.ConnectServer().IsSuccess;//重新链接PLC
                    return;
                }
                PLCerr_content = DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 读取失败{Environment.NewLine}原因：{result.ToMessageShowString()}";
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 读取失败{Environment.NewLine}原因：{result.ToMessageShowString()}");
                if (retry >= 3)
                {
                    err(new Exception("链接PLC异常"));
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
            if (result.IsSuccess!=true)
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
        /// <summary>
        /// Err处理
        /// </summary>
        /// <param name="e"></param>
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
