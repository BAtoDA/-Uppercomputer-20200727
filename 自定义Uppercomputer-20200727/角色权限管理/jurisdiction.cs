using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny;
namespace 自定义Uppercomputer_20200727.角色权限管理
{
    public partial class jurisdiction :Sunny.UI.UILoginForm
    {
        public jurisdiction()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Userjurisdiction userjurisdiction = new Userjurisdiction();
            userjurisdiction.ShowDialog();
        }

        private void jurisdiction_ExtendBoxClick(object sender, EventArgs e)
        {
          
        }

        private void jurisdiction_ButtonLoginClick(object sender, EventArgs e)
        {
           using(EF实体模型.UppercomputerEntities2 db=new EF实体模型.UppercomputerEntities2())
            {
                var user = db.Userpermissions.Where(p => p.用户名称.Trim() == comboBox1.Text.Trim()&&p.密码.Trim()==this.Password.Trim()).FirstOrDefault();
                if (user != null)
                    ShowInfoDialog("登录成功");
                else
                    ShowErrorNotifier("用户名或者密码错误：请重新输入");


            }
        }

        private void jurisdiction_Load(object sender, EventArgs e)
        {
            using (EF实体模型.UppercomputerEntities2 db = new EF实体模型.UppercomputerEntities2())
            {
                db.Userpermissions.ToList().ForEach(s1 => 
                {
                    comboBox1.Items.Add(s1.用户名称.Trim());
                });
            }
        }
    }
}
