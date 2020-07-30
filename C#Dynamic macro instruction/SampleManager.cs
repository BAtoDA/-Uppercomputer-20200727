using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEngineTest
{
    /// <summary>
    /// 提前注册 要运行的类和方法
    /// </summary>
    internal class SampleManager
    {
        /// <summary>
        /// 注册默认运行类与方法
        /// </summary>
        /// <returns></returns>
        public static List<MethodSample> GetAllSample()
        {
            return new List<MethodSample>()
            {
                new MethodSample("Assembly CompileCode(string scriptText)",
                "//引用默认命名空间\r\n"+"using System;\r\n"+"using System.Collections.Concurrent;\r\n"+"using System.Collections.Generic;\r\n"+
                "using System.ComponentModel;\r\n"+"using System.Data;\r\n"+"using System.Drawing;\r\n"+"using System.Linq;\r\n"+
                "using System.Runtime.InteropServices;\r\n"+"using System.Text;\r\n"+"using System.Threading;\r\n"+"using System.Windows.Forms;\r\n"+
                "using System.Net;\r\n"+"using System.Net.Sockets;\r\n"+"using System.IO;\r\n"+"using System.IO.Ports;\r\n"+"using CSEngineTest;\r\n"+
                "//除了主类-方法不能改变其他随意添加--当然还可以访问到本项目的类-控件-接口-方法 \r\n"+
                                               "public class Script//创建主函数类\r\n"+
                                               "{\r\n"+
                                                   "    public int Sum(int a, int b)//主函数\r\n"+
                                                   "    {\r\n"+
                                                            "ThreadPool.QueueUserWorkItem((data_run) =>//线程池--默认把当前任务加到序列中-注意不要死循环否则出现资源抢夺问题-要死循环请使用内部线程 \r\n"+
                                                       "{\r\n"+
                                                          "\r\n"+
                                                          "\r\n"+
                                                        "});\r\n"+ 
                                                       "        return a+b;//返回数据int类型\r\n"+
                                                   "    }\r\n"+
                                               "}",1),

                new MethodSample("Assembly CompileMethod(string code)","int Sum(int a, int b)\r\n"+
                                                 "{\r\n"+
                                                     "  return a+b;\r\n"+
                                                 "}",2),

                new MethodSample("MethodDelegate CreateDelegate(string code)","string Log(string message)\r\n"+
                                             "{\r\n"+
                                                 "  return \"hello \"+message;\r\n"+
                                             "}",3),

                new MethodSample("MethodDelegate<T> CreateDelegate<T>(string code)","int Product(int a, int b)\r\n"+
                                             "{\r\n"+
                                                 "  return a*b;\r\n"+
                                             "}",4),

                new MethodSample("object LoadCode(string scriptText, params object[] args)","using System;\r\n"+
                                              "public class Script\r\n"+
                                              "{\r\n"+
                                                  " public int Sum(int a, int b)\r\n"+
                                                  " {\r\n"+
                                                      "     return a+b;\r\n"+
                                                  " }\r\n"+
                                              "}",5),

                new MethodSample("T LoadCode<T>(string scriptText, params object[] args) where T : class","using System;\r\n"+
                                                 "public class Script\r\n"+
                                                 "{\r\n"+
                                                     "  public int Div(int a, int b)\r\n"+
                                                     "  {\r\n"+
                                                         "      return a/b;\r\n"+
                                                     "  }\r\n"+
                                                 "}",6),

                new MethodSample("T LoadDelegate<T>(string code) where T : class","int Product(int a, int b)\r\n"+
                                             "{\r\n"+
                                                 "  return a*b;\r\n"+
                                             "}",7),

                new MethodSample("object LoadFile(string scriptFile)","此处应为文件路径",8),

                new MethodSample("T LoadFile<T>(string scriptFile) where T : class","此处应为文件路径",9),

                new MethodSample("object LoadMethod(string code)","int Product(int a, int b)\r\n"+
                                             "{\r\n"+
                                                 "  return a*b;\r\n"+
                                             "}",10),

                new MethodSample("T LoadMethod<T>(string code) where T : class","int Div(int a, int b)\r\n"+
                                             "{\r\n"+
                                                 "  return a/b;\r\n"+
                                             "}",11)
            };
        }
    }
}
