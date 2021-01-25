using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSEngineTest.重构帮助文档.说明控件.宏函数解析控件;
using Sunny.UI;

namespace CSEngineTest.重构帮助文档.说明控件
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }
        //通用显示方法
        private void LinkLabel_Click(object sender, EventArgs e)
        {
            //先判断是否已经打开了窗口？？
            Control control = sender as UILinkLabel;
            var form = (from Control pi in this.Controls where pi is FunctionAnalysis select pi).FirstOrDefault();
            if (form != null)
            {
                this.Controls.Remove(form);
                if(control.Name== form.Name)
                return;
            }
            //添加窗口 先获取鼠标当前位置
            //Control.MousePosition
            Document_Class document_Class = new Document_Class();
            var key = document_Class.Key_Tup.Where(pi => pi.Item1 == control.Name).FirstOrDefault();
            if (key != null)
            {
                FunctionAnalysis functionAnalysis = new FunctionAnalysis();
                functionAnalysis.Name2 = key.Item2;
                functionAnalysis.Name4 = key.Item3;
                functionAnalysis.Name6 = key.Item4;
                functionAnalysis.Name8 = key.Item5;
                //添加控件的位置
                if(Explain.SIZE_i.Height<900)
                    functionAnalysis.Location = new Point(Control.MousePosition.X-380 , Control.MousePosition.Y-130 );
                else
                    functionAnalysis.Location = new Point(Control.MousePosition.X-100, Control.MousePosition.Y-80 );
                functionAnalysis.Font_Load();
                functionAnalysis.Name = control.Name;
                this.Controls.Add(functionAnalysis);
                functionAnalysis.BringToFront();
            }
        
        }
    }
}
