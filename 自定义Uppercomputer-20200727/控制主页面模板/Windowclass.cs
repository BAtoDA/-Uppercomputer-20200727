using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace 自定义Uppercomputer_20200727.控制主页面模板
{
    /// <页面转换处理>
    class Windowclass: IDisposable
    {
        private Form Openfrom_1;
        // private string[] FromnamTexe = new string[] { "主画面", "手动画面", "异常画面", "监视画面", "运转画面", "生产设置", "参数设置" };
        public Windowclass(Form Present, SkinButton[] Buttons, Form[] Formlist, SkinLabel Fromname, SkinButton skinButton)
        {      
            for (int i = 0; i < Formlist.Length; i++)
            {
                if (Buttons[i].Name == skinButton.Name)
                {
                    foreach (var Form_dispose in Formlist)
                    {
                        if (Formlist[i].Name != Form_dispose.Name)
                            Form_dispose.Close();
                    }
                    Fromtraverse(Present, Formlist[i], Buttons[i].Text);
                }
            }
        }
        private void Fromtraverse(Form Present, Form Openfrom, string Name)
        {
            foreach (Form frm in Application.OpenForms)//遍历所有窗口
            {
                if (frm.Name == Openfrom.Name)//判断窗口是否打开
                {
                    frm.Activate();//激活窗口
                    frm.WindowState = FormWindowState.Normal;//居中显示
                    //frm.WindowState = FormWindowState.Maximized;//开机最大化
                    Openfrom.Close();
                    return;//如果窗口已打开就放回方法
                }
            }
            this.Openfrom_1 = Openfrom;
            Openfrom.Show();
            Openfrom.WindowState = FormWindowState.Normal;//居中显示
            //Openfrom.Size = new System.Drawing.Size(1071, 745);//设置窗口大小
            Openfrom.BackgroundImageLayout = ImageLayout.Stretch; //自动适应
            Openfrom.Text = Name;
            SkinLabel Label_Text = (SkinLabel)(from Control pi in Openfrom.Controls where pi is SkinLabel select pi).First();
            Label_Text.Text = Name;
        }
        static public void Release(Form Openfrom)
        {
            if (Openfrom.IsNull()) return;
            FormCollection formCollection = Application.OpenForms;//获取窗口集合
            for (int i = 0; i < formCollection.Count; i++)
            {
                if (formCollection[i].Text != "Home" & formCollection[i].Text != Openfrom.Text)//关闭其余窗口
                {
                    formCollection[i].Close();//关闭窗口     
                }
            }
        }
        //这里实现IDisposable 接口
        public Windowclass()
        {
            Dispose(false);
        }
        //是否回收完毕
        bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //这里的参数表示示是否需要释放那些实现IDisposable接口的托管对象
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return; //如果已经被回收，就中断执行
            if (disposing)
            {
                //TODO:释放那些实现IDisposable接口的托管对象
                Release(this.Openfrom_1);
            }
            //TODO:释放非托管资源，设置对象为null
            _disposed = true;
        }
    }
}
