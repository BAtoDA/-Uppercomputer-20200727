using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HZH_Controls.Controls;
using Sunny;
namespace 自定义Uppercomputer_20200727.控制主页面模板
{
    public partial class Form2derma :Sunny.UI.UIForm
    {
        /// <summary>
        /// 用于窗口导航栏文字标识
        /// </summary>
        public static List<string> Navigation = new List<string>() { "添加控件", "注册报警", "宏指令", "链接设备", "伺服控制", "编辑模式", "数据查询", "关于" };
        /// <summary>
        /// 添加控件类型导航栏文字选项
        /// </summary>
        public static List<Tuple<string, List<string>>> Add_attachment = new List<Tuple<string, List<string>>>() { new Tuple<string, List<string>>("按钮类", new List<string>() { "Button_按钮", "透明化_Button", "CheckBox 单选按钮", "Switch_切换开关" }), new Tuple<string, List<string>>("文本类", new List<string>() { "Label_文本", "Texebox_数值", "LedDisplay数值显示" }), new Tuple<string, List<string>>("报警类", new List<string>() { "ScrollingText报警滚动条" }), new Tuple<string, List<string>>("指示类", new List<string>() { "LedBulb指示灯" }), new Tuple<string, List<string>>("图形", new List<string>() { "histogram_Chart柱形图", "doughnut_Chart圆形图", "oscillogram_Chart波形图", "HScrollBar_纵向移动图形", "VScrollBar_横向移动图形", "lmage_图片", "GroupBox四方边框条" }), new Tuple<string, List<string>>("表盘", new List<string>() { "AnalogMeter百分百表盘" }), new Tuple<string, List<string>>("二维码", new List<string>() { "二维码/条形码" }), new Tuple<string, List<string>>("功能键", new List<string>() { "功能键_画面切换", "ComboBox下拉菜单" }), new Tuple<string, List<string>>("工业图形类", new List<string>() { "Conveyor运输带" , "Valve流体阀门" })};
        public Form2derma()
        {
            InitializeComponent();
            ToolStripManager.Renderer = new HZH_Controls.Controls.ProfessionalToolStripRendererEx();
        }

        private void Form2derma_Load(object sender, EventArgs e)
        {
         
        }

        private void uiHeaderButton12_Click(object sender, EventArgs e)
        {

        }

        private void ucListExt1_ItemClick(HZH_Controls.Controls.UCListItemExt item)
        {

        }
    }
}
