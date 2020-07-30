using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCWin;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using CCWin.SkinControl;
using 自定义Uppercomputer_20200727.修改参数界面;

namespace 自定义Uppercomputer_20200727.异常界面
{
    public partial class Event_message : Skin_VS
    {
        Event_EF event_EF { get; set; }//打开窗口前一定要传入EF对象
        EF实体模型.Event_message event_Message;//报警参数
        int ID;//参数索引
        public Event_message(int ID)//构造函数---表明数据库无数据
        {
            InitializeComponent();
            this.ID = ID;
            event_EF = new Event_EF();//实例化EF
        }
        private void Event_message_Shown(object sender, EventArgs e)//加载控件初始值
        {
            //后面实现查询数据库改变索引
            event_Message = event_EF.Event_Query(ID);//查询数据库
            if (event_Message.IsNull() != true)//查询数据库是否有该ID数据
                Index(event_Message);//开始改变选项索引
            else
            {
                this.skinCheckBox1.Checked = true;
                this.skinCheckBox2.Checked = false;
                Event_message_Load event_Message_Load = new Event_message_Load(this.skinCheckBox1, this.skinCheckBox2,
 this.skinComboBox1, this.skinComboBox2, this.skinTextBox1, this.skinComboBox3, this.skinComboBox4, this.skinTextBox2, this.skinChatRichTextBox1);
            }
        }
        private void CheckBox_Click(object send, EventArgs e)//定义用户是否点击位与字
        {
            SkinCheckBox IN = (SkinCheckBox)send;//获取传入的对象
            Modification_General_parameters modification = new Modification_General_parameters();//实例化加载PLC
            if (IN.Text.Equals("位_bit"))//判断是否bit位
            {
                this.skinCheckBox1.Checked = true;
                this.skinCheckBox2.Checked = false;
                this.skinComboBox4.Visible = false;
                this.skinTextBox2.Visible = false;
                this.skinComboBox3.Visible = true;
                this.skinLabel1.Visible = true;
                this.skinLabel2.Visible = false;
                modification.Mitsubishi_PLCload(ref this.skinComboBox1);//填充设备类型
                modification.SkinComboBox_Mitsubishi_BitLoad(ref this.skinComboBox2, PLC选择.PLC.Mitsubishi);//默认填充三菱
            }
            else
            {
                this.skinCheckBox1.Checked = false;
                this.skinCheckBox2.Checked = true;
                this.skinComboBox4.Visible = true;
                this.skinTextBox2.Visible = true;
                this.skinComboBox3.Visible = false;
                this.skinLabel1.Visible = false;
                this.skinLabel2.Visible = true;
                modification.Mitsubishi_PLCload(ref this.skinComboBox1);//填充设备类型
                modification.SkinComboBox_Mitsubishi_numericalLoad(ref this.skinComboBox2, PLC选择.PLC.Mitsubishi);//默认填充三菱
            }
        }
        private void Index(EF实体模型.Event_message event_Message)
        {
            if (event_Message.类型 ==0)//改变类型
            {
                this.skinCheckBox1.Checked = true;
                this.skinCheckBox2.Checked = false;
                this.skinComboBox4.Visible = false;
                this.skinTextBox2.Visible = false;
                this.skinComboBox3.Visible = true;
                this.skinLabel1.Visible = true;
                this.skinLabel2.Visible = false;

            }
            else
            {
                this.skinCheckBox1.Checked = false;
                this.skinCheckBox2.Checked = true;
                this.skinComboBox4.Visible = true;
                this.skinTextBox2.Visible = true;
                this.skinComboBox3.Visible = false;
                this.skinLabel1.Visible = false;
                this.skinLabel2.Visible = true;
            }
            //填充数据
            Event_message_Load event_Message_Load = new Event_message_Load(this.skinCheckBox1, this.skinCheckBox2,
         this.skinComboBox1, this.skinComboBox2, this.skinTextBox1, this.skinComboBox3, this.skinComboBox4, this.skinTextBox2, this.skinChatRichTextBox1);
            ComboBox_Index(this.skinComboBox1, event_Message.设备.Trim());//索引设备
            ComboBox_Index(this.skinComboBox2, event_Message.设备_地址.Trim());//索引设备地址
            this.skinTextBox1.Text = event_Message.设备_具体地址.Trim();//填充地址
            ComboBox_Index(this.skinComboBox3, event_Message.位触发条件.Trim());//索引位触发地址
            ComboBox_Index(this.skinComboBox4, event_Message.字触发条件.Trim());//索引字触发地址
            this.skinTextBox2.Text = event_Message.字触发条件_具体.Trim();//具体字触发数据
            this.skinChatRichTextBox1.Text = event_Message.报警内容.Trim();//报警内容
        }
        private void ComboBox_Index(SkinComboBox skinComboBox,string Name)//改变下拉菜单的索引
        {
            for(int i=0;i<skinComboBox.Items.Count;i++)
            {
                if (skinComboBox.Items[i].ToString() == Name.Trim())
                {
                    skinComboBox.SelectedIndex = i;
                    skinComboBox.SelectedItem = i;
                }
            }        
        }
        private void skinButton1_Click(object sender, EventArgs e)//用户点击了保存
        {
            if (event_EF.Event_Query(ID).IsNull() != true)//查询数据库是否有该ID数据          
                event_EF.Event_modification(parameter());//修改数据库内容            
            else
                event_EF.Event_Add(parameter());//填充数据库
            this.Close();//关闭窗口
        }
        private EF实体模型.Event_message parameter()//要修改的参数
        {
            return new EF实体模型.Event_message
            {
                ID = ID,
                类型 = this.skinCheckBox1.Checked == true ? 0 : 1,
                设备 = this.skinComboBox1.Text,
                设备_地址 = this.skinComboBox2.Text,
                设备_具体地址 = this.skinTextBox1.Text??"0",
                位触发条件 = this.skinComboBox3.Text,
                字触发条件 = this.skinComboBox4.Text,
                字触发条件_具体 = this.skinTextBox2.Text??"0",
                报警内容 = this.skinChatRichTextBox1.Text??"请输入内容"
            };
        }
        private void skinButton2_Click(object sender, EventArgs e)//用户点击取消返回
        {
            this.Close();//关闭窗口
        }

    }
}
