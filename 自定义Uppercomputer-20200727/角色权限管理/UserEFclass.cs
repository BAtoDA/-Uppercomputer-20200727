using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCWin.SkinControl;
using Sunny.UI;
using 自定义Uppercomputer_20200727.EF实体模型;

namespace 自定义Uppercomputer_20200727.角色权限管理
{
    /// <summary>
    /// 用于处理用户权限--对数据库类
    /// </summary>
    public class UserEFclass<T>
    {
        private DataTable dataTable;//定义网格ADO.NET缓存对象
        private SqlDataAdapter sqlDataAdapter;//定义更新数据对象
        SqlConnection sqlConnection;//SQL连接对象
        SqlCommandBuilder sqlCommandBuilder;
        public string connect;//连接字符串
        public string SQL_statement;//SQL语句
        //SQLlite
        private SQLiteDataAdapter SQLiteDataAdapter;//定义更新数据对象
        SQLiteConnection SQLiteConnection;//SQL连接对象
        SQLiteCommandBuilder SQLiteCommandBuilder;
        public UserEFclass()//构造函数--初始化缓存对象
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())//打开EF实体模型
            {
                connect = model.Database.Connection.ConnectionString;//获取EF连接字符串
                SQL_statement = $"select * from {typeof(T).Name}";//获取sql语句
            }
            //选择sql与sqllite
            int ie = 1;
            if (ie != 1)
            {
                this.sqlConnection = new SqlConnection(connect);//实例化SQL对象
                this.sqlDataAdapter = new SqlDataAdapter(SQL_statement, sqlConnection);//数据对象
                this.dataTable = new DataTable();//实例化缓存对象
                return;
            }
            this.SQLiteConnection = new SQLiteConnection(connect);//实例化SQL对象
            this.SQLiteDataAdapter = new SQLiteDataAdapter(SQL_statement, SQLiteConnection);//数据对象
            this.dataTable = new DataTable();//实例化缓存对象
        }
        /// <summary>
        /// 获取数据库数据--更新表
        /// </summary>
        /// <param name="skinDataGridView"></param>
        public void skinDataGridView_update(SkinDataGridView skinDataGridView)//获取数据库数据--更新表
        {
            //选择sql与sqllite
            int ie = 1;
            this.dataTable = new DataTable();//实例化缓存对象
            if (ie != 1)
            {
                this.sqlDataAdapter.Fill(this.dataTable);//获取表
            }
            else
            {
                this.SQLiteDataAdapter.Fill(this.dataTable);//获取表
            }
            skinDataGridView.BeginInvoke((EventHandler)delegate
            {
                skinDataGridView.DataSource = this.dataTable;//绑定数据源
            });
        }
        /// <summary>
        /// 获取数据库数据--修改表
        /// </summary>
        /// <param name="skinDataGridView"></param>
        public void skinDataGridView_modification(SkinDataGridView skinDataGridView)//获取数据库数据--修改表
        {
            //选择sql与sqllite
            int ie = 1;
            this.dataTable = new DataTable();//实例化缓存对象
            if (ie != 1)
            {
                this.sqlCommandBuilder = new SqlCommandBuilder(this.sqlDataAdapter);//
            }
            else
            {
                this.SQLiteCommandBuilder = new SQLiteCommandBuilder(this.SQLiteDataAdapter);//
            }
            //this.sqlDataAdapter.Update(this.dataTable);
        }
        /// <summary>
        /// 获取数据库数据--删除行
        /// </summary>
        /// <param name="skinDataGridView"></param>
        public void skinDataGridView_RemoveAt(SkinDataGridView skinDataGridView)//获取数据库数据--删除行
        {
            //选择sql与sqllite
            skinDataGridView.Rows.RemoveAt(skinDataGridView.CurrentCell.RowIndex);
            int ie = 1;
            if (ie != 1)
            {
                this.sqlCommandBuilder = new SqlCommandBuilder(this.sqlDataAdapter);
            }
            else
            {
                this.SQLiteCommandBuilder = new SQLiteCommandBuilder(this.SQLiteDataAdapter);
            }
            this.sqlDataAdapter.Update(this.dataTable);
        }
 
    }
}
