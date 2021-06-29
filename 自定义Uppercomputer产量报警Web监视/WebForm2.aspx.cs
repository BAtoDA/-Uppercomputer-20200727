using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using HTML布局学习.报警类序列化;
using Sunny.UI;

namespace HTML布局学习
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //初次加载显示的UI
           // Button2_Click("1",new EventArgs());
        }
        [WebMethod]
        public void mess()
        {
            Response.Write("<script>alert('第四种方式，有白屏！')</script>");
        }
        /// <summary>
        /// 动态生成前台代码 DIV数据显示块
        /// </summary>
        /// <returns></returns>
        public LiteralControl DynamicDIV(StringBuilder Value)
        {
            PlaceHolder1.Controls.Clear();        
            LiteralControl literal = new LiteralControl(Value.ToString());
            PlaceHolder1.Controls.Add(literal);
            return literal;
        }

        /// <summary>
        /// 用户点击关于按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button7_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($@"<header style = 'color: #ffffff;
    font-size: 35%;
    text-align: center;
    position: relative;
    margin-top: 0.3rem;
    top: -10px;
    text-align: center;'> <span >软件说明</span></header>
     <div style = 'width: 15rem;
    height: 7rem;
    display: inline-block;
    float: left;
    position: relative;
    margin-left: 0.1rem;
    margin-top: 0.0rem;
    font-size: 25%;
    color: azure;
    text-align: left;
    position: relative;
    top: 0px;
    left: 20px;' >
本软件适用于工业自动化作为上位机对下位设备进行监控与控制使用简易通过拖拽控件修改参数实现对设备的监控。
                    后续会持续添加控件实现多元化, 更贴合，更方便，更快捷的设计理念目前支持简单常用的控件 - 支持三菱PLC--MC协议(3E帧)--西门子S7协议MODBUS TCP协议--或者通过宏指令简易的编写代码实现串口--以太网特定协议的通讯。
  关于对其他设备的数据库对接目前可以通过宏指令实现简易的去处理后续会做一个特定的控件去对接实现。
</ div > ");   
            DynamicDIV(sb);

        }
        /// <summary>
        /// 用户点击参数设置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@" <div style='width: 4rem; height: 8rem; display: inline-block; float: left; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; left: 80px;'>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>参数设置1
                        <input id='parameter1' type='text' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 25%; height: 30px;'></input></label>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>参数设置1
                        <input id='parameter2' type='text' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 25%; height: 30px;'></input></label>
                </div>
                <div style='width: 4rem; height: 8rem; display: inline-block; float: inherit; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; right: -200px;'>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>参数设置1
                        <input id='parameter3' type='text' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 25%; height: 30px;'></input></label>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>参数设置1
                        <input id='parameter4' type='text' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 25%; height: 30px;'></input></label>
                </div>
                <div style='width: 4rem; height: 8rem; display: inline-block; float: right; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; right: 0px;'>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>参数设置1
                        <input id='parameter5' type='text' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 25%; height: 30px;'></input></label>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>参数设置1
                        <input id='parameter6' type='text' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 25%; height: 30px;'></input></label>
                </div>");
            DynamicDIV(builder);
            
        }
        /// <summary>
        /// 用户点击报警注册事件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"<div style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 15rem; height: 7.5rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
                    <header style='color: #ffffff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                        <span>报警注册事件</span>
                    </header>
                    <table style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 15rem; height: 0.8rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; position: relative; top: 0rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%;'
                        id='Abnorma1'>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>类型</th>
                                <th>设备</th>
                                <th>设备地址</th>
                                <th>设备_具体地址</th>
                                <th>位触发条件</th>
                                <th>字触发条件</th>
                                <th>字触发条件_具体</th>
                                <th>报警内容</th>
                            </tr>
                        </thead>
                        <tbody style='width: 100%; height: 100%; line-height: 50px; background-size: 100% 100%; text-align: center; color: darkgray; position: relative; top: 10px; left: 0px; color: #ffffff;'
                            id='tbMain'>
                        </tbody>
                    </table>
                </div>
                <script type='text/javascript'>
                    GetAlarmSQL();
                </script>
         <div style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 15rem; height: 0.5rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
                     <header style='color: #fff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                    <button style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.5rem; width:0.8rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:-2rem;' onclick='previous()'>上一页</button>
                            <button style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.5rem; width:0.8rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:0rem;' onclick='Home()'>首页</button>
                    <button style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.5rem; width:0.8rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:2rem;' onclick='next()'>下一页</button>
                  </header>
                </div>
                <script type='text/javascript'>
                    //上一页触发方法
                    function previous() {
                        alert('正在请求后端获取上一页数据');
                    }
        function Home()
        {
            alert('正在请求后端获取首页数据');
        }
        function next()
        {
            alert('正在请求后端获取下一页数据');
        }
                </script>");
            //动态添加数据到前台
            DynamicDIV(builder);
        }
        static object Info = new object();
        /// <summary>
        /// 报警事件注册查询前端直接传入泛型集合对象
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string DisplayImagesInfo()
        {
            lock (Info)
            {
                List<AlarmSQL> imagelist = new List<AlarmSQL>();//表单集合
                imagelist.Add(new AlarmSQL()
                {
                    ID = 0,
                    位触发条件 = "1",
                    字触发条件 = ">",
                    字触发条件_具体 = "22",
                    报警内容 = "dd",
                    类型 = 1,
                    设备 = "aaa",
                    设备_具体地址 = "22",
                    设备_地址 = "ee"

                });
                imagelist.Add(new AlarmSQL()
                {
                    ID = 0,
                    位触发条件 = "1",
                    字触发条件 = ">",
                    字触发条件_具体 = "22",
                    报警内容 = "dd",
                    类型 = 1,
                    设备 = "aaa",
                    设备_具体地址 = "22",
                    设备_地址 = "ee"

                });
                //序列化JSON返回前端
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                string imageinfoStr = jsonSerializer.Serialize(imagelist);
                return imageinfoStr;
            }
        }
        /// <summary>
        /// 用户点击了报警历史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}