using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Graph;
using CCWin.SkinControl;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <本类用于处理注册事件--报警类进行数据查询修改等操作>    
    class Event_EF
    {
        private DataTable dataTable;//定义网格ADO.NET缓存对象
        private SqlDataAdapter sqlDataAdapter;//定义更新数据对象
        SqlConnection sqlConnection;//SQL连接对象
        SqlCommandBuilder sqlCommandBuilder;
        public string connect;//连接字符串
        public string SQL_statement;//SQL语句
        public Event_EF()//构造函数--初始化缓存对象
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())//打开EF实体模型
            {
               connect = model.Database.Connection.ConnectionString;//获取EF连接字符串
               SQL_statement = "select * from Event_message";//获取sql语句
            }
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
            this.sqlCommandBuilder = new SqlCommandBuilder(this.sqlDataAdapter);//
            this.sqlDataAdapter.Update(this.dataTable);
        }
        public void skinDataGridView_RemoveAt(SkinDataGridView skinDataGridView)//获取数据库数据--删除行
        {
            skinDataGridView.Rows.RemoveAt(skinDataGridView.CurrentCell.RowIndex);
            this.sqlCommandBuilder = new SqlCommandBuilder(this.sqlDataAdapter);
            this.sqlDataAdapter.Update(this.dataTable);
        }
        public Event_message Event_Query(int ID)//查询数据库
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Event_message event_Message = model.Event_message.Where(pi => pi.ID.Equals(ID)).FirstOrDefault();//查询数据库
                return event_Message;//返回数据
            }
        }
        public List<Event_message> Event_Query()//查询数据库--查询所有数据
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
               return model.Event_message.Where(pi =>true).Select(pi=>pi).ToList();//查询数据库-             
            }
        }
        public int Event_ID_maximum()//查询数据库最大值
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                int event_Message = model.Event_message.Where(pi=>true).ToList().Count;//查询数据库最大值
                return event_Message;//返回数据
            }
        }
        public void Event_Add(Event_message event_Message_data)//插入数据
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Event_message event_Message = model.Event_message.Where(pi => pi.ID.Equals(event_Message_data.ID)).FirstOrDefault();//查询数据库
                if(event_Message.IsNull())
                {
                    Event_message event_Message1 = new Event_message();//实例化对象
                    event_Message1 = event_Message_data;//传入获取到的对象
                    model.Event_message.Add(event_Message1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
        }
        public void Event_modification(Event_message event_Message_data)//插入数据
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Event_message event_Message = model.Event_message.Where(pi => pi.ID.Equals(event_Message_data.ID)).FirstOrDefault();//查询数据库
                if (event_Message.IsNull()!=true)
                {
                    #region 要修改的属性
                    event_Message.类型 = event_Message_data.类型;//获取对象
                    event_Message.设备 = event_Message_data.设备;//获取对象
                    event_Message.设备_地址 = event_Message_data.设备_地址;//获取对象
                    event_Message.设备_具体地址 = event_Message_data.设备_具体地址;//获取对象
                    event_Message.位触发条件 = event_Message_data.位触发条件;//获取对象
                    event_Message.字触发条件 = event_Message_data.字触发条件;//获取对象
                    event_Message.字触发条件_具体 = event_Message_data.字触发条件_具体;//获取对象
                    event_Message.报警内容 = event_Message_data.报警内容;//获取对象
                    #endregion
                    model.SaveChanges();//执行操作
                }
            }
        }
    }
}
