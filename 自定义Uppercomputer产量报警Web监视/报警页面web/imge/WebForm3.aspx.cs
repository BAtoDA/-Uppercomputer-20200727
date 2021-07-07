using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 自定义Uppercomputer产量报警Web监视.EF实体模型;

namespace HTML布局学习.报警页面web
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试后端SQL数据库代码
            using(UppercomputerEntities2 db=new UppercomputerEntities2())
            {
                var data = db.Event_message.GroupBy(pi => pi.类型).OrderBy(pi => pi.Key).Select(x => new eventtolist() { id = x.Key, _Messages = x }).ToList();
                var data1 = db.Alarmhistory.Where(p => p.ID == 0).FirstOrDefault();
                var data2 = db.HourOutputs.FirstOrDefault();
              
            }

        }
    }
    [Serializable]
    class eventtolist
    { 
        public int id { get; set; }
        public IGrouping<int,Event_message> _Messages { get; set; }
    }
}