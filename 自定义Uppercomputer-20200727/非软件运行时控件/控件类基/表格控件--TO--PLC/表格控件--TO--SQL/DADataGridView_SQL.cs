using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCWin.SkinControl;

namespace 自定义Uppercomputer_20200727.非软件运行时控件.控件类基.表格控件__TO__PLC.表格控件__TO__SQL
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/22 14:05:43 
    //  文件名：DADataGridView_SQL 
    //  版本：V1.0.1  
    //  说明： 实现控件本类用于处理注册事件--进行数据查询修改等操作
    //  修改者：***
    //  修改说明： 
    //==============================================================
    class DADataGridView_SQL
    {
        private DataTable dataTable;//定义网格ADO.NET缓存对象
        private SqlDataAdapter sqlDataAdapter;//定义更新数据对象
        SqlConnection sqlConnection;//SQL连接对象
        SqlCommandBuilder sqlCommandBuilder;
        public string connect;//连接字符串
        public string SQL_statement;//SQL语句
        public DADataGridView_SQL(string connect,string SqlSurface_Name)//构造函数--初始化缓存对象
        {
            this.connect = connect;
            this.SQL_statement = $"select * from {SqlSurface_Name}";
            this.sqlConnection = new SqlConnection(connect);//实例化SQL对象
            this.sqlDataAdapter = new SqlDataAdapter(SQL_statement, sqlConnection);//数据对象
            this.dataTable = new DataTable();//实例化缓存对象
        }
        public void skinDataGridView_update(SkinDataGridView skinDataGridView)//获取数据库数据--更新表
        {
            this.dataTable = new DataTable();//实例化缓存对象
            this.sqlDataAdapter.Fill(this.dataTable);//获取表
            skinDataGridView.DataSource = this.dataTable;//绑定数据源
        }
        public void skinDataGridView_modification(SkinDataGridView skinDataGridView)//获取数据库数据--修改表
        {
            this.dataTable = new DataTable();//实例化缓存对象
            this.sqlCommandBuilder = new SqlCommandBuilder(this.sqlDataAdapter);
            this.sqlDataAdapter.Update((DataTable)skinDataGridView.DataSource);
        }
        public void skinDataGridView_RemoveAt(SkinDataGridView skinDataGridView)//获取数据库数据--删除行
        {
            skinDataGridView.Rows.RemoveAt(skinDataGridView.CurrentCell.RowIndex);
            this.sqlCommandBuilder = new SqlCommandBuilder(this.sqlDataAdapter);
            this.sqlDataAdapter.Update(this.dataTable);
        }
    }
}
