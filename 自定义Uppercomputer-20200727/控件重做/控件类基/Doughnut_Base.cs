using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bottom_Control.圆型图__TO__PLC
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/21 9:51:40 
    //  文件名：Doughnut_Base 
    //  版本：V1.0.1  
    //  说明： 实现控件上下左右对齐
    //  修改者：***
    //  修改说明： 
    //==============================================================
    interface Doughnut_Base
    {
        /// <summary>
        /// 默认Chart图标名称
        /// </summary>
        string doughnut_Chart_Name { get; set; }
        /// <summary>
        /// 默认图标显示的名称
        /// </summary>
        string doughnut_Chart_Text { get; set; }
        /// <summary>
        /// 默认显示的文本字体
        /// </summary>
        Font doughnut_Chart_Font { get; set; }
        /// <summary>
        /// 设置字体颜色
        /// </summary>
        Color color { get; set; }
        /// <summary>
        /// 设置默认颜色为透明
        /// </summary>
        Color background_colo { get; set; }
    }
}
