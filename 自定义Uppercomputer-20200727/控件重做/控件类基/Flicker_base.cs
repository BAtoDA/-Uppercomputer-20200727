using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bottom_Control.控件类基
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/20 14:58:28 
    //  文件名：Flicker_base 
    //  版本：V1.0.1  
    //  说明： 上位机按钮类闪烁控件底层控件公共属性--必须继承实现该接口
    //  修改者：***
    //  修改说明： 
    //==============================================================
    interface Flicker_base
    {
        /// <summary>
        /// 值为0时 是否开启闪烁
        /// </summary>
        bool O_Flicker { get; set; }
        /// <summary>
        /// 值为0时闪烁颜色变换的队列
        /// </summary>
        Color[] O_FlickerColor { get; set; }
        /// <summary>
        /// 值为0时闪烁变换的时间
        /// </summary>
        int O_FlickerTime { get; set; }
        /// <summary>
        /// 值为1时 是否开启闪烁
        /// </summary>
        bool I_Flicker { get; set; }
        /// <summary>
        /// 值为1时闪烁颜色变换的队列
        /// </summary>
        Color[] I_FlickerColor { get; set; }
        /// <summary>
        /// 值为1时闪烁变换的时间
        /// </summary>
        int I_FlickerTime { get; set; }
    }
}
