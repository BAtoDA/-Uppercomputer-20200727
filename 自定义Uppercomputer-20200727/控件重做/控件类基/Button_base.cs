using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using PLC通讯规范接口;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.控件重做.控件类基.按钮__TO__PLC方法;

namespace 自定义Uppercomputer_20200727.控件重做.控件类基
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/15 12:55:35 
    //  文件名：Button_Interface
    //  版本：V1.0.1  
    //  说明： 上位机按钮类底层控件公共属性--必须继承实现该接口
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 按钮类 通讯类基 必须实现该接口
    /// </summary>
    interface Button_base
    {
        /// <summary>
        /// 刷新控件方法
        /// </summary>
        void ControlRefresh(Button_state button_State);
        /// <summary>
        /// 控件刷新定时器
        /// </summary>
        System.Threading.Timer PLC_time { get; }
        /// <summary>
        /// 按钮类 类基
        /// </summary>
        Button_to_plc button_PLC { get; }
    }
}
