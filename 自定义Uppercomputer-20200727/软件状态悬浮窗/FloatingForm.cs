using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLC通讯规范接口;
using 欧姆龙Fins协议.欧姆龙.报文处理;
using 自定义Uppercomputer_20200727.Nlog;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;

namespace 自定义Uppercomputer_20200727.软件状态悬浮窗
{
    public partial class FloatingForm : Form
    {
        IPLC_interface Mitsubishi_ax;
        IPLC_interface Mitsubishi_rea;
        IPLC_interface MODBUD_tcp;
        IPLC_interface Siemens_rea;
        IPLC_interface OmronFinsCIP;
        IPLC_interface OmronFinsTCP;
        IPLC_interface OmronFinsUDP;
        public FloatingForm()
        {
            InitializeComponent();
            //配置该控件默认参数
            Mitsubishi_ax = new Mitsubishi_axActUtlType();
            Mitsubishi_rea = new Mitsubishi_realize();
            MODBUD_tcp = new MODBUD_TCP();
            Siemens_rea = new Siemens_realize();
            OmronFinsCIP = new OmronFinsCIP();
            OmronFinsTCP = new OmronFinsTcp();
            OmronFinsUDP = new OmronFinsUDP();
        }


        private void FloatingForm_Load(object sender, EventArgs e)
        {
            //窗口默认出现在右上角
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, 0);
            //注册debug输出消息
            LogUtils.DebugEventMessge += ((obj,even) =>
              {
                  this.uiRichTextBox1.AppendText($"来自Debug消息：{obj}\r\n");
                  //让文本框获取焦点
                  this.uiRichTextBox1.Focus();
                  //设置光标的位置到文本尾
                  this.uiRichTextBox1.Select(this.uiRichTextBox1.TextLength, 0);
                  //滚动到控件光标处
                  this.uiRichTextBox1.ScrollToCaret();
              });
        }

        private void uiLight2_Click(object sender, EventArgs e)
        {

        }

        private void PLCtime_Tick(object sender, EventArgs e)
        {
            this.BeginInvoke((EventHandler)delegate
            {
                this.uiLight1.State = Mitsubishi_rea.PLC_ready || Mitsubishi_ax.PLC_ready ? Sunny.UI.UILightState.On : Sunny.UI.UILightState.Off;
                this.uiLight2.State = Siemens_rea.PLC_ready ? Sunny.UI.UILightState.On : Sunny.UI.UILightState.Off;
                this.uiLight3.State = MODBUD_tcp.PLC_ready ? Sunny.UI.UILightState.On : Sunny.UI.UILightState.Off;
                this.uiLight4.State = OmronFinsCIP.PLC_ready || OmronFinsTCP.PLC_ready || OmronFinsUDP.PLC_ready ? Sunny.UI.UILightState.On : Sunny.UI.UILightState.Off;
                this.uiLight5.State= Sunny.UI.UILightState.Off;
                this.uiLight6.State= Sunny.UI.UILightState.Off;
            });
        }
    }
}
