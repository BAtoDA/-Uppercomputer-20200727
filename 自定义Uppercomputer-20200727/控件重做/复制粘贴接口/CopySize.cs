using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 自定义Uppercomputer_20200727.控件重做.复制粘贴接口
{
    /// <summary>
    /// 本类用于处理复制的时候控件大小调整
    /// </summary>
    class CopySize
    {
        public static void ControlSize(Control control,Form form)
        {
            //设置控件产生的位置--判断是否超出边界
            if ((control.Left + control.Size.Width + 20) > form.Width - 10 && (control.Top + control.Size.Height + 20) < form.Height - 10)
            {
                control.Location = new Point(control.Location.X, control.Location.Y + control.Height + 20);
                return;
            }
            if ((control.Location.X + control.Size.Width + 20) < form.Width - 10)
            {
                control.Location = new Point(control.Location.X + control.Size.Width + 20, control.Location.Y);
                return;
            }
            //设置控件产生的位置--判断是否超出边界
            if ((control.Location.X + control.Size.Width + 20) > form.Width - 10 && (control.Location.Y + control.Size.Height + 20) > form.Height - 10)
            {
                control.Location = new Point(control.Location.X + control.Size.Width - 20, control.Location.Y);
                return;
            }
        }
    }

}
