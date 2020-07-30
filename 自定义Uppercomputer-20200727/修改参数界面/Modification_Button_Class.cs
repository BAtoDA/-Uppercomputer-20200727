using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.PLC选择;
using static System.Windows.Forms.Control;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    /// <本类用于处理修改参数_BUTTON按钮类处理>    
    class Modification_Button_Class
    {
        private List<SkinTabPage> skinTabs;//修改参数界面控件
        public Modification_Button_Class(List<SkinTabPage> skinTabs)
        {
            this.skinTabs = skinTabs;//获取控件对象
            Load(0);//目前先默认选择三菱--5U
        }
        private async void Load(int PLC)//加载控件信息
        {
            SkinGroupBox GroupBox_PLC = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "读取/写入地址" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox skinCombo_PLC = (SkinComboBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinComboBox13" select pi).FirstOrDefault();//查询PLC选项菜单
            SkinComboBox skinCombo_PLC_Bit = (SkinComboBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinComboBox12" select pi).FirstOrDefault();//查询PLC选项菜单
            SkinCheckBox skinCheckBox = (SkinCheckBox)(from Control pi in GroupBox_PLC.Controls where pi.Name == "skinCheckBox1" select pi).FirstOrDefault();//查询是否启用读写不同地址功能
            //预留功能
            SkinGroupBox GroupBox_PLC_check = (SkinGroupBox)(from Control pi in skinTabs[0].Controls where pi.Text == "写入地址_复选" select pi).FirstOrDefault();//查询要写入对象
            SkinComboBox skinCombo_PLC_check = (SkinComboBox)(from Control pi in GroupBox_PLC_check.Controls where pi.Name == "skinComboBox11" select pi).FirstOrDefault();//查询PLC选项菜单
            SkinComboBox skinCombo_PLC_Bit_check = (SkinComboBox)(from Control pi in GroupBox_PLC_check.Controls where pi.Name == "skinComboBox10" select pi).FirstOrDefault();//查询PLC选项菜单
            switch (PLC)
            {
                case 0://三菱PLC
                    skinCombo_PLC=ComboBox_Mitsubishi_PLCload(skinCombo_PLC);//修改对象并且返回对象
                    skinCombo_PLC_Bit = SkinComboBox_Mitsubishi_BitLoad(skinCombo_PLC_Bit);//修改对象并且返回对象
                    //预留功能数据填充
                    skinCombo_PLC_check = ComboBox_Mitsubishi_PLCload(skinCombo_PLC_check);//修改对象并且返回对象
                    skinCombo_PLC_Bit_check = SkinComboBox_Mitsubishi_BitLoad(skinCombo_PLC_Bit_check);//修改对象并且返回对象
                    break;
            }
            //预留功能读写不同地址
            skinCheckBox.MouseClick += skinCheckBox_MouseClick;//注册事件
            skinCheckBox_MouseClick(1, new EventArgs());//先隐藏
        }
        private SkinComboBox ComboBox_Mitsubishi_PLCload(SkinComboBox skinCombo)//加载PLC选项
        {
            skinCombo.Items.Clear();//清除选项
            skinCombo.Items.Add("Mitsubishi FX5U -(Ethernet)");//添加选项
            skinCombo.SelectedIndex = 0;
            skinCombo.SelectedItem = 0;
            return skinCombo;//返回对象
        }
        private SkinComboBox SkinComboBox_Mitsubishi_BitLoad(SkinComboBox skinCombo)
        {
            skinCombo.Items.Clear();//清除选项
            foreach (Mitsubishi_bit suit in Enum.GetValues(typeof(Mitsubishi_bit)))
            {
                skinCombo.Items.Add(suit);//添加选项
            }
            skinCombo.SelectedIndex = 0;
            skinCombo.SelectedItem = 0;
            return skinCombo;
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
        ~Modification_Button_Class()
        {
        
        }
    }
}
