using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自定义Uppercomputer_20200727.修改参数界面;

namespace 自定义Uppercomputer_20200727.控件重做.控件对齐实现
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/1/14 9:08:12
    //  文件名：Align_Control
    //  版本：V1.0.1  
    //  说明： 实现控件上下左右对齐
    //  修改者：***
    //  修改说明： 
    //==============================================================
    class Align_Control
    {
        public Align_Control(Control control)
        {
            //retention
        }
        /// <summary>
        /// 注册控件对齐需要的事件
        /// </summary>
        /// <param name="control"></param>
        public static void Registration_Event(Control control)
        {
            if (control != null)
            {
                control.MouseDown += new MouseEventHandler(Align_Control.Control_MouseDown);
            }
        }
        /// <summary>
        /// 移除控件对齐需要的事件
        /// </summary>
        /// <param name="control"></param>
        public static void Remove_Events(Control control)
        {
            if (control != null)
            {
                control.MouseDown -= new MouseEventHandler(Align_Control.Control_MouseDown);
            }
        }
        /// <summary>
        /// 用户需要对齐的控件集合
        /// </summary>
        public static List<Tuple<string,Control>> Align_gather = new List<Tuple<string,Control>>();
        /// <summary>
        /// 在控件上分按下鼠标事件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private static void Control_MouseDown(object send, MouseEventArgs e)
        {
            //判断用户是否启用编辑模式
            if (Form2.edit_mode != true) return;//返回方法
            (send as Control).BeginInvoke((EventHandler)delegate//使用控件异步委托处理
            {          
                //判断用户是否按下热键
                if (Control.ModifierKeys == Keys.Control)
                {
                    FormCollection formCollection = Application.OpenForms;//获取活动的窗口
                    for (int i = 0; i < formCollection.Count; i++)
                    {
                        if (parameter_indexes.Button_from_name((send as Control).Parent.ToString()) == formCollection[i].Name)
                        {
                            if (Align_gather.Where(pi => pi.Item1 == formCollection[i].Name).ToList().Count != Align_gather.Count)
                            {
                                Align_gather.Clear();//清空集合
                                return;
                            }
                            else
                                Align_gather.Add(new Tuple<string, Control>(formCollection[i].Name, (send as Control)));//把控件添加到集合
                        }
                    }
                }
                else
                {
                    Align_gather.Clear();//用户未按下热键 清空集合
                }
            });
        }


    }
}
