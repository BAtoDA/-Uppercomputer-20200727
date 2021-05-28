using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.Nlog;
using static 自定义Uppercomputer_20200727.AutoSizeFormClass;

namespace 自定义Uppercomputer_20200727
{
    /// <summary>
    /// 窗口大小改变 控件自动改变
    /// </summary>
    class AutoSizeFormClass
    {
        /// <summary>
        /// 声明结构 记录控件位置和大小
        /// </summary>
        public struct ControlRect
        {
            public string name;
            public float Left;
            public float Top;
            public float Width;
            public float Height;
            public float Size;
        }



        public List<ControlRect> _oldCtrl = new List<ControlRect>();
        private int _ctrlNo = 0;
        ControlRect decimals;
        public static float X, Y, Width, Height;//静态字段保存数据

        public void RenewControlRect(Control mForm)
        {
            //如果控件集合对象_oldCtrl不存在则将其添加，如果不添加首先无法找到主窗口
            //也就无法开始遍历
           //LogUtils日志
            //LogUtils.debugWrite( $"{mForm.TopLevelControl.ToString()??mForm.Name} 窗口大小改变 控件自动改变");

            _oldCtrl.Clear();
            ControlRect cR;
            cR.name = mForm.Name;
            cR.Left = mForm.Left;
            cR.Top = mForm.Top;
            cR.Width = mForm.Width;
            cR.Height = mForm.Height;
            cR.Size = mForm.Font.Size;
            _oldCtrl.Add(cR);

            AddControl(mForm);


            _ctrlNo = 1;
            _oldCtrl.Clear();
        }


        private void AddControl(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                ControlRect cR;
                cR.name = c.Name;
                cR.Left = c.Left;
                cR.Top = c.Top;
                cR.Width = c.Width;
                cR.Height = c.Height;
                cR.Size = c.Font.Size;
                _oldCtrl.Add(cR);
                // 控件可能嵌套子控件
                if (c.Controls.Count > 0)
                    AddControl(c);
            }
        }

        public void ControlAutoSize(Control mForm)
        {

            _ctrlNo = 1;
            /*计算宽度比率*/
            float wScale = (float)mForm.Width / _oldCtrl[0].Width;
            /*计算高度比率*/
            float hScale = (float)mForm.Height / _oldCtrl[0].Height;
            AutoScaleControl(mForm, wScale, hScale);
        }

        private void AutoScaleControl(Control mForm, float wScale, float hScale)
        {
            float ctrlLeft, ctrlTop, ctrlWidth, ctrlHeight;
            float ctrlFontSize, hSize, wSize;
            List<ControlRect> Ctrl = new List<ControlRect>();
            X = wScale;
            Width = wScale;
            Y = hScale;
            Height= hScale;
            foreach (Control c in mForm.Controls)
            {
                //在_oldCtrl 中查询出控件名称相同的控件，并返回对象
                ControlRect shortDigits = _oldCtrl.Where((p) => p.name == c.Name).ToList().FirstOrDefault();


                //获取左边框的长度
                ctrlLeft = shortDigits.Left;
                //获取上边框的长度
                ctrlTop = shortDigits.Top;
                //获取宽度
                ctrlWidth = shortDigits.Width;
                //获取高度
                ctrlHeight = shortDigits.Height;
                //获取字体大小
                ctrlFontSize = shortDigits.Size;

                //通过获取的比率相乘计算出要显示的x,y轴
                c.Left = (int)Math.Round((ctrlLeft * wScale));
                if (c.Left < 0)
                {
                    c.Left = 0;
                }
                c.Top = (int)Math.Round((ctrlTop * hScale));
                if (c.Top < 0)
                {
                    c.Top = 0;
                }
                //保存计算结果后的坐标和大小,当下次进行计算是使用该浮点型进行计算
                //确保控件不会错乱



                //设置高度和宽度
                c.Width = (int)Math.Round((ctrlWidth * wScale));
                c.Height = (int)Math.Round((ctrlHeight * hScale));

                //通过比率获取放大或缩小后的字体大小并进行设置
                wSize = ctrlFontSize * wScale;
                hSize = ctrlFontSize * hScale;
                if (hSize < 7)
                {
                    hSize = 7;
                }
                if (wSize < 7)
                {
                    wSize = 7;
                }
                // c.Font = new Font(c.Font.Name, Math.Min(hSize, wSize), c.Font.Style, c.Font.Unit);
                c.Font = new Font(c.Font.Name, c.Font.SizeInPoints* hScale, c.Font.Style, c.Font.Unit);

                _ctrlNo++;

                // 先缩放控件本身 再缩放子控件
                if (c.Controls.Count > 0)
                {
                    AutoScaleControl(c, wScale, hScale);
                }

                shortDigits.Top = ctrlTop * hScale;
                shortDigits.Left = ctrlTop * wScale;
                shortDigits.Width = ctrlTop * wScale;
                shortDigits.Height = ctrlTop * hScale;
                //Ctrl.Add(shortDigits);
            }

        }
    }

}

