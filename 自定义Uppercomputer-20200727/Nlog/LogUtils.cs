using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义Uppercomputer_20200727.Nlog
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/10 8:56:43 
    //  文件名：LogUtils 
    //  版本：V1.0.1  
    //  说明： 软件日志
    //  修改者：***
    //  修改说明： 
    //==============================================================
    public class LogUtils
    {
        private static readonly Logger log = LogManager.GetLogger("*");
        /// <summary>
        /// 保存info级别的信息
        /// </summary>
        /// <param name="message"></param>
        public static void infoWrite(string message)
        {
            log.Info(message);
        }
        /// <summary>
        /// 保存info级别的信息
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="content">日志内容</param>
        public static void infoWrite(string className, string methodName, string content)
        {
            string message = "className:{" + className + "}, methodName:{" + methodName + "}, content:{" + content + "}";
            log.Info(message);
        }


        /// <summary>
        /// 保存error级别信息
        /// </summary>
        /// <param name="error"></param>
        public static void errorWrite(string error)
        {
            log.Error(error);
        }

        /// <summary>
        /// 保存error级别信息
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="content">日志内容</param>
        public static void errorWrite(string className, string methodName, string content)
        {
            string message = "className:{" + className + "}, methodName:{" + methodName + "}, content:{" + content + "}";
            log.Error(message);
        }

        /// <summary>
        /// 输出日志消息
        /// </summary>
        public static event EventHandler DebugEventMessge;
        /// <summary>
        /// 保存debug级别信息
        /// </summary>
        /// <param name="message"></param>
        public static void debugWrite(string message)
        {
            //优先输出到软件监控窗口
            if(DebugEventMessge!=null)
            {
                DebugEventMessge.Invoke(message, new EventArgs());
            }
            log.Debug(message);
        }

        /// <summary>
        /// 保存debug级别信息
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="content">日志内容</param>
        public static void debugWrite(string className, string methodName, string content)
        {
            string message = "className:{" + className + "}, methodName:{" + methodName + "}, content:{" + content + "}";
            Log.Debug(message);
        }

        /// <summary>
        /// 删除2个月前的日志文件
        /// </summary>
        public static void deleteLogFile(string logPath)
        {
            if (!Directory.Exists(logPath))
            {
                return;
            }
            DirectoryInfo folder = new DirectoryInfo(logPath);
            FileInfo[] files = folder.GetFiles("*.log");
            if (files == null)
            {
                return;
            }

            foreach (FileInfo file in files)
            {
                //文件创建时间
                DateTime fileCreateTime = file.LastWriteTime;
                //当前时间
                DateTime now = DateTime.Now;
                int createMonth = fileCreateTime.Month;
                int nowMonth = now.Month;

                int distance = nowMonth - createMonth;
                distance = distance >= 0 ? distance : (distance + 12);

                if (distance < 1)
                {
                    //小于1个月不删除
                    continue;
                }

                try
                {
                    File.Delete(file.FullName);
                }
                catch
                {
                    throw new Exception("删除日志文件出现异常");
                }

            }
        }
    }
}
   
