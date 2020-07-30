using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Library_da
{
    /// <summary>
    /// 继承uiRadioButton1实现--单选按钮
    /// </summary>
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("Text")]
    [ToolboxItem(true)]
    public class UI_RadioButton : UIControl
    {
        public delegate void OnValueChanged(object sender, bool value);

        public event OnValueChanged ValueChanged;

        public UI_RadioButton()
        {
            Cursor = Cursors.Hand;
            ShowRect = false;
            Size = new Size(150, 29);
            foreColor = UIStyles.Blue.CheckBoxForeColor;
            fillColor = UIStyles.Blue.CheckBoxColor;
        }

        [DefaultValue(false)]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// 字体颜色
        /// </summary>
        [Description("字体颜色"), Category("自定义")]
        [DefaultValue(typeof(Color), "48, 48, 48")]
        public override Color ForeColor
        {
            get => foreColor;
            set => SetForeColor(value);
        }

        private int _imageSize = 16;
        private int _imageInterval = 3;

        [DefaultValue(16)]
        public int ImageSize
        {
            get => _imageSize;
            set
            {
                _imageSize = Math.Max(value, 16);
                _imageSize = Math.Min(value, 64);
                Invalidate();
            }
        }

        [DefaultValue(3)]
        public int ImageInterval
        {
            get => _imageInterval;
            set
            {
                _imageInterval = Math.Max(1, value);
                Invalidate();
            }
        }

        private bool _checked;

        [DefaultValue(false)]
        public bool Checked
        {
            get => _checked;
            set
            {
                _checked = value;

                if (value)
                {
                    try
                    {
                        if (Parent == null) return;
                        List<UI_RadioButton> buttons = Parent.GetControls<UI_RadioButton>();
                        foreach (var box in buttons)
                        {
                            if (box == this) continue;
                            if (box.GroupIndex != GroupIndex) continue;
                            if (box.Checked) box.Checked = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(@"UIRadioBox click error." + ex.Message);
                    }
                }

                ValueChanged?.Invoke(this, _checked);
                Invalidate();
            }
        }

        protected override void OnPaintFore(Graphics g, GraphicsPath path)
        {
            //设置按钮标题位置
            Padding = new Padding(_imageSize + _imageInterval * 2, Padding.Top, Padding.Right, Padding.Bottom);

            //填充文字
            Color color = ForeColor;
            color = Enabled ? color : UIDisableColor.Fore;

            g.DrawString(Text, Font, color, Size, Padding, ContentAlignment.MiddleLeft);
        }

        protected override void OnPaintFill(Graphics g, GraphicsPath path)
        {
            //图标
            float top = Padding.Top - 1 + (Height - Padding.Top - Padding.Bottom - ImageSize) / 2.0f;
            float left = Text.IsValid() ? ImageInterval : (Width - ImageSize) / 2.0f;

            Color color = Enabled ? fillColor : foreDisableColor;
            if (Checked)
            {
                g.FillEllipse(color, left, top, ImageSize, ImageSize);
                float pointSize = ImageSize - 4;
                g.FillEllipse(BackColor.IsValid() ? BackColor : Color.White,
                    left + ImageSize / 2.0f - pointSize / 2.0f,
                    top + ImageSize / 2.0f - pointSize / 2.0f,
                    pointSize, pointSize);

                pointSize = ImageSize - 8;
                g.FillEllipse(color,
                    left + ImageSize / 2.0f - pointSize / 2.0f,
                    top + ImageSize / 2.0f - pointSize / 2.0f,
                    pointSize, pointSize);
            }
            else
            {
                using (Pen pn = new Pen(color, 2))
                {
                    g.SetHighQuality();
                    g.DrawEllipse(pn, left + 1, top + 1, ImageSize - 2, ImageSize - 2);
                    g.SetDefaultQuality();
                }
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            //if (this.Checked) this.Checked = false; else this.Checked = true;
            if (!ReadOnly)
            {
                Checked = true;
            }
            base.OnClick(e);
        }

        public override void SetStyleColor(UIBaseStyle uiColor)
        {
            base.SetStyleColor(uiColor);
            if (uiColor.IsCustom()) return;

            fillColor = uiColor.CheckBoxColor;
            foreColor = uiColor.CheckBoxForeColor;
            Invalidate();
        }

        [DefaultValue(0)]
        public int GroupIndex { get; set; }

        /// <summary>
        /// 填充颜色，当值为背景色或透明色或空值则不填充
        /// </summary>
        [Description("填充颜色"), Category("自定义")]
        [DefaultValue(typeof(Color), "80, 160, 255")]
        public Color RadioButtonColor
        {
            get => fillColor;
            set => SetFillColor(value);
        }
    }
}
