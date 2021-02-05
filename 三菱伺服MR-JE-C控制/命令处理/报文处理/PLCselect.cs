using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令处理
{
    /// <summary>
    /// PLC硬件选择
    /// PLC选择枚举>
    /// </summary>

    public enum PLC
    {
        Mitsubishi,
        Siemens,
        Modbus_TCP,
        HMI
    }
    /// <summary>
    /// PLC各可访问软元件  三菱-bit位
    /// </summary>
    public enum Mitsubishi_bit
    { 
      /*  LCS,LCC,*/SM,X,Y,M,L,F,B,TS,SS,SC,CS,CC,SB,S,D_Bit,SD_Bit,R_Bit,SW_Bit,W_Bit
    }
    /// <summary>
    /// PLC各可访问软元件 三菱 -WORD 字
    /// </summary>
    public enum Mitsubishi_D
    {
        /*LCN,LZ,*/SD,D,R,W,TN,SN,CN,SW,Z
    }
    /// <summary>
    ///  PLC各可访问软元件 西门子 -bit位
    /// </summary>
    public enum Siemens_bit
    {
       I, Q, M,DB
    }
    /// <summary>
    /// PLC各可访问软元件 西门子-WORD 字
    /// </summary>
    public enum Siemens_D
    {
       DB,M
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
        Off,ON
    }
    /// <summary>
    /// 数值显示类型
    /// </summary>
    public enum numerical_format
    {
        BCD_16_Bit, BCD_32_Bit, Hex_16_Bit, Hex_32_Bit, Binary_16_Bit, Binary_32_Bit, Unsigned_16_Bit, Signed_16_Bit
            , Unsigned_32_Bit, Signed_32_Bit, Float_32_Bit
    }
    /// <summary>
    /// 数值显示类型
    /// </summary>
    public enum numerical_type
    {
        数值
    }
    class PLCselect
    {

    }
}
