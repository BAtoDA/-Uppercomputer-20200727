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

namespace HTML布局学习.报警页面web
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Alarmpage alarmpage = new Alarmpage();
        }
        static object lex = new object();
        [WebMethod]
        public static string Alarmnumber()
        {
            lock(lex)
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
            lock (lex)
            {
                return new JavaScriptSerializer().Serialize(Alarmpage.webpoliceCollection !=null ? Alarmpage.webpoliceCollection : new EF实体模型.WebpoliceCollection() { ID = 0, week处理用时 = "00:00:00", week报警次数 = 0, 今日处理用时 = "00:00:00", 今日报警次数 = 0, 本月处理用时 = "00:00:00", 本月报警次数 = 0, 采集软件在线时间 = "0" });
            }

        }
    }
    [Serializable]
    class eventtolist
    { 
        public int id { get; set; }
        public IGrouping<int,Event_message> _Messages { get; set; }
    }

}