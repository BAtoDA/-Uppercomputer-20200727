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
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.表格控件__TO__PLC;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.基本控件
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/22 8:38:29 
    //  文件名：Histogram_PLC 
    //  版本：V1.0.1  
    //  说明： 实现从PLC出读取自定寄存器进行柱形图显示
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现从PLC出读取自定寄存器进行柱形图显示
    /// </summary>
    [ToolboxItem(true)]
    [Browsable(true)]
    [Description("实现从PLC出读取自定寄存器进行柱形图显示 -不再公共运行时")]
    public class Histogram_PLC:Chart,TextBox_base, DataGridViewPLC_base, Histogram_base
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
        public numerical_format numerical { get; set; } = numerical_format.Signed_16_Bit;
        [DefaultValue(typeof(int), "8")]
        public int Decimal_Above { get; set; } = 8;
        [DefaultValue(typeof(int), "0")]
        public int Decimal_Below { get; set; } = 0;
        public string Control_Text { get => this.Text; set => this.Text = value; }
        /// <summary>
        /// 定时刷新 定时器
        /// </summary>
        [Description("文本刷新定时器"), Category("PLC-控件参数")]
        [DefaultValue(typeof(string), "PLC_time")]
        public System.Windows.Forms.Timer PLC_time { get; } = new System.Windows.Forms.Timer() { Enabled = true, Interval = 500 };
        [Description("读取PLC的地址--对应表格列"), Category("PLC-控件参数")]
        public string[] PLC_address
        {
            get => Plc_address;
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (Button_PLC.Address(this.Plc,value[i]))
                        Plc_address[i] = value[i];
                    else
                        Plc_address[i] = "00";
                }
            }
        }
        string[] Plc_address = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        [Description("表格列显示的名称--对应表格列"), Category("PLC-控件参数")]
        public string[] DataGridView_Name { get; set; } = new string[10];
        [Description("表格列读取PLC的类型--对应表格列"), Category("PLC-控件参数")]
        public numerical_format[] DataGridView_numerical { get; set; } = new numerical_format[10];
        public bool DataGridViewPLC_Time { get; set; } = false;
        public string doughnut_Chart_Name { get; set; } = "Chart1";
        public string doughnut_Chart_Text { get; set; } = "Chart_Text";
        public Font doughnut_Chart_Font { get; set; } = new Font("宋体", 9);
        public Color color { get; set; }
        public Color background_colo { get; set; }
        [Description("默认Chart图标名称"), Category("PLC-控件参数")]
        public string Histogram_Chart_Name { get; set; } = "数据分析图";
        [Description("默认图标显示的名称"), Category("PLC-控件参数")]
        public string Histogram_Chart_Text { get; set; } = "数据表";
        [Description("默认显示的文本字体"), Category("PLC-控件参数")]
        public Font Histogram_Chart_Font { get; set; } = new Font("微软雅黑", 12, FontStyle.Bold);
        [Description("设置字体颜色"), Category("PLC-控件参数")]
        public Color Font_Color { get; set; } = Color.DarkCyan;
        [Description("设置默认颜色为透明"), Category("PLC-控件参数")]
        public Color Background_colo { get; set; } = Color.Transparent;
        [Description("默认柱形图小标题名称"), Category("PLC-控件参数")]
        public string[] Headline { get; set; } = new string[10];
        [Description("默认柱形图小标题显示数据的地址"), Category("PLC-控件参数")]
        public string[] Total_address { get; set; } = new string[10];
        [Description("默认标题数据类型"), Category("PLC-控件参数")]
        public numerical_format[] Histogram_numerical { get; set; } = new numerical_format[10];


        /// <summary>
        /// PLC通讯对象
        /// </summary>
        DataGridView_PLC pLC;
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public Histogram_PLC()
        {
            pLC = new DataGridView_PLC();
            PLC_time.Start();
            PLC_time.Tick += new EventHandler(Time_tick);

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
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            //doughnut_Chart_Load();
        }
        /// <summary>
        /// 定时器到达事件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_tick(object send, EventArgs e)
        {
            if (!plc_Enable) return;//用户不开启PLC功能
            int indx = 0;
            for (int i = 0; i < this.DataGridView_Name.Length; i++)
            {
                if (this.DataGridView_Name[i] == null)
                    break;
                indx += 1;
            }
            List<string> Data = pLC.plc(this, (DataGridViewPLC_base)this, indx);
            if (Data.Count != indx || Data.Count == 0)
                return;
            int indx1 = 0;
            for (int i = 0; i < this.Headline.Length; i++)
            {
                if (this.Headline[i] == null)
                    break;
                indx1 += 1;
            }
            List<string> Data1 = pLC.plc(this, (Histogram_base)this, indx);
            if (Data1.Count != indx1 || Data1.Count == 0)
                return;
            histogram_Chart_refresh(Data, Data1);
        }
        /// <summary>
        /// 刷新控件数据
        /// </summary>
        public void histogram_Chart_refresh(List<string> AreasData,List<string> TitlesData)
        {
            #region 刷新数据
            //标题
            this.Titles.Clear();
            this.InitializeLifetimeService();
            this.Titles.Add(Histogram_Chart_Name ?? "数据分析图");//标题
            this.Titles[0].Text = Histogram_Chart_Name;
            this.Titles[0].ForeColor = Font_Color;
            this.Titles[0].Font = Histogram_Chart_Font;
            this.Titles[0].Alignment = ContentAlignment.TopCenter;
            //动态添加小标题
            for (int i = 0; i < TitlesData.Count; i++)
            {
                this.Titles.Add(Headline[i].Trim() + TitlesData[i] ?? "20"); ;
                //this.Titles[i].Text = Histogram_Chart_Text;
                this.Titles[i+1].ForeColor = Font_Color;
                this.Titles[i+1].Font = new Font("微软雅黑", 10, FontStyle.Bold);
                this.Titles[i+1].Alignment = ContentAlignment.TopRight;

            }
            //控件背景
            this.BackColor = background_colo;
            //图表区背景
            this.ChartAreas[0].BackColor = background_colo;
            this.ChartAreas[0].BorderColor = Color.White;
            //X轴标签间距
            this.ChartAreas[0].AxisX.Interval = 1;
            this.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
            this.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            this.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 14f, FontStyle.Regular);
            this.ChartAreas[0].AxisX.TitleForeColor = Font_Color;

            //X坐标轴颜色
            this.ChartAreas[0].AxisX.LineColor = ColorTranslator.FromHtml("#2c4c6d"); ;
            this.ChartAreas[0].AxisX.LabelStyle.ForeColor = Font_Color;
            this.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);

            //X轴网络线条
            this.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            this.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

            //Y坐标轴颜色
            this.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
            this.ChartAreas[0].AxisY.LabelStyle.ForeColor = Font_Color;
            this.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
            //Y坐标轴标题
            this.ChartAreas[0].AxisY.Title = "数量(宗)";
            this.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            this.ChartAreas[0].AxisY.TitleForeColor = Font_Color;
            this.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
            this.ChartAreas[0].AxisY.ToolTip = "数量(宗)";
            //Y轴网格线条
            this.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            this.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

            this.ChartAreas[0].AxisY2.LineColor = Color.Transparent;
            this.ChartAreas[0].BackGradientStyle = GradientStyle.TopBottom;
            Legend legend = new Legend("legend");
            legend.Title = "legendTitle";

            this.Series[0].XValueType = ChartValueType.String;  //设置X轴上的值类型
            this.Series[0].Label = "#VAL";                //设置显示X Y的值    
            this.Series[0].LabelForeColor = Color.Black;
            this.Series[0].ToolTip = "#VALX:#VAL";     //鼠标移动到对应点显示数值
            this.Series[0].ChartType = SeriesChartType.Column;    //图类型(折线)


            this.Series[0].Color = Color.Lime;
            this.Series[0].LegendText = legend.Name;
            this.Series[0].IsValueShownAsLabel = true;
            this.Series[0].LabelForeColor = Color.Black;
            this.Series[0].CustomProperties = "DrawingStyle = Cylinder";

            this.Legends[0].Position.Auto = false;
            //遍历要填充的数据
            List<string> Data = new List<string>();//名称
            List<double> Data_1 = new List<double>();//数据
            for (int i = 0; i < AreasData.Count; i++)
            {
                Data.Add(this.DataGridView_Name[i]);
                Data_1.Add(Convert.ToDouble(AreasData[i]));
            }
            //绑定数据
            this.Series[0].Points.DataBindXY(Data, Data_1);
            this.Series[0].Points[0].Color = Color.White;
            this.Series[0].Palette = ChartColorPalette.Bright;
            #endregion
        }
    }
}
