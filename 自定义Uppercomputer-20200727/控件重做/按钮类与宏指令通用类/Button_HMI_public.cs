using CSEngineTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 宏指令公用类
    /// </summary>
    class Button_HMI_public
    {
        public static bool Button_HMI_write_select(int ID,string Name)//按照按钮模式写入
        {
            bool state = false;
            switch (Name)
            {
                case "Set_as_on"://设置常ON
                    macroinstruction_data<bool>.M_Data[ID] = true; //写入常ON
                    break;
                case "Set_as_off"://设置常OFF
                    macroinstruction_data<bool>.M_Data[ID] = false; //写入常Off
                    break;
                case "切换开关":
                    //根据要写入的状态进行取反
                    if (macroinstruction_data<bool>.M_Data[ID] == true)
                        macroinstruction_data<bool>.M_Data[ID] = false;
                    else
                        macroinstruction_data<bool>.M_Data[ID] = true;
                    break;
                case "复归型":
                    macroinstruction_data<bool>.M_Data[ID] = true;//先写入ON--后用事件复位-off       
                    state = true;
                    break;
                case "复归型_Off":
                    Thread.Sleep(100);//延时300ms复位
                    macroinstruction_data<bool>.M_Data[ID] = false;//先写入ON--后用事件复位-off
                    break;
            }
            return state;
        }
    }
}
