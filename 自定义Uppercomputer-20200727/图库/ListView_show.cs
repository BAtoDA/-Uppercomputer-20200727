using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义Uppercomputer_20200727.图库
{
    /// <图库类处理>
    class ListView_show
    {
        string[] Thenameof_thegallery = new string[] { "图库1", "图库2", "图库3" };//图库名称后续使用SQL定义
        public List<ImageList> imageLists;//图库类集合
        SkinListView skinListView;//显示图库控件
        SkinComboBox skinComboBox;//图库选项
        SkinPictureBox skinPicture;//显示用户选定的图片
        private Image image;//用户选定图
        public static Image image_thegallery { get; set; }//返回图片属性
        public static List<ImageList> imageLists_1 { get; set; } //图库类集合--不可修改
        public ListView_show(List<ImageList> imageLists,SkinListView skinListView, SkinComboBox skinComboBox, SkinPictureBox skinPicture)//构造函数
        {
            this.imageLists = imageLists;
            this.skinListView = skinListView;
            this.skinComboBox = skinComboBox;
            this.skinPicture = skinPicture;
            this.skinListView.ItemActivate += listView_ItemActivate;//注册选择事件
            this.skinComboBox.SelectionChangeCommitted += comboBox_SelectionChangeCommitted;//注册事件         
            imageLists_1 = imageLists;
        }
        public async void ListView_Load()//加载图库
        {
            var t = Task.Run(() =>
              {
                //图库选项菜单加载
                this.skinComboBox.Items.Clear();//移除图库选项
                foreach (string pi in this.Thenameof_thegallery)
                {
                      this.skinComboBox.Items.Add(pi);//添加图库选项
                }
                this.skinComboBox.SelectedItem = 0;//菜单活动项
                this.skinComboBox.SelectedIndex = 0;//菜单活动项
                //加载图库-图片 图名称
                this.skinListView.Items.Clear();//清除图库
                this.skinListView.View = System.Windows.Forms.View.LargeIcon;//设置图片参数
                this.skinListView.LargeImageList = imageLists[0];//设置显示的图库 -默认显示图库0
                this.skinListView.Columns.Add(Thenameof_thegallery[0], 400, HorizontalAlignment.Center); //将列头添加到ListView控件。
                this.skinListView.BeginUpdate(); //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
                for (int i = 0; i < imageLists[0].Images.Count; i++)
                  {
                      ListViewItem lvi = new ListViewItem();//实例化控件子项
                    lvi.ImageIndex = i;//添加位置索引

                    lvi.Text = Thenameof_thegallery[0] +" 图片_"+ i;//子项名称

                    this.skinListView.Items.Add(lvi);//添加子项
                }
                  this.skinListView.EndUpdate();//开始一次性绘制图库
            });
            await t;//等待加载完成
        }
        private void listView_ItemActivate(object sender, EventArgs e)
        {
            image = this.imageLists[this.skinComboBox.SelectedIndex].Images[this.skinListView.SelectedItems[0].Index];//获取用户选定的图片
            this.skinPicture.SizeMode = PictureBoxSizeMode.StretchImage;//显示图片方式
            this.skinPicture.Image = image;//获取用户选定的图片并且显示
            ListView_show.image_thegallery = this.skinPicture.Image;//传递图片参数
        }
        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)//用户选定的图库
        {
            //加载图库-图片 图名称
            this.skinListView.Items.Clear();//清除图库
            this.skinListView.View = System.Windows.Forms.View.LargeIcon;//设置图片参数
            this.skinListView.LargeImageList = imageLists[this.skinComboBox.SelectedIndex];//设置显示的图库 -默认显示图库0
            this.skinListView.Columns.Add(Thenameof_thegallery[this.skinComboBox.SelectedIndex], 400, HorizontalAlignment.Center); //将列头添加到ListView控件。
            this.skinListView.BeginUpdate(); //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            for (int i = 0; i < imageLists[this.skinComboBox.SelectedIndex].Images.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();//实例化控件子项
                lvi.ImageIndex = i;//添加位置索引

                lvi.Text = Thenameof_thegallery[this.skinComboBox.SelectedIndex] + " 图片_" + i;//子项名称

                this.skinListView.Items.Add(lvi);//添加子项
            }
            this.skinListView.EndUpdate();//开始一次性绘制图库
        }
        ~ListView_show()
        {
            this.skinListView.ItemActivate -= listView_ItemActivate;//注册选择事件
            this.skinComboBox.SelectionChangeCommitted -= comboBox_SelectionChangeCommitted;//注册事件
        }
    }
}
