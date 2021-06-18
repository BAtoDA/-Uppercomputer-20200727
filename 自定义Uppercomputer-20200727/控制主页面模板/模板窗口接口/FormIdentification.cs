using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.控制主页面模板.模板窗口接口
{
    /// <summary>
    /// 该接口主要用于如何处理上位机窗口  
    /// 理论上所以窗口都需要实现该接口
    /// </summary>
    interface FormIdentification
    {
        /// <summary>
        /// 指示着该窗口是否需要关闭
        /// true 切换完成后自动关闭该窗口
        /// false 切换完成后不关闭该窗口
        /// </summary>
        bool IsCloseForm { get; }
        /// <summary>
        /// 指示着该窗口任务是否加载完成
        /// true加载完成允许切换窗口 false 不能切换窗口
        /// </summary>
        bool IsfunctionKey { get; set; }

    }
}
