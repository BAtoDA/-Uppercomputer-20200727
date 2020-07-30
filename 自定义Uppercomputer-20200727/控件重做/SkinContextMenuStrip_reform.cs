using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.修改参数界面;

namespace 自定义Uppercomputer_20200727.控件重做
{
    class SkinContextMenuStrip_reform:SkinContextMenuStrip
    {
        /// <本类主要重写右键菜单的属性-事件-等>
        public string SkinContextMenuStrip_Button_ID { get; set; }//定义ID
        public object all_purpose { get; set; }//定义通用类型
        public SkinContextMenuStrip_reform()//构造函数
        {
            /// <写入相应参数>
            ToolStripMenuItem toolStrip = new ToolStripMenuItem();
            toolStrip.Text = "修改参数";
            this.Items.Add(toolStrip);
            toolStrip.Click += toolStrip_Click_reform;//注册修改参数事件
        }
        /// <本方法重写右键点击菜单事件--触发相应操作>
        private void toolStrip_Click_reform(object sender, EventArgs e)
        {
            Modification_Button modification = new Modification_Button(SkinContextMenuStrip_Button_ID,this.all_purpose);//弹出修改参数传递
            modification.ShowDialog();//弹出修改参数窗口
        }
        ~SkinContextMenuStrip_reform()
        {

        }
    }
}
