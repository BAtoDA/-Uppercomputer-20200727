using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Web;
using 服务器端.上位机通讯报文处理;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Threading;
using PLC通讯规范接口;
using Mitsubishi_D = 服务器端.上位机通讯报文处理.Mitsubishi_D;
using Siemens_D = 服务器端.上位机通讯报文处理.Siemens_D;
using Modbus_TCP_D = 服务器端.上位机通讯报文处理.Modbus_TCP_D;
using HMI_D = 服务器端.上位机通讯报文处理.HMI_D;
using Omron_bit = 服务器端.上位机通讯报文处理.Omron_bit;
using Omron_D = 服务器端.上位机通讯报文处理.Omron_D;
using Web网页数据后台采集.EF实体模型;
using System.Linq;
using Mitsubishi_bit = 服务器端.上位机通讯报文处理.Mitsubishi_bit;
using Siemens_bit = 服务器端.上位机通讯报文处理.Siemens_bit;
using Modbus_TCP_bit = 服务器端.上位机通讯报文处理.Modbus_TCP_bit;

namespace Web网页数据后台采集.PLC通讯部分
{
   /// <summary>
   /// 实现PLC通讯类--采用上位机内部通讯类
   /// 具体实现请查看服务器端 上位机通讯报文处理
   /// </summary>
    public class PLCChatRoom: Socket_Client
    {
        /// <summary>
        /// 互斥锁 预防多线程进入导致 数据错乱
        /// </summary>
        static Mutex mutex { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="iPEnd">需要通讯的地址</param>
        public PLCChatRoom(IPEndPoint iPEnd):base(iPEnd)
        {
            this.IPEnd = iPEnd;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            GetSqlScheduletaiyaki();
        }
        /// <summary>
        /// 自动获取本机IP地址
        /// 由于上位机内部通讯是自动或者本机IP地址作为绑定 成功获取绑定该ip 失败默认 127.0.0.1 
        /// 推荐使用该类搭配
        /// </summary>
        /// <returns></returns>
        public static IList<string> GetSocketIP()
        {
            var networkCardIPs = new List<string>();

            NetworkInterface[] fNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in fNetworkInterfaces)
            {
                string fRegistryKey = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + adapter.Id + "\\Connection";
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
                if (rk != null)
                {
                    // 区分 PnpInstanceID  
                    // 如果前面有 PCI 就是本机的真实网卡 
                    string fPnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
                    int fMediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", 0));
                    if (fPnpInstanceID.Length > 3 && fPnpInstanceID.Substring(0, 3) == "PCI")
                    {
                        IPInterfaceProperties fIPInterfaceProperties = adapter.GetIPProperties();
                        UnicastIPAddressInformationCollection UnicastIPAddressInformationCollection = fIPInterfaceProperties.UnicastAddresses;
                        foreach (UnicastIPAddressInformation UnicastIPAddressInformation in UnicastIPAddressInformationCollection)
                        {
                            if (UnicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                networkCardIPs.Add(UnicastIPAddressInformation.Address.ToString()); //Ip 地址
                            }
                        }
                    }
                }
            }

            return networkCardIPs.Count>0? networkCardIPs : new List<string>() { "127.0.0.1"};
        }
        private object Sche = new object();
        /// <summary>
        /// 保存在内存中的设置参数
        /// </summary>
        private ParameterWeb ParameterWebi
        {
            get
            {
                lock (Sche)
                {
                    return parameterWeb;
                }
            }
            set
            {
                lock(Sche)
                {
                    parameterWeb = value;
                }
            }
        }
        private ParameterWeb parameterWeb;
        /// <summary>
        /// 获取设置参数到本类内存中
        /// </summary>
        /// <returns></returns>
        public void GetSqlScheduletaiyaki()
        {
            using(UppercomputerEntities2 db=new UppercomputerEntities2())
            {
                parameterWeb = db.ParameterWebs.FirstOrDefault();
            }
        }
        /// <summary>
        /// 获取PLC中的产量并且汇报到SQL中
        /// </summary>
        public void GetPLCoutput()
        {
            if (this.Socket_ready&parameterWeb!=null)
            {
                dynamic data = new object();
                dynamic Hmidata = new object();
                dynamic Materialcoding = new object();
                dynamic MaterialHmidata = new object();
                switch (Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) ?? PLC.Mitsubishi)
                {
                    case PLC.Mitsubishi:
                        //读取产量
                        data = this.ReadPLCD(this.GetType().Name,(Mitsubishi_D)Enum.Parse(typeof(Mitsubishi_D),parameterWeb.产量地址.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.产量具体地址.Trim(),1);
                        //读取物料编码
                        Materialcoding = this.ReadPLCD(this.GetType().Name, (Mitsubishi_D)Enum.Parse(typeof(Mitsubishi_D), parameterWeb.物料编码.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.编码具体地址.Trim(), 1);
                        break;
                    case PLC.Siemens:
                        //读取产量
                        data = this.ReadPLCD(this.GetType().Name, (Siemens_D)Enum.Parse(typeof(Siemens_D), parameterWeb.产量地址.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.产量具体地址.Trim(), 1);
                        //读取物料编码
                        Materialcoding = this.ReadPLCD(this.GetType().Name, (Siemens_D)Enum.Parse(typeof(Siemens_D), parameterWeb.物料编码.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.编码具体地址.Trim(), 1);
                        break;
                    case PLC.Modbus_TCP:
                        //读取产量
                        data = this.ReadPLCD(this.GetType().Name, (Modbus_TCP_D)Enum.Parse(typeof(Modbus_TCP_D), parameterWeb.产量地址.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.产量具体地址.Trim(), 1);
                        //读取物料编码
                        Materialcoding = this.ReadPLCD(this.GetType().Name, (Modbus_TCP_D)Enum.Parse(typeof(Modbus_TCP_D), parameterWeb.物料编码.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.编码具体地址.Trim(), 1);
                        break;
                    case PLC.HMI:
                        //读取产量
                        data = this.ReadHmiD<int>(this.GetType().Name,Convert.ToInt32(parameterWeb.产量具体地址.Trim()),1,HmiType.Int32);
                        Hmidata = data.IsSuccess ? data.Content[0] : 0;
                        //读取物料编码
                        Materialcoding = this.ReadHmiD<int>(this.GetType().Name, Convert.ToInt32(parameterWeb.编码具体地址.Trim()), 1, HmiType.Int32);
                        MaterialHmidata = Materialcoding.IsSuccess ? Materialcoding.Content[0] : 0;
                        break;
                    case PLC.OmronTCP:
                    case PLC.OmronCIP:
                    case PLC.OmronUDP:
                        //读取产量
                        data = this.ReadPLCD(this.GetType().Name, (Omron_D)Enum.Parse(typeof(Omron_D), parameterWeb.产量地址.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.产量具体地址.Trim(), 1);
                        //读取物料编码
                        Materialcoding = this.ReadPLCD(this.GetType().Name, (Omron_D)Enum.Parse(typeof(Omron_D), parameterWeb.物料编码.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.编码具体地址.Trim(), 1);
                        break;
                }
                if(data.IsSuccess&& Materialcoding.IsSuccess)
                {
                    //读取成功上传到SQL
                    using(UppercomputerEntities2 db=new UppercomputerEntities2())
                    {
                        //获取系统当前时间
                        var Datetimeq = DateTime.Now;
                        //获取当天时间
                        var Dateday = Datetimeq.ToLongDateString().ToString() ;
                        //获取当天小时时间
                        var DateHortq = DateTime.Parse(Datetimeq.ToString("f"));


                        //获取当天是否有上传过数据
                        var DataSQL = (from p in db.Scheduletaiyakis.ToList() where DateTime.Parse(p.生产时间).ToString("D") == Dateday select p).FirstOrDefault();

                        var datae = db.Alarmhistory.ToList();
                        var query = (from q in datae where DateTime.Parse(q.报警时间.Trim()).ToString("D") == DateTime.Now.ToString("D") select q).ToList();
                        if (DataSQL != null)
                        {
                            //当天有数据
                            DataSQL.生产时间 = DateTime.Now.ToString("f");
                            DataSQL.物料编码 = Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? MaterialHmidata : Materialcoding.Content);
                            DataSQL.当天目标 = (int)parameterWeb.当班目标;
                            DataSQL.当天产量 = Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim())==PLC.HMI?Hmidata: data.Content);
                            DataSQL.异常次数 = query.Count;
                            DataSQL.异常时长 = MonthlyErrQ(query).ToString();

                        }
                        else
                        {
                            //当天未上传数据
                            Scheduletaiyaki scheduletaiyaki = new Scheduletaiyaki();
                            scheduletaiyaki.生产时间 = DateTime.Now.ToString("f");
                            scheduletaiyaki.物料编码 = Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? MaterialHmidata : Materialcoding.Content);
                            scheduletaiyaki.当天目标 = (int)parameterWeb.当班目标;
                            scheduletaiyaki.当天产量 = Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? Hmidata : data.Content);
                            scheduletaiyaki.异常次数 = query.Count;
                            scheduletaiyaki.异常时长 = MonthlyErrQ(query).ToString();
                            scheduletaiyaki.ID = 0;
                            db.Scheduletaiyakis.Add(scheduletaiyaki);
                        }
                        //获取小时是否有上传过数据
                        var HortData = db.HourOutputs.ToList();
                        var DataSQLHort = (from pi in HortData where (DateHortq - DateTime.Parse(pi.生产时间.Trim())).Hours < 1 select pi).FirstOrDefault();
                        //获取上个小时是否有数据
                        var DataSQLUPHort = (from pi in HortData where (DateHortq - DateTime.Parse(pi.生产时间.Trim())).Hours >= 1 && (DateHortq - DateTime.Parse(pi.生产时间.Trim())).Hours < 2 select pi).FirstOrDefault();
                        if (DataSQLHort != null)
                        {
                            //当前小时有数据
                            DataSQLHort.生产数量 = DataSQLUPHort != null ? Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? Hmidata : data.Content) - (DataSQLUPHort != null ? DataSQLUPHort.生产数量 > 0 ? DataSQLUPHort.生产数量 : 0 : 0) : Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? Hmidata : data.Content);
                            DataSQLHort.生产数量 = DataSQLHort.生产数量 < 1 ? Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? Hmidata : data.Content) : DataSQLHort.生产数量;
                            DataSQLHort.班次 = DateTime.Now.Hour > 18 ? true : false;
                        }
                        else
                        {
                            //当前小时没有数据
                            HourOutput hourOutput = new HourOutput()
                            {
                                ID = 0,
                                生产数量 = Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? Hmidata : data.Content),
                                生产时间 = DateTime.Now.ToString("f"),
                                班次 = DateTime.Now.Hour > 18 ? true : false
                            };
                            db.HourOutputs.Add(hourOutput);
                        }
                        //保存到SQL中
                        db.SaveChanges();
                    }
                }
            }
        }
        /// <summary>
        /// 计算的报警处理用时
        /// </summary>
        private TimeSpan MonthlyErrQ(List<Alarmhistories> Querydata)
        {
            TimeSpan time = new TimeSpan();
            Querydata.ForEach(P =>
            {
                time += DateTime.Parse(P.处理完成时间.Trim()) - DateTime.Parse(P.报警时间.Trim());
            });
            return time;
        }
        /// <summary>
        /// 用于处理产量WeboutputCollection表的数据 上传到SQL
        /// </summary>
        public void OutputWeb()
        {
            using (UppercomputerEntities2 db = new UppercomputerEntities2())
            {
                ///假定8:00---到18:00为晚班  18：00到次日7:00为晚班
                var HourTabel = (from p in db.HourOutputs.ToList() where (DateTime.Now - DateTime.Parse(p.生产时间.Trim())).Days == 0 select p).ToList().GroupBy(x => x.班次).OrderBy(x => x.Key).Select(q => new Nightshift { nightshift = q.Key, NightshiftTabel = q }).ToList();
                //判断当天是白班还是晚班
                var NightshiftoutputTabel = HourTabel.Where(p => p.nightshift == DateTime.Now.Hour > 18 ? true : false).FirstOrDefault();
                //计算集合的和 
                var Nightshiftoutput = NightshiftoutputTabel != null ? NightshiftoutputTabel.NightshiftTabel.Sum(x => x.生产数量) : 0;
                //获取生产数据集合
                var Tabel = db.Scheduletaiyakis.ToList();
                //获取本月生产数量
                var ScheduletaiyakiTabel = (from p in Tabel where DateTime.Now.ToString("Y") == DateTime.Parse(p.生产时间.Trim()).ToString("Y") select p).Sum(x => x.当天产量);
                //获取全年产量
                var YearTabel = (from p in Tabel where DateTime.Now.ToString("yyyy") == DateTime.Parse(p.生产时间.Trim()).ToString("yyyy") select p).Sum(x => x.当天产量);
                //获取设备状态
                if (this.Socket_ready & parameterWeb != null)
                {
                    dynamic data = new object();
                    dynamic Hmidata = new object();
                    dynamic Materialcoding = new object();
                    dynamic MaterialHmidata = new object();
                    switch (Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) ?? PLC.Mitsubishi)
                    {
                        case PLC.Mitsubishi:
                            //读取设备状态
                            data = this.ReadPLCBool(this.GetType().Name, (Mitsubishi_bit)Enum.Parse(typeof(Mitsubishi_bit), parameterWeb.自动运行地址.Trim()), parameterWeb.自动运行具体地址.Trim(), 1);
                            //读取设备速率
                            Materialcoding = this.ReadPLCD(this.GetType().Name, (Mitsubishi_D)Enum.Parse(typeof(Mitsubishi_D), parameterWeb.设备速率地址.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.设备速率具体地址.Trim(), 1);
                            break;
                        case PLC.Siemens:
                            //读取设备状态
                            data = this.ReadPLCBool(this.GetType().Name, (Siemens_bit)Enum.Parse(typeof(Siemens_bit), parameterWeb.自动运行地址.Trim()), parameterWeb.自动运行具体地址.Trim(), 1);
                            //读取设备速率
                            Materialcoding = this.ReadPLCD(this.GetType().Name, (Siemens_D)Enum.Parse(typeof(Siemens_D), parameterWeb.设备速率地址.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.设备速率具体地址.Trim(), 1);
                            break;
                        case PLC.Modbus_TCP:
                            //读取设备状态
                            data = this.ReadPLCBool(this.GetType().Name, (Modbus_TCP_bit)Enum.Parse(typeof(Modbus_TCP_bit), parameterWeb.自动运行地址.Trim()), parameterWeb.自动运行具体地址.Trim(), 1);
                            //读取设备速率
                            Materialcoding = this.ReadPLCD(this.GetType().Name, (Modbus_TCP_D)Enum.Parse(typeof(Modbus_TCP_D), parameterWeb.设备速率地址.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.设备速率具体地址.Trim(), 1);
                            break;
                        case PLC.HMI:
                            //读取设备状态
                            data = this.ReadHmi_Bool(this.GetType().Name, Convert.ToInt32(parameterWeb.自动运行具体地址.Trim()), 1);
                            Hmidata = data.IsSuccess ? data.Content[0] : false;
                            //读取设备速率
                            Materialcoding = this.ReadHmiD<int>(this.GetType().Name, Convert.ToInt32(parameterWeb.设备速率具体地址.Trim()), 1, HmiType.Int32);
                            MaterialHmidata = Materialcoding.IsSuccess ? Materialcoding.Content[0] : 0;
                            break;
                        case PLC.OmronTCP:
                        case PLC.OmronCIP:
                        case PLC.OmronUDP:
                            //读取设备状态
                            data = this.ReadPLCBool(this.GetType().Name, (Omron_bit)Enum.Parse(typeof(Omron_bit), parameterWeb.自动运行地址.Trim()), parameterWeb.自动运行具体地址.Trim(), 1);
                            //读取设备速率
                            Materialcoding = this.ReadPLCD(this.GetType().Name, (Omron_D)Enum.Parse(typeof(Omron_D), parameterWeb.设备速率地址.Trim()), 服务器端.上位机通讯报文处理.numerical_format.Signed_32_Bit, parameterWeb.设备速率具体地址.Trim(), 1);
                            break;
                    }
                    var Collections = db.WeboutputCollections.FirstOrDefault();
                    if (Collections != null)
                    {
                        //数据存在数据
                        Collections.停机次数 = 0;
                        Collections.全年产量 = YearTabel;
                        Collections.当月产量 = ScheduletaiyakiTabel;
                        Collections.当班产量 = Nightshiftoutput;
                        Collections.设备状态 = (PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? Hmidata : data.Content;
                        Collections.设备速率 = Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? MaterialHmidata : Materialcoding.Content);
                        Collections.采集软件状态 = true;
                        Collections.采集软件在线时间 = DateTime.Now.ToString("f");
                    }
                    else
                    {
                        //数据不存在数据
                        WeboutputCollection weboutput = new WeboutputCollection()
                        {
                            ID = 0,
                            停机次数 = 0,
                            全年产量 = YearTabel,
                            当月产量 = ScheduletaiyakiTabel,
                            当班产量 = Nightshiftoutput,
                            设备状态 = (PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? Hmidata : data.Content,
                            设备速率 = Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? MaterialHmidata : Materialcoding.Content),
                            采集软件在线时间 = DateTime.Now.ToString("f"),
                            采集软件状态 = true
                        };
                        db.WeboutputCollections.Add(weboutput);
                    }
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// 用于处理报警WebpoliceCollection表的数据 上传到SQL
        /// </summary>
        public void AlarmWeb()
        {
            //从数据获取数据
            using (UppercomputerEntities2 db = new UppercomputerEntities2())
            {
                var data = db.Alarmhistory.ToList();
                var query = (from q in data where DateTime.Parse(q.报警时间.Trim()).ToString("D") == DateTime.Now.ToString("D") select q).ToList();

                //填充7天警告次数
                var query1 = (from q in data where (DateTime.Parse(DateTime.Now.ToString("F")) - DateTime.Parse(q.报警时间.Trim())).Days >= 0 && (DateTime.Parse(DateTime.Now.ToString("F")) - DateTime.Parse(q.报警时间.Trim())).Days <= 7 select q).ToList();

                //查询月度警告次数
                var Monthly = (from q in data where (DateTime.Parse(DateTime.Now.ToString("Y")) == DateTime.Parse(DateTime.Parse(q.报警时间.Trim()).ToString("Y"))) select q).ToList();
                //填充月底报警次数
                //_ = Monthly.Count.ToString();//填充月底报警次数
                //生成分析7天警告报表
                //把7天结果LINQ分组
                var grouping = query1.GroupBy(pi => DateTime.Parse(pi.报警时间.Trim()).Date).Select(group => new StoreInfo
                {
                    StoreID = group.Key,
                    List = group.ToList()
                }).ToList();
                //获取后7天的日期
                string[] Days = new string[7];
                for (int i = 0; i < Days.Length; i++)
                    Days[i] = DateTime.Now.AddDays(Convert.ToInt16($"-{i}")).ToString(); //当前时间减去7天
                //计算每天处理异常的总时间
                List<Tuple<int, string>> Histogramdata = new List<Tuple<int, string>>();
                DateTime dateTime = DateTime.Parse(DateTime.Now.ToString("yyyy - MM - dd"));
                int quantity = 0;
                foreach (var i in Days)
                {
                    dateTime = DateTime.Parse(DateTime.Now.ToString("yyyy - MM - dd"));
                    quantity = 0;
                    var group = grouping.Where(pi => pi.StoreID.ToString("D") == DateTime.Parse(i.Trim()).ToString("D")).Select(pi => pi).FirstOrDefault();
                    if (group != null)
                    {
                        var grouptime = group.List.Where(pi => DateTime.Parse(pi.报警时间.Trim()).ToString("D") == DateTime.Parse(i.Trim()).ToString("D")).Select(P => new { DatetimeName = DateTime.Parse(P.处理完成时间.Trim()) - DateTime.Parse(P.报警时间.Trim()) }).ToList();
                        //求和时间
                        grouptime.ForEach(s =>
                        {
                            dateTime += s.DatetimeName;
                        });
                        quantity = grouptime.Count;
                    }
                    Histogramdata.Add(new Tuple<int, string>(quantity, dateTime.ToString("T")));
                }
                //填充警告处理用时
                //_= Histogramdata[0].Item2;//当天用时
                //处理7天用时
                TimeSpan dateTim = MonthlyErr(query1, query1.Count);
                //_= $"{(24 * dateTim.Days) + dateTim.Hours}:{dateTim.Minutes}:{dateTim.Seconds}";
                //填充月度处理用时
                TimeSpan dateTim1 = new TimeSpan();
                MonthlyErr(Monthly).ForEach(s =>
                {
                    dateTim1 += TimeSpan.Parse(s.Item2.Trim());
                });
                //_= $"{(24 * dateTim1.Days) + dateTim1.Hours}:{dateTim1.Minutes}:{dateTim1.Seconds}";
                //填充表格数据
                var Webpolice= db.WebpoliceCollections.FirstOrDefault();
                if (Webpolice != null)
                {
                    //SQL中存在数据
                    Webpolice.今日报警次数 = query.Count;//填充当天报警次数
                    Webpolice.今日处理用时 = Histogramdata[0].Item2;//当天用时
                    Webpolice.week报警次数 = query1.Count; //填充7天警告次数
                    Webpolice.week处理用时 = $"{(24 * dateTim.Days) + dateTim.Hours}:{dateTim.Minutes}:{dateTim.Seconds}"; //处理7天用时
                    Webpolice.本月报警次数 = Monthly.Count;//填充月底报警次数
                    Webpolice.本月处理用时 = $"{(24 * dateTim1.Days) + dateTim1.Hours}:{dateTim1.Minutes}:{dateTim1.Seconds}"; //填充月度处理用时
                    Webpolice.采集软件在线时间 = DateTime.Now.ToString("f");

                }
                else
                {
                    //SQL不存在数据
                    WebpoliceCollection webpolice = new WebpoliceCollection()
                    {
                        今日报警次数 = query.Count,//填充当天报警次数
                        今日处理用时 = Histogramdata[0].Item2,//当天用时
                        week报警次数 = query1.Count, //填充7天警告次数
                        week处理用时 = $"{(24 * dateTim.Days) + dateTim.Hours}:{dateTim.Minutes}:{dateTim.Seconds}", //处理7天用时
                        本月报警次数 = Monthly.Count,//填充月底报警次数
                        本月处理用时 = $"{(24 * dateTim1.Days) + dateTim1.Hours}:{dateTim1.Minutes}:{dateTim1.Seconds}", //填充月度处理用时
                        采集软件在线时间 = DateTime.Now.ToString("f"),
                        ID = 0
                    };
                    db.WebpoliceCollections.Add(webpolice);
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 计算的报警处理用时
        /// </summary>
        private TimeSpan MonthlyErr(List<Alarmhistories> Querydata, int index)
        {
            TimeSpan time = new TimeSpan();
            Querydata.ForEach(P =>
            {
                time += DateTime.Parse(P.处理完成时间.Trim()) - DateTime.Parse(P.报警时间.Trim());
            });
            return time;
        }
        /// <summary>
        /// 计算30天的报警处理用时
        /// </summary>
        private List<Tuple<int, string>> MonthlyErr(List<Alarmhistories> Querydata)
        {
            //把30天结果LINQ分组
            var grouping = Querydata.GroupBy(pi => DateTime.Parse(pi.报警时间.Trim()).Date).Select(group => new StoreInfo
            {
                StoreID = group.Key,
                List = group.ToList()
            }).ToList();
            //获取后30天的日期
            string[] Days = new string[30];
            for (int i = 0; i < Days.Length; i++)
                Days[i] = DateTime.Now.AddDays(Convert.ToInt16($"-{i}")).ToString(); //当前时间减去30天
            //计算每天处理异常的总时间
            List<Tuple<int, string>> Histogramdata = new List<Tuple<int, string>>();
            TimeSpan dateTime = new TimeSpan();
            int quantity = 0;
            foreach (var i in Days)
            {
                dateTime = new TimeSpan();
                quantity = 0;
                var group = grouping.Where(pi => pi.StoreID.ToString("D") == DateTime.Parse(i.Trim()).ToString("D")).Select(pi => pi).FirstOrDefault();
                if (group != null)
                {
                    var grouptime = group.List.Where(pi => DateTime.Parse(pi.报警时间.Trim()).ToString("D") == DateTime.Parse(i.Trim()).ToString("D")).Select(P => new { DatetimeName = DateTime.Parse(P.处理完成时间.Trim()) - DateTime.Parse(P.报警时间.Trim()) }).ToList();
                    //求和时间
                    grouptime.ForEach(s =>
                    {
                        dateTime += s.DatetimeName;
                    });
                    quantity = grouptime.Count;
                }
                Histogramdata.Add(new Tuple<int, string>(quantity, dateTime.ToString("T")));
            }
            return Histogramdata;
        }
    }
    [Serializable]
    class Nightshift
    {
        public bool nightshift { get; set; }
        public IGrouping<bool,HourOutput> NightshiftTabel { get; set; }
    }
    public class StoreInfo
    {
        public DateTime StoreID { get; set; }
        public List<Alarmhistories> List { get; set; }

    }
    public class StoreInfoErr
    {
        public string ErrID { get; set; }
        public IGrouping<string, Alarmhistories> List { get; set; }
    }
}