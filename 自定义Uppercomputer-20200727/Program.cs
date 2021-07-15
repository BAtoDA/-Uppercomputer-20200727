using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.Nlog;
using 自定义Uppercomputer_20200727.PLC选择.MODBUS_TCP监控窗口;
using 自定义Uppercomputer_20200727.修改参数界面;
using 自定义Uppercomputer_20200727.控件重做;

namespace 自定义Uppercomputer_20200727
{
    static class Program
    {
        public static bool OPENCLOASE = false;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //全局异常捕捉
            Application.ApplicationExit += ((send, e) =>
            {
                Process[] allProgresse = System.Diagnostics.Process.GetProcessesByName("Web网页数据后台采集");
                foreach (Process closeProgress in allProgresse)
                {
                    if (closeProgress.ProcessName.Equals("Web网页数据后台采集"))
                    {
                        closeProgress.Kill();
                        closeProgress.Close();
                        return;
                    }
                }
                OPENCLOASE = false;
            });
            //处理UI线程异常
            Application.ThreadException += Application_ThreadException;
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //主函数
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OPENCLOASE = true;
            Application.Run(new Home());
            OPENCLOASE = false;

        }
        /// <summary>
        /// 处理非线程异常  保存到日志中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            LogUtils.infoWrite(string.Format("捕获到未处理异常：{0}\r\n异常信息：{1}\r\n异常堆栈：{2}\r\nCLR即将退出：{3}", ex.GetType(), ex.Message, ex.StackTrace, e.IsTerminating));
        }
        /// <summary>
        /// 处理UI线程异常 保存到日志中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            LogUtils.errorWrite(string.Format("捕获到未处理异常：{0}\r\n异常信息：{1}\r\n异常堆栈：{2}", ex.GetType(), ex.Message, ex.StackTrace));
        }
    }
}
