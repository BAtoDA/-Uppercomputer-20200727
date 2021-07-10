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
                            DataSQL.异常时长 = MonthlyErr(query).ToString();

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
                            scheduletaiyaki.异常时长 = MonthlyErr(query).ToString();
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
                        }
                        else
                        {
                            //当前小时没有数据
                            HourOutput hourOutput = new HourOutput()
                            {
                                ID = 0,
                                生产数量 = Convert.ToInt32((PLC)Enum.Parse(typeof(PLC), parameterWeb.设备.Trim()) == PLC.HMI ? Hmidata : data.Content),
                                生产时间 = DateTime.Now.ToString("f")
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
        private TimeSpan MonthlyErr(List<Alarmhistories> Querydata)
        {
            TimeSpan time = new TimeSpan();
            Querydata.ForEach(P =>
            {
                time += DateTime.Parse(P.处理完成时间.Trim()) - DateTime.Parse(P.报警时间.Trim());
            });
            return time;
        }
    }
}