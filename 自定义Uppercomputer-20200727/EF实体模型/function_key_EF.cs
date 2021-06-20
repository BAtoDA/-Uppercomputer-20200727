using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <summary>
    /// function_key功能键对数据库增删改查
    /// </summary>
    class function_key_EF
    {
        public static string function_key_Parameter_inquire(string ID)//功能键类参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                function_key_Class function_key_Class = model.function_key_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (function_key_Class != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public function_key_Class function_key_Parameter_Query(string ID)//功能键标签类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                function_key_Class function_key_Class = model.function_key_Class.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return function_key_Class;//返回查询结果
            }
        }
        public function_key_Class function_key_Parameter_Query(string ID, string From)//功能键标签类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                function_key_Class function_key_Class = model.function_key_Class.Where(pi => pi.ID == ID & pi.FORM == From).FirstOrDefault();//查询数据库是否有该ID
                return function_key_Class;//返回查询结果
            }
        }
        public string function_key_Parameter_Add(function_key_parameter parameter)//功能键类主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                function_key_parameter button_Parameter = model.function_key_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_Parameter == null)
                {
                    function_key_parameter parameter1 = new function_key_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.function_key_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public string function_key_Parameter_Add(Tag_common_parameters parameter)//功能键类--主参数--字体参数插入
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
        public string function_key_Parameter_Add(control_location parameter)//功能键类位置坐标参数插入
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
        public string function_key_Parameter_Add(Button_colour parameter)//按钮类按钮类颜色参数插入
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
        public string function_key_Parameter_delete(string ID)//功能键类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除按钮类主参数操作
                function_key_parameter function_key_Parameter = model.function_key_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (function_key_Parameter != null)
                {
                    model.function_key_parameter.Remove(function_key_Parameter);////构造添加表的SQL语句
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
        public string function_key_Parameter_modification(string ID, function_key_parameter function_key_Parameter, Tag_common_parameters tag_Common_, control_location _Location, Button_colour button_)//功能键类ID修改参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行修改功能键主属性
                function_key_parameter control = model.function_key_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                #region 要修改的属性
                control.OpenForm = function_key_Parameter.OpenForm;//获取对象
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

        [Obsolete]
        public string function_key_Parameter_Remove(string Form)//该方法是把功能键里面的所有控件全部移除
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //SQL Server 与 SQLlite 数据库切换
                int ie = 1;
                if (ie == 0)
                {
                    //SQL Server数据库代码
                    model.Button_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除button按钮控件信息
                    model.AnalogMeter_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除百分百表盘控件信息
                    model.Control_layer.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除Control_layer控件信息
                    model.doughnut_Chart_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除doughnut_Chart_parameter控件信息
                    model.GroupBox_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除GroupBox_parameter控件信息
                    model.histogram_Chart_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除histogram_Chart_parameter控件信息
                    model.ihatetheqrcode_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除ihatetheqrcode_parameter控件信息
                    model.ImageButton_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除ImageButton_parameter控件信息
                    model.label_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除label_parameter控件信息
                    model.LedBulb_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除LedBulb_parameter控件信息
                    model.LedDisplay_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除LedDisplay_parameter控件信息
                    model.numerical_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除numerical_parameter控件信息
                    model.oscillogram_Chart_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除oscillogram_Chart_parameter控件信息
                    model.ScrollingText_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除ScrollingText_parameter控件信息
                    model.Switch_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除Switch_parameter控件信息
                    model.RadioButton_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除RadioButton控件
                    model.Tag_common_parameters.Delete(pi => pi.FROM.Trim() == Form.Trim());//移除Tag_common_parameters字体信息
                    model.control_location.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除control_location位置信息
                    model.General_parameters_of_picture.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除General_parameters_of_picture图片信息
                    model.Button_colour.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除控件Button_colour背景颜色
                    model.HScrollBar_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除HScrollBar_parameter控件
                    model.Conveyor_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除Conveyor_parameter控件


                    model.pull_down_menu_parameter.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除pull_down_menu_parameter下拉菜单控件
                    model.pull_down_menuName.Delete(pi => pi.FORM.Trim() == Form.Trim());//移除.pull_down_menuName下拉菜单控件
                }
                else//SQLlite数据库代码
                {
                    //移除button按钮控件信息
                    foreach (var i in model.Button_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.Button_parameter.Remove(i);
                    //移除百分百表盘控件信息
                    foreach (var i in model.AnalogMeter_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.AnalogMeter_parameter.Remove(i);
                    //移除Control_layer控件信息
                    foreach (var i in model.Control_layer.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.Control_layer.Remove(i);
                    //移除doughnut_Chart_parameter控件信息
                    foreach (var i in model.doughnut_Chart_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.doughnut_Chart_parameter.Remove(i);
                    //移除GroupBox_parameter控件信息
                    foreach (var i in model.GroupBox_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.GroupBox_parameter.Remove(i);
                    //移除histogram_Chart_parameter控件信息
                    foreach (var i in model.histogram_Chart_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.histogram_Chart_parameter.Remove(i);
                    //移除ihatetheqrcode_parameter控件信息
                    foreach (var i in model.ihatetheqrcode_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.ihatetheqrcode_parameter.Remove(i);
                    //移除ImageButton_parameter控件信息
                    foreach (var i in model.ImageButton_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.ImageButton_parameter.Remove(i);
                    //移除label_parameter控件信息
                    foreach (var i in model.label_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.label_parameter.Remove(i);
                    //移除LedBulb_parameter控件信息
                    foreach (var i in model.LedBulb_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.LedBulb_parameter.Remove(i);
                    //移除LedDisplay_parameter控件信息
                    foreach (var i in model.LedDisplay_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.LedDisplay_parameter.Remove(i);
                    //移除numerical_parameter控件信息
                    foreach (var i in model.numerical_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.numerical_parameter.Remove(i);
                    //移除oscillogram_Chart_parameter控件信息
                    foreach (var i in model.oscillogram_Chart_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.oscillogram_Chart_parameter.Remove(i);
                    //移除ScrollingText_parameter控件信息
                    foreach (var i in model.ScrollingText_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.ScrollingText_parameter.Remove(i);
                    //移除Switch_parameter控件信息
                    foreach (var i in model.Switch_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.Switch_parameter.Remove(i);
                    //移除RadioButton_parameter控件
                    foreach (var i in model.RadioButton_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.RadioButton_parameter.Remove(i);
                    //移除Tag_common_parameters字体信息
                    foreach (var i in model.Tag_common_parameters.Where(pi => pi.FROM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.Tag_common_parameters.Remove(i);
                    //移除control_location位置信息
                    foreach (var i in model.control_location.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.control_location.Remove(i);
                    //移除General_parameters_of_picture图片信息
                    foreach (var i in model.General_parameters_of_picture.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.General_parameters_of_picture.Remove(i);
                    //移除控件Button_colour背景颜色
                    foreach (var i in model.Button_colour.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.Button_colour.Remove(i);
                    //移除HScrollBar_parameter控件
                    foreach (var i in model.HScrollBar_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.HScrollBar_parameter.Remove(i);
                    //移除Conveyor_parameter控件
                    foreach (var i in model.Conveyor_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.Conveyor_parameter.Remove(i);
                    //移除pull_down_menu_parameter下拉菜单控件
                    foreach (var i in model.pull_down_menu_parameter.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.pull_down_menu_parameter.Remove(i);
                    //移除.pull_down_menuName下拉菜单控件
                    foreach (var i in model.pull_down_menuName.Where(pi => pi.FORM.Trim() == Form.Trim()).Select(pi => pi).ToList())
                        model.pull_down_menuName.Remove(i);
                }
                model.SaveChanges();//更新到数据库
            }
            return "OK";
        }
    }
}
