using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZH_Controls.Controls;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.文本__TO__PLC方法;
using PLC通讯规范接口;
using 自定义Uppercomputer_20200727.非软件运行时控件.PLC参数设置界面;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.按钮_TO_PLC方法;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.基本控件
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/19 8:46:43 
    //  文件名：DACombox 
    //  版本：V1.0.1  
    //  说明： 实现上位机底层控件 下拉菜单类 -不再公共运行时
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现上位机底层控件 下拉菜单类 -不再公共运行时
    /// </summary>
    [ToolboxItem(true)]
    [Browsable(true)]
    [Description("实现上位机底层控件 下拉菜单类 不再公共运行时 ")]
    public class DACombox: UCCombox, TextBox_base, Combox_base
    {
        #region 实现接口参数
        public event EventHandler Modification;
        public event EventHandler Combox_Modification;
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
        public string Control_Text 
        {
            get
            {
                if (this.Source !=null)
                    return KeyValuePair[ this.Source.Count>0? this.SelectedIndex:0].ToString();
                else
                   return this.TextValue??"00";
            }
            set
            {
                if (this.Source != null)
                {
                    for (int i = 0; i < this.Source.Count; i++)
                    {
                        if (this.Source[i].Key == value)
                            this.SelectedIndex = i;
                    }
                }
            }
        }
        /// <summary>
        /// 定时刷新 定时器
        /// </summary>
        [Description("文本刷新定时器"), Category("PLC-控件参数")]
        [DefaultValue(typeof(string), "PLC_time")]
        public System.Windows.Forms.Timer PLC_time { get; } = new System.Windows.Forms.Timer() { Enabled = true, Interval = 200 };
        [Description("下拉菜单Key值 指示着需要写入PLC的值"), Category("PLC-控件参数")]
        public int[] KeyValuePair { get; set; } = new int[10];
        [Description("下拉菜单Value值 指示着用户选中的值"), Category("PLC-控件参数")]
        public string[] ValuePair { get; set; } = new string[10];
        public void Combox_Modifications_Eeve(object send, EventArgs e)
        {
            ComboxForm1 buttonBitForm = new ComboxForm1(this.KeyValuePair??new int[] {1 },this.ValuePair??new string[] { "PLC1"});
            buttonBitForm.ShowDialog();
            this.Combox_Modification -= Combox_Modifications_Eeve;
            if (buttonBitForm.keydata.Length<0) return;
        }
        /// <summary>
        /// PLC通讯对象
        /// </summary>
        TextBox_PLC pLC;
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public DACombox()
        {
            pLC = new TextBox_PLC();
            PLC_time.Start();
            PLC_time.Tick += new EventHandler(Time_tick);
        }
        protected void DACombox_SelectedChangedEvent(object sender, EventArgs e)//如果用户改变索引 把当前值写入PLC中
        {
            this.pLC.plc(this);
        }
        protected override void OnLoad(EventArgs e)
        {
            List<KeyValuePair<string, string>> valuePairs = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < KeyValuePair.Length; i++)
            {
                if (ValuePair[i] != null)
                    valuePairs.Add(new KeyValuePair<string, string>(this.KeyValuePair[i].ToString(), this.ValuePair[i]));
            }
            this.Source = valuePairs;
            if(this.Source.Count>1)
            {
                this.SelectedIndex = 0;
                this.TextValue = this.Source[0].Value;
            }
            this.SelectedChangedEvent += new EventHandler(DACombox_SelectedChangedEvent);
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
            }
        }
        protected override void Dispose(bool disposing)//重写释放托管资源
        {
            this.PLC_time.Dispose();
            base.Dispose(disposing);
        }
    }
}
