using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot通讯控制
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/3/24 22:03:27 
    //  文件名：KeyBusy 
    //  版本：V1.0.1  
    //  说明： 实现监控是否有鼠标按下输入
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现IMessageFilter接口 监听WIN消息
    /// </summary>
    class KeyBusy : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x0201|| m.Msg== 516)
            {
                MessageBox.Show("dd");
            }
            return false;
        }
    }
}
