using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;

namespace 自定义Uppercomputer_20200727.字体
{
    /// <本类用于处理软件控件字体>    
    class typeface
    {
       public static List<string> typeface_win=new List<string>();//获取系统字体-这段代码是用来搞笑的-好后续维护
       public typeface()
        {
            Load(ref typeface_win);
        }
        private void Load(ref List<string> typeface_win)//遍历系统字体
        {
            InstalledFontCollection MyFont = new InstalledFontCollection();
            FontFamily[] FontFamily = MyFont.Families;
            foreach (FontFamily i in FontFamily)
                typeface_win.Add(i.Name);//添加到泛型中
            MyFont.Dispose();
            FontFamily.Clone();
        }
    }
}
