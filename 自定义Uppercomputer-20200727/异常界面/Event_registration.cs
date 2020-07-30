using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCWin;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using CCWin.SkinControl;
using CCWin.SkinClass;
using Microsoft.Graph;

namespace 自定义Uppercomputer_20200727.异常界面
{
    public partial class Event_registration : Skin_VS
    {
        public Event_registration()
        {
            InitializeComponent();
        }
        Event_EF event_EF;//EF操作对象
        private void Event_registration_Shown(object sender, EventArgs e)//加载数据
        {
            event_EF = new Event_EF();
            event_EF.skinDataGridView_update(this.skinDataGridView1);
        }
        private void skinDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)//判断用户是否选中行
            {
                if (this.skinDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim()=="")//用户是否选中了空行
                {
                    MessageBox.Show("你选中了空行", "Err");//提示异常
                    return; //返回方法
                }
                else
                {
                    Event_message event_Message = new Event_message(this.skinDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToInt32());//弹出窗口
                    event_Message.ShowDialog();//显示窗口
                    event_EF.skinDataGridView_update(this.skinDataGridView1);//更新数据库
                }
            }
            
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)//插入报警
        {
            Event_message event_Message = new Event_message(event_EF.Event_ID_maximum());//弹出窗口
            event_Message.ShowDialog();//显示窗口
            event_EF.skinDataGridView_update(this.skinDataGridView1);//更新数据库
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)//删除报警
        {
            if (this.skinDataGridView1.CurrentCell.RowIndex.IsNull()!=true)//判断用户是否选中行
            {
                event_EF.skinDataGridView_RemoveAt(this.skinDataGridView1);//实现删除行
                event_EF.skinDataGridView_update(this.skinDataGridView1);//更新数据库
            }
        }

        private void Event_registration_Load(object sender, EventArgs e)
        {

        }
    }
}
