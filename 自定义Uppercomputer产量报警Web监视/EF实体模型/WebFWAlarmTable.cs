using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML布局学习.EF实体模型
{
    [Table("WebFWAlarmTable")]
    public class WebFWAlarmTable
    {
        public int ID { get; set; }
        public string 报警时间 { get; set; }
        public string 处理完成时间 { get; set; }
        public bool 类型 { get; set; }
        public string 设备 { get; set; }
        public string 设备地址 { get; set; }
        public string 设备_具体地址 { get; set; }
        public string 报警内容 { get; set; }
        public int 事件关联ID { get; set; }
    }
}
