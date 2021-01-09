using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型.工业图形控件参数
{
    /// <summary>
    /// 用于处理工业图形
    /// Valve 流体阀门控件对数据库增删改查
    /// </summary>
    class Valve_EF
    {
        public static string Valve_Parameter_inquire(string ID)//流体阀门类参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Valve_Class Valve_Class = model.Valve_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (Valve_Class != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public Valve_Class Valve_Parameter_Query(string ID)//查询流体阀门类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Valve_Class Valve_Class = model.Valve_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return Valve_Class;//返回查询结果
            }
        }
        public Valve_Class Valve_Parameter_Query(string ID, string From)//查询流体阀门类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Valve_Class Valve_Class = model.Valve_Class.Where(pi => pi.ID == ID & pi.FORM == From).FirstOrDefault();//查询数据库是否有该ID
                return Valve_Class;//返回查询结果
            }
        }
        public string Valve_Parameter_Add(Valve_parameter parameter)//流体阀门类主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                Valve_parameter Valve_Parameter = model.Valve_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (Valve_Parameter == null)
                {
                    Valve_parameter parameter1 = new Valve_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.Valve_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string Valve_Parameter_Add(Tag_common_parameters parameter)//流体阀门类--主参数--字体参数插入
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
        public string Valve_Parameter_Add(control_location parameter)//流体阀门类位置坐标参数插入
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
        public string Valve_Parameter_delete(string ID)//流体阀门类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除按钮类主参数操作
                Valve_parameter Valve_Parameter = model.Valve_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (Valve_Parameter != null)
                {
                    model.Valve_parameter.Remove(Valve_Parameter);////构造添加表的SQL语句
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
        public string Valve_modification(string ID, Valve_parameter _Parameter, Tag_common_parameters tag_Common_, control_location _Location)//流体阀门类ID修改参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {

                //执行修改按钮类主参数操作
                Valve_parameter Valve_parameter = model.Valve_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID                 
                #region 要修改的属性
                Valve_parameter.小数点以下位数 = _Parameter.小数点以下位数;//获取对象
                Valve_parameter.数据类型 = _Parameter.数据类型;//获取对象
                Valve_parameter.写设备_地址_具体地址_复选 = _Parameter.写设备_地址_具体地址_复选;//获取对象
                Valve_parameter.写设备_地址_复选 = _Parameter.写设备_地址_复选;//获取对象
                Valve_parameter.写设备_复选 = _Parameter.写设备_复选;//获取对象
                Valve_parameter.操作安全时间 = _Parameter.操作安全时间;//获取对象
                Valve_parameter.小数点以上位数 = _Parameter.小数点以上位数;//获取对象
                Valve_parameter.读写不同地址_ON_OFF = _Parameter.读写不同地址_ON_OFF;//获取对象
                Valve_parameter.读写设备 = _Parameter.读写设备;//获取对象
                Valve_parameter.读写设备_地址 = _Parameter.读写设备_地址;//获取对象
                Valve_parameter.读写设备_地址_具体地址 = _Parameter.读写设备_地址_具体地址;//获取对象
                Valve_parameter.资料格式 = _Parameter.资料格式;//获取对象     
                Valve_parameter.开关把手颜色 = _Parameter.开关把手颜色;//获取对象
                Valve_parameter.液体流动方向 = _Parameter.液体流动方向;//获取对象
                Valve_parameter.液体流速 = _Parameter.液体流速;//获取对象
                Valve_parameter.液体流速自动控制 = _Parameter.液体流速自动控制;//获取对象
                Valve_parameter.液体颜色 = _Parameter.液体颜色;//获取对象
                Valve_parameter.轴底座颜色 = _Parameter.轴底座颜色;//获取对象
                Valve_parameter.轴颜色 = _Parameter.轴颜色;//获取对象
                Valve_parameter.阀门 = _Parameter.阀门;//获取对象
                Valve_parameter.阀门样式= _Parameter.阀门样式;//获取对象
                Valve_parameter.阀门自动控制= _Parameter.阀门自动控制;//获取对象
                Valve_parameter.阀门颜色 = _Parameter.阀门颜色;//获取对象
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
