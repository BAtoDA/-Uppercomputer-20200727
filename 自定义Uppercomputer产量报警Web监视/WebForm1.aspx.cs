using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HTML布局学习.小时产量类序列化;
using HTML布局学习.报警类序列化;

namespace HTML布局学习
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 折线图获取全周产量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static List<string> GetWeekData()
        {
            //此处需要配合SQL数据库
            Random random = new Random();
            return new List<string>() {random.Next(0,2000).ToString(), random.Next(0, 2000).ToString() , random.Next(0, 2000).ToString(),
           random.Next(0,2000).ToString(),random.Next(0,2000).ToString(),random.Next(0,2000).ToString(),random.Next(0,2000).ToString()};
        }
        /// <summary>
        /// 圆形图显示设备总产量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Getthroughput()
        {
            //此处需要配合SQL数据库
            return new Random().Next(1000, 6000).ToString();
        }
        /// <summary>
        /// 圆形图显示设备当前产量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string GetPresent()
        {
            //此处需要在线读取PLC产量
            return new Random().Next(0, 1600).ToString();
        }
        /// <summary>
        /// 柱形图小时显示时间
        /// </summary>
        static List<string> hourName = new List<string>();
        /// <summary>
        /// 柱形图前台获取小时显示名称--废弃
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static List<string> GetHourName()
        {
            lock (loc)
            {
                if (hourName.Count > 6)//柱形最大显示数目
                {
                    hourName.RemoveAt(0);//移除头部数据
                    hourData.RemoveAt(0);//移除头部数据
                    Houryield_Time.RemoveAt(0);
                }
            }
            return hourName;
        }
        static List<string> hourData = new List<string>();
        /// <summary>
        /// 柱形图前台获取PLC当前产量--废弃
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static List<string> GetHourData()
        {
            lock (loc)
            {
                PLC_Houryield();//获取PLC数据
                if (hourData.Count > 6)//柱形最大显示数目
                {
                    hourName.RemoveAt(0);//移除头部数据
                    hourData.RemoveAt(0);//移除头部数据
                    Houryield_Time.RemoveAt(0);
                }
            }
            return hourData;             
        }
        /// <summary>
        /// 折线图当前时间
        /// </summary>
        static List<string> Houryield_Time = new List<string>();
        static object loc = new object();
        /// <summary>
        /// 判断距离上次读取是否满足一小时
        /// </summary>
        private static void PLC_Houryield()
        {
            lock (loc)
            {
                if (hourName.Count < 1)//判断是否初次上电？
                {
                    hourName.Add(System.DateTime.Now.ToString("T"));//添加时间
                    hourData.Add(new Random().Next(0, 500).ToString());//模拟产量
                    Houryield_Time.Add(System.DateTime.Now.ToString("T"));//添加时间不显示秒
                }
                else
                {
                    //获取时间进行时间运算--3600秒等于1小时后添加一组数据
                    DateTime dt1 = DateTime.Parse(Houryield_Time[Houryield_Time.Count - 1]);
                    var DX = DateTime.Now.Subtract(dt1).TotalSeconds;
                    if (DateTime.Now.Subtract(dt1).TotalSeconds >= 2)
                    {
                        //Linechart_output.Add(Convert.ToInt32(pLC_Interface.PLC_read_D_register("DB", "74.12", numerical_format.Signed_32_Bit)));//读取当前产量
                        hourName.Add(System.DateTime.Now.ToString("T"));//添加时间
                        hourData.Add(new Random().Next(0, 500).ToString());//模拟产量
                        Houryield_Time.Add(System.DateTime.Now.ToString("T"));//添加时间不显示秒
                    }
                }
            }
        }
        /// <summary>
        /// 获取当班目标数量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string GetSquad_target()
        {
            //此处需要在SQL数据库获取
            return new Random().Next(0, 1600).ToString();
        }
        /// <summary>
        /// 获取当班产量数量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Squad_output()
        {
            //此处需要在线读取PLC产量
            return new Random().Next(500,1600).ToString();
        }
        /// <summary>
        /// 获取当月目标数量
        /// </summary>
        /// <returns></returns>

        [WebMethod]
        public static string headline_target()
        {
            //此处需要在SQL数据库获取
            return new Random().Next(2000, 30000).ToString();
        }
        /// <summary>
        /// 获取当月产量数量
        /// </summary>
        /// <returns></returns>

        [WebMethod]
        public static string headline_output()
        {
            //此处需要在SQL数据库获取
            return new Random().Next(0, 3000).ToString();
        }
        /// <summary>
        /// 获取当月产量数量
        /// </summary>
        /// <returns></returns>

        [WebMethod]
        public static string headline1_output()
        {
            //此处需要在SQL数据库获取
            return new Random().Next(100000, 300000).ToString();
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
                int Page = 0;//页数
                             //测试数据
                for (int i = 0; i < 6; i++)
                {
                    if ((i > Page * 4) & (i > 4))
                    {
                        Page += 1;
                    }
                    imagelist.Add(new Alarm() { AlarmID = $"M{i}", AlarmContent = $"当前报警DDDDDDDD{i}", AlarmManageTime = "否", AlarmPage = Page, AlarmTime = DateTime.Now.ToString("T") });
                }
                //序列化JSON返回前端
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                string imageinfoStr = jsonSerializer.Serialize(imagelist);
                return imageinfoStr;
            }
        }

        /// <summary>
        /// 前端Post请求获取小时产量
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Houryield()
        {
            lock (Info)
            {
                PLC_Houryield();//获取PLC数据
                if (hourData.Count > 6)//柱形最大显示数目
                {
                    hourName.RemoveAt(0);//移除头部数据
                    hourData.RemoveAt(0);//移除头部数据
                    Houryield_Time.RemoveAt(0);
                }
                List<HourClass> imagelist = new List<HourClass>();//表单集合
                for(int i=0;i< hourData.Count;i++)
                    imagelist.Add(new HourClass() { HourData =hourData[i], HourName =hourName[i] });
                //自动补全数据
                for (int i = hourData.Count; i < 6; i++)
                {
                    imagelist.Add(new HourClass() { HourData ="0" , HourName = DateTime.Now.ToString("T") }) ;
                }
                var listdata = (from pi in imagelist orderby pi.HourName select pi).ToList();
                //序列化JSON返回前端
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                string imageinfoStr = jsonSerializer.Serialize(listdata);
                return imageinfoStr;
            }
        }

    }
}