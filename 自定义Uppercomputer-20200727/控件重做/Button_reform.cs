using CCWin.SkinClass;
using CCWin.SkinControl;
using DragResizeControlWindowsDrawDemo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.控件重做.复制粘贴接口;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 本类主要重写按钮的属性
    /// 重写
    /// </summary>
    class Button_reform : SkinButton, ControlCopy
    {
        public Button_Class Button_Class;//控件参数
        public enum Button_pattern//按钮模式类型枚举
        {
            Set_as_on , Set_as_off, 切换开关, 复归型
        }
        public string Button_ID { get; set; }//该按钮ID
        SkinContextMenuStrip_reform menuStrip_Reform;//绑定右键菜单类
        public  Button_reform()//构造函数
        {
            this.menuStrip_Reform = new SkinContextMenuStrip_reform();//实例化右键菜单
            this.ContextMenuStrip = this.menuStrip_Reform;//绑定右键菜单
            this.Cursor = Cursors.Hand;//改变鼠标状态
            this.MouseDown += Click_reform;//注册事件
            this.MouseDown += MouseDown_reform;//注册事件
            this.MouseUp += MouseUp_reform;//注册事件
            this.MouseMove += MouseMove__reform;//注册事件
            this.DoubleClick += DoubleClick_reform;//注册事件
            DragResizeControl.RegisterControl(this);//实现控件改变大小与拖拽位置
        }
        /// <方法重写当鼠标移到控件时获取——ID>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Cursor = Cursors.Hand;//改变鼠标状态
            Button_reform button = (Button_reform)this;//获取控件信息
            this.Button_ID = button.Parent.ToString();//写入信息
            this.menuStrip_Reform.SkinContextMenuStrip_Button_ID = button.Parent.ToString();//写入信息
            this.menuStrip_Reform.all_purpose = this;//获取事件触发的控件
            this.menuStrip_Reform.SkinContextMenuStrip_Button_type = this.GetType().Name;//获取类型名称
            //如果用户不开启编辑模式--右键菜单选项为锁定状态
            this.menuStrip_Reform.Enabled = Form2.edit_mode;//启用状态
        }
        /// <方法重写当按钮按下触发—写入PLC状态>
        private void Click_reform(object send, EventArgs e)
        {
            //当按钮按下触发—写入PLC状态
            this.BeginInvoke((EventHandler)delegate
            {
                Button_EF button_EF = new Button_EF();//实例化EF
                Button_Class = button_EF.Button_Parameter_Query(this.Parent + "-" + this.Name);//查询控件参数
                if (Form2.edit_mode || Button_Class.位指示灯.Trim() == "1") return;
                if (Button_Class.读写不同地址_ON_OFF == 0)
                    plc(Button_Class.读写设备.Trim());//选择相应PLC 进行写入
                else
                    plc(Button_Class.写设备_复选.Trim());//选择相应PLC 进行写入
            });
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
                        location = (numerical_public.Size_X(this.Left)).ToString() + "-" + (numerical_public.Size_Y(this.Top)).ToString(),
                        size = (numerical_public.Size_X(this.Size.Width) + "-" + numerical_public.Size_Y(this.Size.Height))
                    });
                startMove = false;
            }
            if (Form2.edit_mode) return;
            if (state)
            {
                if (Button_Class.读写不同地址_ON_OFF == 0)
                    ThreadPool.QueueUserWorkItem((sr)=> { plc(Button_Class.读写设备.Trim(), state); });//选择相应PLC--复归型按钮--把任务交到线程池序列
                else
                    ThreadPool.QueueUserWorkItem((sr) => { plc(Button_Class.写设备_复选.Trim(), state); });//选择相应PLC--复归型按钮--把任务交到线程池序列
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
                //this.Location = new Point(x, y);//放弃该代码
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
                            Button_write_select(Button_Class.操作模式.Trim(), mitsubishi_AxActUtlType);//根据按钮模式进行写入操作
                        }
                        else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)//PLC是否准备完成
                        {
                            Button_write_select(Button_Class.操作模式.Trim(), mitsubishi);//根据按钮模式进行写入操作
                        }
                        else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)//PLC是否准备完成
                    {
                        Button_write_select(Button_Class.操作模式.Trim(), Siemens);//根据按钮模式进行写入操作
                    }
                    else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)//PLC是否准备完成
                    {                        
                        Button_write_select(Button_Class.操作模式.Trim(), "MODBUD_TCP", MODBUD_TCP);//根据按钮模式进行写入操作
                    }
                    else MessageBox.Show("未连接设备：" + pLC.Trim(), "Err");//推出异常提示用户
                    break;
                //访问 宏指令数据区--Data_M
                case "HMI":
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                        state = Button_HMI_public.Button_HMI_write_select(Button_Class.读写设备_地址_具体地址.Trim().ToInt32(), Button_Class.操作模式.Trim());//根据按钮模式进行写入操作 
                    else
                        state = Button_HMI_public.Button_HMI_write_select(Button_Class.写设备_地址_具体地址_复选.Trim().ToInt32(), Button_Class.操作模式.Trim());//根据按钮模式进行写入操作 
                    break;
            }
            return "OK";
        }
        private string plc(string pLC,bool state)//根据PLC类型写入--为复归型按钮使用
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
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                        Button_HMI_public.Button_HMI_write_select(Button_Class.读写设备_地址_具体地址.Trim().ToInt32(), "复归型_Off");//根据按钮模式进行写入操作 
                    else
                        Button_HMI_public.Button_HMI_write_select(Button_Class.写设备_地址_具体地址_复选.Trim().ToInt32(), "复归型_Off");//根据按钮模式进行写入操作 
                    break;
            }
            return "OK";
        }
        bool state = false;//定义标志位--复归型按钮-判断状态
        private void Button_write_select(string Name,IPLC_interface pLC_Interface)//按照按钮模式写入
        {
            switch (Name)
            {
                case "Set_as_on"://设置常ON
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.PLC_write_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_state.ON);//写入常ON
                    else
                        pLC_Interface.PLC_write_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), Button_state.ON);//写入常ON
                    break;
                case "Set_as_off"://设置常OFF
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.PLC_write_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_state.Off);//写入常Off
                    else
                        pLC_Interface.PLC_write_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), Button_state.Off);//写入常Off
                    break;
                case "切换开关":
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                    {
                        List<bool> data = pLC_Interface.PLC_read_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim());//先读取要写入的状态
                        pLC_Interface.PLC_write_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), data[0] == true ? Button_state.Off : Button_state.ON);//根据要写入的状态进行取反
                    }
                    else
                    {
                        List<bool> data = pLC_Interface.PLC_read_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim());//先读取要写入的状态
                        pLC_Interface.PLC_write_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), data[0] == true ? Button_state.Off : Button_state.ON);//根据要写入的状态进行取反
                    }
                    break;
                case "复归型":
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.PLC_write_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_state.ON);//先写入ON--后用事件复位-off
                    else
                        pLC_Interface.PLC_write_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), Button_state.ON);//先写入ON--后用事件复位-off
                    state = true;//标志位                      
                    break;
                    case "复归型_Off":
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.PLC_write_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_state.Off);//先写入ON--后用事件复位-off
                    else
                        pLC_Interface.PLC_write_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), Button_state.Off);//先写入ON--后用事件复位-off
                    state = false;//标志位
                    break;
            }
        }
        private void Button_write_select(string Name, string modbus_tcp, MODBUD_TCP pLC_Interface)//按照按钮模式写入
        {
            switch (Name)
            {
                case "Set_as_on"://设置常ON
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_state.ON);//写入常ON
                    else
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), Button_state.ON);//写入常ON
                    break;
                case "Set_as_off"://设置常OFF
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_state.Off);//写入常Off
                    else
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), Button_state.Off);//写入常Off
                    break;
                case "切换开关":
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                    {
                        List<bool> data = pLC_Interface.IPLC_interface_PLC_read_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim());//先读取要写入的状态
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), data[0] == true ? Button_state.Off : Button_state.ON);//根据要写入的状态进行取反
                    }
                    else
                    {
                        List<bool> data = pLC_Interface.IPLC_interface_PLC_read_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim());//先读取要写入的状态
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), data[0] == true ? Button_state.Off : Button_state.ON);//根据要写入的状态进行取反
                    }
                    break;
                case "复归型":
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_state.ON);//先写入ON--后用事件复位-off
                    else
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), Button_state.ON);//先写入ON--后用事件复位-off
                    state = true;//标志位                      
                    break;
                case "复归型_Off":
                    if (Button_Class.读写不同地址_ON_OFF == 0)
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_state.Off);//先写入ON--后用事件复位-off
                    else
                        pLC_Interface.IPLC_interface_PLC_write_M_bit(Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), Button_state.Off);//先写入ON--后用事件复位-off
                    state = false;//标志位
                    break;
            }
        }
        /// <summary>
        /// 复制控件的属性
        /// </summary>
        /// <returns></returns>
        public Control Objectproperty(string Name,Form form)
        {
            using (UppercomputerEntities2 db = new UppercomputerEntities2())
            {
                //获取上个控件的值
                string path = this.Button_ID + "-" + this.Name;
                var button_colour = db.Button_colour.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var button_parameter = db.Button_parameter.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var general_parameters_of_picture = db.General_parameters_of_picture.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var Tag_common = db.Tag_common_parameters.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var locatio = db.control_location.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var button_class = db.Button_Class.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                //产生新的控件
                Button_reform button =(Button_reform) this.Clone();

                Public_attributeCalss public_AttributeCalss = new Public_attributeCalss();//实例化按钮参数设置
                public_AttributeCalss.attributeCalss(button, button_class);//查询数据库--进行设置后的参数修改

                //修改控件名称
                button.Name = Name.Trim();
                //设置控件产生的位置--判断是否超出边界
                if((button.Left + button.Size.Width + 20)> form.Width-10&&(button.Top + button.Size.Height + 20)< form.Height-10)
                {
                    button.Location = new Point(button.Location.X, button.Location.Y+button.Height+20);
                    goto Location;
                }
                if ((button.Location.X + button.Size.Width + 20) < form.Width-10)
                {
                    button.Location = new Point(button.Location.X + button.Size.Width + 20, button.Location.Y);
                    goto Location;
                }
                //设置控件产生的位置--判断是否超出边界
                if ((button.Location.X + button.Size.Width + 20) > form.Width - 10 && (button.Location.Y + button.Size.Height + 20) > form.Height - 10)
                {
                    button.Location = new Point(button.Location.X + button.Size.Width - 20, button.Location.Y);
                    goto Location;
                }
                // button.Location = new Point(button.Location.X + button.Size.Width + 20, button.Location.Y);
                Location:
                //获取窗口ID
                string From= parameter_indexes.Button_from_name(form.ToString());//获取窗口名称

                button_parameter.ID = form.ToString() + "-" + Name;
                button_colour.ID = form.ToString() + "-" + Name;
                general_parameters_of_picture.ID= form.ToString() + "-" + Name;
                Tag_common.ID= form.ToString() + "-" + Name;
                Tag_common.Control_type= Name;
                locatio.ID= form.ToString() + "-" + Name;
                locatio.location = (numerical_public.Size_X(button.Left)).ToString() + "-" + (numerical_public.Size_Y(button.Top)).ToString();

                button_parameter.FORM = From.Trim();
                button_colour.FORM= From.Trim();
                general_parameters_of_picture.FORM = From;
                Tag_common.FROM= From;
                locatio.FORM= From;

                //重新向SQL插入数据
                Button_EF button_EF = new Button_EF();
                button_EF.Button_Add(button_parameter, Tag_common, general_parameters_of_picture, locatio, button_colour);
                return button;
            }
        }
        /// <summary>
        /// 复制控件
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Button_reform reform = new Button_reform();//实例化按钮
            reform.Size = new Size(83, 31);//设置大小
            reform.Location = this.Location;//设置按钮位置
            reform.Name = this.Name;//设置名称
            reform.Text = this.Name;//设置文本
            reform.BringToFront();//将控件放置所有控件最顶层        
            return reform;//返回数据
        }
        protected override void Dispose(bool disposing)
        {
            this.Click -= Click_reform;//移除事件
            this.MouseDown -= MouseDown_reform;//移除事件
            this.MouseUp -= MouseUp_reform;//移除事件
            this.MouseMove -= MouseMove__reform;//移除事件
            this.DoubleClick -= DoubleClick_reform;//移除事件
            DragResizeControl.UnRegisterControl(this);//实现控件改变大小与拖拽位置
            Button_Class = null;
            this.menuStrip_Reform.Dispose();
            base.Dispose(disposing);
        }

    }
}
