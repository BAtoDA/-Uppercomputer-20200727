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
    public partial class OptionPalette : UserControl
    {
        /// <summary>
        /// 指示导航栏项点击时间
        /// </summary>
        public event EventHandler ItemClick;
        /// <summary>
        /// 导航栏缩小时显示的方块名称与个数
        /// </summary>
        public List<string> OptionName { get; set; } = new List<string>() { "测试1" };
        public OptionPalette()
        {
            InitializeComponent();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            this.uiPanel1.Size = Size;
            LoadOption();
            base.OnSizeChanged(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            this.uiPanel1.Size = Size;
            LoadOption();
            base.OnLoad(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.uiPanel1.Size = Size;
            LoadOption();
            base.OnPaint(e);
        }
        private void LoadOption()
        {
            OptionName = Windowclass.FromnamTexe.ToList();
            foreach (Control i in this.uiPanel1.Controls)
                i.Click -= Item_Click;
            this.uiPanel1.Controls.Clear();
            for (int i = 0; i < OptionName.Count; i++)
            {
                Option option = new Option() { LabelText = OptionName[i] };
                option.Size = new Size(30, i == 0 ? 65 : 65);
                option.Location = new Point(0, i == 0 ? 0 : ((65 * i)));
                option.Click += Item_Click;
                this.uiPanel1.Controls.Add(option);
            }

        }
        /// <summary>
        /// 触发事件
        /// </summary>
        protected virtual void Item_Click(object send,EventArgs e)
        {
            if (ItemClick != null)
                ItemClick.Invoke(send, e);
        }
    }
}
