using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.表格控件__TO__PLC.表格控件__TO__SQL;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.基本控件
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/22 11:58:08 
    //  文件名：DADataGridView_PLCSQL 
    //  版本：V1.0.1  
    //  说明： 实现上位机底层控件 定时从PLC自定寄存器读取数据 保存到SQL数据库  -不再公共运行时
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现上位机底层控件 定时从PLC自定寄存器读取数据 保存到SQL数据库  -不再公共运行时
    /// </summary>
    [ToolboxItem(true)]
    [Browsable(true)]
    [Description("实现上位机底层控件 定时从PLC自定寄存器读取数据 保存到SQL数据库  -不再公共运行时")]
    public class DADataGridView_PLCSQL : DataGridView, TextBox_base, DataGridViewPLC_base
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
        [Description("是否启用PLC功能 启用前确认SQL字符串 表名是否正确 否则UI会卡死 报错"), Category("PLC类型")]
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
            get => Plc_address;
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (Button_PLC.Address(this.Plc,value[i]))
                        Plc_address[i] = value[i];
                    else
                        Plc_address[i] = "00";
                }
            }
        }
        string[] Plc_address = new string[10] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        public string[] DataGridView_Name { get; set; } = new string[10];
        [Description("表格列读取PLC的类型--对应表格列"), Category("PLC-控件参数")]
        public numerical_format[] DataGridView_numerical { get; set; } = new numerical_format[10];
        public bool DataGridViewPLC_Time { get; set; }
        [Description("SQL链接字符串--仅支持用户名 密码 登录不支持Win身份登录 字符串需要写明需要链接的数据库名 注意仅支持SQL Server"), Category("SQL-控件参数")]
        /// <summary>
        /// SQL链接字符串
        /// </summary>
        public string SqlString { get; set; } = @"data source=DESKTOP-955LB02\SQLEXPRESS;initial catalog=XN;persist security info=True;user id=sa;password=3131458;MultipleActiveResultSets=True;App=EntityFramework";
        [Description("需要链接的SQL表名"), Category("SQL-控件参数")]
        /// <summary>
        /// 需要链接的SQL表名
        /// </summary>
        public string SqlSurface_Name { get; set; } = "Table_1";
        [Description("是否启用SQL功能"), Category("SQL-控件参数")]
        public bool SQL_Enable
        {
            get => sql_Enable;
            set
            {
                sql_Enable = value;
            }
        }
        private bool sql_Enable = false;
        /// <summary>
        /// PLC通讯对象
        /// </summary>
        DataGridView_PLC pLC;
        #endregion
        #region SQL操作对象
        DADataGridView_SQL gridView_SQL;
        #endregion
        public DADataGridView_PLCSQL()
        {
            pLC = new DataGridView_PLC();

        }
        protected override void DefWndProc(ref Message m)
        {
            base.DefWndProc(ref m);
        }
        protected override void OnParentChanged(EventArgs e)//加载状态栏
        {
            //判断程序是否在进程中运行？
            if (!pLC.GetPidByProcess()) return;
            //添加控件参数
            if (!SQL_Enable) return;
            if (this.DataSource != null || this.IsDisposed || this.Created == false) return;
            this.BeginInvoke((EventHandler)delegate
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.@SqlString))
                {
                    try
                    {
                        sqlConnection.Open();
                        sqlConnection.Close();
                    }
                    catch
                    {
                        throw new Exception("链接SQL数据库错误--请检查链接字符串");
                    }
                }
                gridView_SQL = new DADataGridView_SQL(this.@SqlString, this.@SqlSurface_Name);
                gridView_SQL.skinDataGridView_update(this);

                //获取SQL数据正常再启动定时器
                PLC_time.Start();
                PLC_time.Tick += new EventHandler(Time_tick);
            });
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
            if (!plc_Enable || !sql_Enable || this.IsDisposed || this.Created == false) return;//用户不开启PLC功能
            lock (this)
            {
                List<string> Data = pLC.plc(this, this, this.Columns.Count);              
                if (Data.Count == (this.Columns.Count))
                {
                    DataTable dataTable = (DataTable)this.DataSource;//获取数据源
                    dataTable.Rows.Add(Data.ToArray());
                    this.DataSource = dataTable;
                }
                this.gridView_SQL.skinDataGridView_modification(this);
                this.gridView_SQL.skinDataGridView_update(this);
                this.FirstDisplayedScrollingRowIndex = this.Rows.Count - 1;
            }
        }
    }
}

