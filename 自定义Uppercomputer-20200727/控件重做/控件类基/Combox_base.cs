using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bottom_Control.控件类基
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/19 16:11:55 
    //  文件名：Combox_base 
    //  版本：V1.0.1  
    //  说明： 上位机下拉菜单类底层控件公共属性--必须继承实现该接口
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 上位机下拉菜单类底层控件公共属性
    /// </summary>
    interface Combox_base
    {
        /// <summary>
        /// 下拉菜单KEY值
        /// </summary>
        int[] KeyValuePair { get;}
        /// <summary>
        /// 下拉菜单Value 显示名称值
        /// </summary>
        string[] ValuePair { get;}
        /// <summary>
        /// 修改下拉菜单参数界面启动事件
        /// </summary>
        event EventHandler Combox_Modification;
    }
}
