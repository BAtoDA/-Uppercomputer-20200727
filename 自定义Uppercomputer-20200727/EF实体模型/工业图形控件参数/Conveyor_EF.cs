using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型.工业图形控件参数
{
    /// <summary>
    /// 用于处理Conveyor运输带图形参数
    /// 控件对数据库增删改查
    /// </summary>
    class Conveyor_EF
    {
        public static string Conveyor_Parameter_inquire(string ID)//运输带类参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Conveyor_Class Conveyor_Class = model.Conveyor_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (Conveyor_Class != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public Conveyor_Class Conveyor_Parameter_Query(string ID)//查询运输带类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Conveyor_Class Conveyor_Class = model.Conveyor_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return Conveyor_Class;//返回查询结果
            }
        }
        public Conveyor_Class Conveyor_Parameter_Query(string ID, string From)//查询运输带类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Conveyor_Class Conveyor_Class = model.Conveyor_Class.Where(pi => pi.ID == ID & pi.FORM == From).FirstOrDefault();//查询数据库是否有该ID
                return Conveyor_Class;//返回查询结果
            }
        }
        public string Conveyor_Parameter_Add(Conveyor_parameter parameter)//运输带类主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Conveyor_parameter AnalogMeter_Parameter = model.Conveyor_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (AnalogMeter_Parameter == null)
                {
                    Conveyor_parameter parameter1 = new Conveyor_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.Conveyor_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string Conveyor_Parameter_Add(Tag_common_parameters parameter)//运输带类--主参数--字体参数插入
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
        public string Conveyor_Parameter_Add(control_location parameter)//运输带类位置坐标参数插入
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
        public string Conveyor_Parameter_delete(string ID)//运输带类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除按钮类主参数操作
                Conveyor_parameter Conveyor_Parameter = model.Conveyor_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (Conveyor_Parameter != null)
                {
                    model.Conveyor_parameter.Remove(Conveyor_Parameter);////构造添加表的SQL语句
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
                if (button_parameters != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string Conveyor_modification(string ID, Conveyor_parameter _Parameter, Tag_common_parameters tag_Common_, control_location _Location)//运输带类ID修改参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {

                //执行修改按钮类主参数操作
                Conveyor_parameter Conveyor_parameter = model.Conveyor_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID                 
                #region 要修改的属性
                Conveyor_parameter.小数点以下位数 = _Parameter.小数点以下位数;//获取对象
                Conveyor_parameter.数据类型 = _Parameter.数据类型;//获取对象
                Conveyor_parameter.写设备_地址_具体地址_复选 = _Parameter.写设备_地址_具体地址_复选;//获取对象
                Conveyor_parameter.写设备_地址_复选 = _Parameter.写设备_地址_复选;//获取对象
                Conveyor_parameter.写设备_复选 = _Parameter.写设备_复选;//获取对象
                Conveyor_parameter.操作安全时间 = _Parameter.操作安全时间;//获取对象
                Conveyor_parameter.小数点以上位数 = _Parameter.小数点以上位数;//获取对象
                Conveyor_parameter.读写不同地址_ON_OFF = _Parameter.读写不同地址_ON_OFF;//获取对象
                Conveyor_parameter.读写设备 = _Parameter.读写设备;//获取对象
                Conveyor_parameter.读写设备_地址 = _Parameter.读写设备_地址;//获取对象
                Conveyor_parameter.读写设备_地址_具体地址 = _Parameter.读写设备_地址_具体地址;//获取对象
                Conveyor_parameter.资料格式 = _Parameter.资料格式;//获取对象     
                Conveyor_parameter.设备控制方向 = _Parameter.设备控制方向;//获取对象
                Conveyor_parameter.设备读取数据控制 = _Parameter.设备读取数据控制;//获取对象
                Conveyor_parameter.运输带方向 = _Parameter.运输带方向;//获取对象
                Conveyor_parameter.运输带角度 = _Parameter.运输带角度;//获取对象
                Conveyor_parameter.运输带速度 = _Parameter.运输带速度;//获取对象
                Conveyor_parameter.运输带颜色 = _Parameter.运输带颜色;//获取对象
                Conveyor_parameter.运输带高度 = _Parameter.运输带高度;//获取对象
                #endregion
                model.SaveChanges();//执行操作
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
    }
}
