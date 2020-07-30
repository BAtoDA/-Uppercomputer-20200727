using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自定义Uppercomputer_20200727.控制主页面模板
{
    /// <页面转换处理>
    class Windowclass
    {
       // private string[] FromnamTexe = new string[] { "主画面", "手动画面", "异常画面", "监视画面", "运转画面", "生产设置", "参数设置" };
        public Windowclass(Form Present, SkinButton[] Buttons,Form[] Formlist,SkinLabel Fromname,SkinButton skinButton)
        {
           for(int i=0;i<Formlist.Length;i++)
            {
                if(Buttons[i].Name == skinButton.Name)
                {                   
                    Fromtraverse(Present, Formlist[i], Buttons[i].Text);
                }
            }
        }
        private void Fromtraverse (Form Present, Form Openfrom,string Name)
        {
            foreach (Form frm in Application.OpenForms)//遍历所有窗口
            {
                if (frm.Name== Openfrom.Name)//判断窗口是否打开
                {
                    frm.Activate();//激活窗口
                    frm.WindowState = FormWindowState.Normal;//居中显示
                    return;//如果窗口已打开就放回方法
                }
            }
            Openfrom.Show();
            Openfrom.Text = Name;
            SkinLabel Label_Text = (SkinLabel)(from Control pi in Openfrom.Controls where pi is SkinLabel select pi).First();
            Label_Text.Text = Name;
        }
    }
}
