﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.控件重做.工业图形控件;

namespace 自定义Uppercomputer_20200727.控制主页面模板.工业图形ADD
{
    /// <summary>
    /// 添加Conveyor运输带
    /// </summary>
    class Conveyor_Add
    {
        string Button_serial = "Conveyor_reform";//默认名称
        public Conveyor_reform Add(System.Windows.Forms.Control.ControlCollection control, Point point)//添加按钮方法
        {
            _ = control.Owner.Name;//获取创建的窗口名称
            this.Button_serial = Button_Name(control);//获得名称
            Conveyor_reform reform = new Conveyor_reform();//实例化按钮
            reform.Size = new Size(300, 105);//设置大小
            reform.Location = point;//设置按钮位置
            reform.Name = Button_serial;//设置名称
            reform.Text = Button_serial;//设置文本
            reform.ConveyorColor = Color.FromName("DimGray");
            reform.ConveyorDirection = HZH_Controls.Controls.ConveyorDirection.Backward;
            reform.ConveyorHeight = 10;
            reform.ConveyorSpeed = 100;
            reform.Inclination =90;
            reform.ForeColor = Color.FromName("ControlText");//获取数据库中颜色名称进行设置
            reform.BackColor = Color.FromName("Transparent");
            reform.BackgroundImageLayout = ImageLayout.Tile;
            reform.BringToFront();//将控件放置所有控件最顶层        
            return reform;//返回数据
        }
        public string Button_Name(System.Windows.Forms.Control.ControlCollection control)//判断名称是否存在该窗口
        {
            List<System.Windows.Forms.Control> Data = (from Control pi in control where pi is Conveyor_reform select pi).ToList();//获得名称            
            int dex = 0;//获得序列
        inedx:
            dex += 1;
            string Name = Button_serial + (Data.Count + dex);//先定义名称
            foreach (Conveyor_reform i in Data)//遍历窗口是否有该名称存在
            {
                if (i.Name == Name) goto inedx;
            }
            return Name;//返回名称
        }
    }
}
