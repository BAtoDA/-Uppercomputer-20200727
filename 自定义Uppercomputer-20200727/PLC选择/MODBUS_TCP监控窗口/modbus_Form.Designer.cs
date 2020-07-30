namespace 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口
{
    partial class modbus_Form
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modbus_Form));
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.skinChatRichTextBox1 = new CCWin.SkinControl.SkinChatRichTextBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinChatRichTextBox2 = new CCWin.SkinControl.SkinChatRichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.doughnut_Chart1 = new UI_Library_da.doughnut_Chart();
            ((System.ComponentModel.ISupportInitialize)(this.doughnut_Chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // skinChatRichTextBox1
            // 
            this.skinChatRichTextBox1.Location = new System.Drawing.Point(472, 102);
            this.skinChatRichTextBox1.Name = "skinChatRichTextBox1";
            this.skinChatRichTextBox1.SelectControl = null;
            this.skinChatRichTextBox1.SelectControlIndex = 0;
            this.skinChatRichTextBox1.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.skinChatRichTextBox1.Size = new System.Drawing.Size(345, 318);
            this.skinChatRichTextBox1.TabIndex = 0;
            this.skinChatRichTextBox1.Text = "";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(551, 156);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(44, 17);
            this.skinLabel1.TabIndex = 1;
            this.skinLabel1.Text = "发送区";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(563, 59);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 3;
            this.skinLabel2.Text = "接收";
            // 
            // skinChatRichTextBox2
            // 
            this.skinChatRichTextBox2.Location = new System.Drawing.Point(444, 102);
            this.skinChatRichTextBox2.Name = "skinChatRichTextBox2";
            this.skinChatRichTextBox2.SelectControl = null;
            this.skinChatRichTextBox2.SelectControlIndex = 0;
            this.skinChatRichTextBox2.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.skinChatRichTextBox2.Size = new System.Drawing.Size(345, 318);
            this.skinChatRichTextBox2.TabIndex = 2;
            this.skinChatRichTextBox2.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // doughnut_Chart1
            // 
            this.doughnut_Chart1.BorderlineColor = System.Drawing.Color.BlanchedAlmond;
            chartArea1.Name = "ChartArea1";
            this.doughnut_Chart1.ChartAreas.Add(chartArea1);
            this.doughnut_Chart1.doughnut_Chart_Data = ((System.Collections.Generic.List<string>)(resources.GetObject("doughnut_Chart1.doughnut_Chart_Data")));
            this.doughnut_Chart1.doughnut_Chart_Data_INT = ((System.Collections.Generic.List<int>)(resources.GetObject("doughnut_Chart1.doughnut_Chart_Data_INT")));
            this.doughnut_Chart1.doughnut_Chart_Font = new System.Drawing.Font("宋体", 15F);
            this.doughnut_Chart1.doughnut_Chart_Name = "chartArea";
            this.doughnut_Chart1.doughnut_Chart_Text = "PLC数据监控圆形图";
            legend1.Name = "Legend1";
            this.doughnut_Chart1.Legends.Add(legend1);
            this.doughnut_Chart1.Load_number = 5;
            this.doughnut_Chart1.Location = new System.Drawing.Point(64, 37);
            this.doughnut_Chart1.Name = "doughnut_Chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.doughnut_Chart1.Series.Add(series1);
            this.doughnut_Chart1.Size = new System.Drawing.Size(300, 300);
            this.doughnut_Chart1.TabIndex = 4;
            this.doughnut_Chart1.Text = "doughnut_Chart1";
            // 
            // modbus_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.doughnut_Chart1);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinChatRichTextBox2);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.skinChatRichTextBox1);
            this.Name = "modbus_Form";
            this.Text = "modbus_Form";
            this.Load += new System.EventHandler(this.modbus_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.doughnut_Chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinChatRichTextBox skinChatRichTextBox1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinChatRichTextBox skinChatRichTextBox2;
        private System.Windows.Forms.Timer timer1;
        private UI_Library_da.doughnut_Chart doughnut_Chart1;
    }
}