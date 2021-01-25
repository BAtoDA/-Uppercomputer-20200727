using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEngineTest.重构帮助文档.说明控件.宏函数解析控件
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/1/24 16:04:24
    //  文件名：Document_Class
    //  版本：V1.0.1  
    //  说明： 用于显示文档
    //  修改者：***
    //  修改说明： 
    //==============================================================
    class Document_Class
    {
        //创建默认字典
        private List<Tuple<string, string, string, string, string>> tuples = new List<Tuple<string, string, string, string, string>>();
        public  List<Tuple<string, string, string, string, string>> Key_Tup { get => tuples; set => document_Form(); }
        //构造函数
        public Document_Class()
        {
            document_Form();
        }
        //加载字典
        public void document_Form()
        {
            tuples.Clear();
            //添加PLC_read_M_bit("Y","0"); 方法使用案例
            tuples.Add(new Tuple<string, string, string, string, string>("uiLinkLabel1",
                "PLC_read_M_bit(触点,读取地址)  ",
                "读取三菱仿真:Mitsubishi_axActUtlType.PLC_read_M_bit(X,0);  " +
                "\r\n读取三菱在线:Mitsubishi.PLC_read_M_bit(X,0); " +
                "\r\n读取西门子:Siemens.PLC_read_M_bit(I,0.0);  " +
                "\r\n读取MODBUD_TCP:MODBUD_TCP.PLC_read_M_bit(X,0);   ",
                "使用PLC_read_M_bit()方法可以读取指定设备的I Y Q M DB这些辅助触点\r\n 返回类型是List<bool> "
                , "示例：\r\n 读取三菱仿真输入变量X点:var data=Mitsubishi_axActUtlType.PLC_read_M_bit(X,0); " +
                "\r\n 读取西门子I var data=Siemens.PLC_read_M_bit(I,0.0); " +
                "返回类型是泛型 使用方法是: \r\n" +
                "Bool in=data[0];//获取PLC当前读取值的状态 要么为FALSE 要么为TRUE"));
            //添加PLC_write_M_bit("Y","0",true); 方法使用案例
            tuples.Add(new Tuple<string, string, string, string, string>("uiLinkLabel2",
              "PLC_write_M_bit(触点,起始地址,要写入的枚举)  ",
              "写入三菱仿真:Mitsubishi_axActUtlType.PLC_write_M_bit(Y,0,Button_state.ON);  " +
              "\r\n写入三菱在线:Mitsubishi.PLC_write_M_bit(Y,0,Button_state.ON); " +
              "\r\n写入西门子:Siemens.PLC_write_M_bit(Q,0.0,Button_state.ON);  " +
              "\r\n写入MODBUD_TCP:MODBUD_TCP.PLC_write_M_bit(Y,0,Button_state.OFF);   ",
              "使用PLC_write_M_bit(String,String,Button_state.ON)方法可以写入指定设备的I Y Q M DB这些辅助触点\r\n 返回类型是List<bool> "
              , "示例：\r\n 写入三菱仿真输入变量Y点:\r\nvar data=Mitsubishi_axActUtlType.PLC_write_M_bit(Y,0,Button_state.ON);" +
              "\r\n 写入西门子Q var data=Siemens.PLC_write_M_bit(Q,0.0,Button_state.ON);\r\n" +
              "返回类型是泛型 使用方法是: \r\n" +
              "Bool in=data[0];//获取PLC当前读取值的状态 要么为FALSE 要么为TRUE\r\n" +
              "Button_state这是枚举 他的状态只有Button_state.ON" +
              "\r\n和Button_state.ON"));
            //添加PLC_read_D_register(寄存器, 起始地址,数据类型枚举); 方法使用案例
            tuples.Add(new Tuple<string, string, string, string, string>("uiLinkLabel3",
              "PLC_read_D_register(寄存器, 起始地址,数据类型枚举); ",
              "读取三菱仿真:\r\nMitsubishi_axActUtlType.PLC_read_D_register(D, 0,numerical_format.Signed_32_Bit); " +
              "\r\n读取三菱在线:\r\nMitsubishi.PLC_read_D_register(D, 0,numerical_format.Signed_32_Bit); " +
              "\r\n读取西门子:\r\nSiemens.PLC_read_D_register(M, 0,numerical_format.Signed_32_Bit);或者是DB " +
              "\r\n读取MODBUD_TCP:\r\nMODBUD_TCP.PLC_read_D_register(D, 0,numerical_format.Signed_32_Bit);  ",
              "使用PLC_read_D_register(String, String,Snumerical_format.igned_32_Bit);\r\n方法可以读取指定设备的寄存器D M DB SD R W等寄存器类型"
              , "示例：\r\n 读取三菱仿真D0:\r\nvar data=Mitsubishi_axActUtlType.PLC_read_D_register\r\n(D, 0,numerical_format.Signed_32_Bit);" +
              "\r\n 读取西门子读取MD0:\r\n var data=Siemens.PLC_read_D_register\r\n(M, 0,numerical_format.Signed_32_Bit);\r\n" +
              "返回类型是String  numerical_format数据类型有: \r\n"
              + "numerical_format.BCD_16_Bit, numerical_format.BCD_32_Bit, \r\nnumerical_format.Hex_16_Bit, numerical_format.Hex_32_Bit," +
              " \r\nnumerical_format.Binary_16_Bit, numerical_format.Binary_32_Bit, \r\nnumerical_format.Unsigned_16_Bit, numerical_format.Signed_16_Bit\r\n" +
            ", numerical_format.Unsigned_32_Bit, numerical_format.Signed_32_Bit, \r\nnumerical_format.Float_32_Bit"));
            //添加PLC_write_D_register("D", "0",“0”,“Signed_32_Bit”); 方法使用案例
            tuples.Add(new Tuple<string, string, string, string, string>("uiLinkLabel4",
              "PLC_write_D_register(寄存器, 起始地址,要写入的数据,数据类型枚举); ",
              "写入三菱仿真:\r\nMitsubishi_axActUtlType.PLC_write_D_register(D, 0,66,numerical_format.Signed_32_Bit); " +
              "\r\n读取三菱在线:\r\nMitsubishi.PLC_write_D_register(D, 0,66,numerical_format.Signed_32_Bit); " +
              "\r\n读取西门子:\r\nSiemens.PLC_write_D_register(M, 0,66,numerical_format.Signed_32_Bit);或者是DB " +
              "\r\n读取MODBUD_TCP:\r\nMODBUD_TCP.PLC_write_D_register(D, 0,66,numerical_format.Signed_32_Bit); ",
              "使用PLC_write_D_register(String,String,String,numerical_format.Signed_32_Bit); \r\n方法可以读取指定设备的寄存器D M DB SD R W等寄存器类型"
              , "示例：\r\n 读取三菱仿真D0:\r\nvar data=Mitsubishi_axActUtlType.PLC_write_D_register\r\n(D, 0,66,numerical_format.Signed_32_Bit);" +
              "\r\n 读取西门子读取MD0:\r\n var data=Siemens.PLC_write_D_register\r\n(M, 0,66,numerical_format.Signed_32_Bit);\r\n" +
              "返回类型是String numerical_format数据类型有: \r\n"
              + "numerical_format.BCD_16_Bit, numerical_format.BCD_32_Bit, \r\nnumerical_format.Hex_16_Bit, numerical_format.Hex_32_Bit, " +
              "\r\nnumerical_format.Binary_16_Bit, numerical_format.Binary_32_Bit,\r\n numerical_format.Unsigned_16_Bit, numerical_format.Signed_16_Bit\r\n" +
            ", numerical_format.Unsigned_32_Bit, numerical_format.Signed_32_Bit,\r\n numerical_format.Float_32_Bit"));
            //添加内置线程使用方法
            //添加macroinstruction_data<Thread>.thread[0]; 方法使用案例
            tuples.Add(new Tuple<string, string, string, string, string>("uiLinkLabel8",
                "macroinstruction_data<Thread>.thread[0]\r\n//使用内置线程需要实例化(推荐使用匿名方法实例化)",
                "//匿名线程使用\r\n"+
                "macroinstruction_data<Thread>.thread[0] = new Thread(() =>\r\n" +
                "{\r\n" +
                "while(true)\r\n" +
                "{\r\n" +
                 "需要循环的任务\r\n" +
                "}\r\n" +
                "});\r\n" +
                 "macroinstruction_data<Thread>.thread[0].Start();//启动线程\r\n",
                 "macroinstruction_data<Thread>.thread[0] = new Thread(() =>\r\n" +
                "{\r\n" +
                "//内容\r\n" +
                "});\r\n" +
                 "macroinstruction_data<Thread>.thread[0].Start();//启动线程\r\n",
                "//线程使用方法\r\n" +
                "thread.Start();//启动线程\r\n" +
                "thread.Abort();//停止线程--销毁\r\n" +
                "thread.Join();//暂停线程\r\n" +
                "thread.IsAlive;//线程状态--BOOL值\r\n" +
                "Thread.Sleep();//延时线程\r\n"
                ));
        }
    }
}
