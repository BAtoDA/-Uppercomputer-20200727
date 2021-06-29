using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HTML布局学习.报警类序列化
{
    /// <summary>
    /// 报警注册类--用于提交表单返回前端处理
    /// </summary>
    [DataContract]
    public class AlarmSQL
    {
        public int ID { get; set; }
        public int 类型 { get; set; }
        public string 设备 { get; set; }
        public string 设备_地址 { get; set; }
        public string 设备_具体地址 { get; set; }
        public string 位触发条件 { get; set; }
        public string 字触发条件 { get; set; }
        public string 字触发条件_具体 { get; set; }
        public string 报警内容 { get; set; }
    }
}