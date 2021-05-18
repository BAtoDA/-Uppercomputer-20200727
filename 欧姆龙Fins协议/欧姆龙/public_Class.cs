using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 欧姆龙Fins协议.报文处理
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/3 17:39:00 
    //  文件名：public_Class 
    //  版本：V1.0.1  
    //  说明： 实现主要用于处理字节 分析数据
    //  修改者：***
    //  修改说明： 
    //==============================================================
    public class public_Class
    {
        /// <summary>
        /// int转B00L
        /// </summary>
        /// <param name="result"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public bool[] ConvertIntToBoolArray(int result, int len)//int转B00L
        {

            if (len > 32 || len < 0)
            {
                Console.WriteLine("bool数组长度应该在0到32之间。");
            }

            bool[] barray2 = new bool[len];

            for (int i = 0; i < len; i++)
            {
                barray2[len - i - 1] = ((result >> i) % 2) == 1;
            }
            Array.Reverse(barray2);
            return barray2;
        }
    }
}
