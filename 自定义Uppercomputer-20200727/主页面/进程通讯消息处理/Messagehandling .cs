using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSEngineTest;
using Nancy.Json;
using PLC通讯规范接口;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using static PLC通讯规范接口.Request;

namespace 自定义Uppercomputer_20200727.主页面
{
    /// <summary>
    /// 处理进程间通讯消息报文
    /// </summary>
    public class Messagehandling
    {
        public Messagehandling()
        {
        }
        public COPYDATASTRUCTresult Manage(COPYDATASTRUCT oPYDATASTRUCT)
        {
            try
            {
                switch (oPYDATASTRUCT.function)
                {
                    //H01---读取上位机内部bool区
                    case 01:
                        //检查输入数据是否正确
                        Regex reg = new Regex(@"^[M]+(m+)?$");
                        if (reg.IsMatch(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            int Address = IsInt(oPYDATASTRUCT.Address) ? Convert.ToInt32(oPYDATASTRUCT.Address) : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            bool type = oPYDATASTRUCT.Type == typeof(bool).Name ? true : throw new Exception($"输入类型:{oPYDATASTRUCT.Type}无法识别 正确类型应为：" + typeof(bool).Name);
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            bool[] Data = new bool[len];
                            Array.Copy(macroinstruction_data<bool>.M_Data, Address, Data, 0, len);
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            string jsonStr = jss.Serialize(Data);
                            return Replymessage(oPYDATASTRUCT, jsonStr, true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 01功能码应为：M");
                    //H02---读取上位机内部D区  
                    case 02:
                        //检查输入数据是否正确
                        Regex regD = new Regex(@"^[D]+(d+)?$");
                        if (regD.IsMatch(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            int Address = IsInt(oPYDATASTRUCT.Address) ? Convert.ToInt32(oPYDATASTRUCT.Address) : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            switch (oPYDATASTRUCT.Type)
                            {
                                case "hex":
                                case "Hex":
                                    List<string> stringdata = new List<string>();
                                    for (int i = 0; i < len; i++)
                                    {
                                        if (macroinstruction_data<int>.D_Data[Address + i] != null)
                                            stringdata.Add(macroinstruction_data<int>.D_Data[Address + i].ToString());
                                        else
                                            stringdata.Add("0");
                                    }
                                    return Replymessage(oPYDATASTRUCT, jss.Serialize(stringdata), true);

                                case "int32":
                                case "Int32":
                                    List<int> int32data = new List<int>();
                                    for (int i = 0; i < len; i++)
                                    {
                                        if (macroinstruction_data<int>.D_Data[Address + i] != null)
                                            int32data.Add(IsInt(macroinstruction_data<int>.D_Data[Address + i].ToString()) != true ? Convert.ToInt32(macroinstruction_data<int>.D_Data[Address + i].ToString(), 16) : Convert.ToInt32(macroinstruction_data<int>.D_Data[Address + i]));
                                        else
                                            int32data.Add(0);
                                    }
                                    return Replymessage(oPYDATASTRUCT, jss.Serialize(int32data), true);
                                case "int16":
                                case "Int16":
                                    List<Int16> int16data = new List<Int16>();
                                    for (int i = 0; i < len; i++)
                                    {
                                        if (macroinstruction_data<int>.D_Data[Address + i] != null)
                                            int16data.Add(IsInt(macroinstruction_data<int>.D_Data[Address + i].ToString()) != true ? Convert.ToInt16(macroinstruction_data<int>.D_Data[Address + i].ToString(), 16) : Convert.ToInt16(macroinstruction_data<int>.D_Data[Address + i]));
                                        else
                                            int16data.Add(0);
                                    }
                                    return Replymessage(oPYDATASTRUCT, jss.Serialize(int16data), true);
                                case "byte":
                                case "Byte":
                                    List<byte[]> byetdata = new List<byte[]>();
                                    for (int i = 0; i < len;)
                                    {
                                        //先判断是否全数字
                                        if (macroinstruction_data<int>.D_Data[Address + (i / 4)] != null)
                                            byetdata.Add(BitConverter.GetBytes(IsInt(macroinstruction_data<int>.D_Data[Address + (i / 4)].ToString()) ? Convert.ToInt32(macroinstruction_data<int>.D_Data[Address + (i / 4)]) : Convert.ToInt32(macroinstruction_data<int>.D_Data[Address + (i / 4)].ToString(), 16)));
                                        else
                                            byetdata.Add(BitConverter.GetBytes(0));
                                        i = i == 0 ? 4 : i += i * 4;
                                    }
                                    return Replymessage(oPYDATASTRUCT, jss.Serialize(byetdata), true);
                                default:
                                    throw new Exception($"输入类型:{oPYDATASTRUCT.Type}无法识别 正确类型应为：{typeof(int).Name}或者{typeof(Int16).Name}或者{typeof(byte)}");
                                    break;
                            }

                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 02功能码应为：D");

                    // H03---写入上位机内部BOOL区
                    case 03:
                        //检查输入数据是否正确
                        Regex reg03 = new Regex(@"^[M]+(m+)?$");
                        if (reg03.IsMatch(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            int Address = IsInt(oPYDATASTRUCT.Address) ? Convert.ToInt32(oPYDATASTRUCT.Address) : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            bool type = oPYDATASTRUCT.Type == typeof(bool).Name ? true : throw new Exception($"输入类型:{oPYDATASTRUCT.Type}无法识别 正确类型应为：" + typeof(bool).Name);
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            bool result;
                            macroinstruction_data<bool>.M_Data[Address] = oPYDATASTRUCT.lpData == null ? false : bool.TryParse(oPYDATASTRUCT.lpData, out result) ? Convert.ToBoolean(oPYDATASTRUCT.lpData) : throw new Exception($"输入内容：{oPYDATASTRUCT.lpData}转换bool类型失败 正确类型为：true false");
                            return Replymessage(oPYDATASTRUCT, "", true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 03功能码应为：M");
                    //H04--写入上位机内部D区   
                    case 04:
                        //检查输入数据是否正确
                        Regex regwriD = new Regex(@"^[D]+(d+)?$");
                        if (regwriD.IsMatch(oPYDATASTRUCT.Equipmenttype))
                        {
                            int Address = IsInt(oPYDATASTRUCT.Address) ? Convert.ToInt32(oPYDATASTRUCT.Address) : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            switch (oPYDATASTRUCT.Type)
                            {
                                case "hex":
                                case "Hex":
                                    macroinstruction_data<int>.D_Data[Address] = oPYDATASTRUCT.lpData ?? "0";
                                    return Replymessage(oPYDATASTRUCT, "", true);

                                case "int32":
                                case "Int32":
                                    macroinstruction_data<int>.D_Data[Address] = Convert.ToInt32(oPYDATASTRUCT.lpData ?? "0");
                                    return Replymessage(oPYDATASTRUCT, "", true);
                                case "int16":
                                case "Int16":
                                    macroinstruction_data<Int16>.D_Data[Address] = Convert.ToInt16(oPYDATASTRUCT.lpData ?? "0");
                                    return Replymessage(oPYDATASTRUCT, "", true);
                                case "byte":
                                case "Byte":
                                    macroinstruction_data<byte>.D_Data[Address] = Convert.ToByte(oPYDATASTRUCT.lpData ?? "0");
                                    return Replymessage(oPYDATASTRUCT, "", true);
                                default:
                                    throw new Exception($"输入类型:{oPYDATASTRUCT.Type}无法识别 正确类型应为：{typeof(int).Name}或者{typeof(Int16).Name}或者{typeof(byte)}");
                            }

                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 04功能码应为：D");
                    //H05 读取外部PLC链接设备BOOL区  （三菱PLC ）
                    case 05:
                        //检查输入数据是否正确
                        if (IsPLCType<Mitsubishi_bit>(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            //检查输入数据是否正确
                            Regex RegMitsubit = new Regex(@"^[A-Fa-z0-9]+([0-9]+)?$");
                            string Address = RegMitsubit.IsMatch(oPYDATASTRUCT.Address) ? oPYDATASTRUCT.Address : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = oPYDATASTRUCT.Type == typeof(bool).Name ? true : throw new Exception($"输入类型:{oPYDATASTRUCT.Type}无法识别 正确类型应为：" + typeof(bool).Name);
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            bool[] Data = new bool[len];
                            IPLC_interface Mitsubishi_rea = new Mitsubishi_realize();
                            if (Mitsubishi_rea.PLC_ready)
                            {
                                for (int i = 0; i < len; i++)
                                {
                                    if (IsInt(Address))
                                    {
                                        Data[i] = Mitsubishi_rea.PLC_read_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), (Convert.ToInt32(Address) + i).ToString())[0];
                                    }
                                    else
                                    {
                                        string addres = (Convert.ToInt32(Address, 16) + i).ToString("X");
                                        Data[i] = Mitsubishi_rea.PLC_read_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), addres)[0];
                                    }
                                }
                            }
                            else
                                throw new Exception($"三菱PLC未准备好 异常代码为：{Mitsubishi_rea.PLCerr_content ?? "0"}");
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            string jsonStr = jss.Serialize(Data);
                            return Replymessage(oPYDATASTRUCT, jsonStr, true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 05功能码应为：{EnumValue<Mitsubishi_bit>()}");
                    // H06---读取外部PLC链接设备D区  （三菱PLC ） 
                    case 06:
                        //检查输入数据是否正确
                        if (IsPLCType<Mitsubishi_D>(oPYDATASTRUCT.Equipmenttype))
                        {
                            int Address = IsInt(oPYDATASTRUCT.Address) ? Convert.ToInt32(oPYDATASTRUCT.Address) : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            IPLC_interface Mitsubishi_rea = new Mitsubishi_realize();
                            _ = IsPLCType<numerical_format>(oPYDATASTRUCT.Type.Trim()) ? true : throw new Exception($"输入类型：{oPYDATASTRUCT.Type} 错误 正确应为：{EnumValue<numerical_format>()}");
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            if (Mitsubishi_rea.PLC_ready)
                            {
                                string jsonStr = jss.Serialize(Mitsubishi_rea.PLC_read_D_register_bit(oPYDATASTRUCT.Equipmenttype, (Address).ToString(), (numerical_format)Enum.Parse(typeof(numerical_format), oPYDATASTRUCT.Type.Trim()), oPYDATASTRUCT.length));
                                return Replymessage(oPYDATASTRUCT, jsonStr, true);
                            }
                            else
                                throw new Exception($"三菱PLC未准备好 异常代码为：{Mitsubishi_rea.PLCerr_content ?? "0"}");
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 06功能码应为：{EnumValue<Mitsubishi_D>()}");
                    //H07 写入外部PLC链接设备bool区 （三菱PLC ）
                    case 07:
                        //检查输入数据是否正确
                        if (IsPLCType<Mitsubishi_bit>(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            //检查输入数据是否正确
                            Regex RegMitsubit = new Regex(@"^[A-Fa-z0-9]+([0-9]+)?$");
                            string Address = RegMitsubit.IsMatch(oPYDATASTRUCT.Address) ? oPYDATASTRUCT.Address : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = oPYDATASTRUCT.Type == typeof(bool).Name ? true : throw new Exception($"输入类型:{oPYDATASTRUCT.Type}无法识别 正确类型应为：" + typeof(bool).Name);
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            _ = IsPLCType<Button_state>(oPYDATASTRUCT.lpData) == false ? throw new Exception($"输入内容{oPYDATASTRUCT.lpData}不正确 正确应为：{EnumValue<Button_state>()}") : oPYDATASTRUCT.lpData;
                            IPLC_interface Mitsubishi_rea = new Mitsubishi_realize();
                            if (Mitsubishi_rea.PLC_ready)
                            {
                                for (int i = 0; i < len; i++)
                                {
                                    if (IsInt(Address))
                                    {
                                        Mitsubishi_rea.PLC_write_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), (Convert.ToInt32(Address) + i).ToString(), (Button_state)Enum.Parse(typeof(Button_state), oPYDATASTRUCT.lpData));
                                    }
                                    else
                                    {
                                        string addres = (Convert.ToInt32(Address, 16) + i).ToString("X");
                                        Mitsubishi_rea.PLC_write_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), addres, (Button_state)Enum.Parse(typeof(Button_state), oPYDATASTRUCT.lpData));
                                    }
                                }
                            }
                            else
                                throw new Exception($"三菱PLC未准备好 异常代码为：{Mitsubishi_rea.PLCerr_content ?? "0"}");
                            return Replymessage(oPYDATASTRUCT, "", true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 07功能码应为：{EnumValue<Mitsubishi_bit>()}");
                    //H08 写入外部PLC链接设备D区（三菱PLC ）
                    case 08:
                        //检查输入数据是否正确
                        if (IsPLCType<Mitsubishi_D>(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            //检查输入数据是否正确
                            Regex RegMitsubit = new Regex(@"^[A-Fa-z0-9]+([0-9]+)?$");
                            string Address = RegMitsubit.IsMatch(oPYDATASTRUCT.Address) ? oPYDATASTRUCT.Address : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = IsPLCType<numerical_format>(oPYDATASTRUCT.Type.Trim()) ? true : throw new Exception($"输入类型：{oPYDATASTRUCT.Type} 错误 正确应为：{EnumValue<numerical_format>()}");
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            _ = oPYDATASTRUCT.lpData == null ? throw new Exception("输入内容不能为空") : Convert.ToInt32(oPYDATASTRUCT.lpData);
                            IPLC_interface Mitsubishi_rea = new Mitsubishi_realize();
                            if (Mitsubishi_rea.PLC_ready)
                            {
                                for (int i = 0; i < len; i++)
                                {
                                    if (IsInt(Address))
                                    {
                                        Mitsubishi_rea.PLC_write_D_register(oPYDATASTRUCT.Equipmenttype.Trim(), (Convert.ToInt32(Address) + i).ToString(), oPYDATASTRUCT.lpData ?? "00", (numerical_format)Enum.Parse(typeof(numerical_format), oPYDATASTRUCT.Type));
                                    }
                                }
                            }
                            else
                                throw new Exception($"三菱PLC未准备好 异常代码为：{Mitsubishi_rea.PLCerr_content ?? "0"}");
                            return Replymessage(oPYDATASTRUCT, "", true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 08功能码应为：{EnumValue<Mitsubishi_D>()}");
                    //  H09---读取外部PLC链接设备BOOL区  （西门子PLC）
                    case 09:
                        //检查输入数据是否正确
                        if (IsPLCType<Siemens_bit>(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            //检查输入数据是否正确
                            Regex RegMitsubit = new Regex(@"^[0-9]+(.+[0-9]+)?$");
                            string Address = RegMitsubit.IsMatch(oPYDATASTRUCT.Address) ? oPYDATASTRUCT.Address : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = oPYDATASTRUCT.Type == typeof(bool).Name ? true : throw new Exception($"输入类型:{oPYDATASTRUCT.Type}无法识别 正确类型应为：" + typeof(bool).Name);
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            bool[] Data = new bool[len];
                            IPLC_interface Siemens_rea = new Siemens_realize();
                            if (Siemens_rea.PLC_ready)
                            {
                                for (int i = 0; i < len; i++)
                                {
                                    if (IsInt(Address))
                                    {
                                        Data[i] = Siemens_rea.PLC_read_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), (Convert.ToInt32(Address) + i).ToString())[0];
                                    }
                                    else
                                    {
                                        string addres = (Convert.ToSingle(Address) + i).ToString();
                                        Data[i] = Siemens_rea.PLC_read_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), addres)[0];
                                    }
                                }
                            }
                            else
                                throw new Exception($"西门子PLC未准备好 异常代码为：{Siemens_rea.PLCerr_content ?? "0"}");
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            string jsonStr = jss.Serialize(Data);
                            return Replymessage(oPYDATASTRUCT, jsonStr, true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 09功能码应为：{EnumValue<Siemens_bit>()}");
                    // H10---读取外部PLC链接设备D区  （西门子PLC） 
                    case 10:
                        //检查输入数据是否正确
                        if (IsPLCType<Siemens_D>(oPYDATASTRUCT.Equipmenttype))
                        {
                            //检查输入数据是否正确
                            Regex RegMitsubit = new Regex(@"^[0-9]+(.+[0-9]+)?$");
                            string Address = RegMitsubit.IsMatch(oPYDATASTRUCT.Address) ? oPYDATASTRUCT.Address : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            IPLC_interface Siemens_rea = new Siemens_realize();
                            _ = IsPLCType<numerical_format>(oPYDATASTRUCT.Type.Trim()) ? true : throw new Exception($"输入类型：{oPYDATASTRUCT.Type} 错误 正确应为：{EnumValue<numerical_format>()}");
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            if (Siemens_rea.PLC_ready)
                            {
                                string jsonStr = jss.Serialize(Siemens_rea.PLC_read_D_register_bit(oPYDATASTRUCT.Equipmenttype, (Address).ToString(), (numerical_format)Enum.Parse(typeof(numerical_format), oPYDATASTRUCT.Type.Trim()), oPYDATASTRUCT.length));
                                return Replymessage(oPYDATASTRUCT, jsonStr, true);
                            }
                            else
                                throw new Exception($"三菱PLC未准备好 异常代码为：{Siemens_rea.PLCerr_content ?? "0"}");
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 06功能码应为：{EnumValue<Siemens_D>()}");
                    //  H11---写入外部PLC链接设备bool区  （西门子PLC） 
                    case 11:
                        //检查输入数据是否正确
                        if (IsPLCType<Siemens_bit>(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            //检查输入数据是否正确
                            Regex RegMitsubit = new Regex(@"^[0-9]+(.+[0-9]+)?$");
                            string Address = RegMitsubit.IsMatch(oPYDATASTRUCT.Address) ? oPYDATASTRUCT.Address : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = oPYDATASTRUCT.Type == typeof(bool).Name ? true : throw new Exception($"输入类型:{oPYDATASTRUCT.Type}无法识别 正确类型应为：" + typeof(bool).Name);
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            _ = IsPLCType<Button_state>(oPYDATASTRUCT.lpData) == false ? throw new Exception($"输入内容{oPYDATASTRUCT.lpData}不正确 正确应为：{EnumValue<Button_state>()}") : oPYDATASTRUCT.lpData;
                            IPLC_interface Mitsubishi_rea = new Mitsubishi_realize();
                            if (Mitsubishi_rea.PLC_ready)
                            {
                                for (int i = 0; i < len; i++)
                                {
                                    if (IsInt(Address))
                                    {
                                        Mitsubishi_rea.PLC_write_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), (Convert.ToInt32(Address) + i).ToString(), (Button_state)Enum.Parse(typeof(Button_state), oPYDATASTRUCT.lpData));
                                    }
                                    else
                                    {
                                        string addres = (Convert.ToInt32(Address, 16) + i).ToString("X");
                                        Mitsubishi_rea.PLC_write_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), addres, (Button_state)Enum.Parse(typeof(Button_state), oPYDATASTRUCT.lpData));
                                    }
                                }
                            }
                            else
                                throw new Exception($"西门子PLC未准备好 异常代码为：{Mitsubishi_rea.PLCerr_content ?? "0"}");
                            return Replymessage(oPYDATASTRUCT, "", true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 11功能码应为：{EnumValue<Siemens_bit>()}");
                    //H12 写入外部PLC链接设备D区  （西门子PLC） 
                    case 12:
                        //检查输入数据是否正确
                        if (IsPLCType<Siemens_D>(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            //检查输入数据是否正确
                            Regex RegMitsubit = new Regex(@"^[A-Fa-z0-9]+(.+[0-9]+)?$");
                            string Address = RegMitsubit.IsMatch(oPYDATASTRUCT.Address) ? oPYDATASTRUCT.Address : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = IsPLCType<numerical_format>(oPYDATASTRUCT.Type.Trim()) ? true : throw new Exception($"输入类型：{oPYDATASTRUCT.Type} 错误 正确应为：{EnumValue<numerical_format>()}");
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            _ = oPYDATASTRUCT.lpData == null ? throw new Exception("输入内容不能为空") : Convert.ToInt32(oPYDATASTRUCT.lpData);
                            IPLC_interface Siemens_rea = new Siemens_realize();
                            if (Siemens_rea.PLC_ready)
                            {
                                for (int i = 0; i < len; i++)
                                {
                                    if (IsInt(Address))
                                    {
                                        Siemens_rea.PLC_write_D_register(oPYDATASTRUCT.Equipmenttype.Trim(), (Convert.ToInt32(Address) + i).ToString(), oPYDATASTRUCT.lpData ?? "00", (numerical_format)Enum.Parse(typeof(numerical_format), oPYDATASTRUCT.Type));
                                    }
                                }
                            }
                            else
                                throw new Exception($"西门子PLC未准备好 异常代码为：{Siemens_rea.PLCerr_content ?? "0"}");
                            return Replymessage(oPYDATASTRUCT, "", true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 12功能码应为：{EnumValue<Siemens_D>()}");
                    //H13 读取外部PLC链接设备BOOL区  （Modbsu tcp PLC）
                    case 13:
                        //检查输入数据是否正确
                        if (IsPLCType<Modbus_TCP_bit>(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            //检查输入数据是否正确
                            Regex RegMitsubit = new Regex(@"^[A-Fa-z0-9]+([0-9]+)?$");
                            string Address = RegMitsubit.IsMatch(oPYDATASTRUCT.Address) ? oPYDATASTRUCT.Address : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = oPYDATASTRUCT.Type == typeof(bool).Name ? true : throw new Exception($"输入类型:{oPYDATASTRUCT.Type}无法识别 正确类型应为：" + typeof(bool).Name);
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            bool[] Data = new bool[len];
                            IPLC_interface MODBUD_rea = new MODBUD_TCP();
                            if (MODBUD_rea.PLC_ready)
                            {
                                for (int i = 0; i < len; i++)
                                {
                                    if (IsInt(Address))
                                    {
                                        Data[i] = MODBUD_rea.PLC_read_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), (Convert.ToInt32(Address) + i).ToString())[0];
                                    }
                                    else
                                    {
                                        string addres = (Convert.ToInt32(Address, 16) + i).ToString("X");
                                        Data[i] = MODBUD_rea.PLC_read_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), addres)[0];
                                    }
                                }
                            }
                            else
                                throw new Exception($"Modbus TCPPLC未准备好 异常代码为：{MODBUD_rea.PLCerr_content ?? "0"}");
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            string jsonStr = jss.Serialize(Data);
                            return Replymessage(oPYDATASTRUCT, jsonStr, true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 13功能码应为：{EnumValue<Modbus_TCP_bit>()}");
                    // H06---读取外部PLC链接设备D区  （Modbsu tcp PLC） 
                    case 14:
                        //检查输入数据是否正确
                        if (IsPLCType<Modbus_TCP_D>(oPYDATASTRUCT.Equipmenttype))
                        {
                            int Address = IsInt(oPYDATASTRUCT.Address) ? Convert.ToInt32(oPYDATASTRUCT.Address) : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            IPLC_interface MODBUD_rea = new MODBUD_TCP();
                            _ = IsPLCType<numerical_format>(oPYDATASTRUCT.Type.Trim()) ? true : throw new Exception($"输入类型：{oPYDATASTRUCT.Type} 错误 正确应为：{EnumValue<numerical_format>()}");
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            if (MODBUD_rea.PLC_ready)
                            {
                                string jsonStr = jss.Serialize(MODBUD_rea.PLC_read_D_register_bit(oPYDATASTRUCT.Equipmenttype, (Address).ToString(), (numerical_format)Enum.Parse(typeof(numerical_format), oPYDATASTRUCT.Type.Trim()), oPYDATASTRUCT.length));
                                return Replymessage(oPYDATASTRUCT, jsonStr, true);
                            }
                            else
                                throw new Exception($"Modbus Tcp PLC未准备好 异常代码为：{MODBUD_rea.PLCerr_content ?? "0"}");
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 14功能码应为：{EnumValue<Modbus_TCP_D>()}");
                    //H15 写入外部PLC链接设备bool区  （Modbsu tcp PLC）
                    case 15:
                        //检查输入数据是否正确
                        if (IsPLCType<Modbus_TCP_bit>(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            //检查输入数据是否正确
                            Regex RegMitsubit = new Regex(@"^[A-Fa-z0-9]+([0-9]+)?$");
                            string Address = RegMitsubit.IsMatch(oPYDATASTRUCT.Address) ? oPYDATASTRUCT.Address : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = oPYDATASTRUCT.Type == typeof(bool).Name ? true : throw new Exception($"输入类型:{oPYDATASTRUCT.Type}无法识别 正确类型应为：" + typeof(bool).Name);
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            _ = IsPLCType<Button_state>(oPYDATASTRUCT.lpData) == false ? throw new Exception($"输入内容{oPYDATASTRUCT.lpData}不正确 正确应为：{EnumValue<Button_state>()}") : oPYDATASTRUCT.lpData;
                            IPLC_interface MODBUD_rea = new MODBUD_TCP();
                            if (MODBUD_rea.PLC_ready)
                            {
                                for (int i = 0; i < len; i++)
                                {
                                    if (IsInt(Address))
                                    {
                                        MODBUD_rea.PLC_write_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), (Convert.ToInt32(Address) + i).ToString(), (Button_state)Enum.Parse(typeof(Button_state), oPYDATASTRUCT.lpData));
                                    }
                                    else
                                    {
                                        string addres = (Convert.ToInt32(Address, 16) + i).ToString("X");
                                        MODBUD_rea.PLC_write_M_bit(oPYDATASTRUCT.Equipmenttype.Trim(), addres, (Button_state)Enum.Parse(typeof(Button_state), oPYDATASTRUCT.lpData));
                                    }
                                }
                            }
                            else
                                throw new Exception($"Modbus Tcp PLC未准备好 异常代码为：{MODBUD_rea.PLCerr_content ?? "0"}");
                            return Replymessage(oPYDATASTRUCT, "", true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 15功能码应为：{EnumValue<Modbus_TCP_bit>()}");
                    //H16 写入外部PLC链接设备D区  （Modbsu tcp PLC）
                    case 16:
                        //检查输入数据是否正确
                        if (IsPLCType<Modbus_TCP_D>(oPYDATASTRUCT.Equipmenttype.Trim()))
                        {
                            //检查输入数据是否正确
                            Regex RegMitsubit = new Regex(@"^[A-Fa-z0-9]+([0-9]+)?$");
                            string Address = RegMitsubit.IsMatch(oPYDATASTRUCT.Address) ? oPYDATASTRUCT.Address : throw new Exception($"输入{oPYDATASTRUCT.Address}地址错误 正常应为：1");
                            _ = IsPLCType<numerical_format>(oPYDATASTRUCT.Type.Trim()) ? true : throw new Exception($"输入类型：{oPYDATASTRUCT.Type} 错误 正确应为：{EnumValue<numerical_format>()}");
                            int len = IsInt(oPYDATASTRUCT.length) ? Convert.ToInt32(oPYDATASTRUCT.length) : throw new Exception($"输入{oPYDATASTRUCT.length}长度错误 正确类型应为： 1");
                            _ = oPYDATASTRUCT.lpData == null ? throw new Exception("输入内容不能为空") : Convert.ToInt32(oPYDATASTRUCT.lpData);
                            IPLC_interface MODBUD_rea = new MODBUD_TCP();
                            if (MODBUD_rea.PLC_ready)
                            {
                                for (int i = 0; i < len; i++)
                                {
                                    if (IsInt(Address))
                                    {
                                        MODBUD_rea.PLC_write_D_register(oPYDATASTRUCT.Equipmenttype.Trim(), (Convert.ToInt32(Address) + i).ToString(), oPYDATASTRUCT.lpData ?? "00", (numerical_format)Enum.Parse(typeof(numerical_format), oPYDATASTRUCT.Type));
                                    }
                                }
                            }
                            else
                                throw new Exception($"Modbus Tcp PLC未准备好 异常代码为：{MODBUD_rea.PLCerr_content ?? "0"}");
                            return Replymessage(oPYDATASTRUCT, "", true);
                        }
                        else
                            throw new Exception($"输入设备功能码错误：{oPYDATASTRUCT.Equipmenttype} 16功能码应为：{EnumValue<Modbus_TCP_D>()}");
                    default:
                        return Replymessage(oPYDATASTRUCT, $"Err报警内容:未找到功能码为：{oPYDATASTRUCT.function} 请确定一下功能码是否正确", false);
                }
            }
            catch(Exception e)
            {
                return Replymessage(oPYDATASTRUCT, $"Err报警内容{e.Message}", false);
            }
        }
        /// <summary>
        /// 读取枚举的值
        /// </summary>
        /// <returns></returns>
        private string EnumValue<T>()
        {
            string err = " ";
            foreach (var i in Enum.GetValues(typeof(T)))
                err += i.ToString() + "  ";
            return err;
        }
        /// <summary>
        /// 判断PLC读写类型 是否正确
        /// 符合返回true  不符合false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsPLCType<T>(string value)
        {
            object data = null;
            try
            {
                data = Enum.Parse(typeof(T), value);
            }
            catch { }
            return data == null ? false : true;
        }
        /// <summary>
        /// 判断数据是否int类型
        /// </summary>
        /// <returns></returns>
        private bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        public COPYDATASTRUCTresult Replymessage(COPYDATASTRUCT oPYDATASTRUCT,string Value,bool result)
        {
            COPYDATASTRUCTresult tresult=new COPYDATASTRUCTresult();
            tresult.characteristic = oPYDATASTRUCT.characteristic;
            tresult.Equipmenttype = oPYDATASTRUCT.Equipmenttype;
            tresult.Data = Value;
            tresult.Address = oPYDATASTRUCT.Address;
            tresult.function = oPYDATASTRUCT.function;
            tresult.lpData = oPYDATASTRUCT.lpData;
            tresult.result = result;
            tresult.Type = oPYDATASTRUCT.Type;
            tresult.length = oPYDATASTRUCT.length;
            //获取所有的字节长度
            byte[] sarr = System.Text.Encoding.Default.GetBytes(tresult.characteristic + tresult.Equipmenttype + tresult.Data + tresult.Address + tresult.function + tresult.lpData + tresult.result + tresult.Type + tresult.length);
            //获取长度
            int len = sarr.Length;
            tresult.cbData = len + 4;
            return tresult;
        }
        /// <summary>
        /// 计算发送字节的长度
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vale"></param>
        /// <returns></returns>
        public int Messagelen(COPYDATASTRUCTresult tresult)
        {
            //获取所有的字节长度
            byte[] sarr = System.Text.Encoding.Default.GetBytes(tresult.characteristic + tresult.Equipmenttype + tresult.Data + tresult.Address + tresult.function + tresult.lpData + tresult.result + tresult.Type + tresult.length);
            //获取长度
            int len = sarr.Length+4;
            return len;
        }
    }
}
