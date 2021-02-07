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
            //添加Socket通讯使用方法
            //添加macroinstruction_Socket(AddressFamily family, SocketType socket,ProtocolType protocol) 方法使用案例
            tuples.Add(new Tuple<string, string, string, string, string>("uiLinkLabel12",
                "macroinstruction_Socket(AddressFamily family, SocketType socket,ProtocolType protocol)\r\n"+
                "Socket通讯需要传入开放类型",
                "//Socket通讯的使用\r\n" +
                "macroinstruction_Socket socket =new macroinstruction_Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);\r\n"
                +"//开放链接服务器\r\n"+
                "socket.Open(new IPEndPoint(IPAddress.Parse(127.0.0.1), int.Parse(502)));\r\n"
                + "//向服务器发送消息-字节数组类型\r\n"
                + "socket.send(new byet[] {0x1,0x2});\r\n"
                +"//向服务器发送消息--字符串\r\n"
                + "socket.send(123);\r\n"
                +"//等待服务器回复数据 堵塞线程模式\r\n"
                +"byet data=new byet[1024];\r\n"
                + "socket.reception(data);\r\n"
                +"//服务器与客户端异常标志位-这个比较重要 true 正常 false 异常\r\n"
                + "socket.socket_OK;",
                "macroinstruction_Socket socket =new macroinstruction_Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);",
                "//Socket使用方法\r\n" +
                "socket.Open() 表示链接服务器 需要传入IP 与端口\r\n"
                + "socket.send()向服务器发送消息 可以发送数组 可以直接字符串发送\r\n"
                + "socket.reception()接收服务器消息 会堵塞线程"
                ));
            //添加串口通讯使用方法
            //添加macroinstruction_SerialPort(int BaudRate, int DataBits,string PortName,StopBits stopBits, Parity parity) 方法使用案例
            tuples.Add(new Tuple<string, string, string, string, string>("uiLinkLabel11",
                "macroinstruction_SerialPort(int BaudRate, int DataBits,string PortName,\r\n" +
                "StopBits stopBits, Parity parity)\r\n" +
                "串口通讯需要传入参数\r\n",
                "//串口通讯的使用\r\n" 
                + "this.BaudRate = BaudRate;//设置波特率\r\n"
                + "this.DataBits = DataBits;//数据长度\r\n"
                + "this.Encoding = Encoding.UTF8;//设置解码类型\r\n"
                + "this.PortName = PortName;//端口号\r\n"
                + "this.StopBits = stopBits;//停止位数--枚举---StopBits\r\n"
                + "this.Parity = parity;//校验-枚举 -parity\r\n"
                + "macroinstruction_SerialPort port =new macroinstruction_SerialPort\r\n"
                + "(9600,8,COM1,StopBits.One,Parity.None);\r\n"
                + "//打开COM1\r\n" +
                 "port.Open();\r\n"
                + "//向COM1发送消息--字符串\r\n"
                + "port.send_Port(123);\r\n"
                + "//等待服务器回复数据 堵塞线程模式\r\n"
                + "byet data=new byet[1024];\r\n"
                + "data=port.read_Port();\r\n"
                + "//COM1异常标志位-这个比较重要 true 正常 false 异常\r\n"
                + "port.Port_OK;",
                "macroinstruction_SerialPort port =new macroinstruction_SerialPort(9600,8,COM1,StopBits.One,Parity.None);",
                "//COM使用方法\r\n" +
                "port.Open_Port() 表示链接COM口\r\n"
                + "port.send_Port()向COM口发送消息 可以发送数组 可以直接字符串发送\r\n"
                + "port.read_Port()接收COM口消息 会堵塞线程"
                )); ;
        }
    }
}
