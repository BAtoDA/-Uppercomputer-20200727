using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
namespace 自定义Uppercomputer_20200727.非软件运行时控件.PLC参数设置界面
{
    public partial class ComboxForm1 : Sunny.UI.UIForm
    {
        int[] key;
        string[] Data;
        public ComboxForm1(int[] key,string[] Data)
        {
            InitializeComponent();
            this.key = key;
            this.Data = Data;
        }

        private void ComboxForm1_Load(object sender, EventArgs e)
        {
            this.uiDataGridView1.Rows.Add();
            for (int i=0;i<this.key.Length; i++)
            {
                this.uiDataGridView1.Rows[i].Cells[0].Value = key[i];
                this.uiDataGridView1.Rows[i].Cells[1].Value = Data[i];
                this.uiDataGridView1.Rows.Add();
            }
        }

        public int[] keydata { get; set; }
        public string[] Value { get; set; }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            keydata = new int[this.uiDataGridView1.Rows.Count];
            Value=new string[this.uiDataGridView1.Rows.Count];
            for (int i=0;i<this.uiDataGridView1.Rows.Count;i++)
            {
                if(this.uiDataGridView1.Rows[i].Cells[0].Value!=null)
                {
                    keydata[i] = Convert.ToInt32(this.uiDataGridView1.Rows[i].Cells[0].Value);
                    Value[i] = this.uiDataGridView1.Rows[i].Cells[1].Value.ToString();
                }
            }
            this.Close();
        }
    }
}
