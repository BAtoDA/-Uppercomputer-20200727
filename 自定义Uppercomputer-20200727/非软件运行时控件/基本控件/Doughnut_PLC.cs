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
    //  时间：2021/2/21 9:33:48 
    //  文件名：Doughnut_PLC 
    //  版本：V1.0.1  
    //  说明： 实现从PLC出读取自定寄存器进行圆形图显示
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现从PLC出读取自定寄存器进行圆形图显示
    /// </summary>
    [ToolboxItem(true)]
    [Browsable(true)]
    [Description("实现从PLC出读取自定寄存器进行圆形图显示 -不再公共运行时")]
    public class Doughnut_PLC : Chart, TextBox_base, DataGridViewPLC_base, Doughnut_Base
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
        private bool plc_Enable = true;

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
        [Description("默认Chart图标名称"), Category("PLC-控件参数")]
        public string doughnut_Chart_Name { get; set; } = "Chart1";
        [Description("默认图标显示的名称"), Category("PLC-控件参数")]
        public string doughnut_Chart_Text { get; set; } = "Chart_Text";
        [Description("默认显示的文本字体"), Category("PLC-控件参数")]
        public Font doughnut_Chart_Font { get; set; } = new Font("宋体", 9);
        [Description("设置字体颜色"), Category("PLC-控件参数")]
        public Color color { get; set; } = Color.White;
        [Description("设置默认颜色为透明"), Category("PLC-控件参数")]
        public Color background_colo { get; set; } = Color.Transparent;

        /// <summary>
        /// PLC通讯对象
        /// </summary>
        DataGridView_PLC pLC;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public Doughnut_PLC()
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
            lock(this)
            {
                int indx = 0;
                for(int i=0;i < this.DataGridView_Name.Length;i++)
                {
                    if (this.DataGridView_Name[i] == null)
                        break;
                    indx += 1;
                }
                List<string> Data = pLC.plc(this, this,indx);
                if (Data.Count != indx||Data.Count==0)
                    return;
                doughnut_Chart_Load(Data);
            }
        }
        /// <summary>
        /// 初次加载UI加载方法
        /// </summary>
        public void doughnut_Chart_Load(List<string> doughnut_Chart_Data_INT)
        {
            //清空chart图表
            this.ChartAreas.Clear(); //图表区
            this.Titles.Clear(); //图表标题
            this.Series.Clear(); //图表序列
            this.Legends.Clear(); //图表图例

            //新建chart图表要素
            this.ChartAreas.Add(new ChartArea(doughnut_Chart_Name));
            this.ChartAreas[doughnut_Chart_Name].AxisX.IsMarginVisible = false;
            this.ChartAreas[doughnut_Chart_Name].Area3DStyle.Enable3D = false;
            this.Titles.Add(doughnut_Chart_Text);
            this.Titles[0].Font = doughnut_Chart_Font;
            this.Titles[0].ForeColor = color;
            this.Series.Add("data");
            this.Series["data"].ChartType = SeriesChartType.Doughnut; //这一行与上个不同
            this.Series["data"]["PieLabelStyle"] = "Outside";
            this.Series["data"]["PieLineColor"] = "Black";
            this.Legends.Add(new Legend("legend"));
            this.Palette = ChartColorPalette.BrightPastel;
            //控件背景--透明
            this.BackColor = background_colo;
            this.ChartAreas[doughnut_Chart_Name].BackColor = Color.Transparent;
            this.Titles[0].BackColor = Color.Transparent;
            //为chart图表赋值
            //点1
            for (int i = 0; i < 10; i++)
            {
                if (this.DataGridView_Name[i] == null || i > doughnut_Chart_Data_INT.Count)
                    break;
                int idxA = this.Series["data"].Points.AddY(Convert.ToInt32(doughnut_Chart_Data_INT[i]));
                DataPoint pointA = this.Series["data"].Points[idxA];
                pointA.Label = this.DataGridView_Name[i];
                pointA.LegendText = "#LABEL(#VAL) #PERCENT{P2}";
                pointA.LabelForeColor = color;//字体颜色
            }
        }
        
    }
}
