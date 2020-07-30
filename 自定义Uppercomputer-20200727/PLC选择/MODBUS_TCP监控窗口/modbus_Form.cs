using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.控件重做;

namespace 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口
{
    public partial class modbus_Form : Form
    {
        public modbus_Form()
        {
            InitializeComponent();
            MODBUD_TCP.SkinChatRichTextBox1 = this.skinChatRichTextBox1;
            MODBUD_TCP.SkinChatRichTextBox2 = this.skinChatRichTextBox2;
        }
        BarChart_reform barChart_Reform;
        private void modbus_Form_Load(object sender, EventArgs e)
        {
            barChart_Reform = new BarChart_reform();
            barChart_Reform.Data_Bar1 = new int[] { 10, 20, 20, 20, 20 };
            barChart_Reform.Data_Bar2 = new int[] { 10, 20, 20, 20, 20 };
            barChart_Reform.TextInterval = 100;
            timer1.Start();
            this.Controls.Add(barChart_Reform);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int inr = 60;      
            barChart_Reform.Data_Bar1 = new int[] { (inr+=1), 20, 20, 20, 20 };
            barChart_Reform.Data_Bar2 = new int[] { 20, 20, 20, 20, 20 };
            barChart_Reform.CreateEmptn();
        }
    }
}
