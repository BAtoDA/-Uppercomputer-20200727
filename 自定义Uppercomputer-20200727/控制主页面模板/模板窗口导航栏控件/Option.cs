using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义Uppercomputer_20200727.控制主页面模板.模板窗口导航栏控件
{
    [ToolboxItem(false)]
    [Browsable(false)]
    public partial class Option : UserControl
    {
        /// <summary>
        /// 方格显示文字
        /// </summary>
        public string LabelText
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;             
            }
        }
        public Option()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.AutoSize = false;
            String DrawText = this.Text;
            this.uiLabel1.Height = (int)e.Graphics.MeasureString(DrawText, this.uiLabel1.Font, DrawText.Length, new StringFormat(StringFormatFlags.DirectionVertical)).Height;
            e.Graphics.DrawString(DrawText, this.uiLabel1.Font, new SolidBrush(Color.White), new PointF((this.Size.Width / 2) - 13, 10), new StringFormat(StringFormatFlags.DirectionVertical));
            this.uiLine1.Location = new Point(0, (this.uiLabel1.Height) + 90);
            this.Height = (this.Size.Width / 2) + this.uiLabel1.Height > this.Size.Height - 5 ? this.uiLabel1.Height + 10 : this.Size.Height;

            base.OnPaint(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            //鼠标进入控件上方时--UI控件变色
            this.BackColor = Color.FromArgb(76, 76, 76);
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            //鼠标移出控件时变回原来颜色
            this.BackColor = Color.FromArgb(63, 92, 136);
            base.OnMouseLeave(e);
        }
    }
}
