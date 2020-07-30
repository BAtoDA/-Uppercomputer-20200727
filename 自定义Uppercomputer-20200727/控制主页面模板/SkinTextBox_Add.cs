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
    class SkinTextBox_Add
    {
        string SkinTextBox_serial = " TextBox_reform";//默认名称
        public SkinTextBox Add(System.Windows.Forms.Control.ControlCollection control, Point point)//添加按钮方法
        {
            this.SkinTextBox_serial += (from Control pi in control where pi is SkinTextBox select pi).ToList().Count;
            SkinTextBox_reform reform = new SkinTextBox_reform();//实例化按钮
            reform.Size = new Size(83, 31);//设置大小
            reform.Location = point;//设置按钮位置
            reform.Name = SkinTextBox_serial;//设置名称
            reform.Text = SkinTextBox_serial;//设置文本
            reform.Lines = new string[] { SkinTextBox_serial };//初次显示文字
            return reform;//返回数据
        }
    }
}
