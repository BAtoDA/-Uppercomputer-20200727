using CCWin.SkinControl;
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
    /// 继承Chart图片--进行柱形图绘制
    /// </summary>
    [ToolboxItem(false)]
    public class histogram_Chart: Chart
    {
        /// <summary>
        /// 柱形图列名 默认名称
        /// </summary>
        public string[] x { get; set; } = default_Nmae;//柱形图列名 默认名称
        private static string[] default_Nmae = new string[] { "numerical_1", "comparison_1", "numerical_2", "comparison_2", "numerical_3", "comparison_3", "numerical_4", "comparison_4", "numerical_5", "comparison_5" };//默认列名称
        /// <summary>
        /// 这是柱形图高度-默认高度
        /// </summary>
        public double[] y { get; set; } = default_Data;//这是柱形图高度-默认高度
        private static double[] default_Data = new double[] { 50, 60, 40, 30, 50, 70, 60, 80, 90, 40 };//默认柱形图数据--高度
        /// <summary>
        /// 默认柱形图标题
        /// </summary>
        public string headline { get; set; } = "数据分析图";//默认柱形图标题
        /// <summary>
        /// 默认显示合格数量
        /// </summary>
        public string total { get; set; } = "102";//默认显示合格数量
        /// <summary>
        /// 默认不合格数量
        /// </summary>
        public string disqualification { get; set; } = "120";//默认不合格数量
        /// <summary>
        /// 设置显示柱形图默认颜色
        /// </summary>
        public Color colour { get; set; } = Color.FromName("DeepSkyBlue");//设置显示柱形图默认颜色
        /// <summary>
        /// 设置显示字体样式
        /// </summary>
        public Font default_Font { get; set; } = new Font("微软雅黑", 15, FontStyle.Bold);//设置默认字体样式
        /// <summary>
        /// 设置默认颜色为透明
        /// </summary>
        public Color background_colo { get; set; } = Color.Transparent;//默认背景颜色透明
        /// <summary>
        /// 默认加载数量
        /// </summary>
        public int Load_number { get; set; } = 10;//默认加载数量
        public histogram_Chart()//构造函数
        {
            
        }
        /// <summary>
        /// 重写事件UI控件绘制事
        /// </summary>
        /// <param name="levent"></param>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
        }
        /// <summary>
        /// 控件初次加载--方法--需要设置好相应的属性
        /// </summary>
        public void histogram_Chart_Load()
        {
            //标题
            this.Titles.Clear();
            this.InitializeLifetimeService();
            this.Titles.Add(headline ?? "数据分析图");//标题
            this.Titles[0].Text = "数据分析图";
            //小标题--1
            this.Titles[0].ForeColor = colour;
            this.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
            this.Titles[0].Alignment = ContentAlignment.TopCenter;
            this.Titles.Add("合格:" + total ?? "20");//合格总数量
            this.Titles[1].ForeColor = colour;
            this.Titles[1].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
            this.Titles[1].Alignment = ContentAlignment.TopRight;
            //小标题--2
            this.Titles.Add("不合格:" + disqualification ?? "10");//不合格数量
            this.Titles[2].ForeColor = colour;
            this.Titles[2].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
            this.Titles[2].Alignment = ContentAlignment.TopRight;
            //控件背景
            this.BackColor = background_colo;
            //图表区背景
            ChartArea chartArea = new ChartArea();
            this.ChartAreas.Add(chartArea);
            this.ChartAreas[0].BackColor = background_colo;
            this.ChartAreas[0].BorderColor = Color.White;
            //X轴标签间距
            this.ChartAreas[0].AxisX.Interval = 1;
            this.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
            this.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            this.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 14f, FontStyle.Regular);
            this.ChartAreas[0].AxisX.TitleForeColor = colour;

            //X坐标轴颜色
            this.ChartAreas[0].AxisX.LineColor = ColorTranslator.FromHtml("#2c4c6d"); ;
            this.ChartAreas[0].AxisX.LabelStyle.ForeColor = colour;
            this.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);

            //X轴网络线条
            this.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            this.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

            //Y坐标轴颜色
            this.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
            this.ChartAreas[0].AxisY.LabelStyle.ForeColor = colour;
            this.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
            //Y坐标轴标题
            this.ChartAreas[0].AxisY.Title = "数量(宗)";
            this.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            this.ChartAreas[0].AxisY.TitleForeColor = colour;
            this.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
            this.ChartAreas[0].AxisY.ToolTip = "数量(宗)";
            //Y轴网格线条
            this.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            this.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

            this.ChartAreas[0].AxisY2.LineColor = Color.Transparent;
            this.ChartAreas[0].BackGradientStyle = GradientStyle.TopBottom;
            Legend legend = new Legend("legend");
            legend.Title = "legendTitle";

            this.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series());
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
            this.Legends.Add(legend);
            this.Legends[0].Position.Auto = false;
            //遍历要填充的数据
            List<string> Data = new List<string>();//名称
            List<double> Data_1 = new List<double>();//数据
            for (int i = 0; i < Load_number; i++)
            {
                Data.Add(x[i]);
                Data_1.Add(y[i]);
            }
            //绑定数据
            this.Series[0].Points.DataBindXY(Data, Data_1);
            this.Series[0].Points[0].Color = Color.White;
            this.Series[0].Palette = ChartColorPalette.Bright;

        }
        /// <summary>
        /// 刷新控件数据
        /// </summary>
        public void histogram_Chart_refresh()
        {
            #region 刷新数据
            //标题
            this.Titles.Clear();
            this.InitializeLifetimeService();
            this.Titles.Add(headline ?? "数据分析图");//标题
            this.Titles[0].Text = "数据分析图";
            //小标题--1
            this.Titles[0].ForeColor = colour;
            this.Titles[0].Font = new Font("微软雅黑", 12f, FontStyle.Regular);
            this.Titles[0].Alignment = ContentAlignment.TopCenter;
            this.Titles.Add("合格:" + total ?? "20");//合格总数量
            this.Titles[1].ForeColor = colour;
            this.Titles[1].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
            this.Titles[1].Alignment = ContentAlignment.TopRight;
            //小标题--2
            this.Titles.Add("不合格:" + disqualification ?? "10");//不合格数量
            this.Titles[2].ForeColor = colour;
            this.Titles[2].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
            this.Titles[2].Alignment = ContentAlignment.TopRight;
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
            this.ChartAreas[0].AxisX.TitleForeColor = colour;

            //X坐标轴颜色
            this.ChartAreas[0].AxisX.LineColor = ColorTranslator.FromHtml("#2c4c6d"); ;
            this.ChartAreas[0].AxisX.LabelStyle.ForeColor = colour;
            this.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);

            //X轴网络线条
            this.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            this.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

            //Y坐标轴颜色
            this.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
            this.ChartAreas[0].AxisY.LabelStyle.ForeColor = colour;
            this.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
            //Y坐标轴标题
            this.ChartAreas[0].AxisY.Title = "数量(宗)";
            this.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            this.ChartAreas[0].AxisY.TitleForeColor = colour;
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
            //遍历要填充的数据
            List<string> Data = new List<string>();//名称
            List<double> Data_1 = new List<double>();//数据
            for (int i = 0; i < Load_number; i++)
            {
                Data.Add(x[i]);
                Data_1.Add(y[i]);
            }

            //绑定数据
            this.Series[0].Points.DataBindXY(Data, Data_1);
            this.Series[0].Points[0].Color = Color.White;
            this.Series[0].Palette = ChartColorPalette.Bright;
            #endregion
        }
    }
}
