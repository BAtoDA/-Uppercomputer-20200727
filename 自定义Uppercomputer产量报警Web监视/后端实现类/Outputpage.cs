using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 自定义Uppercomputer产量报警Web监视.EF实体模型;
using System.Threading;
using HTML布局学习.EF实体模型;
using System.Runtime.Serialization;
using HTML布局学习.小时产量类序列化;

namespace HTML布局学习.后端实现类
{
    /// <summary>
    /// 该类用于实现产量页面
    /// </summary>
    public class Outputpage
    {
        Timer refresh_time;
        /// <summary>
        /// 采集软件是否在线报警锁
        /// </summary>
        static object Alarmobject = new object();
        /// <summary>
        /// 指示采集软件是否在线
        /// </summary>
        public static bool Gatherrun
        {
            get
            {
                lock (Alarmobject)
                {
                    //判断数据采集软件是否掉线--false掉线 true 在线
                    using (UppercomputerEntities2 db = new UppercomputerEntities2())
                    {
                        var Data = db.WeboutputCollections.ToList();
                        return Data.Count > 0 ? (DateTime.Now - DateTime.Parse(Data[0].采集软件在线时间)).Minutes > 5 ? false : true : false;
                    }
                }
            }
        }
        /// <summary>
        /// 产量表锁
        /// </summary>
        static object lex = new object();
        /// <summary>
        /// SQL中的产量表
        /// </summary>
        public static List<Scheduletaiyaki> scheduletaiyaki
        {
            
            get
            {
                lock (lex)
                {
                    if (scheduleta != null)
                        return scheduleta;
                    else
                        return new List<Scheduletaiyaki>();
                }
            }
            set
            {
                lock (lex)
                {
                    scheduleta = value;
                }
            }
        }
        private  static List<Scheduletaiyaki> scheduleta;
        /// <summary>
        /// 当前报警表锁
        /// </summary>
        static object le = new object();
        /// <summary>
        /// SQL中的当前报警表
        /// </summary>
        public static List<WebFWAlarmTable> webFWAlarmTable
        {

            get
            {
                lock (le)
                {
                    if (WebFWAlarm != null)
                        return WebFWAlarm;
                    else
                        return new List<WebFWAlarmTable>();
                }
            }
            set
            {
                lock (le)
                {
                    WebFWAlarm = value;
                }
            }
        }
        private static List<WebFWAlarmTable> WebFWAlarm;
        /// <summary>
        /// 产量页面表锁
        /// </summary>
        static object lq = new object();
        /// <summary>
        /// SQL中的产量页面表
        /// </summary>
        public static List<WeboutputCollection> weboutputCollection
        {

            get
            {
                lock (lq)
                {
                    if (weboutput != null)
                        return weboutput;
                    else
                        return new List<WeboutputCollection>();
                }
            }
            set
            {
                lock (lq)
                {
                    weboutput = value;
                }
            }
        }
        private static List<WeboutputCollection> weboutput;
        /// <summary>
        /// 报警页面表锁
        /// </summary>
        static object lw = new object();
        /// <summary>
        /// SQL中的当前报警表
        /// </summary>
        public static List<WebpoliceCollection> webpoliceCollection
        {

            get
            {
                lock (lw)
                {
                    if (WebpoliceCollection != null)
                        return WebpoliceCollection;
                    else
                        return new List<WebpoliceCollection>();
                }
            }
            set
            {
                lock (lw)
                {
                    WebpoliceCollection = value;
                }
            }
        }
        private static List<WebpoliceCollection> WebpoliceCollection;
        /// <summary>
        /// 小时产量表锁
        /// </summary>
        static object lh = new object();
        /// <summary>
        /// SQL中的小时产量表
        /// </summary>
        public static List<HourOutput> hourOutput
        {

            get
            {
                lock (lh)
                {
                    if (HourOutp != null)
                        return HourOutp;
                    else
                        return new List<HourOutput>();
                }
            }
            set
            {
                lock (lh)
                {
                    HourOutp = value;
                }
            }
        }
        /// <summary>
        /// 本类数据加载锁
        /// </summary>
        static object thle = new object();
        private static List<HourOutput> HourOutp;
        public Outputpage()
        {
            //定时刷新数据
            refresh_time = new System.Threading.Timer(new TimerCallback((s) =>
            {
                lock (thle)
                {
                    //读取SQL获取指定数据
                    using (UppercomputerEntities2 entities = new UppercomputerEntities2())
                    {
                        scheduletaiyaki = entities.Scheduletaiyakis.ToList();
                        webFWAlarmTable = entities.WebFWAlarmTables.ToList();
                        weboutputCollection = entities.WeboutputCollections.ToList();
                        webpoliceCollection = entities.WebpoliceCollections.ToList();
                        hourOutput = entities.HourOutputs.ToList();
                    }
                }
            }));
            refresh_time.Change(500, 300);
        }
        /// <summary>
        /// 获取周产量
        /// </summary>
        /// <returns></returns>
        public static List<string> WeekData()
        {
            //创建周表
            List<string> Weeksurface = new List<string>();
            //周默认数据
            for (int i = 0; i < 7; i++)
            {
                Weeksurface.Add("0");
            }
            var present = System.DateTime.Now;
            int number = Convert.ToInt32(present.DayOfWeek);//需要往后移动的天数
            if (number == 0)
                number = 7;
            for (int i = 0; i < number; i++)
            {
                DateTime date2 = DateTime.Parse(System.DateTime.Now.ToString("D") + "00:00");
                TimeSpan ts2 = new TimeSpan(0, 24 * i, 0, 0);
                DateTime dt22 = date2.Subtract(ts2);
                var Date = (from p in scheduletaiyaki where DateTime.Parse(p.生产时间.Trim()).Date == dt22.Date select p).ToList();
                if (Date.Count > 0)
                {
                    int Data = 0;
                    Date.ForEach(sl =>//遍历当天所有换产后数量
                    {
                        Data += sl.当天产量;
                    });

                    Weeksurface[Convert.ToInt32(dt22.DayOfWeek - 1) < 0 ? Weeksurface.Count - 1 : (number - i) - 1] = Data.ToString();
                }
            }
            return Weeksurface;
        }
        /// <summary>
        /// 获取小时产量
        /// </summary>
        /// <returns></returns>
        public static List<HourClass> HourData()
        {
            //获取当天日期
            var Presentdate = System.DateTime.Now.ToString("D");
            //创建小时表
            List<HourClass> hourClasses = new List<HourClass>();
            //查询数据库--当前时区 产量
            var same = (from p in hourOutput where DateTime.Parse(p.生产时间.Trim()).ToString("D") == DateTime.Now.ToString("D") select p).ToList();
            //小时默认数据
            for (int i = 0; i < 6; i++)
            {
                DateTime date = DateTime.Parse(System.DateTime.Now.ToString("f"));
                TimeSpan ts = new TimeSpan(0, i, 0, 0);
                DateTime dt2 = date.Subtract(ts);
                hourClasses.Add(new HourClass() { HourName = dt2.ToString("t"), HourData = "0" });
            }

                //开始遍历小时产量
                for (int i = 0; i < 6; i++)
                {
                    //计算时区
                    DateTime date = DateTime.Parse(System.DateTime.Now.ToString("f"));
                    TimeSpan ts = new TimeSpan(0, i, 0, 0);
                    DateTime dt2 = date.Subtract(ts);
                    var Presentdate1 = dt2.Hour.ToString("0");
                    //查询数据库--当前时区 产量
                    var Date = (from p in same where DateTime.Parse(p.生产时间.Trim()).Hour == dt2.Hour select p).ToList();
                    if (Date.Count == 0)
                    {
                        continue;//强行重开循环
                    }
                    hourClasses[i].HourData = (Date.Sum(X => X.生产数量)<0?0: Date.Sum(X => X.生产数量)).ToString();
                }
            hourClasses.Reverse();
            return hourClasses;
        }
        /// <summary>
        /// 获取月产量--生成月度表
        /// </summary>
        /// <returns></returns>
        public static List<HourClass> MonthData()
        {
            //创建月表
            List<HourClass> Weeksurface = new List<HourClass>();           
            //月默认数据
            for (int i = 0; i < 5; i++)
            {
                Weeksurface.Add(new HourClass() { HourData = "0", HourName = i.ToString() });
            }
                //获取当前时间
                var present = System.DateTime.Now;
                int month = (present.Month - 4);
                int year = System.DateTime.Now.Year;
                //获取当前月的往后7个月的时间
                //判断获取的数据是否需要跨年度
                if ((present.Month - 5) < 0)
                {
                    //获取后一年的月数
                    month = (present.Month - 5) + 13;
                    //获取后一年的数
                    year = System.DateTime.Now.Year - 1;
                }
                for (int i = 0; i < 5; i++)
                {
                    //如果数量大于12  变成当前年1月1号
                    if (month > 12)
                    {
                        month = 1;
                        year = System.DateTime.Now.Year;
                    }
                    month = month == 0 ? 1 : month;
                    //获取需要遍历的时间
                    DateTime date2 = DateTime.Parse($"{year}/{month}/1 00:00");
                  var Month = (from p in scheduletaiyaki where date2.ToString("Y") == DateTime.Parse(p.生产时间.Trim()).ToString("Y") select p).Sum(x => x.当天产量);
                    month += 1;
                    //判断获取到的产量表
                    Weeksurface[i].HourName = date2.ToString("d");
                    Weeksurface[i].HourData = (Month).ToString();
                }
                //当月就显示当前最新的日期
                Weeksurface[4].HourName = present.ToString("d");
            
            return Weeksurface;
        }

    }
}