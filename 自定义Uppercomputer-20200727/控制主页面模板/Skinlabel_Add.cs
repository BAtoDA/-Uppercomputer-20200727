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
    /// <本类主要产生用户点击添加-移除-拖放-等操作>
    class Skinlabel_Add
    {
        string Skinlabel_serial = " SkinLabel_reform";//默认名称
        public SkinLabel Add(System.Windows.Forms.Control.ControlCollection control, Point point)//添加按钮方法
        {
            this.Skinlabel_serial += (from Control pi in control where pi is SkinLabel select pi).ToList().Count;
            SkinLabel_reform reform = new SkinLabel_reform();//实例化按钮
            reform.Size = new Size(120,25);//设置大小
            reform.Location = point;//设置按钮位置
            reform.Name = Skinlabel_serial;//设置名称
            reform.Text = Skinlabel_serial;//设置文本
            return reform;//返回数据
        }
    }
}
