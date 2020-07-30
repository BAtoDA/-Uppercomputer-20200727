using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Install_deployment
{
    /// <summary>
    /// 数据库操作控制类
    /// </summary>
    public class DataBaseControl
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString;

        /// <summary>
        /// SQL操作语句/存储过程
        /// </summary>
        public string StrSQL;

        /// <summary>
        /// 实例化一个数据库连接对象
        /// </summary>
        private SqlConnection Conn;

        /// <summary>
        /// 实例化一个新的数据库操作对象Comm
        /// </summary>
        private SqlCommand Comm;

        /// <summary>
        /// 要操作的数据库名称
        /// </summary>
        public string DataBaseName;

        /// <summary>
        /// 数据库文件完整地址
        /// </summary>
        public string DataBase_MDF;

        /// <summary>
        /// 数据库日志文件完整地址
        /// </summary>
        public string DataBase_LDF;

        /// <summary>
        /// 备份文件名
        /// </summary>
        public string DataBaseOfBackupName;

        /// <summary>
        /// 备份文件路径
        /// </summary>
        public string DataBaseOfBackupPath;

        /// <summary>
        /// 执行创建/修改数据库和表的操作
        /// </summary>
        public void DataBaseAndTableControl()
        {
            try
            {
                Conn = new SqlConnection(ConnectionString);
                Conn.Open();

                Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = StrSQL;
                Comm.CommandType = CommandType.Text;
                Comm.ExecuteNonQuery();

                MessageBox.Show("数据库操作成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// 附加数据库
        /// </summary>
        public void AddDataBase()
        {
            Conn = new SqlConnection(ConnectionString);
            Conn.Open();

            Comm = new SqlCommand();
            Comm.Connection = Conn;
            Comm.CommandText = @"sp_attach_db";

            Comm.Parameters.Add(new SqlParameter(@"dbname", SqlDbType.NVarChar));
            Comm.Parameters[@"dbname"].Value = DataBaseName;
            Comm.Parameters.Add(new SqlParameter(@"filename1", SqlDbType.NVarChar));
            Comm.Parameters[@"filename1"].Value = DataBase_MDF;
            Comm.Parameters.Add(new SqlParameter(@"filename2", SqlDbType.NVarChar));
            Comm.Parameters[@"filename2"].Value = DataBase_LDF;

            Comm.CommandType = CommandType.StoredProcedure; //此处一定要用存储过程，还有我也认识到存储过程的参数的写法不同与SQL语句。在查询分析器中写附加数据库的语法为exec sp_attach_db @dbname=N'数据库名',@filename1=N'MDF文件路径',@filename2=N'LDF文件路径',按照我的推测，存储过程方式添加参数后它的值直接跟在后面了。
            Comm.ExecuteNonQuery();
            Conn.Close();
            MessageBox.Show("附加数据库成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 分离数据库
        /// </summary>
        public void DeleteDataBase()
        {
            try
            {
                Conn = new SqlConnection(ConnectionString);
                Conn.Open();

                Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = "sp_detach_db";

                Comm.Parameters.Add(new SqlParameter(@"dbname", SqlDbType.NVarChar));
                Comm.Parameters[@"dbname"].Value = DataBaseName;

                Comm.CommandType = CommandType.StoredProcedure;
                Comm.ExecuteNonQuery();

                MessageBox.Show("分离数据库成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Conn.Close();
            }
        }
        /// <summary>
        /// 移除数据库
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string shujukushanchu()//删除数据库
        {
            Conn = new SqlConnection(ConnectionString);
            Conn.Open();//打开数据库
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            Comm.CommandText = "DROP DATABASE " + DataBaseName;//DROP DATABASE 语句用于删除数据库：
            string jieguo = Comm.ExecuteNonQuery().ToString();//执行语句并返回受影响的行数
            Conn.Close();//关闭数据库
            return jieguo;//执行语句并返回受影响的行数
        }
        /// <summary>
        /// 备份数据库
        /// </summary>
        public void BackupDataBase()
        {
            try
            {
                Conn = new SqlConnection(ConnectionString);
                Conn.Open();

                Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = "use master;backup database @dbname to disk = @backupname;";

                Comm.Parameters.Add(new SqlParameter(@"dbname", SqlDbType.NVarChar));
                Comm.Parameters[@"dbname"].Value = DataBaseName;
                Comm.Parameters.Add(new SqlParameter(@"backupname", SqlDbType.NVarChar));
                Comm.Parameters[@"backupname"].Value = @DataBaseOfBackupPath + @DataBaseOfBackupName;

                //这里添加参数的方式就跟我以前的做法一样，只不过他加了@,我认识加@是个好习惯，防止特殊字符被转义，我以后也采用这种方式。

                Comm.CommandType = CommandType.Text;
                Comm.ExecuteNonQuery();

                MessageBox.Show("备份数据库成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// 还原数据库
        /// </summary>
        public void ReplaceDataBase()
        {
            try
            {
                string BackupFile = @DataBaseOfBackupPath + @DataBaseOfBackupName;
                Conn = new SqlConnection(ConnectionString);
                Conn.Open();

                Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = "use master;restore database @DataBaseName From disk = @BackupFile with replace;";

                Comm.Parameters.Add(new SqlParameter(@"DataBaseName", SqlDbType.NVarChar));
                Comm.Parameters[@"DataBaseName"].Value = DataBaseName;
                Comm.Parameters.Add(new SqlParameter(@"BackupFile", SqlDbType.NVarChar));
                Comm.Parameters[@"BackupFile"].Value = BackupFile;

                Comm.CommandType = CommandType.Text;
                Comm.ExecuteNonQuery();

                MessageBox.Show("还原数据库成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}
