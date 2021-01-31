using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.三菱报文
{
    /// <summary>
    /// 本类主要产生三菱的3E帧标准报文
    /// </summary>
    public class Mitsubishi_message
    {
        /// <summary>
        /// 头部报文包含了副头部 ：5000 网络编号：00 PLC编号：FF IO编号：FF03
        /// </summary>
        private const string Secondary_head = "500000FFFF03";
        /// <summary>
        /// 模块站号默认00
        /// </summary>
        private string Station_number { get; } = "00";
        /// <summary>
        /// 表示等待PLC响应的timeout时间
        /// 高低位互换，实际为0001 即最大等待时间250ms*1=0.25秒
        /// </summary>
        private const string Time = "0100";
        /// <summary>
        /// 批量读取命令与子命令--bit位方式
        /// </summary>
        private const string Batch_read_command_bit = "01040100";
        /// <summary>
        /// 批量读取命令与子命令--Word字方式
        /// </summary>
        private const string Batch_read_command_Word = "01040000";
        /// <summary>
        ///批量写入命令与子命令--bit方式
        /// </summary>
        private const string Batch_write_command_bit = "01140100";
        /// <summary>
        /// 批量写入命令与字命令--Word字方式
        /// </summary>
        private const string Batch_write_command_Word = "01140000";
        /// <summary>
        /// 报文结束命令默认00
        /// </summary>
        private const string End = "00";
        /// <summary>
        ///  bit位读取
        /// </summary>
        /// <param name="message_Bit">需要读取的类型</param>
        /// <param name="location">起始位置</param>
        /// <param name="number">读取个数需要少于255</param>
        /// <returns></returns>
        protected virtual byte[] Read_bit(message_bit message_Bit, int location, byte number)
        {
            string length = "0c00";//请求长度真实数据是000C 转换成10进制是13个字节
            if (message_Bit != message_bit.Y)
            {
                string Data1 = $"{Secondary_head}{Station_number}{length}{Time}{Batch_read_command_bit}{Int_to_String(location)}{Convert.ToString((int)message_Bit, 16)}{ number_to_String(number)}{End}";//获取默认头部帧
                return BytesLHToBytesHL(Data1);
            }
            int len = 0;//Y点读取位置
            switch(location.ToString().Length)
            {
                case 1:
                    len = 0;
                    break;
                case 2:
                    len = Convert.ToInt32(location.ToString().Remove(1, 1))/2;
                    break;
                case 3:
                    len = Convert.ToInt32(location.ToString().Remove(1, 2))/2;
                    break;
            }
            string Data = $"{Secondary_head}{Station_number}{length}{Time}{Batch_read_command_bit}{Int_to_String(len*10,true)}{Convert.ToString((int)message_Bit, 16)}10{End}";//获取默认头部帧
            return BytesLHToBytesHL(Data);
        }
        /// <summary>
        /// 字读取
        /// </summary>
        /// <param name="message_Word">需要读取的类型</param>
        /// <param name="location">起始位置</param>
        /// <param name="number">读取个数需要少于255</param>
        /// <returns></returns>
        protected virtual  byte[] Read_Word(message_Word message_Word,int location, byte number)
        {
            string length = "0C00";//请求长度真实数据是000C 转换成10进制是13个字节
            string Data = $"{Secondary_head}{Station_number}{length}{Time}{Batch_read_command_Word}{Int_to_String(location)}{Convert.ToString((int)message_Word, 16)}{ number_to_String(number)}{End}" ;//获取默认头部帧
            return BytesLHToBytesHL(Data);
        }
        /// <summary>
        /// bit位写入
        /// </summary>
        /// <param name="message_Bit">需要写入的类型</param>
        /// <param name="location">起始位置</param>
        /// <param name="number">需要写入的数据</param>
        /// <returns></returns>
        protected virtual byte[] Write_bit(message_bit message_Bit, int location, bool number)
        {
            int len = 1;
            string length = $"{number_to_String(Convert.ToByte(len + 12))}00";//请求长度真实数据标准12个加上要写入的长度等于真实长度
            if (message_Bit != message_bit.Y|| location<10)
            {
                string Data = $"{Secondary_head}{Station_number}{length}{Time}{Batch_write_command_bit}{Int_to_String(location)}{Convert.ToString((int)message_Bit, 16)}{number_to_String(Convert.ToByte(len))}{End}{bool_to_string(new bool[] { number })}";//获取默认头部帧
                return BytesLHToBytesHL(Data);
            }
            var DATQ = Convert.ToInt32(location.ToString(), 8);//Q系列不需要装换8进制
            string Data1 = $"{Secondary_head}{Station_number}{length}{Time}{Batch_write_command_bit}{Int_to_String(DATQ)}{Convert.ToString((int)message_Bit, 16)}{number_to_String(Convert.ToByte(len))}{End}{bool_to_string(new bool[] { number })}";//获取默认头部帧
            return BytesLHToBytesHL(Data1);
        }
        /// <summary>
        /// 多线圈写入
        /// </summary>
        /// <param name="message_Bit">需要写入的类型</param>
        /// <param name="location">起始位置</param>
        /// <param name="number">需要写入的数据</param>
        /// <returns></returns>
        protected virtual byte[] Write_multi_bit(message_bit message_Bit, int location, bool[] number)
        {
            int len = number.Length;
            string length = $"{number_to_String(Convert.ToByte((number.Length % 2 == 1 ? number.Length + 1 : number.Length )/2+ 12))}00";//请求长度真实数据标准12个加上要写入的长度等于真实长度
            string Data = $"{Secondary_head}{Station_number}{length}{Time}{Batch_write_command_bit}{Int_to_String(location)}{Convert.ToString((int)message_Bit, 16)}{number_to_String(Convert.ToByte(len))}{End}{bool_to_string(number)}";//获取默认头部帧
            return BytesLHToBytesHL(Data);
        }
        /// <summary>
        /// 字写入
        /// </summary>
        /// <param name="message_Word">需要写入的类型</param>
        /// <param name="location">起始位置</param>
        /// <param name="number">需要写入的数据</param>
        /// <returns></returns>
        protected virtual byte[] Write_Word(message_Word message_Word, int location, byte[] number)
        {
            int len = number.Length % 2 == 1 ? number.Length + 1 : number.Length;
            string length = $"{number_to_String(Convert.ToByte(len + 12))}00";//请求长度真实数据标准12个加上要写入的长度等于真实长度
            string Data = $"{Secondary_head}{Station_number}{length}{Time}{Batch_write_command_Word}{Int_to_String(location)}{Convert.ToString((int)message_Word, 16)}{number_to_String(Convert.ToByte(len/2))}{End}{byet_to_String(number)}";//获取默认头部帧
            return BytesLHToBytesHL(Data);
        }
        /// <summary>
        /// 强制执行操作模式
        /// </summary>
        private const string Mandatory_ON = "0300";
        /// <summary>
        /// 不强制执行操作模式--推荐使用
        /// </summary>
        private const string Mandatory_OFF = "0100";
        /// <summary>
        /// 清除模式
        /// </summary>
        private const string Eliminate = "00";
        /// <summary>
        /// 远程Run运行指令
        /// </summary>
        private const string Remote_Run = "01100000";
        /// <summary>
        /// 远程Stop停止指令
        /// </summary>
        private const string Remote_Stop = "02100000";
        /// <summary>
        /// 远程Pause指令
        /// </summary>
        private const string Remote_Pause = "03100000";
        /// <summary>
        /// 远程Rest复位操作
        /// 由于访问目标硬件异常等，有可能无法远程复位。
        ///远程复位时，由于访问目标被复位，有可能外部设备中无法回复响应报文。
        /// </summary>
        private const string Remote_Rest = "06100000";
        /// <summary>
        /// 远程出错代码的初始化
        /// 对象设备使CPU模块的ERR LED熄灯或使缓冲存储器中存储的出错信息
        /// 出错代码初始化的功能。
        /// </summary>
        private const string Remote_Err_Rest = "17160000";

        /// <summary>
        /// 对远程PLC执行Run运行操作--不强制执行
        /// </summary>
        /// <returns></returns>
        protected virtual byte[] PLC_Run_remote()
        {
            string length = $"0A00";//请求长度
            string Data = $"{Secondary_head}{Station_number}{length}{Time}{Remote_Run}{Mandatory_OFF}{Eliminate}{End}";//获取默认头部帧
            return BytesLHToBytesHL(Data);
        }
        /// <summary>
        /// 对远程PLC执行Stop停止操作
        /// </summary>
        /// <returns></returns>
        protected virtual byte[] PLC_Stop_remote()
        {
            string length = $"0800";//请求长度
            string Data = $"{Secondary_head}{Station_number}{length}{Time}{Remote_Stop}{Eliminate}{End}";//获取默认头部帧
            return BytesLHToBytesHL(Data);
        }
        /// <summary>
        /// 对远程PLC进行Pause操作
        /// </summary>
        /// <returns></returns>
        protected virtual byte[] PLC_Pause_remote()
        {
            string length = $"0800";//请求长度
            string Data = $"{Secondary_head}{Station_number}{length}{Time}{Remote_Pause}{Eliminate}{End}";//获取默认头部帧
            return BytesLHToBytesHL(Data);
        }
        /// <summary>
        /// 对远程PLC进行Rest复位操作
        /// </summary>
        /// <returns></returns>
        protected virtual byte[] PLC_Rest_remote()
        {
            string length = $"0800";//请求长度
            string Data = $"{Secondary_head}{Station_number}{length}{Time}{Remote_Rest}{Eliminate}{End}";//获取默认头部帧
            return BytesLHToBytesHL(Data);
        }
        /// <summary>
        /// 对远程PLC进行 出错代码的初始化复位操作
        /// </summary>
        /// <returns></returns> 
        protected virtual byte[] PLC_Rrr_Rest_remote()
        {
            string length = $"0600";//请求长度
            string Data = $"{Secondary_head}{Station_number}{length}{Time}{Remote_Err_Rest}";//获取默认头部帧
            return BytesLHToBytesHL(Data);
        }
        /// <summary>
        /// 把bool布尔状态转换成string字符串
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string bool_to_string(bool[] number)
        {
            string Data = string.Empty;
            foreach (var i in number)
                Data += i ? "1" : "0";
            if (Data.Length % 2 == 1)
                Data += "0";
            return Data;
        }
        /// <summary>
        /// 把需要的数据翻转并且转换成字符串
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string byet_to_String(byte[] number)
        {
            Array.Reverse(number);
            string Data_1 = string.Empty;
            foreach (var i in number)
                Data_1 += number_to_String(i);
            if (number.Length % 2 == 1)
                Data_1 += "00";
            return Data_1;
        }
        /// <summary>
        /// 把需要写入的长度转换成16进制并且自动补0
        /// </summary>
        /// <param name="number">要补码的数据</param>
        /// <returns></returns>
        private string number_to_String(byte number)
        {
            string Data = string.Empty;
            if (Convert.ToString(number, 16).Length == 1)
            {
                Data += "0";
                Data += Convert.ToString(number, 16);
            }
            else
                Data = Convert.ToString(number, 16);
            return Data;
        }
        /// <summary>
        /// 把int类型转换成string并且进行高低位互换
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private string Int_to_String(int location)
        {
            byte[] Data = new byte[3];
            Data = BitConverter.GetBytes(location);
            string Data_1 = string.Empty;
            for(int i=0;i<3;i++)
            {
                if (Data[i].ToString("X").Length ==1)
                    Data_1 += "0" + Data[i].ToString("X");
                else
                    Data_1 += Data[i].ToString("X");
            }
            return  Data_1;
        }
        /// <summary>
        /// 把int类型转换成string并且进行高低位互换
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private string Int_to_String(int location,bool x)
        {
            byte[] Data = new byte[3];
            Data = BitConverter.GetBytes(location);
            string Data_1 = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                if (Data[i].ToString().Length == 1)
                    Data_1 += "0" + Data[i].ToString();
                else
                    Data_1 += Data[i].ToString();
            }
            return Data_1;
        }
        /// <summary>
        /// 把生成的字符串报文转换二进制报文
        /// </summary>
        /// <param name="str">字符串报文</param>
        /// <returns></returns>
        private byte[] BytesLHToBytesHL(string str)
        {
            byte[] bytes = new byte[str.Length / 2];

            for (int i = 0; i < str.Length; i += 2)

                bytes[i / 2] = (byte)Convert.ToByte(str.Substring(i, 2), 16);
            return bytes;
        }
    }
}
