using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <summary>
    /// <本类用于处理ScrollingText类进行数据查询修改等操作> 
    /// </summary>
    class ScrollingText_EF22
    {
        public static string ScrollingText_Parameter_inquire(string ID)//标签类参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                ScrollingText_Class ScrollingText_Class = model.ScrollingText_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (ScrollingText_Class != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public ScrollingText_Class ScrollingText_Parameter_Query(string ID)//查询标签类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                ScrollingText_Class ScrollingText_Class = model.ScrollingText_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return ScrollingText_Class;//返回查询结果
            }
        }
        public ScrollingText_Class ScrollingText_Parameter_Query(string ID, string From)//查询标签类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                ScrollingText_Class ScrollingText_Class = model.ScrollingText_Class.Where(pi => pi.ID == ID & pi.FORM == From).FirstOrDefault();//查询数据库是否有该ID
                return ScrollingText_Class;//返回查询结果
            }
        }
        public string ScrollingText_Parameter_Add(ScrollingText_parameter parameter)//标签类主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                ScrollingText_parameter ScrollingText_Parameter = model.ScrollingText_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (ScrollingText_Parameter == null)
                {
                    ScrollingText_parameter parameter1 = new ScrollingText_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.ScrollingText_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string ScrollingText_Parameter_Add(Tag_common_parameters parameter)//标签类--主参数--字体参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Tag_common_parameters button_Parameter = model.Tag_common_parameters.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_Parameter == null)
                {
                    Tag_common_parameters parameter1 = new Tag_common_parameters();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.Tag_common_parameters.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string ScrollingText_Parameter_Add(control_location parameter)//标签类位置坐标参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                control_location button_Parameter = model.control_location.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_Parameter == null)
                {
                    control_location parameter1 = new control_location();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.control_location.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string ScrollingText_Parameter_delete(string ID)//按钮类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除按钮类主参数操作
                ScrollingText_parameter ScrollingText_Parameter = model.ScrollingText_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (ScrollingText_Parameter != null)
                {
                    model.ScrollingText_parameter.Remove(ScrollingText_Parameter);////构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
                //执行删除按钮类字体参数操作
                Tag_common_parameters button_parameters = model.Tag_common_parameters.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID  
                if (button_parameters != null)
                {
                    model.Tag_common_parameters.Remove(button_parameters);////构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
                //执行删除按钮类坐标参数操作
                control_location button_control_location = model.control_location.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (button_control_location != null)
                {
                    model.control_location.Remove(button_control_location);////构造添加表的SQL语句              
                    model.SaveChanges();//执行操作
                }
                //执行删除上下层参数操作
                Control_layer Control_layer = model.Control_layer.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (Control_layer != null)
                {
                    model.Control_layer.Remove(Control_layer);////构造添加表的SQL语句              
                    model.SaveChanges();//执行操作
                }
                if (button_parameters != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string ScrollingText_Parameter_modification(string ID, Tag_common_parameters tag_Common_, control_location _Location)//标签类ID修改参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {

                //执行修改标签类字体参数操作
                Tag_common_parameters button_parameters = model.Tag_common_parameters.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                #region 要修改的属性
                button_parameters.Control_state_0 = tag_Common_.Control_state_0;//获取对象
                button_parameters.Control_state_0_aligning = tag_Common_.Control_state_0_aligning;//获取对象
                button_parameters.Control_state_0_colour = tag_Common_.Control_state_0_colour;//获取对象
                button_parameters.Control_state_0_content = tag_Common_.Control_state_0_content;//获取对象
                button_parameters.Control_state_0_flicker = tag_Common_.Control_state_0_flicker;//获取对象
                button_parameters.Control_state_0_size = tag_Common_.Control_state_0_size;//获取对象
                button_parameters.Control_state_0_typeface = tag_Common_.Control_state_0_typeface;//获取对象
                button_parameters.Control_state_1 = tag_Common_.Control_state_1;//获取对象
                button_parameters.Control_state_1_aligning = tag_Common_.Control_state_1_aligning;//获取对象
                button_parameters.Control_state_1_colour = tag_Common_.Control_state_1_colour;//获取对象
                button_parameters.Control_state_1_content1 = tag_Common_.Control_state_1_content1;//获取对象
                button_parameters.Control_state_1_flicker = tag_Common_.Control_state_1_flicker;//获取对象
                button_parameters.Control_state_1_size = tag_Common_.Control_state_1_size;//获取对象
                button_parameters.Control_state_1_typeface = tag_Common_.Control_state_1_typeface;//获取对象
                button_parameters.Control_type = tag_Common_.Control_type;//获取对象
                #endregion
                model.SaveChanges();//执行操作
                //执行修改标签类坐标参数操作
                control_location button_control_location = model.control_location.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                #region 要修改的属性
                button_control_location.location = _Location.location;//获取对象
                button_control_location.size = _Location.size;//获取对象
                #endregion       
                model.SaveChanges();//执行操作
                if (button_parameters != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string ScrollingText_Parameter_modification(string ID, control_location _Location)//按钮类ID修改参数--坐标参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行修改按钮类坐标参数操作
                control_location button_control_location = model.control_location.Where(pi => pi.ID.Trim() == ID.Trim()).FirstOrDefault();//查询数据库是否有该ID 
                if (button_control_location != null)
                {
                    #region 要修改的属性
                    button_control_location.location = _Location.location;//获取对象
                    button_control_location.size = _Location.size;//获取对象
                    #endregion
                    model.SaveChanges();//执行操作
                }
                if (button_control_location != null)
                    return "OK";
                else
                    return "NG";
            }
        }
    }
}
