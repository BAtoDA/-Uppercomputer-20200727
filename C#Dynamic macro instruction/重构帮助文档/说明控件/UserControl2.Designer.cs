namespace CSEngineTest.重构帮助文档.说明控件
{
    partial class UserControl2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(261, 22);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(0, 25);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.AutoWordSelection = true;
            this.uiRichTextBox1.FillColor = System.Drawing.SystemColors.Control;
            this.uiRichTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRichTextBox1.Location = new System.Drawing.Point(4, 29);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.RectColor = System.Drawing.Color.Transparent;
            this.uiRichTextBox1.Size = new System.Drawing.Size(1111, 280);
            this.uiRichTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRichTextBox1.TabIndex = 5;
            this.uiRichTextBox1.Text = resources.GetString("uiRichTextBox1.Text");
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(530, 6);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(106, 21);
            this.uiLabel2.TabIndex = 7;
            this.uiLabel2.Text = "宏指令编译器";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Image = global::CSEngineTest.Properties.Resources.宏指令编译器界面;
            this.skinPictureBox1.Location = new System.Drawing.Point(3, 300);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(817, 419);
            this.skinPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.skinPictureBox1.TabIndex = 6;
            this.skinPictureBox1.TabStop = false;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.skinPictureBox1);
            this.Controls.Add(this.uiRichTextBox1);
            this.Controls.Add(this.uiLabel1);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(1074, 722);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private Sunny.UI.UILabel uiLabel2;
    }
}
