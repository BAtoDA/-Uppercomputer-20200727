using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.控件重做;

namespace 自定义Uppercomputer_20200727.控制主页面模板
{
    class SkinPictureBox_Add
    {
        string Button_serial = "SkinPictureBox_reform";//默认名称
        public SkinPictureBox Add(System.Windows.Forms.Control.ControlCollection control, Point point,Image image)//添加按钮方法
        {
            this.Button_serial += (from Control pi in control where pi is SkinPictureBox select pi).ToList().Count;
            SkinPictureBox_reform reform = new SkinPictureBox_reform();//实例化按钮
            reform.Size = new Size(100, 100);//设置大小
            reform.Location = point;//设置按钮位置
            reform.Name = Button_serial;//设置名称
            reform.Text = Button_serial;//设置文本
            reform.Image = image;//初次显示图片
            reform.SizeMode = PictureBoxSizeMode.StretchImage;//显示图片方式
            return reform;//返回数据
        }
    }
}
