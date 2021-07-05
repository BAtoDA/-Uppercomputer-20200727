using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTML布局学习.EF实体模型;
using SQLite.CodeFirst;

namespace 自定义Uppercomputer产量报警Web监视.EF实体模型
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/4/2 10:22:28 
    //  文件名：ThumbnailContext 
    //  版本：V1.0.1  
    //  说明： 实现SQLlite数据库EF实体模型
    //  修改者：***
    //  修改说明： 
    //==============================================================
    public partial class UppercomputerEntities2 : DbContext
    {
        public static string dbPath = $@"data source={@Application.StartupPath}\临时数据库文件\Extent1.db;Version=3;";
        /// <summary>
        /// EF构造函数
        /// </summary>
        /// <param name="SqlPath">需要打开的SQLlite数据库路径</param>
        public UppercomputerEntities2(string SqlPath) : base("SqliteTest") 
        {
            dbPath = SqlPath;//获取传入的路径
        }
        public UppercomputerEntities2():base("SqliteTest")
        {
            this.Database.CommandTimeout = 2000;
        }
        /// <summary>
        /// 创建链接字符串
        /// </summary>
        /// <param name="host"></param>
        /// <param name="catalog"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="winAuth"></param>
        /// <returns></returns>
        public static string ConnectToSqlServer(string host, string catalog, string user, string pass, bool winAuth)
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = host,
                InitialCatalog = catalog,
                PersistSecurityInfo = true,
                IntegratedSecurity = winAuth,
                MultipleActiveResultSets = true,
                UserID = user,
                Password = pass,
            };

            // assumes a connectionString name in .config of MyDbEntities
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SQLite.EF6",
                ProviderConnectionString = sqlBuilder.ConnectionString,
                //Metadata = "res://*/EF实体模型.Model1.csdl|res://*/EF实体模型.Model1.ssdl|res://*/EF实体模型.Model1.msl",
            };

            return entityConnectionStringBuilder.ConnectionString;
        }
        /// <summary>
        /// 打开SQL链接属性
        /// </summary>
        public static UppercomputerEntities2 Instance
        {
            get
            {
                DbConnection sqliteCon = SQLiteProviderFactory.Instance.CreateConnection();
                sqliteCon.ConnectionString = dbPath;
                return new UppercomputerEntities2(sqliteCon);
            }
        }
        private UppercomputerEntities2(DbConnection con) : base(con, true) { }
        /// <summary>
        /// 自动创建SQLlte数据库
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //如果不存在数据库，则创建
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<UppercomputerEntities2>(modelBuilder));
        }
        #region 数据库属性
        public virtual DbSet<Event_message> Event_message { get; set; }
        public virtual DbSet<Alarmhistories> Alarmhistory { get; set; }
        public virtual DbSet<HourOutput> HourOutputs { get; set; }
        public virtual DbSet<ParameterWeb> ParameterWebs { get; set; }
        public virtual DbSet<Scheduletaiyaki> Scheduletaiyakis { get; set; }
        #endregion
    }
}
