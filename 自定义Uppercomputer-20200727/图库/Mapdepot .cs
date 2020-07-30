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
           
        }
        #region 窗体关闭效果
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果
        #endregion
        private void Mapdepot_Load(object sender, EventArgs e)//加载窗口
        {
            AnimateWindow(this.Handle, 600, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
            ListView_show listView = new ListView_show(new List<ImageList> { this.imageList1, this.imageList2, this.imageList3 },
               this.skinListView1, this.skinComboBox1, this.skinPictureBox1);
            listView.ListView_Load();//加载图库
        }

        private void Mapdepot_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 600, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
        }
    }
}
