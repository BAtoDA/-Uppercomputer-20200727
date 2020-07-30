using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <summary>
    /// oscillogram_Chart_reform控件--对数据库进行增删改查
    /// </summary>
    class oscillogram_Chart_EF
    {
        public static string oscillogram_Chart_Parameter_inquire(string ID)//折线图类参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                oscillogram_Chart_Class oscillogram_Chart_Class = model.oscillogram_Chart_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (oscillogram_Chart_Class != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public oscillogram_Chart_Class oscillogram_Chart_Parameter_Query(string ID)//查询折线图类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                oscillogram_Chart_Class oscillogram_Chart_Class = model.oscillogram_Chart_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return oscillogram_Chart_Class;//返回查询结果
            }
        }
        public oscillogram_Chart_Class oscillogram_Chart_Parameter_Query(string ID, string From)//查询折线图类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                oscillogram_Chart_Class oscillogram_Chart_Class = model.oscillogram_Chart_Class.Where(pi => pi.ID == ID & pi.FORM == From).FirstOrDefault();//查询数据库是否有该ID
                return oscillogram_Chart_Class;//返回查询结果
            }
        }
        public string oscillogram_Chart_Parameter_Add(oscillogram_Chart_parameter parameter)//折线图类主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                oscillogram_Chart_parameter oscillogram_Parameter = model.oscillogram_Chart_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (oscillogram_Parameter == null)
                {
                    oscillogram_Chart_parameter parameter1 = new oscillogram_Chart_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.oscillogram_Chart_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string oscillogram_Chart_Parameter_Add(Tag_common_parameters parameter)//折线图类--主参数--字体参数插入
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
        public string oscillogram_Chart_Parameter_Add(control_location parameter)//折线图类位置坐标参数插入
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
        public string oscillogram_Chart_Parameter_Add(Button_colour parameter)//折线图类颜色参数插入
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
        public string oscillogram_Chart_Parameter_delete(string ID)//折线图类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除按钮类主参数操作
                oscillogram_Chart_parameter oscillogram_Chart_Parameter = model.oscillogram_Chart_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (oscillogram_Chart_Parameter != null)
                {
                    model.oscillogram_Chart_parameter.Remove(oscillogram_Chart_Parameter);////构造添加表的SQL语句
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
        public string oscillogram_Chart_modification(string ID, oscillogram_Chart_parameter _Parameter, Tag_common_parameters tag_Common_, control_location _Location, Button_colour button_)//折线图类ID修改参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {

                //执行修改按钮类主参数操作
                oscillogram_Chart_parameter histogram_parameter = model.oscillogram_Chart_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID                 
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
                histogram_parameter.通道数量 = _Parameter.通道数量;//获取要修改的通道数量
                histogram_parameter.Name_Text = _Parameter.Name_Text;     //获取设置通道名称      
                histogram_parameter.Min = _Parameter.Min;//获取设置最小值
                histogram_parameter.Max = _Parameter.Max;//获取设置最大值
                histogram_parameter.刷新时间 = _Parameter.刷新时间;//获取设置刷新时间
                histogram_parameter.折线图_曲线图 = _Parameter.折线图_曲线图;//获取设置是否折线图/波形图
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
