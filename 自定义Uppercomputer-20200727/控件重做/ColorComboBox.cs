using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义Uppercomputer_20200727.控件重做
{
    /// <summary>
    /// 颜色选择下拉菜单
    /// </summary>
    class ColorComboBox : ComboBox
    {
        /// <summary>
        /// 当前选中色
        /// </summary>
        public Color SelectedColor
        {
            get { return Color.FromName(this.Text); }
        }
        /// <summary>
        /// 构造函数，构造颜色下拉列表
        /// </summary>
        public ColorComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ItemHeight = 25;

            PropertyInfo[] propInfoList = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.Items.Add(c.Name);
            }
            this.Text = "Black"; //设置默认色
        }
        /// <summary>
        /// 重写OnDrawItem
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Rectangle rect = e.Bounds;

            if (e.Index >= 0)
            {
                string colorName = this.Items[e.Index].ToString();
                Color c = Color.FromName(colorName);
                using (Brush b = new SolidBrush(c)) //预留下拉项间距
                {
                    e.Graphics.FillRectangle(b, rect.X, rect.Y + 2, rect.Width, rect.Height - 4);
                }
            }
        }
    }
    }
