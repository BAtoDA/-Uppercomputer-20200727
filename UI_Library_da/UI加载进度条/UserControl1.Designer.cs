namespace UI_Library_da.UI加载进度条
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
            this.ucProcessEllipse1 = new HZH_Controls.Controls.UCProcessEllipse();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // ucProcessEllipse1
            // 
            this.ucProcessEllipse1.BackColor = System.Drawing.Color.Transparent;
            this.ucProcessEllipse1.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucProcessEllipse1.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucProcessEllipse1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ucProcessEllipse1.ForeColor = System.Drawing.Color.White;
            this.ucProcessEllipse1.IsShowCoreEllipseBorder = true;
            this.ucProcessEllipse1.Location = new System.Drawing.Point(107, 41);
            this.ucProcessEllipse1.MaxValue = 100;
            this.ucProcessEllipse1.Name = "ucProcessEllipse1";
            this.ucProcessEllipse1.ShowType = HZH_Controls.Controls.ShowType.Ring;
            this.ucProcessEllipse1.Size = new System.Drawing.Size(150, 150);
            this.ucProcessEllipse1.TabIndex = 10;
            this.ucProcessEllipse1.Value = 0;
            this.ucProcessEllipse1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucProcessEllipse1.ValueMargin = 5;
            this.ucProcessEllipse1.ValueType = HZH_Controls.Controls.ValueType.Percent;
            this.ucProcessEllipse1.ValueWidth = 30;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(135, 5);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(107, 25);
            this.uiLabel1.TabIndex = 11;
            this.uiLabel1.Text = "窗口加载中";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.White;
            this.uiLabel2.Location = new System.Drawing.Point(141, 198);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(90, 21);
            this.uiLabel2.TabIndex = 12;
            this.uiLabel2.Text = "窗口加载中";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.ucProcessEllipse1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(362, 225);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HZH_Controls.Controls.UCProcessEllipse ucProcessEllipse1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
    }
}
