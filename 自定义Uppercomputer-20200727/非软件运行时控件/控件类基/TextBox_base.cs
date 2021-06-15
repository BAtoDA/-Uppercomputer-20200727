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
    //  时间：2021/2/18 11:19:44 
    //  文件名：TextBox_base 
    //  版本：V1.0.1  
    //  说明：上位机文本类底层控件公共属性--必须继承实现该接口
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 上位机文本类底层控件公共属性
    /// </summary>
    interface TextBox_base
    {
        /// <summary>
        /// 修改参数界面启动事件
        /// </summary>
        event EventHandler Modification;
        /// <summary>
        /// 选择PLC类型枚举
        /// </summary>
        PLC Plc { get; set; }
        /// <summary>
        /// 指示是否启用PLC功能
        /// </summary>
        bool PLC_Enable { get; set; }
        /// <summary>
        /// 修改参数界面方法
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        void Modifications_Eeve(object send, EventArgs e);
        /// <summary>
        /// PLC触点功能
        /// </summary>
        string PLC_Contact { get; set; }
        /// <summary>
        /// PLC访问具体地址
        /// </summary>
        string PLC_Address { get; set; }
        /// <summary>
        /// 控件显示数据的类型
        /// </summary>
        numerical_format numerical { get; set; }
        /// <summary>
        /// 显示小数点以上
        /// </summary>
        int Decimal_Above { get; set; }
        /// <summary>
        /// 显示小数点以下
        /// </summary>
        int Decimal_Below { get; set; }
        /// <summary>
        /// 传递控件文本值
        /// </summary>
        string Control_Text { get; set; }
        /// <summary>
        /// 控件刷新定时器
        /// </summary>
        System.Windows.Forms.Timer PLC_time { get; }
    }
}
