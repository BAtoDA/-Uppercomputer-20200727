using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC通讯规范接口
{
    /// <summary>
    /// PLC实现接口--规范定义的方法名称Mitsubishi_realize
    /// </summary>
    public interface IPLC_interface//规范定义的方法名称
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
        /// PLC是否重连标志位
        /// </summary>
        bool PLC_Reconnection { get; set; }
        /// <summary>
        /// PLC链接的类型
        /// </summary>
        string PLC_type { get; set; }
        /// <summary>
        /// 打开PLC
        /// </summary>
        /// <returns></returns>
        string PLC_open();//打开PLC
        /// <summary>
        /// 切断PLC链接
        /// </summary>
        /// <returns></returns>
        void PLC_Close();
        /// <summary>
        /// 重连PLC方法
        /// </summary>
        void PLCreconnection();
        /// <summary>
        /// 读取--位
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        List<bool> PLC_read_M_bit(string Name, string id);//读取--位
        /// <summary>
        /// /写入--位
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="button_State"></param>
        /// <returns></returns>
        List<bool> PLC_write_M_bit(string Name, string id, Button_state button_State);//写入--位
        /// <summary>
        /// /读取--字
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string PLC_read_D_register(string Name, string id, numerical_format format);//读取--字
        /// <summary>
        /// 读写--字
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string PLC_write_D_register(string Name, string id, string content, numerical_format format);//读写--字
        /// <summary>
        /// 读取--字--多个读取-自动判断类型改变地址索引
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> PLC_read_D_register_bit(string Name, string id, numerical_format format, string Index);//读取--字--多个读取
        /// <summary>
        /// 读写--字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> PLC_write_D_register_bit(string id);//读写--字
    }
}
