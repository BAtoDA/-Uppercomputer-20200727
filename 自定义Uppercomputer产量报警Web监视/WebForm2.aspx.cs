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
using System.Xml;
using HTML布局学习.EF实体模型;
using HTML布局学习.报警类序列化;
using PLC通讯规范接口;
using Sunny.UI;
using 自定义Uppercomputer产量报警Web监视.EF实体模型;

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
            Blockprocessing blockprocessing = new Blockprocessing(this.PlaceHolder1);
            //UpdateConnectionString("SqliteTest", @AppDomain.CurrentDomain.BaseDirectory.ToString() + "临时数据库文件\\Extent1.db");
        }
        /// <summary>  
        /// 修改config文件(ConnectionString节点)  
        /// </summary>  
        /// <param name="name">键</param>  
        /// <param name="value">要修改成的值</param>  
        public static void UpdateConnectionString(string name, string value)
        {
            XmlDocument doc = new XmlDocument();
            //获得配置文件的全路径   
            string strFileName = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Web.config";
            doc.Load(strFileName);
            //找出名称为“add”的所有元素   
            XmlNodeList nodes = doc.GetElementsByTagName("add");
            for (int i = 0; i < nodes.Count; i++)
            {
                //获得将当前元素的key属性   
                XmlAttribute _name = nodes[i].Attributes["name"];
                //根据元素的第一个属性来判断当前的元素是不是目标元素   
                if (_name != null)
                {
                    if (_name.Value == name)
                    {
                        //对目标元素中的第二个属性赋值   
                        _name = nodes[i].Attributes["connectionString"];

                        _name.Value = value;
                        break;
                    }
                }
            }
            //保存上面的修改   
            doc.Save(strFileName);
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
        private  LiteralControl DynamicDIV(StringBuilder Value)
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
    text-align: center;'> <span >软件说明</span> <button id='pageE' style='color: #fff; float: right; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: -1.5%;'onclick='Close()'>关闭</button></header>
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
 //关闭页面按钮特效
    //按钮特效
    var yieldButton = document.getElementById('pageE');
    yieldButton.onmouseleave = function () {
        yieldButton.style.opacity = 10;
    }
    yieldButton.onmouseenter = function () {
        yieldButton.style.opacity = 0.7;
    }
    //关闭本页面
    function Close() {
        location.reload();//重新刷新网页
    }
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
            builder.Append(@" 
                <style>
                    ul {
                        list-style: none;
                    }

                    a {
                        text-decoration: none;
                    }
                    /*一级菜单样式*/
                    #nav {
                        width: 60.2%;
                        height: 50%;
                        margin: 0px auto;
                        background: #3bd5e5;
                        font-size: 30%;
                        font-family: 微软雅黑;
                        float: left;
                        position: relative;
                        top: 0.51rem;
                        text-align: center;
                    }

                        #nav ul li {
                            float: left;
                            /*包含块*/
                            position: relative;
                        }

                            #nav ul li a {
                                display: block;
                                width: 200px;
                                height: 40px;
                                line-height: 40px;
                                text-align: center;
                                color: #fff;
                            }

                                #nav ul li a:hover {
                                    color: #ffd800;
                                    background: #970606;
                                }
                            /*二级菜单样式*/
                            #nav ul li ul {
                                position: absolute;
                                top: 40px;
                                left: 0px;
                                display: none;
                            }

                                #nav ul li ul li {
                                    float: none;
                                }

                                    #nav ul li ul li a {
                                        background: #3bd5e5;
                                        border-top: 1px solid #ccc;
                                    }
                            /*一级菜单悬停时二级菜单可见*/
                            #nav ul li:hover ul {
                                display: block;
                            }
                </style>
                <div id='parameterDiv1' style='width: 30%; height: 8.5rem; display: inline-block; float: left; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; left: 80px;'>
                    <div style='float: left; width: 28%; height: 10%;'>
                        <p style='float: left; position: relative; top: 20%; font-size: 25%; text-align: left; margin-left: 1%; margin-top: 30%; width: 100%;'>设备类型：</p>
                    </div>
                    <div style='float: left; width: 72%; height: 10%; position: relative; z-index: 1'>
                        <div id='nav'>
                            <ul>
                                <li><a id='pitchText1'>Mitsubishi</a>
                                    <ul id='PLCname'>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div style='float: left; width: 100%; height: 20%;'>
                        <div style='float: left; width: 40%; height: 100%;'>
                            <p style='float: left; position: relative; top: 28%; left: -0.05rem; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 11%; width: 100%;'>全年产量目标：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter2' type='text' value='9999' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -10px; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>
                    <div style='float: left; width: 100%; height: 20%; position: relative; top: 18%;'>
                        <div style='float: left; width: 40%; height: 20%;'>
                            <p style='float: left; position: relative; top: 28%; left: -0.05rem; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 11%; width: 100%;'>当天产量目标：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter6' type='text' value='9999' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -60%; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>
                    <div style='float: left; width: 100%; height: 20%; position: relative; top: 10%;'>
                        <div style='float: left; width: 40%; height: 20%;'>
                            <p style='float: left; position: relative; top: 28%; left: -0.05rem; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 11%; width: 100%;'>当月产量目标：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter7' type='text' value='9999' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -60%; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>
                </div>
                <div id='parameterDiv2' style='width: 30%; height: 8.5rem; display: inline-block; float: inherit; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; right: -5%;'>
                    <div style='float: left; width: 28%; height: 10%;'>
                        <p style='float: left; position: relative; top: 20%; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 30%; width: 100%;'>产量地址：</p>
                    </div>
                    <div style='float: left; width: 72%; height: 10%; position: relative; z-index: 1'>
                        <div id='nav'>
                            <ul>
                                <li><a id='pitchText2'>D</a>
                                    <ul id='PLCDname'>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div style='float: left; width: 100%; height: 20%;'>
                        <div style='float: left; width: 40%; height: 12%;'>
                            <p style='float: left; position: relative; top: 28%; left: -0.02rem; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 34%; width: 100%;'>产量具体地址：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter3' type='text' value='0' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -10px; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>
                    <div style='float: left; width: 100%; height: 20%; position: relative; top: 15%;'>
                        <div style='float: left; width: 28%; height: 10%;'>
                            <p style='float: left; position: relative; top: 90%; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 30%; width: 100%;'>物料编码：</p>
                        </div>
                        <div style='float: left; width: 72%; height: 50%; position: relative; z-index: 1'>
                            <div id='nav'>
                                <ul>
                                    <li><a id='pitchText4'>D</a>
                                        <ul id='PLCDname1'>
                                        </ul>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>              
                    <div style='float: left; width: 100%; height: 20%; position: relative; top: 5%;'>
                        <div style='float: left; width: 40%; height: 12%;'>
                            <p style='float: left; position: relative; top: 28%; left: -0.02rem; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 34%; width: 100%;'>编码具体地址：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter8' type='text' value='0' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -10px; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>
                </div>
                <div id='parameterDiv3' style='width: 30%; height: 8.5rem; display: inline-block; float: right; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; right: 0px;'>
                    <div style='float: left; width: 28%; height: 10%;'>
                        <p style='float: left; position: relative; top: 20%; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 30%; width: 100%;'>速率地址：</p>
                    </div>
                    <div style='float: left; width: 72%; height: 10%; position: relative; z-index: 1'>
                        <div id='nav'>
                            <ul>
                                <li><a id='pitchText3'>M</a>
                                    <ul id='PLCDname2'>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>            
                    <div style='float: left; width: 100%; height: 20%;'>
                        <div style='float: left; width: 40%; height: 50%;'>
                            <p style='float: left; position: relative; top: 28%; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 22%; width: 100%;'>速率具体地址：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter4' type='text' value='0' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -10px; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>
                    <div style='float: left; width: 100%; height: 20%; position: relative; top: 15%;'>
                        <div style='float: left; width: 28%; height: 10%;'>
                            <p style='float: left; position: relative; top: 90%; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 30%; width: 100%;'>自动地址：</p>
                        </div>
                        <div style='float: left; width: 72%; height: 50%; position: relative; z-index: 1'>
                            <div id='nav'>
                                <ul>
                                    <li><a id='pitchText10'>D</a>
                                        <ul id='PLCDname10'>
                                        </ul>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>                   
                    <div style='float: left; width: 100%; height: 20%; position:relative;top:5%;'>
                        <div style='float: left; width: 40%; height: 50%;'>
                            <p style='float: left; position: relative; top: 28%; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 22%; width: 100%;'>自动具体地址：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter11' type='text' value='0' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -10px; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>
                     <div style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 80%; height: 10%; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; float: left; position: relative; top: 20%;left:-100%; '>
                    <header style='color: #fff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                        <button id='previous' type='button' style='color: #fff; float: initial; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: -2rem;'
                            onclick='previouse()'>
                            确定提交</button>
                        <button id='page' type='button' style='color: #fff; float: initial; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: 2rem;'
                            onclick='next()'>
                            取消</button>
                    </header>
                </div>
                    <script type='text/javascript'>
                        PLCpost();
                        PLCpostM1();
                        PLCpostM();
                        PLCpostD1();
                        PLCpostD();
                        //请求SQL数据库
                        SQLTOParameter();
                        //用于处理表格按钮的特效
                        Tablecss1();
                        //提交表单方法
                        function previouse() {
                            if (confirm('是否提交表单到SQL数据库？')) {
                                ParameterTOSQL();//修改参数数据
                            }
                           
                        }
                        function next() {
                            location.reload();//重新刷新网页
                        }
                    </script>
                </div> 
 </div>");
            DynamicDIV(builder);
            
        }
        /// <summary>
        /// 前端请求所有PLC类型的名称
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string PLCload()
        {
            string PLCName = string.Empty;
            foreach(var i in Enum.GetValues(typeof(PLC通讯规范接口.PLC)))
            {
                PLCName += $"<li id='{i}'><a>{i}</a></li>";
            }
            //下拉菜单选中 
            return PLCName;
        }
        /// <summary>
        /// 前端请求该PLC D区地址
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string PLCDLoad(string Data)
        {
          return PLCDSelecte(Convert.ToInt32(Enum.Parse(typeof(PLC), Data)));
        }
        private static string PLCDSelecte(int data)
        {
            string PLCName = string.Empty;
            switch (data)
            {
                case 0:
                    Enum.GetNames(typeof(Mitsubishi_D)).ToList().ForEach(s1 => { PLCName += $"<li id='{s1}'><a>{s1}</a></li>"; });
                    break;
                case 1:
                    Enum.GetNames(typeof(Siemens_D)).ToList().ForEach(s1 => { PLCName += $"<li id='{s1}'><a>{s1}</a></li>"; });
                    break;
                case 2:
                    Enum.GetNames(typeof(Modbus_TCP_D)).ToList().ForEach(s1 => { PLCName += $"<li id='{s1}'><a>{s1}</a></li>"; });
                    break;
                case 3:
                    Enum.GetNames(typeof(HMI_D)).ToList().ForEach(s1 => { PLCName += $"<li id='{s1}'><a>{s1}</a></li>"; });
                    break;
                case 4:
                case 5:
                case 6:
                    Enum.GetNames(typeof(Omron_D)).ToList().ForEach(s1 => { PLCName += $"<li id='{s1}'><a>{s1}</a></li>"; });
                    break;
            }
            return PLCName;
        }
        /// <summary>
        /// 前端请求该PLC M区地址
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string PLCMLoad(string Data)
        {
            return PLCMSelecte(Convert.ToInt32(Enum.Parse(typeof(PLC),Data)));
        }
        private static string PLCMSelecte(int data)
        {
            string PLCName = string.Empty;
            switch (data)
            {
                case 0:
                     Enum.GetNames(typeof(Mitsubishi_bit)).ToList().ForEach(s1=> { PLCName += $"<li id='{s1}'><a>{s1}</a></li>"; });
                    break;
                case 1:
                   Enum.GetNames(typeof(Siemens_bit)).ToList().ForEach(s1 => { PLCName += $"<li id='{s1}'><a>{s1}</a></li>"; });
                    break;
                case 2:
                   Enum.GetNames(typeof(Modbus_TCP_bit)).ToList().ForEach(s1 => { PLCName += $"<li id='{s1}'><a>{s1}</a></li>"; });
                    break;
                case 3:
                    Enum.GetNames(typeof(HMI_bit)).ToList().ForEach(s1 => { PLCName += $"<li id='{s1}'><a>{s1}</a></li>"; });
                    break;
                case 4:
                case 5:
                case 6:
                    Enum.GetNames(typeof(Omron_bit)).ToList().ForEach(s1 => { PLCName += $"<li id='{s1}'><a>{s1}</a></li>"; });
                    break;
            }
            return PLCName;
        }
        /// <summary>
        /// 前端提交表单到SQL数据库中
        /// </summary>
        /// <param name="pitchText1">PLC类型菜单</param>
        /// <param name="parameter2">全年产量目标</param>
        /// <param name="parameter6">当天产量目标</param>
        /// <param name="parameter7">当月产量目标</param>
        /// <param name="pitchText2">产量地址下拉菜单地址</param>
        /// <param name="parameter3">产量具体地址</param>
        /// <param name="pitchText4">物料编码下拉菜单</param>
        /// <param name="parameter8">编码具体地址</param>
        /// <param name="pitchText3">速率地址下拉菜单</param>
        /// <param name="parameter4">速率具体地址</param>
        /// <param name="pitchText10">自动地址下拉菜单</param>
        /// <param name="parameter11">自动具体地址</param>
        /// <param name=""></param>
        /// <returns></returns>
        [WebMethod]
        public static bool ParameterTOSQL(string pitchText1,string parameter2,string parameter6,string parameter7,string pitchText2,string parameter3
            ,string pitchText4,string parameter8,string pitchText3,string parameter4,string pitchText10,string parameter11)
        {
            try
            {
                //打开SQL数据库
                using (UppercomputerEntities2 db = new UppercomputerEntities2())
                {
                    //查询SQL数据库是否存在改数据
                    var data = db.ParameterWebs.FirstOrDefault();
                    if (data != null)
                    {
                        //SQl存在数据
                        data.产量具体地址 = parameter3 ?? "0";
                        data.产量地址 = pitchText2 ?? "D";
                        data.当月目标 = Convert.ToInt64(parameter7 ?? "0");
                        data.当班目标 = Convert.ToInt64(parameter6 ?? "0");
                        data.自动运行具体地址 = parameter11 ?? "0";
                        data.自动运行地址 = pitchText10 ?? "M";
                        data.设备 = pitchText1 ?? "Mitsubishi";
                        data.设备速率具体地址 = parameter4 ?? "0";
                        data.设备速率地址 = pitchText3 ?? "D";
                        data.全年产量目标 = Convert.ToInt64(parameter2 ?? "0");
                        data.物料编码 = pitchText4 ?? "D";
                        data.编码具体地址 = parameter8 ?? "0";
                    }
                    else
                    {
                        //SQL不存在该数据
                        ParameterWeb web = new ParameterWeb()
                        {
                            ID = 1,
                            产量具体地址 = parameter3 ?? "0",
                            产量地址 = pitchText2 ?? "D",
                            当月目标 = Convert.ToInt64(parameter7 ?? "0"),
                            当班目标 = Convert.ToInt64(parameter6 ?? "0"),
                            自动运行具体地址 = parameter11 ?? "0",
                            自动运行地址 = pitchText10 ?? "M",
                            设备 = pitchText1 ?? "Mitsubishi",
                            设备速率具体地址 = parameter4 ?? "0",
                            设备速率地址 = pitchText3 ?? "D",
                            全年产量目标 = Convert.ToInt64(parameter2 ?? "0"),
                            物料编码 = pitchText4 ?? "D",
                            编码具体地址 = parameter8 ?? "0"
                        };

                        db.ParameterWebs.Add(web);
                    }
                    //保存在SQL中
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 前端请求获取保存在SQL中的参数设置数据
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string SQLTOParameter()
        {
            using (UppercomputerEntities2 db = new UppercomputerEntities2())
            {
                var data = db.ParameterWebs.FirstOrDefault();
                if (data != null)
                {
                    return new JavaScriptSerializer().Serialize(data);//序列化参数设置对象
                }
                //SQL不存在该数据
                ParameterWeb web = new ParameterWeb()
                {
                    ID = 1,
                    产量具体地址 = "0",
                    产量地址 = "D",
                    当月目标 = Convert.ToInt64("0"),
                    当班目标 = Convert.ToInt64("0"),
                    自动运行具体地址 = "0",
                    自动运行地址 = "M",
                    设备 = "Mitsubishi",
                    设备速率具体地址 = "0",
                    设备速率地址 = "D",
                    全年产量目标 = Convert.ToInt64("0"),
                    物料编码 = "D",
                    编码具体地址 = "0"
                };
                return new JavaScriptSerializer().Serialize(web);
            }

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
  <button id='pageE' style='color: #fff; float: right; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: -1.5%;'
                         onclick='Close()'>关闭</button>
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
                    <button id='previous' type='button' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:-2rem;' onclick='previouse()'>上一页</button>
                            <button id='home' type='button' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:0rem;' onclick='Home()'>首页</button>
                    <button id='page' type='button' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:2rem;' onclick='next()'>下一页</button>
                  </header>
                </div>
                <script type='text/javascript'>
                 //下方导航栏按钮特效
                    Tablecss();
                   //鼠标移到子项 子项变色
                    Itembackground();
    //关闭页面按钮特效
    var yieldButton = document.getElementById('pageE');
    yieldButton.onmouseleave = function () {
        yieldButton.style.opacity = 10;
    }
    yieldButton.onmouseenter = function () {
        yieldButton.style.opacity = 0.7;
    }
    //关闭本页面
    function Close() {
        location.reload();//重新刷新网页
    }
                    //上一页触发方法
                    function previouse() {
                      Alarmregisterprevious();
                      //鼠标移到子项 子项变色
                      Itembackground();
                    }
        function Home()
        {
           //回首页
            GetAlarmSQL();
           //鼠标移到子项 子项变色
           Itembackground();
        }
        function next()
        {
              //下一页
               Alarmregisternext();
               //鼠标移到子项 子项变色
                Itembackground();
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
        /// 报警事件注册查询前端直接传入泛型集合对象
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string DisplayImagesInfo()
        {
            //打开SQL数据库
            using (UppercomputerEntities2 db = new UppercomputerEntities2())
            {
                //每页条数   
                const int pageSize = 10;
                //页码 0也就是第一条 
                int pageNum = 0;
                AlarmregisterPageNum = 0;
                var data = db.Event_message.ToList();
                if (data.Count > 0)
                {
                    //创建泛型集合保存数据
                    List<Tuple<int, List<Event_message>>> tuples = new List<Tuple<int, List<Event_message>>>();
                    while (pageNum * pageSize < data.Count)
                    {
                        var scheduletaiya = data.Skip(pageNum * pageSize).Take(pageSize).ToList();
                        tuples.Add(new Tuple<int, List<Event_message>>(pageNum, scheduletaiya));
                        pageNum += 1;
                    }
                    Alarmregistertuples = tuples;
                    //获取到数据返回第一页数据
                    return new JavaScriptSerializer().Serialize(tuples[0].Item2);
                }
                //获取不到数据 返回null
                return new JavaScriptSerializer().Serialize(new Event_message());
            }
        }
        /// <summary>
        /// 报警注册事件查询的当前页号
        /// </summary>
        static int AlarmregisterPageNum = 0;
        /// <summary>
        /// 报警注册事件保存的数据
        /// </summary>
        static List<Tuple<int, List<Event_message>>> Alarmregistertuples;
        /// <summary>
        /// 报警注册事件页面请求上一页
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Alarmregisterprevious()
        {
            //判断当前页
            if (AlarmregisterPageNum <= 0 || Alarmregistertuples.Count <= 1)
            {
                //达到首页
                return "false";
            }
            //进行上一页请求处理
            AlarmregisterPageNum -= 1;
            return new JavaScriptSerializer().Serialize(Alarmregistertuples[AlarmregisterPageNum].Item2);
        }
        /// <summary>
        /// 报警注册事件页面请求下一页
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Alarmregisternext()
        {
            //判断当前页
            if ((AlarmregisterPageNum + 1) >= Alarmregistertuples.Count)
            {
                //达到最后一页
                return "false";
            }
            //进行下一页请求处理
            AlarmregisterPageNum += 1;
            return new JavaScriptSerializer().Serialize(Alarmregistertuples[AlarmregisterPageNum].Item2);
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
  <button id='pageE' style='color: #fff; float: right; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: -1.5%;'
                         onclick='Close()'>关闭</button>
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
                    //请求数据首页
                    GetAlarmhistory();
                </script>
         <div style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width:100%; height:15%; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
                     <header style='color: #fff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                    <button id='previous' type='button' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:-2rem;' onclick='previouse()'>上一页</button>
                            <button id='home' type='button' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:0rem;' onclick='Home()'>首页</button>
                    <button id='page' type='button' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:2rem;' onclick='next()'>下一页</button>
                  </header>
                </div>
                <script type='text/javascript'>
                  //下方导航栏按钮特效
                    Tablecss();
                    //鼠标移到子项 子项变色
                    Itembackground();
       //关闭页面按钮特效
    var yieldButton = document.getElementById('pageE');
    yieldButton.onmouseleave = function () {
        yieldButton.style.opacity = 10;
    }
    yieldButton.onmouseenter = function () {
        yieldButton.style.opacity = 0.7;
    }
    //关闭本页面
    function Close() {
        location.reload();//重新刷新网页
    }
                    //上一页触发方法
                    function previouse() {
                    Alarmprevious();
                   //鼠标移到子项 子项变色
                    Itembackground();
                    }
        function Home()
        {
          //请求数据首页
          GetAlarmhistory();
         //鼠标移到子项 子项变色
          Itembackground();
        }
        function next()
        {
            Alarmnext();
           //鼠标移到子项 子项变色
           Itembackground();
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
        /// 报警页面查询的当前页号
        /// </summary>
        static int AlarmPageNum = 0;
        /// <summary>
        /// 报警页面保存的数据
        /// </summary>
        static List<Tuple<int, List<Alarmhistories>>> Alarmtuples;
        /// <summary>
        /// 报警事件历史数据查询前端直接传入泛型集合对象
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Displayhistory()
        {
            //打开SQL数据库
            using (UppercomputerEntities2 db = new UppercomputerEntities2())
            {
                //每页条数   
                const int pageSize = 5;
                //页码 0也就是第一条 
                int pageNum = 0;
                AlarmPageNum = 0;
                var data = db.Alarmhistory.ToList();
                if (data.Count > 0)
                {
                    //创建泛型集合保存数据
                    List<Tuple<int, List<Alarmhistories>>> tuples = new List<Tuple<int, List<Alarmhistories>>>();
                    while (pageNum * pageSize < data.Count)
                    {
                        var scheduletaiya = data.Skip(pageNum * pageSize).Take(pageSize).ToList();
                        tuples.Add(new Tuple<int, List<Alarmhistories>>(pageNum, scheduletaiya));
                        pageNum += 1;
                    }
                    Alarmtuples = tuples;
                    //获取到数据返回第一页数据
                    return new JavaScriptSerializer().Serialize(tuples[0].Item2);
                }
                //获取不到数据 返回null
                return new JavaScriptSerializer().Serialize(new Alarmhistories());
            }
        }
        /// <summary>
        /// 报警历史页面请求上一页
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Alarmprevious()
        {
            //判断当前页
            if (AlarmPageNum <= 0 || Alarmtuples.Count <= 1)
            {
                //达到首页
                return "false";
            }
            //进行上一页请求处理
            AlarmPageNum -= 1;
            return new JavaScriptSerializer().Serialize(Alarmtuples[AlarmPageNum].Item2);
        }
        /// <summary>
        /// 报警历史页面请求下一页
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Alarmnext()
        {
            //判断当前页
            if ((AlarmPageNum + 1) >= Alarmtuples.Count)
            {
                //达到最后一页
                return "false";
            }
            //进行下一页请求处理
            AlarmPageNum += 1;
            return new JavaScriptSerializer().Serialize(Alarmtuples[AlarmPageNum].Item2);
        }
        /// <summary>
        /// 页面自适应状态修改
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [WebMethod]
        public static string Fullscreene(bool name)
        {
            Fullscreen = name;
            return new JavaScriptSerializer().Serialize(Fullscreen);
        }
        /// <summary>
        /// 页面自适应状态读取
        /// </summary>
        /// <returns></returns>
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
  <button id='pageE' style='color: #fff; float: right; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: -1.5%;'
                         onclick='Close()'>关闭</button>
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
                                    <button id='yieldq' type='button' style='color: #fff; float: initial; font-size: 70%; font-weight: 900; text-align: center; margin-right: 0%; margin-top: 0.2rem; height: 0.8rem; width: 2.5rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: 0rem;'
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
                                    <button id='Alarm' type='button' style='color: #fff;  float: initial; font-size: 70%; font-weight: 900; text-align: center; margin-right: 0%; margin-top: 0.2rem; height: 0.8rem; width: 2.5rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: 0rem;'
                                        onclick='GOAlarm()'  >
                                        进入异常监控页面</button>
                                </header>
                            </div>
                        </div>
                    </div>
                    <script type='text/javascript'>
                        //按钮特效
                        var yieldButton1 = document.getElementById('yieldq');
                        yieldButton1.onmouseleave = function () {
                           yieldButton1.style.opacity = 10;
                        }
                        yieldButton1.onmouseenter = function () {
                            yieldButton1.style.opacity = 0.7;
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
                            window.open('../报警页面web/WebForm3.aspx');
                        }
                    </script>
                </div>
                <script type='text/javascript'>
       //关闭页面按钮特效
    var yieldButton = document.getElementById('pageE');
    yieldButton.onmouseleave = function () {
        yieldButton.style.opacity = 10;
    }
    yieldButton.onmouseenter = function () {
        yieldButton.style.opacity = 0.7;
    }
    //关闭本页面
    function Close() {
        location.reload();//重新刷新网页
    }
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
        /// <summary>
        /// 用户点击产量监控界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"<div id='Tablediv' style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 98.7%; height: 7.5rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
                    <header style='color: #ffffff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                        <span>产量历史查看</span>
  <button id='pageE' style='color: #fff; float: right; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: -1.5%;'
                         onclick='Close()'>关闭</button>
                    </header>
                    <table style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 98.7%; height: 0.8rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; position: relative; top: 0rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%;'
                        id='Abnorma1'>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>生产时间</th>
                                <th>当天产量</th>
                                <th>当天目标</th>
                                <th>异常次数</th>
                                <th>异常时长</th>
                            </tr>
                        </thead>
                        <tbody style='width: 100%; height: 100%; line-height: 50px; background-size: 100% 100%; text-align: center; color: darkgray; position: relative; top: 10px; left: 0px; color: #ffffff;'
                            id='tbMaincl'>
                        </tbody>
                    </table>
                </div>
                <script type='text/javascript'>
                     //请求后端获取SQL中的产量表
                    GetSQLoutput();
                </script>
         <div style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width:100%; height:15%; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
                     <header style='color: #fff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                    <button id='previous' type='button' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:-2rem;' onclick='previouse()'>上一页</button>
                            <button id='home' type='button' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:0rem;' onclick='Home()'>首页</button>
                    <button id='page' type='button' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.6rem; width:1rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:2rem;' onclick='next()'>下一页</button>
                  </header>
                </div>
                <script type='text/javascript'>
                  //下方导航栏按钮特效
                    Tablecss();
                    //鼠标移到子项 子项变色
                    Itembackground();
       //关闭页面按钮特效
    var yieldButton = document.getElementById('pageE');
    yieldButton.onmouseleave = function () {
        yieldButton.style.opacity = 10;
    }
    yieldButton.onmouseenter = function () {
        yieldButton.style.opacity = 0.7;
    }
    //关闭本页面
    function Close() {
        location.reload();//重新刷新网页
    }
                    //上一页触发方法
                    function previouse() {
              //请求上一页数据
             Outputprevious();
           //鼠标移到子项 子项变色
             Itembackground();
                    }
        function Home()
        {
            //请求首页数据
             GetSQLoutput();
           //鼠标移到子项 子项变色
             Itembackground();
        }
        function next()
        {
               //请求下一页数据
             Outputnext();
           //鼠标移到子项 子项变色
             Itembackground();
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
        /// 产量查询的当前页号
        /// </summary>
        static int OutputPageNum = 0;
        /// <summary>
        /// 产量保存的数据
        /// </summary>
        static List<Tuple<int, List<Scheduletaiyaki>>> Outputtuples;
        /// <summary>
        /// 前端请求后端获取SQL中存在的产量数据表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string GetSQLoutput()
        {
            //打开SQL数据库
            using (UppercomputerEntities2 db = new UppercomputerEntities2())
            {
                //每页条数   
                const int pageSize = 10;
                //页码 0也就是第一条 
                int pageNum = 0;
                OutputPageNum = 0;
                var data = db.Scheduletaiyakis.ToList();
                if (data.Count > 0)
                {
                    //创建泛型集合保存数据
                    List<Tuple<int, List<Scheduletaiyaki>>> tuples = new List<Tuple<int, List<Scheduletaiyaki>>>();
                    while (pageNum * pageSize < data.Count)
                    {
                        var scheduletaiya = data.Skip(pageNum * pageSize).Take(pageSize).ToList();
                        tuples.Add(new Tuple<int, List<Scheduletaiyaki>>(pageNum, scheduletaiya));
                        pageNum += 1;
                    }
                    Outputtuples = tuples;
                    //获取到数据返回第一页数据
                    return new JavaScriptSerializer().Serialize(tuples[0].Item2);
                }
                //获取不到数据 返回null
                return new JavaScriptSerializer().Serialize(new Scheduletaiyaki());
            }
        }
        /// <summary>
        /// 前端请求返回产量首页
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Outputrefresh()
        {          
            return GetSQLoutput();
        }
        /// <summary>
        /// 前端请求返回产量上一页
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Outputprevious()
        {
            //判断当前页
            if(OutputPageNum<=0||Outputtuples.Count<=1)
            {
                //达到首页
                return "false";
            }
            //进行上一页请求处理
            OutputPageNum -= 1;
            return new JavaScriptSerializer().Serialize(Outputtuples[OutputPageNum].Item2);
        }
        /// <summary>
        /// 前端请求返回产量下一页
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string Outputnext()
        {
            //判断当前页
            if ((OutputPageNum+1) >= Outputtuples.Count )
            {
                //达到最后一页
                return "false";
            }
            //进行下一页请求处理
            OutputPageNum += 1;
            return new JavaScriptSerializer().Serialize(Outputtuples[OutputPageNum].Item2);
        }
    }
    /// <summary>
    /// 用于区块处理
    /// </summary>
    class Blockprocessing
    {
        static PlaceHolder placeHolder;
        public Blockprocessing(PlaceHolder placeHolder2)
        {
            placeHolder = placeHolder2;
        }
        public static LiteralControl Blockp(StringBuilder Value)
        {
            placeHolder.Controls.Clear();
            LiteralControl literal = new LiteralControl(Value.ToString());
            placeHolder.Controls.Add(literal);
            return literal;
        }
    }
}