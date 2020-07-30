using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <summary>
    /// 二维码/条形码 ihatetheqrcode控件对数据库进行增删改查
    /// </summary>
    class ihatetheqrcode_EF
    {
        public static string ihatetheqrcode_Parameter_inquire(string ID)//二维码/条形码类参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                ihatetheqrcode_Class ihatetheqrcode_Parameter = model.ihatetheqrcode_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (ihatetheqrcode_Parameter != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string ihatetheqrcode_Parameter_Add(ihatetheqrcode_parameter parameter)//二维码/条形码类主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                ihatetheqrcode_parameter ihatetheqrcode_Parameter = model.ihatetheqrcode_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (ihatetheqrcode_Parameter == null)
                {
                    ihatetheqrcode_parameter parameter1 = new ihatetheqrcode_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.ihatetheqrcode_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string ihatetheqrcode_Parameter_Add(Tag_common_parameters parameter)//二维码/条形码类字体参数插入
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
        public string ihatetheqrcode_Parameter_Add(General_parameters_of_picture parameter)//二维码/条形码类图片参数插入
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
        public string ihatetheqrcode_Parameter_Add(control_location parameter)//二维码/条形码类位置坐标参数插入
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
        public ihatetheqrcode_Class ihatetheqrcode_Parameter_Query(string ID)//查询二维码/条形码类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                ihatetheqrcode_Class ihatetheqrcode_Class = model.ihatetheqrcode_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return ihatetheqrcode_Class;//返回查询结果
            }
        }
        public ihatetheqrcode_Class ihatetheqrcode_Parameter_Query(string ID, string From)//查询数值软件类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                ihatetheqrcode_Class numerical_Class = model.ihatetheqrcode_Class.Where(pi => pi.ID == ID & pi.FORM == From).FirstOrDefault();//查询数据库是否有该ID
                return numerical_Class;//返回查询结果
            }
        }
        public string ihatetheqrcode_Parameter_delete(string ID)//二维码/条形码类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除按钮类主参数操作
                ihatetheqrcode_parameter ihatetheqrcode_Parameter = model.ihatetheqrcode_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (ihatetheqrcode_Parameter != null)
                {
                    model.ihatetheqrcode_parameter.Remove(ihatetheqrcode_Parameter);////构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
                //执行删除按钮类字体参数操作
                Tag_common_parameters button_parameters = model.Tag_common_parameters.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID  
                if (button_parameters != null)
                {
                    model.Tag_common_parameters.Remove(button_parameters);////构造添加表的SQL语句
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
                if (ihatetheqrcode_Parameter != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string ihatetheqrcode_Parameter_modification(string ID, ihatetheqrcode_parameter _Parameter, Tag_common_parameters tag_Common_,
     General_parameters_of_picture _Of_Picture, control_location _Location)//二维码/条形码类ID修改参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行修改按钮类主参数操作
                ihatetheqrcode_parameter numerical_parameter = model.ihatetheqrcode_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID                 
                #region 要修改的属性
                numerical_parameter.小数点以下位数 = _Parameter.小数点以下位数;//获取对象
                numerical_parameter.数据类型 = _Parameter.数据类型;//获取对象
                numerical_parameter.写设备_地址_具体地址_复选 = _Parameter.写设备_地址_具体地址_复选;//获取对象
                numerical_parameter.写设备_地址_复选 = _Parameter.写设备_地址_复选;//获取对象
                numerical_parameter.写设备_复选 = _Parameter.写设备_复选;//获取对象
                numerical_parameter.操作安全时间 = _Parameter.操作安全时间;//获取对象
                numerical_parameter.小数点以上位数 = _Parameter.小数点以上位数;//获取对象
                numerical_parameter.读写不同地址_ON_OFF = _Parameter.读写不同地址_ON_OFF;//获取对象
                numerical_parameter.读写设备 = _Parameter.读写设备;//获取对象
                numerical_parameter.读写设备_地址 = _Parameter.读写设备_地址;//获取对象
                numerical_parameter.读写设备_地址_具体地址 = _Parameter.读写设备_地址_具体地址;//获取对象
                numerical_parameter.资料格式 = _Parameter.资料格式;//获取对象
                numerical_parameter.二维码_条形码 = _Parameter.二维码_条形码;//条形码类型
                numerical_parameter.显示宽_高 = _Parameter.显示宽_高;//条形码高度
                #endregion
                model.SaveChanges();//执行操作
                //执行修改按钮类字体参数操作
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
                if (numerical_parameter != null)
                    return "OK";
                else
                    return "NG";
            }
        }
    }
}
