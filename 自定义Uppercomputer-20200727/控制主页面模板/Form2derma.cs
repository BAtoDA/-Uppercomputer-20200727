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
namespace 自定义Uppercomputer_20200727.控制主页面模板
{
    public partial class Form2derma :Sunny.UI.UIForm
    {
        public Form2derma()
        {
            InitializeComponent();
        }

        private void Form2derma_Load(object sender, EventArgs e)
        {
            //添加标题栏
            List<HZH_Controls.Controls.ListEntity> data = new List<HZH_Controls.Controls.ListEntity>();
            data.Add(new HZH_Controls.Controls.ListEntity()
            {
                ID = Convert.ToString(1),
                Title = "选项" + 1,
                ShowMoreBtn = 1 % 2 == 1,
                Source = 1
            });
            this.ucListExt1.SetList(data);
        }
    }
}
