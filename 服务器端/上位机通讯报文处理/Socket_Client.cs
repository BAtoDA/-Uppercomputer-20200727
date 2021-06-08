using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 服务器端.上位机通讯报文处理
{
    /// <summary>
    /// 用于处理访问上位机互交通讯
    /// </summary>
    public class Socket_Client:message
     {
        /// <summary>
        /// 实例化一个套接字
        /// </summary>
        Socket socket { get; set; } = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        /// <summary>
        /// 实例化一个IP地址与端口
        /// </summary>
        IPEndPoint IPEnd { get; set; } = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse("4999"));
        /// <summary>
        /// 指示着是否访问成功
        /// </summary>
        public bool Socket_ready { get; set; }
        /// <summary>
        /// 互斥锁 预防多线程进入导致 数据错乱
        /// </summary>
        static Mutex mutex { get; set; }
        public Socket_Client(IPEndPoint iPEnd)
        {
            this.IPEnd = iPEnd;
            mutex = new Mutex();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        /// <summary>
        /// 打开通讯链接
        /// </summary>
        /// <returns></returns>
        public Operating<bool> Open()
        {
            try
            {
                socket.SendTimeout = 2000;
                socket.ReceiveTimeout = 2000;
                socket.Connect(IPEnd);
                Socket_ready = true;
                return new Operating<bool>() { IsSuccess = true, ErrorCode = " ", Content = true };
            }
            catch(Exception e)
            {
                Socket_ready = false;
                return new Operating<bool>() { IsSuccess = false, ErrorCode = e.Message, Content = false };
            }
        }
        /// <summary>
        /// 切断通讯链接
        /// </summary>
        /// <returns></returns>
        public Operating<bool> Close()
        {
            try
            {
                socket.Close();
                Socket_ready = false;
                return new Operating<bool>() { Content = true, ErrorCode = "", IsSuccess = true };
            }
            catch(Exception e)
            {
                Socket_ready = false;
                return new Operating<bool>() { Content = false, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 读取Hmi上位机M区
        /// </summary>
        /// <param name="FormNmae">发送者窗口名称</param>
        /// <param name="address">要读取的地址</param>
        /// <param name="length">要读取的长度</param>
        /// <returns></returns>
        public Operating<bool[]> ReadHmi_Bool(string FormNmae, int address, int length)
        {
            try
            {
                socket.Send(this.ReadHmiBool(FormNmae, address, length));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadHmiBoolresult(Data);
            }
            catch(Exception e)
            {
                Err();
                return new Operating<bool[]>() { Content = new bool[] { false}, ErrorCode =e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 读取上位机D区的值
        /// 请注意T约束 Hex类型是string约束T int32 约束int  int16 约束Int16 Byte约束byte[]
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        public Operating<List<T>> ReadHmiD<T>(string FormNmae, int address, int length, HmiType hmiType)
        {
            try
            {
                socket.Send(this.ReadHmiD(FormNmae, address, length, hmiType));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadHmiDresult<T>(Data);
            }
            catch(Exception e)
            {
                Err();
                return new Operating<List<T>>() { Content =null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 写入上位机M区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="button_State">请需要写入的状态</param>
        /// <returns></returns>
        public Operating<string> WriteHmi_Bool(string FormNmae, int address, bool button_State)
        {
            try
            {
                socket.Send(WriteHmiBool(FormNmae, address, button_State));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.Writeresult(Data);
            }
            catch(Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode =e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 写入上位机D区 数据
        /// </summary>
        /// <param name="FormNmae">消息发生者窗口名称</param>
        /// <param name="address">>请输入起始地址</param>
        /// <param name="hmiType">写入类型</param>
        /// <param name="value">写入内容</param>
        /// <returns></returns>
        public Operating<string> WriteHmi_D(string FormNmae, int address, HmiType hmiType, string value)
        {
            try
            {
                socket.Send(WriteHmiD(FormNmae,address,hmiType,value));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.Writeresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 读取三菱PLC--
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="mitsubishi_Bit">要读取PLC的软元件</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        public Operating<bool[]> ReadPLCBool(string FormNmae, Mitsubishi_bit mitsubishi_Bit, string address , int length)
        {
            try
            {
                socket.Send(ReadPLCBool(FormNmae,Functional.Readmitsubishi_bool, mitsubishi_Bit,address,length));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCBoolresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<bool[]>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 读取西门子PLC--
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="Siemens_Bit">要读取PLC的软元件</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        public Operating<bool[]> ReadPLCBool(string FormNmae, Siemens_bit Siemens_Bit, string address, int length)
        {
            try
            {
                socket.Send(ReadPLCBool(FormNmae, Functional.Readsiemens_bool, Siemens_Bit, address, length));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCBoolresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<bool[]>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 读取Modbus TCP PLC--
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="Modbus_TCP_Bit">要读取PLC的软元件</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        public Operating<bool[]> ReadPLCBool(string FormNmae, Modbus_TCP_bit Modbus_TCP_Bit, string address, int length)
        {
            try
            {
                socket.Send(ReadPLCBool(FormNmae, Functional.ReadModbusTCP_bool, Modbus_TCP_Bit, address, length));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCBoolresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<bool[]>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 读取Modbus TCP PLC--
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="Modbus_TCP_Bit">要读取PLC的软元件</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        public Operating<bool[]> ReadPLCBool(string FormNmae, Omron_bit Omron_Bit, string address, int length)
        {
            try
            {
                socket.Send(ReadPLCBool(FormNmae, Functional.ReadOmronTCP_bool, Omron_Bit, address, length));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCBoolresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<bool[]>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 读取三菱PLC--D区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        ///  <param name="mitsubishi_D">要读取PLC的软元件</param>
        ///  <param name="numerical">要读取PLC的类型</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        public Operating<string> ReadPLCD(string FormNmae, Mitsubishi_D mitsubishi_D,numerical_format numerical, string address, int length)
        {
            try
            {
                socket.Send(ReadPLCD(FormNmae,Functional.Readmitsubishi_D,mitsubishi_D,numerical,address,length));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 读取西门子PLC--D区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        ///  <param name="Siemens_D">要读取PLC的软元件</param>
        ///  <param name="numerical">要读取PLC的类型</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        public Operating<string> ReadPLCD(string FormNmae, Siemens_D Siemens_D, numerical_format numerical, string address, int length)
        {
            try
            {
                socket.Send(ReadPLCD(FormNmae, Functional.Readsiemens_D, Siemens_D, numerical, address, length));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 读取Modbus_TCP PLC--D区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        ///  <param name="Modbus_TCP_D">要读取PLC的软元件</param>
        ///  <param name="numerical">要读取PLC的类型</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        public Operating<string> ReadPLCD(string FormNmae, Modbus_TCP_D Modbus_TCP_D, numerical_format numerical, string address, int length)
        {
            try
            {
                socket.Send(ReadPLCD(FormNmae, Functional.ReadModbusTCP_D, Modbus_TCP_D, numerical, address, length));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 读取Omron PLC--D区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        ///  <param name="Omron_D">要读取PLC的软元件</param>
        ///  <param name="numerical">要读取PLC的类型</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        public Operating<string> ReadPLCD(string FormNmae, Omron_D Omron_D, numerical_format numerical, string address, int length)
        {
            try
            {
                socket.Send(ReadPLCD(FormNmae, Functional.ReadOmronTCP_D, Omron_D, numerical, address, length));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 写入三菱PLC---M区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="mitsubishi">写入PLC的软元件</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="button_State">请需要写入的状态</param>
        /// <returns></returns>
        public Operating<string> WritePLCBool(string FormNmae, Mitsubishi_bit mitsubishi, string address, bool button_State)
        {
            try
            {
                socket.Send(WritePLCBool(FormNmae, Functional.Writemitsubishi_bool, mitsubishi , address,button_State));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 写入西门子PLC---M区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="mitsubishi">写入PLC的软元件</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="button_State">请需要写入的状态</param>
        /// <returns></returns>
        public Operating<string> WritePLCBool(string FormNmae, Siemens_bit mitsubishi, string address, bool button_State)
        {
            try
            {
                socket.Send(WritePLCBool(FormNmae, Functional.Writesiemens_bool, mitsubishi, address, button_State));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 写入Modbus tcp PLC---M区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="mitsubishi">写入PLC的软元件</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="button_State">请需要写入的状态</param>
        /// <returns></returns>
        public Operating<string> WritePLCBool(string FormNmae, Modbus_TCP_bit mitsubishi, string address, bool button_State)
        {
            try
            {
                socket.Send(WritePLCBool(FormNmae, Functional.WriteModbusTCP_bool, mitsubishi, address, button_State));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 写入欧姆龙 PLC---M区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="mitsubishi">写入PLC的软元件</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="button_State">请需要写入的状态</param>
        /// <returns></returns>
        public Operating<string> WritePLCBool(string FormNmae, Omron_bit mitsubishi, string address, bool button_State)
        {
            try
            {
                socket.Send(WritePLCBool(FormNmae, Functional.WriteOmronTCP_bool, mitsubishi, address, button_State));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 写入三菱PLC--D区 数据
        /// </summary>
        /// <param name="FormNmae">消息发生者窗口名称</param>
        /// <param name="mitsubishi">写入的PLC的软元件</param>
        /// <param name=" numerical">写入的PLC的类型</param>
        /// <param name="address">>请输入起始地址</param>
        /// <param name="value">写入内容</param>
        /// <returns></returns>
        public Operating<string> WritePLCD(string FormNmae, Mitsubishi_D mitsubishi, numerical_format numerical, string address , string value)
        {
            try
            {
                socket.Send(WritePLCD(FormNmae, Functional.Writemitsubishi_D, mitsubishi,numerical, address, value));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 写入西门子PLC--D区 数据
        /// </summary>
        /// <param name="FormNmae">消息发生者窗口名称</param>
        /// <param name="mitsubishi">写入的PLC的软元件</param>
        /// <param name=" numerical">写入的PLC的类型</param>
        /// <param name="address">>请输入起始地址</param>
        /// <param name="value">写入内容</param>
        /// <returns></returns>
        public Operating<string> WritePLCD(string FormNmae, Siemens_D mitsubishi, numerical_format numerical, string address, string value)
        {
            try
            {
                socket.Send(WritePLCD(FormNmae, Functional.Writesiemens_D, mitsubishi, numerical, address, value));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 写入Mosbu tcp PLC--D区 数据
        /// </summary>
        /// <param name="FormNmae">消息发生者窗口名称</param>
        /// <param name="mitsubishi">写入的PLC的软元件</param>
        /// <param name=" numerical">写入的PLC的类型</param>
        /// <param name="address">>请输入起始地址</param>
        /// <param name="value">写入内容</param>
        /// <returns></returns>
        public Operating<string> WritePLCD(string FormNmae, Modbus_TCP_D mitsubishi, numerical_format numerical, string address, string value)
        {
            try
            {
                socket.Send(WritePLCD(FormNmae, Functional.WriteModbusTCP_D, mitsubishi, numerical, address, value));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// 写入欧姆龙 PLC--D区 数据
        /// </summary>
        /// <param name="FormNmae">消息发生者窗口名称</param>
        /// <param name="mitsubishi">写入的PLC的软元件</param>
        /// <param name=" numerical">写入的PLC的类型</param>
        /// <param name="address">>请输入起始地址</param>
        /// <param name="value">写入内容</param>
        /// <returns></returns>
        public Operating<string> WritePLCD(string FormNmae, Omron_D mitsubishi, numerical_format numerical, string address, string value)
        {
            try
            {
                socket.Send(WritePLCD(FormNmae, Functional.WriteOmronTCP_D, mitsubishi, numerical, address, value));
                byte[] Data = new byte[1024];
                socket.Receive(Data);
                return this.ReadPLCDresult(Data);
            }
            catch (Exception e)
            {
                Err();
                return new Operating<string>() { Content = null, ErrorCode = e.Message, IsSuccess = false };
            }
        }
        /// <summary>
        /// Err处理
        /// </summary>
        private void Err()
        {
            Socket_ready = false;
            socket.Close();
        }
    }
}
