using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 服务器端.上位机通讯报文处理
{
    /// <summary>
    /// 指示着访问结果-与访问返回的数据
    /// </summary>
    /// <typeparam name="T">需要约束的类型</typeparam>
    public class Operating<T>
    {
        /// <summary>
        /// 用户数据
        /// </summary>
        public T Content;
        /// <summary>
        ///   指示本次访问是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 具体的错误代码
        /// </summary>
        public string ErrorCode { get; set; }
    }
}
