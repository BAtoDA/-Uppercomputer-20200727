using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace UI_Library_da
{
    /// <summary>
    /// 继承PictureBox进行 生成二维码/条形码-与显示
    /// </summary>
    public class UI_ihatetheqrcode: PictureBox
    {
        /// <summary>
        /// 显示内容
        /// </summary>
        public string Data { get; set; } = "123456789";

        /// <summary>
        /// 选择显示条形码还是二维码--默认二维码
        /// </summary>
        public bool select { get; set; } = false;
        /// <summary>
        /// 二维码/条形码--长度--高度
        /// </summary>
        public Size ihatetheqrcode_Size { get; set; } = new Size(143, 118);

        /// <summary>
        /// 构造函数
        /// </summary>
        public UI_ihatetheqrcode()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;//铺满
            this.BackgroundImage = Generate1(Data, this.Width, this.Height);//生成二维码
        }
        /// <summary>
        /// 刷新图片--目前不实现带Logo
        /// </summary>
        public void Refresh_Data()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;//显示方式铺满
            //小于一定字符数量--显示默认数据
            if (Data.Length < 2)
                Data = "123456789";
            //判断用户选择显示的类型
            if (this.select != true)
                this.BackgroundImage = this.Generate1(Data, ihatetheqrcode_Size.Width, ihatetheqrcode_Size.Height);//加载二维码
            else
                this.BackgroundImage = this.Generate2(Data, ihatetheqrcode_Size.Width, ihatetheqrcode_Size.Height);//加载条形码
        }
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public Bitmap Generate1(string text, int width, int height)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions()
            {
                DisableECI = true,//设置内容编码
                CharacterSet = "UTF-8",  //设置二维码的宽度和高度
                Width = width,
                Height = height,
                Margin = 1//设置二维码的边距,单位不是固定像素
            };

            writer.Options = options;
            Bitmap map = writer.Write(text ?? "123456789");
            return map;
        }

        /// <summary>
        /// 生成一维条形码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public Bitmap Generate2(string text, int width, int height)
        {
            BarcodeWriter writer = new BarcodeWriter();
            //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
            //如果想生成可识别的可以使用 CODE_128 格式
            //writer.Format = BarcodeFormat.ITF;
            writer.Format = BarcodeFormat.CODE_39;
            EncodingOptions options = new EncodingOptions()
            {
                Width = width,
                Height = height,
                Margin = 2
            };
            writer.Options = options;
            Bitmap map = writer.Write(text ?? "123456789");
            return map;
        }

        /// <summary>
        /// 生成带Logo的二维码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public Bitmap Generate3(string text, int width, int height)
        {
            //Logo 图片
            string logoPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\img\logo.png";
            Bitmap logo = new Bitmap(logoPath);
            //构造二维码写码器
            MultiFormatWriter writer = new MultiFormatWriter();
            Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
            hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            //hint.Add(EncodeHintType.MARGIN, 2);//旧版本不起作用，需要手动去除白边

            //生成二维码 
            BitMatrix bm = writer.encode(text, BarcodeFormat.QR_CODE, width + 30, height + 30, hint);
            bm = deleteWhite(bm);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap map = barcodeWriter.Write(bm);

            //获取二维码实际尺寸（去掉二维码两边空白后的实际尺寸）
            int[] rectangle = bm.getEnclosingRectangle();

            //计算插入图片的大小和位置
            int middleW = Math.Min((int)(rectangle[2] / 3), logo.Width);
            int middleH = Math.Min((int)(rectangle[3] / 3), logo.Height);
            int middleL = (map.Width - middleW) / 2;
            int middleT = (map.Height - middleH) / 2;

            Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(map, 0, 0, width, height);
                //白底将二维码插入图片
                g.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
                g.DrawImage(logo, middleL, middleT, middleW, middleH);
            }
            return bmpimg;
        }

        /// <summary>
        /// 删除默认对应的空白
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private BitMatrix deleteWhite(BitMatrix matrix)
        {
            int[] rec = matrix.getEnclosingRectangle();
            int resWidth = rec[2] + 1;
            int resHeight = rec[3] + 1;

            BitMatrix resMatrix = new BitMatrix(resWidth, resHeight);
            resMatrix.clear();
            for (int i = 0; i < resWidth; i++)
            {
                for (int j = 0; j < resHeight; j++)
                {
                    if (matrix[i + rec[0], j + rec[1]])
                        resMatrix[i, j] = true;
                }
            }
            return resMatrix;
        }
    }
}
