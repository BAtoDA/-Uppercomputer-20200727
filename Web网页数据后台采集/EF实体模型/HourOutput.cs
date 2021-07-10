using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web网页数据后台采集.EF实体模型
{
    /// <summary>
    /// 小时产量表
    /// </summary>
    [Table("HourOutput")]
    public class HourOutput
    {
        public int ID { get; set; }
        public string 生产时间 { get; set; }
        public int 生产数量 { get; set; }
        public bool 班次 { get; set; }
    }
}