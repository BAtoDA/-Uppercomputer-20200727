using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEngineTest
{
    public class macroinstruction_SerialPort : SerialPort
    {
        /// <summary>
        ///   指示端口是否正常  
        /// </summary>
        public bool Port_OK { get; set; }//指示端口是否正常
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="BaudRate"></param>
        /// <param name="DataBits"></param>
        /// <param name="PortName"></param>
        /// <param name="stopBits"></param>
        /// <param name="parity"></param>
        public macroinstruction_SerialPort(int BaudRate, int DataBits, string PortName, StopBits stopBits, Parity parity)
        {
            this.BaudRate = BaudRate;//设置波特率
            this.DataBits = DataBits;//数据长度
            this.Encoding = Encoding.UTF8;//设置解码类型
            this.PortName = PortName;//端口号
            this.StopBits = stopBits;//停止位数--枚举---StopBits
            this.Parity = parity;//校验-枚举 -parity
          
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        public void Open_Port()
        {
            try
            {
                if (this.IsOpen != true)
                    this.Open();//串口串口
                Port_OK = true;
            }
            catch { Port_OK = false; }
        }
        public void send_Port(string Data)
        {
            try
            {
                this.Write(Data);//发送数据
                Port_OK = true;
            }
            catch
            { Port_OK = false; }
        }
        public byte[] read_Port()
        {
            byte[] Data = new byte[this.BytesToRead];//获取要接收的长度
            try
            {
                this.Read(Data, 0, Data.Length);//读取数据
                Port_OK = true;
                return Data;
            }
            catch { Port_OK = false; return new byte[] { 0 }; }


        }
    }

}
