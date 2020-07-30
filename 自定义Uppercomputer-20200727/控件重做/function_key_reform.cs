using CCWin.SkinControl;
using DragResizeControlWindowsDrawDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_Library_da;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.控件重做.按钮类与宏指令通用类;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 继承UI_Button 实现功能键--画面切换
    /// 此类不能在窗口设计器中使用-如果需要使用请拖拽父类
    /// </summary>
    class function_key_reform : UI_Button
    {
        string LedDisplay_ID { get; set; }//文本属性ID
        SkinContextMenuStrip_reform menuStrip_Reform;//绑定右键菜单类
        /// <summary>
        /// 构造函数初始化控件UI
        /// </summary>
        public function_key_reform()
        {
            //this.InitChart_load();//初始化
            this.menuStrip_Reform = new SkinContextMenuStrip_reform();//实例化右键菜单
            this.ContextMenuStrip = this.menuStrip_Reform;//绑定右键菜单
            this.Cursor = Cursors.Hand;//改变鼠标状态
            this.MouseDown += MouseDown_reform;//注册事件
            this.MouseUp += MouseUp_reform;//注册事件
            this.MouseMove += MouseMove__reform;//注册事件
            this.MouseEnter += MouseEnter_reform;//注册事件--获取控件信息
            this.TextChanged += TextChanged_reform;//注册事件
            DragResizeControl.RegisterControl(this);//实现控件改变大小与拖拽位置
        }
        /// <summary>
        /// 重写点击事件--实现画面切换
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (Form2.edit_mode) return;//返回方法--用户开启了编辑模式
            foreach (Form frm in Application.OpenForms)//遍历所有窗口
            {
                if (frm.Name == this.Name)//判断窗口是否打开
                {
                    frm.Activate();//激活窗口
                    frm.WindowState = FormWindowState.Normal;//居中显示
                    return;//如果窗口已打开就放回方法
                }
            }
            Form2 form2 = new Form2();//实例化模板类--基类所有窗口继承于此类
            form2.Text = this.Name.Trim();//设置窗口名称
            form2.Name = this.Name.Trim();//设置窗口标识
            form2.WindowState = FormWindowState.Normal;//居中显示
            form2.Size = new System.Drawing.Size(1071, 745);//设置窗口大小
            form2.BackgroundImageLayout = ImageLayout.Stretch; //自动适应
            SkinLabel Label_Text = (SkinLabel)(from Control pi in form2.Controls where pi is SkinLabel select pi).First();
            Label_Text.Text = this.Text.Trim();//设置窗口名称
            form2.Show();//显示窗口
            for (int i1 = 0; i1 < 2; i1++)
            {
                FormCollection formCollection = Application.OpenForms;//获取窗口集合
                for (int i = 0; i < formCollection.Count; i++)
                {
                    if (formCollection[i].Text != "Home" & formCollection[i].Text != form2.Text)//关闭其余窗口
                    {
                        formCollection[i].Close();//关闭窗口
                    }
                }
                GC.Collect();//通知GC开始垃圾清理
            }
        }
        /// <方法重写当鼠标移到控件时获取——ID>
        private void MouseEnter_reform(object send, EventArgs e)
        {
            this.Cursor = Cursors.Hand;//改变鼠标状态
            function_key_reform button = (function_key_reform)send;//获取控件信息
            this.LedDisplay_ID = button.Parent.ToString();//写入信息
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
                button_EF.Button_Parameter_modification(this.Parent + "-" + this.Name
                    , new control_location
                    {
                        location = (numerical_public.Size_X(this.Location.X) + e.X - clickX).ToString() + "-" + (numerical_public.Size_Y(this.Location.Y) + e.Y - clickY).ToString(),
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
        ~function_key_reform()
        {
            this.MouseDown -= MouseDown_reform;//注册事件
            this.MouseUp -= MouseUp_reform;//注册事件
            this.MouseMove -= MouseMove__reform;//注册事件
            this.MouseEnter -= MouseEnter_reform;//注册事件--获取控件信息
            this.TextChanged -= TextChanged_reform;//注册事件
            DragResizeControl.UnRegisterControl(this);//实现控件改变大小与拖拽位置
            this.menuStrip_Reform.Dispose();
            this.Dispose();
        }
    }
}
