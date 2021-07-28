using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using 自定义Uppercomputer_20200727.EF实体模型;

namespace 自定义Uppercomputer_20200727.角色权限管理
{
    public partial class Userjurisdiction :CCWin.Skin_VS
    {
        public Userjurisdiction()
        {
            InitializeComponent();
        }

        private async void Userjurisdiction_Load(object sender, EventArgs e)
        {
            await DataGridViewLoad();
        }
        /// <summary>
        /// 异步加载用户权限表格
        /// </summary>
        /// <returns></returns>
        public async Task DataGridViewLoad()
        {
            await Task.Run(() =>
            {
                //创建加载类
                new UserEFclass<Userpermission>().skinDataGridView_update(this.skinDataGridView1);
                return 1;
            });
        }

        private void Userjurisdiction_SizeChanged(object sender, EventArgs e)
        {
            this.uiLabel1.Left = (this.uiGroupBox1.Size.Width / 2)-70;
            this.uiLabel2.Left = this.uiLabel1.Left;
            this.uiTextBox1.Left = this.uiLabel1.Left+60;
            this.uiTextBox2.Left = this.uiLabel1.Left+60;

        }

        private void Userjurisdiction_Shown(object sender, EventArgs e)
        {
        }
    }
}
