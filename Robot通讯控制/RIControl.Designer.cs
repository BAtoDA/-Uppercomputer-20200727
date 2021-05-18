
namespace Robot通讯控制
{
    partial class RIControl
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
            this.uiLight1 = new Sunny.UI.UILight();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // uiLight1
            // 
            this.uiLight1.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.uiLight1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLight1.Location = new System.Drawing.Point(6, 7);
            this.uiLight1.Name = "uiLight1";
            this.uiLight1.Radius = 35;
            this.uiLight1.Size = new System.Drawing.Size(49, 49);
            this.uiLight1.TabIndex = 1;
            this.uiLight1.Text = "uiLight1";
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(18, 22);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(25, 21);
            this.uiLabel1.TabIndex = 2;
            this.uiLabel1.Text = "RI";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiLight1);
            this.Name = "RIControl";
            this.Size = new System.Drawing.Size(68, 69);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RIControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILight uiLight1;
        private Sunny.UI.UILabel uiLabel1;
    }
}
