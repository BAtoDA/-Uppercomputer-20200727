using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.图库;

namespace 自定义Uppercomputer_20200727.修改参数界面
{
    public partial class Modification_picture : Mapdepot
    {
        private string Button_ID;//控件的基本信息
        private object all_purpose;//通用类型
        public bool Add_to_allow = false;//反馈标志位是否允许添加
        picture_Class picture;//图片类全部参数
        private string From_Name;//控件处在的窗口名称
        private int serial;//用户选定的图片序号
        string[] Thenameof_thegallery = new string[] { "图库1", "图库2", "图库3" };//图库名称后续使用SQL定义
        public Image Image { get; set; }//返回用户选定的图片
        public Modification_picture(string ID, object all_purpose)
        {
            InitializeComponent();
            this.Button_ID = ID;//获取参数
            this.all_purpose = all_purpose;
            this.skinTextBox1.Text = Button_ID + "-" + ((SkinPictureBox)all_purpose).Name;//保存ID 为一地址  -是分割字符
            From_Name = parameter_indexes.Button_from_name(skinTextBox1.Text);//获取窗口名称
            this.skinListView1.ItemActivate += listView_ItemActivate;//注册事件
            this.skinButton1.Click += skinButton1_Click;//注册事件
        }

        private void Modification_picture_Shown(object sender, EventArgs e)
        {
            //查询数据库是否有该数据
            if (picture_EF.picture__Parameter_inquire(this.skinTextBox1.Text) == "OK")
            {
                picture_EF picture_EF = new picture_EF();//实例化EF对象
                picture = picture_EF.picture_Parameter_Query(this.skinTextBox1.Text);//获取按钮类全部参数
                List_Index();//开始改变索引
            }
        }
        private void List_Index()//索引
        {
            //this.skinComboBox1.SelectedIndex = picture.Control_state_0_list;
            //this.skinComboBox1.SelectedItem = picture.Control_state_0_list;
            //List_Index_Load();
            this.skinPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//显示图片方式
            this.skinPictureBox1.Image = ListView_show.imageLists_1[picture.Control_state_0_list].Images[picture.Control_state_0_picture];//获取数据库保存的图片
        }
        private void List_Index_Load()//用户选定的图库
        {
            //加载图库-图片 图名称
            this.skinListView1.Items.Clear();//清除图库
            this.skinListView1.View = System.Windows.Forms.View.LargeIcon;//设置图片参数
            this.skinListView1.LargeImageList = ListView_show.imageLists_1[this.skinComboBox1.SelectedIndex];//设置显示的图库 -默认显示图库0
            this.skinListView1.Columns.Add(Thenameof_thegallery[this.skinComboBox1.SelectedIndex], 400, HorizontalAlignment.Center); //将列头添加到ListView控件。
            this.skinListView1.BeginUpdate(); //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            for (int i = 0; i < ListView_show.imageLists_1[this.skinComboBox1.SelectedIndex].Images.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();//实例化控件子项
                lvi.ImageIndex = i;//添加位置索引

                lvi.Text = Thenameof_thegallery[this.skinComboBox1.SelectedIndex] + " 图片_" + i;//子项名称

                this.skinListView1.Items.Add(lvi);//添加子项
            }
            this.skinListView1.EndUpdate();//开始一次性绘制图库
        }
        private void listView_ItemActivate(object sender, EventArgs e)//用户选定的图片序号
        {
            serial = this.skinListView1.SelectedItems[0].Index;//获取用户选定的图片
        }
        private void skinButton1_Click(object sender, EventArgs e)//用户点击了保存
        {
            //先查询数据库有无此ID--有进行修改--无新增--
            picture_EF picture_EF = new picture_EF();//实例化EF对象
            if (picture_EF.picture__Parameter_inquire(this.skinTextBox1.Text) == "OK")
                picture_EF.picture_Parameter_modification(this.skinTextBox1.Text, picture_Parameter(), general_Parameters_Of_Picture(), control_Location());//修改数据库参数
            else
            {
                picture_EF.picture_Parameter_Add(picture_Parameter());//插入主参数
                picture_EF.picture_Parameter_Add(general_Parameters_Of_Picture());//插入图片参数
                picture_EF.picture_Parameter_Add(control_Location());//插入控件坐标参数
            }
            if(this.skinPictureBox1.Image!=null) Image = this.skinPictureBox1.Image;
            ((SkinPictureBox)all_purpose).SizeMode = PictureBoxSizeMode.StretchImage;//显示图片方式
            if (this.skinPictureBox1.Image != null) ((SkinPictureBox)all_purpose).Image= this.skinPictureBox1.Image;
            Add_to_allow = true;
            this.Close();
            this.Dispose();
        }
        private picture_parameter picture_Parameter()
        {
            return new picture_parameter
            {
                ID = skinTextBox1.Text,
                FORM = From_Name
            };
        }
        private General_parameters_of_picture general_Parameters_Of_Picture()//获取要写入的图片参数---目前未实现
        {
            return new General_parameters_of_picture
            {
                Control_state_0 = 0,
                Control_state_0_list =this.skinComboBox1.SelectedIndex,
                Control_state_0_picture = serial,
                Control_state_1 = 1,
                Control_state_1_list = this.skinComboBox1.SelectedIndex,
                Control_state_1_picture = serial,
                Control_type = ((SkinPictureBox)this.all_purpose).Name,
                FORM = From_Name,
                ID = skinTextBox1.Text
            };
        }
        private control_location control_Location()//获取要写入的控件位置
        {
            return new control_location
            {
                ID = skinTextBox1.Text,
                FORM = From_Name,
                location = ((SkinPictureBox)this.all_purpose).Location.X + "-" + ((SkinPictureBox)this.all_purpose).Location.Y,
                size = ((SkinPictureBox)this.all_purpose).Size.Width + "-" + ((SkinPictureBox)this.all_purpose).Size.Height
            };
        }
    }
}
