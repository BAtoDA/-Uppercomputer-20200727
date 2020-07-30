using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 自定义Uppercomputer_20200727.PLC选择;
using 自定义Uppercomputer_20200727.修改参数界面;

namespace 自定义Uppercomputer_20200727.异常界面
{
    /// <本类用于处理报警窗口参数初始加载>    
    class Event_message_Load
    {
        public static string[] condition_Bit = new string[] { "ON", "OFF" };//触发条件--bit位
        public static string[] condition_word = new string[] { "<", ">", "==", "<>", ">=", "<=" };//触发条件--word字--由于枚举不能写小于等于号现用字符串替代
        public Event_message_Load(SkinCheckBox bit, SkinCheckBox word, SkinComboBox equipment, SkinComboBox address ,SkinTextBox address_data, SkinComboBox touch ,SkinComboBox status,SkinTextBox data,SkinChatRichTextBox richTextBox)
        {
            Modification_General_parameters modification = new Modification_General_parameters();//实例化加载PLC
            modification.Mitsubishi_PLCload(ref equipment);//填充设备类型
            if (bit.Checked)
            {
                bit.Checked = true;//默认Bit位
                word.Checked = false;//取消
                modification.SkinComboBox_Mitsubishi_BitLoad(ref address, PLC选择.PLC.Mitsubishi);//默认填充三菱
            }
            else
            {
                bit.Checked = false;//默认Bit位
                word.Checked = true;//取消
                modification.SkinComboBox_Mitsubishi_numericalLoad(ref address, PLC选择.PLC.Mitsubishi);//默认填充三菱
            }                 
            address_data.Text = "0";//默认地址0
            condition_Bit_traverse(touch);//填充bit
            condition_word_traverse(status);//填充word
            data.Text = "0";
            richTextBox.Text = "请输入报警内容。。。";//默认填充内容
            //绑定控件事件--实现选择PLC切换内容
            equipment.SelectedIndexChanged += ((send, e) =>
            {
                if (bit.Checked)
                    modification.SkinComboBox_Mitsubishi_BitLoad(ref address, PLC_Index(equipment.Text));//选项填充
                else
                    modification.SkinComboBox_Mitsubishi_numericalLoad(ref address, PLC_Index(equipment.Text));//填充选项
            });
        }
        public void condition_Bit_traverse(SkinComboBox skinComboBox)//遍历bit触发条件
        {
            skinComboBox.Items.Clear();//清空集合
            foreach (string i in condition_Bit)
            {
                skinComboBox.Items.Add(i);//填充选项
            }
            skinComboBox.SelectedIndex = 0;
            skinComboBox.SelectedItem = 0;
        }
        public void condition_word_traverse(SkinComboBox skinComboBox)//遍历WORD触发条件
        {
            skinComboBox.Items.Clear();//清空集合
            foreach (string i in condition_word)
            {
                skinComboBox.Items.Add(i);//填充选项
            }
            skinComboBox.SelectedIndex = 0;
            skinComboBox.SelectedItem = 0;
        }
        public PLC PLC_Index(string Name)//索引PLC选项
        {
            foreach (PLC suit in Enum.GetValues(typeof(PLC)))
            {
                if (suit.ToString()==Name.Trim()) return suit;
            }
            return PLC.Mitsubishi;
        }
    }
}
