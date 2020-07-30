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
        public SkinLabel_reform Add(System.Windows.Forms.Control.ControlCollection control, Point point)//添加按钮方法
        {
            this.Skinlabel_serial = Button_Name(control);
            SkinLabel_reform reform = new SkinLabel_reform();//实例化按钮
            reform.Size = new Size(20,30);//设置大小
            reform.Location = point;//设置按钮位置
            reform.Name = Skinlabel_serial.Trim();//设置名称
            reform.Text = Skinlabel_serial.Trim();//设置文本
            reform.BringToFront();//将控件放置所有控件最顶层        
            return reform;//返回数据
        }
        public string Button_Name(System.Windows.Forms.Control.ControlCollection control)//判断名称是否存在该窗口
        {
            List<System.Windows.Forms.Control> Data = (from Control pi in control where pi is SkinLabel_reform select pi).ToList();//获得名称            
            int dex = 0;//获得序列
        inedx:
            dex += 1;
            string Name = Skinlabel_serial + (Data.Count + dex);//先定义名称
            foreach (SkinLabel_reform i in Data)//遍历窗口是否有该名称存在
            {
                if (i.Name == Name.Trim()) goto inedx;
            }
            return Name;//返回名称
        }
    }
}
