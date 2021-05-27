using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UI_Library_da.UI加载进度条
{
    [ToolboxItem(false)]
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
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
        /// <summary>
        /// 窗口的显示性
        /// </summary>
        [Description("进度条可显示性"), Category("自定义")]
        [DefaultValue(typeof(bool), "开")]
        public bool Display { get => this.Visible; set => FormDisplay(value); }
        private void FormDisplay(bool Value)
        {
            this.ucProcessEllipse1.Visible = Value;
            this.uiLabel1.Visible = Value;
            this.uiLabel2.Visible = Value;
            this.Visible = Value;
        }
        /// <summary>
        /// 进度条--进度
        /// </summary>
        [Description("进度当前值"), Category("自定义")]
        [DefaultValue(typeof(int), "0")]
        public int Schedule { get => this.ucProcessEllipse1.Value; set => this.ucProcessEllipse1.Value = value; }
        /// <summary>
        /// 进度文本显示值
        /// </summary>
        [Description("进度显示文本"), Category("自定义")]
        [DefaultValue(typeof(string), "当前任务")]
        public string Schedule_Text { get => this.uiLabel2.Text; set => this.uiLabel2.Text=value; }

    }
}
