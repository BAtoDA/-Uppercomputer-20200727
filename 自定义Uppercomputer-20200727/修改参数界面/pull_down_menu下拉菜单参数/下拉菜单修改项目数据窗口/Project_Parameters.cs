using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
namespace 自定义Uppercomputer_20200727.修改参数界面.pull_down_menu下拉菜单参数.下拉菜单修改项目数据窗口
{
    public partial class Project_Parameters : Skin_VS
    {
        //创建标志位
        public bool operation = false;//指示是否允许更改
        public string ID, Data, Name;//创建要返回的数据
        public Project_Parameters(string ID,string Data,string Name)
        {
            InitializeComponent();
            this.textBox1.Text = ID.Trim();
            this.textBox2.Text = Data.Trim();
            this.textBox3.Text = Name.Trim();
            this.Data = Data;
            this.Name = Name;
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            ID = this.textBox1.Text;
            if (this.textBox2.Text != null) { if (this.textBox2.Text.Trim() != "") Data = this.textBox2.Text ?? Data; }
            if (this.textBox3.Text != null) { if (this.textBox3.Text.Trim() != "") Name = this.textBox3.Text ?? Name; }
            operation = true;
            this.Close();//关闭窗口    
        }

        private void KeyPress_reform(object sender, KeyPressEventArgs e)//键盘事件--位置与大小数据
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字 最大数据不能大于3位数  
                {
                    e.Handled = true;//只能输入数字
                }
            }
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            operation = false;
            this.Close();//关闭窗口        
        }
    }
}
