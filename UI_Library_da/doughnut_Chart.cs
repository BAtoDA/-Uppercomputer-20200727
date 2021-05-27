using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI_Library_da
{
    /// <summary>
    /// 继承Chart实现圆环图形绘制
    /// </summary>
    [ToolboxItem(false)]
    public class doughnut_Chart : Chart
    {
        /// <summary>
        /// 默认Chart图标名称
        /// </summary>
        public string doughnut_Chart_Name { get; set; } = "chartArea";//默认Chart图标名称
        /// <summary>
        /// 默认图标显示的名称
        /// </summary>
        public string doughnut_Chart_Text { get; set; } = "PLC数据监控圆形图";//默认图标显示的名称
        /// <summary>
        /// 默认显示的文本字体
        /// </summary>
        public Font doughnut_Chart_Font { get; set; } = new Font("宋体", 15, FontStyle.Regular);//默认显示的文本字体
        /// <summary>
        /// 默认泛型表数据
        /// </summary>
        public List<String> doughnut_Chart_Data { get; set; } = new List<String>() { "寄存器1","寄存器2", "寄存器3","寄存器4", "寄存器5" };//默认泛型表数据
        /// <summary>
        /// 默认泛型表数据
        /// </summary>
        public List<int> doughnut_Chart_Data_INT { get; set; } = new List<int>() { 10,20,30,40,50};//默认泛型表数据
        /// <summary>
        /// 默认加载个数
        /// </summary>
        public int Load_number { get; set; } = 5;//默认加载个数
        /// <summary>
        /// 设置字体颜色
        /// </summary>
        public Color color { get; set; } = Color.BlanchedAlmond;//默认字体颜色
        /// <summary>
        /// 设置默认颜色为透明
        /// </summary>
        public Color background_colo { get; set; } = Color.Transparent;//默认背景颜色透明
        /// <summary>
        /// 构造函数
        /// </summary>
        public doughnut_Chart()
        {
           
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
        /// 初次加载UI加载方法
        /// </summary>
        public void doughnut_Chart_Load()
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
            this.Titles[0].BackColor= Color.Transparent;
            //为chart图表赋值
            //点1
            for (int i=0;i< Load_number; i++)
            {
                int idxA = this.Series["data"].Points.AddY(doughnut_Chart_Data_INT[i]);
                DataPoint pointA = this.Series["data"].Points[idxA];
                pointA.Label = doughnut_Chart_Data[i].Trim();
                pointA.LegendText = "#LABEL(#VAL) #PERCENT{P2}";
                pointA.LabelForeColor = color;//字体颜色
            }
        }
    }
    /// <summary>
    /// <本类用于处理圆形图名称与数据绑定类>
    /// </summary>
    public class doughnut_Chart_data
    {
        [NonSerialized]
        public string Name ;
        [NonSerialized]
        public int Data ;
    }
}
