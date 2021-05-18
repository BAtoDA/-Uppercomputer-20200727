using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HZH_Controls.Controls;
using Sunny.UI;
namespace Robot通讯控制
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/3/20 22:13:13 
    //  文件名：TextBox_overwrite 
    //  版本：V1.0.1  
    //  说明： 实现控件排序用
    //  修改者：***
    //  修改说明： 
    //==============================================================
    class TextBox_overwrite :TextBoxEx, IMessageFilter
    {
        public int Serial { get; set; }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x0201 || m.Msg == 516)
            {
                //遍历当前窗口
                //if (uCKey != null)
                //{
                //    if (Control.MousePosition.X>uCKey.Location.X+uCKey.Size.Width )
                //        return false;
                //    var conrt = (from Control pi in Application.OpenForms[0].Controls where pi.Name == "uiPanel1" select pi).First();
                //    var thart = (from Control pi in conrt.Controls where pi.Name == "uiTabControlMenu1" select pi).First();
                //    UITabControlMenu uITab = thart as UITabControlMenu;
                //    uITab.TabPages[4].Controls.Remove(uCKey);
                //}
            }
            return false;
        }
        public TextBox_overwrite()
        {
            this.KeyPress += KeyPress_reform;
        }
        private void KeyPress_reform(object sender, KeyPressEventArgs e)//键盘事件--位置与大小数据
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9')||this.Text.Length>7)//这是允许输入0-9数字 最大数据不能大于3位数  
                {
                    e.Handled = true;//只能输入数字
                }
            }
        }

    }
}
