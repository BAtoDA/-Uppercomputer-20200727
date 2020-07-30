using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型
{
    /// <本类用于处理PLC链接参数进行数据查询修改等操作>   
    class PLC_EF
    {
        public  string Parameter_inquire(int ID)//参数ID查询
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                PLC_parameter button_Parameter = model.PLC_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_Parameter != null)
                    return "OK";
                else
                    return "NG";
            }
        }
        public string PLC_Parameter_Add(PLC_parameter parameter)//主参数参数插入
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                PLC_parameter button_Parameter = model.PLC_parameter.Where(pi => pi.ID == parameter.ID).FirstOrDefault();//查询数据库是否有该ID
                if (button_Parameter == null)
                {
                    PLC_parameter parameter1 = new PLC_parameter();//实例化对象
                    parameter1 = parameter;//传入获取到的对象
                    model.PLC_parameter.Add(parameter1);//构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                }
            }
            return "操作成功";//返回
        }
        public PLC_parameter Parameter_Query(int ID)//查询类全部参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                PLC_parameter button_Class = model.PLC_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                return button_Class;//返回查询结果
            }
        }
        public string Parameter_delete(int ID)//类ID删除参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行删除按钮类主参数操作
                PLC_parameter button_Parameter = model.PLC_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID   
                if (button_Parameter != null)
                {
                    model.PLC_parameter.Remove(button_Parameter);////构造添加表的SQL语句
                    model.SaveChanges();//执行操作
                    return "OK";
                }
                return "NG";
            }
        }
        public string Button_Parameter_modification(int ID, PLC_parameter _Parameter)//修改主类参数
        {
            using (UppercomputerEntities2 model = new UppercomputerEntities2())
            {
                //执行修改类主参数操作
                PLC_parameter Button_parameter = model.PLC_parameter.Where(pi => pi.ID == ID).FirstOrDefault();//查询数据库是否有该ID
                if (Button_parameter != null)
                {
                    #region 要修改的属性
                    Button_parameter.三菱PLC_IP = _Parameter.三菱PLC_IP;
                    Button_parameter.三菱PLC_端口 = _Parameter.三菱PLC_端口;
                    Button_parameter.三菱PLC_类型= _Parameter.三菱PLC_类型;
                    Button_parameter.三菱PLC_链接类型 = _Parameter.三菱PLC_链接类型;
                    Button_parameter.西门子PLC_IP = _Parameter.西门子PLC_IP;
                    Button_parameter.西门子PLC_端口= _Parameter.西门子PLC_端口;
                    Button_parameter.西门子PLC_类型 = _Parameter.西门子PLC_类型;
                    Button_parameter.西门子PLC_链接类型 = _Parameter.西门子PLC_链接类型;
                    Button_parameter.MODBUS_TCP_PLC_IP = _Parameter.MODBUS_TCP_PLC_IP;
                    Button_parameter.MODBUS_TCP_PLC_端口11 = _Parameter.MODBUS_TCP_PLC_端口11;
                    Button_parameter.MODBUS_TCP_PLC_类型 = _Parameter.MODBUS_TCP_PLC_类型;
                    Button_parameter.MODBUS_TCP_PLC_链接类型 = _Parameter.MODBUS_TCP_PLC_链接类型;
                    #endregion
                    model.SaveChanges();//执行操作
                    return "OK";
                }
                return "NG";
            }
        }
    }
}
