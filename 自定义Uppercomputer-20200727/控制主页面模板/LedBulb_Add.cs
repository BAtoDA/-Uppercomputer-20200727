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
    /// <summary>
    /// <指示灯类控件添加>
    /// </summary>
    class LedBulb_Add
    {
        string LedBulb_serial = "LedBulb_reform";//默认名称
        public LedBulb_reform Add(System.Windows.Forms.Control.ControlCollection control, Point point)//添加按钮方法
        {
            _ = control.Owner.Name;//获取创建的窗口名称
            this.LedBulb_serial = Button_Name(control);
            LedBulb_reform reform = new LedBulb_reform();//实例化按钮
            reform.Size = new Size(36, 32);//设置大小
            reform.Location = point;//设置按钮位置
            reform.Name = LedBulb_serial;//设置名称
            reform.Text = LedBulb_serial;//设置文本
            reform.BringToFront();//将控件放置所有控件最顶层        
            return reform;//返回数据
        }
        public string Button_Name(System.Windows.Forms.Control.ControlCollection control)//判断名称是否存在该窗口
        {
            List<System.Windows.Forms.Control> Data = (from Control pi in control where pi is LedBulb_reform select pi).ToList();//获得名称            
            int dex = 0;//获得序列
        inedx:
            dex += 1;
            string Name = LedBulb_serial + (Data.Count + dex);//先定义名称
            foreach (LedBulb_reform i in Data)//遍历窗口是否有该名称存在
            {
                if (i.Name == Name) goto inedx;
            }
            return Name;//返回名称
        }
    }
}
