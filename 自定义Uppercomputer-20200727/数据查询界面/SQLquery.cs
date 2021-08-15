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

namespace 自定义Uppercomputer_20200727.数据查询界面
{
    public partial class SQLquery : Sunny.UI.UIForm
    {
        public SQLquery()
        {
            InitializeComponent();
        }

        private async void SQLquery_Load(object sender, EventArgs e)
        {
            foreach(var i in typeof(自定义Uppercomputer_20200727.EF实体模型.UppercomputerEntities2).GetProperties())
            {
                this.uiComboBox1.Items.Add(i.Name);
            }
            this.uiDataGridView1.DataSource=await Task.Run(() =>
            {
                using(自定义Uppercomputer_20200727.EF实体模型.UppercomputerEntities2 db=new EF实体模型.UppercomputerEntities2())
                {
                    return  db.Button_Class.ToList();
                }
            });
        }


        private void uiComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("d");
        }
    }
}
