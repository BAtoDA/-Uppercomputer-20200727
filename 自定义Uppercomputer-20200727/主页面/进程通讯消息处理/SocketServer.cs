using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Nancy.Json;
using static PLC通讯规范接口.Request;

namespace 自定义Uppercomputer_20200727.主页面.进程通讯消息处理
{
    /// <summary>
    /// 主要用于Socket服务器实现用于 其他socket发送的数据
    /// </summary>
    class SocketServer
    {
        /// <summary>
        /// 传入的IP地址与端口
        /// </summary>
        IPEndPoint IPEnd;
        /// <summary>
        /// 接收客户端发生消息缓冲区
        /// </summary>
        byte[] reception = new byte[1000];//接收字节
        /// <summary>
        /// Socket服务器对象
        /// </summary>
        Socket socketload;

        IList<ArraySegment<Byte>> Data = new List<ArraySegment<Byte>>() { new ArraySegment<byte>(new byte[10]) };
        public SocketServer(IPEndPoint iPEnd)
        {
            this.IPEnd = iPEnd;
            this.IPEnd.Address = IPAddress.Parse("127.0.0.1");
            this.IPEnd.Port = 9500;
        }
        /// <summary>
        /// 获得本机真实物理网卡IP
        /// </summary>
        /// <returns></returns>
        public  IList<string> GetPhysicsNetworkCardIP()
        {
            var networkCardIPs = new List<string>();

            NetworkInterface[] fNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in fNetworkInterfaces)
            {
                string fRegistryKey = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + adapter.Id + "\\Connection";
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
                if (rk != null)
                {
                    // 区分 PnpInstanceID  
                    // 如果前面有 PCI 就是本机的真实网卡 
                    string fPnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
                    int fMediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", 0));
                    if (fPnpInstanceID.Length > 3 && fPnpInstanceID.Substring(0, 3) == "PCI")
                    {
                        IPInterfaceProperties fIPInterfaceProperties = adapter.GetIPProperties();
                        UnicastIPAddressInformationCollection UnicastIPAddressInformationCollection = fIPInterfaceProperties.UnicastAddresses;
                        foreach (UnicastIPAddressInformation UnicastIPAddressInformation in UnicastIPAddressInformationCollection)
                        {
                            if (UnicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                networkCardIPs.Add(UnicastIPAddressInformation.Address.ToString()); //Ip 地址
                            }
                        }
                    }
                }
            }

            return networkCardIPs;
        }
        /// <summary>
        /// Socket套接字加载开放
        /// </summary>
        public void SocketLoad()
        {
            //创建Socket服务器
            socketload = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketload.Bind(this.IPEnd);
            //监听客户端
            socketload.Listen(10);
            socketload.BeginAccept(new AsyncCallback(Socketcall_back), socketload);
        }
        /// <summary>
        /// 回调获取Socket客户端对象
        /// </summary>
        /// <param name="async"></param>
        private void Socketcall_back(IAsyncResult async)
        {
            //强制对象
            Socket socket = (Socket)async.AsyncState;
            try
            {
                if (socketload == null)
                    return;
                //获取Socket客户端对象
                Socket Socketclient = socket.EndAccept(async);
                if (SocketHeartbeat(Socketclient))
                {
                    Socketclient.BeginReceive(reception, 0, reception.Length, SocketFlags.None, new AsyncCallback(SocketRend), Socketclient);//异步接收数据
                }
            }
            catch
            {
                if (socketload == null)
                    return;
                //继续回调监听客户端
                socket.BeginAccept(new AsyncCallback(Socketcall_back), socket);
            }
        }
        /// <summary>
        /// 向客户端发生数据
        /// </summary>
        /// <param name="Data">需要发生的数据</param>
        /// <param name="inedx">Socket客户端索引</param>
        public void SocketSend(string Data, int inedx)
        {

        }
        /// <summary>
        /// 消息发送状态监控 
        /// </summary>
        /// <param name="async"></param>
        private void SocketSendcall_back(IAsyncResult async)
        {
            RichTextcontrol(async.AsyncState.ToString() + "\r\n");
        }
        /// <summary>
        /// 监听客户端发生的消息
        /// </summary>
        /// <param name="async"></param>
        public void SocketRend(IAsyncResult async)
        {
            Socket socket = async.AsyncState as Socket;
            try
            {
                int d = socket.IOControl(IOControlCode.DataToRead, null, new byte[100]);
                if (!SocketHeartbeat(socket)) return;
                //获取接收字节长度
                int index = socket.EndReceive(async);
                string Data = Encoding.UTF8.GetString(reception, 0, index);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var da= jss.Deserialize<COPYDATASTRUCT>(Data);
                Messagehandling messagehandling = new Messagehandling();
                var jsondata= Encoding.UTF8.GetBytes(jss.Serialize(messagehandling.Manage(da)));
                socket.BeginSend(jsondata, 0, jsondata.Length, SocketFlags.None, new AsyncCallback(SocketSendcall_back), $"向IP:发送：" + Data + "成功 \r\n");
                socket.BeginReceive(reception, 0, reception.Length, SocketFlags.None, new AsyncCallback(SocketRend), socket);//异步接收数据
            }
            catch (Exception e)
            {
                Messagehandling messagehandling = new Messagehandling();
                var da= messagehandling.Replymessage(new COPYDATASTRUCT() { lpData = e.Message, Address = " ", cbData = 0, characteristic = " ", Equipmenttype = " ", function = 0, length = "10", Type = " " }, e.Message, false);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var jsondata = Encoding.UTF8.GetBytes(jss.Serialize(da));
                socket.BeginSend(jsondata, 0, jsondata.Length, SocketFlags.None, new AsyncCallback(SocketSendcall_back), $"向IP:发送：" + Data + "成功 \r\n");
                socket.BeginReceive(reception, 0, reception.Length, SocketFlags.None, new AsyncCallback(SocketRend), socket);//异步接收数据
            }
        }
        /// <summary>
        /// 显示文本内容
        /// </summary>
        /// <param name="Value">显示值</param>
        private void RichTextcontrol(string Value)
        {

        }
        /// <summary>
        /// 判断检测客户端是否在线
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        private bool SocketHeartbeat(Socket socket)
        {
            if (socketload != null)
            {
                if (socket.Connected != false && !socket.Poll(1000, SelectMode.SelectRead))
                {
                    return true;
                }
            }
            //显示自定IP掉线
            RichTextcontrol($"IP:{socket.RemoteEndPoint} 已切断链接 \r\n");
            return false;
        }
        /// <summary>
        /// Socket服务器释放
        /// </summary>
        public void SocketClose()
        {
            if (socketload != null)
            {
                socketload.Close();//释放对象
                socketload = null;
            }
        }
    }
}
