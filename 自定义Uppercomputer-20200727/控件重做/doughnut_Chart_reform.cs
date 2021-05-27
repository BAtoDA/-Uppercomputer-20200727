using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_Library_da;
using 自定义Uppercomputer_20200727.EF实体模型;
using DragResizeControlWindowsDrawDemo;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.控件重做.复制粘贴接口;
using 自定义Uppercomputer_20200727.控件重做.控件类基;
using 自定义Uppercomputer_20200727.控件重做.控件类基.文本__TO__PLC方法;
using System.Threading;
using CCWin.SkinControl;
using System.ComponentModel;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 继承Chart实现圆环图形绘制
    /// 此类不能在窗口设计器中使用-如果需要使用请拖拽父类
    /// </summary>
    [ToolboxItem(false)]
    class doughnut_Chart_reform : doughnut_Chart, ControlCopy, TextBox_base
    {
        string doughnut_Chart_ID { get; set; }//圆环图形属性ID

        public System.Threading.Timer PLC_time { get; }

        public TextBox_PLC TextBox { get; }

        public string Data_Text { get => this.Text; }

        SkinContextMenuStrip_reform menuStrip_Reform;//绑定右键菜单类
        /// <summary>
        /// 构造函数初始化控件UI
        /// </summary>
        public doughnut_Chart_reform()
        {
            this.doughnut_Chart_Load();//初始化
            this.menuStrip_Reform = new SkinContextMenuStrip_reform();//实例化右键菜单
            this.ContextMenuStrip = this.menuStrip_Reform;//绑定右键菜单
            this.Cursor = Cursors.Hand;//改变鼠标状态
            this.MouseDown += MouseDown_reform;//注册事件
            this.MouseUp += MouseUp_reform;//注册事件
            this.MouseMove += MouseMove__reform;//注册事件
            this.MouseEnter += MouseEnter_reform;//注册事件--获取控件信息
            this.TextChanged += TextChanged_reform;//注册事件
            DragResizeControl.RegisterControl(this);//实现控件改变大小与拖拽位置
            TextBox = new TextBox_PLC();
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
            doughnut_Chart_reform button = (doughnut_Chart_reform)send;//获取控件信息
            this.doughnut_Chart_ID = button.Parent.ToString();//写入信息
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
                Button_EF button_EF = new Button_EF();//实例化EF
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
        /// <方法重写实现字体大小改变控件Size大小功能—>
        private void TextChanged_reform(object sender, EventArgs e)//自动改变Size
        {
            this.Text = this.Text.Trim();//去除空白
            this.AutoSize = true;//控件大小根据字体改变
        }
        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            base.OnClick(e);
        }
        protected override void Dispose(bool disposing)
        {
            this.MouseDown -= MouseDown_reform;//移除事件
            this.MouseUp -= MouseUp_reform;//移除事件
            this.MouseMove -= MouseMove__reform;//移除事件
            DragResizeControl.UnRegisterControl(this);//实现控件改变大小与拖拽位置
            this.menuStrip_Reform.Dispose();
            PLC_time.Dispose();
            base.Dispose(disposing);
        }
        /// <summary>
        /// 填充文本数据 doughnut_Chart
        /// </summary>
        /// <param name="doughnut_Chart_Reform"></param>
        /// <param name="doughnut_Chart_Class"></param>
        /// <param name="Data"></param>
        private void TextBox_state(List<int> doughnut_Chart_Data)//填充文本数据
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate//委托当前窗口处理控件UI
                {
                    if (this.Load_number != doughnut_Chart_Data.Count) return;
                    this.doughnut_Chart_Data_INT = doughnut_Chart_Data;//获取要填充的数据
                    this.doughnut_Chart_Load();//重新刷新UI
                });
            }
            catch { return; }
        }
        doughnut_Chart_Class _Class;
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
                    if (_Class.IsNull())
                    {
                        doughnut_Chart_EF EF = new doughnut_Chart_EF();//实例化EF
                        _Class = EF.doughnut_Chart_Parameter_Query(this.Parent + "- " + this.Name);//查询控件参数
                    }
                    if (_Class.IsNull()) return;
                    this.TextBox_state(TextBox.Refresh(_Class.读写设备.Trim(), _Class.资料格式.Trim(), _Class.读写设备_地址.Trim(), _Class.读写设备_地址_具体地址.Trim(), _Class.通道数量));
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
                string path = this.Parent.ToString() + "- " + this.Name;
                var parameter = db.doughnut_Chart_parameter.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var Tag_common = db.Tag_common_parameters.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var locatio = db.control_location.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var contrclass = db.doughnut_Chart_Class.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var contrcolor=db.Button_colour.Where(pi => pi.ID.Trim() == path).FirstOrDefault();

                //产生新的控件
                doughnut_Chart_reform control = (doughnut_Chart_reform)this.Clone();

                Public_attributeCalss public_AttributeCalss = new Public_attributeCalss();//实例化按钮参数设置
                public_AttributeCalss.attributeCalss(control, contrclass);//查询数据库--进行设置后的参数修改
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
                contrcolor.ID = contrpath;

                parameter.FORM = From.Trim();
                Tag_common.FROM = From;
                locatio.FORM = From;
                contrcolor.FORM= From;

                //重新向SQL插入数据
                doughnut_Chart_EF EF = new doughnut_Chart_EF();
                EF.doughnut_Chart_Parameter_Add(parameter);
                EF.doughnut_Chart_Parameter_Add(Tag_common);
                EF.doughnut_Chart_Parameter_Add(locatio);
                EF.doughnut_Chart_Parameter_Add(contrcolor);

                return control;
            }
        }
        /// <summary>
        /// 复制控件
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new doughnut_Chart_reform() as object;//返回数据
        }

        public void ControlRefresh(string Data)
        {
            throw new NotImplementedException();
        }
    }
}
