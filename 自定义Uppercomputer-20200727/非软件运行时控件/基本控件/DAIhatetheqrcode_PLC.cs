using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLC通讯规范接口;
using 自定义Uppercomputer_20200727.文本输入键盘;
using 自定义Uppercomputer_20200727.非软件运行时控件.PLC参数设置界面;
using 自定义Uppercomputer_20200727.非软件运行时控件.二维码生成;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.按钮_TO_PLC方法;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.文本__TO__PLC方法;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.基本控件
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/22 15:58:49 
    //  文件名：DAIhatetheqrcode_PLC
    //  版本：V1.0.1  
    //  说明： 实现从PLC侧读取自定类型数据 产生二维码或者条形码
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现从PLC侧读取自定类型数据 产生二维码或者条形码
    /// </summary>
    [ToolboxItem(true)]
    [Browsable(true)]
    [Description("实现从PLC侧读取自定类型数据 产生二维码或者条形码")]
    public class DAIhatetheqrcode_PLC : PictureBox, TextBox_base
    {
        #region 实现接口参数
        public event EventHandler Modification;
        [Description("选择PLC类型\r\n默认三菱PLC"), Category("PLC类型")]
        [DefaultValue(typeof(PLC), "Mitsubishi")]
        public PLC Plc
        {
            get => pLC_valu;
            set
            {
                if (plc_Enable)
                {
                    this.Modification += new EventHandler(Modifications_Eeve);
                    this.Modification(Convert.ToInt32(pLC_valu), new EventArgs());
                    this.Modification -= new EventHandler(Modifications_Eeve);
                    return;
                }
                pLC_valu = value;
            }
        }
        private PLC pLC_valu;
        [Description("是否启用PLC功能"), Category("PLC类型")]
        public bool PLC_Enable
        {
            get => plc_Enable;
            set => plc_Enable = value;
        }
        private bool plc_Enable = false;

        public void Modifications_Eeve(object send, EventArgs e)
        {
            TextboxDForm1 buttonBitForm = new TextboxDForm1(Convert.ToInt32(send), PLC_Contact, PLC_Address);
            buttonBitForm.ShowDialog();
            if (buttonBitForm.PLC_parameter.Length < 1) return;
            pLC_valu = buttonBitForm.pLC;
            PLC_Contact = buttonBitForm.PLC_parameter[1];
            plc_Address = buttonBitForm.PLC_parameter[2];
        }
        [Description("PLC读取触点"), Category("PLC类型")]
        public string PLC_Contact
        {
            get => plc_Contact;
            set
            {
                if (value == null || !TextBox_PLC.IsNull(value, Plc))
                    throw new Exception("参数设置错误");
                plc_Contact = value;
            }
        }
        private string plc_Contact = "D";
        [Description("PLC访问地址"), Category("PLC类型")]
        public string PLC_Address
        {
            get => plc_Address;
            set
            {
                if (Button_PLC.Address(this.Plc,value))
                    plc_Address = value;
            }
        }
        private string plc_Address = "0";
        [Description("设置访问PLC的类型 包含显示数据的类型"), Category("PLC-控件参数")]
        [DefaultValue(typeof(numerical_format), "Signed_16_Bit")]
        public numerical_format numerical { get; set; } = numerical_format.Signed_16_Bit;
        [Description("设置访问PLC小数点以上几位"), Category("PLC-控件参数")]
        [DefaultValue(typeof(int), "8")]
        public int Decimal_Above { get; set; } = 8;
        [Description("设置访问PLC小数点以下几位"), Category("PLC-控件参数")]
        [DefaultValue(typeof(int), "0")]
        public int Decimal_Below { get; set; } = 0;
        public string Control_Text { get => this.Text; set => this.Text = value; }
        /// <summary>
        /// 定时刷新 定时器
        /// </summary>
        [Description("文本刷新定时器"), Category("PLC-控件参数")]
        [DefaultValue(typeof(string), "PLC_time")]
        public System.Windows.Forms.Timer PLC_time { get; } = new System.Windows.Forms.Timer() { Enabled = true, Interval = 200 };
        [Description("二维码生成类型 选择显示条形码还是二维码--默认二维码 false 二维码 true 条形码"), Category("PLC-控件参数")]
        /// <summary>
        /// 选择显示条形码还是二维码--默认二维码
        /// </summary>
        public bool select { get; set; } = false;

        /// <summary>
        /// PLC通讯对象
        /// </summary>
        TextBox_PLC pLC;
        IhatetheqrcodeCreate ihatetheqrcode;
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public DAIhatetheqrcode_PLC()
        {
            ihatetheqrcode = new IhatetheqrcodeCreate();
            pLC = new TextBox_PLC();
            PLC_time.Start();
            PLC_time.Tick += new EventHandler(Time_tick);
            this.Text = "123456789";
        }
        /// <summary>
        /// 定时器到达事件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_tick(object send, EventArgs e)
        {
            lock (this)
            {
                pLC.Refresh(this);
                this.Refresh_Data(Control_Text);
            }
        }
        /// <summary>
        /// 刷新图片--目前不实现带Logo
        /// </summary>
        public void Refresh_Data(string Data)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;//显示方式铺满
            //小于一定字符数量--显示默认数据
            if (Data.Length < 2)
                Data = "123456789";
            //判断用户选择显示的类型
            if (this.select != true)
                this.BackgroundImage = ihatetheqrcode.Generate1(Data,this.Size.Width, this.Size.Height);//加载二维码
            else
                this.BackgroundImage = ihatetheqrcode.Generate2(Data, this.Size.Width, this.Size.Height);//加载条形码
        }
    }
}
