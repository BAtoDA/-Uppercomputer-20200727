using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <summary>
    /// AnalogMeter-控件对数据库增删改查
    /// </summary>
    class AnalogMeter_EF
    {
        public static string AnalogMeter_Parameter_inquire(string ID)//百分百表盘类参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                AnalogMeter_Class oscillogram_Chart_Class = model.AnalogMeter_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (oscillogram_Chart_Class != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public AnalogMeter_Class AnalogMeter_Parameter_Query(string ID)//查询百分百表盘类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                AnalogMeter_Class AnalogMeter_Class = model.AnalogMeter_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return AnalogMeter_Class;//返回查询结果
            }
        }
        public AnalogMeter_Class AnalogMeter_Parameter_Query(string ID, string From)//查询百分百表盘类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                AnalogMeter_Class AnalogMeter_Class = model.AnalogMeter_Class.Where(pi => pi.ID == ID & pi.FORM == From).FirstOrDefault();//查询数据库是否有该ID
                return AnalogMeter_Class;//返回查询结果
            }
        }
        public string AnalogMeter_Parameter_Add(AnalogMeter_parameter parameter)//百分百表盘类主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                AnalogMeter_parameter AnalogMeter_Parameter = model.AnalogMeter_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (AnalogMeter_Parameter == null)
                {
                    AnalogMeter_parameter parameter1 = new AnalogMeter_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.AnalogMeter_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string AnalogMeter_Parameter_Add(Tag_common_parameters parameter)//百分百表盘类--主参数--字体参数插入
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
        public string AnalogMeter_Parameter_Add(control_location parameter)//百分百表盘类位置坐标参数插入
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
        public string AnalogMeter_Parameter_delete(string ID)//百分百表盘类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除按钮类主参数操作
                AnalogMeter_parameter AnalogMeter_Parameter = model.AnalogMeter_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (AnalogMeter_Parameter != null)
                {
                    model.AnalogMeter_parameter.Remove(AnalogMeter_Parameter);////构造添加表的SQL语句
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
        public string AnalogMeter_modification(string ID, AnalogMeter_parameter _Parameter, Tag_common_parameters tag_Common_, control_location _Location)//百分百表盘类ID修改参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {

                //执行修改按钮类主参数操作
                AnalogMeter_parameter histogram_parameter = model.AnalogMeter_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID                 
                #region 要修改的属性
                histogram_parameter.小数点以下位数 = _Parameter.小数点以下位数;//获取对象
                histogram_parameter.数据类型 = _Parameter.数据类型;//获取对象
                histogram_parameter.写设备_地址_具体地址_复选 = _Parameter.写设备_地址_具体地址_复选;//获取对象
                histogram_parameter.写设备_地址_复选 = _Parameter.写设备_地址_复选;//获取对象
                histogram_parameter.写设备_复选 = _Parameter.写设备_复选;//获取对象
                histogram_parameter.操作安全时间 = _Parameter.操作安全时间;//获取对象
                histogram_parameter.小数点以上位数 = _Parameter.小数点以上位数;//获取对象
                histogram_parameter.读写不同地址_ON_OFF = _Parameter.读写不同地址_ON_OFF;//获取对象
                histogram_parameter.读写设备 = _Parameter.读写设备;//获取对象
                histogram_parameter.读写设备_地址 = _Parameter.读写设备_地址;//获取对象
                histogram_parameter.读写设备_地址_具体地址 = _Parameter.读写设备_地址_具体地址;//获取对象
                histogram_parameter.资料格式 = _Parameter.资料格式;//获取对象     
                histogram_parameter.Min = _Parameter.Min;//获取设置最小值
                histogram_parameter.Max = _Parameter.Max;//获取设置最大值
                histogram_parameter.刷新时间 = _Parameter.刷新时间;//获取设置刷新时间
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
