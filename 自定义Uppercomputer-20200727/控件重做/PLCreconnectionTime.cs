using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLC通讯规范接口;
using 欧姆龙Fins协议.欧姆龙.报文处理;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 继承与系统定时器 用于处理PLC重连机制
    /// </summary>
    [ToolboxItem(true)]
    [Browsable(true)]
    [Description("PLC后台定时打开,刷新,重新链接控件")]
    class PLCreconnectionTime :System.Windows.Forms.Timer
    {
        IPLC_interface Mitsubishi_ax;
        IPLC_interface Mitsubishi_rea;
        IPLC_interface MODBUD_tcp;
        IPLC_interface Siemens_rea;
        IPLC_interface OmronFinsCIP;
        IPLC_interface OmronFinsTCP;
        IPLC_interface OmronFinsUDP;
        /// <summary>
        /// 构造函数
        /// </summary>
        public PLCreconnectionTime()
        {
            //配置该控件默认参数
            this.Enabled = false;
            this.Interval = 500;
            Mitsubishi_ax = new Mitsubishi_axActUtlType();
            Mitsubishi_rea = new Mitsubishi_realize();
            MODBUD_tcp = new MODBUD_TCP();
            Siemens_rea = new Siemens_realize();
            OmronFinsCIP = new OmronFinsCIP();
            OmronFinsTCP = new OmronFinsTcp();
            OmronFinsUDP = new OmronFinsUDP();

        }
        protected async override void OnTick(EventArgs e)//重写定时器到达事件
        {

               await Task.Run(() =>
                {
                    this.Stop();
                    lock (this)
                    {
                        //重连PLC机制
                        if( Mitsubishi_ax.PLC_Reconnection&& Mitsubishi_ax.PLC_ready!=true)
                        {
                            Mitsubishi_ax.PLC_Close();
                            Mitsubishi_ax.PLC_open();
                        }
                        if (Mitsubishi_rea.PLC_Reconnection && Mitsubishi_rea.PLC_ready != true)
                        {
                            Mitsubishi_rea.PLC_Close();
                            Mitsubishi_rea.PLC_open();
                        }
                        if (MODBUD_tcp.PLC_Reconnection && MODBUD_tcp.PLC_ready != true)
                        {
                            MODBUD_tcp.PLC_Close();
                            MODBUD_tcp.PLC_open();
                        }
                        if (Siemens_rea.PLC_Reconnection && Siemens_rea.PLC_ready != true)
                        {
                            Siemens_rea.PLC_Close();
                            Siemens_rea.PLC_open();
                        }
                        if (OmronFinsCIP.PLC_Reconnection && OmronFinsCIP.PLC_ready != true)
                        {
                            OmronFinsCIP.PLC_Close();
                            OmronFinsCIP.PLC_open();
                        }
                        if (OmronFinsTCP.PLC_Reconnection && OmronFinsTCP.PLC_ready != true)
                        {
                            OmronFinsTCP.PLC_Close();
                            OmronFinsTCP.PLC_open();
                        }
                        if (OmronFinsUDP.PLC_Reconnection && OmronFinsUDP.PLC_ready != true)
                        {
                            OmronFinsUDP.PLC_Close();
                            OmronFinsUDP.PLC_open();
                        }
                        this.Start();
                    }
                });
          
        }
    }
}
