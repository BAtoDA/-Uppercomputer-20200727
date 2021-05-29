using CCWin.SkinClass;
using CCWin.SkinControl;
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
using 自定义Uppercomputer_20200727.控件重做.控件类基.按钮__TO__PLC方法;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 本类主要重写按钮的属性
    /// 重写
    /// </summary>
    [ToolboxItem(false)]
    class Button_reform : SkinButton, ControlCopy, Button_base
    {

        public Button_to_plc button_PLC { get; }
        public Button_Class Button_Class;//控件参数
        public string Button_ID { get; set; }//该按钮ID

        public System.Threading.Timer PLC_time { get; }

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
            button_PLC = new Button_to_plc();
            PLC_time = new System.Threading.Timer(new TimerCallback((s) =>
            {
                this.Time_Tick();
            }));
            PLC_time.Change(500, 300);
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
                Button_EFbase button_EF = new Button_EFbase();//实例化EF
                Button_Class = button_EF.Button_Parameter_Query<Button_Class>(this.Parent + "-" + this.Name);//查询控件参数
                if (Form2.edit_mode || Button_Class.位指示灯.Trim() == "1") return;
                if (Button_Class.读写不同地址_ON_OFF == 0)
                    button_PLC.plc(Button_Class.读写设备.Trim(), Button_Class.操作模式.Trim(), Button_Class.读写设备_地址.Trim(),Button_Class.读写设备_地址_具体地址.Trim(), Button_Class.读写不同地址_ON_OFF,Button_Class.写设备_地址_复选.Trim(),Button_Class.写设备_地址_具体地址_复选.Trim());//选择相应PLC 进行写入
                else
                    button_PLC.plc(Button_Class.写设备_复选.Trim(), Button_Class.操作模式.Trim(), Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_Class.读写不同地址_ON_OFF, Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim());//选择相应PLC 进行写入
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
                Button_EFbase button_EF = new Button_EFbase();//实例化EF
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
                if (Button_Class.读写不同地址_ON_OFF == 0)
                    ThreadPool.QueueUserWorkItem((sr)=> 
                    {
                        button_PLC.plc(Button_Class.读写设备.Trim(), Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_Class.读写不同地址_ON_OFF, Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), button_PLC.state);
                    });//选择相应PLC--复归型按钮--把任务交到线程池序列
                else
                    ThreadPool.QueueUserWorkItem((sr) => {
                        button_PLC.plc(Button_Class.写设备_复选.Trim(), Button_Class.读写设备_地址.Trim(), Button_Class.读写设备_地址_具体地址.Trim(), Button_Class.读写不同地址_ON_OFF, Button_Class.写设备_地址_复选.Trim(), Button_Class.写设备_地址_具体地址_复选.Trim(), button_PLC.state);
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
                string path = this.Parent.ToString() + "-" + this.Name;
                var button_colour = db.Button_colour.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var button_parameter = db.Button_parameter.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var general_parameters_of_picture = db.General_parameters_of_picture.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var Tag_common = db.Tag_common_parameters.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var locatio = db.control_location.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var contrsclass = db.Button_Class.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                //产生新的控件
                Button_reform button =(Button_reform) this.Clone();

                Public_attributeCalss public_AttributeCalss = new Public_attributeCalss();//实例化按钮参数设置
                public_AttributeCalss.attributeCalss(button, contrsclass);//查询数据库--进行设置后的参数修改

                //修改控件名称
                button.Name = Name.Trim();
                //设置控件产生的位置--判断是否超出边界
                CopySize.ControlSize(button, form);
                //获取窗口ID
                string From= parameter_indexes.Button_from_name(form.ToString());//获取窗口名称
                string contrpath = form.ToString() + "-" + Name;
                button_parameter.ID = contrpath;
                button_colour.ID = contrpath;
                general_parameters_of_picture.ID= contrpath;
                Tag_common.ID= contrpath;
                Tag_common.Control_type= Name;
                locatio.ID= contrpath;
                locatio.location = (numerical_public.Size_X(button.Left)).ToString() + "-" + (numerical_public.Size_Y(button.Top)).ToString();

                button_parameter.FORM = From.Trim();
                button_colour.FORM= From.Trim();
                general_parameters_of_picture.FORM = From;
                Tag_common.FROM= From;
                locatio.FORM= From;

                //重新向SQL插入数据
                Button_EFbase EF = new Button_EFbase();
                EF.Button_Add(button_parameter, Tag_common, general_parameters_of_picture, locatio, button_colour);
                return button;
            }
        }
        /// <summary>
        /// 复制控件
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {  
            return new Button_reform() as object;//返回数据
        }
        /// <summary>
        /// 填充按钮类
        /// </summary>
        /// <param name="button_Reform"></param>
        /// <param name="button_Classes"></param>
        /// <param name="button_State"></param>
        public void button_state(Button_reform button_Reform, Button_Class button_Classes, Button_state button_State)//填充按钮类
        {
            try
            {
                switch (button_State)
                {
                    case Button_state.Off:
                        button_Reform.Text = button_Classes.Control_state_0_content.Trim();//设置文本
                        button_Reform.ForeColor = Color.FromName(button_Classes.Control_state_0_colour.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_0_typeface.Trim(), button_Classes.Control_state_0_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.TextAlign = button_PLC.ContentAlignment_1(button_Classes.Control_state_0_aligning.Trim());//设置对齐方式
                        button_Reform.BaseColor = Color.FromName(button_Classes.colour_0.Trim());//设置样式
                        button_Reform.DownBaseColor = Color.FromName(button_Classes.colour_0.Trim());//设置样式
                        break;
                    case Button_state.ON:
                        button_Reform.Text = button_Classes.Control_state_1_content1.Trim();//设置文本
                        button_Reform.ForeColor = Color.FromName(button_Classes.Control_state_1_colour.Trim());//获取数据库中颜色名称进行设置
                        button_Reform.Font = new Font(button_Classes.Control_state_1_typeface.Trim(), button_Classes.Control_state_1_size.ToInt32(), FontStyle.Bold);//设置字体与大小
                        button_Reform.TextAlign = button_PLC.ContentAlignment_1(button_Classes.Control_state_1_aligning.Trim());//设置对齐方式
                        button_Reform.BaseColor = Color.FromName(button_Classes.colour_1.Trim());//设置样式
                        button_Reform.DownBaseColor = Color.FromName(button_Classes.colour_1.Trim());//设置样式
                        break;
                }
            }
            catch { return; }
        }
        protected override void Dispose(bool disposing)
        {
            this.Click -= Click_reform;//移除事件
            this.MouseDown -= MouseDown_reform;//移除事件
            this.MouseUp -= MouseUp_reform;//移除事件
            this.MouseMove -= MouseMove__reform;//移除事件
            this.DoubleClick -= DoubleClick_reform;//移除事件`
            DragResizeControl.UnRegisterControl(this);//实现控件改变大小与拖拽位置
            Button_Class = null;
            this.menuStrip_Reform.Dispose();
            PLC_time.Dispose();
            base.Dispose(disposing);
        }
        Button_Class _Class;
        public void Time_Tick()
        {
            if (this.IsDisposed || this.Created == false) return;//用户不开启PLC功能

            lock (this)
            {
                try
                {
                    this.BeginInvoke((EventHandler)delegate
                    {
                        if (Form2.edit_mode == true)
                        {
                            _Class = null;
                            return;//返回方法
                            }
                        if (_Class.IsNull())
                        {
                            Button_EFbase EF = new Button_EFbase();//实例化EF
                                _Class = EF.Button_Parameter_Query<Button_Class>(this.Parent + "-" + this.Name);//查询控件参数
                            }
                        if (_Class.IsNull()) return;
                        this.button_state(this, _Class, button_PLC.Refresh(this, _Class.读写设备.Trim(), _Class.读写设备_地址.Trim(), _Class.读写设备_地址_具体地址.Trim()));
                    });
                }
                catch
                {

                }
            }
        }
        public void ControlRefresh(Button_state button_State)
        {
        }
    }
}
