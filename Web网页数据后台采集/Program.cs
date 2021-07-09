using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web网页数据后台采集.PLC通讯部分;
using System.Net;
using System.Net.Sockets;

namespace Web网页数据后台采集
{
    class Program
    {
        static void Main(string[] args)
        {
            PLCChatRoom pLCChatRoom = new PLCChatRoom(new System.Net.IPEndPoint(IPAddress.Parse(PLCChatRoom.GetSocketIP()[0]), 9500));
            pLCChatRoom.Readmessage += ((send1,e1) =>
              {
                  Console.WriteLine($"读取设备：{send1}");
              });
            pLCChatRoom.Writemessage += ((send2, e2) =>
              {
                  Console.WriteLine($"写入设备：{send2}");
              });
            var Open= pLCChatRoom.Open();
            Console.WriteLine($"链接设备：{Open.IsSuccess}");
            pLCChatRoom.GetPLCoutput();
        }
    }
}
