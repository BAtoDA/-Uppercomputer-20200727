using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HTML布局学习.后端实现类;
using 自定义Uppercomputer产量报警Web监视.EF实体模型;

namespace HTML布局学习.手机访问页面
{
    public partial class 手机报警页面1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Alarmpage alarmpage = new Alarmpage();
        }
        static object lex = new object();
        [WebMethod]
        public static string Alarmnumber()
        {
            lock (lex)
            {
                return Alarmpage.Alarmnumber();
            }
        }
        static object lq = new object();
        /// <summary>
        /// 上传报警用时与报警次数
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string MonthDisposeData()
        {
            lock (lq)
            {
                return new JavaScriptSerializer().Serialize(Alarmpage.webpoliceCollection != null ? Alarmpage.webpoliceCollection : new EF实体模型.WebpoliceCollection() { ID = 0, week处理用时 = "00:00:00", week报警次数 = 0, 今日处理用时 = "00:00:00", 今日报警次数 = 0, 本月处理用时 = "00:00:00", 本月报警次数 = 0, 采集软件在线时间 = "0" });
            }

        }
        static object dispose = new object();
        /// <summary>
        /// 上传报警处理用时与月度报警处理用时
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string AlarDisposemnumber()
        {
            lock (dispose)
            {
                return new JavaScriptSerializer().Serialize(Alarmpage.AlarmDispose());
            }
        }
        static object lT = new object();
        /// <summary>
        /// 用于处理上传设备速率
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Weboutput()
        {
            lock (lT)
            {
                using (UppercomputerEntities2 db = new UppercomputerEntities2())
                {
                    var webout = db.WeboutputCollections.FirstOrDefault();
                    return new JavaScriptSerializer().Serialize(webout != null ? webout : new EF实体模型.WeboutputCollection() { ID = 0, 停机次数 = 0, 全年产量 = 0, 当月产量 = 0, 当班产量 = 0, 设备状态 = false, 设备速率 = 0, 采集软件在线时间 = "0", 采集软件状态 = false });
                }
            }
        }
    }
}