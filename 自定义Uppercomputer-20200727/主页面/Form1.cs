using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.主页面;
using System.Threading;
using 自定义Uppercomputer_20200727.手动控制页面;
using 自定义Uppercomputer_20200727.控制主页面;
namespace 自定义Uppercomputer_20200727
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void Home_Shown(object sender, EventArgs e)
        {
            _ = new Homepag_class(new Home());
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;
            timer.Tick += ((object sende1r, EventArgs e1) =>
              {
                  Thread.Sleep(2000);
                  Form3 form3 = new Form3();
                  form3.Show();
                  this.Hide();
                  timer.Stop();
              });
            timer.Start();
        }
    }
}
