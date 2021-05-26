using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 自定义Uppercomputer_20200727.控件重做.控件类基.文本__TO__PLC方法;

namespace 自定义Uppercomputer_20200727.控件重做.控件类基
{
    interface TextBox_base
    {
        /// <summary>
        /// 刷新控件方法
        /// </summary>
        void ControlRefresh(string Data);
        /// <summary>
        /// 控件刷新定时器
        /// </summary>
        System.Threading.Timer PLC_time { get; }
        /// <summary>
        /// 按钮类 类基
        /// </summary>
        TextBox_PLC TextBox { get; }
    }
}
