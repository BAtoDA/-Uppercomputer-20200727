using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI_Library_da
{
    /// <summary>
    /// 继承Chart类实现折线图波形图
    /// </summary>
    public class oscillogram_Chart:Chart
    {
        /// <summary>
        /// 折线图还是波形图--默认显示是折线图
        /// </summary>
        public bool waveform_ON { get; set; } = false;//折线图还是波形图--默认显示是折线图
        /// <summary>
        /// 默认图形名称
        /// </summary>
        public string oscillogram_Chart_Name { get; set; } = "PLC数据监控";//默认图形名称
        /// <summary>
        /// 默认最小值
        /// </summary>
        public int Chart_Minimum { get; set; } = 0;//默认最小值
        /// <summary>
        /// 默认最大值
        /// </summary>
        public int Chart_Maximum { get; set; } = 100;//默认最大值
        /// <summary>
        /// 默认刷新时间
        /// </summary>
        public int Chart_Interval { get; set; } = 5;//默认刷新时间
        /// <summary>
        /// 表示正在监控的数据名称
        /// </summary>
        public string oscillogram_Data_Name { get; set; } = "D10";//表示正在监控的数据名称
        /// <summary>
        /// 表示要显示的数据值
        /// </summary>
        public int oscillogram_Data { get; set; } = 0;//表示要显示的数据值
        /// <summary>
        /// 图形绘制线颜色
        /// </summary>
        public Color color { get; set; } = Color.Red;//图形绘制线颜色
        /// <summary>
        /// 设置默认字体样式
        /// </summary>
        public Font font { get; set; } = new Font("微软雅黑", 15, FontStyle.Bold);//设置默认字体样式
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
        private int num = 5;//每次删除增加几个点
        /// <summary>
        /// 设置默认颜色为透明
        /// </summary>
        public Color background_colo { get; set; } = Color.White;//默认背景颜色透明
        /// <summary>
        /// 构造函数
        /// </summary>
        public oscillogram_Chart()
        {
        }
        /// <summary>
        /// 重写事件UI控件绘制事
        /// </summary>
        /// <param name="levent"></param>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            //InitChart_load();
        }
        /// <summary>
        /// 初始化图表
        /// </summary>
        public void InitChart_load()
        {
            //定义图表区域
            this.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            chartArea1.BackColor = background_colo;//设置背景颜色
            this.ChartAreas.Add(chartArea1);
            //定义存储和显示点的容器
            this.Series.Clear();
            Series series1 = new Series(oscillogram_Data_Name);
            series1.ChartArea = "C1";
            this.Series.Add(series1);
            //设置图表显示样式
            this.ChartAreas[0].AxisY.Minimum = Chart_Minimum;
            this.ChartAreas[0].AxisY.Maximum = Chart_Maximum;
            this.ChartAreas[0].AxisX.Interval = Chart_Interval;
            this.ChartAreas[0].BackColor = background_colo;//设置背景颜色
            //X Y轴颜色
            this.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            this.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //设置标题
            this.Titles.Clear();
            this.Titles.Add("S01");
            this.Titles[0].Text = oscillogram_Chart_Name + "显示";
            this.Titles[0].ForeColor = color;
            this.Titles[0].Font = font;
            this.Titles[0].BackColor = background_colo;//设置背景颜色
            //设置图表显示样式
            this.Series[0].Color = color;
            this.Series[0].BorderColor = background_colo;//设置背景颜色
            if (waveform_ON!=true)
            {
                this.Titles[0].Text = string.Format(oscillogram_Chart_Name + "{0} 显示", "折线图");
                this.Series[0].ChartType = SeriesChartType.Line;
            }
            if (waveform_ON)
            {
                this.Titles[0].Text = string.Format(oscillogram_Chart_Name+"{0} 显示", "波形图");
                this.Series[0].ChartType = SeriesChartType.Spline;
            }
            this.Series[0].Points.Clear();
        }
        /// <summary>
        /// 更新队列中的值
        /// </summary>
        private void UpdateQueueValue()
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
                    dataQueue.Enqueue(oscillogram_Data);
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
                    curValue = curValue+ 10;//+ oscillogram_Data
                }
            }
        }
        /// <summary>
        /// 刷新控件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void oscillogram_Chart_Tick()
        {
            curValue = oscillogram_Data;
            UpdateQueueValue();//填充要刷新的数据
            this.Series[0].Points.Clear();//清空数据
            for (int i = 0; i < dataQueue.Count; i++)//填充数据
            {
                this.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
            }
        }


    }
}
