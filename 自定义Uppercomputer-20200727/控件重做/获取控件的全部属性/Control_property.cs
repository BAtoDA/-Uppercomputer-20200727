using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
namespace 自定义Uppercomputer_20200727.控件重做.获取控件的全部属性
{
    public partial class Control_property :Skin_DevExpress
    {
        public Control_property(PropertyGrid propertyGrid)
        {
            InitializeComponent();
            this.propertyGrid1.SelectedObject = propertyGrid.SelectedObject;
        }

        private void Control_property_Shown(object sender, EventArgs e)//添加数据
        {

        }
    }
}
