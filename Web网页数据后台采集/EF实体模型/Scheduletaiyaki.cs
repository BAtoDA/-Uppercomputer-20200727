using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web网页数据后台采集.EF实体模型
{
    /// <summary>
    /// 当天产量与当天报警次数表
    /// </summary>
    [Table("Scheduletaiyaki")]
    public class Scheduletaiyaki
    {
        public int ID { get; set; }
        public string 生产时间 { get; set; }
        public int 当天产量 { get; set; }
        public int 当天目标 { get; set; }
        public int 异常次数 { get; set; }
        public string 异常时长 { get; set; }
        public Int64 物料编码 { get; set; }
    }
}