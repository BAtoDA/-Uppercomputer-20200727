using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLC通讯规范接口;

namespace CSEngineTest
{
    /// <summary>
    /// 本类主要用于-宏指令到
    /// </summary>
    public class PLC
    {
        /// <summary>
        /// 三菱Mitsubishi PLC仿真
        /// </summary>
        public static macroinstruction_PLC_interface Mitsubishi_axActUtlType { get; set; }
        /// <summary>
        /// 三菱Mitsubishi PLC在线访问 
        /// </summary>
        public static macroinstruction_PLC_interface Mitsubishi { get; set; }
        /// <summary>
        /// MODBUD_TCP 在线访问
        /// </summary>
        public static macroinstruction_PLC_interface MODBUD_TCP { get; set; }
        /// <summary>
        /// 西门子Siemens 在线访问
        /// </summary>
        public static macroinstruction_PLC_interface Siemens { get; set; }
        /// <summary>
        /// 欧姆龙PLC Tcp在线访问
        /// </summary>
        public static IPLC_interface OmronTcp { get; set; }
        /// <summary>
        /// 欧姆龙PLC Udp在线访问
        /// </summary>
        public static IPLC_interface OmronUdp { get; set; }
        /// <summary>
        /// 欧姆龙PLC Cip在线访问
        /// </summary>
        public static IPLC_interface OmronCip { get; set; }
        /// <summary>
        /// 发那科机器人 在线访问
        /// </summary>
        public static IPLC_interface Fanuc { get; set; }
    }
}
