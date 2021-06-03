using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PLC通讯规范接口
{
    public class Request
    {
        /// <summary>
        /// 发送方读取标准报文
        /// </summary>
        public class COPYDATASTRUCT
        {
            /// <summary>
            /// 消息标识符 一般是指发送与回复方的名称
            /// </summary>
            public string characteristic;
            /// <summary>
            /// 功能码 
            /// </summary>
            public int function;
            /// <summary> 
            /// 访问设备的功能码 假设访问三菱 D 
            /// </summary>
            public string Equipmenttype;
            /// <summary>
            /// 访问设备具体地址 假设访问三菱 D--100
            /// </summary>
            public string Address;
            /// <summary>
            /// 访问设备的类型 假设访问三菱 D--100 -- int16
            /// </summary>
            public string Type;
            /// <summary>
            /// 访问设备的长度 假设访问三菱 D--100 -- int16 --1 读一个字
            /// </summary>
            public string length;
            /// <summary>
            /// 指向内存的字节数
            /// </summary>
            public int cbData;
            /// <summary>
            /// 消息内容  读数据时 该属性为null
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]

            public string lpData;

        }
        /// <summary>
        /// Hmi回复标准报文
        /// </summary>
        public class COPYDATASTRUCTresult
        {
            /// <summary>
            /// 消息标识符 一般是指发送与回复方的名称
            /// </summary>
            public string characteristic;
            /// <summary>
            /// 功能码 
            /// </summary>
            public int function;
            /// <summary> 
            /// 访问设备的功能码 假设访问三菱 D 
            /// </summary>
            public string Equipmenttype;
            /// <summary>
            /// 访问设备具体地址 假设访问三菱 D--100
            /// </summary>
            public string Address;
            /// <summary>
            /// 访问设备的类型 假设访问三菱 D--100 -- int16
            /// </summary>
            public string Type;
            /// <summary>
            /// 访问设备的长度 假设访问三菱 D--100 -- int16 --1 读一个字
            /// </summary>
            public string length;
            /// <summary>
            /// 访问设备回复数据 假设访问三菱 D--100 -- int16 --1 读一个字
            /// </summary>
            public string Data;
            /// <summary>
            /// 请求结果--正常为true  异常为false
            /// </summary>
            public bool result;
            /// <summary>
            /// 指向内存的字节数
            /// </summary>
            public int cbData;
            /// <summary>
            /// 消息内容  读数据时 该属性为null
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]

            public string lpData;

        }
    }
}
