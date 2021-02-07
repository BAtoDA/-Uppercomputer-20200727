namespace CSEngineTest.重构帮助文档
{
    partial class Explain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("宏指令");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("宏指令编译器");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("宏指令语法");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("宏函数");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("自定义函数");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("宏内置元件");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("宏指令注意事项");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Socket通讯源码");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("串口通讯源码");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("数据转换源码");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("宏指令", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            this.uiTreeView1 = new Sunny.UI.UITreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // uiTreeView1
            // 
            this.uiTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTreeView1.CheckBoxes = true;
            this.uiTreeView1.FillColor = System.Drawing.Color.White;
            this.uiTreeView1.FillDisableColor = System.Drawing.Color.Black;
            this.uiTreeView1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTreeView1.Location = new System.Drawing.Point(8, 37);
            this.uiTreeView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTreeView1.Name = "uiTreeView1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "宏指令";
            treeNode2.Name = "节点1";
            treeNode2.Text = "宏指令编译器";
            treeNode3.Name = "节点2";
            treeNode3.Text = "宏指令语法";
            treeNode4.Name = "节点3";
            treeNode4.Text = "宏函数";
            treeNode5.Name = "节点2";
            treeNode5.Text = "自定义函数";
            treeNode6.Name = "节点3";
            treeNode6.Text = "宏内置元件";
            treeNode7.Name = "节点4";
            treeNode7.Text = "宏指令注意事项";
            treeNode8.Name = "Socket通讯源码";
            treeNode8.Text = "Socket通讯源码";
            treeNode9.Name = "串口通讯源码";
            treeNode9.Text = "串口通讯源码";
            treeNode10.Name = "数据转换源码";
            treeNode10.Text = "数据转换源码";
            treeNode11.Checked = true;
            treeNode11.Name = "宏指令";
            treeNode11.Text = "宏指令";
            this.uiTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11});
            this.uiTreeView1.SelectedNode = null;
            this.uiTreeView1.Size = new System.Drawing.Size(409, 815);
            this.uiTreeView1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTreeView1.TabIndex = 0;
            this.uiTreeView1.Text = "uiTreeView1";
            this.uiTreeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.uiTreeView1_NodeMouseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(178, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 817);
            this.panel1.TabIndex = 1;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // Explain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 861);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uiTreeView1);
            this.Name = "Explain";
            this.Text = "Explain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Explain_FormClosing);
            this.Load += new System.EventHandler(this.Explain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITreeView uiTreeView1;
        private System.Windows.Forms.Panel panel1;
    }
}