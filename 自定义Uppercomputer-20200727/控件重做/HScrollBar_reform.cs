using CCWin.SkinClass;
using CCWin.SkinControl;
using CSEngineTest;
using DragResizeControlWindowsDrawDemo;
using PLC通讯规范接口;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.EF实体模型.EFtoSQL操作类重写;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.控件重做.复制粘贴接口;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    ///继承 HScrollBar类-实现动态绘制移动图形 
    /// </summary>
    [ToolboxItem(false)]
    class HScrollBar_reform: SkinHScrollBar, ControlCopy
    {
        string AnalogMeter_ID { get; set; }//文本属性ID
        SkinContextMenuStrip_reform menuStrip_Reform;//绑定右键菜单类
        /// <summary>
        /// 构造函数初始化控件UI
        /// </summary>
        public HScrollBar_reform()
        {
            //this.InitChart_load();//初始化
            this.menuStrip_Reform = new SkinContextMenuStrip_reform();//实例化右键菜单
            this.ContextMenuStrip = this.menuStrip_Reform;//绑定右键菜单
            this.MouseDown += MouseDown_reform;//注册事件
            this.MouseUp += MouseUp_reform;//注册事件
            this.MouseMove += MouseMove__reform;//注册事件
            this.MouseEnter += MouseEnter_reform;//注册事件--获取控件信息
            this.TextChanged += TextChanged_reform;//注册事件
            this.ValueChanged += VisibleChanged_1;//注册事件
            DragResizeControl.RegisterControl(this);//实现控件改变大小与拖拽位置
            this.Cursor = Cursors.Hand;//改变鼠标状态
            this.InnerPaddingWidth = 10;//内框宽度
            this.LargeChange = 1;//移动数量
        }
        /// <方法重写当鼠标移到控件时获取——ID>
        private void MouseEnter_reform(object send, EventArgs e)
        {
            this.Cursor = Cursors.Hand;//改变鼠标状态
            HScrollBar_reform button = (HScrollBar_reform)send;//获取控件信息
            this.AnalogMeter_ID = button.Parent.ToString();//写入信息
            this.menuStrip_Reform.SkinContextMenuStrip_Button_ID = button.Parent.ToString();//写入信息
            this.menuStrip_Reform.all_purpose = send;//获取事件触发的控件
            this.menuStrip_Reform.SkinContextMenuStrip_Button_type = this.GetType().Name;//获取类型名称
                                                                                         //如果用户不开启编辑模式--右键菜单选项为锁定状态
            this.menuStrip_Reform.Enabled = Form2.edit_mode;//启用状态
        }
        /// <方法重写实现拖放功能—>
        bool startMove = false;
        int clickX = 0;  //记录上次点击的鼠标位置
        int clickY = 0;//记录上次点击的鼠标位置
        private void MouseDown_reform(object sender, MouseEventArgs e)//鼠标按下事件
        {  //初始化按钮
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
                Button_EFbase button_EF = new Button_EFbase();//实例化EF
                button_EF.Button_Parameter_modification(this.Parent + "- " + this.Name
                    , new control_location
                    {
                        location = (numerical_public.Size_X(this.Left)).ToString() + "-" + (numerical_public.Size_Y(this.Top)).ToString(),
                        size = (numerical_public.Size_X(this.Size.Width) + "-" + numerical_public.Size_Y(this.Size.Height))
                    });
                startMove = false;
            }
            if (Form2.edit_mode) return;//返回方法
            if (Visi)
            {
                plc();//写入数据
                Visi = false;
            }
        }
        bool Visi = false;//数值写入标志位
        private void VisibleChanged_1(object sender, EventArgs e)
        {
            Visi = true;
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
        /// <方法重写实现字体大小改变控件Size大小功能—>
        private void TextChanged_reform(object sender, EventArgs e)//自动改变Size
        {
            this.Text = this.Text.Trim();//去除空白
            this.AutoSize = true;//控件大小根据字体改变
        }
        private string plc()//根据PLC类型写入
        {
            HScrollBar_EF  hScrollBar_EF  = new HScrollBar_EF();
            HScrollBar_Class numerical_Classes= hScrollBar_EF.AnalogMeter_Parameter_Query(this.Parent + "- " + this.Name);
            string pLC = numerical_Classes.读写设备.Trim();
            switch (pLC)
            {
                case "Mitsubishi":
                    if (PLCselect_Form.Mitsubishi.Trim() != "在线访问")//判断用户选定模式
                    {
                        IPLC_interface mitsubishi_AxActUtlType = new Mitsubishi_axActUtlType();//实例化接口--实现三菱仿真
                        if (mitsubishi_AxActUtlType.PLC_ready)
                        {
                            mitsubishi_AxActUtlType.PLC_write_D_register(numerical_Classes.读写设备_地址.Trim(), numerical_Classes.读写设备_地址_具体地址.Trim(), this.Value.ToString(), Index(numerical_Classes.资料格式));
                        }
                        else MessageBox.Show("未连接设备：" + numerical_Classes.读写设备.Trim(), "Err");//推出异常提示用户
                    }
                    else
                    {
                        IPLC_interface mitsubishi = new Mitsubishi_realize();//实例化接口--实现三菱在线访问
                        if (mitsubishi.PLC_ready)
                        {
                            mitsubishi.PLC_write_D_register(numerical_Classes.读写设备_地址.Trim(), numerical_Classes.读写设备_地址_具体地址.Trim(), this.Value.ToString(), Index(numerical_Classes.资料格式));
                        }
                        else MessageBox.Show("未连接设备：" + numerical_Classes.读写设备.Trim(), "Err");//推出异常提示
                    }
                    break;
                case "Siemens":
                    IPLC_interface Siemens = new Siemens_realize();//实例化接口--实现西门子在线访问
                    if (Siemens.PLC_ready)
                    {
                        Siemens.PLC_write_D_register(numerical_Classes.读写设备_地址.Trim(), numerical_Classes.读写设备_地址_具体地址.Trim(), this.Value.ToString(), Index(numerical_Classes.资料格式));
                    }
                    else MessageBox.Show("未连接设备：" + numerical_Classes.读写设备.Trim(), "Err");//推出异常提示
                    break;
                case "Modbus_TCP":
                    MODBUD_TCP MODBUD_TCP = new MODBUD_TCP();//实例化接口--实现MODBUS TCP
                    if (MODBUD_TCP.IPLC_interface_PLC_ready)
                    {
                        MODBUD_TCP.PLC_write_D_register(numerical_Classes.读写设备_地址.Trim(), numerical_Classes.读写设备_地址_具体地址.Trim(), this.Value.ToString(), Index(numerical_Classes.资料格式));
                    }
                    else MessageBox.Show("未连接设备：" + numerical_Classes.读写设备.Trim(), "Err");//推出异常提示用户
                    break;
                //写入到 宏指令 静态区D_Data
                case "HMI":
                    macroinstruction_data<int>.D_Data[numerical_Classes.读写设备_地址_具体地址.Trim().ToInt32()] = this.Value.ToString();
                    break;
            }
            return "OK_RUN";
        }
        private numerical_format Index(string Name)//查询索引
        {
            foreach (numerical_format suit in Enum.GetValues(typeof(numerical_format)))
            {
                if (suit.ToString() == Name.Trim()) return suit;//遍历枚举查询索引
            }
            return numerical_format.Unsigned_32_Bit;//如果不匹配则返回默认无符号类型
        }
        protected override void Dispose(bool disposing)
        {
            this.MouseDown -= MouseDown_reform;//注册事件
            this.MouseUp -= MouseUp_reform;//注册事件
            this.MouseMove -= MouseMove__reform;//注册事件
            this.MouseEnter -= MouseEnter_reform;//注册事件--获取控件信息
            this.TextChanged -= TextChanged_reform;//注册事件
            this.ValueChanged -= VisibleChanged_1;//注册事件
            menuStrip_Reform.Dispose();
            base.Dispose(disposing);
        }
        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            base.OnClick(e);
        }
        /// <summary>
        /// 复制控件的属性
        /// </summary>
        /// <returns></returns>
        public Control Objectproperty(string Name, Form form)
        {
            using (UppercomputerEntities2 db = new UppercomputerEntities2())
            {
                //获取上个控件的值
                string path = this.Parent.ToString() + "- " + this.Name;
                var parameter = db.HScrollBar_parameter.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var Tag_common = db.Tag_common_parameters.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var locatio = db.control_location.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var contrclass = db.HScrollBar_Class.Where(pi => pi.ID.Trim() == path).FirstOrDefault();

                //产生新的控件
                HScrollBar_reform control = (HScrollBar_reform)this.Clone();

                Public_attributeCalss public_AttributeCalss = new Public_attributeCalss();//实例化按钮参数设置
                public_AttributeCalss.HScrollBar(control, contrclass);//查询数据库--进行设置后的参数修改
                //修改控件名称
                control.Name = Name.Trim();
                //设置控件产生的位置--判断是否超出边界
                CopySize.ControlSize(control, form);
                //获取窗口ID
                string From = parameter_indexes.Button_from_name(form.ToString());//获取窗口名称
                string contrpath = form.ToString() + "- " + Name;
                parameter.ID = contrpath;
                Tag_common.ID = contrpath;
                Tag_common.Control_type = Name;
                locatio.ID = contrpath;
                locatio.location = (numerical_public.Size_X(control.Left)).ToString() + "-" + (numerical_public.Size_Y(control.Top)).ToString();

                parameter.FORM = From.Trim();
                Tag_common.FROM = From;
                locatio.FORM = From;

                //重新向SQL插入数据
                HScrollBar_EF EF = new HScrollBar_EF();
                EF.HScrollBar_Parameter_Add(parameter);
                EF.HScrollBar_Parameter_Add(Tag_common);
                EF.HScrollBar_Parameter_Add(locatio);
                return control;
            }
        }
        /// <summary>
        /// 复制控件
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new HScrollBar_reform();//返回数据
        }
    }
}
