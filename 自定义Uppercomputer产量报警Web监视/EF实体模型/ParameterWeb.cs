using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HTML布局学习.EF实体模型
{
    /// <summary>
    /// 参数设置表
    /// </summary>
    [Table("ParameterWeb")]
    public class ParameterWeb
    {
        public int ID { get; set; }
        public Int64 当班目标 { get; set; }
        public Int64 当月目标 { get; set; }
        public Int64 全年产量目标 { get; set; }
        public string 设备 { get; set; }
        public string 产量地址 { get; set; }
        public string 产量具体地址 { get; set; }
        public string 设备速率地址 { get; set; }
        public string 设备速率具体地址 { get; set; }
        public string 自动运行地址 { get; set; }
        public string 自动运行具体地址 { get; set; }
        public string 物料编码 { get; set; }
        public string 编码具体地址 { get; set; }
    }
}