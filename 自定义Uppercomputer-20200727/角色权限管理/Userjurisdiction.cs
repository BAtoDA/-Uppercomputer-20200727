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
using CCWin.SkinControl;
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
        /// <summary>
        /// 触发修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (this.skinDataGridView1.CurrentCell.RowIndex.IsNull() != true)//判断用户是否选中行//判断用户是否选中行
            {
                if (this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() == "")//用户是否选中了空行
                {
                    MessageBox.Show("你选中了空行", "Err");//提示异常
                    return; //返回方法
                }
                else
                {
                    using (UppercomputerEntities2 db = new UppercomputerEntities2())
                    {
                        var modificationkey = Convert.ToInt32(this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                        var modificationData = db.Userpermissions.Where(p => p.ID == modificationkey).FirstOrDefault();
                        if (modificationData != null)
                        {
                            //modificationData.ID = modificationkey;
                            modificationData.用户名称 = this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                            modificationData.密码 = this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
                            modificationData.启用 = Convert.ToBoolean(this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[1].Value);
                            modificationData.类别A= Convert.ToBoolean(this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[4].Value);
                            modificationData.类别B = Convert.ToBoolean(this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[5].Value);
                            modificationData.类别C = Convert.ToBoolean(this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[6].Value);
                            modificationData.类别D = Convert.ToBoolean(this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[7].Value);
                        }                          
                        db.SaveChanges();
                    }
                    await DataGridViewLoad();//更新数据库
                }
            }
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (UppercomputerEntities2 db = new UppercomputerEntities2())
            {
                //插入默认数据
                int Key = db.Userpermissions.FirstOrDefault() != null ? db.Userpermissions.Max(p => p.ID) : 0;
                db.Userpermissions.Add(new Userpermission()
                {
                    ID = Key,
                    启用 = false,
                    密码 = "000",
                    用户名称 = $"user{Key}",
                    类别A = true,
                    类别B = true,
                    类别C = true,
                    类别D = true
                });
                db.SaveChanges();
            }
            await DataGridViewLoad();//更新数据库
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            if (this.skinDataGridView1.CurrentCell.RowIndex.IsNull() != true)//判断用户是否选中行//判断用户是否选中行
            {
                if (this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() == "")//用户是否选中了空行
                {
                    MessageBox.Show("你选中了空行", "Err");//提示异常
                    return; //返回方法
                }
                else
                {
                    using (UppercomputerEntities2 db = new UppercomputerEntities2())
                    {
                        var Removekey = Convert.ToInt32(this.skinDataGridView1.Rows[this.skinDataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                        var RemoveData = db.Userpermissions.Where(p => p.ID == Removekey).FirstOrDefault();
                        if (RemoveData != null)
                            db.Userpermissions.Remove(RemoveData);
                        db.SaveChanges();
                    }
                    await DataGridViewLoad();//更新数据库
                }
            }
        }
    }
}
