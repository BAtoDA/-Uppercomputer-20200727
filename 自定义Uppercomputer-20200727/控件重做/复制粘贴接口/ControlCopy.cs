using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 自定义Uppercomputer_20200727.控件重做.复制粘贴接口
{
    /// <summary>
    /// 复制粘贴控件接口
    /// 必须实现所有方法
    /// </summary>
    interface ControlCopy: ICloneable
    {
       Control Objectproperty(String Name,Form form);
    }
}
