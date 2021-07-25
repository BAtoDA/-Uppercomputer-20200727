using CCWin.SkinControl;
using PLC通讯规范接口;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.控件重做;
using static System.Windows.Forms.Control;
using static 自定义Uppercomputer_20200727.控件重做.Button_reform;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    /// <本类用于处理修改参数_BUTTON按钮类处理>    
    class Modification_Button_Class
    {
        private List<SkinTabPage> skinTabs;//修改参数界面控件
        private List<Control> controls=new List<Control>();//所有查询一般参数控件的对象保存地
        private List<Control> controls_format = new List<Control>();//所有查询格式控件的对象保存地
        private string Button_Name, ID;//控件名称--ID
        Modification_label_parameter modification_Label;//标签选项类
        SkinComboBox skinCombo_PLC, skinCombo_PLC_check, skinCombo_PLC_Bit_check;
        public Modification_Button_Class(List<SkinTabPage> skinTabs,string Button_Name,string ID)//初始加载构造函数
        {
            this.skinTabs = skinTabs;//获取控件对象
            this.Button_Name = Button_Name;
            Load(0,true);//目前先默认选择三菱--5U
            this.ID = ID;
        }
        private  void Load(PLC pLC,bool Load_1)//加载控件信息
        {
                SkinGroupBox GroupBox_PLC = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "读取/写入地址" select pi).FirstOrDefault();//查询要写入对象
                SkinComboBox skinCombo_PLC = (SkinComboBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinComboBox13" select pi).FirstOrDefault();//查询PLC选项菜单
                SkinComboBox skinCombo_PLC_Bit = (SkinComboBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinComboBox12" select pi).FirstOrDefault();//查询PLC选项菜单
                SkinCheckBox skinCheckBox = (SkinCheckBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinCheckBox1" select pi).FirstOrDefault();//查询是否启用读写不同地址功能
                //skinRadioButton4
                SkinGroupBox GroupBox_describe = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "按钮描述" select pi).FirstOrDefault();//查询要写入对象
                SkinRadioButton RadioButton_describe = (SkinRadioButton)(from Control pi in GroupBox_describe.Controls where pi.Name == "skinRadioButton1" select pi).FirstOrDefault();//查询PLC选项菜单
                  SkinRadioButton RadioButton_describe_1 = (SkinRadioButton)(from Control pi in GroupBox_describe.Controls where pi.Name == "skinRadioButton2" select pi).FirstOrDefault();//查询PLC选项菜单

                  //预留功能
                  SkinGroupBox GroupBox_PLC_check = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "写入地址_复选" select pi).FirstOrDefault();//查询要写入对象
                SkinComboBox skinCombo_PLC_check = (SkinComboBox)(from Control pi in GroupBox_PLC_check.Controls where pi.Name == "skinComboBox11" select pi).FirstOrDefault();//查询PLC选项菜单
                SkinComboBox skinCombo_PLC_Bit_check = (SkinComboBox)(from Control pi in GroupBox_PLC_check.Controls where pi.Name == "skinComboBox10" select pi).FirstOrDefault();//查询PLC选项菜单
                //预留功能读写不同地址
                skinCheckBox.MouseClick += skinCheckBox_MouseClick;//注册事件
                //if(GroupBox_PLC.Visible) skinCheckBox_MouseClick(1, new EventArgs());//先隐藏
                //属性功能
                SkinGroupBox GroupBox_PLC_property = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "属性" select pi).FirstOrDefault();//查询要写入对象
                SkinComboBox skinCombo_button_pattern = (SkinComboBox)(from Control pi in GroupBox_PLC_property.Controls where pi.Name == "skinComboBox9" select pi).FirstOrDefault();//查询模式选项菜单
                //重写一般参数的使用--加载
                Modification_General_parameters _General_Parameters = new Modification_General_parameters(skinCombo_PLC, skinCombo_PLC_Bit
                    , RadioButton_describe, skinCombo_PLC_check, skinCombo_PLC_Bit_check, skinCombo_button_pattern, pLC);
                //安全控制功能
                SkinGroupBox GroupBox_safety = (SkinGroupBox)(from Control pi in skinTabs[1].Controls where pi.Text == "安全控制" select pi).FirstOrDefault();//查询要写入对象
                SkinComboBox skinCombo_safety = (SkinComboBox)(from Control pi in GroupBox_safety.Controls where pi.Name == "skinComboBox1" select pi).FirstOrDefault();//查询模式选项菜单
                SkinComboBox_safety(ref skinCombo_safety);//添加安全控制时间
                //用户点击了更换PLC下拉菜单变换
                this.skinCombo_PLC= skinCombo_PLC;
                this.skinCombo_PLC_check= skinCombo_PLC_check;
                this.skinCombo_PLC_Bit_check = skinCombo_PLC_Bit_check;
                skinCombo_PLC.SelectedIndexChanged += SelectedIndexChanged;
                  skinCombo_PLC_check.SelectedIndexChanged += SelectedIndexChanged;
                //保存查询到的控件
                #region 保存查询一般参数的控件进行保存
                controls.Add(skinCombo_PLC); controls.Add(skinCombo_PLC_Bit); controls.Add(RadioButton_describe); controls.Add(skinCombo_PLC_check);
                  controls.Add(skinCombo_PLC_Bit_check); controls.Add(skinCombo_button_pattern); controls.Add(RadioButton_describe_1);
                  #endregion
                  //加载标签选项
                  //控件标签状态
                  SkinGroupBox GroupBox_label = (SkinGroupBox)(from Control pi in skinTabs[3].Controls where pi.Text == "按钮状态" select pi).FirstOrDefault();//查询要写入对象
                SkinComboBox GroupBox_label_Text = (SkinComboBox)(from Control pi in GroupBox_label.Controls where pi.Name == "skinComboBox2" select pi).FirstOrDefault();//查询
                //查询按钮状态-0-1-控件进行事件注册
                SkinButton GroupBox_label_button_0 = (SkinButton)(from Control pi in GroupBox_label.Controls where pi.Name == "skinButton6" select pi).FirstOrDefault();//查询控件0状态
                SkinButton GroupBox_label_button_1 = (SkinButton)(from Control pi in GroupBox_label.Controls where pi.Name == "skinButton7" select pi).FirstOrDefault();//查询控件1状态
                //字体属性查询
                SkinGroupBox Font_properties = (SkinGroupBox)(from Control pi in skinTabs[3].Controls where pi.Text == "字体属性" select pi).FirstOrDefault();//查询要写入对象
                SkinComboBox Font_properties_Font = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox3" select pi).FirstOrDefault();//查询字体
                ColorComboBox Font_properties_Colour = (ColorComboBox)(from Control pi in Font_properties.Controls where pi.Name == "colorComboBox2" select pi).FirstOrDefault();//查询颜色
                SkinComboBox Font_properties_Size = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox5" select pi).FirstOrDefault();//查询尺寸
                SkinComboBox Font_properties_align_at = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox6" select pi).FirstOrDefault();//查询对齐方式
                SkinComboBox Font_properties_flicker = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox7" select pi).FirstOrDefault();//查询闪烁
                //按钮样式
                SkinGroupBox Font_properties_1 = (SkinGroupBox)(from Control pi in skinTabs[3].Controls where pi.Text == "按钮样式" select pi).FirstOrDefault();//查询要写入对象
                ColorComboBox Font_properties_Colour_1 = (ColorComboBox)(from Control pi in Font_properties_1.Controls where pi.Name == "colorComboBox1" select pi).FirstOrDefault();//查询颜色
                //查询文本内容
                SkinGroupBox Font_characters = (SkinGroupBox)(from Control pi in skinTabs[3].Controls where pi.Text == "文字：" select pi).FirstOrDefault();//查询要写入对象
                SkinChatRichTextBox Font_characters_content = (SkinChatRichTextBox)(from Control pi in Font_characters.Controls where pi.Name == "skinChatRichTextBox1" select pi).FirstOrDefault();//查询字体
                //加载格式显示
                modification_Label = new Modification_label_parameter(GroupBox_label_Text, Font_properties_Font, Font_properties_Colour, Font_properties_Size, Font_properties_align_at, Font_properties_flicker,
                   Font_characters_content, Button_state.Off, true, Button_Name, 0, Font_properties_Colour_1);
                #region 保存查询格式的控件进行保存
                controls_format.Clear();//清空集合
                controls_format.Add(GroupBox_label_Text); controls_format.Add(Font_properties_Font); controls_format.Add(Font_properties_Colour);
                  controls_format.Add(Font_properties_Size); controls_format.Add(Font_properties_align_at); controls_format.Add(Font_properties_flicker);
                  controls_format.Add(Font_characters_content); controls_format.Add(GroupBox_label_button_0); controls_format.Add(GroupBox_label_button_1);
                 controls_format.Add(Font_properties_Colour_1);
            #endregion
            if (Load_1) Load_incident();//判断是否初始加载
        }
        private void Load_incident()//初始加载事件注册
        {
            //等待加载格式选项完毕--进行事件注册
            controls_format[7].Click += Button_Click;//注册事件
            controls_format[8].Click += Button_Click;//注册事件
        }
        public void SelectedIndexChanged(object sender, EventArgs e)//用户更换其他PLC类型
        {
            //重写一般参数的使用--加载
            PLC lC = 0; ;//定义PLC枚举
            foreach (PLC suit in Enum.GetValues(typeof(PLC)))
            {
               if((int)suit== ((SkinComboBox)sender).SelectedIndex) lC = suit;
            }
            if(((SkinComboBox)sender).Name== skinCombo_PLC.Name)
            { 
                Modification_General_parameters _General_Parameters = new Modification_General_parameters(skinCombo_PLC,(SkinComboBox)controls[1], lC);
            }
            else
            {
                Modification_General_parameters _General_Parameters = new Modification_General_parameters(skinCombo_PLC_check, this.skinCombo_PLC_Bit_check, lC);
            }
        }
        private void SkinComboBox_safety(ref SkinComboBox skinComboBox)//安全控制功能--添加时间
        {
            skinComboBox.Items.Clear();//清除选项
            for(int i=10;i<1001;i++)
            {
                skinComboBox.Items.Add(i*1);//添加选项
            }
            skinComboBox.SelectedIndex = 0;
            skinComboBox.SelectedItem = 0;
        }
        private void skinCheckBox_MouseClick(object sender, EventArgs e) //预留功能读写不同地址
        {
           SkinGroupBox GroupBox_PLC = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "写入地址_复选" select pi).FirstOrDefault();//查询要写入对象
           if(GroupBox_PLC.Visible)
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
        bool start_stop = false;//定义格式按钮初始状态
        private void Button_Click(object sender, EventArgs e)//格式选项按钮0-1状态切换
        {
            if (start_stop & ((SkinButton)sender).Name == "skinButton7")//判断是否初始使用
            {
                //加载格式显示
                modification_Label = new Modification_label_parameter((SkinComboBox)controls_format[0], (SkinComboBox)controls_format[1], (ColorComboBox)controls_format[2]
                    , (SkinComboBox)controls_format[3], (SkinComboBox)controls_format[4], (SkinComboBox)controls_format[5],
                   (SkinChatRichTextBox)controls_format[6], Button_state.Off, false, Button_Name, 0, (ColorComboBox)controls_format[9]);
            }
            if (start_stop==false & ((SkinButton)sender).Name == "skinButton7")//判断是否初始使用
            {
                //加载格式显示
                modification_Label = new Modification_label_parameter((SkinComboBox)controls_format[0], (SkinComboBox)controls_format[1], (ColorComboBox)controls_format[2]
                    , (SkinComboBox)controls_format[3], (SkinComboBox)controls_format[4], (SkinComboBox)controls_format[5],
                   (SkinChatRichTextBox)controls_format[6], Button_state.Off, false, Button_Name, 0, (ColorComboBox)controls_format[9]);
                start_stop = true;//已初始
            }
            if (start_stop & ((SkinButton)sender).Name == "skinButton6")//判断是否初始使用
            {
                //加载格式显示
                modification_Label = new Modification_label_parameter((SkinComboBox)controls_format[0], (SkinComboBox)controls_format[1], (ColorComboBox)controls_format[2]
                    , (SkinComboBox)controls_format[3], (SkinComboBox)controls_format[4], (SkinComboBox)controls_format[5],
                   (SkinChatRichTextBox)controls_format[6], Button_state.Off, false, Button_Name, 1, (ColorComboBox)controls_format[9]);            
            }
        }
    }
}
