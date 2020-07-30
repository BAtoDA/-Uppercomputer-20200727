using CCWin.SkinControl;
using CSEngineTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类
{
    /// <summary>
    /// 数值公用类
    /// </summary>
    class numerical_public
    {
        public static List<int> Index(int ID,int location,List<int> doughnut_Chart_Data)
        {
            for (int i = 0; i < ID ; i++)
            {
                int data = 0;
                if (macroinstruction_data<int>.D_Data[location+i].IsNull() != true)
                {
                    try
                    {
                        //强制转换--失败返回默认值0
                        data = Convert.ToInt32(macroinstruction_data<int>.D_Data[location+i]);
                    }
                    catch
                    {
                    }
                    doughnut_Chart_Data.Add(data);
                }
                else
                    doughnut_Chart_Data.Add(data);
            }
            return doughnut_Chart_Data;
        }
        public static int Size_X(int X)
        {
            if (Form2.Size_Max)
            {
                return (int)Math.Round(Convert.ToSingle(X)/AutoSizeFormClass.X);

            }
            else
            {
                return X;
            }
        }
        public static int Size_Y(int Y)
        {
            if (Form2.Size_Max)
            {
                return (int)Math.Round(Convert.ToSingle(Y)/AutoSizeFormClass.Y);

            }
            else
            {
                return Y;
            }
        }
    }

}
