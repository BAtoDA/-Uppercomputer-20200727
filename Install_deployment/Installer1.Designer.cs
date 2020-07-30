using System;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
namespace Install_deployment
{
    partial class Installer1 : System.Configuration.Install.Installer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);
          
        }
        /// <summary>
        /// 在 Installers 属性中的安装程序执行它们的卸载操作前发生。
        /// </summary>
        /// <param name="savedState"></param>
        protected override void OnBeforeUninstall(IDictionary savedState)
        {

            //读取安装路径
            string targetdir = this.Context.Parameters["targetdir"];//读取安装路径
            //                                                        //开始读取用户数据库的安装配置
            //XML xML = new XML(@targetdir);
            //var SqlName = xML.Read_XML();
            //MessageBox.Show(SqlName[0].Item1 + SqlName[0].Item2 + SqlName[0].Item3 + SqlName[0].Item4);
            //////开始自动移除数据库
            //this.Context.LogMessage("开始移除数据库");
            //DataBaseControl DBC = new DataBaseControl();
            //DBC.ConnectionString = @"Data Source=" + SqlName[0].Item1 + ";Initial Catalog= " + SqlName[0].Item2 + ";Persist Security Info=True;User ID=" + SqlName[0].Item3 + ";Password=" + SqlName[0].Item4;
            //DBC.DataBaseName = SqlName[0].Item2;
            //DBC.shujukushanchu();//移除数据库
            //xML.Delete_XML();//移除数据库配置文件
            base.OnBeforeUninstall(savedState);
            MessageBox.Show("卸载完成但是需要手动分离数据库才能彻底清除安装");

        }
        /// <summary>
        /// 引发System.Configuration.Install.Installer.AfterInstall 事件，即在执行安装后进入该函数。
        /// 进行对数据库判断与MX组件
        /// </summary>
        /// <param name="savedState"></param>
        protected override void OnAfterInstall(IDictionary savedState)
        {
            //读取安装路径
            string targetdir = this.Context.Parameters["targetdir"];//读取安装路径
            //读取安装配置数据库内容
            string editb1 = this.Context.Parameters["editb1"];
            string editb2 = this.Context.Parameters["editb2"];
            string editb3 = this.Context.Parameters["editb3"];
            string editb4 = this.Context.Parameters["editb4"];
            if (editb1 == null || editb2 == null || editb3 == null || editb4 == null)
                throw new System.Exception("输入的数据库名称或者名称为空");
            //开始自动附加数据库
            String_to_String(ref editb1);
            this.Context.LogMessage("开始附加数据库");
            DataBaseControl DBC = new DataBaseControl();
            DBC.ConnectionString = @"Data Source=" + editb1 + ";Initial Catalog= master;Persist Security Info=True;User ID=" + editb3 + ";Password=" + editb4;
            DBC.DataBaseName = "Uppercomputer";
            string SqlName = @targetdir;
            SqlName = SqlName.Substring(0, SqlName.Length - 2);
            SqlName = SqlName + "\\Uppercomputer";
            this.Context.LogMessage(SqlName);
            DBC.DataBase_MDF = SqlName+".mdf";
            this.Context.LogMessage(SqlName+".mdf");
            DBC.DataBase_LDF = SqlName+"_log.ldf";
            DBC.AddDataBase();
            //判断用户输入的连接字符串是否正确
            string Sqllin =@"Data Source="+ editb1 + ";Initial Catalog="+editb2+";Persist Security Info=True;User ID="+editb3+";Password="+editb4;
            using (SqlConnection sqlConnection = new SqlConnection(Sqllin))
            {
                sqlConnection.Open();//打开数据库
                sqlConnection.Close();//关闭数据库
            }
            this.Context.LogMessage("你的数据库连接字符串为:\r\n" + Sqllin);
            //判断COM组件是否存在
            //FileInfo fileInfo = new FileInfo(@"C:\Act\Control\ActUtlType.dll");
            //if (!fileInfo.Exists)
            //throw new Exception(@"未能找到C:\Act\Control\ActUtlType.dll路径下的文件--确定该电脑是否安装了三菱MX Component软件  如果安装了请在该路径下创建一个文件");
            //使用ID去判断COM组件是否注册
            Guid clsid = new Guid("63885648-1785-41A4-82D5-C578D29E4DA8");
            Type comType = Type.GetTypeFromCLSID(clsid);
            if(comType==null)
            throw new Exception("未能找到ActUtlType.dll确定该电脑是否安装了三菱MX Component软件\r\n"+ @"如果安装了请在C:\Act\Control\ActUtlType.dll该路径下创建一个文件");
            //开始对就开始配置文件进行保存写入
            XML xML = new XML(@targetdir);
            xML.Add_XMl(editb1, editb2, editb3, editb4);
        }
        private void String_to_String(ref string editb1)
        {
            string[] DSW;
            if (editb1.IndexOf('\\') > -1)
            {
                DSW = editb1.Split('\\');
                editb1 = DSW[0] + @"\" + DSW[2];
            }
        }
        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
    }
}