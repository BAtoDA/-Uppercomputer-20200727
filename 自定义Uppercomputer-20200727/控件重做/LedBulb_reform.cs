using DragResizeControlWindowsDrawDemo;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.控件重做.复制粘贴接口;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 引用第三方开源控件重构对事件方法等进行具体的实现
    /// 指示灯
    /// </summary>LedBulb_parameter
    class LedBulb_reform : UILedBulb, ControlCopy
    {
        LedBulb_Class LedBulb_Class;//控件参数
        public enum Switch_pattern//切换开模式类型枚举
        {
            Set_as_on, Set_as_off, 切换开关, 复归型
        }
        public string Switch_ID { get; set; }//该按钮ID
        SkinContextMenuStrip_reform menuStrip_Reform;//绑定右键菜单类
        public LedBulb_reform()//构造函数
        {
            this.menuStrip_Reform = new SkinContextMenuStrip_reform();//实例化右键菜单
            this.ContextMenuStrip = this.menuStrip_Reform;//绑定右键菜单
            this.Cursor = Cursors.Hand;//改变鼠标状态
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
            LedBulb_reform button = (LedBulb_reform)send;//获取控件信息
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
            this.Focus();
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
            LedBulb_EF button_EF = new LedBulb_EF();//实例化EF
            LedBulb_Class = button_EF.Button_Parameter_Query(this.Parent + "-" + this.Name);//查询控件参数
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
                var button_colour = db.Button_colour.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var button_parameter = db.LedBulb_parameter.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var general_parameters_of_picture = db.General_parameters_of_picture.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var Tag_common = db.Tag_common_parameters.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var locatio = db.control_location.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                var contrsclass = db.LedBulb_Class.Where(pi => pi.ID.Trim() == path).FirstOrDefault();
                //产生新的控件
                LedBulb_reform button = (LedBulb_reform)this.Clone();

                Public_attributeCalss public_AttributeCalss = new Public_attributeCalss();//实例化按钮参数设置
                public_AttributeCalss.attributeCalss(button, contrsclass);//查询数据库--进行设置后的参数修改

                //修改控件名称
                button.Name = Name.Trim();
                //设置控件产生的位置--判断是否超出边界
                CopySize.ControlSize(button, form);
                //获取窗口ID
                string From = parameter_indexes.Button_from_name(form.ToString());//获取窗口名称
                string contrpath = form.ToString() + "-" + Name;
                button_parameter.ID = contrpath;
                general_parameters_of_picture.ID = contrpath;
                Tag_common.ID = contrpath;
                Tag_common.Control_type = Name;
                locatio.ID = contrpath;
                button_colour.ID = contrpath;
                locatio.location = (numerical_public.Size_X(button.Left)).ToString() + "-" + (numerical_public.Size_Y(button.Top)).ToString();

                button_parameter.FORM = From.Trim();
                general_parameters_of_picture.FORM = From;
                Tag_common.FROM = From;
                locatio.FORM = From;
                button_colour.FORM = From;

                //重新向SQL插入数据
                LedBulb_EF EF = new LedBulb_EF();
                EF.Button_Parameter_Add(button_parameter);
                EF.Button_Parameter_Add(general_parameters_of_picture);
                EF.Button_Parameter_Add(Tag_common);
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
            return new LedBulb_reform() as object;//返回数据
        }
        protected override void Dispose(bool disposing)//释放控件托管资源
        {         
            this.MouseEnter -= MouseEnter_reform;//移除事件
            this.Click -= Click_reform;//移除事件
            this.MouseDown -= MouseDown_reform;//移除事件
            this.MouseUp -= MouseUp_reform;//移除事件
            this.MouseMove -= MouseMove__reform;//移除事件
            this.DoubleClick -= DoubleClick_reform;//移除事件       
            DragResizeControl.UnRegisterControl(this);
            LedBulb_Class = null;
            menuStrip_Reform.Dispose();
            base.Dispose(disposing);
        }
    
    }
}
