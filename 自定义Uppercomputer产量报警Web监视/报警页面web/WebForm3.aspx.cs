using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HTML布局学习.EF实体模型;
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
        /// <summary>
        /// 7天 本月报警次数锁
        /// </summary>
        static object la = new object();
        /// <summary>
        /// 上传报警次数与报警时长表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Alarmcomplete()
        {
            lock (la)
            {
                return Alarmpage.Alarmcompletee();
            }
        }
        /// <summary>
        /// 7天 本月报警次数锁
        /// </summary>
        static object lex = new object();
        /// <summary>
        /// 上次7天 与本月报警次数
        /// </summary>
        /// <returns></returns>
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
            lock (lq)
            {
                var data = Alarmpage.Gatherrun;
                if(Alarmpage.Gatherrun==false)
                {
                    return new JavaScriptSerializer().Serialize(new EF实体模型.WebpoliceCollection() { ID = 0, week处理用时 = "00:00:00", week报警次数 = 0, 今日处理用时 = "00:00:00", 今日报警次数 = 0, 本月处理用时 = "00:00:00", 本月报警次数 = 0, 采集软件在线时间 = "0" });
                }
                return new JavaScriptSerializer().Serialize(Alarmpage.webpoliceCollection != null  ? Alarmpage.webpoliceCollection : new EF实体模型.WebpoliceCollection() { ID = 0, week处理用时 = "00:00:00", week报警次数 = 0, 今日处理用时 = "00:00:00", 今日报警次数 = 0, 本月处理用时 = "00:00:00", 本月报警次数 = 0, 采集软件在线时间 = "0" });
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
            lock(dispose)
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
            lock(lT)
            {
                using(UppercomputerEntities2 db=new UppercomputerEntities2())
                {
                    var webout= db.WeboutputCollections.FirstOrDefault();
                    return new JavaScriptSerializer().Serialize(webout != null ? webout : new EF实体模型.WeboutputCollection() { ID = 0, 停机次数 = 0, 全年产量 = 0, 当月产量 = 0, 当班产量 = 0, 设备状态 = false, 设备速率 = 0, 采集软件在线时间 = "0", 采集软件状态 = false });
                }
            }
        }
        /// <summary>
        /// 当前报警锁
        /// </summary>
        static object Alarm = new object();
        /// <summary>
        /// 当前滚动报警表
        /// </summary>
        static List<WebFWAlarmTable> RollAlarmTable = new List<WebFWAlarmTable>();
        static int Rollndex = 0;
        /// <summary>
        /// 用于上传当前报警
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string PresentRoll()
        {
            lock(Alarm)
            {
                string Data = string.Empty;
                using (UppercomputerEntities2 db = new UppercomputerEntities2())
                {
                    if (Rollndex*4 >= RollAlarmTable.Count||RollAlarmTable.Count<1)
                    {
                        RollAlarmTable = db.WebFWAlarmTables.ToList();
                        Rollndex = 0;
                    }
                    //判断是否有数据
                    if(RollAlarmTable.Count>0&& Alarmpage.Gatherrun&& Rollndex*4 < RollAlarmTable.Count  )
                    {
                        RollAlarmTable[Rollndex].ID = RollAlarmTable.Count - Rollndex*4;
                        Data = new JavaScriptSerializer().Serialize(RollAlarmTable.Skip(Rollndex * 4).Take(4).ToList());
                        Rollndex += 1;
                        return Data;
                    }
                    //判断采集软件是否掉线状态
                    if(!Alarmpage.Gatherrun)
                    {
                        return new JavaScriptSerializer().Serialize(new WebFWAlarmTable()
                        {
                            ID = 0,
                            事件关联ID = 99,
                            处理完成时间 = "000",
                            报警内容 = "数据采集软件离线中",
                            报警时间 = DateTime.Now.ToString("f"),
                            类型 = true,
                            设备 = "内部",
                            设备地址 = "Web服务器",
                            设备_具体地址 = "Web"
                        });
                    }
                    //如果SQL中不存在数据表示设备正常无异常--返回Bool值
                    return "true";
                }
            }
        }
        /// <summary>
        /// 当前报警锁
        /// </summary>
        static object Alarm1 = new object();
        /// <summary>
        /// 当前滚动报警表
        /// </summary>
        static List<Alarmhistories> RollAlarmTablehistory = new List<Alarmhistories>();
        static int Rollndex1 = 0;
        /// <summary>
        /// 用于上传历史报警
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string PresentRollhistory()
        {
            lock (Alarm1)
            {
                string Data = string.Empty;
                using (UppercomputerEntities2 db = new UppercomputerEntities2())
                {
                    if (Rollndex1 >= RollAlarmTablehistory.Count || RollAlarmTablehistory.Count < 1)
                    {
                        RollAlarmTablehistory = db.Alarmhistory.ToList();
                        Rollndex1 = 0;
                    }
                    //判断是否有数据
                    if (RollAlarmTablehistory.Count > 4)
                    {
                        if (RollAlarmTablehistory.Count > 0 && Rollndex1 < RollAlarmTablehistory.Count)
                        {
                            RollAlarmTablehistory[Rollndex1].ID = RollAlarmTablehistory.Count - Rollndex1;
                            Data = new JavaScriptSerializer().Serialize(RollAlarmTablehistory[Rollndex1]);
                            Rollndex1 += 1;
                            return Data;
                        }
                    }
                    else
                    {
                        if(RollAlarmTablehistory.Count > 0 && Rollndex1*4 < RollAlarmTablehistory.Count)
                        {
                            RollAlarmTablehistory[Rollndex1].ID = RollAlarmTablehistory.Count - Rollndex1*4;
                            Data = new JavaScriptSerializer().Serialize(RollAlarmTablehistory.Skip(Rollndex1*4).Take(4).ToList());
                            Rollndex1 += 1;
                            return Data;
                        }
                    }
                    //如果SQL中不存在数据表示设备正常无异常--返回Bool值
                    return "true";
                }
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