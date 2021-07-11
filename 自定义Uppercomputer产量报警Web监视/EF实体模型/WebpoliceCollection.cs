using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML布局学习.EF实体模型
{
    [Table("WebpoliceCollection")]
    public class WebpoliceCollection
    {
        public int ID { get; set; }
        public int 今日报警次数 { get; set; }
        public int week报警次数 { get; set; }
        public int 本月报警次数 { get; set; }
        public string 今日处理用时 { get; set; }
        public string week处理用时 { get; set; }
        public string 本月处理用时 { get; set; }
        public string 采集软件在线时间 { get; set; }
    }
}
