namespace 自定义Uppercomputer_20200727.手动控制页面
{
    partial class Form4
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
            this.daButton1 = new 自定义Uppercomputer_20200727.非软件运行时控件.基本控件.DAButton();
            this.SuspendLayout();
            // 
            // daButton1
            // 
            this.daButton1.BackColor = System.Drawing.Color.Transparent;
            this.daButton1.Backdrop_OFF = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(131)))), ((int)(((byte)(229)))));
            this.daButton1.Backdrop_ON = System.Drawing.Color.Lime;
            this.daButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(131)))), ((int)(((byte)(229)))));
            this.daButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.daButton1.DownBack = null;
            this.daButton1.Location = new System.Drawing.Point(381, 100);
            this.daButton1.MouseBack = null;
            this.daButton1.Name = "daButton1";
            this.daButton1.NormlBack = null;
            this.daButton1.Pattern = 自定义Uppercomputer_20200727.非软件运行时控件.按钮操作模式.DAButton_pattern.Set_as_on;
            this.daButton1.Plc = PLC通讯规范接口.PLC.HMI;
            this.daButton1.PLC_Address = "1";
            this.daButton1.PLC_Contact = "Data_Bit";
            this.daButton1.PLC_Enable = true;
            this.daButton1.Size = new System.Drawing.Size(75, 23);
            this.daButton1.TabIndex = 2;
            this.daButton1.Text = "OFF";
            this.daButton1.UseVisualStyleBackColor = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 654);
            this.Controls.Add(this.daButton1);
            this.IsfunctionKey = true;
            this.Name = "Form4";
            this.Text = "Form4";
            this.Controls.SetChildIndex(this.daButton1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private 非软件运行时控件.基本控件.DAButton daButton1;
    }
}