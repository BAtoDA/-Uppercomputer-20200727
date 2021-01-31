using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.三菱报文
{
    /// <summary>
    /// 可访问设备的软元件-类型是bit位
    /// 请指定读取、写入数据的对象模块中存在的软元件
    /// </summary>
    public enum message_bit
    {
        /// <summary>
        /// 内部用户软元件
        /// 内部继电器
        /// </summary>
        M = 0x90,
        /// <summary>
        /// 系统软元件 
        /// 特殊继电器
        /// </summary>
        SM = 0x91,
        /// <summary>
        /// 内部用户软元件
        /// 输入
        /// </summary>
        X = 0x9C,
        /// <summary>
        /// 内部用户软元件
        /// 输出
        /// </summary>
        Y = 0x9D,
        /// <summary>
        /// 内部用户软元件
        /// 锁存继电器
        /// </summary>
        L = 0x92,
        /// <summary>
        /// 内部用户软元件
        /// 报警器
        /// </summary>
        F = 0x93,
        /// <summary>
        /// 内部用户软元件
        /// 变址继电器
        /// </summary>
        V = 0x94,
        /// <summary>
        /// 内部用户软元件
        /// 定时器-位触点
        /// </summary>
        TS = 0xC1,
        /// <summary>
        /// 内部用户软元件
        /// 定时器-线圈
        /// </summary>
        TC = 0xC2,
        /// <summary>
        /// 内部用户软元件
        /// 累计定时器-触点
        /// </summary>
        SS = 0xC7,
        /// <summary>
        /// 内部用户软元件
        /// 累计定时器-线圈
        /// </summary>
        SC = 0xC6,
        /// <summary>
        /// 内部用户软元件
        /// 计数器-触点
        /// </summary>
        CS = 0xC4,
        /// <summary>
        /// 内部用户软元件
        /// 计数器-线圈
        /// </summary>
        CC = 0xC3,
        /// <summary>
        /// 内部用户软元件
        /// 链接特殊继电器
        /// </summary>
        SB = 0xA1,
        /// <summary>
        /// 内部用户软元件
        /// 步继电器
        /// </summary>
        S = 0x98,
    }
    /// <summary>
    /// 可访问设备的软元件-类型是字或者双字
    /// 请指定读取、写入数据的对象模块中存在的软元件
    /// </summary>
    public enum message_Word
    {
        /// <summary>
        /// 系统软元件
        /// 特殊寄存器
        /// </summary>
        SD = 0xA9,
        /// <summary>
        /// 链接直接软元件
        /// 链接寄存器
        /// </summary>
        W = 0xB4,
        /// <summary>
        /// 链接直接软元件
        /// 链接继电器
        /// </summary>
        B = 0xA0,
        /// <summary>
        /// 内部用户软元件
        /// 数据寄存器
        /// </summary>
        D = 0xA8,
        /// <summary>
        /// 内部用户软元件
        /// 定时器-当前值
        /// </summary>
        TN = 0xC0,
        /// <summary>
        /// 内部用户软元件
        /// 累计定时器-当前值
        /// </summary>
        SN = 0xC8,
        /// <summary>
        /// 内部用户软元件
        /// 计数器-当前值
        /// </summary>
        CN = 0xC5,
        ///// <summary>
        ///// 
        ///// </summary>
        //DX = 0xA2,
        //DY = 0xA3,
        /// <summary>
        /// 变址寄存器
        /// </summary>
        Z = 0xCC,
        /// <summary>
        /// 文件寄存器
        /// </summary>
        R = 0xAF,
        /// <summary>
        /// 文件寄存器-延长
        /// </summary>
        ZR = 0xB0,
        /// <summary>
        /// 内部用户软元件
        /// 链接特殊寄存器 
        /// </summary>
        SW = 0xB5

    }
    /// <summary>
    /// 用于选择访问设备返回的类型
    /// </summary>
    public enum numerical_format
    {
        /// <summary>
        /// 返回字节类型
        /// </summary>
        Byet,
        /// <summary>
        /// 返回16进制字
        /// </summary>
        Hex_16_Bit,
        /// <summary>
        /// 返回16进制双字
        /// </summary>
        Hex_32_Bit,
        /// <summary>
        /// 返回二进制字
        /// </summary>
        Binary_16_Bit,
        /// <summary>
        /// 返回二进制双字
        /// </summary>
        Binary_32_Bit,
        /// <summary>
        /// 返回无符号字
        /// </summary>
        Unsigned_16_Bit,
        /// <summary>
        /// 返回有符号字
        /// </summary>
        Signed_16_Bit,
        /// <summary>
        /// 返回无符号双字
        /// </summary>
        Unsigned_32_Bit,
        /// <summary>
        /// 返回有符号双字
        /// </summary>
        Signed_32_Bit,
        /// <summary>
        /// 返回有符号int64
        /// </summary>
        Signed_64_Bit,
        /// <summary>
        /// 返回单精度浮点小数
        /// </summary>
        Float_32_Bit
    }
}
