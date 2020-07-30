using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEngineTest
{
    /// <summary>
    /// 宏指令与PLC的接口--PLC端必须继承与实现接口
    /// </summary>

    public interface macroinstruction_PLC_interface
    {
        /// <summary>
        /// PLC准备好
        /// </summary>
        bool PLC_ready { get; }//PLC准备好
        /// <summary>
        /// PLC报警代码
        /// </summary>
        int PLCerr_code { get; }//PLC报警代码
        /// <summary>
        /// PLC报警内容
        /// </summary>
        string PLCerr_content { get; }//PLC报警内容
        /// <summary>
        /// 打开PLC
        /// </summary>
        /// <returns></returns>
        List<bool> PLC_read_M_bit(string Name, string id);//读取--位
        /// <summary>
        /// /写入--位
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="bon-off "></param>
        /// <returns></returns>
        List<bool> PLC_write_M_bit(string Name, string id, bool on_off );//写入--位
        /// <summary>
        /// /读取--字
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format">数据格式</param>
        /// <returns></returns>
        string PLC_read_D_register(string Name, string id, string format);//读取--字
        /// <summary>
        /// 读写--字
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string PLC_write_D_register(string Name, string id, string content, string format);//读写--字
        /// <summary>
        /// 读取--字--多个读取-自动判断类型改变地址索引
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> PLC_read_D_register_bit(string Name, string id, string format, string Index);//读取--字--多个读取
        /// <summary>
        /// 读写--字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> PLC_write_D_register_bit(string id);//读写--字
    }
}
