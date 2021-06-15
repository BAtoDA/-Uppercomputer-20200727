
namespace 自定义Uppercomputer_20200727.非软件运行时控件.控件测试界面
{
    partial class TestForm
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
            this.daAlarmLamp1 = new 自定义Uppercomputer_20200727.非软件运行时控件.基本控件.DAAlarmLamp();
            this.daButton1 = new 自定义Uppercomputer_20200727.非软件运行时控件.基本控件.DAButton();
            this.daDataGridView_TO_PLC1 = new 自定义Uppercomputer_20200727.非软件运行时控件.DADataGridView_TO_PLC();
            ((System.ComponentModel.ISupportInitialize)(this.daDataGridView_TO_PLC1)).BeginInit();
            this.SuspendLayout();
            // 
            // daAlarmLamp1
            // 
            this.daAlarmLamp1.Backdrop_OFF = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(131)))), ((int)(((byte)(229)))));
            this.daAlarmLamp1.Backdrop_ON = System.Drawing.Color.Lime;
            this.daAlarmLamp1.Button_select = false;
            this.daAlarmLamp1.Command = false;
            this.daAlarmLamp1.I_FlickerColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))))};
            this.daAlarmLamp1.I_FlickerTime = 1000;
            this.daAlarmLamp1.LampColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))))};
            this.daAlarmLamp1.Lampstand = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.daAlarmLamp1.Location = new System.Drawing.Point(255, 49);
            this.daAlarmLamp1.Name = "daAlarmLamp1";
            this.daAlarmLamp1.O_FlickerColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))))};
            this.daAlarmLamp1.O_FlickerTime = 1000;
            this.daAlarmLamp1.Pattern = 自定义Uppercomputer_20200727.非软件运行时控件.按钮操作模式.DAButton_pattern.Set_as_off;
            this.daAlarmLamp1.PLC_Address = "0";
            this.daAlarmLamp1.PLC_Contact = "X";
            this.daAlarmLamp1.PLC_Enable = false;
            this.daAlarmLamp1.Size = new System.Drawing.Size(50, 50);
            this.daAlarmLamp1.TabIndex = 1;
            this.daAlarmLamp1.Text_OFF = "OFF";
            this.daAlarmLamp1.Text_ON = "ON";
            this.daAlarmLamp1.TwinkleSpeed = 0;
            // 
            // daButton1
            // 
            this.daButton1.BackColor = System.Drawing.Color.Transparent;
            this.daButton1.Backdrop_OFF = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(131)))), ((int)(((byte)(229)))));
            this.daButton1.Backdrop_ON = System.Drawing.Color.Lime;
            this.daButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.daButton1.DownBack = null;
            this.daButton1.Location = new System.Drawing.Point(144, 38);
            this.daButton1.MouseBack = null;
            this.daButton1.Name = "daButton1";
            this.daButton1.NormlBack = null;
            this.daButton1.Pattern = 自定义Uppercomputer_20200727.非软件运行时控件.按钮操作模式.DAButton_pattern.Regression;
            this.daButton1.PLC_Address = "0";
            this.daButton1.PLC_Contact = "X";
            this.daButton1.PLC_Enable = false;
            this.daButton1.Size = new System.Drawing.Size(91, 62);
            this.daButton1.TabIndex = 0;
            this.daButton1.Text = "daButton1";
            this.daButton1.UseVisualStyleBackColor = false;
            // 
            // daDataGridView_TO_PLC1
            // 
            this.daDataGridView_TO_PLC1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.daDataGridView_TO_PLC1.Control_Text = "";
            this.daDataGridView_TO_PLC1.DataGridView_Name = new string[] {
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null};
            this.daDataGridView_TO_PLC1.DataGridView_numerical = new PLC通讯规范接口.numerical_format[] {
        PLC通讯规范接口.numerical_format.Signed_16_Bit,
        PLC通讯规范接口.numerical_format.Signed_16_Bit,
        PLC通讯规范接口.numerical_format.Signed_16_Bit,
        PLC通讯规范接口.numerical_format.Signed_16_Bit,
        PLC通讯规范接口.numerical_format.Signed_16_Bit,
        PLC通讯规范接口.numerical_format.Signed_16_Bit,
        PLC通讯规范接口.numerical_format.Signed_16_Bit,
        PLC通讯规范接口.numerical_format.Signed_16_Bit,
        PLC通讯规范接口.numerical_format.Signed_16_Bit,
        PLC通讯规范接口.numerical_format.Signed_16_Bit};
            this.daDataGridView_TO_PLC1.DataGridViewPLC_Time = true;
            this.daDataGridView_TO_PLC1.Location = new System.Drawing.Point(255, 175);
            this.daDataGridView_TO_PLC1.Name = "daDataGridView_TO_PLC1";
            this.daDataGridView_TO_PLC1.numerical = PLC通讯规范接口.numerical_format.Signed_16_Bit;
            this.daDataGridView_TO_PLC1.PLC_address = new string[] {
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0"};
            this.daDataGridView_TO_PLC1.PLC_Address = "0";
            this.daDataGridView_TO_PLC1.PLC_Contact = "D";
            this.daDataGridView_TO_PLC1.PLC_Enable = true;
            this.daDataGridView_TO_PLC1.Size = new System.Drawing.Size(240, 150);
            this.daDataGridView_TO_PLC1.TabIndex = 2;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.daDataGridView_TO_PLC1);
            this.Controls.Add(this.daAlarmLamp1);
            this.Controls.Add(this.daButton1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.daDataGridView_TO_PLC1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private 基本控件.DAButton daButton1;
        private 基本控件.DAAlarmLamp daAlarmLamp1;
        private DADataGridView_TO_PLC daDataGridView_TO_PLC1;
    }
}