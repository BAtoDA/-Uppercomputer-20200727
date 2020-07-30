using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <summary>
    /// 本类用于控件最上层-与最下层--进行数据库查询
    /// </summary>
    class Control_layer_EF
    {
        public List<Control_layer> all_Parameter_Query_Control_layer(string From)//查询那些控件有最上层-否则默认最下层
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.Control_layer.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public void all_Parameter_Query_delete(string ID)//查询该ID控件然后移除数据
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
               Control_layer control_Layer= model.Control_layer.Where(pi => pi.ID==ID).Select(PI => PI).FirstOrDefault();//查询数据库是否有该FROM返回查询结果  
                if(control_Layer.IsNull()!=true)
                {
                    model.Control_layer.Remove(control_Layer);//移除该ID数据
                    model.SaveChanges();
                }
            }
        }
        public void all_Parameter_Query_Add(string ID,string Name,int Data)//查询该ID控件然后插入数据如果有该数据就作为修改提交到数据库
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Control_layer control_Layer = model.Control_layer.Where(pi => pi.ID == ID).Select(PI => PI).FirstOrDefault();//查询数据库是否有该FROM返回查询结果  
                if (control_Layer.IsNull())
                {
                    Control_layer control_Layer1 = new Control_layer
                    {
                        ID = ID,
                        type = Name,
                        Upper_layer = Data,
                        FORM = FORM_segmentation(ID).Trim()
                    };
                    model.Control_layer.Add(control_Layer1);
                    model.SaveChanges();
                }
                else
                {
                    control_Layer.Upper_layer = Data;
                    model.SaveChanges();
                }
            }
        }
        private string FORM_segmentation(string Data)//把ID进行数据分割--获取所在窗口的ID
        {
            //string[] segmentation = Data.Split('.');//第一次分割
            //string[] FORM = new string[5];
            //if (segmentation.Length > 2) FORM= segmentation[2].Split(',');//第二次分割
            //return FORM[0];//返回数据
            string[] Name = Data.Split('.');
            string[] Name_1 = new string[2];
            if (Name.Length > 2)
            {
                Name_1 = Name[2].Split(',');
            }
            else
            {
                string[] Name_2 = Name[1].Split(':');
                Name_1 = Name_2[1].Split('-');
            }
            return Name_1[0].Trim();//返回
        }
    }
}
