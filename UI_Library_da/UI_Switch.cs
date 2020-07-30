using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace UI_Library_da
{
    /// <summary>
    /// <引用第三方开源控件重构>
    /// <切换开关>
    ///  * SunnyUI 开源控件库、工具类库、扩展类库、多页面开发框架。
    /// </summary>
    [DefaultEvent("ValueChanged")]
        [DefaultProperty("ActiveValue")]
        [ToolboxItem(true)]
        public  class UI_Switch : Sunny.UI.UIControl
    {
            public delegate void OnValueChanged(object sender, bool value);

            public UI_Switch()
            {
                Height = 29;
                Width = 75;
                ShowText = false;
                ShowRect = false;
                foreColor = Color.White;
                inActiveColor = Color.Silver;
                fillColor = Color.White;
            }

            public event OnValueChanged ValueChanged;

            /// <summary>
            /// 字体颜色
            /// </summary>
            [Description("字体颜色"), Category("自定义")]
            [DefaultValue(typeof(Color), "White")]
            public override Color ForeColor
            {
                get => foreColor;
                set => SetForeColor(value);
            }

            private bool activeValue;

            [DefaultValue(false)]
            public bool Active
            {
                get => activeValue;
                set
                {
                    activeValue = value;
                    ValueChanged?.Invoke(this, value);
                    Invalidate();
                }
            }

            private string activeText = "开";

            [DefaultValue("开")]
            public string ActiveText
            {
                get => activeText;
                set
                {
                    activeText = value;
                    Invalidate();
                }
            }

            private string inActiveText = "关";

            [DefaultValue("关")]
            public string InActiveText
            {
                get => inActiveText;
                set
                {
                    inActiveText = value;
                    Invalidate();
                }
            }

            private Color inActiveColor;

            [DefaultValue(typeof(Color), "Silver")]
            public Color InActiveColor
            {
                get => inActiveColor;
                set
                {
                    inActiveColor = value;
                    Invalidate();
                }
            }

            /// <summary>
            /// 填充颜色，当值为背景色或透明色或空值则不填充
            /// </summary>
            [Description("填充颜色"), Category("自定义")]
            [DefaultValue(typeof(Color), "White")]
            public Color ButtonColor
            {
                get => fillColor;
                set => SetFillColor(value);
            }

            /// <summary>
            /// 边框颜色
            /// </summary>
            [Description("选中颜色"), Category("自定义")]
            [DefaultValue(typeof(Color), "80, 160, 255")]
            public Color ActiveColor
            {
                get => rectColor;
                set => SetRectColor(value);
            }

            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                Active = !Active;
            }

            public override void SetStyleColor(UIBaseStyle uiColor)
            {
                base.SetStyleColor(uiColor);
                if (uiColor.IsCustom()) return;

                rectColor = uiColor.SwitchActiveColor;
                fillColor = uiColor.SwitchFillColor;
                inActiveColor = uiColor.SwitchInActiveColor;
                Invalidate();
            }

            protected override void OnPaintFill(Graphics g, GraphicsPath path)
            {
                Width = (int)(Height * 2.6);
                Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
                g.FillRoundRectangle(Active ? ActiveColor : InActiveColor, rect, rect.Height);

                int width = Width - 3 - 1 - 3 - (rect.Height - 6);
                if (!Active)
                {
                    g.FillEllipse(fillColor.IsValid() ? fillColor : Color.White, 3, 3, rect.Height - 6, rect.Height - 6);
                    SizeF sf = g.MeasureString(InActiveText, Font);
                    g.DrawString(InActiveText, Font, fillColor.IsValid() ? fillColor : Color.White, 3 + rect.Height - 6 + (width - sf.Width) / 2, 3 + (rect.Height - 6 - sf.Height) / 2);
                }
                else
                {
                    g.FillEllipse(fillColor.IsValid() ? fillColor : Color.White, Width - 3 - 1 - (rect.Height - 6), 3, rect.Height - 6, rect.Height - 6);
                    SizeF sf = g.MeasureString(ActiveText, Font);
                    g.DrawString(ActiveText, Font, fillColor.IsValid() ? fillColor : Color.White, 3 + (width - sf.Width) / 2, 3 + (rect.Height - 6 - sf.Height) / 2);
                }
            }
        }    
}
