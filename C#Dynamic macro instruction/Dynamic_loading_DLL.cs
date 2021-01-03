using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSEngineTest
{
    /// <summary>
    /// 动态加载外部程序集(dll)
    /// 方便本软件与外部系统对接实现
    /// </summary>
    public class Dynamic_loading_DLL
    {
        /// <summary>
        /// 加载程序集
        /// </summary>
        Assembly assembly;
        /// <summary>
        /// 对象实例
        /// </summary>
        Type type;
        /// <summary>.
        /// 实例化对象
        /// </summary>
        Object activator;
        /// <summary>
        /// 需要传入地址
        /// </summary>
        /// <param name="location">需要加载程序集的具体地址</param>
        public Dynamic_loading_DLL(string @location)
        {
            try
            {
                this.assembly = Assembly.LoadFrom(location);//加载dll
            }
            catch(Exception e)
            { MessageBox.Show("加载失败：" + e.Message, "加载程序集失败"); }
        }
        /// <summary>
        /// 获取与实例化远程对象
        /// </summary>
        /// <param name="Nmae">远程对象的命名空间加上.加上类名</param>
        /// <returns></returns>
        public int Load_type(string Nmae)
        {
            try
            {
                this.type = assembly.GetType(Nmae);
                this.activator = Activator.CreateInstance(type);
                return 1;
            }
            catch(Exception e)
            { MessageBox.Show(e.Message, "实例远程对象失败");  return 0; }
        }
        /// <summary>
        /// 启动指定的方法
        /// </summary>
        /// <returns></returns>
        public async Task<object> Method_Start(string Name, object[] Value)
        {
            object Invoke_Value = null;
            try
            {
                // var T = Task.Run(() =>
                //    {
                var Method = this.type.GetMethod(Name);//搜寻到指定方法
                Invoke_Value = Method.Invoke(this.activator, Value);//启动方法
                return Invoke_Value;
                //  });
                //await T;
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); return Invoke_Value; }
        }
        /// <summary>
        /// 写入指定属性值
        /// </summary>
        /// <param name="Name">属性名称</param>
        /// <param name="Value">需要写入属性的值</param>
        /// <returns></returns>
        public void Property_Write(string Name, object Value)
        {
            try
            {
                var Property = this.type.GetProperty(Name);
                Property.SetValue(this.activator, Value);
            }
            catch(Exception e)
            { MessageBox.Show(e.Message); }
        }
        /// <summary>
        /// 读取指定属性值
        /// </summary>
        /// <param name="Nmae">属性名称</param>
        /// <returns></returns>
        public object Property_Read(string Name)
        {
            object Value = null;
            try
            {
                var Property = this.type.GetProperty(Name);
                Value = Property.GetValue(this.activator);
                return Value;
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); return Value; }
        }
        /// <summary>
        /// 写入指定的字段值
        /// </summary>
        /// <param name="Name">字段名称</param>
        /// <param name="Value">需要写入值</param>
        /// <returns></returns>
        public void Field_Write(string Name,object[] Value)
        {
            try
            {
                var Property = this.type.GetField(Name);
                Property.SetValue(this.activator, Value);
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        }
        /// <summary>
        /// 读取指定字段值
        /// </summary>
        /// <param name="Name">字段名称</param>
        /// <returns></returns>
        public object Field_Read(string Name)
        {
            object Value = null;
            try
            {
                var Property = this.type.GetField(Name);
                Value = Property.GetValue(this.activator);
                return Value;
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); return Value; }
        }
        /// <summary>
        /// 搜索所有公有方法--不搜寻私有的
        /// 返回方法组
        /// </summary>
        /// <returns></returns>
        public object Method_group()
        {            
            if (type.IsNull() || this.activator.IsNull()) return new List<MethodInfo>();
            return this.type.GetMethods().ToList();
        }
        /// <summary>
        /// 搜索所有公有属性--不搜寻私有的
        /// 返回属性组
        /// </summary>
        /// <returns></returns>
        public object Property_group()
        {
            if (type.IsNull() || this.activator.IsNull()) return new List<MethodInfo>();
            return this.type.GetProperties().ToList();
        }
        /// <summary>
        /// 搜索所有公有字段--不搜寻私有的
        /// </summary>
        /// <returns></returns>
        public object Field_group()
        {
            if (type.IsNull() || this.activator.IsNull()) return new List<MethodInfo>();
            return this.type.GetFields().ToList();
        }
    }
}
