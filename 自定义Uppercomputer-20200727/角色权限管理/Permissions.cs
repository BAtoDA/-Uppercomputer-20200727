using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.角色权限管理
{
    /// <summary>
    /// 用户权限类
    /// </summary>
    class Permissions
    {
        /// <summary>
        /// 用户权限等级
        /// </summary>
        public static int Privilege { get; set; } = 0;
        /// <summary>
        /// 登录的用户名
        /// </summary>
        public static string User { get; set; } = "00";
        /// <summary>
        /// 登录的用户密码
        /// </summary>
        public static string Password { get; set; } = "0";
    }
}
