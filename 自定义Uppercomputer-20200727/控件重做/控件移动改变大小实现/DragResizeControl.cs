using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using 自定义Uppercomputer_20200727;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.控件重做.控件移动改变大小实现;
using 自定义Uppercomputer_20200727.控件重做;

namespace DragResizeControlWindowsDrawDemo
{
    /// <summary>
    /// 实现拖拽控件 改变控件大小
    /// </summary>
    public class DragResizeControl
    {
        #region Field
        private const int Band = 5;
        private const int MinWidth = 10;
        private const int MinHeight = 10;
        private static EnumMousePointPosition m_MousePointPosition;
        private static Point p, p1;
        #endregion

        #region Inner Object
        private enum EnumMousePointPosition
        {
            MouseSizeNone = 0, //'无
            MouseSizeRight = 1, //'拉伸右边框
            MouseSizeLeft = 2, //'拉伸左边框
            MouseSizeBottom = 3, //'拉伸下边框
            MouseSizeTop = 4, //'拉伸上边框
            MouseSizeTopLeft = 5, //'拉伸左上角
            MouseSizeTopRight = 6, //'拉伸右上角
            MouseSizeBottomLeft = 7, //'拉伸左下角
            MouseSizeBottomRight = 8, //'拉伸右下角
            MouseDrag = 9   // '鼠标拖动
        }
        #endregion

        #region Constructor
        public DragResizeControl()
        {
            // Nothing to do.
        }
        #endregion

        #region Public Method
        public static void RegisterControl(Control control)
        {
            if (control != null)
            {
                control.MouseDown += new MouseEventHandler(control_MouseDown);
                control.MouseLeave += new EventHandler(control_MouseLeave);
                control.MouseMove += new MouseEventHandler(control_MouseMove);
                control.MouseUp += new MouseEventHandler(control_MouseUP);
            }
        }
        /// <summary>
        /// 获取需要出现的窗口名称
        /// </summary>
        private static string Name;
        private static Graphics graphics;
        public static void UnRegisterControl(Control control)
        {
            if (control != null)
            {
                control.MouseDown -= new MouseEventHandler(control_MouseDown);
                control.MouseLeave -= new EventHandler(control_MouseLeave);
                control.MouseMove -= new MouseEventHandler(control_MouseMove);
                control.MouseUp -= new MouseEventHandler(control_MouseUP);
            }
        }
        #endregion
        /// <summary>
        /// 需要绘制窗口的画布
        /// </summary>
        private static Canvas UserControl;
        /// <summary>
        /// 跟随显示坐标标签
        /// </summary>
        private static Label LabelControl;
        private static void control_MouseDown(object sender, MouseEventArgs e)
        {
            p.X = e.X;
            p.Y = e.Y;
            p1.X = e.X;
            p1.Y = e.Y;
            //测试代码
            if (Form2.edit_mode != true) return;//返回方法
            Control control = sender as Control;//强转控件类基
            FormCollection formCollection = Application.OpenForms;//获取活动的窗口
            for (int i = 0; i < formCollection.Count; i++)
            {
                if (parameter_indexes.Button_from_name(control.Parent.ToString())== formCollection[i].Name)
                {
                    UserControl = new Canvas();
                    UserControl.Size = new Size()
                    {
                        Width = formCollection[i].Size.Width,
                        Height = formCollection[i].Size.Height
                    };
                    //添加画布
                    formCollection[i].SetBounds(formCollection[i].Location.X, formCollection[i].Location.Y, formCollection[i].Size.Width, formCollection[i].Size.Height);
                    formCollection[i].Controls.Add(UserControl);
                    //添加坐标显示
                    LabelControl = new Label();
                    formCollection[i].Controls.Add(LabelControl);

                    UserControl.SendToBack();
                    foreach (Control ix in formCollection[i].Controls)
                    {
                        if (ix is GroupBox_reform)
                            ix.SendToBack();
                    }
                    control.BringToFront();
                    LabelControl.BringToFront();
                    graphics = UserControl.CreateGraphics();//获取需要绘制窗口的GDI+
                }
            }
        }
        private static void control_MouseUP(object sender, MouseEventArgs e)
        {
            //测试代码
            if (Form2.edit_mode != true) return;//返回方法
            Control control = sender as Control;//强转控件类基
            FormCollection formCollection = Application.OpenForms;//获取活动的窗口
            for (int i = 0; i < formCollection.Count; i++)
            {
                if (parameter_indexes.Button_from_name(control.Parent.ToString()) == formCollection[i].Name)
                {
                    formCollection[i].Controls.Remove(UserControl);
                    formCollection[i].Controls.Remove(LabelControl);
                    UserControl.Dispose();
                    if (control is GroupBox_reform)
                        control.SendToBack();
                }
            }
        }
        private static void control_MouseLeave(object sender, EventArgs e)
        {
            m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
            Control control = sender as Control;
            control.Cursor = Cursors.Arrow;
            //当鼠标移出可见范围
            if ((Form2.edit_mode != true)|| (control is GroupBox_reform)) return;//返回方法
            using (Graphics graphics = control.CreateGraphics())
            {
                using (Pen pen = new Pen(control.BackColor, 1))
                {
                    pen.Color = control is LedBulb_reform ? Color.FromName("AppWorkspace") : control.BackColor;
                    Brush brush = pen.Brush;//创建形状
                    graphics.DrawRectangle(pen, 0, 0, control.Size.Width-1 , control.Size.Height-1);//绘制边框
                }
            }
        }
        private static void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (Form2.edit_mode != true) return;//返回方法
            Control lCtrl = (sender as Control);
            if (e.Button != MouseButtons.Left)
            {
                //当鼠标出现控件上方 控件四边出现边框
                if (!(lCtrl is GroupBox_reform))//四边框控件不再绘制
                {
                    using (Graphics graphics = lCtrl.CreateGraphics())
                    {
                        using (Pen pen = new Pen(Color.Red, 1))
                        {
                            Brush brush = pen.Brush;//创建形状
                            graphics.DrawRectangle(pen, 0, 0, lCtrl.Size.Width - 1, lCtrl.Size.Height - 1);//绘制边框
                        }
                    }
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                ///绘制直线
                graphics.Clear(Color.FromName("AppWorkspace"));
                lCtrl.BeginInvoke((EventHandler)delegate
                {
                    using (Pen pen = new Pen(Color.Red, 3))
                    {
                        //绘制X轴坐标
                        Point point1 = new Point(lCtrl.Location.X - 1000, lCtrl.Top - 1);
                        Point point2 = new Point(lCtrl.Location.X + 1000, lCtrl.Top - 1);
                        graphics.DrawLine(pen, point1, point2);
                        //绘制Y轴坐标
                        Point point3 = new Point(lCtrl.Left - 1, lCtrl.Location.Y - 1000);
                        Point point4 = new Point(lCtrl.Left - 1, lCtrl.Location.Y + 1000);
                        graphics.DrawLine(pen, point3, point4);
                    }
                    //显示坐标标签控件跟随
                    LabelControl.Location = new Point()
                    {
                        X = lCtrl.Location.X+3,
                        Y = lCtrl.Top-25
                    };
                    LabelControl.Text = $"X：{lCtrl.Location.X} Y：{lCtrl.Location.Y}";
                    lCtrl.Refresh();
                    LabelControl.Refresh();
                });
                switch (m_MousePointPosition)
                {
                    case EnumMousePointPosition.MouseDrag:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + e.Y - p.Y;
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;       
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width + (e.X - p1.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    default:
                        break;
                }
                if (lCtrl.Width < MinWidth) lCtrl.Width = MinWidth;
                if (lCtrl.Height < MinHeight) lCtrl.Height = MinHeight;
                //判断是否有该类型控件在同一XY轴上
                Control control = sender as Control;//强转控件类基
                FormCollection formCollection = Application.OpenForms;//获取活动的窗口
                for (int i = 0; i < formCollection.Count; i++)
                {
                    if (parameter_indexes.Button_from_name(control.Parent.ToString()) == formCollection[i].Name)
                    {
                        //获取同一类型控件
                        var trol = from Control pi in formCollection[i].Controls where pi.GetType() == sender.GetType() select pi;
                        foreach (var ix in trol)
                        {
                            int x = ix.Location.X - control.Location.X;//计算偏差
                            int y = ix.Location.Y - control.Location.Y;//计算偏差
                            if ((x > 0 & x < 20) || (x < -0 & x > -20))
                            {
                                control.Location = new Point() { X = ix.Location.X, Y = control.Location.Y };
                                return;
                            }
                            if ((y > 0 & y < 20) || (y < -0 & y > -20))
                            {
                                control.Location = new Point() { X = control.Location.X, Y = ix.Location.Y };
                                return;
                            }
                        }
                        //同时达到下边界时
                        if (lCtrl.Left < 15 && lCtrl.Top > formCollection[i].Size.Height - 35)
                        {
                            lCtrl.Left = 15;
                            lCtrl.Top = formCollection[i].Size.Height - 35;
                            return;
                        }
                        if (lCtrl.Left > formCollection[i].Size.Width - 80 && lCtrl.Top > formCollection[i].Size.Height - 30)
                        {
                            lCtrl.Left = formCollection[i].Size.Width - 90;
                            lCtrl.Top = formCollection[i].Size.Height - 35;
                            return;
                        }
                        //同时到达上边界时
                        if (lCtrl.Top < 80&& lCtrl.Left < 10)
                        {
                            lCtrl.Left = 15;
                            lCtrl.Top = 85;
                            return;
                        }
                        if (lCtrl.Top < 80 && lCtrl.Left >formCollection[i].Size.Width - 80)
                        {
                            lCtrl.Left = formCollection[i].Size.Width - 90;
                            lCtrl.Top = 85;
                            return;
                        }
                        //不允许控件超越边界
                        if (lCtrl.Left < 10)
                        {
                            lCtrl.Left = 15;
                            return;
                        }
                        if (lCtrl.Top < 80)
                        {
                            lCtrl.Top = 85;
                            return;
                        }
                        if (lCtrl.Left > formCollection[i].Size.Width-80)
                        {
                            lCtrl.Left = formCollection[i].Size.Width-90;
                            return;
                        }
                        if (lCtrl.Top > formCollection[i].Size.Height-30)
                        {
                            lCtrl.Top = formCollection[i].Size.Height -35;
                            return;
                        }
                    }
                }
            }
            else
            {
                m_MousePointPosition = MousePointPosition(lCtrl.Size, e);   //'判断光标的位置状态
                Control control = sender as Control;
                switch (m_MousePointPosition)  //'改变光标
                {
                    case EnumMousePointPosition.MouseSizeNone:
                        control.Cursor = Cursors.Arrow;
                        //'箭头
                        break;
                    case EnumMousePointPosition.MouseDrag:
                        control.Cursor = Cursors.SizeAll;     //'四方向
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        control.Cursor = Cursors.SizeNS;      //'南北
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        control.Cursor = Cursors.SizeNS;      //'南北
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        control.Cursor = Cursors.SizeWE;      //'东西
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        control.Cursor = Cursors.SizeWE;      //'东西
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        control.Cursor = Cursors.SizeNESW;    //'东北到南西
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        control.Cursor = Cursors.SizeNWSE;    //'东南到西北
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        control.Cursor = Cursors.SizeNWSE;    //'东南到西北
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        control.Cursor = Cursors.SizeNESW;    //'东北到南西
                        break;
                    default:
                        break;
                }
            }
        }
        private static void From_graphics()
        {

          
        }
        private static EnumMousePointPosition MousePointPosition(Size size, System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.X >= -1 * Band) | (e.X <= size.Width) | (e.Y >= -1 * Band) | (e.Y <= size.Height))
            {
                if (e.X < Band)
                {
                    if (e.Y < Band)
                    {
                        return EnumMousePointPosition.MouseSizeTopLeft;
                    }
                    else
                    {
                        if (e.Y > -1 * Band + size.Height)
                        {
                            return EnumMousePointPosition.MouseSizeBottomLeft;
                        }
                        else
                        {
                            return EnumMousePointPosition.MouseSizeLeft;
                        }
                    }
                }
                else
                {
                    if (e.X > -1 * Band + size.Width)
                    {
                        if (e.Y < Band)
                        {
                            return EnumMousePointPosition.MouseSizeTopRight;
                        }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            {
                                return EnumMousePointPosition.MouseSizeBottomRight;
                            }
                            else
                            {
                                return EnumMousePointPosition.MouseSizeRight;
                            }
                        }
                    }
                    else
                    {
                        if (e.Y < Band)
                        {
                            return EnumMousePointPosition.MouseSizeTop;
                        }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            {
                                return EnumMousePointPosition.MouseSizeBottom;
                            }
                            else
                            {
                                return EnumMousePointPosition.MouseDrag;
                            }
                        }
                    }
                }
            }
            else
            {
                return EnumMousePointPosition.MouseSizeNone;
            }
        }
    }
}
