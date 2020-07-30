using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <本类用于处理GroupBox四边形方框类进行数据查询修改等操作>    
    class GroupBox_EF
    {
        public static string GroupBox_Parameter_inquire(string ID)//四边形方框类参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                GroupBox_Class label_Class = model.GroupBox_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (label_Class != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public GroupBox_Class GroupBox_Parameter_Query(string ID)//查询四边形方框类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                GroupBox_Class GroupBox_Class = model.GroupBox_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return GroupBox_Class;//返回查询结果
            }
        }
        public GroupBox_Class GroupBox_Parameter_Query(string ID, string From)//查询四边形方框类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                GroupBox_Class GroupBox_Class = model.GroupBox_Class.Where(pi => pi.ID == ID & pi.FORM == From).FirstOrDefault();//查询数据库是否有该ID
                return GroupBox_Class;//返回查询结果
            }
        }
        public string GroupBox_Parameter_Add(GroupBox_parameter parameter)//四边形方框类主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                GroupBox_parameter GroupBox_Parameter = model.GroupBox_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (GroupBox_Parameter == null)
                {
                    GroupBox_parameter parameter1 = new GroupBox_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.GroupBox_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string GroupBox_Parameter_Add(Tag_common_parameters parameter)//四边形方框类--主参数--字体参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Tag_common_parameters GroupBox_Parameter = model.Tag_common_parameters.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (GroupBox_Parameter == null)
                {
                    Tag_common_parameters parameter1 = new Tag_common_parameters();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.Tag_common_parameters.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string GroupBox_Parameter_Add(control_location parameter)//四边形方框类位置坐标参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                control_location GroupBox_Parameter = model.control_location.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (GroupBox_Parameter == null)
                {
                    control_location parameter1 = new control_location();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.control_location.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string GroupBox_Parameter_Add(Button_colour parameter)//四边形方框类颜色参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Button_colour button_Parameter = model.Button_colour.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_Parameter == null)
                {
                    Button_colour parameter1 = new Button_colour();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.Button_colour.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string GroupBox_Parameter_delete(string ID)//四边形方框类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除按钮类主参数操作
                GroupBox_parameter GroupBox_Parameter = model.GroupBox_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (GroupBox_Parameter != null)
                {
                    model.GroupBox_parameter.Remove(GroupBox_Parameter);////构造添加表的SQL语句
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
                //执行删除按钮样式参数操作
                Button_colour Button_colour = model.Button_colour.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (Button_colour != null)
                {
                    model.Button_colour.Remove(Button_colour);////构造添加表的SQL语句              
                    model.SaveChanges();//执行操作
                }
                if (button_parameters != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string label_Parameter_modification(string ID, GroupBox_parameter GroupBox_Parameter, Tag_common_parameters tag_Common_, control_location _Location, Button_colour button_)//四边形方框类ID修改参数
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
                //执行修改按钮样式参数操作
                Button_colour Button_colour = model.Button_colour.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (Button_colour != null)
                {
                    #region 要修改的属性
                    Button_colour.colour_0 = button_.colour_0;//获取对象
                    Button_colour.colour_1 = button_.colour_1;//获取对象
                    #endregion
                    model.SaveChanges();//执行操作
                }
                if (button_parameters != null)
                    return "OK";
                else
                    return "NG";
            }
        }
    }
}
