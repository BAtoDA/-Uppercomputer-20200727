using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSEngineTest.重构帮助文档.说明控件.宏函数解析控件
{
    public partial class FunctionAnalysis : UserControl
    {
        public FunctionAnalysis()
        {
            InitializeComponent();
        }
        public string Name1 { get; set; } = "函数名称";
        public string Name2 { get; set; } = "函数内容";
        public string Name3 { get; set; } = "语法";
        public string Name4 { get; set; } = "语法内容";
        public string Name5 { get; set; } = "范例";
        public string Name6 { get; set; } = "范例内容";
        public string Name7 { get; set; } = "描述";
        public string Name8 { get; set; } = "描述内容";
        public Size formsize { get; set; }
        public void Font_Load()
        {
            //先判断函数内容文本长度调整panel长度
            this.skinLabel1.Text = Name2;
            this.panel1.Size = new Size(panel1.Size.Width, skinLabel1.Size.Height > 19 ?
                panel1.Size.Height + (skinLabel1.Size.Height - 19) : panel1.Size.Height);
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel1.Size.Height);
            skinLabel2.Top = (this.panel3.Size.Height / 2) - skinLabel2.Font.Height / 2;
            this.skinLabel2.Text = Name1;
            skinLabel2.Left = (this.panel3.Size.Width / 2) - Convert.ToInt32(skinLabel2.Size.Width / 2);
            //移动语法内容panel控件位置
            this.panel2.Top = this.panel1.Location.Y + this.panel1.Size.Height + 10;
            this.panel4.Top = this.panel1.Location.Y + this.panel1.Size.Height + 10;
            skinLabel4.Text = Name4;
            this.panel2.Size = new Size(panel2.Size.Width, skinLabel4.Size.Height > 19 ?
              panel2.Size.Height + (skinLabel4.Size.Height - 19) : panel2.Size.Height);
            this.panel4.Size = new Size(this.panel4.Size.Width, this.panel2.Size.Height);

            skinLabel3.Top = (this.panel4.Size.Height / 2) - skinLabel3.Font.Height / 2;
            this.skinLabel3.Text = Name3;
            skinLabel3.Left = (this.panel4.Size.Width / 2) - Convert.ToInt32(skinLabel3.Size.Width / 2);
            //移动范例内容panel控件
            this.panel6.Top = this.panel2.Location.Y + this.panel2.Size.Height + 10;
            this.panel5.Top = this.panel2.Location.Y + this.panel2.Size.Height + 10;
            skinLabel6.Text = Name6;
            this.panel6.Size = new Size(panel6.Size.Width, skinLabel6.Size.Height > 19 ?
              panel6.Size.Height + (skinLabel6.Size.Height - 19) : panel6.Size.Height);
            this.panel5.Size = new Size(this.panel5.Size.Width, this.panel6.Size.Height);

            skinLabel5.Top = (this.panel5.Size.Height / 2) - skinLabel5.Font.Height / 2;
            this.skinLabel5.Text = Name5;
            skinLabel5.Left = (this.panel5.Size.Width / 2) - Convert.ToInt32(skinLabel5.Size.Width / 2);

            //移动描述内容panel控件
            this.panel8.Top = this.panel6.Location.Y + this.panel6.Size.Height + 10;
            this.panel7.Top = this.panel6.Location.Y + this.panel6.Size.Height + 10;
            skinLabel8.Text = Name8;
            this.panel8.Size = new Size(panel8.Size.Width, skinLabel8.Size.Height > 19 ?
              panel8.Size.Height + (skinLabel8.Size.Height - 19) : panel8.Size.Height);
            this.panel7.Size = new Size(this.panel7.Size.Width, this.panel8.Size.Height);

            skinLabel7.Top = (this.panel8.Size.Height / 2) - (skinLabel7.Font.Height / 2);
            this.skinLabel7.Text = Name7;
            skinLabel7.Left = (this.panel8.Size.Width / 2) - Convert.ToInt32(skinLabel7.Size.Width / 2);
            //移动帮助内容panel控件
            this.panel9.Top = this.panel7.Location.Y + this.panel7.Size.Height + 5;
            this.skinChatRichTextBox1.Text = Name4;
            this.panel9.Size = new Size(this.panel9.Width, this.panel2.Size.Height);
            this.skinChatRichTextBox1.Size = this.panel9.Size;
            this.Size = new Size(this.Size.Width, this.panel9.Top + this.panel9.Height + 10);
            formsize = Size;
        }
    }
}
