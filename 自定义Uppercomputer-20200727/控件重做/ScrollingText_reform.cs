using DragResizeControlWindowsDrawDemo;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.EF实体模型.EFtoSQL操作类重写;
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.控件重做.复制粘贴接口;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 引用第三方开源控件重构对事件方法等进行具体的实现
    /// 报警条
    /// </summary>
    [ToolboxItem(false)]
    class ScrollingText_reform : UIScrollingText, ControlCopy
    {
        string SkinLabel_ID { get; set; }//文本属性ID
        SkinContextMenuStrip_reform menuStrip_Reform;//绑定右键菜单类
        Event_time event_Time;//报警条遍历事件定时器
        public ScrollingText_reform(Form form)//构造函数
        {
            this.menuStrip_Reform = new SkinContextMenuStrip_reform();//实例化右键菜单
            this.ContextMenuStrip = this.menuStrip_Reform;//绑定右键菜单
            this.MouseDown += MouseDown_reform;//注册事件
            this.MouseUp += MouseUp_reform;//注册事件
            this.MouseMove += MouseMove__reform;//注册事件
            this.MouseEnter += MouseEnter_reform;//注册事件--获取控件信息
            this.TextChanged += TextChanged_reform;//注册事件
            DragResizeControl.RegisterControl(this);//实现控件改变大小与拖拽位置
            event_Time = new Event_time(this, form);//实例化报警条事件遍历
            event_Time.Start();//启动定时器
            this.Interval = 100;//文本刷新时间
            this.Size = new Size(200, 60);//设置大小
        }
        /// <方法重写当鼠标移到控件时获取——ID>
        private void MouseEnter_reform(object send, EventArgs e)
        {
            this.Cursor = Cursors.Hand;//改变鼠标状态
            ScrollingText_reform button = (ScrollingText_reform)send;//获取控件信息
            this.SkinLabel_ID = button.Parent.ToString();//写入信息
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
                button_EF.Button_Parameter_modification(this.Parent + "-" + this.Name
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
            event_Time.Stop();//停止定时器
            this.MouseDown -= MouseDown_reform;//注册事件
            this.MouseUp -= MouseUp_reform;//注册事件
            this.MouseMove -= MouseMove__reform;//注册事件
            this.MouseEnter -= MouseEnter_reform;//注册事件--获取控件信息
            this.TextChanged -= TextChanged_reform;//注册事件
            DragResizeControl.UnRegisterControl(this);
            menuStrip_Reform.Dispose();
            event_Time.Dispose();
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
                string path = this.Parent?.ToString() ?? SkinLabel_ID ;
                path += "-" + this.Name;
                var parameter = db.ScrollingText_parameter.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var Tag_common = db.Tag_common_parameters.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var locatio = db.control_location.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var AnalogMeter_class = db.ScrollingText_Class.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                //产生新的控件
                ScrollingText_reform control = (ScrollingText_reform)this.Clone(form);

                Public_attributeCalss public_AttributeCalss = new Public_attributeCalss();//实例化按钮参数设置
                public_AttributeCalss.attributeCalss(control, AnalogMeter_class);//查询数据库--进行设置后的参数修改

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

                parameter.FORM = From.Trim();
                Tag_common.FROM = From;
                locatio.FORM = From;

                //重新向SQL插入数据
                Button_EFbase EF = new Button_EFbase();
                EF.Button_Parameter_Add(parameter);
                EF.Button_Parameter_Add(Tag_common);
                EF.Button_Parameter_Add(locatio);
                return control;
            }
        }
        /// <summary>
        /// 复制控件
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new object();
            //return new ScrollingText_reform() as object;//返回数据
        }
        public object Clone(Form form)
        {
            return new ScrollingText_reform(form) as object;//返回数据
        }
    }
}
