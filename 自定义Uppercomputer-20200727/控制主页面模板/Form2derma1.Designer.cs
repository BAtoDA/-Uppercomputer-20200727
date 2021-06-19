
namespace 自定义Uppercomputer_20200727.控制主页面模板
{
    partial class Form2derma1
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
            this.navigationBar1 = new 自定义Uppercomputer_20200727.控制主页面模板.模板窗口导航栏控件.NavigationBar();
            this.SuspendLayout();
            // 
            // navigationBar1
            // 
            this.navigationBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(92)))), ((int)(((byte)(136)))));
            this.navigationBar1.Location = new System.Drawing.Point(3, 36);
            this.navigationBar1.Margin = new System.Windows.Forms.Padding(2);
            this.navigationBar1.Name = "navigationBar1";
            this.navigationBar1.Size = new System.Drawing.Size(116, 612);
            this.navigationBar1.TabIndex = 0;
            this.navigationBar1.OptionitemClick += new System.EventHandler(this.navigationBar1_OptionitemClick);
            this.navigationBar1.NavigationitemClick += new System.EventHandler(this.navigationBar1_NavigationitemClick);
            // 
            // Form2derma1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 654);
            this.Controls.Add(this.navigationBar1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2derma1";
            this.Text = "Form2derma1";
            this.ResumeLayout(false);

        }

        #endregion

        private 模板窗口导航栏控件.NavigationBar navigationBar1;
    }
}