using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using Sunny.UI;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.EF实体模型.EFtoSQL操作类重写;

namespace 自定义Uppercomputer_20200727.异常界面.报警历史
{
    public partial class HistoryErr : CCWin.Skin_DevExpress
    {
        public HistoryErr()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初次打开窗口--加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void HistoryErr_Load(object sender, EventArgs e)
        {
            //显示UI过度
            UIWaitFormService.ShowWaitForm("开始加载UI...");
            await Task.Run(() =>
            {
                //从数据获取数据
                using (UppercomputerEntities2 db = new UppercomputerEntities2())
                {
                    this.UIShowText("正在从SQL数据库获取数据");
                    var data = db.Alarmhistory.ToList();
                    var query = (from q in data where DateTime.Parse(q.报警时间.Trim()).ToString("D") == DateTime.Now.ToString("D") select q).ToList();
                    this.UIShowText("正在分析数据");
                    //填充当天报警次数
                    this.uiLabel2.Text = query.Count.ToString();
                    //填充7天警告次数
                    var query1 = (from q in data where (DateTime.Parse(DateTime.Now.ToString("F")) - DateTime.Parse(q.报警时间.Trim())).Days >= 0 && (DateTime.Parse(DateTime.Now.ToString("F")) - DateTime.Parse(q.报警时间.Trim())).Days <= 7 select q).ToList();
                    this.uiLabel3.Text = query1.Count.ToString();
                    //查询月度警告次数
                    var Monthly = (from q in data where (DateTime.Parse(DateTime.Now.ToString("Y")) == DateTime.Parse(DateTime.Parse(q.报警时间.Trim()).ToString("Y"))) select q).ToList();
                    //填充月底报警次数
                    this.uiLabel5.Text = Monthly.Count.ToString();
                    //填充报警历史
                    this.BeginInvoke((EventHandler)delegate
                    {
                        this.uiDataGridView1.DataSource = data;
                        alarmhistories = data;
                    //填充报警历史的查询项
                    this.uiComboBox1.Items.Clear();
                        this.uiComboBox2.Items.Clear();
                        this.uiComboBox3.Items.Clear();
                        data.ForEach(s =>
                        {
                            this.uiComboBox1.Items.Add(s.报警时间.Trim());
                            this.uiComboBox2.Items.Add(s.处理完成时间.Trim());
                            this.uiComboBox3.Items.Add(s.设备.Trim());

                        });
                        this.uiComboBox1.Items.Add("全部");
                        this.uiComboBox2.Items.Add("全部");
                        this.uiComboBox3.Items.Add("全部");
                        this.uiComboBox1.Text = "全部";
                        this.uiComboBox2.Text = "全部";
                        this.uiComboBox3.Text = "全部";
                    //填充报警注册内容
                    var Gridviwe2 = db.Event_message.ToList();
                        Gridviwe2.ForEach(s =>
                    {
                        s.位触发条件 = s.位触发条件.Trim();
                        s.报警内容 = s.报警内容.Trim();
                        s.字触发条件 = s.字触发条件.Trim();
                        s.字触发条件_具体 = s.字触发条件_具体.Trim();
                        s.设备 = s.设备.Trim();
                        s.设备_具体地址 = s.设备_具体地址.Trim();
                        s.设备_地址 = s.设备_地址.Trim();
                    });
                        this.uiDataGridView2.DataSource = Gridviwe2;
                    });
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
                    //填充7天警告分析图形
                    this.BeginInvoke((EventHandler)delegate
                    {
                        Histogram(Days, Histogramdata);
                    });

                    //填充警告处理用时
                    this.uiLabel16.Text = Histogramdata[0].Item2;//当天用时
                   //处理7天用时
                    TimeSpan dateTim = MonthlyErr(query1, query1.Count);
                    this.uiLabel14.Text = $"{(24 * dateTim.Days) + dateTim.Hours}:{dateTim.Minutes}:{dateTim.Seconds}";
                    //填充月度处理用时
                    dateTim = new TimeSpan();
                    MonthlyErr(Monthly).ForEach(s =>
                    {
                        dateTim += TimeSpan.Parse(s.Item2.Trim());
                    });
                    this.uiLabel12.Text = $"{(24 * dateTim.Days) + dateTim.Hours}:{dateTim.Minutes}:{dateTim.Seconds}";
                    //填充设备警告分析
                    //查找重复最多的数据--意味着报警最多的
                    EquipmentErr(Monthly);
                }
            });
            //启用定时刷新
            timer1.Enabled = true;
            timer1.Start();
            //关闭显示UI窗口
            UIWaitFormService.HideWaitForm();
        }
        public void UIShowText(string Value) => UIWaitFormService.SetDescription(Value);

        /// <summary>
        /// 定时刷新--加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoryErrTiming()
        {
            //从数据获取数据
            using (UppercomputerEntities2 db = new UppercomputerEntities2())
            {
                var data = db.Alarmhistory.ToList();
                var query = (from q in data where DateTime.Parse(q.报警时间.Trim()).ToString("D") == DateTime.Now.ToString("D") select q).ToList();
                //填充当天报警次数
                this.uiLabel2.Text = query.Count.ToString();
                //填充7天警告次数
                var query1 = (from q in data where (DateTime.Parse(DateTime.Now.ToString("F")) - DateTime.Parse(q.报警时间.Trim())).Days >= 0 && (DateTime.Parse(DateTime.Now.ToString("F")) - DateTime.Parse(q.报警时间.Trim())).Days <= 7 select q).ToList();
                this.uiLabel3.Text = query1.Count.ToString();
                //查询月度警告次数
                var Monthly = (from q in data where (DateTime.Parse(DateTime.Now.ToString("Y")) == DateTime.Parse(DateTime.Parse(q.报警时间.Trim()).ToString("Y"))) select q).ToList();
                //填充月底报警次数
                this.uiLabel5.Text = Monthly.Count.ToString();
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
                //填充7天警告分析图形
                this.BeginInvoke((EventHandler)delegate
                {
                    Histogram(Days, Histogramdata);
                });
                //填充警告处理用时
                this.uiLabel16.Text = Histogramdata[0].Item2;//当天用时
                //处理7天用时
                TimeSpan dateTim = MonthlyErr(query1, query1.Count);
                this.uiLabel14.Text = $"{(24 * dateTim.Days) + dateTim.Hours}:{dateTim.Minutes}:{dateTim.Seconds}";
                //填充月度处理用时
                dateTim = new TimeSpan();
                MonthlyErr(Monthly).ForEach(s =>
                {
                    dateTim += TimeSpan.Parse(s.Item2.Trim());
                });
                this.uiLabel12.Text = $"{(24 * dateTim.Days) + dateTim.Hours}:{dateTim.Minutes}:{dateTim.Seconds}";
                //填充设备警告分析
                //查找重复最多的数据--意味着报警最多的
                EquipmentErr(Monthly);
            }
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
        /// <summary>
        /// 分析设备报警最多的数据
        /// </summary>
        private void EquipmentErr(List<Alarmhistories> Querydata)
        {
            var res = (from n in Querydata
                       group n by n.报警内容 into g
                       orderby g.Count() descending
                       select g).Select(P => new StoreInfoErr { ErrID=P.Key, List=P }).ToList();
            var data=Querydata.GroupBy(p=>p.报警内容).OrderBy(x=>x.Key).Select(P => new StoreInfoErr { ErrID = P.Key, List = P }).ToList();//该语句同等于上面
            //划分查询结果重新生成表
            BindingList<ShowErr> showErrs = new BindingList<ShowErr>();
            if(data.Count<10)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    var ErrData = data[i].List.First();
                    var dateTim = MonthlyErr(data[i].List.Select(pi => pi).ToList(), data[i].List.Count());
                    var Errtime = $"{(24 * dateTim.Days) + dateTim.Hours}:{dateTim.Minutes}:{dateTim.Seconds}";
                    showErrs.Add(new ShowErr() { 报警内容 = ErrData.报警内容.Trim(), 设备 = ErrData.设备.Trim(), 地址 = ErrData.设备_地址.Trim() + ErrData.设备_具体地址.Trim(), 用时 = Errtime, 次数 = data[i].List.Count() });
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    var ErrData = data[i].List.First();
                    var dateTim = MonthlyErr(data[i].List.Select(pi => pi).ToList(), data[i].List.Count());
                    var Errtime = $"{(24 * dateTim.Days) + dateTim.Hours}:{dateTim.Minutes}:{dateTim.Seconds}";
                    showErrs.Add(new ShowErr() {  报警内容 = ErrData.报警内容.Trim(), 设备 = ErrData.设备.Trim(), 地址 = ErrData.设备_地址.Trim() + ErrData.设备_具体地址.Trim(), 用时 = Errtime, 次数 = data[i].List.Count() });
                }
            }
            this.BeginInvoke((EventHandler)delegate
            {
                uiDataGridView3.DataSource = showErrs.OrderByDescending(x => x.次数).Select(pi => pi).ToList();
                uiDataGridView3.Columns[0].Width = 300;
                uiDataGridView3.Columns[2].Width = 80;
                uiDataGridView3.Columns[3].Width = 50;
                uiDataGridView3.Columns[4].Width = 70;
            });
        }
        /// <summary>
        /// 计算的报警处理用时
        /// </summary>
        private TimeSpan MonthlyErr(List<Alarmhistories> Querydata,int index)
        {
            TimeSpan time = new TimeSpan();
            Querydata.ForEach(P =>
            {
                time += DateTime.Parse(P.处理完成时间.Trim()) - DateTime.Parse(P.报警时间.Trim());
            });
            return time;
        }
        private void Histogram(string[] Days, List<Tuple<int, string>> Histogramdata )
        {
            UIBarOption option = new UIBarOption();
            option.Title = new UITitle();
            option.Title.Text = "7天警告分析";
            option.Title.SubText = "";

            //设置Legend
            option.Legend = new UILegend();
            option.Legend.Orient = UIOrient.Horizontal;
            option.Legend.Top = UITopAlignment.Top;
            option.Legend.Left = UILeftAlignment.Left;
            option.Legend.AddData("警告总时长");
            option.Legend.AddData("发生次数");

            var series = new UIBarSeries();
            series.Name = "Bar1";
            //填充当前报警次数
            foreach (var i in Histogramdata)
                series.AddData(i.Item1);
            option.Series.Add(series);

            series = new UIBarSeries();
            series.Name = "Bar2";
            //填充当前报警时长
            foreach (var i in Histogramdata)
              series.AddData(DateTime.Parse(i.Item2).Hour==0? DateTime.Parse(i.Item2).Minute: DateTime.Parse(i.Item2).Hour);
         
            option.Series.Add(series);
            //填充7天日期
            foreach (var i in Days)
                option.XAxis.Data.Add(DateTime.Parse(i).ToString("M"));
           
            option.ToolTip.Visible = true;
            option.YAxis.Scale = true;

            option.XAxis.Name = "发生日期";
            option.YAxis.Name = "时间/次数";

            this.uiBarChart1.SetOption(option);
        }
        /// <summary>
        /// 定时刷新 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (this.Handle != null)
                    HistoryErrTiming();
            });

        }
        /// <summary>
        /// 用于保存历史报警源数据
        /// </summary>
        List<Alarmhistories> alarmhistories = new List<Alarmhistories>();
        /// <summary>
        /// 用户点击了刷新数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton1_Click(object sender, EventArgs e)
        {
            using(UppercomputerEntities2 db=new UppercomputerEntities2())
            {
                alarmhistories = db.Alarmhistory.Where(pi => true).OrderBy(p=>p.报警时间.Trim()).ToList();
                this.uiDataGridView1.DataSource = alarmhistories;
            }
        }
        /// <summary>
        /// 查询报警历史
        /// </summary>
        public void QueryErr(object sender, EventArgs e)
        {
            if (this.uiDataGridView1.DataSource != null&& alarmhistories!=null)
                this.uiDataGridView1.DataSource= alarmhistories.Where(pi => pi.报警时间 == (uiComboBox1.Text == "全部" ? pi.报警时间 : uiComboBox1.Text) && pi.处理完成时间 == (uiComboBox2.Text == "全部" ? pi.处理完成时间 : uiComboBox2.Text) && pi.设备 == (this.uiComboBox3.Text == "全部" ? pi.设备 : this.uiComboBox3.Text)).OrderBy(x=>x.报警时间.Trim()).ToList();
        }
    }
    public class StoreInfo
    {
        public DateTime StoreID { get; set; }
        public List<Alarmhistories> List { get; set; }

    }
    public class StoreInfoErr
    {
        public string ErrID { get; set; }
        public IGrouping<string,Alarmhistories> List { get; set; }
    }
    [Serializable]
    public class ShowErr
    {
        public string 报警内容 { get; set; }
        public string 设备 { get; set; }
        public string 地址 { get; set; }
        public int 次数 { get; set; }
        public string 用时 { get; set; }
    }
}
