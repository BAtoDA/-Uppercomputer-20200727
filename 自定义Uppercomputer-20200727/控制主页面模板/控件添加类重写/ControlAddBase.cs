using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 自定义Uppercomputer_20200727.控制主页面模板.控件添加类重写
{
    /// <summary>
    /// 用于处理添加控件时
    /// </summary>
    class ControlAddBase
    {
        string serial = " ";//默认名称
        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="control">承载控件的集合</param>
        /// <param name="point">添加控件的位置</param>
        /// <returns></returns>
        public T Add<T>(Control.ControlCollection control, Point point)where T:new()
        {
            _ = control.Owner.Name;//获取创建的窗口名称
            this.serial = typeof(T).Name;
            this.serial = ObtainName<T>(control);//获得名称

            dynamic reform = new T();//实例化按钮
            reform.Location = point;//设置按钮位置
            reform.Name = this.serial;//设置名称
            reform.Text = this.serial;//设置文本
            reform.BringToFront();//将控件放置所有控件最顶层        
            return (T)reform;//返回数据
        }
        public string ObtainName<T>(System.Windows.Forms.Control.ControlCollection control)//判断名称是否存在该窗口
        {
            List<System.Windows.Forms.Control> Data = (from Control pi in control where pi is T select pi).ToList();//获得名称            
            int dex = 0;//获得序列
        inedx:
            dex += 1;
            string Name = this.serial + (Data.Count + dex);//先定义名称
            foreach (Control i in Data)//遍历窗口是否有该名称存在
            {
                if (i.Name == Name) goto inedx;
            }
            return Name;//返回名称
        }
    }
}
