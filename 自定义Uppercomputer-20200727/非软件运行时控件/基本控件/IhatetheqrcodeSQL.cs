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
using 自定义Uppercomputer_20200727.非软件运行时控件.二维码生成;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.基本控件
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/22 14:05:43 
    //  文件名：DADataGridView_SQL 
    //  版本：V1.0.1  
    //  说明： 实现控件从SQL数据库获取数据 并且允许用户扫码完成删除该数据
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现控件从SQL数据库获取数据 并且允许用户扫码完成删除该数据
    /// </summary>
    [ToolboxItem(true)]
    [Browsable(true)]
    [Description("实现控件从SQL数据库获取数据 并且允许用户扫码完成删除该数据")]
    public partial class IhatetheqrcodeSQL : UserControl
    {
        #region  控件属性
        [Description("二维码生成类型 选择显示条形码还是二维码--默认二维码 false 二维码 true 条形码"), Category("SQL-控件参数")]
        /// <summary>
        /// 选择显示条形码还是二维码--默认二维码
        /// </summary>
        public bool select { get; set; } = false;
        /// <summary>
        /// SQL链接字符串
        /// </summary>
        [Description("SQL链接字符串--仅支持用户名 密码 登录不支持Win身份登录 字符串需要写明需要链接的数据库名 注意仅支持SQL Server"), Category("SQL-控件参数")]
        public string SqlString { get; set; } = @"data source=DESKTOP-955LB02\SQLEXPRESS;initial catalog=XN;persist security info=True;user id=sa;password=3131458;MultipleActiveResultSets=True;App=EntityFramework";
        /// <summary>
        /// 需要链接的SQL表名
        /// </summary>
        [Description("需要链接的SQL表名"), Category("SQL-控件参数")]
        public string SqlSurface_Name { get; set; } = "Table_1";
        /// <summary>
        /// 需要链接的SQL列名
        /// </summary>
        [Description("需要链接的SQL列名"), Category("SQL-控件参数")]
        public string Column_Name { get; set; } = "ID";
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

        private DataTable dataTable;//定义网格ADO.NET缓存对象 保存需要显示二维码的数据
        private DataTable DataTable_id;//定义ADO.NET缓存对象 保存显示二维码的主键ID
        private SqlDataAdapter sqlDataAdapter;//定义更新数据对象
        SqlConnection sqlConnection;//SQL连接对象
        public string SQL_statement;//SQL语句
        IhatetheqrcodeCreate ihatetheqrcode;
        int Line = 0, PresentLine = 0;
        #endregion
        public IhatetheqrcodeSQL()
        {
            InitializeComponent();
        }
        protected override void OnParentChanged(EventArgs e)//加载状态栏
        {
            IhatetheqrcodeSQL1_Load1(this, new EventArgs());
        }
        private void IhatetheqrcodeSQL1_Load1(object sender, EventArgs e)//控件加载事件 从SQL数据库获取数据
        {
            ihatetheqrcode = new IhatetheqrcodeCreate();
            if (SQL_Enable)
            {
                this.SQL_statement = $"select * from {SqlSurface_Name}";
                this.sqlConnection = new SqlConnection(SqlString);//实例化SQL对象
                this.sqlDataAdapter = new SqlDataAdapter(SQL_statement, sqlConnection);//数据对象
                DataTable_id = new DataTable();
                this.sqlDataAdapter.Fill(this.DataTable_id);//获取表

                this.SQL_statement = $"select {Column_Name} from {SqlSurface_Name}";
                this.sqlDataAdapter = new SqlDataAdapter(SQL_statement, sqlConnection);//数据对象
                this.dataTable = new DataTable();//实例化缓存对象
                this.sqlDataAdapter.Fill(this.dataTable);//获取表
                this.skinTextBox1.Text = this.dataTable.Rows.Count.ToString();
                this.skinTextBox2.Text = 1.ToString();
                if (this.dataTable.Rows.Count > 0)
                    this.Refresh_Data(this.dataTable.Rows[0].ItemArray[0].ToString());
            }
        }
        /// <summary>
        /// 刷新图片--目前不实现带Logo
        /// </summary>
        public void Refresh_Data(string Data)
        {
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;//显示方式铺满
            //小于一定字符数量--显示默认数据
            if (Data.Length < 0)
                Data = "123456789";
            //判断用户选择显示的类型
            if (this.select != true)
                this.pictureBox1.BackgroundImage = ihatetheqrcode.Generate1(Data, this.pictureBox1.Size.Width, this.pictureBox1.Size.Height);//加载二维码
            else
                this.pictureBox1.BackgroundImage = ihatetheqrcode.Generate2(Data, this.pictureBox1.Size.Width, this.pictureBox1.Size.Height);//加载条形码
        }

        private void skinButton2_Click(object sender, EventArgs e)//刷新数据库
        {
            this.IhatetheqrcodeSQL1_Load1(this, new EventArgs());
        }

        private void skinButton1_Click(object sender, EventArgs e)//扫码完成事件
        {
            if(this.DataTable_id.Rows.Count>0)
            {
                //请求更新数据
                if (this.skinCheckBox1.Checked)
                {
                    try
                    {
                        this.SQL_statement = $"DELETE FROM {SqlSurface_Name} WHERE {Column_Name} = '{this.dataTable.Rows[0].ItemArray[0].ToString()}' ";
                        using (sqlConnection = new SqlConnection(SqlString))
                        {
                            SqlCommand sqlCommand = new SqlCommand(SQL_statement, sqlConnection);
                            sqlConnection.Open();
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();
                        }
                    }
                    catch { MessageBox.Show("删除SQL数据库行错误"); }
                }
                this.DataTable_id.Rows.RemoveAt(0);
                this.dataTable.Rows.RemoveAt(0);
                //更新数据库完成
                if (this.DataTable_id.Rows.Count == 0)
                {
                    MessageBox.Show("SQL数据库已经无数据");
                    return;
                }
                //获取产生下一条二维码
                this.Refresh_Data(this.dataTable.Rows[0].ItemArray[0].ToString());
                this.skinTextBox2.Text = (Convert.ToInt32(this.skinTextBox2.Text) + 1).ToString();
            }
            else
                MessageBox.Show("SQL数据库已经无数据");

        }
    }
}
