﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web网页数据后台采集.PLC通讯部分;
using System.Net;
using System.Net.Sockets;

namespace Web网页数据后台采集
{
    public class Program
    {
        static void Main(string[] args)
        {

               Console.WriteLine(PLCChatRoom.GetSocketIP()[0]+9500);
                PLCChatRoom pLCChatRoom = new PLCChatRoom(new System.Net.IPEndPoint(IPAddress.Parse(PLCChatRoom.GetSocketIP()[0]), 9500));
                pLCChatRoom.Readmessage += ((send1, e1) =>
                  {
                      Console.WriteLine($"读取设备：{send1.ToString().Trim()}");
                  });
                pLCChatRoom.Writemessage += ((send2, e2) =>
                  {
                      Console.WriteLine($"写入设备：{send2.ToString().Trim()}");
                  });
                var Open = pLCChatRoom.Open();
                Console.WriteLine($"链接设备：{Open.IsSuccess}");
            while (true)
            {
                pLCChatRoom.GetPLCoutput();
                pLCChatRoom.OutputWeb();
                pLCChatRoom.AlarmWeb();
            }
        }
    }
}
