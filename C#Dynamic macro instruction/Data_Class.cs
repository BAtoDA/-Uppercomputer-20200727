using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEngineTest
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/6 17:51:48 
    //  文件名：Data_Class 
    //  版本：V1.0.1  
    //  说明： 主要用于数据转换 
    //  修改者：***
    //  修改说明： 
    //==============================================================
    class Data_Class
    {
        /// <summary>
        /// 字符串转INT32类型
        /// </summary>
        public static int String_TO_Int32(string Vaule)
        {
            try
            {
                return Convert.ToInt32(Vaule);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 字符串转INT16类型
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static short String_TO_Int16(string Vaule)
        {
            try
            {
                return Convert.ToInt16(Vaule);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// int32类型转string字符串类型
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static string Int32_TO_String(int Vaule)
        {
            try
            {
                return Convert.ToString(Vaule);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// int16类型转string字符串类型
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static string Int16_TO_String(short Vaule)
        {
            try
            {
                return Convert.ToString(Vaule);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// Byet类型转string字符串类型
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static string Byet_TO_String(byte Vaule)
        {
            try
            {
                return Convert.ToString(Vaule);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// int32转二进制字符串
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static string Int32_TO_Binary(int Vaule)
        {
            try
            {
                return Convert.ToString(Vaule,2);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// int16转二进制字符串
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static string Int16_TO_Binary(short Vaule)
        {
            try
            {
                return Convert.ToString(Vaule,2);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// byet转二进制字符串
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static string Byet_TO_Binary(byte Vaule)
        {
            try
            {
                return Convert.ToString(Vaule, 2);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// String字符串转二进制字符串
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static string String_TO_Binary(string Vaule)
        {
            try
            {
                return Convert.ToString(Convert.ToInt32(Vaule), 2);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// Float浮点小数转二进制字符串
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static string Float_TO_Binary(float Vaule)
        {
            try
            {
                return Convert.ToString(Convert.ToInt32(Vaule), 2);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// Float浮点转Int32
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static int Float_TO_Int32(float Vaule)
        {
            try
            {
                return Convert.ToInt32(Vaule);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Float浮点转Int16
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static short Float_TO_Int16(float Vaule)
        {
            try
            {
                return Convert.ToInt16(Vaule);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Float浮点转String
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static String Float_TO_String(float Vaule)
        {
            try
            {
                return Convert.ToString(Vaule);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// Int10进制转Hex16进制
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static String Int_TO_Hex(int Vaule)
        {
            try
            {
                return Vaule.ToString("X");
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// Byet[]数组转string字符串
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static String ByetArray_TO_String(Byte[] Value)
        {
            try
            {
                return BitConverter.ToString(Value);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// Byet[]数组转string字符串
        /// </summary>
        /// <param name="Value">传入字节数组</param>
        /// <param name="le">需要转换的起始地址</param>
        /// <returns></returns>
        public static String ByetArray_TO_String(Byte[] Value,int le)
        {
            try
            {
                return BitConverter.ToString(Value, le);
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// Byet[]数组转int类型
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static int ByetArray_TO_Int32(Byte[] Value)
        {
            try
            {
                return BitConverter.ToInt32(Value, 0);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Byet[]数组转int类型
        /// </summary>
        /// <param name="Vaule"></param>
        /// <param name="le">需要转换的起始地址</param>
        /// <returns></returns>
        public static int ByetArray_TO_Int32(Byte[] Value,int le)
        {
            try
            {
                return BitConverter.ToInt32(Value, le);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// string字符串转Byet[]数组
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static Byte[] String_TO_ByetArray(string Vaule)
        {
            try
            {
                return Encoding.UTF8.GetBytes(Vaule);
            }
            catch
            {
                return new byte[] { 0};
            }
        }
        /// <summary>
        /// int转Byet[]数组
        /// </summary>
        /// <param name="Vaule"></param>
        /// <returns></returns>
        public static Byte[] Int_TO_ByetArray(int Vaule)
        {
            try
            {
                return BitConverter.GetBytes(Vaule);
            }
            catch
            {
                return new byte[] { 0 };
            }
        }
    }
}