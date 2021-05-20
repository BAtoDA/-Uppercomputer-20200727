using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_Library_da;
using 自定义Uppercomputer_20200727.EF实体模型;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 继承UI_BarChart--进行柱形图绘制与重写
    /// 此类不能在窗口设计器中使用-如果需要使用请拖拽父类
    /// </summary>
    class BarChart_reform : UI_Library_da.UI_BarChart
    {
        public BarChart_reform()
        {          
        }
        public void CreateEmptn()
        {
            this.Cursor = Cursors.Hand;//改变鼠标状态
            this.Data_Bar1 = new int[] { 100, 5, 2, 4, 3 };//默认柱形图1数据
            this.Data_Bar2 = new int[] { 200, 1, 4, 3, 4 };//默认柱形图2数据
            this.option.Title.Text = Control_Name ?? "UppercomputerUI";//控件名称
            this.option.Title.SubText = Statement_Name ?? "UppercomputerChart";//报表名称

            //设置Legend
            this.option.Legend = new UILegend();//添加比较个数
            this.option.Legend.Orient = UIOrient.Horizontal;
            this.option.Legend.Top = UITopAlignment.Top;
            this.option.Legend.Left = UILeftAlignment.Left;
            this.option.Legend.AddData("Bar1");//报表柱形图1
            this.option.Legend.AddData("Bar2");//报表柱形图2

            this.option.Series.Clear();
            var series = new UIBarSeries();//实例化报表柱形图1-相关数据
            series.Name = "Bar1";//名称
            foreach (int i in this.Data_Bar1) series.AddData(i);//柱形图数据
            this.option.Series.Add(series);

            series = new UIBarSeries();
            series.Name = "Bar2";
            foreach (int i in this.Data_Bar2) series.AddData(i);//柱形图数据
            this.option.Series.Add(series);

            // foreach(string i in XAxis_Name) option.XAxis.Data.Add(i.Trim());//添加默认名
            this.option.XAxis.Clear();
            this.option.XAxis.Data.Add("Mon");
            this.option.XAxis.Data.Add("Tue");
            this.option.XAxis.Data.Add("Wed");
            this.option.XAxis.Data.Add("Thu");
            this.option.XAxis.Data.Add("Fri");

            this.option.ToolTip = new UIBarToolTip();
            this.option.ToolTip.AxisPointer.Type = UIAxisPointerType.Shadow;
            emptyOption = this.option;

        }
        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            base.OnClick(e);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
