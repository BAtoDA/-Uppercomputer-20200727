using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <summary>
    /// 实现RadioButton 单选按钮类对EF模型进行增删改查
    /// </summary>
    class RadioButton_EF
    {
        public static string Button_Parameter_inquire(string ID)//切换开关类参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                RadioButton_Class RadioButton_Parameter = model.RadioButton_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (RadioButton_Parameter != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string Button_Parameter_Add(RadioButton_parameter parameter)//切换开关类主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                RadioButton_parameter RadioButton_Parameter = model.RadioButton_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (RadioButton_Parameter == null)
                {
                    RadioButton_parameter parameter1 = new RadioButton_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.RadioButton_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string Button_Parameter_Add(Tag_common_parameters parameter)//切换开关类字体参数插入
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
        public string Button_Parameter_Add(General_parameters_of_picture parameter)//切换开关类图片参数插入
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
        public string Button_Parameter_Add(control_location parameter)//切换开关类位置坐标参数插入
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
        public string Button_Parameter_Add(Button_colour parameter)//按钮类按钮类颜色参数插入
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
        public RadioButton_Class Button_Parameter_Query(string ID)//查询切换开关类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                RadioButton_Class button_Class = model.RadioButton_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return button_Class;//返回查询结果
            }
        }

        public string Button_Parameter_delete(string ID)//切换开关类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除切换开关类主参数操作
                RadioButton_parameter RadioButton_Parameter = model.RadioButton_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (RadioButton_Parameter != null)
                {
                    model.RadioButton_parameter.Remove(RadioButton_Parameter);////构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
                //执行删除切换开关类字体参数操作
                Tag_common_parameters button_parameters = model.Tag_common_parameters.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID  
                if (button_parameters != null)
                {
                    model.Tag_common_parameters.Remove(button_parameters);////构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
                //执行删除切换开关类图片参数操作
                General_parameters_of_picture button_parameters_of_picture = model.General_parameters_of_picture.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_parameters_of_picture != null)
                {
                    model.General_parameters_of_picture.Remove(button_parameters_of_picture);////构造添加表的SQL语句              
                    model.SaveChanges();//执行操作
                }
                //执行删除切换开关类坐标参数操作
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
                if (RadioButton_Parameter != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string Button_Parameter_modification(string ID, RadioButton_parameter _Parameter, Tag_common_parameters tag_Common_,
            General_parameters_of_picture _Of_Picture, control_location _Location, Button_colour button_)//切换开关类ID修改参数
        {

            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行修改切换开关类主参数操作
                RadioButton_parameter RadioButton_parameter = model.RadioButton_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (RadioButton_parameter != null)
                {
                    #region 要修改的属性
                    RadioButton_parameter.位切换开关 = _Parameter.位切换开关;//获取对象
                    RadioButton_parameter.位指示灯 = _Parameter.位指示灯;//获取对象
                    RadioButton_parameter.写设备_地址_具体地址_复选 = _Parameter.写设备_地址_具体地址_复选;//获取对象
                    RadioButton_parameter.写设备_地址_复选 = _Parameter.写设备_地址_复选;//获取对象
                    RadioButton_parameter.写设备_复选 = _Parameter.写设备_复选;//获取对象
                    RadioButton_parameter.操作安全时间 = _Parameter.操作安全时间;//获取对象
                    RadioButton_parameter.操作模式 = _Parameter.操作模式;//获取对象
                    RadioButton_parameter.读写不同地址_ON_OFF = _Parameter.读写不同地址_ON_OFF;//获取对象
                    RadioButton_parameter.读写设备 = _Parameter.读写设备;//获取对象
                    RadioButton_parameter.读写设备_地址 = _Parameter.读写设备_地址;//获取对象
                    RadioButton_parameter.读写设备_地址_具体地址 = _Parameter.读写设备_地址_具体地址;//获取对象
                    #endregion
                    model.SaveChanges();//执行操作
                }
                //执行修改切换开关类字体参数操作
                Tag_common_parameters button_parameters = model.Tag_common_parameters.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_parameters != null)
                {
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
                }
                //执行修改切换开关类图片参数操作
                General_parameters_of_picture button_parameters_of_picture = model.General_parameters_of_picture.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_parameters_of_picture != null)
                {
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
                }
                //执行修改按钮类坐标参数操作
                control_location button_control_location = model.control_location.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_control_location != null)
                {
                    #region 要修改的属性
                    button_control_location.location = _Location.location;//获取对象
                    button_control_location.size = _Location.size;//获取对象
                    #endregion
                    model.SaveChanges();//执行操作
                }
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
                if (RadioButton_parameter != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string Button_Parameter_modification(string ID, control_location _Location)//切换开关类ID修改参数--坐标参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行修改切换开关类坐标参数操作
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
