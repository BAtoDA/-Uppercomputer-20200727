using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义Uppercomputer_20200727.控件重做.复制粘贴接口
{
    /// <summary>
    /// 用于复制粘贴消息提示控件
    /// </summary>
    public partial class CopyControl : UserControl
    {
        Form Control;
        public CopyControl(string ControlName,Form control)
        {
            InitializeComponent();
            //添加消息内容
            this.uiLabel1.Text = $"{ControlName}";
            this.Control = control;
            if (this.uiLabel1.Font.Size + this.uiLabel1.Size.Width > this.Size.Width)
            {
                this.Size = new Size((int)this.uiLabel1.Font.Size + this.uiLabel1.Size.Width + 40, this.Size.Height);
                this.Width = (int)this.uiLabel1.Font.Size + this.uiLabel1.Size.Width + 40;
            }
        }

        private void CopyControl_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Control.Controls.Remove(this);
        }
    }
}
