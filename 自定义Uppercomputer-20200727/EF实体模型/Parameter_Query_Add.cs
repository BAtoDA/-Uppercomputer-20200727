using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    class Parameter_Query_Add
    {
        public List<Button_Class> all_Parameter_Query_Button(string From)//查询按钮类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
               return model.Button_Class.Where(pi => pi.FORM == From).Select(PI=>PI). ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<picture_Class> all_Parameter_Query_picture(string From)//查询图片类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.picture_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<label_Class> all_Parameter_Query_label(string From)//查询标签类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.label_Class.Where(pi => pi.FROM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<numerical_Class> all_Parameter_Query_numerical(string From)//查询数值元件类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.numerical_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<Switch_Class> all_Parameter_Query_Switch(string From)//查询切换开关类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.Switch_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<LedBulb_Class> all_Parameter_Query_LedBulb(string From)//查询切换开关类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.LedBulb_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<GroupBox_Class> all_Parameter_Query_GroupBox(string From)//查询四边框类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.GroupBox_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<ImageButton_Class> all_Parameter_Query_ImageButton(string From)//查询无图片按钮类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.ImageButton_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<ScrollingText_Class> all_Parameter_Query_ScrollingText(string From)//查询无图片按钮类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.ScrollingText_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<doughnut_Chart_Class> all_Parameter_Query_doughnut_Chart(string From)//查询圆形图类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.doughnut_Chart_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<histogram_Chart_Class> all_Parameter_Query_doughnut_histogram(string From)//查询柱形图类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.histogram_Chart_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<oscillogram_Chart_Class> all_Parameter_Query_doughnut_oscillogram(string From)//查询柱形图类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.oscillogram_Chart_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<AnalogMeter_Class> all_Parameter_Query_AnalogMeter(string From)//查询百分百表盘类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.AnalogMeter_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<LedDisplay_Class> all_Parameter_Query_LedDisplay(string From)//查询数值显示类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.LedDisplay_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<ihatetheqrcode_Class> all_Parameter_Query_ihatetheqrcode(string From)//查询二维码/条形码类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.ihatetheqrcode_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<function_key_Class> all_Parameter_Query_function_key(string From)//查询二维码/条形码类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.function_key_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<RadioButton_Class> all_Parameter_Query_RadioButton(string From)//查询二维码/条形码类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.RadioButton_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<pull_down_menu_Class> all_Parameter_Query_pull_down_menu(string From)//查询类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.pull_down_menu_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<pull_down_menuName> all_Parameter_Query_pull_down_menuName(string From)//查询项目资料类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.pull_down_menuName.Where(pi => pi.控件归属 == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<HScrollBar_Class> all_Parameter_Query_HScrollBar(string From)//查询项目资料类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.HScrollBar_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<Conveyor_Class> all_Parameter_Query_Conveyor(string From)//查询项目资料类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.Conveyor_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
        public List<Valve_Class> all_Parameter_Query_Valve(string From)//查询项目资料类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                return model.Valve_Class.Where(pi => pi.FORM == From).Select(PI => PI).ToList();//查询数据库是否有该FROM返回查询结果                
            }
        }
    }
}
