namespace CSEngineTest.重构帮助文档.说明控件
{
    partial class UserControl1
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(515, 11);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(58, 21);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "宏指令";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.AutoWordSelection = true;
            this.uiRichTextBox1.FillColor = System.Drawing.SystemColors.Control;
            this.uiRichTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiRichTextBox1.Location = new System.Drawing.Point(4, 37);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.RectColor = System.Drawing.Color.Transparent;
            this.uiRichTextBox1.Size = new System.Drawing.Size(1090, 158);
            this.uiRichTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRichTextBox1.TabIndex = 3;
            this.uiRichTextBox1.Text = "宏指令提供了应用程序之外所需的附加功能。在 HMI 运行时，宏指令可以自动的执行这些命令。\n\n它可以执行复杂的运算、字符串处理，和使用者与工程之间的交流等功能。本" +
    "索引介绍宏指令的语法、如何使用和编辑方法等功能。\n\n点选以下各区块查看详细说明。\n";
            this.uiRichTextBox1.TextChanged += new System.EventHandler(this.uiRichTextBox1_TextChanged);
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Image = global::CSEngineTest.Properties.Resources.宏指令主页面;
            this.skinPictureBox1.Location = new System.Drawing.Point(4, 203);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(811, 722);
            this.skinPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.skinPictureBox1.TabIndex = 4;
            this.skinPictureBox1.TabStop = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinPictureBox1);
            this.Controls.Add(this.uiRichTextBox1);
            this.Controls.Add(this.uiLabel1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1074, 957);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
    }
}
