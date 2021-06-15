using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PLC通讯规范接口;
using 自定义Uppercomputer_20200727.非软件运行时控件.PLC参数设置界面;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.按钮_TO_PLC方法;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.文本__TO__PLC方法;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.基本控件
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/22 11:17:35 
    //  文件名：Oscillogram_PLC 
    //  版本：V1.0.1  
    //  说明：实现从PLC出读取自定寄存器进行折线图显示
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现从PLC出读取自定寄存器进行折线图显示
    /// </summary>
    [ToolboxItem(true)]
    [Browsable(true)]
    [Description("实现从PLC出读取自定寄存器进行折线图显示 -不再公共运行时")]
    public class Oscillogram_PLC : Chart, TextBox_base
    {
        #region 实现接口参数
        public event EventHandler Modification;
        [Description("选择PLC类型\r\n默认三菱PLC"), Category("PLC类型")]
        [DefaultValue(typeof(PLC), "Mitsubishi")]
        public PLC Plc
        {
            get => pLC_valu;
            set
            {
                if (plc_Enable)
                {
                    this.Modification += new EventHandler(Modifications_Eeve);
                    this.Modification(Convert.ToInt32(pLC_valu), new EventArgs());
                    this.Modification -= new EventHandler(Modifications_Eeve);
                    return;
                }
                pLC_valu = value;
            }
        }
        private PLC pLC_valu;
        [Description("是否启用PLC功能"), Category("PLC类型")]
        public bool PLC_Enable
        {
            get => plc_Enable;
            set => plc_Enable = value;
        }
        private bool plc_Enable = false;

        public void Modifications_Eeve(object send, EventArgs e)
        {
            TextboxDForm1 buttonBitForm = new TextboxDForm1(Convert.ToInt32(send), PLC_Contact, PLC_Address);
            buttonBitForm.ShowDialog();
            if (buttonBitForm.PLC_parameter.Length < 1) return;
            pLC_valu = buttonBitForm.pLC;
            PLC_Contact = buttonBitForm.PLC_parameter[1];
            plc_Address = buttonBitForm.PLC_parameter[2];
        }
        [Description("PLC读取触点"), Category("PLC类型")]
        public string PLC_Contact
        {
            get => plc_Contact;
            set
            {
                if (value == null || !TextBox_PLC.IsNull(value, Plc))
                    throw new Exception("参数设置错误");
                plc_Contact = value;
            }
        }
        private string plc_Contact = "D";
        [Description("PLC访问地址"), Category("PLC类型")]
        public string PLC_Address
        {
            get => plc_Address;
            set
            {
                if (Button_PLC.Address(this.Plc,value))
                    plc_Address = value;
            }
        }
        private string plc_Address = "0";
        [Description("设置访问PLC的类型 包含显示数据的类型"), Category("PLC-控件参数")]
        [DefaultValue(typeof(numerical_format), "Signed_16_Bit")]
        public numerical_format numerical { get; set; } = numerical_format.Signed_16_Bit;
        [Description("设置访问PLC小数点以上几位"), Category("PLC-控件参数")]
        [DefaultValue(typeof(int), "8")]
        public int Decimal_Above { get; set; } = 8;
        [Description("设置访问PLC小数点以下几位"), Category("PLC-控件参数")]
        [DefaultValue(typeof(int), "0")]
        public int Decimal_Below { get; set; } = 0;
        public string Control_Text { get; set; } = "00";
        /// <summary>
        /// 定时刷新 定时器
        /// </summary>
        [Description("文本刷新定时器"), Category("PLC-控件参数")]
        [DefaultValue(typeof(string), "PLC_time")]
        public System.Windows.Forms.Timer PLC_time { get; } = new System.Windows.Forms.Timer() { Enabled = true, Interval = 500 };
        [Description("默认Chart图标名称"), Category("PLC-控件参数")]
        public string Histogram_Chart_Name { get; set; } = "数据分析图";
        [Description("默认图标显示的名称"), Category("PLC-控件参数")]
        public string Histogram_Chart_Text { get; set; } = "数据表";
        [Description("默认显示的文本字体"), Category("PLC-控件参数")]
        public Font Histogram_Chart_Font { get; set; } = new Font("微软雅黑", 15, FontStyle.Bold);
        [Description("设置字体颜色"), Category("PLC-控件参数")]
        public Color Font_Color { get; set; } = Color.DarkCyan;
        [Description("设置默认颜色为透明"), Category("PLC-控件参数")]
        public Color Background_colo { get; set; } = Color.Transparent;
        [Description("折线图还是波形图--默认显示是折线图"), Category("PLC-控件参数")]
        /// <summary>
        /// 折线图还是波形图--默认显示是折线图
        /// </summary>
        public bool waveform_ON { get; set; } = false;//折线图还是波形图--默认显示是折线图
        [Description("默认最小值"), Category("PLC-控件参数")]
        /// <summary>
        /// 默认最小值
        /// </summary>
        public int Chart_Minimum { get; set; } = 0;//默认最小值
        [Description("默认最大值"), Category("PLC-控件参数")]
        /// <summary>
        /// 默认最大值
        /// </summary>
        public int Chart_Maximum { get; set; } = 100;//默认最大值
        [Description("默认刷新时间"), Category("PLC-控件参数")]
        /// <summary>
        /// 默认刷新时间
        /// </summary>
        public int Chart_Interval { get; set; } = 5;//默认刷新时间
        [Description("图形绘制线颜色"), Category("PLC-控件参数")]
        /// <summary>
        /// 图形绘制线颜色
        /// </summary>
        public Color color { get; set; } = Color.Red;//图形绘制线颜色
        /// <summary>
        /// 容量
        /// </summary>
        private Queue<double> dataQueue = new Queue<double>(100);//容量
        /// <summary>
        /// 值
        /// </summary>
        private int curValue = 0;//值
        /// <summary>
        /// 每次删除增加几个点
        /// </summary>
        private int num = 2;//每次删除增加几个点
        /// <summary>
        /// PLC通讯对象
        /// </summary>
        TextBox_PLC pLC;
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public Oscillogram_PLC()
        {
            pLC = new TextBox_PLC();
        }
        protected override void Dispose(bool disposing)//释放托管资源
        {
            base.Dispose(disposing);
            this.PLC_time.Dispose();
        }
        /// <summary>
        /// 重写事件UI控件绘制事
        /// </summary>
        /// <param name="levent"></param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            PLC_time.Start();
            PLC_time.Tick += new EventHandler(Time_tick);
            if (this.ChartAreas.Count > 0)
                return;
            InitChart_load();
        }
        /// <summary>
        /// 定时器到达事件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_tick(object send, EventArgs e)
        {
            if (!plc_Enable) return;//用户不开启PLC功能
            pLC.Refresh(this);
            oscillogram_Chart_Tick(Convert.ToInt32(this.Control_Text??"00"));
        }
        /// <summary>
        /// 初始化图表
        /// </summary>
        public void InitChart_load()
        {
            //定义图表区域
            this.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            chartArea1.BackColor = Background_colo;//设置背景颜色
            this.ChartAreas.Add(chartArea1);
            //定义存储和显示点的容器
            this.Series.Clear();
            Series series1 = new Series(Histogram_Chart_Name);
            series1.ChartArea = "C1";
            this.Series.Add(series1);
            //设置图表显示样式
            this.ChartAreas[0].AxisY.Minimum = Chart_Minimum;
            this.ChartAreas[0].AxisY.Maximum = Chart_Maximum;
            this.ChartAreas[0].AxisX.Interval = Chart_Interval;
            this.ChartAreas[0].BackColor = Background_colo;//设置背景颜色
            //X Y轴颜色
            this.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            this.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //设置标题
            this.Titles.Clear();
            this.Titles.Add("S01");
            this.Titles[0].Text = Histogram_Chart_Name + "显示";
            this.Titles[0].ForeColor = color;
            this.Titles[0].Font = Histogram_Chart_Font;
            this.Titles[0].BackColor = Background_colo;//设置背景颜色
            //设置图表显示样式
            this.Series[0].Color = color;
            this.Series[0].BorderColor = Background_colo;//设置背景颜色
            if (waveform_ON != true)
            {
                this.Titles[0].Text = string.Format(Histogram_Chart_Name + "{0} 显示", "折线图");
                this.Series[0].ChartType = SeriesChartType.Line;
            }
            if (waveform_ON)
            {
                this.Titles[0].Text = string.Format(Histogram_Chart_Name + "{0} 显示", "波形图");
                this.Series[0].ChartType = SeriesChartType.Spline;
            }
            this.Series[0].Points.Clear();
        }
        /// <summary>
        /// 更新队列中的值
        /// </summary>
        private void UpdateQueueValue(int Data)
        {

            if (dataQueue.Count > 100)
            {
                //先出列
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Dequeue();
                }
            }
            if (waveform_ON != true)
            {
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Enqueue(Data);
                }
            }
            if (waveform_ON)
            {
                for (int i = 0; i < num; i++)
                {
                    //对curValue只取[0,360]之间的值
                    curValue = curValue % 360;
                    //对得到的正玄值，放大50倍，并上移50
                    dataQueue.Enqueue((50 * Math.Sin(curValue * Math.PI / 180)) + 50);
                    curValue = curValue + 10;//+ oscillogram_Data
                }
            }
        }
        /// <summary>
        /// 刷新控件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void oscillogram_Chart_Tick(int Data)
        {
            curValue = Data;
            UpdateQueueValue(Data);//填充要刷新的数据
            this.Series[0].Points.Clear();//清空数据
            for (int i = 0; i < dataQueue.Count; i++)//填充数据
            {
                this.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
            }
        }

    }
}
