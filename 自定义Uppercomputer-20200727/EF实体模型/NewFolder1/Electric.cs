using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SQLite.CodeFirst;
namespace 自定义Uppercomputer_20200727.EF实体模型.NewFolder1
{
    public class Electric
    {
        [Required]
        [Unique]
        public int ID { get; set; }
        [Required]
        [Unique]
        public string Coding { get; set; }
        [Required]
        [Unique]
        public string Type { get; set; }
        [Required]
        [Unique]
        public string Specification { get; set; }
        [Required]
        [Unique]
        public string Brand { get; set; }
        [Required]
        [Unique]
        public string MLFB { get; set; }
        [Required]
        [Unique]
        public string Measure { get; set; }
        [Required]
        [Unique]
        public string Picture { get; set; }
        [Required]
        [Unique]
        public string Comment { get; set; }
    }
}
