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
using 自定义Uppercomputer_20200727.图库;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    public partial class Modification_Button : Skin_VS
    {
        
        private string Button_ID;//控件的基本信息
        private object all_purpose;//通用类型
        public Modification_Button(string ID,object all_purpose)
        {
            InitializeComponent();
            this.Button_ID = ID;//获取参数
            skinTextBox8.Text = Button_ID;//测试用
            this.all_purpose = all_purpose;
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            Mapdepot mapdepot = new Mapdepot();
            mapdepot.ShowDialog();
            var T = all_purpose.GetType().ToString();
            
        }

        private void Modification_Button_Shown(object sender, EventArgs e)
        {
            Modification_Button_Class modification_Button = new Modification_Button_Class
                (new List<SkinTabPage> {this.skinTabPage1,this.skinTabPage2,this.skinTabPage3,this.skinTabPage4,this.skinTabPage5 });//调用加载数据类
        }
    }
}
