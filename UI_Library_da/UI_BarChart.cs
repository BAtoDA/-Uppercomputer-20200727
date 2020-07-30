using Sunny.UI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_Library_da
{
    /// <summary>
    /// <引用第三方开源控件重构>
    /// <柱形图>
    ///  * SunnyUI 开源控件库、工具类库、扩展类库、多页面开发框架。
    /// </summary>
    public class UI_BarChart : Sunny.UI.UIChart
    {
        private bool NeedDraw;

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            CalcData(BarOption);
        }

        protected override void CalcData(UIOption option)
        {
            Bars.Clear();
            NeedDraw = false;
            UIBarOption o = (UIBarOption)option;
            if (o == null || o.Series == null || o.SeriesCount == 0) return;

            DrawOrigin = new Point(BarOption.Grid.Left, Height - BarOption.Grid.Bottom);
            DrawSize = new Size(Width - BarOption.Grid.Left - BarOption.Grid.Right,
                Height - BarOption.Grid.Top - BarOption.Grid.Bottom);

            if (DrawSize.Width <= 0 || DrawSize.Height <= 0) return;
            if (o.XAxis.Data.Count == 0) return;

            NeedDraw = true;
            DrawBarWidth = DrawSize.Width * 1.0f / o.XAxis.Data.Count;

            double min = double.MaxValue;
            double max = double.MinValue;
            foreach (var series in o.Series)
            {
                min = Math.Min(min, series.Data.Min());
                max = Math.Max(max, series.Data.Max());
            }

            if (min > 0 && max > 0 && !o.YAxis.Scale)
            {
                min = 0;
            }

            if (min < 0 && max < 0 && !o.YAxis.Scale)
            {
                max = 0;
            }

            if (!o.YAxis.MaxAuto) max = o.YAxis.Max;
            if (!o.YAxis.MinAuto) min = o.YAxis.Min;

            if ((max - min).IsZero())
            {
                max = 100;
                min = 0;
            }

            UIChartHelper.CalcDegreeScale(min, max, o.YAxis.SplitNumber,
                out int start, out int end, out double interval);

            YAxisStart = start;
            YAxisEnd = end;
            YAxisInterval = interval;

            float x1 = DrawBarWidth / ((o.SeriesCount * 2) + o.SeriesCount + 1);
            float x2 = x1 * 2;

            for (int i = 0; i < o.SeriesCount; i++)
            {
                float barX = DrawOrigin.X;
                var series = o.Series[i];
                Bars.TryAdd(i, new List<BarInfo>());

                for (int j = 0; j < series.Data.Count; j++)
                {
                    Color color = ChartStyle.GetColor(i);
                    if (series.Colors.Count > 0 && j >= 0 && j < series.Colors.Count)
                        color = series.Colors[j];

                    if (YAxisStart >= 0)
                    {
                        float h = Math.Abs((float)(DrawSize.Height * (series.Data[j] - start * interval) / ((end - start) * interval)));

                        Bars[i].Add(new BarInfo()
                        {
                            Rect = new RectangleF(
                                barX + x1 * (i + 1) + x2 * i,
                                DrawOrigin.Y - h,
                                x2, h),
                            Color = color
                        });
                    }
                    else if (YAxisEnd <= 0)
                    {
                        float h = Math.Abs((float)(DrawSize.Height * (end * interval - series.Data[j]) / ((end - start) * interval)));
                        Bars[i].Add(new BarInfo()
                        {
                            Rect = new RectangleF(
                                barX + x1 * (i + 1) + x2 * i,
                                BarOption.Grid.Top + 1,
                                x2, h - 1),
                            Color = color
                        });
                    }
                    else
                    {
                        float lowH = 0;
                        float highH = 0;
                        float DrawBarHeight = DrawSize.Height * 1.0f / (YAxisEnd - YAxisStart);
                        float lowV = 0;
                        float highV = 0;
                        for (int k = YAxisStart; k <= YAxisEnd; k++)
                        {
                            if (k < 0) lowH += DrawBarHeight;
                            if (k > 0) highH += DrawBarHeight;
                            if (k < 0) lowV += (float)YAxisInterval;
                            if (k > 0) highV += (float)YAxisInterval;
                        }

                        lowH.ConsoleWriteLine();
                        highH.ConsoleWriteLine();

                        if (series.Data[j] >= 0)
                        {
                            float h = Math.Abs((float)(highH * series.Data[j] / highV));
                            Bars[i].Add(new BarInfo()
                            {
                                Rect = new RectangleF(
                                    barX + x1 * (i + 1) + x2 * i,
                                    DrawOrigin.Y - lowH - h,
                                    x2, h),
                                Color = color
                            });
                        }
                        else
                        {
                            float h = Math.Abs((float)(lowH * series.Data[j] / lowV));
                            Bars[i].Add(new BarInfo()
                            {
                                Rect = new RectangleF(
                                    barX + x1 * (i + 1) + x2 * i,
                                    DrawOrigin.Y - lowH + 1,
                                    x2, h - 1),
                                Color = color
                            });
                        }
                    }

                    barX += DrawBarWidth;
                }
            }

            if (BarOption.ToolTip != null)
            {
                for (int i = 0; i < BarOption.XAxis.Data.Count; i++)
                {
                    string str = BarOption.XAxis.Data[i];
                    foreach (var series in BarOption.Series)
                    {
                        str += '\n';
                        str += series.Name + " : " + series.Data[i].ToString(BarOption.ToolTip.ValueFormat);
                    }

                    Bars[0][i].Tips = str;
                }
            }
        }

        private int selectIndex = -1;
        private Point DrawOrigin;
        private Size DrawSize;
        private float DrawBarWidth;
        private int YAxisStart;
        private int YAxisEnd;
        private double YAxisInterval;
        private readonly ConcurrentDictionary<int, List<BarInfo>> Bars = new ConcurrentDictionary<int, List<BarInfo>>();

        [DefaultValue(-1), Browsable(false)]
        private int SelectIndex
        {
            get => selectIndex;
            set
            {
                if (BarOption.ToolTip != null && selectIndex != value)
                {
                    selectIndex = value;
                    Invalidate();
                }

                if (selectIndex < 0) tip.Visible = false;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            try
            {
                if (BarOption.ToolTip == null) return;
                if (e.Location.X > BarOption.Grid.Left && e.Location.X < Width - BarOption.Grid.Right
                                                       && e.Location.Y > BarOption.Grid.Top &&
                                                       e.Location.Y < Height - BarOption.Grid.Bottom)
                {
                    SelectIndex = (int)((e.Location.X - BarOption.Grid.Left) / DrawBarWidth);
                }
                else
                {
                    SelectIndex = -1;
                }

                if (SelectIndex >= 0 && Bars.Count > 0)
                {
                    if (tip.Text != Bars[0][selectIndex].Tips)
                    {
                        tip.Text = Bars[0][selectIndex].Tips;
                        tip.Size = new Size((int)Bars[0][selectIndex].Size.Width + 4, (int)Bars[0][selectIndex].Size.Height + 4);
                    }

                    int x = e.Location.X + 15;
                    int y = e.Location.Y + 20;
                    if (e.Location.X + 15 + tip.Width > Width - BarOption.Grid.Right)
                        x = e.Location.X - tip.Width - 2;
                    if (e.Location.Y + 20 + tip.Height > Height - BarOption.Grid.Bottom)
                        y = e.Location.Y - tip.Height - 2;

                    tip.Left = x;
                    tip.Top = y;
                    if (!tip.Visible) tip.Visible = Bars[0][selectIndex].Tips.IsValid();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        [Browsable(false)]
        private UIBarOption BarOption
        {
            get
            {
                UIOption option = Option ?? EmptyOption;
                return (UIBarOption)option;
            }
        }
        //未添加设置属性--需要后期添加
        //添加设置需要的属性
        public string Control_Name { get; set; }//控件名称
        public string Statement_Name { get; set; }//报表名称
        public int[] Data_Bar1 { get; set; }//柱形图1数据
        public int[] Data_Bar2 { get; set; }//柱形图2数据
        public string[] XAxis_Name { get; set; }//X轴名称
        private List<string> Day = new List<string>();//获取计算机周
        public UIBarOption option;
        public UI_BarChart()//构造函数
        {
            Control_Name = "UppercomputerUI";//默认控件名称
            Statement_Name = "UppercomputerChart";//默认报表名称
            this.Data_Bar1 = new int[] { 30, 5, 2, 4, 3 };//默认柱形图1数据
            this.Data_Bar2 = new int[] { 30, 1, 4, 3, 4 };//默认柱形图2数据
            Day.Clear();//清空泛型表
            foreach (DayOfWeek suit in Enum.GetValues(typeof(DayOfWeek)))
            {
                Day.Add(suit.ToString());//添加表
            }            
            XAxis_Name = Day.ToArray();//默认名
        }
        static int Dname = 0;
        protected override void CreateEmptyOption()
        {
            if (emptyOption != null) return;
            if (Dname < 1)
            {
                this.Data_Bar1 = new int[] { 10, 5, 2, 4, 3 };//默认柱形图1数据
                this.Data_Bar2 = new int[] { 20, 1, 4, 3, 4 };//默认柱形图2数据
                Day.Clear();//清空泛型表
                foreach (DayOfWeek suit in Enum.GetValues(typeof(DayOfWeek)))
                {
                    Day.Add(suit.ToString());//添加表
                }
                XAxis_Name = Day.ToArray();//默认名
                Dname = 2;
            }
            option = new UIBarOption();
            option.Title = new UITitle();
            option.Title.Text = Control_Name?? "UppercomputerUI";//控件名称
            option.Title.SubText = Statement_Name?? "UppercomputerChart";//报表名称

            //设置Legend
            option.Legend = new UILegend();//添加比较个数
            option.Legend.Orient = UIOrient.Horizontal;
            option.Legend.Top = UITopAlignment.Top;
            option.Legend.Left = UILeftAlignment.Left;
            option.Legend.AddData("Bar1");//报表柱形图1
            option.Legend.AddData("Bar2");//报表柱形图2

            var series = new UIBarSeries();//实例化报表柱形图1-相关数据
            series.Name = "Bar1";//名称
            foreach(int i in this.Data_Bar1) series.AddData(i);//柱形图数据
            option.Series.Add(series);

            series = new UIBarSeries();
            series.Name = "Bar2";
            foreach (int i in this.Data_Bar2) series.AddData(i);//柱形图数据
            option.Series.Add(series);

            // foreach(string i in XAxis_Name) option.XAxis.Data.Add(i.Trim());//添加默认名
            option.XAxis.Data.Add("Mon");
            option.XAxis.Data.Add("Tue");
            option.XAxis.Data.Add("Wed");
            option.XAxis.Data.Add("Thu");
            option.XAxis.Data.Add("Fri");

            option.ToolTip = new UIBarToolTip();
            option.ToolTip.AxisPointer.Type = UIAxisPointerType.Shadow;

            emptyOption = option;
        }

        protected override void DrawOption(Graphics g)
        {
            if (BarOption == null) return;
            if (!NeedDraw) return;

            if (BarOption.ToolTip != null && BarOption.ToolTip.AxisPointer.Type == UIAxisPointerType.Shadow) DrawToolTip(g);
            DrawAxis(g);
            DrawTitle(g, BarOption.Title);
            DrawSeries(g, BarOption.Series);
            if (BarOption.ToolTip != null && BarOption.ToolTip.AxisPointer.Type == UIAxisPointerType.Line) DrawToolTip(g);
            DrawLegend(g, BarOption.Legend);
            DrawAxisScales(g);
        }

        private void DrawToolTip(Graphics g)
        {
            if (selectIndex < 0) return;
            if (BarOption.ToolTip.AxisPointer.Type == UIAxisPointerType.Line)
            {
                float x = DrawOrigin.X + SelectIndex * DrawBarWidth + DrawBarWidth / 2.0f;
                g.DrawLine(ChartStyle.ToolTipShadowColor, x, DrawOrigin.Y, x, BarOption.Grid.Top);
            }

            if (BarOption.ToolTip.AxisPointer.Type == UIAxisPointerType.Shadow)
            {
                float x = DrawOrigin.X + SelectIndex * DrawBarWidth;
                g.FillRectangle(ChartStyle.ToolTipShadowColor, x, BarOption.Grid.Top, DrawBarWidth, Height - BarOption.Grid.Top - BarOption.Grid.Bottom);
            }
        }

        private void DrawAxis(Graphics g)
        {
            if (YAxisStart >= 0) g.DrawLine(ChartStyle.ForeColor, DrawOrigin, new Point(DrawOrigin.X + DrawSize.Width, DrawOrigin.Y));
            if (YAxisEnd <= 0) g.DrawLine(ChartStyle.ForeColor, new Point(DrawOrigin.X, BarOption.Grid.Top), new Point(DrawOrigin.X + DrawSize.Width, BarOption.Grid.Top));

            g.DrawLine(ChartStyle.ForeColor, DrawOrigin, new Point(DrawOrigin.X, DrawOrigin.Y - DrawSize.Height));

            if (BarOption.XAxis.AxisTick.Show)
            {
                float start;

                if (BarOption.XAxis.AxisTick.AlignWithLabel)
                {
                    start = DrawOrigin.X + DrawBarWidth / 2.0f;
                    for (int i = 0; i < BarOption.XAxis.Data.Count; i++)
                    {
                        g.DrawLine(ChartStyle.ForeColor, start, DrawOrigin.Y, start, DrawOrigin.Y + BarOption.XAxis.AxisTick.Length);
                        start += DrawBarWidth;
                    }
                }
                else
                {
                    bool haveZero = false;
                    for (int i = YAxisStart; i <= YAxisEnd; i++)
                    {
                        if (i == 0)
                        {
                            haveZero = true;
                            break;
                        }
                    }

                    if (!haveZero)
                    {
                        start = DrawOrigin.X;
                        for (int i = 0; i <= BarOption.XAxis.Data.Count; i++)
                        {
                            g.DrawLine(ChartStyle.ForeColor, start, DrawOrigin.Y, start, DrawOrigin.Y + BarOption.XAxis.AxisTick.Length);
                            start += DrawBarWidth;
                        }
                    }
                }
            }

            if (BarOption.XAxis.AxisLabel.Show)
            {
                float start = DrawOrigin.X + DrawBarWidth / 2.0f;
                foreach (var data in BarOption.XAxis.Data)
                {
                    SizeF sf = g.MeasureString(data, SubFont);
                    g.DrawString(data, SubFont, ChartStyle.ForeColor, start - sf.Width / 2.0f, DrawOrigin.Y + BarOption.XAxis.AxisTick.Length);
                    start += DrawBarWidth;
                }

                SizeF sfname = g.MeasureString(BarOption.XAxis.Name, SubFont);
                g.DrawString(BarOption.XAxis.Name, SubFont, ChartStyle.ForeColor, DrawOrigin.X + (DrawSize.Width - sfname.Width) / 2.0f, DrawOrigin.Y + BarOption.XAxis.AxisTick.Length + sfname.Height);
            }

            if (BarOption.YAxis.AxisTick.Show)
            {
                float start = DrawOrigin.Y;
                float DrawBarHeight = DrawSize.Height * 1.0f / (YAxisEnd - YAxisStart);
                for (int i = YAxisStart; i <= YAxisEnd; i++)
                {
                    g.DrawLine(ChartStyle.ForeColor, DrawOrigin.X, start, DrawOrigin.X - BarOption.YAxis.AxisTick.Length, start);

                    if (i != 0)
                    {
                        using (Pen pn = new Pen(ChartStyle.ForeColor))
                        {
                            pn.DashStyle = DashStyle.Dash;
                            pn.DashPattern = new float[] { 3, 3 };
                            g.DrawLine(pn, DrawOrigin.X, start, Width - BarOption.Grid.Right, start);
                        }
                    }
                    else
                    {
                        g.DrawLine(ChartStyle.ForeColor, DrawOrigin.X, start, Width - BarOption.Grid.Right, start);

                        float lineStart = DrawOrigin.X;
                        for (int j = 0; j <= BarOption.XAxis.Data.Count; j++)
                        {
                            g.DrawLine(ChartStyle.ForeColor, lineStart, start, lineStart, start + BarOption.XAxis.AxisTick.Length);
                            lineStart += DrawBarWidth;
                        }
                    }

                    start -= DrawBarHeight;
                }
            }

            if (BarOption.YAxis.AxisLabel.Show)
            {
                float start = DrawOrigin.Y;
                float DrawBarHeight = DrawSize.Height * 1.0f / (YAxisEnd - YAxisStart);
                int idx = 0;
                float wmax = 0;
                for (int i = YAxisStart; i <= YAxisEnd; i++)
                {
                    string label = BarOption.YAxis.AxisLabel.GetLabel(i * YAxisInterval, idx);
                    SizeF sf = g.MeasureString(label, SubFont);
                    wmax = Math.Max(wmax, sf.Width);
                    g.DrawString(label, SubFont, ChartStyle.ForeColor, DrawOrigin.X - BarOption.YAxis.AxisTick.Length - sf.Width, start - sf.Height / 2.0f);
                    start -= DrawBarHeight;
                }

                SizeF sfname = g.MeasureString(BarOption.YAxis.Name, SubFont);
                int x = (int)(DrawOrigin.X - BarOption.YAxis.AxisTick.Length - wmax - sfname.Height);
                int y = (int)(BarOption.Grid.Top + (DrawSize.Height - sfname.Width) / 2);
                g.DrawString(BarOption.YAxis.Name, SubFont, ChartStyle.ForeColor, new Point(x, y),
                    new StringFormat() { Alignment = StringAlignment.Center }, 270);
            }
        }

        private void DrawAxisScales(Graphics g)
        {
            foreach (var line in BarOption.YAxisScaleLines)
            {
                double ymin = YAxisStart * YAxisInterval;
                double ymax = YAxisEnd * YAxisInterval;
                float pos = (float)((line.Value - ymin) * (Height - BarOption.Grid.Top - BarOption.Grid.Bottom) / (ymax - ymin));
                pos = (Height - BarOption.Grid.Bottom - pos);
                using (Pen pn = new Pen(line.Color, line.Size))
                {
                    g.DrawLine(pn, DrawOrigin.X, pos, Width - BarOption.Grid.Right, pos);
                }

                SizeF sf = g.MeasureString(line.Name, SubFont);

                if (line.Left == UILeftAlignment.Left)
                    g.DrawString(line.Name, SubFont, line.Color, DrawOrigin.X + 4, pos - 2 - sf.Height);
                if (line.Left == UILeftAlignment.Center)
                    g.DrawString(line.Name, SubFont, line.Color, DrawOrigin.X + (Width - BarOption.Grid.Left - BarOption.Grid.Right - sf.Width) / 2, pos - 2 - sf.Height);
                if (line.Left == UILeftAlignment.Right)
                    g.DrawString(line.Name, SubFont, line.Color, Width - sf.Width - 4, pos - 2 - sf.Height);
            }
        }

        private void DrawSeries(Graphics g, List<UIBarSeries> series)
        {
            if (series == null || series.Count == 0) return;

            for (int i = 0; i < Bars.Count; i++)
            {
                var bars = Bars[i];
                foreach (var info in bars)
                {
                    g.FillRectangle(info.Color, info.Rect);
                }
            }

            for (int i = 0; i < BarOption.XAxis.Data.Count; i++)
            {
                Bars[0][i].Size = g.MeasureString(Bars[0][i].Tips, SubFont);
            }
        }

        internal class BarInfo
        {
            public RectangleF Rect { get; set; }

            public string Tips { get; set; }

            public SizeF Size { get; set; }

            public Color Color { get; set; }
        }

    }
}
