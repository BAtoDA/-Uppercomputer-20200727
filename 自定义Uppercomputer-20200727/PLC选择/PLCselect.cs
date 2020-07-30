using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.PLC选择
{
    /// <PLC硬件选择>
    /// <PLC选择枚举> 
    public enum PLC
    {
        Mitsubishi,
        Siemens,
        Modbus_TCP
    }
    /// <PLC各可访问软元件>
    public enum Mitsubishi_bit
    { 
        LCS,LCC,SM,X,Y,M,L,F,B,TS,SS,SC,CS,CC,SB,S,D_Bit,SD_Bit,R_Bit,SW_Bit,W_Bit
    }
    public enum Mitsubishi_D
    {
        LCN,LZ,SD,D,R,W,TN,SN,CN,SW,Z
    }

    class PLCselect
    {

    }
}
