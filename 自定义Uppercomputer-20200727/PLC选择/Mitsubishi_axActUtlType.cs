using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using AxActUtlTypeLib;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using CCWin.SkinClass;
using CSEngineTest;
using PLC通讯规范接口;

namespace 自定义Uppercomputer_20200727.PLC选择
{
    /// <summary>
    /// 实现三菱仿真--与GX2 GX3 下位PLC等
    /// </summary>
    class Mitsubishi_axActUtlType : PLC_public_Class, IPLC_interface, macroinstruction_PLC_interface
    {
        /// <summary>
        /// /IP地址
        /// </summary>
        public IPEndPoint IPEndPoint { get; set; }//IP地址
        string pattern;
        static AxActUtlTypeLib.AxActUtlType axActUtlType;//COM组件控件
        static private bool PLC_ready;//内部PLC状态
        static private int PLCerr_code;//内部报警代码
        static private string PLCerr_content;//内部报警内容
        static bool PLC_Reconnection;//重连标志位
        static string PLC_type = "TCP";//链接类型
        //实现接口的属性
        /// <summary>
        /// 三菱Mitsubishi PLC状态
        /// </summary>
        bool IPLC_interface.PLC_ready { get => PLC_ready; } //PLC状态
        /// <summary>
        /// 宏指令 三菱Mitsubishi PLC状态
        /// </summary>
        bool macroinstruction_PLC_interface.PLC_ready { get => PLC_ready; } //PLC状态
        /// <summary>
        /// 三菱Mitsubishi PLC报警代码
        /// </summary>
        int IPLC_interface.PLCerr_code { get => PLCerr_code; }//PLC报警代码
        /// <summary>
        /// 宏指令 三菱Mitsubishi PLC报警代码 
        /// </summary>
        int macroinstruction_PLC_interface.PLCerr_code { get => PLCerr_code; }//PLC报警代码
        /// <summary>
        ///三菱Mitsubishi PLC报警内容
        /// </summary>
        string IPLC_interface.PLCerr_content { get => PLCerr_content; }//PLC报警内容
        bool IPLC_interface.PLC_Reconnection { get {return PLC_Reconnection; } set { PLC_Reconnection = value; } }
        string IPLC_interface.PLC_type { get { return PLC_type; } set { PLC_type = value; } }
        /// <summary>
        /// 宏指令  三菱Mitsubishi PLC报警内容
        /// </summary>
        string macroinstruction_PLC_interface.PLCerr_content { get => PLCerr_content; }//PLC报警内容
        /// <summary>
        /// 构造函数---初始化---open
        /// </summary>
        /// <param name="iPEndPoint"></param>
        /// <param name="pattern"></param>
        /// <param name="axActUtlType"></param>
        public Mitsubishi_axActUtlType(IPEndPoint iPEndPoint,string pattern, AxActUtlType axActUtlType)//构造函数---初始化---open
        {
            this.IPEndPoint = iPEndPoint;
            this.pattern = pattern;
            //Mitsubishi_axActUtlType.axActUtlType = axActUtlType;
            Mitsubishi_axActUtlType.axActUtlType = axActUtlType;
        }
        /// <summary>
        /// 构造函数---多态
        /// </summary>
        public Mitsubishi_axActUtlType()//构造函数---多态
        {

        }
        /// <summary>
        /// 三菱Mitsubishi  打开PLC
        /// </summary>
        /// <returns></returns>
        string IPLC_interface.PLC_open()
        {
            try
            {
                //利用Communication DLL库实现
                axActUtlType.ActLogicalStationNumber = Convert.ToInt32(1);//填设置的逻辑站号
                axActUtlType.ActPassword = " ";//填设置的逻辑密码
                if (axActUtlType.Open() > 0)
                {
                    MessageBox.Show("链接PLC异常");
                    PLC_ready = false;//PLC开放异常
                    return "链接PLC异常";//尝试连接PLC，如果连接成功则返回值为0
                }
                else
                    PLC_ready = true;//PLC开放正常
                return "已成功链接到" + this.IPEndPoint.Address;
            }
            catch(Exception e)
            {
                err(e);//异常处理
                return "链接PLC异常";//尝试连接PLC，如果连接成功则返回值为0
            }
        }
        public void PLC_Close()//切断PLC链接
        {
            err(new Exception("切断PLC链接"));
        }
        /// <summary>
        /// 三菱Mitsubishi  读取PLC
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        List<bool> IPLC_interface.PLC_read_M_bit(string Name, string id)//读取PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        {
            short[] import = new short[2];//寄存器
            string[] segmentation = Name.Split('_');//分割字符串
            string[] segmentation_1 = id.Split('.');//分割字符串
            axActUtlType.ReadDeviceBlock2((segmentation.Length>1? segmentation[0]+ segmentation_1[0]: Name+id), import.Length, out import[0]);//获取三菱PLC输入状态
            //判断是否D-bit类型
            if (segmentation_1.Length > 1)
            {
                List<bool> Romv = bit_public(import);//先获取数据
                for (int i = 0; i < segmentation_1[1].ToInt32(); i++) Romv.RemoveAt(i);//移除不需要的数据
                return Romv;//返回数据
            }
            else
            {
                if(import[0]==-1)return new List<bool>(){ true};//如果读取数据溢出-负数直接返回
                return bit_public(import);//返回数据
            }
        }
        /// <summary>
        /// 宏指令  三菱Mitsubishi  读取PLC
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        List<bool> macroinstruction_PLC_interface.PLC_read_M_bit(string Name, string id)
        {      
            short[] import = new short[2];//寄存器
            if (PLC_ready != true) return bit_public(import);//PLC未准备好 返回数据
            string[] segmentation = Name.Split('_');//分割字符串
            string[] segmentation_1 = id.Split('.');//分割字符串
            axActUtlType.ReadDeviceBlock2((segmentation.Length > 1 ? segmentation[0] + segmentation_1[0] : Name + id), import.Length, out import[0]);//获取三菱PLC输入状态
            //判断是否D-bit类型
            if (segmentation_1.Length > 1)
            {
                List<bool> Romv = bit_public(import);//先获取数据
                for (int i = 0; i < segmentation_1[1].ToInt32(); i++) Romv.RemoveAt(i);//移除不需要的数据
                return Romv;//返回数据
            }
            else
            {
                if (import[0] == -1) return new List<bool>() { true };//如果读取数据溢出-负数直接返回
                return bit_public(import);//返回数据
            }
        }
        /// <summary>
        /// 三菱Mitsubishi 写入PLC
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="button_State"></param>
        /// <returns></returns>
        List<bool> IPLC_interface.PLC_write_M_bit(string Name, string id, Button_state button_State)//写入PLC 位状态 --D_bit这类需要自己在表流获取当前位状态--M这类不需要
        {
            short[] import_1 = new short[2];//寄存器
            string[] segmentation = Name.Split('_');//分割字符串
            string[] segmentation_1 = id.Split('.');//分割字符串
            axActUtlType.ReadDeviceBlock2((segmentation.Length > 1 ? segmentation[0] + segmentation_1[0] : Name + id), 1, out import_1[0]);//先读三菱PLC输入状态
            bool[] state = new bool[16];
            state=ConvertIntToBoolArray(import_1[0],16);
            if (segmentation_1.Length > 1)//寄存器指定bit处理方式
            {
                Array.Reverse(state);//先翻转数据--让数据填充
                state[segmentation_1[1].ToInt32()] = true;
                Array.Reverse(state);//填充完毕翻转数据打包--int
            }
            else
                state[15] = Convert.ToBoolean((int)button_State);                       
            import_1[0] =(short)ConvertBoolArrayToInt(state);//BOOL转INT
            axActUtlType.WriteDeviceBlock2((segmentation.Length > 1 ? segmentation[0] + segmentation_1[0] : Name + id), import_1.Length, ref import_1[0]);//写入三菱PLC输入状态
            return bit_public(import_1);//返回数据
        }
        /// <summary>
        ///宏指令  三菱Mitsubishi 写入PLC
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="on_off"></param>
        /// <returns></returns>
        List<bool> macroinstruction_PLC_interface.PLC_write_M_bit(string Name, string id, bool on_off)
        {
            short[] import_1 = new short[2];//寄存器
            if (PLC_ready != true) return bit_public(import_1);//PLC未准备好 返回数据
            string[] segmentation = Name.Split('_');//分割字符串
            string[] segmentation_1 = id.Split('.');//分割字符串
            axActUtlType.ReadDeviceBlock2((segmentation.Length > 1 ? segmentation[0] + segmentation_1[0] : Name + id), 1, out import_1[0]);//先读三菱PLC输入状态
            bool[] state = new bool[16];
            state = ConvertIntToBoolArray(import_1[0], 16);
            if (segmentation_1.Length > 1)//寄存器指定bit处理方式
            {
                Array.Reverse(state);//先翻转数据--让数据填充
                state[segmentation_1[1].ToInt32()] = true;
                Array.Reverse(state);//填充完毕翻转数据打包--int
            }
            else
                state[15] = on_off;
            import_1[0] = (short)ConvertBoolArrayToInt(state);//BOOL转INT
            axActUtlType.WriteDeviceBlock2((segmentation.Length > 1 ? segmentation[0] + segmentation_1[0] : Name + id), import_1.Length, ref import_1[0]);//写入三菱PLC输入状态
            return bit_public(import_1);//返回数据
        }
        /// <summary>
        /// 三菱Mitsubishi 读寄存器--转换相应类型
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string IPLC_interface.PLC_read_D_register(string Name,string id, numerical_format format)//读寄存器--转换相应类型
        {
            short[] import = new short[2];//寄存器
            string[] segmentation = Name.Split('_');//分割字符串
            string[] segmentation_1 = id.Split('.');//分割字符串
            axActUtlType.ReadDeviceBlock2((segmentation.Length > 1 ? segmentation[0] + segmentation_1[0] : Name + id), import.Length, out import[0]);//获取三菱PLC寄存器状态
            //判断是否其他类型
            return Mitsubishi_to_numerical(new int[] { import[0], import[1] }, format); //返回数据           
        }
        /// <summary>
        /// 宏指令 三菱Mitsubishi 读寄存器--转换相应类型
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string macroinstruction_PLC_interface.PLC_read_D_register(string Name, string id, string format)
        {
            short[] import = new short[2];//寄存器
            if (PLC_ready != true) return Mitsubishi_to_numerical(new int[] { import[0], import[1] }, inquire_numerical(format));//PLC未准备好 返回数据
            string[] segmentation = Name.Split('_');//分割字符串
            string[] segmentation_1 = id.Split('.');//分割字符串
            axActUtlType.ReadDeviceBlock2((segmentation.Length > 1 ? segmentation[0] + segmentation_1[0] : Name + id), import.Length, out import[0]);//获取三菱PLC寄存器状态
            //判断是否其他类型
            return Mitsubishi_to_numerical(new int[] { import[0], import[1] }, inquire_numerical(format)); //返回数据         
        }
        /// <summary>
        /// 三菱Mitsubishi 写寄存器--转换类型--并且写入
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string IPLC_interface.PLC_write_D_register(string Name,string id, string content, numerical_format format)//写寄存器--转换类型--并且写入
        {        
            string[] segmentation = Name.Split('_');//分割字符串
            string[] segmentation_1 = id.Split('.');//分割字符串
            short[] import = numerical_to_Mitsubishi(content, format);
            axActUtlType.WriteDeviceBlock2((segmentation.Length > 1 ? segmentation[0] + segmentation_1[0] : Name + id), import.Length, ref import[0]);//写入三菱PLC输入状态
            return content;       
        }
        /// <summary>
        /// 宏指令 三菱Mitsubishi 写寄存器--转换类型--并且写入
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        string macroinstruction_PLC_interface.PLC_write_D_register(string Name, string id, string content, string format)
        {

            string[] segmentation = Name.Split('_');//分割字符串
            if (PLC_ready != true) return Mitsubishi_to_numerical(new int[] { 0, 0 }, inquire_numerical(format));//PLC未准备好 返回数据
            string[] segmentation_1 = id.Split('.');//分割字符串
            short[] import = numerical_to_Mitsubishi(content, inquire_numerical(format));
            axActUtlType.WriteDeviceBlock2((segmentation.Length > 1 ? segmentation[0] + segmentation_1[0] : Name + id), import.Length, ref import[0]);//写入三菱PLC输入状态
            return content;
        }
        /// <summary>
        /// 三菱Mitsubishi 批量读取寄存器
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        List<int> IPLC_interface.PLC_read_D_register_bit(string Name, string id, numerical_format format, string Index)//批量读取寄存器
        {
            return Mitsubishi_to_Index_numerical(Name,id.ToInt32(),format,Index.ToInt32(),this);//批量读取寄存器并且返回数据
        }
        /// <summary>
        /// 宏指令 三菱Mitsubishi 批量读取寄存器
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="id"></param>
        /// <param name="format"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        List<int> macroinstruction_PLC_interface.PLC_read_D_register_bit(string Name, string id, string format, string Index)
        {
            if (PLC_ready != true) return new List<int>() { 0 };//PLC未准备好 返回数据
            return Mitsubishi_to_Index_numerical(Name, id.ToInt32(), inquire_numerical(format), Index.ToInt32(), this);//批量读取寄存器并且返回数据
        }
        /// <summary>
        /// 三菱Mitsubishi 批量写入寄存器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> IPLC_interface.PLC_write_D_register_bit(string id)
        {
            
            return new List<int>() { 1 };
        }
        /// <summary>
        ///  宏指令 三菱Mitsubishi 批量写入寄存器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> macroinstruction_PLC_interface.PLC_write_D_register_bit(string id)
        {
            return new List<int>() { 0 };
        }
        /// <summary>
        /// Err处理
        /// </summary>
        /// <param name="e"></param>
        private void err(Exception e)
        {
            PLC_ready = false;//PLC开放异常
            PLCerr_code = e.HResult;
            PLCerr_content = e.Message;
        }
    }
}
