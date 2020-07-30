using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.控件重做;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    public partial class Modification_label : Skin_VS
    {
        private string Button_ID;//控件的基本信息
        private object all_purpose;//通用类型
        public bool Add_to_allow = false;//反馈标志位是否允许添加
        label_Class label;//按钮类全部参数
        private string From_Name;//控件处在的窗口名称
        public Modification_label(string ID, object all_purpose)
        {
            InitializeComponent();
            this.Button_ID = ID;//获取参数
            this.all_purpose = all_purpose;
            this.skinTextBox1.Text = Button_ID + "-" + ((SkinLabel_reform)all_purpose).Name;//保存ID 为一地址  -是分割字符
            From_Name = parameter_indexes.Button_from_name(skinTextBox1.Text);//获取窗口名称
        }
        private void skinButton3_Click(object sender, EventArgs e)//关闭窗口
        {
            this.Close();
            this.Dispose();
        }

        #region 窗体关闭效果
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果
        #endregion
        private void Modification_label_Load(object sender, EventArgs e)//加载窗口
        {
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
            Modification_label_Class _Label_Class = new Modification_label_Class(new List<SkinTabPage>() { this.skinTabPage1, this.skinTabPage2, this.skinTabPage3 }, ((SkinLabel)all_purpose).Name);//加载
        }

        private void Modification_label_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
        }

        private void Modification_label_Shown(object sender, EventArgs e)
        {
            //查询数据库是否有该数据
            if (label_EF.label_Parameter_inquire(this.skinTextBox1.Text) == "OK")
            {
                label_EF label_EF = new label_EF();//实例化EF对象
                label = label_EF.label_Parameter_Query(this.skinTextBox1.Text);//获取按钮类全部参数
                List_Index();//开始改变索引
            }
            else
            {
                //新增控件获取位置与大小
                this.textBox1.Text = ((SkinLabel_reform)this.all_purpose).Location.X.ToString();//控件位置X轴
                this.skinTextBox2.Text = ((SkinLabel_reform)this.all_purpose).Location.Y.ToString();//控件位置Y轴
                this.skinTextBox4.Text = ((SkinLabel_reform)this.all_purpose).Size.Width.ToString();//控件大小宽度
                this.skinTextBox3.Text = ((SkinLabel_reform)this.all_purpose).Size.Height.ToString();//控件大小宽度
            }
        }
        private void List_Index()
        {
            parameter_indexes indexes = new parameter_indexes();//实例化索引器
            //按钮安全控制时间
            indexes.Button_ComboBoxIndex_fill("10", ref this.skinComboBox1);
            //按钮标签0-参数索引           
            indexes.Button_ComboBoxIndex_fill(label.Control_state_0_typeface, ref this.skinComboBox2);
            indexes.Button_ComboBoxIndex_fill(label.Control_state_0_colour, ref this.colorComboBox1);
            indexes.Button_ComboBoxIndex_fill(label.Control_state_0_size, ref this.skinComboBox3);
            indexes.Button_ComboBoxIndex_fill(label.Control_state_0_aligning, ref this.skinComboBox4);
            indexes.Button_ComboBoxIndex_fill(label.Control_state_0_flicker.ToString(), ref this.skinComboBox5);
            this.skinChatRichTextBox1.Text = label.Control_state_0_content.Trim();
            //获取控件位置-大小-等信息
            this.textBox1.Text = point_or_Size(label.location)[0].ToString();//控件位置X轴
            this.skinTextBox2.Text = point_or_Size(label.location)[1].ToString();//控件位置Y轴
            this.skinTextBox4.Text = point_or_Size(label.size)[0].ToString();//控件大小宽度
            this.skinTextBox3.Text = point_or_Size(label.size)[1].ToString();//控件大小宽度
        }

        private void skinButton2_Click(object sender, EventArgs e)//用户点击了确定
        {
            //先查询数据库有无此ID--有进行修改--无新增--
            label_EF label_EF = new label_EF();//实例化EF对象
            if (label_EF.label_Parameter_inquire(this.skinTextBox1.Text) == "OK")
                label_EF.label_Parameter_modification(this.skinTextBox1.Text, Label_Parameter(), tag_Common_Parameters(), control_Location());//修改数据库参数
            else
            {
                label_EF.label_Parameter_Add(Label_Parameter());//插入主参数
                label_EF.label_Parameter_Add(tag_Common_Parameters());//插入标签参数
                label_EF.label_Parameter_Add(control_Location());//插入控件坐标参数
            }
            Add_to_allow = true;
            ((SkinLabel_reform)all_purpose).Text = this.skinChatRichTextBox1.Text;//修改显示内容
            Public_attributeCalss public_AttributeCalss = new Public_attributeCalss();//实例化按钮参数设置
            public_AttributeCalss.attributeCalss((SkinLabel_reform)this.all_purpose,label_EF.label_Parameter_Query(this.skinTextBox1.Text.Trim()));//查询数据库--进行设置后的参数修改
            this.Close();
            this.Dispose();
        }
        private label_parameter Label_Parameter()//获取要写入的主参数
        {
            return new label_parameter
            {
                ID = skinTextBox1.Text,
                FORM = From_Name
            };
        }
        private Tag_common_parameters tag_Common_Parameters()//获取要写入的标签参数
        {
                return new Tag_common_parameters
                {
                    //写入0状态
                    Control_state_0 = 0,
                    Control_state_0_typeface = this.skinComboBox2.Text,
                    Control_state_0_colour = this.colorComboBox1.Text,
                    Control_state_0_size = this.skinComboBox3.Text,
                    Control_state_0_aligning = this.skinComboBox4.Text,
                    Control_state_0_flicker = this.skinComboBox5.Text.ToInt32(),
                    Control_state_0_content = this.skinChatRichTextBox1.Text,
                    //写入1状态
                    Control_state_1 = 1,
                    Control_state_1_typeface = this.skinComboBox2.Text,
                    Control_state_1_colour = this.colorComboBox1.Text,
                    Control_state_1_size = this.skinComboBox3.Text,
                    Control_state_1_aligning = this.skinComboBox4.Text,
                    Control_state_1_flicker = this.skinComboBox5.Text.ToInt32(),
                    Control_state_1_content1 = this.skinChatRichTextBox1.Text,
                    Control_type = ((SkinLabel)this.all_purpose).Name,
                    FROM = From_Name,
                    ID = skinTextBox1.Text
                };
         }
        private control_location control_Location()//获取要写入的控件位置
        {
            return new control_location
            {
                ID = skinTextBox1.Text,
                FORM = From_Name,
                location = this.textBox1.Text.Trim() + "-" + this.skinTextBox2.Text.Trim(),
                size = this.skinTextBox4.Text.Trim() + "-" + this.skinTextBox3.Text.Trim()
            };
        }
        private int[] point_or_Size(string Name)//分割-来自数据库的-位置与大小数据
        {
            string[] segmentation;//定义分割数组
            segmentation = Name.Split('-');
            return new int[] { Convert.ToInt32(segmentation[0] ?? "81"), Convert.ToInt32(segmentation[1] ?? "31") };
        }
        private void KeyPress_reform(object sender, KeyPressEventArgs e)//键盘事件--位置与大小数据
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {               
                if ((e.KeyChar < '0') || (e.KeyChar > '9') || ((TextBox)sender).Text.Length >3)//这是允许输入0-9数字 最大数据不能大于3位数  
                {                   
                    e.Handled = true;//只能输入数字
                }
            }
        }
    }
}
