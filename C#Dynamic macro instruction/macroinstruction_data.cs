using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSEngineTest
{
    /// <summary>
    /// 宏指令 数据保存静态区
    /// </summary>
    public class macroinstruction_data<T>
    {
        /// <summary>
        /// 泛型区--使用前要记得地址
        /// </summary>
        public static List<T> Data = new List<T>();
        /// <summary>
        ///宏指令默认线程区 -- 最大线程数量100
        /// </summary>
        public static Thread[] thread = new Thread[100];//最大线程数量
        /// <summary>
        /// 创建寄存器--默认无类型约束--使用前
        /// </summary>
        public static object[] D_Data = new object[1024];
        /// <summary>
        /// 创建标志位--默认全是false
        /// </summary>
        public static bool[] M_Data = new bool[1024];
        /// <summary>
        /// 构造函数--使用泛型前 记得 使用此类实例化 
        /// </summary>
        /// <param name="Name"></param>
        public macroinstruction_data(T Name)
        {
            Data.Add(Name);//添加对象
        }

    }
}
