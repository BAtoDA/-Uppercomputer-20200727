using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.图库;
using 自定义Uppercomputer_20200727.控件重做;

namespace 自定义Uppercomputer_20200727.修改参数界面.ImageButton按钮参数
{
    public partial class Modification_ImageButton : Skin_VS
    {
        private string Button_ID;//控件的基本信息
        private object all_purpose;//通用类型
        public bool Add_to_allow = false;//反馈标志位是否允许添加
        ImageButton_Class button;//按钮类全部参数
        private string From_Name;//控件处在的窗口名称
        public Modification_ImageButton(string ID, object all_purpose)
        {
            InitializeComponent();
            this.Button_ID = ID;//获取参数
            this.all_purpose = all_purpose;
            skinTextBox8.Text = Button_ID + "-" + ((ImageButton_reform)this.all_purpose).Name;//保存ID 为一地址  -是分割字符 
            From_Name = parameter_indexes.Button_from_name(skinTextBox8.Text);//获取窗口名称
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            Mapdepot mapdepot = new Mapdepot();
            mapdepot.ShowDialog();
            var T = all_purpose.GetType().ToString();
        }

        private void Modification_ImageButton_Shown(object sender, EventArgs e)
        {
            //查询数据库是否有该数据
            if (ImageButton_EF.Button_Parameter_inquire(this.skinTextBox8.Text) == "OK")
            {
                ImageButton_EF button_EF = new ImageButton_EF();//实例化EF对象
                button = button_EF.Button_Parameter_Query(this.skinTextBox8.Text);//获取按钮类全部参数
                List_Index();//开始改变索引
                if (skinRadioButton1.Checked == false & skinRadioButton4.Checked == false) skinRadioButton1.Checked = true;
            }
            else
            {
                //新增控件获取位置与大小
                this.skinTextBox1.Text = ((ImageButton_reform)this.all_purpose).Location.X.ToString();//控件位置X轴
                this.skinTextBox2.Text = ((ImageButton_reform)this.all_purpose).Location.Y.ToString();//控件位置Y轴
                this.skinTextBox4.Text = ((ImageButton_reform)this.all_purpose).Size.Width.ToString();//控件大小宽度
                this.skinTextBox3.Text = ((ImageButton_reform)this.all_purpose).Size.Height.ToString();//控件大小宽度
                if (skinRadioButton1.Checked == false & skinRadioButton4.Checked == false) skinRadioButton1.Checked = true;
                if (skinRadioButton1.Checked == true & skinRadioButton4.Checked == true) { skinRadioButton1.Checked = true; skinRadioButton4.Checked = false; }
            }
        }

        private void skinButton3_Click(object sender, EventArgs e)
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
        private void Modification_ImageButton_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
            Modification_Button_Class modification_Button = new Modification_Button_Class
           (new List<SkinTabPage> { this.skinTabPage1, this.skinTabPage2, this.skinTabPage3, this.skinTabPage4, this.skinTabPage5 }, ((ImageButton_reform)this.all_purpose).Name, ((ImageButton_reform)this.all_purpose).Parent.ToString() + "-" + ((ImageButton_reform)this.all_purpose).Name);//调用加载数据类                
        }
    
        private void Modification_ImageButton_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
        }
        private void List_Index()
        {
            parameter_indexes indexes = new parameter_indexes();//实例化索引器
            //改变一般参数索引
            indexes.Button_ComboBoxIndex_fill(button.读写设备, ref this.skinComboBox13);
            indexes.Button_ComboBoxIndex_fill(button.读写设备_地址, ref this.skinComboBox12);
            skinTextBox7.Text = button.读写设备_地址_具体地址.Trim();
            skinCheckBox1.Checked = button.读写不同地址_ON_OFF > 0 ? true : false;
            if (skinCheckBox1.Checked) skinGroupBox6.Visible = true;
            indexes.Button_ComboBoxIndex_fill(button.写设备_复选, ref this.skinComboBox11);
            indexes.Button_ComboBoxIndex_fill(button.写设备_地址_复选, ref this.skinComboBox10);
            skinTextBox6.Text = button.写设备_地址_具体地址_复选;
            indexes.Button_ComboBoxIndex_fill(button.操作模式, ref this.skinComboBox9);
            skinRadioButton1.Checked = button.位切换开关.Trim() == "1" ? true : false;
            skinRadioButton4.Checked = button.位指示灯.Trim() == "1" ? true : false;
            //按钮安全控制时间
            indexes.Button_ComboBoxIndex_fill(button.操作安全时间, ref this.skinComboBox1);
            //按钮标签0-参数索引
            Modification_label_parameter.label_Lists[button.Control_state_0].Status = button.Control_state_0;
            indexes.Button_ComboBoxIndex_fill(button.Control_state_0_typeface, ref this.skinComboBox3);
            indexes.Button_ComboBoxIndex_fill(button.Control_state_0_colour, ref this.colorComboBox2);
            indexes.Button_ComboBoxIndex_fill(button.Control_state_0_size, ref this.skinComboBox5);
            indexes.Button_ComboBoxIndex_fill(button.Control_state_0_aligning, ref this.skinComboBox6);
            indexes.Button_ComboBoxIndex_fill(button.Control_state_0_flicker.ToString(), ref this.skinComboBox7);
            this.skinChatRichTextBox1.Text = button.Control_state_0_content.Trim();
            ((ImageButton_reform)this.all_purpose).Text = button.Control_state_0_content.Trim();
            //按钮标签1-参数索引-保存到Modification_label_parameter类中
            Modification_label_parameter.label_Lists[button.Control_state_1].Status = button.Control_state_1;
            Modification_label_parameter.label_Lists[button.Control_state_1].typeface = indexes.Button_ComboBox_Index(button.Control_state_1_typeface, this.skinComboBox3);
            Modification_label_parameter.label_Lists[button.Control_state_1].colour = indexes.Button_ComboBox_Index(button.Control_state_1_colour, this.colorComboBox2);
            Modification_label_parameter.label_Lists[button.Control_state_1].size = indexes.Button_ComboBox_Index(button.Control_state_1_size, this.skinComboBox5);
            Modification_label_parameter.label_Lists[button.Control_state_1].align_at = indexes.Button_ComboBox_Index(button.Control_state_1_aligning, this.skinComboBox6);
            Modification_label_parameter.label_Lists[button.Control_state_1].flicker = indexes.Button_ComboBox_Index(button.Control_state_1_flicker.ToString(), this.skinComboBox7);
            Modification_label_parameter.label_Lists[button.Control_state_1].content = button.Control_state_1_content1.Trim();
            //获取控件位置-大小-等信息
            this.skinTextBox1.Text = point_or_Size(button.location)[0].ToString();//控件位置X轴
            this.skinTextBox2.Text = point_or_Size(button.location)[1].ToString();//控件位置Y轴
            this.skinTextBox4.Text = point_or_Size(button.size)[0].ToString();//控件大小宽度
            this.skinTextBox3.Text = point_or_Size(button.size)[1].ToString();//控件大小宽度
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            //检查输入数据是否正确
            Regex reg = new Regex(@"^[A-Fa-z0-9]+(.[0-9]+)?$");
            if (reg.IsMatch(this.skinTextBox6.Text.Trim()) != true || reg.IsMatch(this.skinTextBox7.Text.Trim()) != true)
            {
                MessageBox.Show("PLC地址输入错误，输入了一个不可能访问到的地址");
                return;
            }
            //先判断用户输入的数据
            if (skinChatRichTextBox1.Text.IsNull() || skinTextBox7.Text.IsNull() || skinTextBox8.Text.IsNull()) { MessageBox.Show("重要参数不能为NULL,请检查参数", "Err"); return; }
            //判断PLC具体地址是否为Null或者不正确

            //先查询数据库有无此ID--有进行修改--无新增--
            ImageButton_EF button_EF = new ImageButton_EF();//实例化EF对象
            if (ImageButton_EF.Button_Parameter_inquire(this.skinTextBox8.Text) == "OK")
                button_EF.Button_Parameter_modification(this.skinTextBox8.Text, button_Parameter(), tag_Common_Parameters(), general_Parameters_Of_Picture(), control_Location());//修改数据库参数
            else
            {
                button_EF.Button_Parameter_Add(tag_Common_Parameters());//插入标签参数
                button_EF.Button_Parameter_Add(button_Parameter());//插入一般参数
                button_EF.Button_Parameter_Add(general_Parameters_Of_Picture());//插入图片参数
                button_EF.Button_Parameter_Add(control_Location());//插入控件坐标参数
            }
            ((ImageButton_reform)this.all_purpose).Text = this.skinChatRichTextBox1.Text.Trim();//设置文本
            Public_attributeCalss public_AttributeCalss = new Public_attributeCalss();//实例化按钮参数设置
            public_AttributeCalss.attributeCalss((ImageButton_reform)this.all_purpose, button_EF.Button_Parameter_Query(skinTextBox8.Text.Trim()));//查询数据库--进行设置后的参数修改
            Add_to_allow = true;//允许添加控件
            this.Close();
            this.Dispose();
        }
        private ImageButton_parameter button_Parameter()//获取要写入的一般参数
        {
            return new ImageButton_parameter
            {
                ID = this.skinTextBox8.Text,
                FORM = From_Name,
                位切换开关 = Convert.ToInt32(skinRadioButton1.Checked).ToString(),
                位指示灯 = Convert.ToInt32(skinRadioButton4.Checked).ToString(),
                读写设备 = this.skinComboBox13.Text,
                读写设备_地址 = this.skinComboBox12.Text,
                读写设备_地址_具体地址 = this.skinTextBox7.Text.Trim() ?? "0",
                读写不同地址_ON_OFF = skinCheckBox1.Checked.ToInt32(),
                写设备_复选 = this.skinComboBox11.Text,
                写设备_地址_复选 = this.skinComboBox10.Text,
                写设备_地址_具体地址_复选 = this.skinTextBox6.Text.Trim() ?? "0",
                操作模式 = skinComboBox9.Text,
                操作安全时间 = this.skinComboBox1.Text
            };
        }
        private Tag_common_parameters tag_Common_Parameters()//获取要写入的标签参数
        {
            Tag_common_parameters tag_Common = new Tag_common_parameters();//定义要返回的对象
            int Index = 0;//定义索引的指针
            if (Convert.ToInt32(this.skinComboBox2.Text) == 1)//判断当前用户选中的格式状态
            {
                Index = 0;
                tag_Common = new Tag_common_parameters
                {
                    //写入0状态
                    Control_state_0 = 0,
                    Control_state_0_typeface = this.skinComboBox3.Items[Modification_label_parameter.label_Lists[Index].typeface].ToString(),
                    Control_state_0_colour = this.colorComboBox2.Items[Modification_label_parameter.label_Lists[Index].colour].ToString(),
                    Control_state_0_size = this.skinComboBox5.Items[Modification_label_parameter.label_Lists[Index].size].ToString(),
                    Control_state_0_aligning = this.skinComboBox6.Items[Modification_label_parameter.label_Lists[Index].align_at].ToString(),
                    Control_state_0_flicker = this.skinComboBox7.Items[Modification_label_parameter.label_Lists[Index].flicker].ToInt32(),
                    Control_state_0_content = Modification_label_parameter.label_Lists[Index].content,
                    //写入1状态
                    Control_state_1 = 1,
                    Control_state_1_typeface = this.skinComboBox3.Text,
                    Control_state_1_colour = this.colorComboBox2.Text,
                    Control_state_1_size = this.skinComboBox5.Text,
                    Control_state_1_aligning = this.skinComboBox6.Text,
                    Control_state_1_flicker = this.skinComboBox7.Text.ToInt32(),
                    Control_state_1_content1 = this.skinChatRichTextBox1.Text,
                    Control_type = ((ImageButton_reform)this.all_purpose).Name,
                    FROM = From_Name,
                    ID = skinTextBox8.Text
                };
            }
            if (Convert.ToInt32(this.skinComboBox2.Text) == 0)//判断当前用户选中的格式状态

            {
                Index = 1;
                tag_Common = new Tag_common_parameters
                {
                    //写入1状态
                    Control_state_1 = 1,
                    Control_state_1_typeface = this.skinComboBox3.Items[Modification_label_parameter.label_Lists[Index].typeface].ToString(),
                    Control_state_1_colour = this.colorComboBox2.Items[Modification_label_parameter.label_Lists[Index].colour].ToString(),
                    Control_state_1_size = this.skinComboBox5.Items[Modification_label_parameter.label_Lists[Index].size].ToString(),
                    Control_state_1_aligning = this.skinComboBox6.Items[Modification_label_parameter.label_Lists[Index].align_at].ToString(),
                    Control_state_1_flicker = this.skinComboBox7.Items[Modification_label_parameter.label_Lists[Index].flicker].ToInt32(),
                    Control_state_1_content1 = Modification_label_parameter.label_Lists[Index].content,
                    //写入0状态
                    Control_state_0 = 0,
                    Control_state_0_typeface = this.skinComboBox3.Text,
                    Control_state_0_colour = this.colorComboBox2.Text,
                    Control_state_0_size = this.skinComboBox5.Text,
                    Control_state_0_aligning = this.skinComboBox6.Text,
                    Control_state_0_flicker = this.skinComboBox7.Text.ToInt32(),
                    Control_state_0_content = this.skinChatRichTextBox1.Text,
                    Control_type = ((ImageButton_reform)this.all_purpose).Name,
                    FROM = From_Name,
                    ID = skinTextBox8.Text
                };
            }
            return tag_Common;//返回对象
        }
        private General_parameters_of_picture general_Parameters_Of_Picture()//获取要写入的图片参数---目前未实现
        {
            return new General_parameters_of_picture
            {
                Control_state_0 = 0,
                Control_state_0_list = 0,
                Control_state_0_picture = 0,
                Control_state_1 = 1,
                Control_state_1_list = 0,
                Control_state_1_picture = 0,
                Control_type = ((ImageButton_reform)this.all_purpose).Name,
                FORM = From_Name,
                ID = skinTextBox8.Text
            };
        }
        private control_location control_Location()//获取要写入的控件位置
        {
            return new control_location
            {
                ID = skinTextBox8.Text,
                FORM = From_Name,
                location = this.skinTextBox1.Text.Trim() + "-" + this.skinTextBox2.Text.Trim(),
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
                if ((e.KeyChar < '0') || (e.KeyChar > '9') || ((TextBox)sender).Text.Length > 3)//这是允许输入0-9数字 最大数据不能大于3位数
                {
                    e.Handled = true;//只能输入数字
                }
            }
        }
        private void skinRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((SkinRadioButton)sender).Name == skinRadioButton1.Name)
            {
                skinRadioButton1.Checked = true;
                skinRadioButton4.Checked = false;
            }
            else
            {
                skinRadioButton4.Checked = true;
                skinRadioButton1.Checked = false;
            }
        }
    }
}
