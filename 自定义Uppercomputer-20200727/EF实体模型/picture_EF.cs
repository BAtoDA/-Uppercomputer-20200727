using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <本类用于处理picture类进行数据查询修改等操作>    
    class picture_EF
    {
        public static string picture__Parameter_inquire(string ID)//图片类参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                picture_Class picture_Class = model.picture_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (picture_Class != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public picture_Class picture_Parameter_Query(string ID)//查询图片类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                picture_Class picture_Class = model.picture_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return picture_Class;//返回查询结果
            }
        }
        public picture_Class Button_Parameter_Query(string ID, string From)//查询图片类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                picture_Class picture_Class = model.picture_Class.Where(pi => pi.ID == ID & pi.FORM == From).FirstOrDefault();//查询数据库是否有该ID
                return picture_Class;//返回查询结果
            }
        }
        public string picture_Parameter_Add(picture_parameter parameter)//图片类主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                picture_parameter button_Parameter = model.picture_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_Parameter == null)
                {
                    picture_parameter parameter1 = new picture_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.picture_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string picture_Parameter_Add(General_parameters_of_picture parameter)//图片类图片参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                General_parameters_of_picture button_Parameter = model.General_parameters_of_picture.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_Parameter == null)
                {
                    General_parameters_of_picture parameter1 = new General_parameters_of_picture();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.General_parameters_of_picture.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string picture_Parameter_Add(control_location parameter)//图片类位置坐标参数插入
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
        public string picture_Parameter_delete(string ID)//图片类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除主参数操作
                picture_parameter picture_Parameter = model.picture_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (picture_Parameter != null)
                {
                    model.picture_parameter.Remove(picture_Parameter);////构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
                //执行删除按钮类图片参数操作
                General_parameters_of_picture button_parameters_of_picture = model.General_parameters_of_picture.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_parameters_of_picture != null)
                {
                    model.General_parameters_of_picture.Remove(button_parameters_of_picture);////构造添加表的SQL语句              
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
                if (button_parameters_of_picture != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string picture_Parameter_modification(string ID, picture_parameter _Parameter, General_parameters_of_picture _Of_Picture, control_location _Location)//图片类ID修改参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行修改按钮类图片参数操作
                General_parameters_of_picture button_parameters_of_picture = model.General_parameters_of_picture.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID 
                #region 要修改的属性
                button_parameters_of_picture.Control_state_0 = _Of_Picture.Control_state_0;//获取对象
                button_parameters_of_picture.Control_state_0_list = _Of_Picture.Control_state_0_list;//获取对象
                button_parameters_of_picture.Control_state_0_picture = _Of_Picture.Control_state_0_picture;//获取对象
                button_parameters_of_picture.Control_state_1 = _Of_Picture.Control_state_1;//获取对象
                button_parameters_of_picture.Control_state_1_list = _Of_Picture.Control_state_1_list;//获取对象
                button_parameters_of_picture.Control_state_1_picture = _Of_Picture.Control_state_1_picture;//获取对象
                button_parameters_of_picture.Control_type = _Of_Picture.Control_type;//获取对象
                #endregion        
                model.SaveChanges();//执行操作
                //执行修改按钮类坐标参数操作
                control_location button_control_location = model.control_location.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                #region 要修改的属性
                button_control_location.location = _Location.location;//获取对象
                button_control_location.size = _Location.size;//获取对象
                #endregion       
                model.SaveChanges();//执行操作
                if (button_parameters_of_picture != null)
                    return "OK";
                else
                    return "NG";
            }
        }
    }
}
