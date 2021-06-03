using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Profinet.Omron;
using PLC通讯规范接口;
using 欧姆龙Fins协议.报文处理;

namespace 欧姆龙Fins协议.欧姆龙.报文处理
{
    /// <summary>
    /// 用于欧姆龙Fins Tcp协议
    /// </summary>
    public class OmronFinsCIP : PLC_public_Class, IPLC_interface
    {
        /// <summary>
        /// 创建发送报文事件
        /// </summary>
        public event EventHandler Send;
        /// <summary>
        /// 创建读取发送报文事件
        /// </summary>
        public event EventHandler Reception;
        /// <summary>
        /// IP地址
        /// </summary>
        public static IPEndPoint IPEndPoint { get; set; }//IP地址
        string pattern;
        static private bool PLC_ready;//内部PLC状态
        static private int PLCerr_code;//内部报警代码
        static private string PLCerr_content;//内部报警内容
        static bool PLC_Reconnection;//重连标志位
        static string PLC_type="TCP";//链接类型
        /// <summary>
        /// 引用HslCommunication.ModBus进行实现
        /// </summary>
        public static OmronCipNet busTcpClient = null;//引用HslCommunication.ModBus进行实现
                                                       //实现接口的属性
        /// <summary>
        /// 实现接口的属性 PLC状态
        /// </summary>
        public static bool IPLC_interface_PLC_ready { get => PLC_ready; } //PLC状态
        /// <summary>
        /// PLC报警代码
        /// </summary>
        public static int IPLC_interface_PLCerr_code { get => PLCerr_code; }//PLC报警代码
        /// <summary>
        /// PLC报警内容
        /// </summary>
        public static string IPLC_interface_PLCerr_content { get => PLCerr_content; }//PLC报警内容
        bool IPLC_interface.PLC_Reconnection { get { return PLC_Reconnection; } set { PLC_Reconnection = value; } }

        bool IPLC_interface.PLC_ready { get => PLC_ready; }

        int IPLC_interface.PLCerr_code { get => PLCerr_code; }

        string IPLC_interface.PLCerr_content { get => PLCerr_content; }
        string IPLC_interface.PLC_type { get { return PLC_type; } set { PLC_type = value; } }

        /// <summary>
        /// /互斥锁(Mutex)，用于多线程中防止两条线程同时对一个公共资源进行读写的机制。
        /// </summary>
        //互斥锁(Mutex)，用于多线程中防止两条线程同时对一个公共资源进行读写的机制。
        static Mutex mutex;//定义互斥锁名称
        /// <summary>
        /// 构造函数---初始化---open
        /// </summary>
        /// <param name="iPEndPoint"></param>
        /// <param name="pattern"></param>
        public OmronFinsCIP(IPEndPoint iPEndPoint, string pattern)//构造函数---初始化---open
        {
            OmronFinsCIP.IPEndPoint = iPEndPoint;//实例化IP地址
            this.pattern = pattern;
            PLC_busy = false;
            mutex = new Mutex();//实例化互斥锁(Mutex)
        }
        /// <summary>
        /// 构造函数---多态
        /// </summary>
        public OmronFinsCIP()//构造函数---多态
        {

        }

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <returns></returns>
        public string PLC_open()//打开端口
        {
            try
            {
                busTcpClient = new OmronCipNet(IPEndPoint.Address.ToString());//传入IP与端口
                busTcpClient.ConnectTimeOut = 500;//X超时时间
                busTcpClient.ReceiveTimeOut = 500;//超时时间
                busTcpClient.ConnectClose();//切断链接                            
                OperateResult connect = busTcpClient.ConnectServer();//是否打开成功？
                retry = 0;
                if (connect.IsSuccess)
                {
                    PLC_ready = true;//PLC开放正常
                    PLC_busy = false;//允许访问
                    return "链接PLC正常";//已连接到服务器        
                }
                else
                {
                    PLC_ready = false;//PLC开放异常
                    PLC_busy = false;//允许访问
                    busTcpClient.ConnectClose();//切断链接
                    //推出异常
                    MessageBox.Show("连接MODBUS_TCP  " + IPEndPoint.Address.ToString() + "失败--请检查下位机设备状态");
                    return "链接PLC异常";//尝试连接PLC，如果连接成功则返回值为0                   
                }
            }
            catch (Exception Err)
            {
                err(Err);//异常处理
                return "链接PLC异常";//尝试连接PLC，如果连接成功则返回值为0
            }
        }
        public void PLC_Close()//切断PLC链接
        {
            err(new Exception("切断PLC链接"));
        }
        public void PLCreconnection()//重连PLC
        {
            try
            {
                busTcpClient = new OmronCipNet(IPEndPoint.Address.ToString());//传入IP与端口
                busTcpClient.ConnectTimeOut = 500;//X超时时间
                busTcpClient.ReceiveTimeOut = 500;//超时时间
                busTcpClient.ConnectClose();//切断链接                            
                OperateResult connect = busTcpClient.ConnectServer();//是否打开成功？
                if (connect.IsSuccess)
                {
                    retry = retry > 3 ? 0 : retry;
                    PLC_ready = true;//PLC开放正常
                    PLC_busy = false;//允许访问
                    return ;//已连接到服务器        
                }
                else
                {
                    PLC_ready = false;//PLC开放异常
                    PLC_busy = false;//允许访问
                    busTcpClient.ConnectClose();//切断链接
                    return ;//尝试连接PLC，如果连接成功则返回值为0                   
                }
            }
            catch (Exception Err)
            {
                err(Err);//异常处理
                return ;//尝试连接PLC，如果连接成功则返回值为0
            }
        }
        /// <summary>
        /// 读取PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<bool> PLC_read_M_bit(string Name, string id)//读取PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        {
            string result = "FALSE";//定义获取数据变量
            lock (this)
            {
                try
                {
                    mutex.WaitOne(100);
                    readResultRender(busTcpClient.ReadBool(Name + id, 1), Name + id.ToString(), ref result);//格式--读取地址-地址，返回数据--地址决定了是Nmae的类型            
                    mutex.ReleaseMutex();
                }
                catch { }
            }
            return new List<bool>() { Convert.ToBoolean(result ?? "FALSE") };//返回数据
        }
        /// <summary>
        /// 读取PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperateResult<bool[]> PLC_read_M_bit(string Name, string id, ushort Length)//读取PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        {
            OperateResult<bool[]> result = new OperateResult<bool[]>();//定义获取数据变量
            lock (this)
            {
                try
                {
                    mutex.WaitOne(100);
                    result = busTcpClient.ReadBool(Name + id, Length);//格式--读取地址-地址，返回数据--地址决定了是Nmae的类型            
                    mutex.ReleaseMutex();
                    return result;
                }
                catch { }
            }
            return result;//返回数据
        }
        /// <summary>
        /// 写入PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="button_State"></param>
        /// <returns></returns>
        public List<bool> PLC_write_M_bit(string Name, string id, Button_state button_State)//写入PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        {
            string result = "FALSE";//定义获取数据变量
            lock (this)
            {
                try
                {
                    mutex.WaitOne(100);
                    writeResultRender(busTcpClient.Write(Name + id, Convert.ToBoolean((int)button_State)), Name + id + Convert.ToBoolean((int)button_State));
                    result = "1";//写入1   
                    mutex.ReleaseMutex();
                }
                catch { }
            }
            return new List<bool>() { Convert.ToBoolean(Convert.ToInt32(result)) };//返回数据
        }
        /// <summary>
        /// 写入PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="button_State"></param>
        /// <returns></returns>
        public List<bool> PLC_write_M_bit(string Name, string id, bool[] button_State)//写入PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        {
            string result = "FALSE";//定义获取数据变量
            lock (this)
            {
                try
                {
                    mutex.WaitOne(100);
                    writeResultRender(busTcpClient.Write(Name + id, button_State), Name + id);
                    result = "1";//写入1   
                    mutex.ReleaseMutex();
                }
                catch { }
            }
            return new List<bool>() { Convert.ToBoolean(Convert.ToInt32(result)) };//返回数据
        }
        /// <summary>
        /// 读寄存器--转换相应类型
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public string PLC_read_D_register(string Name, string id, numerical_format format)//读寄存器--转换相应类型
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
                            readResultRender(busTcpClient.ReadInt16(Name + id, 1), Name + id, ref result);
                            break;
                        case numerical_format.Signed_32_Bit:
                        case numerical_format.BCD_32_Bit:
                            // 读取int变量
                            readResultRender(busTcpClient.ReadInt32(Name + id, 1), Name + id, ref result);
                            break;
                        case numerical_format.Binary_16_Bit:
                            // 读取16位二进制数
                            readResultRender(busTcpClient.ReadInt16(Name + id, 1), Name + id, ref result);
                            result = Convert.ToString(Convert.ToInt32(result), 2);
                            break;
                        case numerical_format.Binary_32_Bit:
                            // 读取32位二进制数
                            readResultRender(busTcpClient.ReadInt32(Name + id, 1), Name + id, ref result);
                            result = Convert.ToString(Convert.ToInt32(result), 2);
                            break;
                        case numerical_format.Float_32_Bit:
                            // 读取float变量
                            readResultRender(busTcpClient.ReadFloat(Name + id, 1), Name + id, ref result);
                            break;
                        case numerical_format.Hex_16_Bit:
                            // 读取short变量
                            readResultRender(busTcpClient.ReadInt16(Name + id, 1), Name + id, ref result);
                            result = Convert.ToInt32(result).ToString("X");
                            break;
                        case numerical_format.Hex_32_Bit:
                            // 读取int变量
                            readResultRender(busTcpClient.ReadInt32(Name + id, 1), Name + id, ref result);
                            result = Convert.ToInt32(result).ToString("X");
                            break;
                        case numerical_format.Unsigned_16_Bit:
                            // 读取ushort变量
                            readResultRender(busTcpClient.ReadUInt16(Name + id, 1), Name + id, ref result);
                            break;
                        case numerical_format.Unsigned_32_Bit:
                            // 读取uint变量
                            readResultRender(busTcpClient.ReadUInt32(Name + id, 1), Name + id, ref result);
                            break;
                    }
                    mutex.ReleaseMutex();
                }
                catch { }
            }
            return result;//返回数据
        }
        /// <summary>
        /// 写寄存器--转换类型--并且写入
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public string PLC_write_D_register(string Name, string id, string content, numerical_format format)//写寄存器--转换类型--并且写入
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
                            writeResultRender(busTcpClient.Write(Name + id, Convert.ToInt16(content)), Name + id + content);
                            break;
                        case numerical_format.Signed_32_Bit:
                        case numerical_format.BCD_32_Bit:
                            writeResultRender(busTcpClient.Write(Name + id, Convert.ToInt32(content)), Name + id + content);
                            break;
                        case numerical_format.Binary_16_Bit:
                            writeResultRender(busTcpClient.Write(Name + id, Convert.ToInt16(Convert.ToInt32(content, 2))), Name + id + content);
                            break;
                        case numerical_format.Binary_32_Bit:
                            writeResultRender(busTcpClient.Write(Name + id, Convert.ToInt32(content, 2)), Name + id + content);
                            break;
                        case numerical_format.Float_32_Bit:
                            writeResultRender(busTcpClient.Write(Name + id, Convert.ToSingle(content)), Name + id + content);
                            break;
                        case numerical_format.Hex_16_Bit:
                            writeResultRender(busTcpClient.Write(Name + id, Convert.ToInt16(Convert.ToInt32(content, 16))), Name + id + content);
                            break;
                        case numerical_format.Hex_32_Bit:
                            writeResultRender(busTcpClient.Write(Name + id, Convert.ToInt32(content, 16)), Name + id + content);
                            break;
                        case numerical_format.Unsigned_16_Bit:
                            writeResultRender(busTcpClient.Write(Name + id, Convert.ToUInt16(content)), Name + id + content);
                            break;
                        case numerical_format.Unsigned_32_Bit:
                            writeResultRender(busTcpClient.Write(Name + id, Convert.ToUInt32(content)), Name + id + content);
                            break;
                    }
                    mutex.ReleaseMutex();
                }
                catch{ }
            }
            return result;//返回数据
        }
        /// <summary>
        /// 批量读寄存器--转换类型-
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        public List<int> PLC_read_D_register_bit(string Name, string id, numerical_format format, string Index)//批量读取寄存器
        {
            List<int> Data = new List<int>();
            lock (this)
            {
                try
                {
                    mutex.WaitOne(100);
                    Data = Mitsubishi_to_Index_numerical(Name, Convert.ToInt32(id), format, Convert.ToInt32(Index), this);//批量读取寄存器并且返回数据
                    mutex.ReleaseMutex();
                }
                catch { }
            }
            return Data;//批量读取寄存器并且返回数据
        }

        /// <summary>
        /// 定义消息以弹出不在弹窗
        /// </summary>
        static bool Message_run = false;
        static int retry;
        #region 读写状态统一返回
        /// <summary>
        /// 统一的读取结果的数据解析，显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="address"></param>
        /// <param name="Data"></param>
        public void readResultRender<T>(OperateResult<T> result, string address, ref string Data)
        {
            ///读取结果
            if (Send != null)
            {
                string res = result.IsSuccess ? "成功" : "失败";
                Send.Invoke($"读取:{address}{res}:返回数据为：{Data}", new EventArgs());
            }

            if (result.IsSuccess != true)//指示读取失败
            {
                retry += 1;//重试次数
                PLCerr_content = DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 读取失败{Environment.NewLine}原因：{result.ToMessageShowString()}";
                if (retry == 1)
                    MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 读取失败{Environment.NewLine}原因：{result.ToMessageShowString()}");
                if (retry >= 1)
                    err(new Exception("链接PLC异常"));
            }
            else
            {
                //使用动态编程--DLR运行时确定T类型
                dynamic Resut = result.Content;
                Data= Resut[0].ToString();

                //switch (typeof(T).Name.ToString())
                //{
                //    case "Boolean[]":
                //        foreach (var i in (bool[])((object)result.Content))
                //        {
                //            Data = i.ToString();
                //        }
                //        break;
                //    case "Int16[]":
                //        foreach (var i in (short[])((object)result.Content))
                //        {
                //            Data = i.ToString();
                //        }
                //        break;
                //    case "Int32[]":
                //        foreach (var i in (int[])((object)result.Content))
                //        {
                //            Data = i.ToString();
                //        }
                //        break;
                //    case "Single[]":
                //        foreach (var i in (float[])((object)result.Content))
                //        {
                //            Data = i.ToString();
                //        }
                //        break;

                //}
                retry = 0;
            }
            Thread.Sleep(2);
            PLC_busy = false;//允许访问

        }
        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="address"></param>
        public void writeResultRender(OperateResult result, string address)
        {
            ///发送结果
            if (this.Reception != null)
            {
                string res = result.IsSuccess ? "成功" : "失败";
                Reception.Invoke($"写入:{address}{res};", new EventArgs());
            }
            if (result.IsSuccess != true)//指示写入失败
            {
                PLC_ready = false;//读取异常
                PLCerr_content = DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 写入失败{Environment.NewLine}原因：{result.ToMessageShowString()}";
            }
            Thread.Sleep(5);
            PLC_busy = false;//允许访问
        }
        #endregion
        /// <summary>
        /// Err处理
        /// </summary>
        /// <param name="e"></param>
        public static void err(Exception e)
        {
            PLC_ready = false;//PLC开放异常
            PLCerr_code = e.HResult;
            PLCerr_content = e.Message;
            Message_run = true;
        }

        public List<int> PLC_write_D_register_bit(string id)
        {
            throw new NotImplementedException();
        }
    }
}
