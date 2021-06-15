using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinControl;
using 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.表格控件__TO__PLC.表格控件__TO__SQL;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.基本控件
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/26 8:48:31 
    //  文件名：DADataGridView_TO_SQL 
    //  版本：V1.0.1  
    //  说明： 实现上位机底层控件 表格控件从SQL进行增删改查操作
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现上位机底层控件 表格控件从SQL进行增删改查操作
    /// </summary>
    [ToolboxItem(true)]
    [Browsable(true)]
    [Description("实现上位机底层控件 表格控件从SQL进行增删改查操作")]
    public class DADataGridView_TO_SQL : SkinDataGridView
    {
        #region
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
        #endregion
        #region SQL操作对象
        DADataGridView_SQL gridView_SQL;
        #endregion
        public DADataGridView_TO_SQL()
        {
            gridView_SQL = new DADataGridView_SQL(this.SqlString,SqlSurface_Name);
        }
        /// <summary>
        /// 判断程序是否在运行
        /// true 该程序在电脑进程运行中  false 表示不在进程运行
        /// 该方法主要用于避免继承过程中CLR 进入SQL数据库 查询数据从而卡死软件
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool GetPidByProcess(string Name = "自定义Uppercomputer-20200727")
        {
            return System.Diagnostics.Process.GetProcessesByName(Name).ToList().Count > 0 ? true : false;
        }
        protected override void OnParentChanged(EventArgs e)//加载状态栏
        {
            //判断程序是否在进程中运行？
            if (!GetPidByProcess()) return;
            //添加控件参数
            if (!SQL_Enable) return;
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
            });
        }
        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)//编辑模式结束
        {
            //判断程序是否在进程中运行？
            if (!GetPidByProcess()) return;
            this.BeginInvoke((EventHandler)delegate
            {
                if (!SQL_Enable) return;
                for (int i = 0; i < this.ColumnCount; i++)
                {
                    if (this.Rows[e.RowIndex].Cells[i].Value == null || this.Rows[e.RowIndex].Cells[i].Value.ToString() == "")//判断内容是否符合刷新
                    {
                        this.Rows[e.RowIndex].Cells[i].Value = "  ";
                    }
                }
                gridView_SQL.skinDataGridView_modification(this);//修改表
                gridView_SQL.skinDataGridView_update(this);//更新表
            });
        }
        protected override void OnUserDeletedRow(DataGridViewRowEventArgs e)//用户删除行完成
        {
            //判断程序是否在进程中运行？
            if (!GetPidByProcess()) return;
            base.OnUserDeletedRow(e);
            this.BeginInvoke((EventHandler)delegate
            {
                if (!SQL_Enable) return;
                gridView_SQL.skinDataGridView_modification(this);//修改表
                gridView_SQL.skinDataGridView_update(this);//更新表
            });
        }
        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
           // base.OnDataError(displayErrorDialogIfNoHandler, e);
        }
        protected override void Dispose(bool disposing)//释放托管资源
        {
            base.Dispose(disposing);
        }

    }
}
