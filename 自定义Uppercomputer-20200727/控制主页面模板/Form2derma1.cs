using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.控制主页面模板.模板窗口导航栏控件;
using Sunny.UI;
namespace 自定义Uppercomputer_20200727.控制主页面模板
{
    public partial class Form2derma1 : CCWin.Skin_DevExpress
    {
        public Form2derma1()
        {
            InitializeComponent();
        }

        private void navigationBar1_NavigationitemClick(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void navigationBar1_OptionitemClick(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Option).LabelText);
        }
    }
}
