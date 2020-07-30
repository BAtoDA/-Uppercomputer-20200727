using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 自定义Uppercomputer_20200727.PLC选择;
using static 自定义Uppercomputer_20200727.控件重做.Button_reform;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    /// <本类用于处理控件的一般参数显示选项加载>    
    class Modification_General_parameters
    {
        public Modification_General_parameters(SkinComboBox comboBox_GroupBox_PLC, SkinComboBox comboBox_PLC_Bit,
            SkinRadioButton skinRadio,
            SkinComboBox comboBox_GroupBox_PLC_check, SkinComboBox comboBox_Bit_check, SkinComboBox skinCheck_pattern,PLC pLC)//按钮类
        {
            Mitsubishi_PLCload(ref comboBox_GroupBox_PLC);//加载PLC选项
            Mitsubishi_PLCload(ref comboBox_GroupBox_PLC_check);//加载PLC选项_复选
            SkinComboBox_Mitsubishi_BitLoad(ref comboBox_PLC_Bit, pLC);//加载相应PLC的辅助触点类型
            SkinComboBox_Mitsubishi_BitLoad(ref comboBox_Bit_check, pLC);//加载相应PLC的辅助触点类型
            button_pattern(ref skinCheck_pattern);//加载按钮模式
            skinRadio.Checked = true;//默认是为切换开关
        }
        public Modification_General_parameters(SkinComboBox comboBox_GroupBox_PLC, SkinComboBox comboBox_PLC_Bit,
           SkinComboBox comboBox_GroupBox_PLC_check, SkinComboBox comboBox_Bit_check,PLC pLC)//标签-文本类
        {
            Mitsubishi_PLCload(ref comboBox_GroupBox_PLC);//加载PLC选项
            Mitsubishi_PLCload(ref comboBox_GroupBox_PLC_check);//加载PLC选项_复选
            SkinComboBox_Mitsubishi_numericalLoad(ref comboBox_PLC_Bit, pLC);//加载相应PLC的寄存器类型
            SkinComboBox_Mitsubishi_numericalLoad(ref comboBox_Bit_check, pLC);//加载相应PLC的寄存器类型
        }
        public Modification_General_parameters(SkinComboBox comboBox_PLC_Bit, SkinComboBox comboBox_Bit_check, PLC pLC)//只修改Bit位于寄存器
        {
           // SkinComboBox_Mitsubishi_BitLoad(ref comboBox_PLC_Bit, pLC);//加载相应PLC的辅助类型
            SkinComboBox_Mitsubishi_BitLoad(ref comboBox_Bit_check, pLC);//加载相应PLC的辅助类型
        }
        public Modification_General_parameters(SkinComboBox comboBox_PLC, SkinComboBox comboBox_Bit_check, PLC pLC,int Data)//只修改寄存器
        {
            SkinComboBox_Mitsubishi_numericalLoad(ref comboBox_Bit_check, pLC);//加载相应PLC的辅助类型
        }
        public Modification_General_parameters()//构造函数无参数
        {

        }
        public void Mitsubishi_PLCload(ref SkinComboBox skinCombo)//加载PLC选项
        {
            skinCombo.Items.Clear();//清除选项
            foreach (PLC suit in Enum.GetValues(typeof(PLC)))
            {
                skinCombo.Items.Add(suit);//添加选项
            }
            skinCombo.SelectedIndex = 0;
            skinCombo.SelectedItem = 0;
        }
        public void SkinComboBox_Mitsubishi_BitLoad(ref SkinComboBox skinCombo, PLC pLC)//PLC辅助触点选项选项
        {
            skinCombo.Items.Clear();//清除选项
            switch (pLC)
            {
                case PLC.Mitsubishi:
                    foreach (Mitsubishi_bit suit in Enum.GetValues(typeof(Mitsubishi_bit)))
                    {
                        skinCombo.Items.Add(suit);//添加选项
                    }
                    break;
                case PLC.Siemens:
                    foreach (Siemens_bit suit in Enum.GetValues(typeof(Siemens_bit)))
                    {
                        skinCombo.Items.Add(suit);//添加选项
                    }
                    break;
                case PLC.Modbus_TCP:
                    foreach (Modbus_TCP_bit suit in Enum.GetValues(typeof(Modbus_TCP_bit)))
                    {
                        skinCombo.Items.Add(suit);//添加选项
                    }
                    break;
                case PLC.HMI:
                    foreach (HMI_bit suit in Enum.GetValues(typeof(HMI_bit)))
                    {
                        skinCombo.Items.Add(suit);//添加选项
                    }
                    break;
            }
            skinCombo.SelectedIndex = 0;
            skinCombo.SelectedItem = 0;
        }
        public void SkinComboBox_Mitsubishi_numericalLoad(ref SkinComboBox skinCombo, PLC pLC)//PLC软元件选项选项
        {
            skinCombo.Items.Clear();//清除选项
            switch (pLC)
            {
                case PLC.Mitsubishi:
                    foreach (Mitsubishi_D suit in Enum.GetValues(typeof(Mitsubishi_D)))
                    {
                        skinCombo.Items.Add(suit);//添加选项
                    }
                    break;
                case PLC.Siemens:
                    foreach (Siemens_D suit in Enum.GetValues(typeof(Siemens_D)))
                    {
                        skinCombo.Items.Add(suit);//添加选项
                    }
                    break;
                case PLC.Modbus_TCP:
                    foreach (Modbus_TCP_D suit in Enum.GetValues(typeof(Modbus_TCP_D)))
                    {
                        skinCombo.Items.Add(suit);//添加选项
                    }
                    break;
                case PLC.HMI:
                    foreach (HMI_D suit in Enum.GetValues(typeof(HMI_D)))
                    {
                        skinCombo.Items.Add(suit);//添加选项
                    }
                    break;
            }
            skinCombo.SelectedIndex = 0;
            skinCombo.SelectedItem = 0;
        }
        private void button_pattern(ref SkinComboBox skinCombo)//按钮操作模式
        {
            skinCombo.Items.Clear();//清除选项
            foreach (Button_pattern suit in Enum.GetValues(typeof(Button_pattern)))
            {
                skinCombo.Items.Add(suit);//添加选项
            }
            skinCombo.SelectedIndex = 0;
            skinCombo.SelectedItem = 0;
        }
    }
}
