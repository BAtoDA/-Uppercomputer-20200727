using CCWin.SkinClass;
using CCWin.SkinControl;
using DragResizeControlWindowsDrawDemo;
using PLC通讯规范接口;
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
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.控件重做.复制粘贴接口;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;
using 自定义Uppercomputer_20200727.控件重做.控件类基;
using 自定义Uppercomputer_20200727.控件重做.控件类基.按钮__TO__PLC方法;

namespace 自定义Uppercomputer_20200727.控件重做
{ 
    /// <summary>
   /// 引用第三方开源控件重构对事件方法等进行具体的实现
   /// 切换开关
   /// </summary>
    class Switch_reform : UI_Switch, ControlCopy, Button_base
    {
        Switch_Class Switch_Class;//控件参数
        public enum Switch_pattern//切换开模式类型枚举
        {
            Set_as_on, Set_as_off, 切换开关, 复归型
        }
        public string Switch_ID { get; set; }//该按钮ID

        public System.Threading.Timer PLC_time { get; }

        public Button_to_plc button_PLC { get; }

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
            button_PLC = new Button_to_plc();
            PLC_time = new System.Threading.Timer(new TimerCallback((s) =>
            {
                this.Time_Tick();
            }));
            PLC_time.Change(500, 300);
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
            //当按钮按下触发—写入PLC状态
            this.BeginInvoke((EventHandler)delegate
            {
                if (Form2.edit_mode || Switch_Class.位指示灯.Trim() == "1") return;
                Switch_EF button_EF = new Switch_EF();//实例化EF
                Switch_Class = button_EF.Button_Parameter_Query(this.Parent + "-" + this.Name);//查询控件参数
                if (Switch_Class.读写不同地址_ON_OFF == 0)
                    button_PLC.plc(Switch_Class.读写设备.Trim(), Switch_Class.操作模式.Trim(), Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Switch_Class.读写不同地址_ON_OFF, Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim());//选择相应PLC 进行写入
                else
                    button_PLC.plc(Switch_Class.写设备_复选.Trim(), Switch_Class.操作模式.Trim(), Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Switch_Class.读写不同地址_ON_OFF, Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim());//选择相应PLC 进行写入
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
                        location = (numerical_public.Size_X(this.Left)).ToString() + "-" + (numerical_public.Size_Y(this.Top)).ToString(),
                        size = (numerical_public.Size_X(this.Size.Width) + "-" + numerical_public.Size_Y(this.Size.Height))
                    });
                startMove = false;
            }
            if (Form2.edit_mode) return;
            if (button_PLC.state)
            {
                if (Switch_Class.读写不同地址_ON_OFF == 0)
                    ThreadPool.QueueUserWorkItem((sr) =>
                    {
                        button_PLC.plc(Switch_Class.读写设备.Trim(), Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Switch_Class.读写不同地址_ON_OFF, Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), button_PLC.state);
                    });//选择相应PLC--复归型按钮--把任务交到线程池序列
                else
                    ThreadPool.QueueUserWorkItem((sr) => {
                        button_PLC.plc(Switch_Class.写设备_复选.Trim(), Switch_Class.读写设备_地址.Trim(), Switch_Class.读写设备_地址_具体地址.Trim(), Switch_Class.读写不同地址_ON_OFF, Switch_Class.写设备_地址_复选.Trim(), Switch_Class.写设备_地址_具体地址_复选.Trim(), button_PLC.state);
                    });//选择相应PLC--复归型按钮--把任务交到线程池序列
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
    
        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            base.OnClick(e);
        }
        protected override void Dispose(bool disposing)
        {
            this.MouseEnter -= MouseEnter_reform;//移除事件
            this.Click -= Click_reform;//移除事件
            this.MouseDown -= MouseDown_reform;//移除事件
            this.MouseUp -= MouseUp_reform;//移除事件
            this.MouseMove -= MouseMove__reform;//移除事件
            this.DoubleClick -= DoubleClick_reform;//移除事件
            menuStrip_Reform.Dispose();
            PLC_time.Dispose();
            DragResizeControl.UnRegisterControl(this);
            base.Dispose(disposing);
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
                string path = this.Parent.ToString() + "-" + this.Name;
                var parameter = db.Switch_parameter.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var Tag_common = db.Tag_common_parameters.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var locatio = db.control_location.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var contrclass = db.Switch_Class.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var contrcolor = db.Button_colour.Where(pi => pi.ID.Trim() == path).FirstOrDefault();

                //产生新的控件
                Switch_reform control = (Switch_reform)this.Clone();

                Public_attributeCalss public_AttributeCalss = new Public_attributeCalss();//实例化按钮参数设置
                public_AttributeCalss.attributeCalss(control, contrclass);//查询数据库--进行设置后的参数修改
                //修改控件名称
                control.Name = Name.Trim();

                //设置控件产生的位置--判断是否超出边界
                CopySize.ControlSize(control, form);
                //获取窗口ID
                string From = parameter_indexes.Button_from_name(form.ToString());//获取窗口名称
                string contrpath = form.ToString() + "-" + Name;
                parameter.ID = contrpath;
                Tag_common.ID = contrpath;
                Tag_common.Control_type = Name;
                locatio.ID = contrpath;
                locatio.location = (numerical_public.Size_X(control.Left)).ToString() + "-" + (numerical_public.Size_Y(control.Top)).ToString();
                contrcolor.ID = contrpath;

                parameter.FORM = From.Trim();
                Tag_common.FROM = From;
                locatio.FORM = From;
                contrcolor.FORM = From;

                //重新向SQL插入数据
                Switch_EF EF = new Switch_EF();
                EF.Button_Parameter_Add(parameter);
                EF.Button_Parameter_Add(Tag_common);
                EF.Button_Parameter_Add(locatio);
                EF.Button_Parameter_Add(contrcolor);

                return control;
            }
        }
        /// <summary>
        /// 复制控件
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Switch_reform() as object;//返回数据
        }
        /// <summary>
        /// 填充切换开关类
        /// </summary>
        /// <param name="button_Reform"></param>
        /// <param name="button_Classes"></param>
        /// <param name="button_State"></param>
        private void button_state(Switch_reform button_Reform, Switch_Class button_Classes, Button_state button_State)//填充切换开关类
        { 
            try
            {

                switch (button_State)
                {
                    case Button_state.Off:
                        button_Reform.Text = button_Classes.Control_state_0_content.Trim();//设置文本
                        button_Reform.BackColor = Color.FromName(button_Classes.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_0_typeface.Trim(), button_Classes.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.TextAlign = button_PLC.ContentAlignment_1(button_Classes.Control_state_0_aligning.Trim());//设置对齐方式
                        button_Reform.BackColor = Color.FromName("182, 182, 182");//填充背景颜色--默认
                        button_Reform.Active = false;
                        button_Reform.InActiveColor = Color.FromName(button_Classes.colour_0.Trim());//获取数据库中颜色名称进行设置
                        break;
                    case Button_state.ON:
                        button_Reform.Text = button_Classes.Control_state_1_content1.Trim();//设置文本
                        button_Reform.BackColor = Color.FromName(button_Classes.Control_state_1_colour.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_1_typeface.Trim(), button_Classes.Control_state_1_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.TextAlign = button_PLC.ContentAlignment_1(button_Classes.Control_state_1_aligning.Trim());//设置对齐方式
                        button_Reform.BackColor = Color.FromName("182, 182, 182");//填充背景颜色--默认
                        button_Reform.Active = true;
                        button_Reform.InActiveColor = Color.FromName(button_Classes.colour_1.Trim());//获取数据库中颜色名称进行设置
                        break;
                }
            }
            catch { return; }
        }
        Switch_Class _Class;
        public void Time_Tick()
        {
            try
            {
                if (Form2.edit_mode == true)
                {
                    _Class = null;
                    return;//返回方法
                }
                if (_Class.IsNull())
                {
                    Switch_EF EF = new Switch_EF();//实例化EF
                    _Class = EF.Button_Parameter_Query(this.Parent + "-" + this.Name);//查询控件参数
                }
                if (_Class.IsNull()) return;
                this.button_state(this, _Class, button_PLC.Refresh(this, _Class.读写设备.Trim(), _Class.读写设备_地址.Trim(), _Class.读写设备_地址_具体地址.Trim()));
            }
            catch
            {

            }
        }
        public void ControlRefresh(Button_state button_State)
        {
            throw new NotImplementedException();
        }
    }
}
