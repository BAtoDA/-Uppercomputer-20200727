using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 服务器端.上位机通讯报文处理
{
    /// <summary>
    /// 用于表示要读写的功能码--标准规范不能更改
    /// </summary>
    public enum Functional
    {
        ReadHmi_bool=0X1,
        ReadHmi_D = 0X2,
        WriteHmi_bool = 0X3,
        WriteHmi_D = 0X4,
        Readmitsubishi_bool = 0X5,
        Readmitsubishi_D = 0X6,
        Writemitsubishi_bool = 0X7,
        Writemitsubishi_D = 0X8,
        Readsiemens_bool = 0X9,
        Readsiemens_D = 0X10,
        Writesiemens_bool = 0X11,
        Writesiemens_D = 0X12,
        ReadModbusTCP_bool = 0X13,
        ReadModbusTCP_D = 0X14,
        WriteModbusTCP_bool = 0X15,
        WriteModbusTCP_D = 0X16,
        ReadOmronTCP_bool = 0X17,
        ReadOmronTCP_D = 0X18,
        WriteOmronTCP_bool = 0X19,
        WriteOmronTCP_D = 0X20,

    }
    /// <summary>
    /// 用于读写上位机D区寄存器
    /// </summary>
    public enum HmiType
    {
        Int32,Int16,Byte,Hex
    }
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
    /// <summary>
    /// PLC各可访问软元件  三菱-bit位
    /// </summary>
    public enum Mitsubishi_bit
    {
        /*  LCS,LCC,*/
        X, Y, M, L, F, B, TS, SM, SS, SC, CS, CC, SB, S, D_Bit, R_Bit, SW_Bit, W_Bit
    }
    /// <summary>
    /// PLC各可访问软元件 三菱 -WORD 字
    /// </summary>
    public enum Mitsubishi_D
    {
        /*LCN,LZ,*/
        D, R, W, TN, SN, CN, SW, Z
    }
    /// <summary>
    /// PLC各可访问软元件  欧姆龙 位
    /// </summary>
    public enum Omron_bit
    {
        W = 36,
        A = 51,
        D = 2,
        H = 50,
        EM00 = 0x20,
        EM01 = 33,
        EM02 = 34,
        EM03 = 35,
        C = 49
    }
    /// <summary>
    /// PLC各可访问软元件  欧姆龙  字
    /// </summary>
    public enum Omron_D
    {
        W = 36,
        C = 49,
        H = 50,
        A = 51,
        D = 2,
        EM00 = 0x20,
        EM01 = 33,
        EM02 = 34,
        EM03 = 35
    }
    /// <summary>
    /// PLC各可访问软元件  欧姆龙 位
    /// </summary>
    public enum Fanuc_bit
    {
        DI = 1,
        DO = 2,
        RI = 3,
        RO = 4,
        UI = 5,
        UO = 6
    }
    /// <summary>
    /// PLC各可访问软元件  欧姆龙  字
    /// </summary>
    public enum Fanuc_D
    {
        R = 1,
        PR = 2,
        GO = 3,
        GI = 4
    }
    /// <summary>
    ///  PLC各可访问软元件 西门子 -bit位
    /// </summary>
    public enum Siemens_bit
    {
        I, Q, M, DB
    }
    /// <summary>
    /// PLC各可访问软元件 西门子-WORD 字
    /// </summary>
    public enum Siemens_D
    {
        DB, M
    }
    /// <summary>
    ///  PLC各可访问软元件 Modbus_TCP -bit位
    /// </summary>
    public enum Modbus_TCP_bit
    {
        X, Y, M
    }
    /// <summary>
    /// PLC各可访问软元件 Modbus_TCP-WORD 字
    /// </summary>
    public enum Modbus_TCP_D
    {
        D
    }
    /// <summary>
    /// PLC各可访问软元件  三菱-bit位
    /// </summary>
    public enum HMI_bit
    {
        Data_Bit
    }
    /// <summary>
    /// PLC各可访问软元件 三菱 -WORD 字
    /// </summary>
    public enum HMI_D
    {
        Data_D
    }
    /// <summary>
    ///  PLC--按钮状态
    /// </summary>
    public enum Button_state
    {
        Off, ON
    }
    /// <summary>
    /// 数值显示类型
    /// </summary>
    public enum numerical_format
    {
        BCD_16_Bit, BCD_32_Bit, Hex_16_Bit, Hex_32_Bit, Binary_16_Bit, Binary_32_Bit, Unsigned_16_Bit, Signed_16_Bit
            , Unsigned_32_Bit, Signed_32_Bit, Float_32_Bit
    }
}
