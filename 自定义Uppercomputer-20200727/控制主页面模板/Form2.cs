using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinControl;
using 自定义Uppercomputer_20200727.参数设置画面;
using 自定义Uppercomputer_20200727.异常界面;
using 自定义Uppercomputer_20200727.手动控制页面;
using 自定义Uppercomputer_20200727.控制主页面;
using 自定义Uppercomputer_20200727.控制主页面模板;
using 自定义Uppercomputer_20200727.生产设置画面;
using 自定义Uppercomputer_20200727.监视画面;
using 自定义Uppercomputer_20200727.运转控制画面;

namespace 自定义Uppercomputer_20200727
{
    public partial class Form2 : CCWin.Skin_Mac
    {
        /// <该页面是模板通用页面->
        public Form2()
        {
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)//公用页面处理
        {
            SkinButton skinButton = (SkinButton)sender;
            _ = new Windowclass(new Form3(), new SkinButton[] { this.skinButton1, this.skinButton2, this.skinButton3,
                this.skinButton4, this.skinButton5, this.skinButton6,this.skinButton7}, new Form[] {new Form3(), new Form4(),new Form5()
                , new Form6(),new Form7(), new 生产设置画面.Form8(), new 参数设置画面.Form9()}, this.skinLabel1, skinButton);
        }

        private void skinContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        int X = 0, Y = 0;//窗口与鼠标的相对位置

        private void buttton按钮ToolStripMenuItem_Click(object sender, EventArgs e)//添加按钮
        {
            Button_Add button = new Button_Add();
            this.Controls.Add(button.Add(this.Controls, new Point(X, Y)));
        }

        private void label文本ToolStripMenuItem_Click(object sender, EventArgs e)//添加系统文本
        {
            Skinlabel_Add skinlabel = new Skinlabel_Add();
            this.Controls.Add(skinlabel.Add(this.Controls, new Point(X, Y)));
        }

        private void texebox数值ToolStripMenuItem_Click(object sender, EventArgs e)//添加系统输入文本
        {
            SkinTextBox_Add skinTextBox = new SkinTextBox_Add();
            this.Controls.Add(skinTextBox.Add(this.Controls, new Point(X, Y)));
        }

        private void lmage图片ToolStripMenuItem_Click(object sender, EventArgs e)//添加系统图片
        {
            SkinPictureBox_Add skinPicture = new SkinPictureBox_Add();
            this.Controls.Add(skinPicture.Add(this.Controls, new Point(X, Y),this.imageList1.Images[0]));
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            X=e.X;Y = e.Y;//获取屏幕位置
        }
    }
}
