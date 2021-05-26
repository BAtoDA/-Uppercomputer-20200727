using CCWin.SkinControl;
using PLC通讯规范接口;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.字体;
using 自定义Uppercomputer_20200727.控件重做;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    /// <本类用于处理控件的标签参数显示选项加载>    
    class Modification_label_parameter
    {
        public static List<label_list> label_Lists = new List<label_list>();////暂时保存参数-0-1状态
        private string[] align = new string[] { "左对齐", "居中对齐", "右对齐" };
        public Modification_label_parameter(SkinComboBox Status,SkinComboBox typeface
            ,ColorComboBox colour,SkinComboBox size,SkinComboBox align_at ,SkinComboBox flicker
            , SkinChatRichTextBox content, Button_state state,bool Load_state,string Name,int Button_state, ColorComboBox colour_1)//按钮类
        {
            if(Load_state)//判断是否初始化加载
            {
                ComboBox_Status(ref Status);//按钮状态
                ComboBox_Status(ref flicker);//是否闪烁
                ComboBox_typeface(ref typeface);//控件字体
                ComboBox_size(ref size);//控件尺寸字体
                ComboBox_align_at(ref align_at);//控件字体对齐方式
                colour.SelectedIndex = 8;//颜色默认黑色
                colour.SelectedItem = 8;//颜色默认黑色
                colour_1.SelectedIndex = 25;//默认灰色
                colour_1.SelectedItem = 25; //默认灰色
                content.Text = Name;//默认显示文本
                label_Lists.Clear();//清除表
                label_Lists.Add(new label_list(0, typeface.SelectedIndex, colour.SelectedIndex, size.SelectedIndex, align_at.SelectedIndex, flicker.SelectedIndex, Name, colour_1.SelectedIndex));//添加0状态
                label_Lists.Add(new label_list(1, typeface.SelectedIndex, colour.SelectedIndex, size.SelectedIndex, align_at.SelectedIndex, flicker.SelectedIndex, Name, colour_1.SelectedIndex));//添加1状态
            }
            else
            {
                #region 修改控件状态
                label_Lists[Button_state].Status = Button_state;
                label_Lists[Button_state].typeface = typeface.SelectedIndex;
                label_Lists[Button_state].colour = colour.SelectedIndex;
                label_Lists[Button_state].size = size.SelectedIndex;
                label_Lists[Button_state].align_at = align_at.SelectedIndex;
                label_Lists[Button_state].flicker = flicker.SelectedIndex;
                label_Lists[Button_state].content = content.Text;
                label_Lists[Button_state].colour_1 = colour_1.SelectedIndex;

                #endregion
                #region 修改控件索引      
                int shuju= Button_state>0? 0:1;//状态取反       
                ComboBox_indexes(ref Status, shuju);
                ComboBox_indexes(ref flicker, label_Lists[shuju].flicker);
                ComboBox_indexes(ref typeface, label_Lists[shuju].typeface);
                ComboBox_indexes(ref size, label_Lists[shuju].size);
                ComboBox_indexes(ref align_at, label_Lists[shuju].align_at);
                ComboBox_indexes(ref size, label_Lists[shuju].size);
                colour.SelectedIndex = label_Lists[shuju].colour;//颜色
                colour.SelectedItem = label_Lists[shuju].colour;//颜色
                colour_1.SelectedIndex = label_Lists[shuju].colour_1;//颜色
                colour_1.SelectedItem = label_Lists[shuju].colour_1;//颜色
                content.Text = label_Lists[shuju].content;//默认显示文本
                #endregion
            }    
        }
        public Modification_label_parameter( SkinComboBox typeface
 , ColorComboBox colour, SkinComboBox size, SkinComboBox align_at, SkinComboBox flicker
 , SkinChatRichTextBox content, string Name)//文本--数值软件类
        {
            ComboBox_Status(ref flicker);//是否闪烁
            ComboBox_typeface(ref typeface);//控件字体
            ComboBox_size(ref size);//控件尺寸字体
            ComboBox_align_at(ref align_at);//控件字体对齐方式
            colour.SelectedIndex = 8;//颜色默认黑色
            colour.SelectedItem = 8;//颜色默认黑色
            content.Text = Name;//默认显示文本
        }
        private void ComboBox_Status(ref SkinComboBox skinCombo)//按钮状态-可以复用是否闪烁
        {
            skinCombo.Items.Clear();//清除选项
            foreach (Button_state suit in Enum.GetValues(typeof(Button_state)))
            {
                skinCombo.Items.Add((int)suit);//添加选项
            }
            skinCombo.SelectedIndex = 0;
            skinCombo.SelectedItem = 0;
        }
        private void ComboBox_typeface(ref SkinComboBox skinCombo)//控件字体
        {
            skinCombo.Items.Clear();//清除选项
            foreach (var i in typeface.typeface_win)
            {
                skinCombo.Items.Add(i);//添加选项
            }
            skinCombo.SelectedIndex = 1;//默认字体宋体
            skinCombo.SelectedItem = 1;//默认字体宋体
        }
        private void ComboBox_size(ref SkinComboBox skinCombo)//控件尺寸字体
        {
            skinCombo.Items.Clear();//清除选项
            for(int i=10;i<255; i++)
            {
                skinCombo.Items.Add(i);//添加选项
            }
            skinCombo.SelectedIndex = 0;//默认10号字体
            skinCombo.SelectedItem = 0;//默认10号字体
        }
        private void ComboBox_align_at(ref SkinComboBox skinCombo)//控件字体对齐方式
        {
            skinCombo.Items.Clear();//清除选项
            foreach (var i in align)
            {
                skinCombo.Items.Add(i);//添加选项
            }
            skinCombo.SelectedIndex = 1;//默认居中对齐
            skinCombo.SelectedItem = 1;//默认居中对齐
        }
        private void ComboBox_indexes(ref SkinComboBox skinCombo,int Index)//改变控件索引
        {
            skinCombo.SelectedIndex = Index;//改变索引
            skinCombo.SelectedItem = Index;//改变索引
        }
        private void ComboBox_indexes(ref ColorComboBox skinCombo, int Index)//改变控件索引
        {
            skinCombo.SelectedIndex = Index;//改变索引
            skinCombo.SelectedItem = Index;//改变索引
        }
    }
    /// <本类用于处理控件的标签参数暂时保存-0-1-参数>    
    class label_list
    {
        public int Status, typeface, colour, size, align_at, flicker, colour_1;//暂时保存参数
        public string content;
        public label_list(int Status, int typeface,int colour, int size,int align_at,int flicker , string content,int colour_1)
        {
            this.Status = Status; this.typeface = typeface;this.colour = colour;this.size = size;
            this.align_at = align_at;this.flicker = flicker;this.content = content;this.colour_1= colour_1;

        }
    }
}
