using CCWin.SkinClass;
using CCWin.SkinControl;
using CSEngineTest;
using DragResizeControlWindowsDrawDemo;
using PLC通讯规范接口;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;   
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.EF实体模型.EFtoSQL操作类重写;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.控件重做.复制粘贴接口;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;
using 自定义Uppercomputer_20200727.控件重做.控件类基;
using 自定义Uppercomputer_20200727.控件重做.控件类基.文本__TO__PLC方法;
using 自定义Uppercomputer_20200727.文本输入键盘;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 本类主要重写系统数值输入控件
    /// 继承系统数值输入控件
    /// </summary>
    [ToolboxItem(false)]
    class SkinTextBox_reform : TextBox, ControlCopy, TextBox_base
    {
        string SkinTextBox_ID { get; set; }//文本属性ID
        SkinContextMenuStrip_reform menuStrip_Reform;//绑定右键菜单类
        numerical_Class numerical_Classes;//实例化当前控件参数
        bool write_ok;//太久用户不输入文本自动允许PLC写入数据
        public bool write_ok_plc { get => write_ok; }//控件允许输入状态--只读状态

        public System.Threading.Timer PLC_time { get; }

        public TextBox_PLC TextBox { get; }

        public string Data_Text { get => this.Text; }

        public SkinTextBox_reform()//构造函数
        {
            this.menuStrip_Reform = new SkinContextMenuStrip_reform();//实例化右键菜单
            this.ContextMenuStrip = this.menuStrip_Reform;//绑定右键菜单
            this.MouseDown += MouseDown_reform;//注册事件
            this.MouseUp += MouseUp_reform;//注册事件
            this.MouseMove += MouseMove__reform;//注册事件
            this.MouseEnter += MouseEnter_reform;//注册事件--获取控件信息
            this.KeyPress += numerical_KeyPress;//注册事件    
            this.MouseDown += numerical_MouseDown;//注册事件
            this.DoubleClick += numerical_DoubleClick;//注册事件
            DragResizeControl.RegisterControl(this);//实现控件改变大小与拖拽位置
            write_ok = true;//默认允许写入控件文本
            this.ReadOnly = true;//指示当前控件只读
            TextBox = new TextBox_PLC();
            PLC_time = new System.Threading.Timer(new TimerCallback((s) =>
            {
                this.Time_Tick();
            }));
            PLC_time.Change(500, 300);
            this.Size = new Size(83, 31);//设置大小
            this.Text = "0";//设置文本
            this.Lines = new string[] { typeof(SkinTextBox_reform).Name };//初次显示文字
        }
        /// <方法重写当鼠标移到控件时获取——ID>
        private void MouseEnter_reform(object send, EventArgs e)
        {
            this.Cursor = Cursors.Hand;//改变鼠标状态
            SkinTextBox_reform button = (SkinTextBox_reform)send;//获取控件信息
            this.SkinTextBox_ID = button.Parent.ToString();//写入信息
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
        /// <方法重写实现不允许用输入--使用键盘 —>
        private void numerical_KeyPress(object sender, KeyPressEventArgs e)//键盘事件
        {            
            e.Handled = true; //不允许用输入--使用键盘        
        }
        /// <方法重写实现当鼠标在控件上方按下时触发--获取数据库中相应控件的参数—实现参数写入与约束>
        private void numerical_MouseDown(object sender, MouseEventArgs e)//当前控件当鼠标在控件上方按下时触发--获取数据库中相应控件的参数
        {
            Button_EFbase numerical_EF = new Button_EFbase();//实例化EF对象
            numerical_Classes=numerical_EF.Button_Parameter_Query<numerical_Class>(((SkinTextBox_reform)sender).Parent + "- " + ((SkinTextBox_reform)sender).Name);//查询控件参数信息            
        }
        /// <方法重写实现用户双击控件---进入键盘—实现参数写入与约束>
        private void numerical_DoubleClick(object sender, EventArgs e)//用户双击控件---进入键盘
        {
            /// <方法定时擦除用户是否在输入>
            write_ok = false;//不允许修改控件
            if (numerical_Classes.资料格式.Trim() == "Hex_16_Bit" || numerical_Classes.资料格式.Trim() == "Hex_32_Bit"||numerical_Classes.读写设备.Trim()== "HMI")
            {
                keyboard_Hex keyboard_Hex = new keyboard_Hex(this.Text, numerical_Classes);//实例化Hex键盘
                keyboard_Hex.ShowDialog();//显示窗口
                this.Text = keyboard_Hex.O_Text;//获取用户输入的文本
            }
            else
            {
                keyboard keyboard = new keyboard(this.Text, numerical_Classes);//调出键盘
                keyboard.ShowDialog();//显示窗口
                this.Text = keyboard.O_Text;//获取用户输入的文本
            }
            write_ok = true;//允许修改控件
            //把控件文本写到PLC
            TextBox.plc(numerical_Classes.读写设备.Trim(),numerical_Classes.资料格式.Trim(),numerical_Classes.读写设备_地址.Trim(),numerical_Classes.读写设备_地址_具体地址.Trim(),numerical_Classes.读写不同地址_ON_OFF,numerical_Classes.写设备_地址_复选.Trim(),numerical_Classes.写设备_地址_具体地址_复选.Trim(),this.Text);//选择相应PLC 进行写入
        }
        protected override void Dispose(bool disposing)
        {
            this.MouseDown -= MouseDown_reform;//注册事件
            this.MouseUp -= MouseUp_reform;//注册事件
            this.MouseMove -= MouseMove__reform;//注册事件
            this.MouseEnter -= MouseEnter_reform;//注册事件--获取控件信息
            this.KeyPress -= numerical_KeyPress;//注册事件    
            this.MouseDown -= numerical_MouseDown;//注册事件 
            this.DoubleClick -= numerical_DoubleClick;//注册事件
            this.menuStrip_Reform.Dispose();
            this.PLC_time.Dispose();
            DragResizeControl.UnRegisterControl(this);
            base.Dispose(disposing);
        }
        /// <summary>
        /// 填充文本数据
        /// </summary>
        /// <param name="skinTextBox_Reform"></param>
        /// <param name="numerical_Class"></param>
        /// <param name="Data"></param>
        private void TextBox_state(SkinTextBox_reform skinTextBox_Reform, numerical_Class numerical_Class, string Data)//填充文本数据
        {
            try
            {
                int Inde = Data.IndexOf('.');//搜索数据是否有小数点
                if (Inde > 0 || Inde >= numerical_Class.小数点以下位数.ToInt32())//判断是否有小数点
                {
                    int In = Data.Length - 1 - numerical_Class.小数点以下位数.ToInt32() - Inde;//实现原理--先获取数据长度-后减1-小数点-在减去设定数-获取小数点位置
                    for (int i = 0; i < In; i++) Data = Data.Remove(Data.Length - 1, 1); //移除掉                
                }
                else
                    Data = TextBox.complement(Data, numerical_Class.小数点以下位数.Trim().ToInt32());//然后位数不够--自动补码
                if (numerical_Class.小数点以下位数.ToInt32() < 1) Data = Data.Replace('.', ' ');//如果用户设定没有小数点直接去除小数点
                skinTextBox_Reform.Text = Data;//直接填充数据
            }
            catch { return; }
        }
        numerical_Class _Class;
        /// <summary>
        /// 定时刷新控件
        /// </summary>
        private void Time_Tick()
        {
            lock (this)
            {
                try
                {
                    if (Form2.edit_mode == true)
                    {
                        _Class = null;
                        return;//返回方法
                    }
                    if (_Class.IsNull()||_Class.ID.IsNull())
                    {
                        Button_EFbase EF = new Button_EFbase();//实例化EF
                        _Class = EF.Button_Parameter_Query<numerical_Class>(this.Parent + "- " + this.Name);//查询控件参数
                    }
                    if (_Class.ID.IsNull()) return;
                    this.TextBox_state(this, _Class, TextBox.Refresh(_Class.读写设备.Trim(), _Class.资料格式.Trim(), _Class.读写设备_地址.Trim(), _Class.读写设备_地址_具体地址.Trim()));
                }
                catch
                {

                }
            }
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
                string path = this.Parent?.ToString() ?? SkinTextBox_ID;
                path += "- " + this.Name;
                var button_colour = db.Button_colour.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var button_parameter = db.numerical_parameter.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var general_parameters_of_picture = db.General_parameters_of_picture.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var Tag_common = db.Tag_common_parameters.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var locatio = db.control_location.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var contrsclass = db.numerical_Class.Where(pi => pi.ID.Trim() == path).FirstOrDefault();

                //产生新的控件
                SkinTextBox_reform button = (SkinTextBox_reform)this.Clone();

                Public_attributeCalss public_AttributeCalss = new Public_attributeCalss();//实例化按钮参数设置
                public_AttributeCalss.attributeCalss(button, contrsclass);//查询数据库--进行设置后的参数修改

                //修改控件名称
                button.Name = Name.Trim();
                //设置控件产生的位置--判断是否超出边界
                CopySize.ControlSize(button, form);
                //获取窗口ID
                string From = parameter_indexes.Button_from_name(form.ToString());//获取窗口名称
                string contrpath = form.ToString() + "- " + Name;
                button_parameter.ID = contrpath;
                button_colour.ID = contrpath;
                general_parameters_of_picture.ID = contrpath;
                Tag_common.ID = contrpath;
                Tag_common.Control_type = Name;
                locatio.ID = contrpath;
                locatio.location = (numerical_public.Size_X(button.Left)).ToString() + "-" + (numerical_public.Size_Y(button.Top)).ToString();

                button_parameter.FORM = From.Trim();
                button_colour.FORM = From.Trim();
                general_parameters_of_picture.FORM = From;
                Tag_common.FROM = From;
                locatio.FORM = From;

                //重新向SQL插入数据
                Button_EFbase EF = new Button_EFbase();
                EF.Button_Parameter_Add(button_parameter);
                EF.Button_Parameter_Add(Tag_common);
                EF.Button_Parameter_Add(general_parameters_of_picture);
                EF.Button_Parameter_Add(locatio);
                EF.Button_Parameter_Add(button_colour);
                return button;
            }
        }
        /// <summary>
        /// 复制控件
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new SkinTextBox_reform() as object;//返回数据
        }

        public void ControlRefresh(string Data)
        {
            throw new NotImplementedException();
        }
    }
}
