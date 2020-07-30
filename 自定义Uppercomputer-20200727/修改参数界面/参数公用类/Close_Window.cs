using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    /// <本类用于处理修改参数窗口关闭功能——公用—-后续可加提示>    
    class Close_Window
    {
        public Close_Window(Form form)
        {
            form.Close();//关闭窗口
            form.Dispose();//释放资源
        }
    }
}
