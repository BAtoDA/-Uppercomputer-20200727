using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CSEngineTest
{
    /// <summary>
    /// 重写 套接字
    /// </summary>
    public class macroinstruction_Socket : Socket
    {
        /// <summary>
        /// 套接字链接 结果
        /// </summary>
        public bool socket_OK { get; set; }
        public macroinstruction_Socket(AddressFamily family, SocketType socket, ProtocolType protocol) : base(family, socket, protocol)
        {

        }
        /// <summary>
        /// 打开连接套接字
        /// </summary>
        /// <param name="iPEndPoint"></param>
        public bool Open(IPEndPoint iPEndPoint)//打开套接字
        {
            try
            {
                this.Connect(iPEndPoint);//连接
                socket_OK = true;
                return true;
            }
            catch { socket_OK = false; return false; }
        }
        public void send(byte[] Data)
        {
            try
            {
                this.Send(Data);//发送数据
                socket_OK = true;
            }
            catch { socket_OK = false; }
        }
        public void send(string Data)
        {
            try
            {
                this.SendFile(Data);//发送数据
                socket_OK = true;
            }
            catch { socket_OK = false; }
        }
        public byte[] reception(byte[] Data)
        {
            try
            {
                this.Receive(Data, Data.Length, 0);//接收数据
                socket_OK = true;
                return Data;
            }
            catch { socket_OK = false; return Data; }
        }
    }
}
