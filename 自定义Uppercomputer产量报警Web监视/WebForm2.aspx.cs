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
        /// <summary>
        /// 该值指示着是否进入全屏模式
        /// </summary>
        public static bool Fullscreen { get; set; }
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
            sb.Append(@"<header style = 'color: #ffffff;
    font-size: 35%;
    text-align: center;
    position: relative;
    margin-top: 0.3rem;
    top: -10px;
    text-align: center;'> <span >软件说明</span></header>
     <div id='Tablediv' style = 'width:96.7%;
    height: 7.5rem;
    display: inline-block;
    float: left;
    position: relative;
    margin-left: 0.1rem;
    margin-top: 0.1rem;
    font-size: 25%;
    color: azure;
    text-align: left;
    position: relative;
    top: 0px;
    left: 20px;' >
本软件适用于工业自动化作为上位机对下位设备进行监控与控制使用简易通过拖拽控件修改参数实现对设备的监控。后续会持续添加控件实现多元化, 更贴合，更方便，更快捷的设计理念目前支持简单常用的控件 - 支持三菱PLC--MC协议(3E帧)--西门子S7协议MODBUS TCP协议--或者通过宏指令简易的编写代码实现串口--以太网特定协议的通讯。关于对其他设备的数据库对接目前可以通过宏指令实现简易的去处理后续会做一个特定的控件去对接实现。
<script type='text/javascript'>
     //定时刷新自适应代码
                    setInterval(function () {
                        //判断表格Div主页面自适应高度
                        var navigation = document.getElementById('Tablediv');
                        //判断高度
                        if (document.body.clientHeight >= 200 && document.body.clientHeight < 3000) {
                            navigation.style.height = (document.body.clientHeight / 126.04415584415584415584415584416) + 'rem';
                            navigation.style.marginTop = (document.body.clientHeight / 9690) + 'rem';
                        }
                    }, 300);
</script>
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
            builder.Append(@"            <div id='parameterDiv1' style='width: 4rem; height: 8.5rem; display: inline-block; float: left; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; left: 80px;'>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter1' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter2' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                </div>
                <div id='parameterDiv2' style='width: 4rem; height: 8.5rem; display: inline-block; float: inherit; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; right: -200px;'>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter3' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter4' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                </div>
                <div id='parameterDiv3' style='width: 4rem; height: 8.5rem; display: inline-block; float: right; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; right: 0px;'>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter5' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter6' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                </div>
                <script type='text/javascript'>
                    function paramete() {
                        //区块一自适应
                        var parameterDiv = document.getElementById('parameterDiv1');

                        //判断按钮导航栏屏幕宽度 标准是1920*969 已知整体Html 1个rem等于100px
                        if (document.body.clientWidth >= 600 && document.body.clientWidth < 6000) {
                            parameterDiv.style.width = (document.body.clientWidth / 480) + 'rem';
                            parameterDiv.style.marginLeft = (document.body.clientHeight / 9690) + 'rem';
                            parameterDiv.style.left = (document.body.clientHeight / 1200) + 'rem';
                        }
                        //判断高度
                        if (document.body.clientHeight > 200 && document.body.clientHeight < 3000) {
                           parameterDiv.style.height = (document.body.clientHeight / 114) + 'rem';
                        }
                        //区块二自适应
                        var parameterDiv = document.getElementById('parameterDiv2');

                        //判断按钮导航栏屏幕宽度 标准是1920*969 已知整体Html 1个rem等于100px
                        if (document.body.clientWidth >= 600 && document.body.clientWidth < 6000) {
                            parameterDiv.style.width = (document.body.clientWidth / 480) + 'rem';
                            parameterDiv.style.marginLeft = (document.body.clientHeight / 9690) + 'rem';
                            parameterDiv.style.right = '-' + (document.body.clientHeight / 480) + 'rem';
                        }
                        //判断高度
                        if (document.body.clientHeight > 200 && document.body.clientHeight < 3000) {
                            parameterDiv.style.height = (document.body.clientHeight / 114) + 'rem';
                        }
                        //区块三自适应
                        var parameterDiv = document.getElementById('parameterDiv3');

                        //判断按钮导航栏屏幕宽度 标准是1920*969 已知整体Html 1个rem等于100px
                        if (document.body.clientWidth >= 600 && document.body.clientWidth < 6000) {
                            parameterDiv.style.width = (document.body.clientWidth / 480) + 'rem';
                            parameterDiv.style.marginLeft = (document.body.clientHeight / 9690) + 'rem';
                        }
                        //判断高度
                        if (document.body.clientHeight > 200 && document.body.clientHeight < 3000) {
                            parameterDiv.style.height = (document.body.clientHeight / 114) + 'rem';
                        }
                    }
                   //用于处理文本框特效
                  Parametertext();
           //定时刷新自适应代码
          setInterval(function () {
                paramete();
             }, 300);     
                </script>");
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
            builder.Append(@"<div id='Tablediv' style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 98.7%; height: 7.5rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
                    <header style='color: #ffffff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                        <span>报警注册事件</span>
                    </header>
                    <table style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 98.7%; height: 0.8rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; position: relative; top: 0rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%;'
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
         <div style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none;  width:100%; height:15%;  color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
                     <header style='color: #fff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                    <button id='previous' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:-2rem;' onclick='previous()'>上一页</button>
                            <button id='home' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:0rem;' onclick='Home()'>首页</button>
                    <button id='page' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:2rem;' onclick='next()'>下一页</button>
                  </header>
                </div>
                <script type='text/javascript'>
                 //下方导航栏按钮特效
                    Tablecss();
                   //鼠标移到子项 子项变色
                    Itembackground();
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
        //定时刷新自适应代码
                    setInterval(function () {
                        //判断表格Div主页面自适应高度
                        var navigation = document.getElementById('Tablediv');
                        //判断高度
                        if (document.body.clientHeight >= 200 && document.body.clientHeight < 3000) {
                            navigation.style.height = (document.body.clientHeight / 125.03225806451612903225806451613) + 'rem';
                            navigation.style.marginTop = (document.body.clientHeight / 9690) + 'rem';
                        }
                    }, 300);
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
                for (int i = 0; i < 12; i++)
                {
                    imagelist.Add(new AlarmSQL()
                    {
                        ID = i,
                        位触发条件 = "1",
                        字触发条件 = ">",
                        字触发条件_具体 = "22",
                        报警内容 = "dd",
                        类型 = 1,
                        设备 = "aaa",
                        设备_具体地址 = "22",
                        设备_地址 = "ee"

                    });
                }
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
            StringBuilder builder = new StringBuilder();
            builder.Append(@"<div id='Tablediv' style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 98.7%; height: 7.5rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
                    <header style='color: #ffffff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                        <span>报警历史查看</span>
                    </header>
                    <table style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 98.7%; height: 0.8rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; position: relative; top: 0rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%;'
                        id='Abnorma1'>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>报警时间</th>
                                <th>处理完成时间</th>
                                <th>类型</th>
                                <th>设备</th>
                                <th>设备_地址</th>
                                <th>设备_具体地址</th>
                                <th>报警内容</th>
                                <th>事件关联ID</th>
                            </tr>
                        </thead>
                        <tbody style='width: 100%; height: 100%; line-height: 50px; background-size: 100% 100%; text-align: center; color: darkgray; position: relative; top: 10px; left: 0px; color: #ffffff;'
                            id='tbMain1'>
                        </tbody>
                    </table>
                </div>
                <script type='text/javascript'>
                    GetAlarmhistory();
                </script>
         <div style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width:100%; height:15%; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
                     <header style='color: #fff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                    <button id='previous' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:-2rem;' onclick='previous()'>上一页</button>
                            <button id='home' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:0rem;' onclick='Home()'>首页</button>
                    <button id='page' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:2rem;' onclick='next()'>下一页</button>
                  </header>
                </div>
                <script type='text/javascript'>
                  //下方导航栏按钮特效
                    Tablecss();
                    //鼠标移到子项 子项变色
                    Itembackground();
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
         //定时刷新自适应代码
                    setInterval(function () {
                        //判断表格Div主页面自适应高度
                        var navigation = document.getElementById('Tablediv');
                        //判断高度
                        if (document.body.clientHeight >= 200 && document.body.clientHeight < 3000) {
                            navigation.style.height = (document.body.clientHeight / 125.03225806451612903225806451613) + 'rem';
                            navigation.style.marginTop = (document.body.clientHeight / 9690) + 'rem';
                        }
                    }, 300);
                </script>");
            //动态添加数据到前台
            DynamicDIV(builder);
        }
        /// <summary>
        /// 报警事件历史数据查询前端直接传入泛型集合对象
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Displayhistory()
        {
            lock (Info)
            {
                List<Alarmhistory> imagelist = new List<Alarmhistory>();//表单集合
                imagelist.Add(new Alarmhistory()
                {
                    ID = 0,
                    设备 = "aaa",
                    设备_具体地址 = "22",
                    设备_地址 = "ee11",
                    事件关联ID = 1,
                    处理完成时间 = DateTime.Now.ToString("D"),
                    报警内容 = "11111",
                    报警时间 = DateTime.Now.ToString("D"),
                    类型 = true

                }) ;
                //序列化JSON返回前端
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                string imageinfoStr = jsonSerializer.Serialize(imagelist);
                return imageinfoStr;
            }
        }
        [WebMethod]
        public static string Fullscreene(bool name)
        {
            Fullscreen = name;
            return new JavaScriptSerializer().Serialize(Fullscreen);
        }
        [WebMethod]
        public static string Fullscreenee()
        {
            return new JavaScriptSerializer().Serialize(Fullscreen);
        }
        /// <summary>
        /// 用户点击了 页面监控按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button6_Click(object sender, EventArgs e)
        {
            //把页面监控界面推送到前台中
            StringBuilder builder = new StringBuilder();
            builder.Append(@"<div id='Tabledivee' style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 98.7%; height: 8.5rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
                    <header style='color: #ffffff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                        <span>界面介绍</span>
                    </header>
                    <div style='width: 45%; height: 70%; display: inline-block; float: left; position: relative; margin-left: 0.1rem; margin-top: 0.1rem; color: azure; top: 0rem; left: 0px;'>
                        <header style='color: #ffffff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                            <span>产量监控界面</span>
                        </header>
                        <div style='width: 75%; height: 60%; display: inline-block; float: left; position: relative; margin-left: 0.1rem; margin-top: 0.1rem; color: azure; top: 0rem; left: 0.65rem; background: url(../img/bg_box3.png); no-repeat; background-size: 100% 100%; border: none;'>
                            <video id='video_id1' style='position: relative; top: -0.11rem;' width='100%;' height='100%;' controls='controls'>
                                你的浏览器不能支持HTML5视频
                                <source src='../网页播放的视频/source1.mp4' type='video/mp4'>
                            </video>
                            <p style='font-size: 40%;'>
                                本界面主要用于：预设当班目标产量,当月目标产量,全年目标产量, 判断当班当天是否完成任务 配合MES系统制定目标有计划的进行生产‘排产’ 
                                内置小时产量动态图表与本周产量动态显示，当月生产数量查询，支持初步查看设备状态与是否进入报警状态和报警发生时间，内容，是否处理等。
                            </p>
                            <div style='color: #fff; font-size: 100%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 100%; height: 15%; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; float: inline-end; position: relative; top: -0rem;'>
                                <header style='color: #fff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                                    <button id='yield' style='color: #fff; float: initial; font-size: 70%; font-weight: 900; text-align: center; margin-right: 0%; margin-top: 0.2rem; height: 0.8rem; width: 2.5rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: 0rem;'
                                        onclick='GOyield()'>
                                        进入产量监控页面</button>
                                </header>
                            </div>
                        </div>
                    </div>
                    <div style='width: 45%; height: 70%; display: inline-block; float: right; position: relative; margin-left: 0.1rem; margin-top: 0.1rem; color: azure; top: 0.0rem; left: 0px;'>
                        <header style='color: #ffffff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                            <span>异常监控界面</span>
                        </header>
                        <div style='width: 75%; height: 60%; display: inline-block; float: left; position: relative; margin-left: 0.1rem; margin-top: 0.1rem; color: azure; top: -5px; left: 0.65rem; background: url(../img/bg_box3.png); no-repeat; background-size: 100% 100%; border: none;'>
                            <video id='video_id2' style='position: relative; top: -0.11rem;' width='100%;' height='100%;' src='../网页播放的视频/source2.mp4' controls='controls'>
                                你的浏览器不能支持HTML5视频
                                 <source src='../网页播放的视频/source2.mp4' type='video/mp4'>
                            </video>
                            <p style='font-size: 40%;'>
                                本界面主要用于：当天报警次数，7天报警次数，当月报警次数，支持用户对报警处理用时进行监控内置当天报警处理用时，7天报警处理用时
                                ，当月报警处理用时，并且把出现次数最多的异常内容显示给用户这样可使用户快速找到设备问题所在提高生产效率。
                            </p>
                            <div style='color: #fff; font-size: 100%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 100%; height: 15%; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; float: inline-end; position: relative; top: 0.32rem;'>
                                <header style='color: #fff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                                    <button id='Alarm' style='color: #fff;  float: initial; font-size: 70%; font-weight: 900; text-align: center; margin-right: 0%; margin-top: 0.2rem; height: 0.8rem; width: 2.5rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: 0rem;'
                                        onclick='GOAlarm()'  >
                                        进入异常监控页面</button>
                                </header>
                            </div>
                        </div>
                    </div>
                    <script type='text/javascript'>
                        //按钮特效
                        var yieldButton = document.getElementById('yield');
                        yieldButton.onmouseleave = function () {
                            yieldButton.style.opacity = 10;
                        }
                        yieldButton.onmouseenter = function () {
                            yieldButton.style.opacity = 0.7;
                        }
                        var AlamButton = document.getElementById('Alarm');
                        AlamButton.onmouseleave = function () {
                            AlamButton.style.opacity = 10;
                        }
                        AlamButton.onmouseenter = function () {
                            AlamButton.style.opacity = 0.7;
                        }
                        //打开产量监控界面
                        function GOyield() {
                            window.open('WebForm1.aspx');
                        }
                        //打开异常监控界面
                        function GOAlarm() {
                            window.open('WebForm1.aspx');
                        }
                    </script>
                </div>
                <script type='text/javascript'>
                    //定时刷新自适应代码
                    setInterval(function () {
                        //判断表格Div主页面自适应高度
                        var navigation = document.getElementById('Tabledivee');
                        //判断高度
                        if (document.body.clientHeight >= 200 && document.body.clientHeight < 3000) {
                            navigation.style.height = (document.body.clientHeight / 115.1) + 'rem';
                            navigation.style.marginTop = (document.body.clientHeight / 9690) + 'rem';
                        }
                    }, 300);
                </script>");
            //动态添加数据到前台
            DynamicDIV(builder);

        }
    }
}