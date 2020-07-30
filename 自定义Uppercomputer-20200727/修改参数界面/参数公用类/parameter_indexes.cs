using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 自定义Uppercomputer_20200727.控件重做;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    /// <本类用于处理参数索引问题>    
    class parameter_indexes
    {
        public void Button_ComboBoxIndex_fill(string Index_ID, ref SkinComboBox skinComboBox)//按照索引填充选项菜单
        {
            for (int i = 0; i < skinComboBox.Items.Count; i++)//遍历选项菜单
            {
                if (skinComboBox.Items[i].ToString() == Index_ID.Trim())
                {
                    //改变控件索引并且跳出循环
                    skinComboBox.SelectedIndex = i;
                    skinComboBox.SelectedItem = i;
                    break;
                }
            }
        }
        public void Button_ComboBoxIndex_fill(string Index_ID, ref ColorComboBox skinComboBox)//按照索引填充选项菜单
        {
            for (int i = 0; i < skinComboBox.Items.Count; i++)//遍历选项菜单
            {
                if (skinComboBox.Items[i].ToString() == Index_ID.Trim())
                {
                    //改变控件索引并且跳出循环
                    skinComboBox.SelectedIndex = i;
                    skinComboBox.SelectedItem = i;
                    break;
                }
            }
        }
        public int Button_ComboBox_Index(string Index_ID, ColorComboBox skinComboBox)//按照索引填充选项菜单
        {
            int Index = 0;
            for (int i = 0; i < skinComboBox.Items.Count; i++)//遍历选项菜单
            {
                if (skinComboBox.Items[i].ToString() == Index_ID.Trim())
                {
                    Index = i;
                }
            }
            return Index;//返回索引
        }
        public int Button_ComboBox_Index(string Index_ID, SkinComboBox skinComboBox)//查询索引
        {
            int Index = 0;
            for (int i = 0; i < skinComboBox.Items.Count; i++)//遍历选项菜单
            {
                if (skinComboBox.Items[i].ToString() == Index_ID.Trim())
                {
                    Index = i;
                }
            }
            return Index;//返回索引
        }
        public static string Button_from_name(string ID)//分割字符串获取控件所在的窗口名称
        {
            string[] Name = ID.Split('.');
            string[] Name_1 = new string[2];
            if (Name.Length > 2)
            {
                Name_1 = Name[2].Split(',');
            }
            else
            {
              string[]  Name_2 = Name[1].Split(':');
              Name_1 = Name_2[1].Split('-');
            }
            return Name_1[0].Trim();//返回
        }
    }
}
