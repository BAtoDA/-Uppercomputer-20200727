using CCWin.SkinClass;
using DragResizeControlWindowsDrawDemo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_Library_da;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;

namespace 自定义Uppercomputer_20200727.控件重做
{ 
    /// <summary>
   /// 引用第三方开源控件重构对事件方法等进行具体的实现
   /// 切换开关
   /// </summary>
    class Switch_reform : UI_Switch
    {
        Switch_Class Switch_Class;//控件参数
        public enum Switch_pattern//切换开模式类型枚举
        {
            Set_as_on, Set_as_off, 切换开关, 复归型
        }
        public string Switch_ID { get; set; }//该按钮ID
        SkinContextMenuStrip_reform menuStrip_Reform;//绑定右键菜单类
        public Switch_reform()//构造函数
        {
            this.menuStrip_Reform = new SkinContextMenuStrip_reform();//实例化右键菜单
            this.ContextMenuStrip = this.menuStrip_Reform;//绑定右键菜单
            this.MouseEnter += MouseEnter_reform;//注册事件
            this.Click += Click_reform;//注册事件
            this.MouseDown += MouseDown_reform;//注册事件
            this.MouseUp += MouseUp_reform;//注册事件
            this.MouseMove += MouseMove__reform;//注册事件
            this.DoubleClick += DoubleClick_reform;//注册事件
            DragResizeControl.RegisterControl(this);//实现控件改变大小与拖拽位置
        }
        /// <方法重写当鼠标移到控件时获取——ID>
        private void MouseEnter_reform(object send, EventArgs e)
        {
            this.Cursor = Cursors.Hand;//改变鼠标状态
            Switch_reform button = (Switch_reform)send;//获取控件信息
            this.Switch_ID = button.Parent.ToString();//写入信息
            this.menuStrip_Reform.SkinContextMenuStrip_Button_ID = button.Parent.ToString();//写入信息
            this.menuStrip_Reform.all_purpose = send;//获取事件触发的控件
            this.menuStrip_Reform.SkinContextMenuStrip_Button_type = this.GetType().Name;//获取类型名称
            //如果用户不开启编辑模式--右键菜单选项为锁定状态
            this.menuStrip_Reform.Enabled = Form2.edit_mode;//启用状态
        }
        /// <方法重写当按钮按下触发—写入PLC状态>
        private void Click_reform(object send, EventArgs e)
        {
            if (Form2.edit_mode) return;
            if (Switch_Class.读写不同地址_ON_OFF == 0)
                plc(Switch_Class.读写设备.Trim());//选择相应PLC 进行写入
            else
                plc(Switch_Class.写设备_复选.Trim());//选择相应PLC 进行写入
        }
        /// <方法重写当触发双击>
        private void DoubleClick_reform(object send, EventArgs e)
        {

        }
        /// <方法重写实现拖放功能—>
        bool startMove = false;
        int clickX = 0;  //记录上次点击的鼠标位置
        int clickY = 0;//记录上次点击的鼠标位置
        private void MouseDown_reform(object sender, MouseEventArgs e)//鼠标按下事件
        {
            //当按钮按下触发—写入PLC状态
            Switch_EF button_EF = new Switch_EF();//实例化EF
            Switch_Class = button_EF.Button_Parameter_Query(this.Parent + "-" + this.Name);//查询控件参数
            //初始化按钮
            if (Form2.edit_mode != true) return;//返回方法
            clickX = e.X;
            clickY = e.Y;
            startMove = true;

        }
        private void MouseUp_reform(object sender, MouseEventArgs e)//鼠标松开事件
        {
            //标志位复位-并且写入数据库
            if (startMove)
            {
                Button_EF button_EF = new Button_EF();//实例化EF
                button_EF.Button_Parameter_modification(this.Parent + "-" + this.Name
                    , new control_location
                    {
                        location = (numerical_public.Size_X(this.Location.X) + e.X - clickX).ToString() + "-" + (numerical_public.Size_Y(this.Location.Y) + e.Y - clickY).ToString(),
                        size = (numerical_public.Size_X(this.Size.Width) + "-" + numerical_public.Size_Y(this.Size.Height))
                    });
                startMove = false;
            }
            if (Form2.edit_mode) return;
            if (state)
            {
                if (Switch_Class.读写不同地址_ON_OFF == 0)
                    ThreadPool.QueueUserWorkItem((sr) => { plc(Switch_Class.读写设备.Trim(), state); });//选择相应PLC--复归型按钮--把任务交到线程池序列
                else
                    ThreadPool.QueueUserWorkItem((sr) => { plc(Switch_Class.写设备_复选.Trim(), state); });//选择相应PLC--复归型按钮--把任务交到线程池序列
            }
        }
        private void MouseMove__reform(object sender, MouseEventArgs e)//鼠标拖放位置
        {
            if (Form2.edit_mode != true) return;//返回方法
            if (startMove)
            {
                // e.X 是正负数,表示移动的方向
                int x = this.Location.X + e.X - clickX;   //还要减去上次鼠标点击的位置
                int y = e.Y + this.Location.Y - clickY;
                //this.Location = new Point(x, y);
            }
        }
        private string plc(string pLC)//根据PLC类型写入
        {
            switch (pLC)
            {
                case "Mitsubishi"://三菱有二种模式 --在线与仿真
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            Button_write_select(Switch_Class.操作模式.Trim(), mitsubishi_AxActUtlType);//根据按钮模式进行写入操作
                        }
                        else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            Button_write_select(Switch_Class.操作模式.Trim(), mitsubishi);//根据按钮模式进行写入操作
                        }
                        else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        Button_write_select(Switch_Class.操作模式.Trim(), Siemens);//根据按钮模式进行写入操作
                    }
                    else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        Button_write_select(Switch_Class.操作模式.Trim(), "MODBUD_TCP", MODBUD_TCP);//根据按钮模式进行写入操作
                    }
                    else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    break;
                //访问 宏指令数据区--Data_M
                case "HMI":
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                        state = Button_HMI_public.Button_HMI_write_select(Switch_Class.读写设备_地址_具体地址.Trim().ToInt32(), Switch_Class.操作模式.Trim());//根据按钮模式进行写入操作 
                    else
                        state = Button_HMI_public.Button_HMI_write_select(Switch_Class.写设备_地址_具体地址_复选.Trim().ToInt32(), Switch_Class.操作模式.Trim());//根据按钮模式进行写入操作 
                    break;
            }
            return "OK";
        }
        private string plc(string pLC, bool state)//根据PLC类型写入--为复归型按钮使用
        {
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)//PLC是否准备完成
                        {
                            Button_write_select("复归型_Off", mitsubishi_AxActUtlType);//根据按钮模式进行写入操作
                        }
                        else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户                       
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            Button_write_select("复归型_Off", mitsubishi);//根据按钮模式进行写入操作
                        }
                        else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        Button_write_select("复归型_Off", Siemens);//根据按钮模式进行写入操作
                    }
                    else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现三菱仿真
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {
                        Button_write_select("复归型_Off", "MODBUD_TCP", MODBUD_TCP);//根据按钮模式进行写入操作
                    }
                    else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    break;
                //访问 宏指令数据区--Data_M
                case "HMI":
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                        Button_HMI_public.Button_HMI_write_select(Switch_Class.读写设备_地址_具体地址.Trim().ToInt32(), "复归型_Off");//根据按钮模式进行写入操作 
                    else
                        Button_HMI_public.Button_HMI_write_select(Switch_Class.写设备_地址_具体地址_复选.Trim().ToInt32(), "复归型_Off");//根据按钮模式进行写入操作 
                    break;
            }
            return "OK";
        }
        bool state = false;//定义标志位--复归型按钮-判断状态
        private void Button_write_select(string Name, IPLC_interface pLC_Interface)//按照按钮模式写入
        {
            switch (Name)
            {
                case "Set_as_on"://设置常ON
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.PLC_write_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Button_state.ON);//写入常ON
                    else
                        pLC_Interface.PLC_write_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), Button_state.ON);//写入常ON
                    break;
                case "Set_as_off"://设置常OFF
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.PLC_write_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Button_state.Off);//写入常Off
                    else
                        pLC_Interface.PLC_write_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), Button_state.Off);//写入常Off
                    break;
                case "切换开关":
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                    {
                        List<bool> data = pLC_Interface.PLC_read_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim());//先读取要写入的状态
                        pLC_Interface.PLC_write_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), data[0] == true ? Button_state.Off : Button_state.ON);//根据要写入的状态进行取反
                    }
                    else
                    {
                        List<bool> data = pLC_Interface.PLC_read_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim());//先读取要写入的状态
                        pLC_Interface.PLC_write_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), data[0] == true ? Button_state.Off : Button_state.ON);//根据要写入的状态进行取反
                    }
                    break;
                case "复归型":
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.PLC_write_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Button_state.ON);//先写入ON--后用事件复位-off
                    else
                        pLC_Interface.PLC_write_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), Button_state.ON);//先写入ON--后用事件复位-off
                    state = true;//标志位                      
                    break;
                case "复归型_Off":
                    Thread.Sleep(200);//延时300ms复位
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.PLC_write_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Button_state.Off);//先写入ON--后用事件复位-off
                    else
                        pLC_Interface.PLC_write_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), Button_state.Off);//先写入ON--后用事件复位-off
                    state = false;//标志位
                    break;
            }
        }
        private void Button_write_select(string Name, string modbus_tcp, MODBUD_TCP pLC_Interface)//按照按钮模式写入
        {
            switch (Name)
            {
                case "Set_as_on"://设置常ON
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Button_state.ON);//写入常ON
                    else
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), Button_state.ON);//写入常ON
                    break;
                case "Set_as_off"://设置常OFF
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Button_state.Off);//写入常Off
                    else
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), Button_state.Off);//写入常Off
                    break;
                case "切换开关":
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                    {
                        List<bool> data = pLC_Interface.IPLC_interface_PLC_read_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim());//先读取要写入的状态
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), data[0] == true ? Button_state.Off : Button_state.ON);//根据要写入的状态进行取反
                    }
                    else
                    {
                        List<bool> data = pLC_Interface.IPLC_interface_PLC_read_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim());//先读取要写入的状态
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), data[0] == true ? Button_state.Off : Button_state.ON);//根据要写入的状态进行取反
                    }
                    break;
                case "复归型":
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Button_state.ON);//先写入ON--后用事件复位-off
                    else
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), Button_state.ON);//先写入ON--后用事件复位-off
                    state = true;//标志位                      
                    break;
                case "复归型_Off":
                    Thread.Sleep(200);//延时300ms复位
                    if (Switch_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Button_state.Off);//先写入ON--后用事件复位-off
                    else
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), Button_state.Off);//先写入ON--后用事件复位-off
                    state = false;//标志位
                    break;
            }
        }
        ~Switch_reform()//析构函数
        {
            this.MouseEnter -= MouseEnter_reform;//移除事件
            this.Click -= Click_reform;//移除事件
            this.MouseDown -= MouseDown_reform;//移除事件
            this.MouseUp -= MouseUp_reform;//移除事件
            this.MouseMove -= MouseMove__reform;//移除事件
            this.DoubleClick -= DoubleClick_reform;//移除事件
            this.Dispose();
        }
    }
}
