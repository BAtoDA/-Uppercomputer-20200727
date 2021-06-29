using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HTML布局学习.报警类序列化
{
    /// <summary>
    /// 报警类--用于提交表单返回前端处理
    /// </summary>
    [DataContract]
    public class Alarm
    {
        /// <summary>
        /// 报警页数
        /// </summary>
        public int AlarmPage;
        /// <summary>
        /// 报警发生时间
        /// </summary>
        public string AlarmTime;
        /// <summary>
        /// 报警ID号
        /// </summary>
        public string AlarmID;
        /// <summary>
        /// 报警内容
        /// </summary>
        public string AlarmContent;
        /// <summary>
        /// 是否处理
        /// </summary>
        public string AlarmManageTime;
    }
}