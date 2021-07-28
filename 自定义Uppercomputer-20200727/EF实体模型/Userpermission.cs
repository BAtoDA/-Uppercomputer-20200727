using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    [Table("Userpermission")]
    public class Userpermission
    {
        public int ID { get; set; }
        public bool 启用 { get; set; }
        public string 用户名称 { get; set; }
        public string 密码 { get; set; }
        public bool 类别A { get; set; }
        public bool 类别B { get; set; }
        public bool 类别C { get; set; }
        public bool 类别D { get; set; }
    }
}
