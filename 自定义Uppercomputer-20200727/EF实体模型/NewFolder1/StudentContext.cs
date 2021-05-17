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
using SQLite.CodeFirst;
namespace 自定义Uppercomputer_20200727.EF实体模型.NewFolder1
{
    public class StudentContext : DbContext
    {
        //定义属性，便于外部访问数据表
        #region sql
        public virtual DbSet<AnalogMeter_parameter> AnalogMeter_parameter { get; set; }
        public virtual DbSet<Button_colour> Button_colour { get; set; }
        public virtual DbSet<Button_parameter> Button_parameter { get; set; }
        public virtual DbSet<Control_layer> Control_layer { get; set; }
        public virtual DbSet<control_location> control_location { get; set; }
        public virtual DbSet<doughnut_Chart_parameter> doughnut_Chart_parameter { get; set; }
        public virtual DbSet<Event_message> Event_message { get; set; }
        public virtual DbSet<function_key_parameter> function_key_parameter { get; set; }
        public virtual DbSet<General_parameters_of_picture> General_parameters_of_picture { get; set; }
        public virtual DbSet<GroupBox_parameter> GroupBox_parameter { get; set; }
        public virtual DbSet<histogram_Chart_parameter> histogram_Chart_parameter { get; set; }
        public virtual DbSet<HScrollBar_parameter> HScrollBar_parameter { get; set; }
        public virtual DbSet<ihatetheqrcode_parameter> ihatetheqrcode_parameter { get; set; }
        public virtual DbSet<ImageButton_parameter> ImageButton_parameter { get; set; }
        public virtual DbSet<label_parameter> label_parameter { get; set; }
        public virtual DbSet<LedBulb_parameter> LedBulb_parameter { get; set; }
        public virtual DbSet<LedDisplay_parameter> LedDisplay_parameter { get; set; }
        public virtual DbSet<numerical_parameter> numerical_parameter { get; set; }
        public virtual DbSet<oscillogram_Chart_parameter> oscillogram_Chart_parameter { get; set; }
        public virtual DbSet<picture_parameter> picture_parameter { get; set; }
        public virtual DbSet<PLC_macroinstruction> PLC_macroinstruction { get; set; }
        public virtual DbSet<PLC_parameter> PLC_parameter { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<pull_down_menu_parameter> pull_down_menu_parameter { get; set; }
        public virtual DbSet<pull_down_menuName> pull_down_menuName { get; set; }
        public virtual DbSet<RadioButton_parameter> RadioButton_parameter { get; set; }
        public virtual DbSet<ScrollingText_parameter> ScrollingText_parameter { get; set; }
        public virtual DbSet<Switch_parameter> Switch_parameter { get; set; }
        public virtual DbSet<Tag_common_parameters> Tag_common_parameters { get; set; }
        public virtual DbSet<AnalogMeter_Class> AnalogMeter_Class { get; set; }
        public virtual DbSet<Button_Class> Button_Class { get; set; }
        public virtual DbSet<doughnut_Chart_Class> doughnut_Chart_Class { get; set; }
        public virtual DbSet<function_key_Class> function_key_Class { get; set; }
        public virtual DbSet<GroupBox_Class> GroupBox_Class { get; set; }
        public virtual DbSet<histogram_Chart_Class> histogram_Chart_Class { get; set; }
        public virtual DbSet<HScrollBar_Class> HScrollBar_Class { get; set; }
        public virtual DbSet<ihatetheqrcode_Class> ihatetheqrcode_Class { get; set; }
        public virtual DbSet<ImageButton_Class> ImageButton_Class { get; set; }
        public virtual DbSet<label_Class> label_Class { get; set; }
        public virtual DbSet<LedBulb_Class> LedBulb_Class { get; set; }
        public virtual DbSet<LedDisplay_Class> LedDisplay_Class { get; set; }
        public virtual DbSet<numerical_Class> numerical_Class { get; set; }
        public virtual DbSet<oscillogram_Chart_Class> oscillogram_Chart_Class { get; set; }
        public virtual DbSet<picture_Class> picture_Class { get; set; }
        public virtual DbSet<pull_down_menu_Class> pull_down_menu_Class { get; set; }
        public virtual DbSet<RadioButton_Class> RadioButton_Class { get; set; }
        public virtual DbSet<ScrollingText_Class> ScrollingText_Class { get; set; }
        public virtual DbSet<Switch_Class> Switch_Class { get; set; }
        public virtual DbSet<Conveyor_parameter> Conveyor_parameter { get; set; }
        public virtual DbSet<Conveyor_Class> Conveyor_Class { get; set; }
        public virtual DbSet<Valve_parameter> Valve_parameter { get; set; }
        public virtual DbSet<Valve_Class> Valve_Class { get; set; }
        #endregion
        public DbSet<Electric> Thumbnails { get; set; }
        public static string dbPath = @"Data Source=D:\C#项目\电气组物料库\电气组物料库\EF实体模型\物料库SQL.db";
        /// <summary>
        /// EF构造函数
        /// </summary>
        /// <param name="SqlPath">需要打开的SQLlite数据库路径</param>
        public StudentContext(string SqlPath) : base("SQLiteConnect")
        {
            dbPath = SqlPath;//获取传入的路径
        }
        public StudentContext(): base("SQLiteConnect")
        {

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
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sqlBuilder.ConnectionString,
                Metadata = "res://*/EF实体模型.Model1.csdl|res://*/EF实体模型.Model1.ssdl|res://*/EF实体模型.Model1.msl",
            };

            return entityConnectionStringBuilder.ConnectionString;
        }
        /// <summary>
        /// 打开SQL链接属性
        /// </summary>
        public static StudentContext Instance
        {
            get
            {
                DbConnection sqliteCon = SQLiteProviderFactory.Instance.CreateConnection();
                sqliteCon.ConnectionString = dbPath;
                return new StudentContext(sqliteCon);
            }
        }
        private StudentContext(DbConnection con) : base(con, true) { }
        /// <summary>
        /// 自动创建SQLlte数据库
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //如果不存在数据库，则创建
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<StudentContext>(modelBuilder));
        }
    }
}
