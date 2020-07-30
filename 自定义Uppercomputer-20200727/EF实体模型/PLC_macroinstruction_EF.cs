using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <summary>
    /// 本类用于宏指令 对数据库增删改查实现
    /// </summary>
    class PLC_macroinstruction_EF
    {
        private DataTable dataTable;//定义网格ADO.NET缓存对象
        private SqlDataAdapter sqlDataAdapter;//定义更新数据对象
        SqlConnection sqlConnection;//SQL连接对象
        SqlCommandBuilder sqlCommandBuilder;
        public string connect;//连接字符串
        public string SQL_statement;//SQL语句
        public PLC_macroinstruction_EF()//构造函数--初始化缓存对象
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())//打开EF实体模型
            {
                connect = model.Database.Connection.ConnectionString;//获取EF连接字符串
                SQL_statement = "select * from PLC_macroinstruction";//获取sql语句
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
        public PLC_macroinstruction PLC_macroinstruction_inquire(int ID)//宏参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                PLC_macroinstruction PLC_macroinstruction = model.PLC_macroinstruction.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return PLC_macroinstruction;
            }
        }
        public int PLC_macroinstruction_Max()//宏参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.PLC_macroinstruction.Where(pi =>true).Select(PI=>PI).ToList().Count;//查询数据库是否有该ID
            }
        }
        public string PLC_macroinstruction_Add(PLC_macroinstruction parameter)//宏参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                PLC_macroinstruction PLC_macroinstruction = model.PLC_macroinstruction.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (PLC_macroinstruction == null)
                {
                    PLC_macroinstruction parameter1 = new PLC_macroinstruction();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.PLC_macroinstruction.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string PLC_macroinstruction_delete(int ID)//宏参数ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除按钮类主参数操作
                PLC_macroinstruction PLC_macroinstruction = model.PLC_macroinstruction.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (PLC_macroinstruction != null)
                {
                    model.PLC_macroinstruction.Remove(PLC_macroinstruction);////构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }       
                if (PLC_macroinstruction != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string PLC_macroinstruction_modification(int ID, PLC_macroinstruction _Parameter)//宏参数ID修改参数
        {

            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行修改按钮类主参数操作
                PLC_macroinstruction PLC_macroinstruction = model.PLC_macroinstruction.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (PLC_macroinstruction != null)
                {
                    #region 要修改的属性
                    PLC_macroinstruction.内容 = _Parameter.内容;//获取要修改的参数
                    PLC_macroinstruction.宏指令名称 = _Parameter.宏指令名称;//获取要修改的参数
                    PLC_macroinstruction.方法索引 = _Parameter.方法索引;//获取要修改的参数
                    PLC_macroinstruction.是否周期执行 = _Parameter.是否周期执行;//获取要修改的参数
                    PLC_macroinstruction.运行时间间隔 = _Parameter.运行时间间隔;//获取要修改的参数
                    #endregion
                    model.SaveChanges();//执行操作
                }        
                if (PLC_macroinstruction != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public List<PLC_macroinstruction> PLC_macroinstruction_modification()//查询数据库中的所有宏
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.PLC_macroinstruction.Where(pi => true).Select(pi => pi).ToList();
            }
        }
    }
}
