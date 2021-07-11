using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML布局学习.EF实体模型
{
    [Table("WeboutputCollection")]
    public class WeboutputCollection
    {
        public int ID { get; set; }
        public bool 设备状态 { get; set; }
        public int 停机次数  { get; set; }
        public int 设备速率 { get; set; }
        public int 当班产量 { get; set; }
        public int 当月产量 { get; set; }
        public int 全年产量 { get; set; }
        public bool 采集软件状态 { get; set; }
        public string 采集软件在线时间 { get; set; }
    }
}
