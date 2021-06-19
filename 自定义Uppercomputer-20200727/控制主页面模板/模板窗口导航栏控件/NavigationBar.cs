using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace 自定义Uppercomputer_20200727.控制主页面模板.模板窗口导航栏控件
{
    public partial class NavigationBar : UserControl
    {
        private Size before;
        /// <summary>
        /// 当用户点击Option触发该事件
        /// 传入子节点名称
        /// </summary>
        public event EventHandler OptionitemClick;
        /// <summary>
        /// 当用户点击Navigation触发该事件
        /// 传入子节点名称
        /// </summary>
        public event EventHandler NavigationitemClick;
        public NavigationBar()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            before = this.Size;
            //before.Height +=50;
            optionPalette1.Enabled = false;
            optionPalette1.Visible = false;
            optionPalette1.Size = new Size(76, this.Height-40);
            base.OnLoad(e);
        }
        protected override void OnResize(EventArgs e)
        {
            this.uiNavMenu1.Size = new Size(this.Size.Width, this.Size.Height - 30);
            base.OnResize(e);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            this.uiNavMenu1.Size = new Size(this.Size.Width, this.Size.Height - 30);
            base.OnSizeChanged(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.uiNavMenu1.Size = new Size(this.Size.Width, this.Size.Height - 30);
            base.OnPaint(e);
        }
        /// <summary>
        /// 按下是缩小导航栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //判断是否在缩小状态
            if(this.Size.Width<101)
            {
                //恢复之前大小
                this.Size = before;
                this.uiNavMenu1.Size = this.Size;
                this.uiNavMenu1.Enabled = true;
                this.uiNavMenu1.Visible =true;
                this.pictureBox1.Location = new Point(this.pictureBox1.Location.X + 14, this.pictureBox1.Location.Y);
                optionPalette1.Enabled = false;
                optionPalette1.Visible = false;
            }
            else
            {
                //进入缩小状态
                this.uiNavMenu1.Visible = false;
                this.uiNavMenu1.Enabled = false;
                this.Size = new Size(62, this.Size.Height);
                this.uiNavMenu1.Size = this.Size;
                this.pictureBox1.Location = new Point(this.pictureBox1.Location.X - 14, this.pictureBox1.Location.Y);
                optionPalette1.Enabled = true;
                optionPalette1.Visible = true;
            }
        }

        private void optionPalette1_ItemClick(object sender, EventArgs e)
        {
            if (OptionitemClick != null)
                OptionitemClick.Invoke(sender, e);
        }

        private void uiNavMenu1_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {

        }
    }
}
