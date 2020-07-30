using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.EF实体模型;
using 自定义Uppercomputer_20200727.字体;

namespace 自定义Uppercomputer_20200727.主页面
{
    /// <主页面处理>
    /// <主页面显示名称>
    class Homepag_class
    {
        int indexes { get; set; }
        public Homepag_class(Form Homepage)
        {
            List <Profile> Quer = EF_HomepagQuery();
            if (Quer.Count>0)
            {
                PictureBox Profile_picture =(PictureBox)(from Control pi in Homepage.Controls where pi is PictureBox select pi).First();
                SkinLabel Profile_Text = (SkinLabel)(from Control pi in Homepage.Controls where pi is SkinLabel select pi).First();
            }
            _ = new typeface();//获取系统字体
        }
        /// <查询主页面参数--ID--图片--主页显示名称>
        public List<Profile> EF_HomepagQuery()
        {
          using(UppercomputerEntities2 model =new UppercomputerEntities2())
            {
                return (from pi in model.Profile select pi).ToList();
            }
        }
        //二进制转图片
        public Image ReturnPhoto(byte[] bit)
        {            
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bit);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            ms.Dispose();
            return img;
        }
        //转换成二进制数据，并保存到数据库
      
    }
}
