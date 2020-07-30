namespace 自定义Uppercomputer_20200727.控制主页面
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.button_reform1 = new 自定义Uppercomputer_20200727.控件重做.Button_reform();
            this.button_reform2 = new 自定义Uppercomputer_20200727.控件重做.Button_reform();
            this.SuspendLayout();
            // 
            // button_reform1
            // 
            this.button_reform1.BackColor = System.Drawing.Color.Transparent;
            this.button_reform1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button_reform1.DownBack = null;
            this.button_reform1.Location = new System.Drawing.Point(340, 339);
            this.button_reform1.MouseBack = null;
            this.button_reform1.Name = "button_reform1";
            this.button_reform1.NormlBack = null;
            this.button_reform1.Size = new System.Drawing.Size(83, 31);
            this.button_reform1.TabIndex = 9;
            this.button_reform1.Text = "button_reform1";
            this.button_reform1.UseVisualStyleBackColor = false;
            // 
            // button_reform2
            // 
            this.button_reform2.BackColor = System.Drawing.Color.Transparent;
            this.button_reform2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button_reform2.DownBack = null;
            this.button_reform2.Location = new System.Drawing.Point(485, 339);
            this.button_reform2.MouseBack = null;
            this.button_reform2.Name = "button_reform2";
            this.button_reform2.NormlBack = null;
            this.button_reform2.Size = new System.Drawing.Size(83, 31);
            this.button_reform2.TabIndex = 10;
            this.button_reform2.Text = "button_reform2";
            this.button_reform2.UseVisualStyleBackColor = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 745);
            this.Controls.Add(this.button_reform2);
            this.Controls.Add(this.button_reform1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Controls.SetChildIndex(this.button_reform1, 0);
            this.Controls.SetChildIndex(this.button_reform2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private 控件重做.Button_reform button_reform1;
        private 控件重做.Button_reform button_reform2;
    }
}