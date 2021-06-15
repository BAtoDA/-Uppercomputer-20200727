using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLC通讯规范接口;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.控件类基
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/22 8:50:36 
    //  文件名：Histogram_base 
    //  版本：V1.0.1  
    //  说明：Histogram柱形图表格控件定时器读取PLC 接口规范 
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// Histogram柱形图控件定时器读取PLC 接口规范 
    /// </summary>

    interface Histogram_base
    {
        /// <summary>
        /// 默认Chart图标名称
        /// </summary>
        string Histogram_Chart_Name { get; set; }
        /// <summary>
        /// 默认图标显示的名称
        /// </summary>
        string Histogram_Chart_Text { get; set; }
        /// <summary>
        /// 默认显示的文本字体
        /// </summary>
        Font Histogram_Chart_Font { get; set; }
        /// <summary>
        /// 设置字体颜色
        /// </summary>
        Color Font_Color { get; set; }
        /// <summary>
        /// 设置默认颜色为透明
        /// </summary>
        Color Background_colo { get; set; }
        /// <summary>
        /// 默认柱形图小标题名称
        /// </summary>
        string[] Headline { get; set; }
        /// <summary>
        /// 默认柱形图小标题显示数据的地址
        /// </summary>
        string[] Total_address { get; set; }
        /// <summary>
        /// 默认标题数据类型
        /// </summary>
        numerical_format[] Histogram_numerical { get; set; }
    }
}
