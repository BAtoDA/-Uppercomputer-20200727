
namespace 自定义Uppercomputer_20200727.软件状态悬浮窗
{
    partial class FloatingForm
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
            this.uiLight1 = new Sunny.UI.UILight();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLight6 = new Sunny.UI.UILight();
            this.uiLight5 = new Sunny.UI.UILight();
            this.uiLight4 = new Sunny.UI.UILight();
            this.uiLight3 = new Sunny.UI.UILight();
            this.uiLight2 = new Sunny.UI.UILight();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.PLCtime = new System.Windows.Forms.Timer(this.components);
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLight1
            // 
            this.uiLight1.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.uiLight1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLight1.Location = new System.Drawing.Point(103, 36);
            this.uiLight1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLight1.Name = "uiLight1";
            this.uiLight1.Radius = 35;
            this.uiLight1.Size = new System.Drawing.Size(35, 35);
            this.uiLight1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLight1.TabIndex = 0;
            this.uiLight1.Text = "uiLight1";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(180, 6);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(151, 39);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "软件状态监控";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiLabel7);
            this.uiGroupBox1.Controls.Add(this.uiLight6);
            this.uiGroupBox1.Controls.Add(this.uiLight5);
            this.uiGroupBox1.Controls.Add(this.uiLight4);
            this.uiGroupBox1.Controls.Add(this.uiLight3);
            this.uiGroupBox1.Controls.Add(this.uiLight2);
            this.uiGroupBox1.Controls.Add(this.uiLabel2);
            this.uiGroupBox1.Controls.Add(this.uiLight1);
            this.uiGroupBox1.Controls.Add(this.uiLabel4);
            this.uiGroupBox1.Controls.Add(this.uiLabel3);
            this.uiGroupBox1.Controls.Add(this.uiLabel5);
            this.uiGroupBox1.Controls.Add(this.uiLabel6);
            this.uiGroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox1.ForeColor = System.Drawing.Color.White;
            this.uiGroupBox1.Location = new System.Drawing.Point(13, 46);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(475, 130);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 2;
            this.uiGroupBox1.Text = "PLC状态";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel7.ForeColor = System.Drawing.Color.White;
            this.uiLabel7.Location = new System.Drawing.Point(345, 84);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(74, 23);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 11;
            this.uiLabel7.Text = "台达PLC";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLight6
            // 
            this.uiLight6.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.uiLight6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLight6.Location = new System.Drawing.Point(432, 77);
            this.uiLight6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLight6.Name = "uiLight6";
            this.uiLight6.Radius = 35;
            this.uiLight6.Size = new System.Drawing.Size(35, 35);
            this.uiLight6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLight6.TabIndex = 10;
            this.uiLight6.Text = "uiLight6";
            // 
            // uiLight5
            // 
            this.uiLight5.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.uiLight5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLight5.Location = new System.Drawing.Point(262, 79);
            this.uiLight5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLight5.Name = "uiLight5";
            this.uiLight5.Radius = 35;
            this.uiLight5.Size = new System.Drawing.Size(35, 35);
            this.uiLight5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLight5.TabIndex = 8;
            this.uiLight5.Text = "uiLight5";
            // 
            // uiLight4
            // 
            this.uiLight4.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.uiLight4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLight4.Location = new System.Drawing.Point(103, 79);
            this.uiLight4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLight4.Name = "uiLight4";
            this.uiLight4.Radius = 35;
            this.uiLight4.Size = new System.Drawing.Size(35, 35);
            this.uiLight4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLight4.TabIndex = 6;
            this.uiLight4.Text = "uiLight4";
            // 
            // uiLight3
            // 
            this.uiLight3.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.uiLight3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLight3.Location = new System.Drawing.Point(432, 36);
            this.uiLight3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLight3.Name = "uiLight3";
            this.uiLight3.Radius = 35;
            this.uiLight3.Size = new System.Drawing.Size(35, 35);
            this.uiLight3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLight3.TabIndex = 4;
            this.uiLight3.Text = "uiLight3";
            // 
            // uiLight2
            // 
            this.uiLight2.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.uiLight2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLight2.Location = new System.Drawing.Point(262, 36);
            this.uiLight2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLight2.Name = "uiLight2";
            this.uiLight2.Radius = 35;
            this.uiLight2.Size = new System.Drawing.Size(35, 35);
            this.uiLight2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLight2.TabIndex = 2;
            this.uiLight2.Text = "uiLight2";
            this.uiLight2.Click += new System.EventHandler(this.uiLight2_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.ForeColor = System.Drawing.Color.White;
            this.uiLabel2.Location = new System.Drawing.Point(16, 43);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(74, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "三菱PLC";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.ForeColor = System.Drawing.Color.White;
            this.uiLabel4.Location = new System.Drawing.Point(328, 43);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(114, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 5;
            this.uiLabel4.Text = "MOdbusPLC";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.ForeColor = System.Drawing.Color.White;
            this.uiLabel3.Location = new System.Drawing.Point(175, 43);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(92, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 3;
            this.uiLabel3.Text = "西门子PLC";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.ForeColor = System.Drawing.Color.White;
            this.uiLabel5.Location = new System.Drawing.Point(16, 86);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(99, 23);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 7;
            this.uiLabel5.Text = "欧姆龙PLC";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.ForeColor = System.Drawing.Color.White;
            this.uiLabel6.Location = new System.Drawing.Point(175, 86);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(117, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 9;
            this.uiLabel6.Text = "发那科PLC";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.uiRichTextBox1);
            this.uiGroupBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox2.ForeColor = System.Drawing.Color.White;
            this.uiGroupBox2.Location = new System.Drawing.Point(13, 186);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(475, 193);
            this.uiGroupBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox2.TabIndex = 3;
            this.uiGroupBox2.Text = "Debug状态";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.AutoWordSelection = true;
            this.uiRichTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.uiRichTextBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.uiRichTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiRichTextBox1.ForeColor = System.Drawing.Color.White;
            this.uiRichTextBox1.Location = new System.Drawing.Point(4, 25);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.ReadOnly = true;
            this.uiRichTextBox1.Size = new System.Drawing.Size(463, 163);
            this.uiRichTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRichTextBox1.TabIndex = 0;
            this.uiRichTextBox1.Text = "uiRichTextBox1";
            this.uiRichTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PLCtime
            // 
            this.PLCtime.Enabled = true;
            this.PLCtime.Interval = 500;
            this.PLCtime.Tick += new System.EventHandler(this.PLCtime_Tick);
            // 
            // FloatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(501, 391);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FloatingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FloatingForm";
            this.Load += new System.EventHandler(this.FloatingForm_Load);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILight uiLight1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILight uiLight3;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILight uiLight2;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILight uiLight6;
        private Sunny.UI.UILight uiLight5;
        private Sunny.UI.UILight uiLight4;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private System.Windows.Forms.Timer PLCtime;
    }
}