using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinControl;
using PLC通讯规范接口;
using 自定义Uppercomputer_20200727.非软件运行时控件.PLC参数设置界面;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.按钮_TO_PLC方法;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.文本__TO__PLC方法;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.表格控件__TO__PLC;

namespace 自定义Uppercomputer_20200727.非软件运行时控件
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/20 16:44:59 
    //  文件名：DADataGridView_TO_PLC 
    //  版本：V1.0.1  
    //  说明： 实现上位机底层控件 定时从PLC自定寄存器读取数据  PLC读取表格类 -不再公共运行时
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现上位机底层控件 文本类 -不再公共运行时
    /// </summary>
    [ToolboxItem(true)]
    [Browsable(true)]
    [Description("实现上位机底层控件 定时从PLC自定寄存器读取数据  PLC读取表格类 -不再公共运行时")]
    public class DADataGridView_TO_PLC: SkinDataGridView, TextBox_base, DataGridViewPLC_base
    {
        #region 实现接口参数
        [Browsable(false)]
        public event EventHandler Modification;

        [Description("选择PLC类型\r\n默认三菱PLC"), Category("PLC类型")]
        [DefaultValue(typeof(PLC), "Mitsubishi")]
        public PLC Plc
        {
            get => pLC_valu;
            set
            {
                if (plc_Enable&& new DataGridView_PLC().GetPidByProcess()!=true)
                {
                    this.Modification += new EventHandler(Modifications_Eeve);
                    this.Modification(Convert.ToInt32(pLC_valu), new EventArgs());
                    this.Modification -= new EventHandler(Modifications_Eeve);
                    return;
                }
                pLC_valu = value;
                
            }
        }
        private bool plc_Enable = true;
        [Description("是否启用PLC功能"), Category("PLC类型")]
        public bool PLC_Enable
        {
            get => plc_Enable;
            set => plc_Enable = value;
        }
        private PLC pLC_valu;
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
        public  string PLC_Contact
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
        [Browsable(false)]
        public string PLC_Address
        {
            get => string_Bases[0];
            set
            {
                if (Button_PLC.Address(this.Plc,value))
                    plc_Address = value;
            }
        }
        private string plc_Address = "0";
        [Browsable(false)]
        public numerical_format numerical { get; set; } = numerical_format.Signed_16_Bit;
        [DefaultValue(typeof(int), "8")]
        public int Decimal_Above { get; set; } = 8;
        [DefaultValue(typeof(int), "0")]
        public int Decimal_Below { get; set; } = 0;
        public string Control_Text { get => this.Text; set => this.Text = value; }
        /// <summary>
        /// 定时刷新 定时器
        /// </summary>
        [Description("文本刷新定时器"), Category("PLC-控件参数")]
        [DefaultValue(typeof(string), "PLC_time")]
        public System.Windows.Forms.Timer PLC_time { get; } = new System.Windows.Forms.Timer() { Enabled = true, Interval = 500 };
        [Description("读取PLC的地址--对应表格列"), Category("PLC-控件参数")]
        public string[] PLC_address
        {
            get => string_Bases;
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (Button_PLC.Address(this.Plc,value[i]))
                        string_Bases[i] = value[i];
                    else
                        string_Bases[i] = "00";
                }
            }
        }
        private  string[] string_Bases = new string[] {"0","0" , "0" , "0" , "0" , "0" , "0" , "0" , "0" , "0" };
        [Description("表格列显示的名称--对应表格列"), Category("PLC-控件参数")]
        public string[] DataGridView_Name { get; set; } = new string[10];
        [Description("表格列读取PLC的类型--对应表格列"), Category("PLC-控件参数")]
        public numerical_format[] DataGridView_numerical { get; set; } = new numerical_format[] {numerical_format.Signed_16_Bit, numerical_format.Signed_16_Bit , numerical_format.Signed_16_Bit , numerical_format.Signed_16_Bit , numerical_format.Signed_16_Bit , numerical_format.Signed_16_Bit , numerical_format.Signed_16_Bit , numerical_format.Signed_16_Bit , numerical_format.Signed_16_Bit , numerical_format.Signed_16_Bit };
        [Description("指示着是否显示读取时间列"), Category("PLC-控件参数")]
        public bool DataGridViewPLC_Time { get; set; } = true;

        /// <summary>
        /// PLC通讯对象
        /// </summary>
        DataGridView_PLC pLC;
        #endregion
        public DADataGridView_TO_PLC()
        {
            pLC = new DataGridView_PLC();
            load();

        }
        private void load()
        {
     
        }
        protected override void OnParentChanged(EventArgs e)//加载状态栏
        {
            //添加控件参数
            this.Columns.Clear();
            for (int i = 0; i < this.DataGridView_Name.Length; i++)
            {
                DataGridViewTextBoxColumn TextBoxColumn = new DataGridViewTextBoxColumn();
                TextBoxColumn.HeaderText = this.DataGridView_Name[i];
                TextBoxColumn.ToolTipText = this.DataGridView_Name[i];
                TextBoxColumn.Width = this.CreateGraphics().MeasureString(this.DataGridView_Name[i], this.Font).Width > TextBoxColumn.Width ? Convert.ToInt32(this.CreateGraphics().MeasureString(this.DataGridView_Name[i], this.Font).Width + 20) : TextBoxColumn.Width;
                this.Columns.Add(TextBoxColumn);
            }
            if (this.DataGridViewPLC_Time)
            {
                DataGridViewTextBoxColumn TextBoxTime = new DataGridViewTextBoxColumn();
                TextBoxTime.HeaderText = "读取PLC时间";
                TextBoxTime.ToolTipText = "读取PLC时间";
                TextBoxTime.Width = 120;
                this.Columns.Add(TextBoxTime);
            }
            //自动改变控件大小
            int Siz = 0;
            for (int i = 0; i < this.ColumnCount; i++)
            {
                Siz += this.Columns[i].Width;
            }
            this.Size = new Size(Siz + 60, this.Size.Height);
            //判断程序是否在进程中运行？
            if (!pLC.GetPidByProcess()) return;
            PLC_time.Start();
            PLC_time.Tick += new EventHandler(Time_tick);

        }
        protected override void Dispose(bool disposing)//释放托管资源
        {
            base.Dispose(disposing);
            this.PLC_time.Dispose();
        }
        /// <summary>
        /// 定时器到达事件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void Time_tick(object send, EventArgs e)
        {
            if (!plc_Enable|| (this.DataGridViewPLC_Time==false & this.Columns.Count<1)||(this.DataGridViewPLC_Time& this.Columns.Count<2)) return;//用户不开启PLC功能
            if (this.IsDisposed || this.Created == false) return;
            lock (this)
            {
                this.BeginInvoke((EventHandler)delegate
                {
                    List<string> Data = pLC.plc(this, this, this.DataGridViewPLC_Time ? this.Columns.Count - 1 : this.Columns.Count);
                    if (Data.Count == (this.DataGridViewPLC_Time ? this.Columns.Count - 1 : this.Columns.Count))
                    {
                        int index = this.Rows.Add();
                        for (int i = 0; i < Data.Count; i++)
                        {
                            this.Rows[index].Cells[i].Value = Data[i];
                        }
                        if (this.DataGridViewPLC_Time)
                            this.Rows[index].Cells[this.Rows[index].Cells.Count - 1].Value = DateTime.Now.ToString();
                    }
                    this.FirstDisplayedScrollingRowIndex = this.Rows.Count - 1;
                });
            }
        }

    }
    [Serializable]
    public class String_base
    {
        public string Plc_Address { get; set; }
    }
}
