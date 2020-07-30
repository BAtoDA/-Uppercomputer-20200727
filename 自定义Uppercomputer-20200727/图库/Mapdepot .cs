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

namespace 自定义Uppercomputer_20200727.图库
{
    public partial class Mapdepot : Skin_Metro
    {       
        public Mapdepot()
        {
            InitializeComponent();
        }

        private void Mapdepot_Shown(object sender, EventArgs e)
        {
            ListView_show listView = new ListView_show(new List<ImageList> { this.imageList1,this.imageList2,this.imageList3},
                this.skinListView1,this.skinComboBox1,this.skinPictureBox1);
            listView.ListView_Load();//加载图库
        }
    }
}
