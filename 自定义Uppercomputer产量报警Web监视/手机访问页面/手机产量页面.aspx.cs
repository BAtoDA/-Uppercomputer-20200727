using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HTML布局学习.后端实现类;
using 自定义Uppercomputer产量报警Web监视.EF实体模型;

namespace HTML布局学习
{
    public partial class WebForm22 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Outputpage outputpage = new Outputpage();
        }
        static object Infoi9 = new object();
        /// <summary>
        /// 圆形图显示设备当前产量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string GetPresent1()
        {
            lock (Infoi9)
            {
               using(UppercomputerEntities2 db=new UppercomputerEntities2())
                {
                    var data = (from p in db.HourOutputs.ToList() where DateTime.Parse(p.生产时间).ToString("D") == DateTime.Now.ToString("D") where (DateTime.Now - DateTime.Parse(p.生产时间)).Hours < 1 select p).FirstOrDefault();
                    return data != null ? data.生产数量.ToString() : "0";
                }
            }
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
                return Outputpage.webpoliceCollection.Count > 0 ? Outputpage.webpoliceCollection[0].今日报警次数.ToString() : "0";
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
                using (UppercomputerEntities2 db = new UppercomputerEntities2())
                {
                    var data = db.ParameterWebs.FirstOrDefault();
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
    }
}