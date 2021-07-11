using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HTML布局学习.后端实现类;
using HTML布局学习.小时产量类序列化;
using HTML布局学习.报警类序列化;
using 自定义Uppercomputer产量报警Web监视.EF实体模型;

namespace HTML布局学习
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Outputpage outputpage = new Outputpage();
        }
        /// <summary>
        /// 折线图获取全周产量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static List<string> GetWeekData()
        {
            //上传整周图表数据
            return Outputpage.WeekData();
        }
        static object Infou = new object();
        [WebMethod]
        /// <summary>
        /// 前端直接获取月度表单
        /// </summary>
        /// <returns></returns>
        public static string Yearyield()
        {
            lock (Infou)
            {
                //序列化JSON返回前端
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                string imageinfoStr = jsonSerializer.Serialize(Outputpage.MonthData());
                return imageinfoStr;
            }

        }
        static object Infoi = new object();
        /// <summary>
        /// 前端Post请求获取小时产量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Houryield()
        {
            lock (Infoi)
            {
                //序列化JSON返回前端
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                string imageinfoStr = jsonSerializer.Serialize(Outputpage.HourData());
                return imageinfoStr;
            }
        }
        static object Infoi1 = new object();
        /// <summary>
        /// 圆形图显示异常处理时间
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Getthroughput()
        {
            lock (Infoi1)
            {
                return Outputpage.webpoliceCollection.Count>0? Outputpage.webpoliceCollection[0].今日报警次数.ToString():"0";
            }
        }
        static object Infoi2 = new object();
        /// <summary>
        /// 圆形图显示设备当前产量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string GetPresent()
        {
            lock (Infoi2)
            {
                return Outputpage.weboutputCollection.Count > 0 ? Outputpage.weboutputCollection[0].当班产量.ToString() : "0";
            }
        }
        static object Infoi3 = new object();
        /// <summary>
        /// 获取当班目标数量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string GetSquad_target()
        {
            lock (Infoi3)
            {
               using(UppercomputerEntities2 db=new UppercomputerEntities2())
                {
                   var data= db.ParameterWebs.FirstOrDefault();
                    return data != null ? data.当班目标.ToString() : "0";
                }
            }
        }
        static object Infoi4 = new object();
        /// <summary>
        /// 获取当班产量数量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Squad_output()
        {
            lock (Infoi4)
            {
                return Outputpage.weboutputCollection.Count > 0 ? Outputpage.weboutputCollection[0].当班产量.ToString() : "0";
            }
        }
        static object Infoi5 = new object();
        /// <summary>
        /// 获取当月目标数量
        /// </summary>
        /// <returns></returns>

        [WebMethod]
        public static string headline_target()
        {
            lock (Infoi5)
            {
                using (UppercomputerEntities2 db = new UppercomputerEntities2())
                {
                    var data = db.ParameterWebs.FirstOrDefault();
                    return data != null ? data.当月目标.ToString() : "0";
                }
            }
        }
        static object Infoi6 = new object();
        /// <summary>
        /// 获取当月产量数量
        /// </summary>
        /// <returns></returns>

        [WebMethod]
        public static string headline_output()
        {
            lock (Infoi6)
            {
                return Outputpage.weboutputCollection.Count > 0 ? Outputpage.weboutputCollection[0].当月产量.ToString() : "0";
            }
        }
        static object Infoi7 = new object();
        /// <summary>
        /// 获取获取全年产量
        /// </summary>
        /// <returns></returns>

        [WebMethod]
        public static string headline1_output()
        {
            lock (Infoi7)
            {
                return Outputpage.weboutputCollection.Count > 0 ? Outputpage.weboutputCollection[0].全年产量.ToString() : "0";
            }
        }
        static object Info = new object();
        /// <summary>
        /// 前端直接传入泛型集合对象
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string DisplayImagesInfo()
        {
            lock (Info)
            {
                List<Alarm> imagelist = new List<Alarm>();//表单集合
                //判断数据采集软件是否掉线--false掉线 true 在线
                var status = Outputpage.weboutputCollection.Count > 0 ? (DateTime.Now-DateTime.Parse(Outputpage.weboutputCollection[0].采集软件在线时间)).Minutes>5?false:true : false;
                //输出 当前为掉线状态
                if (!status)
                {
                    imagelist.Add(new Alarm() { AlarmID = $"内部", AlarmContent = $"数据采集离线状态", AlarmManageTime = "否", AlarmPage = 0, AlarmTime = DateTime.Now.ToString("T") });
                    //序列化JSON返回前端
                    return new JavaScriptSerializer().Serialize(imagelist);
                }
                int Page = 0;//页数
                if (Outputpage.webFWAlarmTable != null)
                {
                    //采集软件正常 --开始输出报警
                    foreach (var i in Outputpage.webFWAlarmTable)
                    {
                        imagelist.Add(new Alarm() { AlarmID = i.设备.Trim() + i.设备_具体地址.Trim(), AlarmContent = i.报警内容.Trim(), AlarmManageTime = "否", AlarmPage = Page, AlarmTime = i.报警时间.Trim() });
                    }
                }
                //序列化JSON返回前端
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                string imageinfoStr = jsonSerializer.Serialize(imagelist);
                return imageinfoStr;
            }
        }

    }
}