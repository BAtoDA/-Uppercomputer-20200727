﻿using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_Library_da
{
    /// <summary>
    /// <引用第三方开源控件重构>
    /// <无图片按钮>
    ///  * SunnyUI 开源控件库、工具类库、扩展类库、多页面开发框架。
    /// </summary>
    public class UI_ImageButton : PictureBox
    {
        private bool IsPress;
        private bool IsHover;

        private Image imageDisabled;
        private Image imagePress;
        private Image imageHover;
        private Image imageSelected;
        private bool selected;
        private string text;
        private ContentAlignment textAlign = ContentAlignment.MiddleCenter;
        private Color foreColor = UIFontColor.Primary;

        [Category("外观")]
        [Description("按钮文字")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => text;
            set
            {
                if (text != value)
                {
                    text = value;
                    Invalidate();
                }
            }
        }

        [DefaultValue(ContentAlignment.MiddleCenter)]
        public ContentAlignment TextAlign
        {
            get => textAlign;
            set
            {
                textAlign = value;
                Invalidate();
            }
        }

        [Category("外观")]
        [Description("文字字体")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        [Category("外观")]
        [Description("文字颜色")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Color), "48, 48, 48")]
        public override Color ForeColor
        {
            get => foreColor;
            set
            {
                foreColor = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DefaultValue(typeof(Image), "null")]
        public new Image InitialImage { get; set; }

        [Browsable(false)]
        [DefaultValue(typeof(Image), "null")]
        public new Image ErrorImage { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UI_ImageButton()
        {
            SetDefaultControlStyles();
            SuspendLayout();
            BorderStyle = BorderStyle.None;
            ResumeLayout(false);
            Width = 100;
            Height = 35;
            Version = UIGlobal.Version;
            Cursor = Cursors.Hand;
            base.Font = UIFontColor.Font;
        }

        public string Version { get; }

        /// <summary>
        /// 鼠标移上图片
        /// </summary>
        [DefaultValue(typeof(Image), "null")]
        public Image ImageHover
        {
            get => imageHover;

            set
            {
                imageHover = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 鼠标按下图片
        /// </summary>
        [DefaultValue(typeof(Image), "null")]
        public Image ImagePress
        {
            get => imagePress;

            set
            {
                imagePress = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 不可用时图片
        /// </summary>
        [DefaultValue(typeof(Image), "null")]
        public Image ImageDisabled
        {
            get => imageDisabled;
            set
            {
                imageDisabled = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 不可用时图片
        /// </summary>
        [DefaultValue(typeof(Image), "null")]
        public Image ImageSelected
        {
            get => imageSelected;
            set
            {
                imageSelected = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 是否选中
        /// </summary>
        [DefaultValue(typeof(bool), "false")]
        public bool Selected
        {
            get => selected;

            set
            {
                if (selected != value)
                {
                    selected = value;
                    Invalidate();
                }
            }
        }

        private void SetDefaultControlStyles()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            UpdateStyles();
        }

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            IsPress = true;
            Invalidate();
        }

        /// <summary>
        /// 鼠标弹起
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            IsPress = false;
            Invalidate();
        }

        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (!DesignMode)
            {
                Cursor = Cursors.Hand;
            }

            IsHover = true;
            Invalidate();
        }

        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            IsHover = false;
            IsPress = false;
            Invalidate();
        }

        public Point imageOffset;

        [DefaultValue(typeof(Point), "0, 0")]
        public Point ImageOffset
        {
            get => imageOffset;
            set
            {
                imageOffset = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 绘制按钮
        /// </summary>
        /// <param name="pe">pe</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            Image img = Image;

            if (!Enabled)
            {
                img = imageDisabled;
            }
            else
            {
                if (IsPress)
                {
                    img = imagePress;
                }
                else if (IsHover)
                {
                    img = imageHover;
                }

                if (Selected)
                {
                    img = imageSelected;
                }
            }

            if (img == null)
            {
                img = Image;
            }

            if (img != null)
            {
                if (SizeMode == PictureBoxSizeMode.Normal)
                    pe.Graphics.DrawImage(img, new Rectangle(ImageOffset.X, ImageOffset.Y, img.Width, img.Height));

                if (SizeMode == PictureBoxSizeMode.StretchImage)
                    pe.Graphics.DrawImage(img, new Rectangle(0, 0, Width, Height));

                if (SizeMode == PictureBoxSizeMode.AutoSize)
                {
                    Width = img.Width;
                    Height = img.Height;
                    pe.Graphics.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
                }

                if (SizeMode == PictureBoxSizeMode.Zoom)
                    pe.Graphics.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));

                if (SizeMode == PictureBoxSizeMode.CenterImage)
                    pe.Graphics.DrawImage(img, new Rectangle((Width - img.Width) / 2, (Height - img.Height) / 2, img.Width, img.Height));
            }
            else
            {
                base.OnPaint(pe);
            }

            SizeF sf = pe.Graphics.MeasureString(Text, Font);
            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                    pe.Graphics.DrawString(text, Font, ForeColor, Padding.Left, Padding.Top);
                    break;

                case ContentAlignment.TopCenter:
                    pe.Graphics.DrawString(text, Font, ForeColor, (Width - sf.Width) / 2, Padding.Top);
                    break;

                case ContentAlignment.TopRight:
                    pe.Graphics.DrawString(text, Font, ForeColor, Width - Padding.Right - sf.Width, Padding.Top);
                    break;

                case ContentAlignment.MiddleLeft:
                    pe.Graphics.DrawString(text, Font, ForeColor, Padding.Left, (Height - sf.Height) / 2);
                    break;

                case ContentAlignment.MiddleCenter:
                    pe.Graphics.DrawString(text, Font, ForeColor, (Width - sf.Width) / 2, (Height - sf.Height) / 2);
                    break;

                case ContentAlignment.MiddleRight:
                    pe.Graphics.DrawString(text, Font, ForeColor, Width - Padding.Right - sf.Width, (Height - sf.Height) / 2);
                    break;

                case ContentAlignment.BottomLeft:
                    pe.Graphics.DrawString(text, Font, ForeColor, Padding.Left, Height - Padding.Bottom - sf.Height);
                    break;

                case ContentAlignment.BottomCenter:
                    pe.Graphics.DrawString(text, Font, ForeColor, (Width - sf.Width) / 2, Height - Padding.Bottom - sf.Height);
                    break;

                case ContentAlignment.BottomRight:
                    pe.Graphics.DrawString(text, Font, ForeColor, Width - Padding.Right - sf.Width, Height - Padding.Bottom - sf.Height);
                    break;
            }
        }
    }
}
