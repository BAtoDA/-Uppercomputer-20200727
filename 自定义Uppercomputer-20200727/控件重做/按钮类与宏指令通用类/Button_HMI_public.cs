using CSEngineTest;
using Sunny.UI;
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
                    ShowSuccessTip($"向设备:HMI 地址:{ID}写入{true} 成功");
                    break;
                case "Set_as_off"://设置常OFF
                    macroinstruction_data<bool>.M_Data[ID] = false; //写入常Off
                    ShowSuccessTip($"向设备:HMI 地址:{ID}写入{false} 成功");
                    break;
                case "切换开关":
                    //根据要写入的状态进行取反
                    if (macroinstruction_data<bool>.M_Data[ID] == true)
                    {
                        macroinstruction_data<bool>.M_Data[ID] = false;
                        ShowSuccessTip($"向设备:HMI 地址:{ID} 写入{false} 成功");
                    }
                    else
                    {
                        macroinstruction_data<bool>.M_Data[ID] = true;
                        ShowSuccessTip($"向设备:HMI 地址:{ID} 写入{true} 成功");
                    }
                    break;
                case "复归型":
                    macroinstruction_data<bool>.M_Data[ID] = true;//先写入ON--后用事件复位-off       
                    state = true;
                    ShowSuccessTip($"向设备:HMI 地址:{ID}写入{true} 成功");
                    break;
                case "复归型_Off":
                    Thread.Sleep(100);//延时300ms复位
                    macroinstruction_data<bool>.M_Data[ID] = false;//先写入ON--后用事件复位-off
                    break;
            }
            return state;
        }
        /// <summary>
        /// 显示成功消息
        /// </summary>
        /// <param name="text">消息文本</param>
        /// <param name="delay">消息停留时长(ms)。默认1秒</param>
        /// <param name="floating">是否漂浮</param>
        private static void ShowSuccessTip(string text, int delay = 1000, bool floating = true)
            => UIMessageTip.ShowOk(text, delay, floating);
    }
}
