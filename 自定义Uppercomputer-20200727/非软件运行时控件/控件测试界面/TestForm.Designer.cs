
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.daDataGridView_TO_PLC1 = new 自定义Uppercomputer_20200727.非软件运行时控件.DADataGridView_TO_PLC();
            ((System.ComponentModel.ISupportInitialize)(this.daDataGridView_TO_PLC1)).BeginInit();
            this.SuspendLayout();
            // 
            // daDataGridView_TO_PLC1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.daDataGridView_TO_PLC1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.daDataGridView_TO_PLC1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.daDataGridView_TO_PLC1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.daDataGridView_TO_PLC1.ColumnFont = null;
            this.daDataGridView_TO_PLC1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.daDataGridView_TO_PLC1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.daDataGridView_TO_PLC1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.daDataGridView_TO_PLC1.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.daDataGridView_TO_PLC1.Control_Text = "";
            this.daDataGridView_TO_PLC1.DataGridView_Name = new string[] {
        "data1"};
            this.daDataGridView_TO_PLC1.DataGridView_numerical = new PLC通讯规范接口.numerical_format[] {
        PLC通讯规范接口.numerical_format.Signed_32_Bit,
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.daDataGridView_TO_PLC1.DefaultCellStyle = dataGridViewCellStyle3;
            this.daDataGridView_TO_PLC1.EnableHeadersVisualStyles = false;
            this.daDataGridView_TO_PLC1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.daDataGridView_TO_PLC1.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daDataGridView_TO_PLC1.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.daDataGridView_TO_PLC1.Location = new System.Drawing.Point(233, 153);
            this.daDataGridView_TO_PLC1.Name = "daDataGridView_TO_PLC1";
            this.daDataGridView_TO_PLC1.numerical = PLC通讯规范接口.numerical_format.Signed_16_Bit;
            this.daDataGridView_TO_PLC1.Plc = PLC通讯规范接口.PLC.Siemens;
            this.daDataGridView_TO_PLC1.PLC_address = new string[] {
        "1.20",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0",
        "0"};
            this.daDataGridView_TO_PLC1.PLC_Address = "1.20";
            this.daDataGridView_TO_PLC1.PLC_Contact = "DB";
            this.daDataGridView_TO_PLC1.PLC_Enable = true;
            this.daDataGridView_TO_PLC1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.daDataGridView_TO_PLC1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.daDataGridView_TO_PLC1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.daDataGridView_TO_PLC1.RowTemplate.Height = 23;
            this.daDataGridView_TO_PLC1.Size = new System.Drawing.Size(60, 150);
            this.daDataGridView_TO_PLC1.TabIndex = 0;
            this.daDataGridView_TO_PLC1.TitleBack = null;
            this.daDataGridView_TO_PLC1.TitleBackColorBegin = System.Drawing.Color.White;
            this.daDataGridView_TO_PLC1.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.daDataGridView_TO_PLC1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.daDataGridView_TO_PLC1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DADataGridView_TO_PLC daDataGridView_TO_PLC1;
    }
}