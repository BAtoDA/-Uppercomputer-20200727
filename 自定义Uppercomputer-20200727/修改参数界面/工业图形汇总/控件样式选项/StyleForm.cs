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
namespace 自定义Uppercomputer_20200727.修改参数界面.工业图形汇总.控件样式选项
{
    public partial class StyleForm : Skin_VS
    {
        public int Imageindexes;
        private string[] ImageNmae;
        public StyleForm()
        {
            InitializeComponent();
        }
        public StyleForm(ImageList imageList,int Imageindexes,string[] ImageNmae)
        {
            InitializeComponent();
            this.imageList1 = imageList;
            this.Imageindexes = Imageindexes;
            this.ImageNmae = ImageNmae;
        }

        /// <summary>
        /// 窗口运行加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StyleForm_Load(object sender, EventArgs e)
        {
       
        }
        private void listView_ItemActivate(object sender, EventArgs e)
        {
            this.skinPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//显示图片方式
            this.skinPictureBox1.Image = this.imageList1.Images[this.skinListView1.SelectedItems[0].Index]; ;//获取用户选定的图片    
            this.Imageindexes = this.skinListView1.SelectedItems[0].Index;
        }
        /// <summary>
        /// 用户按下了确定键--回传数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StyleForm_Shown(object sender, EventArgs e)
        {
            //加载图库-图片 图名称
            this.skinListView1.Items.Clear();//清除图库
            this.skinListView1.View = System.Windows.Forms.View.LargeIcon;//设置图片参数
            this.skinListView1.LargeImageList = imageList1;//设置显示的图库 -默认显示图库0
            this.skinListView1.Columns.Add("控件样式选择", 400, HorizontalAlignment.Center); //将列头添加到ListView控件。
            this.skinListView1.BeginUpdate(); //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            for (int i = 0; i < ImageNmae.Length; i++)
            {
                ListViewItem lvi = new ListViewItem();//实例化控件子项
                lvi.ImageIndex = i;//添加位置索引

                lvi.Text = ImageNmae[i] ?? "样式" + i;//子项名称

                this.skinListView1.Items.Add(lvi);//添加子项
            }
            this.skinListView1.EndUpdate();//开始一次性绘制图库
            this.skinListView1.ItemActivate += listView_ItemActivate;//注册选择事件
            this.skinPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//显示图片方式
            this.skinPictureBox1.Image = this.imageList1.Images[0];//获取图形
        }
    }
}
