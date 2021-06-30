using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HTML布局学习.报警类序列化
{
    /// <summary>
    /// 用于报警历史
    /// </summary>
    [DataContract]
    public class Alarmhistory
    {
        public int ID { get; set; }
        public string 报警时间  { get; set; }
        public string 处理完成时间 { get; set; }
        public bool 类型 { get; set; }
        public string 设备 { get; set; }
        public string 设备_地址 { get; set; }
        public string 设备_具体地址 { get; set; }
        public string 报警内容 { get; set; }
        public int 事件关联ID { get; set; }
    }
}