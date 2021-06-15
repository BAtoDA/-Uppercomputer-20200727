using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLC通讯规范接口;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.控件类基
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/20 16:52:59 
    //  文件名：DataGridViewPLC_base 
    //  版本：V1.0.1  
    //  说明： DataGridView表格控件定时器读取PLC 接口规范 
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// DataGridView表格控件定时器读取接口规范
    /// </summary>
    interface DataGridViewPLC_base
    {
        /// <summary>
        /// 需要访问的PLC地址
        /// </summary>
        string[] PLC_address { get; set; }
        /// <summary>
        /// 显示表格的名称
        /// </summary>
        string[] DataGridView_Name { get; set; }
        /// <summary>
        /// 表格对应的数据类型
        /// </summary>
        numerical_format[] DataGridView_numerical { get; set; }
        /// <summary>
        /// 是否显示读取时间
        /// </summary>
        bool DataGridViewPLC_Time { get; set; }
        
    }
}
