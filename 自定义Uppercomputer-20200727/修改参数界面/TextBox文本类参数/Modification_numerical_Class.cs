using CCWin.SkinClass;
using CCWin.SkinControl;
using PLC通讯规范接口;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.控件重做;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    class Modification_numerical_Class
    {
        /// <本类用于处理控件的数值软-元件处理>   
        private List<SkinTabPage> skinTabs;//修改参数界面控件
        private List<Control> controls = new List<Control>();//所有查询一般参数控件的对象保存地
        private List<Control> controls_format = new List<Control>();//所有查询格式控件的对象保存地
        private string Button_Name;//控件名称
        Modification_label_parameter modification_Label;//标签选项类
        SkinComboBox skinCombo_PLC, skinCombo_PLC_Bit, skinCombo_PLC_check, skinCombo_PLC_Bit_check;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="skinTabs"></param>
        /// <param name="Button_Name"></param>
        public  Modification_numerical_Class(List<SkinTabPage> skinTabs, string Button_Name)//初始加载构造函数
        {
            this.skinTabs = skinTabs;//获取控件对象
            this.Button_Name = Button_Name;
            Load(0, true);
        }
        /// <summary>
        /// 构造函数--新增运输带类
        /// </summary>
        /// <param name="skinTabs"></param>
        /// <param name="Button_Name"></param>
        public Modification_numerical_Class(List<SkinTabPage> skinTabs, string Button_Name,bool Value)//初始加载构造函数
        {
            this.skinTabs = skinTabs;//获取控件对象
            this.Button_Name = Button_Name;
            Load(0);
        }
        private void Load(PLC pLC, bool Load_1)//加载控件信息
        {
            SkinGroupBox GroupBox_PLC = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "读取/写入地址" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox skinCombo_PLC = (SkinComboBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinComboBox13" select pi).FirstOrDefault();//查询PLC选项菜单
            SkinComboBox skinCombo_PLC_Bit = (SkinComboBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinComboBox12" select pi).FirstOrDefault();//查询PLC选项菜单
            SkinCheckBox skinCheckBox = (SkinCheckBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinCheckBox1" select pi).FirstOrDefault();//查询是否启用读写不同地址功能
                                                                                                                                                             //预留功能
            SkinGroupBox GroupBox_PLC_check = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "写入地址_复选" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox skinCombo_PLC_check = (SkinComboBox)(from Control pi in GroupBox_PLC_check.Controls where pi.Name == "skinComboBox11" select pi).FirstOrDefault();//查询PLC选项菜单
            SkinComboBox skinCombo_PLC_Bit_check = (SkinComboBox)(from Control pi in GroupBox_PLC_check.Controls where pi.Name == "skinComboBox10" select pi).FirstOrDefault();//查询PLC选项菜单
                                                                                                                                                                               //预留功能读写不同地址
            skinCheckBox.MouseClick += skinCheckBox_MouseClick;//注册事件
            //用户点击了更换PLC下拉菜单变换
            this.skinCombo_PLC = skinCombo_PLC;
            this.skinCombo_PLC_Bit = skinCombo_PLC_Bit;
            this.skinCombo_PLC_check = skinCombo_PLC_check;
            this.skinCombo_PLC_Bit_check = skinCombo_PLC_Bit_check;
            skinCombo_PLC.SelectedIndexChanged += SelectedIndexChanged;
            skinCombo_PLC_check.SelectedIndexChanged += SelectedIndexChanged;
            //重写一般参数的使用--加载
            Modification_General_parameters _General_Parameters = new Modification_General_parameters(skinCombo_PLC, skinCombo_PLC_Bit
                      , skinCombo_PLC_check, skinCombo_PLC_Bit_check, pLC);
            //安全控制功能
            SkinGroupBox GroupBox_safety = (SkinGroupBox)(from Control pi in skinTabs[1].Controls where pi.Text == "安全控制" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox skinCombo_safety = (SkinComboBox)(from Control pi in GroupBox_safety.Controls where pi.Name == "skinComboBox1" select pi).FirstOrDefault();//查询模式选项菜单
            SkinComboBox_safety(ref skinCombo_safety);//添加安全控制时间
                                                      //字体属性查询
            SkinGroupBox Font_properties = (SkinGroupBox)(from Control pi in skinTabs[3].Controls where pi.Text == "字体属性" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox Font_properties_Font = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox3" select pi).FirstOrDefault();//查询字体
            ColorComboBox Font_properties_Colour = (ColorComboBox)(from Control pi in Font_properties.Controls where pi.Name == "colorComboBox1" select pi).FirstOrDefault();//查询颜色
            SkinComboBox Font_properties_Size = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox5" select pi).FirstOrDefault();//查询尺寸
            SkinComboBox Font_properties_align_at = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox6" select pi).FirstOrDefault();//查询对齐方式
            SkinComboBox Font_properties_flicker = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox7" select pi).FirstOrDefault();//查询闪烁
                                                                                                                                                                           //查询文本内容
            SkinGroupBox Font_characters = (SkinGroupBox)(from Control pi in skinTabs[3].Controls where pi.Text == "文字：" select pi).FirstOrDefault();//查询要写入对象
            SkinChatRichTextBox Font_characters_content = (SkinChatRichTextBox)(from Control pi in Font_characters.Controls where pi.Name == "skinChatRichTextBox1" select pi).FirstOrDefault();//查询字体
                                                                                                                                                                                                //加载格式显示
            modification_Label = new Modification_label_parameter(Font_properties_Font, Font_properties_Colour, Font_properties_Size, Font_properties_align_at, Font_properties_flicker,
               Font_characters_content, Button_Name);
            #region 保存查询格式的控件进行保存
            controls_format.Clear();//清空集合
            controls_format.Add(Font_properties_Font); controls_format.Add(Font_properties_Colour);
            controls_format.Add(Font_properties_Size); controls_format.Add(Font_properties_align_at); controls_format.Add(Font_properties_flicker);
            controls_format.Add(Font_characters_content);
            #endregion
            //读取数据寄存器格式加载
            SkinGroupBox GroupBox_format = (SkinGroupBox)(from Control pi in skinTabs[5].Controls where pi.Text == "显示格式" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox GroupBox_format_format = (SkinComboBox)(from Control pi in GroupBox_format.Controls where pi.Name == "skinComboBox8" select pi).FirstOrDefault();//查询资料格式
            ComboBox_format(ref GroupBox_format_format);//加载资料格式
            SkinGroupBox GroupBox_format_1 = (SkinGroupBox)(from Control pi in skinTabs[5].Controls where pi.Text == "数据格式" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox GroupBox_format_type = (SkinComboBox)(from Control pi in GroupBox_format_1.Controls where pi.Name == "skinComboBox14" select pi).FirstOrDefault();//查询数据类型
            ComboBox_type(ref GroupBox_format_type);//加载资料类型
            SkinTextBox GroupBox_digit_Max = (SkinTextBox)(from Control pi in GroupBox_format_1.Controls where pi.Name == "skinTextBox1" select pi).FirstOrDefault();//查询小数点以上位数
            SkinTextBox GroupBox_digit_Min = (SkinTextBox)(from Control pi in GroupBox_format_1.Controls where pi.Name == "skinTextBox2" select pi).FirstOrDefault();//查询小数点一下位数
            GroupBox_digit_Max.Text = 8.ToString();//默认小数点以上8位
            GroupBox_digit_Min.Text = 0.ToString();//默认小数点以下0位
        }
        private void Load(PLC pLC)//加载控件信息--新增运输带类
        {
            SkinGroupBox GroupBox_PLC = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "运输带方向控制" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox skinCombo_PLC = (SkinComboBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinComboBox13" select pi).FirstOrDefault();//查询PLC选项菜单
            SkinComboBox skinCombo_PLC_Bit = (SkinComboBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinComboBox12" select pi).FirstOrDefault();//查询PLC选项菜单
            //SkinCheckBox skinCheckBox = (SkinCheckBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinCheckBox1" select pi).FirstOrDefault();//查询是否启用读写不同地址功能
                                                                                                                                                             //预留功能
            SkinGroupBox GroupBox_PLC_check = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "运输带速度控制" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox skinCombo_PLC_check = (SkinComboBox)(from Control pi in GroupBox_PLC_check.Controls where pi.Name == "skinComboBox11" select pi).FirstOrDefault();//查询PLC选项菜单
            SkinComboBox skinCombo_PLC_Bit_check = (SkinComboBox)(from Control pi in GroupBox_PLC_check.Controls where pi.Name == "skinComboBox10" select pi).FirstOrDefault();//查询PLC选项菜单
            

            //预留功能读写不同地址
            //skinCheckBox.MouseClick += skinCheckBox_MouseClick;//注册事件
            //用户点击了更换PLC下拉菜单变换
            this.skinCombo_PLC = skinCombo_PLC;
            this.skinCombo_PLC_Bit = skinCombo_PLC_Bit;
            this.skinCombo_PLC_check = skinCombo_PLC_check;
            this.skinCombo_PLC_Bit_check = skinCombo_PLC_Bit_check;
            //新增功能
            Modification_General_parameters _General_Parameters = new Modification_General_parameters();
            _General_Parameters.Mitsubishi_PLCload(ref skinCombo_PLC);//加载PLC类型
            _General_Parameters.Mitsubishi_PLCload(ref skinCombo_PLC_check);//加载PLC类型
            _General_Parameters.SkinComboBox_Mitsubishi_BitLoad(ref skinCombo_PLC_Bit, pLC);//加载辅助触点
            _General_Parameters.SkinComboBox_Mitsubishi_numericalLoad(ref skinCombo_PLC_Bit_check, pLC);//加载寄存器选项

            skinCombo_PLC.SelectedIndexChanged += (send, e)=>
            {
                PLC lC = 0; ;//定义PLC枚举
                foreach (PLC suit in Enum.GetValues(typeof(PLC)))
                {
                    if ((int)suit == ((SkinComboBox)send).SelectedIndex) lC = suit;
                }
                Modification_General_parameters _General_Parameters1 = new Modification_General_parameters(this.skinCombo_PLC, this.skinCombo_PLC_Bit, lC);
            };
            skinCombo_PLC_check.SelectedIndexChanged += (send, e) =>
            {
                PLC lC = 0; ;//定义PLC枚举
                foreach (PLC suit in Enum.GetValues(typeof(PLC)))
                {
                    if ((int)suit == ((SkinComboBox)send).SelectedIndex) lC = suit;
                }
                Modification_General_parameters _General_Parameters1 = new Modification_General_parameters(this.skinCombo_PLC_check, this.skinCombo_PLC_Bit_check, lC,1);
            };
            //安全控制功能
            SkinGroupBox GroupBox_safety = (SkinGroupBox)(from Control pi in skinTabs[1].Controls where pi.Text == "安全控制" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox skinCombo_safety = (SkinComboBox)(from Control pi in GroupBox_safety.Controls where pi.Name == "skinComboBox1" select pi).FirstOrDefault();//查询模式选项菜单
            SkinComboBox_safety(ref skinCombo_safety);//添加安全控制时间
                                                      //字体属性查询
            SkinGroupBox Font_properties = (SkinGroupBox)(from Control pi in skinTabs[3].Controls where pi.Text == "字体属性" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox Font_properties_Font = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox3" select pi).FirstOrDefault();//查询字体
            ColorComboBox Font_properties_Colour = (ColorComboBox)(from Control pi in Font_properties.Controls where pi.Name == "colorComboBox1" select pi).FirstOrDefault();//查询颜色
            SkinComboBox Font_properties_Size = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox5" select pi).FirstOrDefault();//查询尺寸
            SkinComboBox Font_properties_align_at = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox6" select pi).FirstOrDefault();//查询对齐方式
            SkinComboBox Font_properties_flicker = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox7" select pi).FirstOrDefault();//查询闪烁
                                                                                                                                                                           //查询文本内容
            SkinGroupBox Font_characters = (SkinGroupBox)(from Control pi in skinTabs[3].Controls where pi.Text == "文字：" select pi).FirstOrDefault();//查询要写入对象
            SkinChatRichTextBox Font_characters_content = (SkinChatRichTextBox)(from Control pi in Font_characters.Controls where pi.Name == "skinChatRichTextBox1" select pi).FirstOrDefault();//查询字体
                                                                                                                                                                                                //加载格式显示
            modification_Label = new Modification_label_parameter(Font_properties_Font, Font_properties_Colour, Font_properties_Size, Font_properties_align_at, Font_properties_flicker,
               Font_characters_content, Button_Name);
            #region 保存查询格式的控件进行保存
            controls_format.Clear();//清空集合
            controls_format.Add(Font_properties_Font); controls_format.Add(Font_properties_Colour);
            controls_format.Add(Font_properties_Size); controls_format.Add(Font_properties_align_at); controls_format.Add(Font_properties_flicker);
            controls_format.Add(Font_characters_content);
            #endregion
            //读取数据寄存器格式加载
            SkinGroupBox GroupBox_format = (SkinGroupBox)(from Control pi in skinTabs[5].Controls where pi.Text == "显示格式" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox GroupBox_format_format = (SkinComboBox)(from Control pi in GroupBox_format.Controls where pi.Name == "skinComboBox8" select pi).FirstOrDefault();//查询资料格式
            ComboBox_format(ref GroupBox_format_format);//加载资料格式
            SkinGroupBox GroupBox_format_1 = (SkinGroupBox)(from Control pi in skinTabs[5].Controls where pi.Text == "数据格式" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox GroupBox_format_type = (SkinComboBox)(from Control pi in GroupBox_format_1.Controls where pi.Name == "skinComboBox14" select pi).FirstOrDefault();//查询数据类型
            ComboBox_type(ref GroupBox_format_type);//加载资料类型
            SkinTextBox GroupBox_digit_Max = (SkinTextBox)(from Control pi in GroupBox_format_1.Controls where pi.Name == "skinTextBox1" select pi).FirstOrDefault();//查询小数点以上位数
            SkinTextBox GroupBox_digit_Min = (SkinTextBox)(from Control pi in GroupBox_format_1.Controls where pi.Name == "skinTextBox2" select pi).FirstOrDefault();//查询小数点一下位数
            GroupBox_digit_Max.Text = 8.ToString();//默认小数点以上8位
            GroupBox_digit_Min.Text = 0.ToString();//默认小数点以下0位
        }
        private void ComboBox_format(ref SkinComboBox skinCombo)//加载资料格式
        {
            skinCombo.Items.Clear();//清除选项
            foreach (numerical_format suit in Enum.GetValues(typeof(numerical_format)))
            {
                skinCombo.Items.Add(suit);//添加选项
            }
            skinCombo.SelectedIndex = 9;//默认是Signed_32_Bit
            skinCombo.SelectedItem = 9;//默认是Signed_32_Bit
        }
        private void ComboBox_type(ref SkinComboBox skinCombo)//加载资料类型
        {
            skinCombo.Items.Clear();//清除选项
            foreach (numerical_type suit in Enum.GetValues(typeof(numerical_type)))
            {
                skinCombo.Items.Add(suit);//添加选项
            }
            skinCombo.SelectedIndex = 0;//默认是数值
            skinCombo.SelectedItem = 0;//默认是数值
        }
        public void SelectedIndexChanged(object sender, EventArgs e)//用户更换其他PLC类型
        {
            //重写一般参数的使用--加载
            PLC lC = 0; ;//定义PLC枚举
            foreach (PLC suit in Enum.GetValues(typeof(PLC)))
            {
                if ((int)suit == ((SkinComboBox)sender).SelectedIndex) lC = suit;
            }
            if (((SkinComboBox)sender).Name == this.skinCombo_PLC.Name)
            {
                Modification_General_parameters _General_Parameters = new Modification_General_parameters(this.skinCombo_PLC, this.skinCombo_PLC_Bit, lC, 1);
            }
            else
            {
                Modification_General_parameters _General_Parameters = new Modification_General_parameters(this.skinCombo_PLC_check, this.skinCombo_PLC_Bit_check, lC, 1);
            }

        }
        private void skinCheckBox_MouseClick(object sender, EventArgs e) //预留功能读写不同地址
        {
            SkinGroupBox GroupBox_PLC = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "写入地址_复选" select pi).FirstOrDefault();//查询要写入对象
            if (GroupBox_PLC.Visible)
            {
                GroupBox_PLC.Enabled = false;
                GroupBox_PLC.Visible = false;
            }
            else
            {
                GroupBox_PLC.Enabled = true;
                GroupBox_PLC.Visible = true;
            }
        }
        private void SkinComboBox_safety(ref SkinComboBox skinComboBox)//安全控制功能--添加时间
        {
            skinComboBox.Items.Clear();//清除选项
            for (int i = 10; i < 101; i++)
            {
                skinComboBox.Items.Add(i * 10);//添加选项
            }
            skinComboBox.SelectedIndex = 0;
            skinComboBox.SelectedItem = 0;
        }
    }
}
