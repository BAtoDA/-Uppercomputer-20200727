
namespace 自定义Uppercomputer_20200727.控制主页面模板
{
    partial class Form2derma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucListExt1 = new HZH_Controls.Controls.UCListExt();
            this.SuspendLayout();
            // 
            // ucListExt1
            // 
            this.ucListExt1.AutoScroll = true;
            this.ucListExt1.AutoSelectFirst = true;
            this.ucListExt1.ItemBackColor = System.Drawing.Color.White;
            this.ucListExt1.ItemForeColor = System.Drawing.Color.Black;
            this.ucListExt1.ItemForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucListExt1.ItemHeight = 60;
            this.ucListExt1.ItemSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucListExt1.ItemSelectedForeColor = System.Drawing.Color.White;
            this.ucListExt1.ItemSelectedForeColor2 = System.Drawing.Color.White;
            this.ucListExt1.Location = new System.Drawing.Point(3, 38);
            this.ucListExt1.Name = "ucListExt1";
            this.ucListExt1.SelectedCanClick = false;
            this.ucListExt1.Size = new System.Drawing.Size(150, 613);
            this.ucListExt1.SplitColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ucListExt1.TabIndex = 0;
            this.ucListExt1.Title2Font = new System.Drawing.Font("微软雅黑", 14F);
            this.ucListExt1.TitleFont = new System.Drawing.Font("微软雅黑", 15F);
            // 
            // Form2derma
            // 
            this.ClientSize = new System.Drawing.Size(950, 654);
            this.Controls.Add(this.ucListExt1);
            this.Name = "Form2derma";
            this.RectColor = System.Drawing.Color.LightGray;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.TitleColor = System.Drawing.Color.LightGray;
            this.Load += new System.EventHandler(this.Form2derma_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIHeaderButton uiHeaderButton6;
        private Sunny.UI.UIHeaderButton uiHeaderButton7;
        private Sunny.UI.UIHeaderButton uiHeaderButton4;
        private Sunny.UI.UIHeaderButton uiHeaderButton5;
        private Sunny.UI.UIHeaderButton uiHeaderButton3;
        private Sunny.UI.UIHeaderButton uiHeaderButton1;
        private HZH_Controls.Controls.UCListExt ucListExt1;
    }
}