using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HTML布局学习.小时产量类序列化
{ 
    /// <summary>
   /// 报警类--用于提交表单返回前端处理
   /// </summary>
    [DataContract]
    public class HourClass
    {
        /// <summary>
        /// 小时产量时间名称
        /// </summary>
        public string HourName;
        /// <summary>
        /// 小时产量数据
        /// </summary>
        public string HourData;
    }
}