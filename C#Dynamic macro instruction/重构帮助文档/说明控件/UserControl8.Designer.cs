
namespace CSEngineTest.重构帮助文档.说明控件
{
    partial class UserControl8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl8));
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(447, 5);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(106, 21);
            this.skinLabel1.TabIndex = 14;
            this.skinLabel1.Text = "串口通讯源码";
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.AutoWordSelection = true;
            this.uiRichTextBox1.FillColor = System.Drawing.SystemColors.Control;
            this.uiRichTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRichTextBox1.Location = new System.Drawing.Point(6, 50);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.RectColor = System.Drawing.Color.Transparent;
            this.uiRichTextBox1.Size = new System.Drawing.Size(1074, 2043);
            this.uiRichTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRichTextBox1.TabIndex = 13;
            this.uiRichTextBox1.Text = resources.GetString("uiRichTextBox1.Text");
            // 
            // UserControl8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.uiRichTextBox1);
            this.Name = "UserControl8";
            this.Size = new System.Drawing.Size(1074, 2164);
            this.Load += new System.EventHandler(this.UserControl8_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
    }
}
