using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Json;

namespace 服务器端.上位机通讯报文处理
{
    /// <summary>
    /// 用于处理与上位机通讯的报文与解析
    /// </summary>
    public class message
    {
        /// <summary>
        /// 读取上位机时触发事件--传入json 序列化字符串
        /// </summary>
        public event EventHandler Readmessage;
        /// <summary>
        /// 写入上位机时触发事件--传入json 序列化字符串
        /// </summary>
        public event EventHandler Writemessage;
        /// <summary>
        /// 读取上位机M区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        protected byte[] ReadHmiBool(string FormNmae,int address=0,int length=1)
        {
            COPYDATASTRUCT oPYDATASTRUCT = new COPYDATASTRUCT
            {
                Address = address.ToString(),
                length = length.ToString(),
                Equipmenttype = "M",
                function = Convert.ToInt32(Functional.ReadHmi_bool),
                characteristic = FormNmae,
                Type = "Boolean",
                lpData = ""
            };
            oPYDATASTRUCT.cbData = Lengthcalculate(oPYDATASTRUCT);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonStr = jss.Serialize(oPYDATASTRUCT);
            Readmessagetrigger(jsonStr);
            return Encoding.UTF8.GetBytes(jsonStr);
        }
        /// <summary>
        /// 自动解析返回报文 
        /// </summary>
        /// <param name="tresult">传入回复的字节数字</param>
        /// <returns></returns>
        protected Operating<bool[]> ReadHmiBoolresult(byte[] tresult)
        {
            Operating<bool[]> operating = new Operating<bool[]>();
            string Data = Encoding.UTF8.GetString(tresult, 0, tresult.Length);
            Readmessagetrigger(Data);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var result = jss.Deserialize<COPYDATASTRUCTresult>(Data);
           if(result.result)
            {
                var HmiBool = jss.Deserialize<bool[]>(result.Data);
                operating.Content = HmiBool;
                operating.IsSuccess = true;
            }
           else
            {
                operating.IsSuccess = false;
                operating.ErrorCode = result.lpData;
            }
            return operating;
        }
        /// <summary>
        /// 读取上位机D区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        protected byte[] ReadHmiD(string FormNmae, int address = 0, int length = 1, HmiType hmiType=HmiType.Hex )
        {
            COPYDATASTRUCT oPYDATASTRUCT = new COPYDATASTRUCT
            {
                Address = address.ToString(),
                length = length.ToString(),
                Equipmenttype = "D",
                function = Convert.ToInt32(Functional.ReadHmi_D),
                characteristic = FormNmae,
                Type = hmiType.ToString(),
                lpData = ""
            };
            oPYDATASTRUCT.cbData = Lengthcalculate(oPYDATASTRUCT);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonStr = jss.Serialize(oPYDATASTRUCT);
            Readmessagetrigger(jsonStr);
            return Encoding.UTF8.GetBytes(jsonStr);
        }
        /// <summary>
        /// 自动解析返回报文 
        /// 请注意T约束 Hex类型是string约束T int32 约束int  int16 约束Int16 Byte约束byte[]
        /// </summary>
        /// <param name="tresult">传入回复的字节数字</param>
        /// <returns></returns>
        protected Operating< List<T>> ReadHmiDresult<T>(byte[] tresult)
        {
            Operating<List<T>> operating = new Operating<List<T>>();
            string Data = Encoding.UTF8.GetString(tresult, 0, tresult.Length);
            Readmessagetrigger(Data);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var result = jss.Deserialize<COPYDATASTRUCTresult>(Data);
            if (result.result)
            {
                var HmiBool = jss.Deserialize<List<T>>(result.Data);
                operating.Content = HmiBool;
                operating.IsSuccess = true;
            }
            else
            {
                operating.IsSuccess = false;
                operating.ErrorCode = result.lpData;
            }
            return operating;
        }
        /// <summary>
        /// 写入上位机M区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="button_State">请需要写入的状态</param>
        /// <returns></returns>
        protected byte[] WriteHmiBool(string FormNmae, int address = 0,bool button_State=false)
        {
            COPYDATASTRUCT oPYDATASTRUCT = new COPYDATASTRUCT
            {
                Address = address.ToString(),
                length = "1",
                Equipmenttype = "M",
                function = Convert.ToInt32(Functional.WriteHmi_bool),
                characteristic = FormNmae,
                Type = "Boolean",
                lpData = button_State.ToString()
            };
            oPYDATASTRUCT.cbData = Lengthcalculate(oPYDATASTRUCT);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonStr = jss.Serialize(oPYDATASTRUCT);
            Writemessagetrigger(jsonStr);
            return Encoding.UTF8.GetBytes(jsonStr);
        }

        /// <summary>
        /// 写入上位机D区 数据
        /// </summary>
        /// <param name="FormNmae">消息发生者窗口名称</param>
        /// <param name="address">>请输入起始地址</param>
        /// <param name="hmiType">写入类型</param>
        /// <param name="value">写入内容</param>
        /// <returns></returns>
        protected byte[] WriteHmiD(string FormNmae, int address = 0,  HmiType hmiType = HmiType.Hex,string value="0")
        {
            COPYDATASTRUCT oPYDATASTRUCT = new COPYDATASTRUCT
            {
                Address = address.ToString(),
                length = "1",
                Equipmenttype = "D",
                function = Convert.ToInt32(Functional.WriteHmi_D),
                characteristic = FormNmae,
                Type = hmiType.ToString(),
                lpData = value
            };
            oPYDATASTRUCT.cbData = Lengthcalculate(oPYDATASTRUCT);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonStr = jss.Serialize(oPYDATASTRUCT);
            Writemessagetrigger(jsonStr);
            return Encoding.UTF8.GetBytes(jsonStr);
        }
        /// <summary>
        /// 读取PLC--M区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="functional">需要访问的设备功能码</param>
        /// <param name="mitsubishi_Bit">要读取PLC的软元件</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        protected byte[] ReadPLCBool<T>(string FormNmae, Functional functional, T mitsubishi_Bit, string address = "0", int length = 1)where T :Enum
        {
            COPYDATASTRUCT oPYDATASTRUCT = new COPYDATASTRUCT
            {
                Address = address.ToString(),
                length = length.ToString(),
                Equipmenttype = mitsubishi_Bit.ToString(),
                function = Convert.ToInt32(functional),
                characteristic = FormNmae,
                Type = "Boolean",
                lpData = ""
            };
            oPYDATASTRUCT.cbData = Lengthcalculate(oPYDATASTRUCT);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonStr = jss.Serialize(oPYDATASTRUCT);
            Readmessagetrigger(jsonStr);
            return Encoding.UTF8.GetBytes(jsonStr);
        }
        /// <summary>
        /// 读取PLC--D区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="functional">需要访问的设备功能码</param>
        ///  <param name="mitsubishi_D">要读取PLC的软元件</param>
        ///  <param name="numerical">要读取PLC的类型</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="length">请输入要读取的长度</param>
        /// <returns></returns>
        protected byte[] ReadPLCD<T>(string FormNmae, Functional functional, T mitsubishi_D,numerical_format numerical,string address = "0", int length = 1) where T:Enum
        {
            COPYDATASTRUCT oPYDATASTRUCT = new COPYDATASTRUCT
            {
                Address = address.ToString(),
                length = length.ToString(),
                Equipmenttype = mitsubishi_D.ToString(),
                function = Convert.ToInt32(functional),
                characteristic = FormNmae,
                Type = numerical.ToString(),
                lpData = ""
            };
            oPYDATASTRUCT.cbData = Lengthcalculate(oPYDATASTRUCT);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonStr = jss.Serialize(oPYDATASTRUCT);
            Readmessagetrigger(jsonStr);
            return Encoding.UTF8.GetBytes(jsonStr);
        }
        /// <summary>
        /// 写入PLC---M区的值
        /// </summary>
        /// <param name="FormNmae">消息发送者窗口名称</param>
        /// <param name="functional">需要访问的设备功能码</param>
        /// <param name="mitsubishi">写入PLC的软元件</param>
        /// <param name="address">请输入起始地址</param>
        /// <param name="button_State">请需要写入的状态</param>
        /// <returns></returns>
        protected byte[] WritePLCBool<T>(string FormNmae, Functional functional, T mitsubishi, string address = "0", bool button_State = false)where T:Enum
        {
            COPYDATASTRUCT oPYDATASTRUCT = new COPYDATASTRUCT
            {
                Address = address.ToString(),
                length = "1",
                Equipmenttype = mitsubishi.ToString(),
                function = Convert.ToInt32(functional),
                characteristic = FormNmae,
                Type = "Boolean",
                lpData = button_State.ToString()
            };
            oPYDATASTRUCT.cbData = Lengthcalculate(oPYDATASTRUCT);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonStr = jss.Serialize(oPYDATASTRUCT);
            Writemessagetrigger(jsonStr);
            return Encoding.UTF8.GetBytes(jsonStr);
        }
        /// <summary>
        /// 写入PLC--D区 数据
        /// </summary>
        /// <param name="FormNmae">消息发生者窗口名称</param>
        /// <param name="functional">需要访问的设备功能码</param>
        /// <param name="mitsubishi">写入的三菱PLC的软元件</param>
        /// <param name=" numerical">写入的三菱PLC的类型</param>
        /// <param name="address">>请输入起始地址</param>
        /// <param name="value">写入内容</param>
        /// <returns></returns>
        protected byte[] WritePLCD<T>(string FormNmae, Functional functional, T mitsubishi, numerical_format numerical, string address = "0", string value = "0")where T:Enum
        {
            COPYDATASTRUCT oPYDATASTRUCT = new COPYDATASTRUCT
            {
                Address = address.ToString(),
                length = "1",
                Equipmenttype = mitsubishi.ToString(),
                function = Convert.ToInt32(functional),
                characteristic = FormNmae,
                Type = numerical.ToString(),
                lpData = value
            };
            oPYDATASTRUCT.cbData = Lengthcalculate(oPYDATASTRUCT);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonStr = jss.Serialize(oPYDATASTRUCT);
            Writemessagetrigger(jsonStr);
            return Encoding.UTF8.GetBytes(jsonStr);
        }
        /// <summary>
        /// 自动解析返回报文 
        /// </summary>
        /// <param name="tresult">传入回复的字节数字</param>
        /// <returns></returns>
        protected Operating<bool[]> ReadPLCBoolresult(byte[] tresult)
        {
            Operating<bool[]> operating = new Operating<bool[]>();
            string Data = Encoding.UTF8.GetString(tresult, 0, tresult.Length);
            Readmessagetrigger(Data);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var result = jss.Deserialize<COPYDATASTRUCTresult>(Data);
            if (result.result)
            {
                var HmiBool = jss.Deserialize<bool[]>(result.Data);
                operating.Content = HmiBool;
                operating.IsSuccess = true;
            }
            else
            {
                operating.IsSuccess = false;
                operating.ErrorCode = result.lpData;
            }
            return operating;
        }
        /// <summary>
        /// 自动解析返回报文 
        /// 
        /// </summary>
        /// <param name="tresult">传入回复的字节数字</param>
        /// <returns></returns>
        protected Operating<string> ReadPLCDresult(byte[] tresult)
        {
            Operating<string> operating = new Operating<string>();
            string Data = Encoding.UTF8.GetString(tresult, 0, tresult.Length);
            Readmessagetrigger(Data);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var result = jss.Deserialize<COPYDATASTRUCTresult>(Data);
            if (result.result)
            {
                var HmiBool = jss.Deserialize<string>(result.Data);
                operating.Content = HmiBool;
                operating.IsSuccess = true;
            }
            else
            {
                operating.IsSuccess = false;
                operating.ErrorCode = result.lpData;
            }
            return operating;
        }
        /// <summary>
        /// 自动解析返回报文 
        /// </summary>
        /// <param name="tresult">传入回复的字节数字</param>
        /// <returns></returns>
        protected Operating<string> Writeresult(byte[] tresult)
        {
            Operating<string> operating = new Operating<string>();
            string Data = Encoding.UTF8.GetString(tresult, 0, tresult.Length);
            Writemessagetrigger(Data);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var result = jss.Deserialize<COPYDATASTRUCTresult>(Data);
            if (result.result)
            {
                operating.IsSuccess = true;
            }
            else
            {
                operating.IsSuccess = false;
                operating.ErrorCode = result.lpData;
            }
            return operating;
        }

        /// <summary>
        /// 自动计算COPYDATASTRUCT类型的长度
        /// </summary>
        /// <param name="oPYDATASTRUCT">传入对象</param>
        /// <returns></returns>
        private int Lengthcalculate(COPYDATASTRUCT oPYDATASTRUCT)
        {
            //获取所有的字节长度
            byte[] sarr = System.Text.Encoding.Default.GetBytes(oPYDATASTRUCT.Address + oPYDATASTRUCT.cbData + oPYDATASTRUCT.characteristic + oPYDATASTRUCT.Equipmenttype + oPYDATASTRUCT.function  + oPYDATASTRUCT.lpData + oPYDATASTRUCT.Type);
            //获取长度
           return sarr.Length+10;
        }
        /// <summary>
        /// 用于启动读取事件
        /// </summary>
        /// <param name="json"></param>
        private void Readmessagetrigger(string json)
        {
            //判断有无绑定的用户
            if(Readmessage!=null)
            {
                this.Readmessage(json, new EventArgs());
            }
        }
        /// <summary>
        /// 用于启动写入事件
        /// </summary>
        /// <param name="json"></param>
        private void Writemessagetrigger(string json)
        {
            //判断有无绑定的用户
            if (Writemessage != null)
            {
                this.Writemessage(json, new EventArgs());
            }
        }
    }
}
