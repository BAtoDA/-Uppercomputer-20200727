using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 自定义Uppercomputer_20200727.EF实体模型.EFtoSQL操作类重写
{
    /// <summary>
    /// 用于EF类操作EF实体模型---to SQL数据库
    /// </summary>
    class Button_EFbase
    {
        static Mutex mutex;
        static object muxt = new object();
        static object mux = new object();
        public Button_EFbase()
        {
            mutex = new Mutex();//实例化互斥锁(Mutex)    
        }
        public static List<dynamic> EFbase { get; set; }
        /// <summary>
        /// 默认添加EF中所有的表属性对象 
        /// </summary>
        public UppercomputerEntities2 EFsurface()
        {
            lock (this)
            {
                //mutex.WaitOne(3000);
                UppercomputerEntities2 db = new UppercomputerEntities2();
                EFbase = new List<dynamic>()
                {
#region SQL参数表
                db.AnalogMeter_parameter,
                    db.Button_colour,
                    db.Button_parameter,
                    db.Control_layer,
                    db.control_location,
                    db.doughnut_Chart_parameter,
                    db.Event_message,
                    db.function_key_parameter,
                    db.General_parameters_of_picture,
                    db.GroupBox_parameter,
                    db.histogram_Chart_parameter,
                    db.HScrollBar_parameter,
                    db.ihatetheqrcode_parameter,
                    db.ImageButton_parameter,
                    db.label_parameter,
                    db.LedBulb_parameter,
                    db.LedDisplay_parameter,
                    db.numerical_parameter,
                    db.oscillogram_Chart_parameter,
                    db.picture_parameter,
                    db.PLC_macroinstruction,
                    db.PLC_parameter,
                    db.Profile,
                    db.pull_down_menu_parameter,
                    db.pull_down_menuName,
                    db.RadioButton_parameter,
                    db.ScrollingText_parameter,
                    db.Switch_parameter,
                    db.Tag_common_parameters,
                    db.AnalogMeter_Class,
                    db.Button_Class,
                    db.doughnut_Chart_Class,
                    db.function_key_Class,
                    db.GroupBox_Class,
                    db.histogram_Chart_Class,
                    db.HScrollBar_Class,
                    db.ihatetheqrcode_Class,
                    db.ImageButton_Class,
                    db.label_Class,
                    db.LedBulb_Class,
                    db.LedDisplay_Class,
                    db.numerical_Class,
                    db.oscillogram_Chart_Class,
                    db.picture_Class,
                    db.pull_down_menu_Class,
                    db.RadioButton_Class,
                    db.ScrollingText_Class,
                    db.Switch_Class,
                    db.Conveyor_parameter,
                    db.Conveyor_Class,
                    db.Valve_parameter,
                    db.Valve_Class,
                    db.Alarmhistory
#endregion
            };
                //mutex.ReleaseMutex();
                return db;
            }
        }
        /// <summary>
        /// 查询EF类参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T">传入类型</typeparam>
        /// <param name="ID">查询条件</param>
        /// <returns></returns>
        public static string Button_Parameter_inquire<T>(string ID)//按钮类参数ID查询
        {
            lock (muxt)
            {
              //  mutex.WaitOne(3000);
                var entities2 = new Button_EFbase();
                entities2.EFsurface();
                //查询泛型约束 需要修改的表
                var surface = EFbase.Where(pi => pi.GetType().GenericTypeArguments[0].Name == typeof(T).Name).FirstOrDefault();
                //查询SQL数据
                foreach (dynamic i1 in from pi in (IQueryable<T>)surface where true select pi)
                {
                    if (i1.ID.Trim() == ID.Trim())
                    {
                        return "OK";
                    }
                }
              //  mutex.ReleaseMutex();
                return "NG";
            }
        }
        /// <summary>
        /// 插入类型全部参数 可以不使用<T>去约束 IDE根据传入参数的对象自动推断
        /// </summary>
        /// <typeparam name="T1">Button_parameter</typeparam>
        /// <typeparam name="T2">Tag_common_parameters</typeparam>
        /// <typeparam name="T3">General_parameters_of_picture</typeparam>
        /// <typeparam name="T4">control_location</typeparam>
        /// <typeparam name="T5">Button_colour</typeparam>
        /// <param name="parameter1"></param>
        /// <param name="parameter2"></param>
        /// <param name="parameter3"></param>
        /// <param name="parameter4"></param>
        /// <param name="parameter5"></param>
        /// <returns></returns>
        public string Button_Add<T1, T2, T3, T4, T5>(T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
        {
            this.Button_Parameter_Add(parameter1);
            this.Button_Parameter_Add(parameter2);
            this.Button_Parameter_Add(parameter3);
            this.Button_Parameter_Add(parameter4);
            this.Button_Parameter_Add(parameter5);
            return "OK";
        }
        /// <summary>
        /// 插入参数--可以不使用<T>去约束 IDE根据传入参数的对象自动推断
        /// </summary>
        /// <typeparam name="T">传入约束类型</typeparam>
        /// <param name="parameter">该类型的对象</param>
        /// <returns></returns>
        public string Button_Parameter_Add<T>(T parameter)
        {
            lock (this)
            {
               // mutex.WaitOne(3000);
                UppercomputerEntities2 db = new Button_EFbase().EFsurface();
                //查询泛型约束 需要修改的表
                var surface = EFbase.Where(pi => pi.GetType().GenericTypeArguments[0].Name == typeof(T).Name).FirstOrDefault();
                //查询SQL数据
                bool have = false;
                foreach (dynamic i1 in from pi in (IQueryable<T>)surface where true select pi)
                {
                    have = i1.ID.Trim() == ((dynamic)parameter).ID.Trim() ? true : false;
                }
                //表示SQL中不存在该ID数据--允许插入数据
                if (!have)
                {
                    surface.Add(parameter);//构造添加到表的SQL语句
                    db.SaveChanges();//执行操作
                    return "OK";
                }
               // mutex.ReleaseMutex();
                return "NG";
            }
        }
        /// <summary>
        /// 插入参数--可以不使用<T>去约束 IDE根据传入参数的对象自动推断
        /// </summary>
        /// <typeparam name="T">传入约束类型</typeparam>
        /// <param name="parameter">该类型的对象</param>
        /// <returns></returns>
        public string Button_Parameter_Add<T>(T parameter,int id)
        {
            lock (this)
            {
               // mutex.WaitOne(3000);
                UppercomputerEntities2 db = new Button_EFbase().EFsurface();
                //查询泛型约束 需要修改的表
                var surface = EFbase.Where(pi => pi.GetType().GenericTypeArguments[0].Name == typeof(T).Name).FirstOrDefault();
                //表示SQL中不存在该ID数据--允许插入数据
                surface.Add(parameter);//构造添加到表的SQL语句
                db.SaveChanges();//执行操作
               // mutex.ReleaseMutex();
                return "OK";
            }
        }
        /// <summary>
        /// 查询参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T">传入约束类型</typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <returns></returns>
        public T Button_Parameter_Query<T>(string ID) where T : new()
        {
            lock (this)
            {
                // mutex.WaitOne(3000);
                _ = new Button_EFbase().EFsurface();
                //查询泛型约束 需要修改的表
                var surface = EFbase.Where(pi => pi.GetType().GenericTypeArguments[0].Name == typeof(T).Name).FirstOrDefault();
                if (surface != null)
                {
                    var rew = (IQueryable<T>)surface;
                    var reachanull = rew.Where(pi => true).FirstOrDefault();
                    var reach = rew.Where(p => true).ToList();
                    //查询SQL数据
                    foreach (dynamic i1 in reach)
                    {
                        if (i1.ID.Trim() == ID.Trim())
                        {
                            return i1;
                        }
                    }
                    // mutex.ReleaseMutex();
                    return new T();
                }
            }
            return new T();
        }
     
        /// <summary>
        /// 查询窗口参数根据field去判断 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T">传入约束类型</typeparam>
        /// <param name="FORM">查询条件内容</param>
        /// <param name="field">需要查询的字段</param>
        /// <returns></returns>
        public List<T> Button_Parameter_Query<T>(string FORM,string field) where T : new()
        {
            for (int i = 0; i < 3; i++)
            {
                lock (mux)
                {
                    //mutex.WaitOne(5000);
                    //创建表
                    List<T> Data = new List<T>();
                    _ = new Button_EFbase().EFsurface();
                    //查询泛型约束 需要修改的表
                    var surface = EFbase.Where(pi => pi.GetType().GenericTypeArguments[0].Name == typeof(T).Name).FirstOrDefault();
                    if (surface != null)
                    {
                        var reach = (IQueryable<T>)surface;
                        var reachanull = reach.Where(p => true).FirstOrDefault();
                        if ((IQueryable<T>)surface == null || reachanull == null) continue;
                        //查询SQL数据
                        switch (field)
                        {
                            case "FORM":
                                foreach (dynamic i1 in from pi in (IQueryable<T>)surface where true select pi)
                                {
                                    if (i1.FORM.Trim() == FORM.Trim())
                                    {
                                        Data.Add(i1);
                                    }

                                }
                                return Data;
                            case "控件归属":
                                foreach (dynamic i1 in from pi in (IQueryable<T>)surface where true select pi)
                                {
                                    if (i1.控件归属.Trim() == FORM.Trim())
                                    {
                                        Data.Add(i1);
                                    }

                                }
                                return Data;
                        }
                        // mutex.ReleaseMutex();
                        return Data;
                    }
                }
            }
            return new List<T>();
        }
        /// <summary>
        /// 删除参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T1">Button_parameter</typeparam>
        /// <typeparam name="T2">Tag_common_parameters</typeparam>
        /// <typeparam name="T3">General_parameters_of_picture</typeparam>
        /// <typeparam name="T4">control_location</typeparam>
        /// <typeparam name="T5">Control_layer</typeparam>
        /// <typeparam name="T6">Button_colour</typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <returns></returns>
        public string Button_Parameter_delete<T1,T2,T3,T4,T5,T6>(string ID)
        {
            this.Button_Parameter_delete<T1>(ID);
            this.Button_Parameter_delete<T2>(ID);
            this.Button_Parameter_delete<T3>(ID);
            this.Button_Parameter_delete<T4>(ID);
            this.Button_Parameter_delete<T5>(ID);
            this.Button_Parameter_delete<T6>(ID);
            return "OK";
        }
        /// <summary>
        /// 删除参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T1">Button_parameter</typeparam>
        /// <typeparam name="T2">Tag_common_parameters</typeparam>
        /// <typeparam name="T3">General_parameters_of_picture</typeparam>
        /// <typeparam name="T4">control_location</typeparam>
        /// <typeparam name="T5">Control_layer</typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <returns></returns>
        public string Button_Parameter_delete<T1, T2, T3, T4, T5>(string ID)
        {
            this.Button_Parameter_delete<T1>(ID);
            this.Button_Parameter_delete<T2>(ID);
            this.Button_Parameter_delete<T3>(ID);
            this.Button_Parameter_delete<T4>(ID);
            this.Button_Parameter_delete<T5>(ID);
            return "OK";
        }
        /// <summary>
        /// 删除参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T1">Button_parameter</typeparam>
        /// <typeparam name="T2">Tag_common_parameters</typeparam>
        /// <typeparam name="T3">General_parameters_of_picture</typeparam>
        /// <typeparam name="T4">control_location</typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <returns></returns>
        public string Button_Parameter_delete<T1, T2, T3, T4>(string ID)
        {
            this.Button_Parameter_delete<T1>(ID);
            this.Button_Parameter_delete<T2>(ID);
            this.Button_Parameter_delete<T3>(ID);
            this.Button_Parameter_delete<T4>(ID);
            return "OK";
        }
        /// <summary>
        /// 删除参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T1">Button_parameter</typeparam>
        /// <typeparam name="T2">Tag_common_parameters</typeparam>
        /// <typeparam name="T3">General_parameters_of_picture</typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <returns></returns>
        public string Button_Parameter_delete<T1, T2, T3>(string ID)
        {
            this.Button_Parameter_delete<T1>(ID);
            this.Button_Parameter_delete<T2>(ID);
            this.Button_Parameter_delete<T3>(ID);
            return "OK";
        }
        /// <summary>
        /// 删除参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T1">传入约束类型</typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <returns></returns>
        public string Button_Parameter_delete<T>(string ID)
        {
           // mutex.WaitOne(5000);
            var db = new Button_EFbase().EFsurface();
            //查询泛型约束 需要修改的表
            var surface = EFbase.Where(pi => pi.GetType().GenericTypeArguments[0].Name == typeof(T).Name).FirstOrDefault();
            if (surface != null)
            {
                //查询SQL数据
                foreach (dynamic i1 in from pi in (IQueryable<T>)surface where true select pi)
                {
                    if (i1.ID.Trim() == ID.Trim())
                    {
                        surface.Remove(i1);
                        db.SaveChanges();
                        return "OK";
                    }
                }
            }
           // mutex.ReleaseMutex();
            return "NG";
        }
        /// <summary>
        /// 修改参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <param name="_Parameter">Button_parameter</param>
        /// <param name="tag_Common_">Tag_common_parameters</param>
        /// <param name="_Of_Picture">General_parameters_of_picture</param>
        /// <param name="_Location">control_location</param>
        /// <param name="button_">Button_colour</param>
        /// <returns></returns>
        public string Button_Parameter_modification<T1,T2,T3,T4,T5>(string ID,T1 _Parameter,T2 tag_Common_ ,T3 _Of_Picture ,T4 _Location,T5 button_)
        {
            Button_Parameter_modification(ID, _Parameter);
            Button_Parameter_modification(ID, tag_Common_);
            Button_Parameter_modification(ID, _Of_Picture);
            Button_Parameter_modification(ID, _Location);
            Button_Parameter_modification(ID, button_);
            return "OK";
        }
        /// <summary>
        /// 修改参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <param name="_Parameter">Button_parameter</param>
        /// <param name="tag_Common_">Tag_common_parameters</param>
        /// <param name="_Of_Picture">General_parameters_of_picture</param>
        /// <param name="_Location">control_location</param>
        /// <returns></returns>
        public string Button_Parameter_modification<T1, T2, T3, T4>(string ID, T1 _Parameter, T2 tag_Common_, T3 _Of_Picture, T4 _Location)
        {
            Button_Parameter_modification(ID, _Parameter);
            Button_Parameter_modification(ID, tag_Common_);
            Button_Parameter_modification(ID, _Of_Picture);
            Button_Parameter_modification(ID, _Location);
            return "OK";
        }
        /// <summary>
        /// 修改参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <param name="_Parameter">Button_parameter</param>
        /// <param name="tag_Common_">Tag_common_parameters</param>
        /// <param name="_Of_Picture">General_parameters_of_picture</param>
        /// <returns></returns>
        public string Button_Parameter_modification<T1, T2, T3>(string ID, T1 _Parameter, T2 tag_Common_, T3 _Of_Picture)
        {
            Button_Parameter_modification(ID, _Parameter);
            Button_Parameter_modification(ID, tag_Common_);
            Button_Parameter_modification(ID, _Of_Picture);
            return "OK";
        }
        /// <summary>
        /// 修改参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <param name="_Parameter">Button_parameter</param>
        /// <param name="tag_Common_">Tag_common_parameters</param>
        /// <returns></returns>
        public string Button_Parameter_modification<T1, T2>(string ID, T1 _Parameter, T2 tag_Common_)
        {
            Button_Parameter_modification(ID, _Parameter);
            Button_Parameter_modification(ID, tag_Common_);
            return "OK";
        }
        /// <summary>
        /// 修改参数 根据泛型<T>自动推断需要查询的表
        /// </summary>
        /// <typeparam name="T">约束类型</typeparam>
        /// <param name="ID">查询条件内容</param>
        /// <param name="Parameter">需要修改的内容</param>
        /// <returns></returns>
        public string Button_Parameter_modification<T>(string ID,T Parameter)
        {
          //  mutex.WaitOne(5000);
            //获取实体模型对象
            var db = new Button_EFbase().EFsurface();
            //查询泛型约束 需要修改的表
            var surface = EFbase.Where(pi => pi.GetType().GenericTypeArguments[0].Name == typeof(T).Name).FirstOrDefault();
            //查询SQL数据
            foreach (dynamic i1 in from pi in (IQueryable<T>)surface where true select pi)
            {
                if (i1.ID.Trim() == ID.Trim())
                {
                    string id = i1.ID;//先获取旧的ID
                    string Form = "";
                    try
                    {
                        Form = i1.FORM.Trim();
                    }
                    catch
                    {
                        Form = i1.FROM.Trim();
                    }
                    //反射获取泛型的属性
                    var Properties = i1.GetType().GetProperties();
                    var propertyInfos = Parameter.GetType().GetProperties();
                    //遍历属性
                    for (int i = 0; i < propertyInfos.Length; i++)
                    {
                        //不修改ID 与FORM的数据
                        if (Properties[i].GetType().Name != "ID" && Properties[i].GetType().Name != "FORM"&& Properties[i].GetType().Name != "FROM")
                            Properties[i].SetValue(i1, propertyInfos[i].GetValue(Parameter));
                    }
                    i1.ID = id;
                    try
                    {
                        i1.FORM = Form;
                    }
                    catch
                    {
                        i1.FROM= Form;
                    }
                    db.SaveChanges();
                  //  mutex.ReleaseMutex();
                    return "OK"; 
                }
            }
            return "NG";
        }
    }
}
