using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.控件重做;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    class Modification_label_Class
    {
        /// <本类用于处理修改label参数类处理>  
        private List<SkinTabPage> skinTabs;//修改参数界面控件
        private List<Control> controls_format = new List<Control>();//所有查询格式控件的对象保存地
        private string label_Name;//控件名称
        Modification_label_parameter modification_Label;//标签选项类
        public Modification_label_Class(List<SkinTabPage> skinTabs, string label_Name)//初始加载构造函数
        {
            this.skinTabs = skinTabs;
            this.label_Name = label_Name;
            Load();//加载
        }
        private void Load()
        {
                  //安全控制功能
                  SkinGroupBox GroupBox_safety = (SkinGroupBox)(from Control pi in skinTabs[1].Controls where pi.Text == "安全控制" select pi).FirstOrDefault();//查询要写入对象
                  SkinComboBox skinCombo_safety = (SkinComboBox)(from Control pi in GroupBox_safety.Controls where pi.Name == "skinComboBox1" select pi).FirstOrDefault();//查询模式选项菜单
                  SkinComboBox_safety(ref skinCombo_safety);//添加安全控制时间
                  //字体属性查询
                  SkinGroupBox Font_properties = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "文字属性" select pi).FirstOrDefault();//查询要写入对象
                  SkinComboBox Font_properties_Font = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox2" select pi).FirstOrDefault();//查询字体
                  ColorComboBox Font_properties_Colour = (ColorComboBox)(from Control pi in Font_properties.Controls where pi.Name == "colorComboBox1" select pi).FirstOrDefault();//查询颜色
                  SkinComboBox Font_properties_Size = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox3" select pi).FirstOrDefault();//查询尺寸
                  SkinComboBox Font_properties_align_at = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox4" select pi).FirstOrDefault();//查询对齐方式
                  SkinComboBox Font_properties_flicker = (SkinComboBox)(from Control pi in Font_properties.Controls where pi.Name == "skinComboBox5" select pi).FirstOrDefault();//查询闪烁
                  //查询文本内容
                  SkinGroupBox Font_characters = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "内容文本" select pi).FirstOrDefault();//查询要写入对象
                  SkinChatRichTextBox Font_characters_content = (SkinChatRichTextBox)(from Control pi in Font_characters.Controls where pi.Name == "skinChatRichTextBox1" select pi).FirstOrDefault();//查询字体
                                                                                                                                                                                                      //加载格式显示
                  modification_Label = new Modification_label_parameter(Font_properties_Font, Font_properties_Colour, Font_properties_Size, Font_properties_align_at, Font_properties_flicker,
                     Font_characters_content, label_Name);
                  #region 保存查询格式的控件进行保存
                  controls_format.Clear();//清空集合
                  controls_format.Add(Font_properties_Font); controls_format.Add(Font_properties_Colour);
                  controls_format.Add(Font_properties_Size); controls_format.Add(Font_properties_align_at); controls_format.Add(Font_properties_flicker);
                  controls_format.Add(Font_characters_content);
                  #endregion
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
