using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot通讯控制
{
    public partial class RIControl : UserControl
    {
        public RIControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 控件重新绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RIControl_Paint(object sender, PaintEventArgs e)
        {
            this.Size = this.uiLight1.Size;
            this.uiLabel1.BackColor = this.uiLight1.State == Sunny.UI.UILightState.Off ? this.uiLight1.OffColor : this.uiLight1.OnColor;
        }
    }
}
