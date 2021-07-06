<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="HTML布局学习.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="参数页面布局样式.css" />
    <link rel="stylesheet" href="参数设置界面css/参数设置button区域布局.css" />
    <link rel="stylesheet" href="参数设置界面css/主显示区样式.css" />
    <script src="报警视图jsPOST/AlarmSQL_View.js"></script>
    <script src="报警视图jsPOST/Alarmhistory_View.js"></script>
    <title>数据展示参数</title>
    <!-- 引入jquery前后端互交 -->
    <script src="Echarts/jquery-3.5.1.min.js"></script>
    <!-- 引入 echarts.js -->
    <script src="Echarts/Echarts/echarts.js"></script>
    <script src="Echarts/customed.js"></script>
    <script src="JavaScript.js"></script>
    <script src="控件特效样式/Navigation.js"></script>
    <!-- 页面自适应 -->
    <script src="参数页面自适应js/Selfadaption.js"></script>
     <!-- 引入 参数设置js处理与后端互交-->
    <script src="参数设置界面css/参数设置js与后端处理.js"></script>
     <!-- 引入 产量设置界面js处理与后端互交-->
    <script src="数值显示jsPOST/产量页面处理JS.js"></script>
    <!-- 引入 雪花飘落特效 -->
    <link rel="stylesheet" href="樱花特效css/style.css" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no" />
    <!-- 引入 樱花特效 -->
    <meta content="en-us" http-equiv="Content-Language" />
    <meta name="viewport" content="width=device-width, initial-scale=0.9" />
    <script src="樱花飘落js/hm.js"></script>
    <script type="text/javascript">
        var d = new Date()
        var time = d.getHours()
    </script>
    <style>
        @-webkit-keyframes flipInX {
            0% {
                -webkit-transform: perspective(400px) rotateX(90deg);
                transform: perspective(400px) rotateX(90deg);
                opacity: 0
            }

            40% {
                -webkit-transform: perspective(400px) rotateX(-10deg);
                transform: perspective(400px) rotateX(-10deg)
            }

            70% {
                -webkit-transform: perspective(400px) rotateX(10deg);
                transform: perspective(400px) rotateX(10deg)
            }

            100% {
                -webkit-transform: perspective(400px) rotateX(0);
                transform: perspective(400px) rotateX(0);
                opacity: 1
            }
        }

        @keyframes flipInX {
            0% {
                -webkit-transform: perspective(400px) rotateX(90deg);
                -ms-transform: perspective(400px) rotateX(90deg);
                transform: perspective(400px) rotateX(90deg);
                opacity: 0
            }

            40% {
                -webkit-transform: perspective(400px) rotateX(-10deg);
                -ms-transform: perspective(400px) rotateX(-10deg);
                transform: perspective(400px) rotateX(-10deg)
            }

            70% {
                -webkit-transform: perspective(400px) rotateX(10deg);
                -ms-transform: perspective(400px) rotateX(10deg);
                transform: perspective(400px) rotateX(10deg)
            }

            100% {
                -webkit-transform: perspective(400px) rotateX(0);
                -ms-transform: perspective(400px) rotateX(0);
                transform: perspective(400px) rotateX(0);
                opacity: 1
            }
        }

        @-webkit-keyframes fadeIn {
            0% {
                opacity: 0
            }

            100% {
                opacity: 1
            }
        }

        @keyframes fadeIn {
            0% {
                opacity: 0
            }

            100% {
                opacity: 1
            }
        }

        @-webkit-keyframes fadeInDown {
            0% {
                opacity: 0;
                -webkit-transform: translateY(-20px);
                transform: translateY(-20px)
            }

            100% {
                opacity: 1;
                -webkit-transform: translateY(0);
                transform: translateY(0)
            }
        }

        @keyframes fadeInDown {
            0% {
                opacity: 0;
                -webkit-transform: translateY(-20px);
                -ms-transform: translateY(-20px);
                transform: translateY(-20px)
            }

            100% {
                opacity: 1;
                -webkit-transform: translateY(0);
                -ms-transform: translateY(0);
                transform: translateY(0)
            }
        }

        canvas {
            padding: 0;
            margin: 0;
            position: absolute;
            z-index: -1;
            left: 0px;
        }
    </style>
</head>
<body class="t_container">
    <form id="form1" runat="server">
        <!-- 樱花飘落 -->
        <canvas id="sakura" width="0" height="0"></canvas>
        <div id="content" style="z-index: 2; position: relative;">
            <div class="search_part">
            </div>
        </div>

        <header class=" t_h_bg">
            <span class="t_h_bg_frin">数据展示参数</span>
        </header>
        <div class="t_box_little">
            <div id="Buttonnavigation" class="t_box">
                <%--导航栏按钮--%>
                <asp:Button ID="Button2" runat="server" Text="参数设置" BorderStyle="None" CssClass="Crystalbutton" ToolTip="参数设置" OnClick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" Text="报警查询" BorderStyle="None" CssClass="Crystalbutton" ToolTip="报警查询" OnClick="Button3_Click" />
                <asp:Button ID="Button4" runat="server" Text="报警历史" BorderStyle="None" CssClass="Crystalbutton" ToolTip="报警历史" OnClick="Button4_Click" />
                <asp:Button ID="Button5" runat="server" Text="产量查询" BorderStyle="None" CssClass="Crystalbutton" ToolTip="产量查询" OnClick="Button5_Click" />
                <asp:Button ID="Button6" runat="server" Text="页面监控" BorderStyle="None" CssClass="Crystalbutton" ToolTip="产量预设" OnClick="Button6_Click" />
                <asp:Button ID="Button7" runat="server" Text="关于" BorderStyle="None" CssClass="Crystalbutton" ToolTip="关于" OnClick="Button7_Click" />
                <script type='text/javascript'>
                    //处理导航栏按钮特效
                    Navigationcss();
                </script>
            </div>
        </div>
        <div class="t_box_big">
            <div id="MainActivity" class="t_boxbig">
                <%--该控件用于动态生成按钮类型的内容与布局--%>
                <%--   <header style = 'color: #ffffff;
    font-size: 35%;
    text-align: center;
    position: relative;
    margin-top: 0.3rem;
    top: -10px;
    text-align: center;'> <span >软件说明</span> <button id='pageE' style='color: #fff; float: right; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: -1.5%;'
                            onclick='Close()'>关闭</button>  </header>
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
</ div >--%>
                <%--   下拉菜单样式--%>
<%--                <style>
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
                </style>--%>
                 <%-- PLC类型菜单 --%>
               <%-- <div id='parameterDiv1' style='width: 30%; height: 8.5rem; display: inline-block; float: left; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; left: 80px;'>
                    <div style="float: left; width: 28%; height: 10%;">
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
                    <%-- 全年产量目标文本框 --%>
                   <%-- <div style='float: left; width: 100%; height: 20%;'>
                        <div style='float: left; width: 40%; height: 100%;'>
                            <p style='float: left; position: relative; top: 28%; left: -0.05rem; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 11%; width: 100%;'>全年产量目标：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter2' type='text' value='9999' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -10px; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>--%>
                    <%-- 当天产量目标文本框 --%>
                   <%-- <div style='float: left; width: 100%; height: 20%; position: relative; top: 18%;'>
                        <div style='float: left; width: 40%; height: 20%;'>
                            <p style='float: left; position: relative; top: 28%; left: -0.05rem; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 11%; width: 100%;'>当天产量目标：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter6' type='text' value='9999' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -60%; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>--%>
                    <%-- 当月产量目标文本框 --%>
                  <%--  <div style='float: left; width: 100%; height: 20%; position: relative; top: 10%;'>
                        <div style='float: left; width: 40%; height: 20%;'>
                            <p style='float: left; position: relative; top: 28%; left: -0.05rem; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 11%; width: 100%;'>当月产量目标：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter7' type='text' value='9999' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -60%; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>
                </div>--%>
                 <%-- 产量地址下拉菜单 --%>
               <%-- <div id='parameterDiv2' style='width: 30%; height: 8.5rem; display: inline-block; float: inherit; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; right: -5%;'>
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
                    </div>--%>
                    <%-- 产量具体地址文本框 --%>
                <%--    <div style='float: left; width: 100%; height: 20%;'>
                        <div style='float: left; width: 40%; height: 12%;'>
                            <p style='float: left; position: relative; top: 28%; left: -0.02rem; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 34%; width: 100%;'>产量具体地址：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter3' type='text' value='0' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -10px; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>--%>
                    <%-- 物料编码下拉菜单 --%>
                  <%--  <div style='float: left; width: 100%; height: 20%; position: relative; top: 15%;'>
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
                    </div>             --%> 
                    <%-- 编码具体地址文本框 --%>
               <%--     <div style='float: left; width: 100%; height: 20%; position: relative; top: 5%;'>
                        <div style='float: left; width: 40%; height: 12%;'>
                            <p style='float: left; position: relative; top: 28%; left: -0.02rem; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 34%; width: 100%;'>编码具体地址：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter8' type='text' value='0' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -10px; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>
                </div>--%>
                   <%-- 速率地址下拉菜单 --%>
                <%--<div id='parameterDiv3' style='width: 30%; height: 8.5rem; display: inline-block; float: right; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; right: 0px;'>
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
                    </div>            --%>
                    <%-- 速率具体地址文本框 --%>
                 <%--   <div style='float: left; width: 100%; height: 20%;'>
                        <div style='float: left; width: 40%; height: 50%;'>
                            <p style='float: left; position: relative; top: 28%; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 22%; width: 100%;'>速率具体地址：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter4' type='text' value='0' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -10px; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>--%>
                    <%-- 自动地址下拉菜单 --%>
                 <%--   <div style='float: left; width: 100%; height: 20%; position: relative; top: 15%;'>
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
                    </div>                --%>   
                    <%-- 自动具体地址文本框 --%>
                   <%-- <div style='float: left; width: 100%; height: 20%; position:relative;top:5%;'>
                        <div style='float: left; width: 40%; height: 50%;'>
                            <p style='float: left; position: relative; top: 28%; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 22%; width: 100%;'>自动具体地址：</p>
                        </div>
                        <div style='float: left; width: 60%; height: 50%; position: relative; z-index: 0;'>
                            <input id='parameter11' type='text' value='0' style='margin-left: 0.0rem; width: 50%; margin-top: 0.3rem; position: relative; top: -10px; font-size: 25%; height: 50%; border-radius: 0.1rem;'></input>
                        </div>
                    </div>--%>
                     <%-- 下方导航栏 提交表单 --%>
                   <%--  <div style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 80%; height: 10%; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; float: left; position: relative; top: 20%;left:-100%; '>
                    <header style='color: #fff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                        <button id='previous' style='color: #fff; float: initial; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: -2rem;'
                            onclick='previouse()'>
                            确定提交</button>
                        <button id='page' style='color: #fff; float: initial; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: 2rem;'
                            onclick='next()'>
                            取消</button>
                    </header>
                </div>--%>
                      <%-- 参数界面js代码处理 --%>
                <%--    <script type="text/javascript">
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
                            //if (confirm("是否提交表单到SQL数据库？")) {
                                ParameterTOSQL();//修改参数数据
                            //}
                           
                        }
                        function next() {
                            location.reload();//重新刷新网页
                        }
                    </script>--%>
               <%-- </div>--%>
                <script type='text/javascript'>
                    function paramete() {
                        //区块一自适应
                        var parameterDiv = document.getElementById('parameterDiv1');

                        //判断按钮导航栏屏幕宽度 标准是1920*969 已知整体Html 1个rem等于100px
                        if (document.body.clientWidth >= 600 && document.body.clientWidth < 6000) {
                            //parameterDiv.style.width = (document.body.clientWidth / 480) + 'rem';
                            //parameterDiv.style.marginLeft = (document.body.clientHeight / 9690) + 'rem';
                            //parameterDiv.style.left = (document.body.clientHeight / 1200) + 'rem';
                        }
                        //判断高度
                        if (document.body.clientHeight > 200 && document.body.clientHeight < 3000) {
                            parameterDiv.style.height = (document.body.clientHeight / 114) + 'rem';
                        }
                        //区块二自适应
                        var parameterDiv = document.getElementById('parameterDiv2');

                        //判断按钮导航栏屏幕宽度 标准是1920*969 已知整体Html 1个rem等于100px
                        if (document.body.clientWidth >= 600 && document.body.clientWidth < 6000) {
                            //parameterDiv.style.width = (document.body.clientWidth / 480) + 'rem';
                            //parameterDiv.style.marginLeft = (document.body.clientHeight / 9690) + 'rem';
                            //parameterDiv.style.right = '-' + (document.body.clientHeight / 480) + 'rem';
                        }
                        //判断高度
                        if (document.body.clientHeight > 200 && document.body.clientHeight < 3000) {
                            parameterDiv.style.height = (document.body.clientHeight / 114) + 'rem';
                        }
                        //区块三自适应
                        var parameterDiv = document.getElementById('parameterDiv3');

                        //判断按钮导航栏屏幕宽度 标准是1920*969 已知整体Html 1个rem等于100px
                        if (document.body.clientWidth >= 600 && document.body.clientWidth < 6000) {
                            //parameterDiv.style.width = (document.body.clientWidth / 480) + 'rem';
                            //parameterDiv.style.marginLeft = (document.body.clientHeight / 9690) + 'rem';
                        }
                        //判断高度
                        if (document.body.clientHeight > 200 && document.body.clientHeight < 3000) {
                            parameterDiv.style.height = (document.body.clientHeight / 114) + 'rem';
                        }
                    }
                    //用于处理文本框特效
                    //Parametertext();
                    //定时刷新自适应代码
                    setInterval(function () {
                        paramete();
                    }, 1000);
                </script>
                <%--      <div id='Tablediv' style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 98.7%; height: 7.5rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
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
                        <tbody style='width: 98.7%; height: 100%; line-height: 50px; background-size: 100% 100%; text-align: center; color: darkgray; position: relative; top: 10px; left: 0px; color: #ffffff;'
                            id='tbMain'>
                        </tbody>
                    </table>
                </div>
                <script type='text/javascript'>
                    GetAlarmSQL();
                </script>
                <div style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 100%; height: 15%; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; float: inline-end; position: relative; top: -0rem;'>
                    <header style='color: #fff; font-size: 70%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                        <button id='previous' style='color: #fff; float: initial; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: -2rem;'
                            onclick='previouse()'>
                            上一页</button>
                        <button id='home' style='color: #fff; float: initial; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: 0rem;'
                            onclick='Home()'>
                            首页</button>
                        <button id='page' style='color: #fff; float: initial; font-size: 50%; text-align: center; margin-left: 0.0rem; margin-top: 0.0rem; height: 0.5rem; width: 1rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: 2rem;'
                            onclick='next()'>
                            下一页</button>
                    </header>
                </div>
                <script type='text/javascript'>
                    //下方导航栏按钮特效
                    Tablecss();
                    //鼠标移到子项 子项变色s
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
                        alert("正在请求后端获取上一页数据");
                    }
                    function Home() {
                        alert("正在请求后端获取首页数据");
                    }
                    function next() {
                        alert("正在请求后端获取下一页数据");
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
                </script>--%>

                <%--          <div id='Tabledivee' style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 98.7%; height: 8.5rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
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
                            window.open('WebForm3.aspx');
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
                            navigation.style.height = (document.body.clientHeight / 116.7469879518072289156626506024) + 'rem';
                            navigation.style.marginTop = (document.body.clientHeight / 9690) + 'rem';
                        }
                    }, 300);
                </script>--%>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>
        </div>

        <%-- 樱花飘落特效js加载--%>
        <script type="text/javascript">
            var last_kw = '';
            var max_sug_len = 1; //搜索建议最短触发长度
            function get_suggest() {
                var kw = document.getElementById('search_input').value;
                var clear = document.getElementById('clear');
                if (kw) clear.style.display = 'block';
                else clear.style.display = 'none';
                if (kw == last_kw) return;
                last_kw = kw;
                if (!kw || kw.length < max_sug_len) {
                    close_sug();
                    return;
                }
                var script = document.createElement('script');
                script.type = 'text/javascript';
                script.src = 'http://sugs.m.sm.cn/web?t=w&uc_param_str=dnnwnt&scheme=http&fr=android&bid=1&q=' + encodeURIComponent(kw) + '&_=' + new Date().getTime() + '&callback=jsonp3';
                var head = document.querySelector('head');
                script.onload = function () {
                    head.removeChild(script);
                };
                head.appendChild(script);
            }
            function jsonp3(res) {
                var suggest = document.getElementById('suggest');
                if (!res.r || !res.r.length) {
                    suggest.style.display = 'none';
                    return;
                }
                var html = '';
                res.r.forEach(function (v) {
                    html += '<li>' + v.w + '<b></b></li>';
                });
                document.getElementById('suglist').innerHTML = html;
                suggest.style.display = 'block';
            }
            function close_sug() {
                last_kw = '';
                document.getElementById('suggest').style.display = 'none';
            }
            function move_input() {
                document.body.scrollTop = document.getElementById('search_form').offsetTop - 2;
            }
            function clear_seach() {
                var input = document.getElementById('search_input');
                input.value = '';
                document.getElementById('clear').style.display = 'none';
                close_sug();
                input.focus();
            }
            function search() {
                if (document.getElementById("search_input").value != "") {
                    //window.location.href = "http://m.baidu.com/s?ie=utf-8&rn=30&tn=baiduhome_pg&oq=%E5%BC%A0%E7%B1%BD%E6%B2%90&rsv_enter=0&wd=" + encodeURIComponent(document.getElementById("search_input").value);
                    window.location.href = "http://m.sm.cn/s?q=" + encodeURIComponent(document.getElementById("search_input").value) + "&from=smor&safe=1&snum=1";
                    document.getElementById("search_input").value = "";
                } return false;
            }

            document.getElementById('suglist').addEventListener('click', function (e) {
                var input = document.getElementById('search_input');
                if (e.target.tagName == 'B') {
                    input.value = e.target.parentNode.firstChild.textContent;
                    input.focus();
                } else if (e.target.tagName == 'LI') {
                    input.value = e.target.firstChild.textContent;
                    close_sug();
                    search();
                }
            });
            window.addEventListener('resize', move_input);
        </script>
        <script type="text/javascript">
            function search() { if (document.getElementById("search_input").value != "") { window.location.href = "http://m.baidu.com/s?ie=utf-8&rn=30&tn=baiduhome_pg&oq=%E5%BC%A0%E7%B1%BD%E6%B2%90&rsv_enter=0&wd=" + document.getElementById("search_input").value; document.getElementById("search_input").value = ""; } return false; }

        </script>
        <script id="sakura_point_vsh" type="x-shader/x_vertex">
uniform mat4 uProjection;
uniform mat4 uModelview;
uniform vec3 uResolution;
uniform vec3 uOffset;
uniform vec3 uDOF;  //x:focus distance, y:focus radius, z:max radius
uniform vec3 uFade; //x:start distance, y:half distance, z:near fade start

attribute vec3 aPosition;
attribute vec3 aEuler;
attribute vec2 aMisc; //x:size, y:fade

varying vec3 pposition;
varying float psize;
varying float palpha;
varying float pdist;

//varying mat3 rotMat;
varying vec3 normX;
varying vec3 normY;
varying vec3 normZ;
varying vec3 normal;

varying float diffuse;
varying float specular;
varying float rstop;
varying float distancefade;

void main(void) {
    // Projection is based on vertical angle
    vec4 pos = uModelview * vec4(aPosition + uOffset, 1.0);
    gl_Position = uProjection * pos;
    gl_PointSize = aMisc.x * uProjection[1][1] / -pos.z * uResolution.y * 0.5;
    
    pposition = pos.xyz;
    psize = aMisc.x;
    pdist = length(pos.xyz);
    palpha = smoothstep(0.0, 1.0, (pdist - 0.1) / uFade.z);
    
    vec3 elrsn = sin(aEuler);
    vec3 elrcs = cos(aEuler);
    mat3 rotx = mat3(
        1.0, 0.0, 0.0,
        0.0, elrcs.x, elrsn.x,
        0.0, -elrsn.x, elrcs.x
    );
    mat3 roty = mat3(
        elrcs.y, 0.0, -elrsn.y,
        0.0, 1.0, 0.0,
        elrsn.y, 0.0, elrcs.y
    );
    mat3 rotz = mat3(
        elrcs.z, elrsn.z, 0.0, 
        -elrsn.z, elrcs.z, 0.0,
        0.0, 0.0, 1.0
    );
    mat3 rotmat = rotx * roty * rotz;
    normal = rotmat[2];
    
    mat3 trrotm = mat3(
        rotmat[0][0], rotmat[1][0], rotmat[2][0],
        rotmat[0][1], rotmat[1][1], rotmat[2][1],
        rotmat[0][2], rotmat[1][2], rotmat[2][2]
    );
    normX = trrotm[0];
    normY = trrotm[1];
    normZ = trrotm[2];
    
    const vec3 lit = vec3(0.6917144638660746, 0.6917144638660746, -0.20751433915982237);
    
    float tmpdfs = dot(lit, normal);
    if(tmpdfs < 0.0) {
        normal = -normal;
        tmpdfs = dot(lit, normal);
    }
    diffuse = 0.4 + tmpdfs;
    
    vec3 eyev = normalize(-pos.xyz);
    if(dot(eyev, normal) > 0.0) {
        vec3 hv = normalize(eyev + lit);
        specular = pow(max(dot(hv, normal), 0.0), 20.0);
    }
    else {
        specular = 0.0;
    }
    
    rstop = clamp((abs(pdist - uDOF.x) - uDOF.y) / uDOF.z, 0.0, 1.0);
    rstop = pow(rstop, 0.5);
    //-0.69315 = ln(0.5)
    distancefade = min(1.0, exp((uFade.x - pdist) * 0.69315 / uFade.y));
}
        </script>
        <script id="sakura_point_fsh" type="x-shader/x_fragment">
#ifdef GL_ES
//precision mediump float;
precision highp float;
#endif

uniform vec3 uDOF;  //x:focus distance, y:focus radius, z:max radius
uniform vec3 uFade; //x:start distance, y:half distance, z:near fade start

const vec3 fadeCol = vec3(0.08, 0.03, 0.06);

varying vec3 pposition;
varying float psize;
varying float palpha;
varying float pdist;

//varying mat3 rotMat;
varying vec3 normX;
varying vec3 normY;
varying vec3 normZ;
varying vec3 normal;

varying float diffuse;
varying float specular;
varying float rstop;
varying float distancefade;

float ellipse(vec2 p, vec2 o, vec2 r) {
    vec2 lp = (p - o) / r;
    return length(lp) - 1.0;
}

void main(void) {
    vec3 p = vec3(gl_PointCoord - vec2(0.5, 0.5), 0.0) * 2.0;
    vec3 d = vec3(0.0, 0.0, -1.0);
    float nd = normZ.z; //dot(-normZ, d);
    if(abs(nd) < 0.0001) discard;
    
    float np = dot(normZ, p);
    vec3 tp = p + d * np / nd;
    vec2 coord = vec2(dot(normX, tp), dot(normY, tp));
    
    //angle = 15 degree
    const float flwrsn = 0.258819045102521;
    const float flwrcs = 0.965925826289068;
    mat2 flwrm = mat2(flwrcs, -flwrsn, flwrsn, flwrcs);
    vec2 flwrp = vec2(abs(coord.x), coord.y) * flwrm;
    
    float r;
    if(flwrp.x < 0.0) {
        r = ellipse(flwrp, vec2(0.065, 0.024) * 0.5, vec2(0.36, 0.96) * 0.5);
    }
    else {
        r = ellipse(flwrp, vec2(0.065, 0.024) * 0.5, vec2(0.58, 0.96) * 0.5);
    }
    
    if(r > rstop) discard;
    
    vec3 col = mix(vec3(1.0, 0.8, 0.75), vec3(1.0, 0.9, 0.87), r);
    float grady = mix(0.0, 1.0, pow(coord.y * 0.5 + 0.5, 0.35));
    col *= vec3(1.0, grady, grady);
    col *= mix(0.8, 1.0, pow(abs(coord.x), 0.3));
    col = col * diffuse + specular;
    
    col = mix(fadeCol, col, distancefade);
    
    float alpha = (rstop > 0.001)? (0.5 - r / (rstop * 2.0)) : 1.0;
    alpha = smoothstep(0.0, 1.0, alpha) * palpha;
    
    gl_FragColor = vec4(col * 0.5, alpha);
}
        </script>
        <!-- effects -->
        <script id="fx_common_vsh" type="x-shader/x_vertex">
uniform vec3 uResolution;
attribute vec2 aPosition;

varying vec2 texCoord;
varying vec2 screenCoord;

void main(void) {
    gl_Position = vec4(aPosition, 0.0, 1.0);
    texCoord = aPosition.xy * 0.5 + vec2(0.5, 0.5);
    screenCoord = aPosition.xy * vec2(uResolution.z, 1.0);
}
        </script>
        <script id="bg_fsh" type="x-shader/x_fragment">
#ifdef GL_ES
//precision mediump float;
precision highp float;
#endif

uniform vec2 uTimes;

varying vec2 texCoord;
varying vec2 screenCoord;

void main(void) {
    vec3 col;
    float c;
    vec2 tmpv = texCoord * vec2(0.8, 1.0) - vec2(0.95, 1.0);
    c = exp(-pow(length(tmpv) * 1.8, 2.0));
    col = mix(vec3(0.02, 0.0, 0.03), vec3(0.96, 0.98, 1.0) * 1.5, c);
    gl_FragColor = vec4(col * 0.5, 1.0);
}
        </script>
        <script id="fx_brightbuf_fsh" type="x-shader/x_fragment">
#ifdef GL_ES
//precision mediump float;
precision highp float;
#endif
uniform sampler2D uSrc;
uniform vec2 uDelta;

varying vec2 texCoord;
varying vec2 screenCoord;

void main(void) {
    vec4 col = texture2D(uSrc, texCoord);
    gl_FragColor = vec4(col.rgb * 2.0 - vec3(0.5), 1.0);
}
        </script>
        <script id="fx_dirblur_r4_fsh" type="x-shader/x_fragment">
#ifdef GL_ES
//precision mediump float;
precision highp float;
#endif
uniform sampler2D uSrc;
uniform vec2 uDelta;
uniform vec4 uBlurDir; //dir(x, y), stride(z, w)

varying vec2 texCoord;
varying vec2 screenCoord;

void main(void) {
    vec4 col = texture2D(uSrc, texCoord);
    col = col + texture2D(uSrc, texCoord + uBlurDir.xy * uDelta);
    col = col + texture2D(uSrc, texCoord - uBlurDir.xy * uDelta);
    col = col + texture2D(uSrc, texCoord + (uBlurDir.xy + uBlurDir.zw) * uDelta);
    col = col + texture2D(uSrc, texCoord - (uBlurDir.xy + uBlurDir.zw) * uDelta);
    gl_FragColor = col / 5.0;
}
        </script>
        <!-- effect fragment shader template -->
        <script id="fx_common_fsh" type="x-shader/x_fragment">
#ifdef GL_ES
//precision mediump float;
precision highp float;
#endif
uniform sampler2D uSrc;
uniform vec2 uDelta;

varying vec2 texCoord;
varying vec2 screenCoord;

void main(void) {
    gl_FragColor = texture2D(uSrc, texCoord);
}
        </script>
        <!-- post processing -->
        <script id="pp_final_vsh" type="x-shader/x_vertex">
uniform vec3 uResolution;
attribute vec2 aPosition;
varying vec2 texCoord;
varying vec2 screenCoord;
void main(void) {
    gl_Position = vec4(aPosition, 0.0, 1.0);
    texCoord = aPosition.xy * 0.5 + vec2(0.5, 0.5);
    screenCoord = aPosition.xy * vec2(uResolution.z, 1.0);
}
        </script>
        <script id="pp_final_fsh" type="x-shader/x_fragment">
#ifdef GL_ES
//precision mediump float;
precision highp float;
#endif
uniform sampler2D uSrc;
uniform sampler2D uBloom;
uniform vec2 uDelta;
varying vec2 texCoord;
varying vec2 screenCoord;
void main(void) {
    vec4 srccol = texture2D(uSrc, texCoord) * 2.0;
    vec4 bloomcol = texture2D(uBloom, texCoord);
    vec4 col;
    col = srccol + bloomcol * (vec4(1.0) + srccol);
    col *= smoothstep(1.0, 0.0, pow(length((texCoord - vec2(0.5)) * 2.0), 1.2) * 0.5);
    col = pow(col, vec4(0.45454545454545)); //(1.0 / 2.2)
    
    gl_FragColor = vec4(col.rgb, 1.0);
    gl_FragColor.a = 1.0;
}
        </script>
        <script>
            // Utilities
            var Vector3 = {};
            var Matrix44 = {};
            Vector3.create = function (x, y, z) {
                return { 'x': x, 'y': y, 'z': z };
            };
            Vector3.dot = function (v0, v1) {
                return v0.x * v1.x + v0.y * v1.y + v0.z * v1.z;
            };
            Vector3.cross = function (v, v0, v1) {
                v.x = v0.y * v1.z - v0.z * v1.y;
                v.y = v0.z * v1.x - v0.x * v1.z;
                v.z = v0.x * v1.y - v0.y * v1.x;
            };
            Vector3.normalize = function (v) {
                var l = v.x * v.x + v.y * v.y + v.z * v.z;
                if (l > 0.00001) {
                    l = 1.0 / Math.sqrt(l);
                    v.x *= l;
                    v.y *= l;
                    v.z *= l;
                }
            };
            Vector3.arrayForm = function (v) {
                if (v.array) {
                    v.array[0] = v.x;
                    v.array[1] = v.y;
                    v.array[2] = v.z;
                }
                else {
                    v.array = new Float32Array([v.x, v.y, v.z]);
                }
                return v.array;
            };
            Matrix44.createIdentity = function () {
                return new Float32Array([1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0]);
            };
            Matrix44.loadProjection = function (m, aspect, vdeg, near, far) {
                var h = near * Math.tan(vdeg * Math.PI / 180.0 * 0.5) * 2.0;
                var w = h * aspect;

                m[0] = 2.0 * near / w;
                m[1] = 0.0;
                m[2] = 0.0;
                m[3] = 0.0;

                m[4] = 0.0;
                m[5] = 2.0 * near / h;
                m[6] = 0.0;
                m[7] = 0.0;

                m[8] = 0.0;
                m[9] = 0.0;
                m[10] = -(far + near) / (far - near);
                m[11] = -1.0;

                m[12] = 0.0;
                m[13] = 0.0;
                m[14] = -2.0 * far * near / (far - near);
                m[15] = 0.0;
            };
            Matrix44.loadLookAt = function (m, vpos, vlook, vup) {
                var frontv = Vector3.create(vpos.x - vlook.x, vpos.y - vlook.y, vpos.z - vlook.z);
                Vector3.normalize(frontv);
                var sidev = Vector3.create(1.0, 0.0, 0.0);
                Vector3.cross(sidev, vup, frontv);
                Vector3.normalize(sidev);
                var topv = Vector3.create(1.0, 0.0, 0.0);
                Vector3.cross(topv, frontv, sidev);
                Vector3.normalize(topv);

                m[0] = sidev.x;
                m[1] = topv.x;
                m[2] = frontv.x;
                m[3] = 0.0;

                m[4] = sidev.y;
                m[5] = topv.y;
                m[6] = frontv.y;
                m[7] = 0.0;

                m[8] = sidev.z;
                m[9] = topv.z;
                m[10] = frontv.z;
                m[11] = 0.0;

                m[12] = -(vpos.x * m[0] + vpos.y * m[4] + vpos.z * m[8]);
                m[13] = -(vpos.x * m[1] + vpos.y * m[5] + vpos.z * m[9]);
                m[14] = -(vpos.x * m[2] + vpos.y * m[6] + vpos.z * m[10]);
                m[15] = 1.0;
            };

            //
            var timeInfo = {
                'start': 0, 'prev': 0, // Date
                'delta': 0, 'elapsed': 0 // Number(sec)
            };

            //
            var gl;
            var renderSpec = {
                'width': 0,
                'height': 0,
                'aspect': 1,
                'array': new Float32Array(3),
                'halfWidth': 0,
                'halfHeight': 0,
                'halfArray': new Float32Array(3)
                // and some render targets. see setViewport()
            };
            renderSpec.setSize = function (w, h) {
                renderSpec.width = w;
                renderSpec.height = h;
                renderSpec.aspect = renderSpec.width / renderSpec.height;
                renderSpec.array[0] = renderSpec.width;
                renderSpec.array[1] = renderSpec.height;
                renderSpec.array[2] = renderSpec.aspect;

                renderSpec.halfWidth = Math.floor(w / 2);
                renderSpec.halfHeight = Math.floor(h / 2);
                renderSpec.halfArray[0] = renderSpec.halfWidth;
                renderSpec.halfArray[1] = renderSpec.halfHeight;
                renderSpec.halfArray[2] = renderSpec.halfWidth / renderSpec.halfHeight;
            };

            function deleteRenderTarget(rt) {
                gl.deleteFramebuffer(rt.frameBuffer);
                gl.deleteRenderbuffer(rt.renderBuffer);
                gl.deleteTexture(rt.texture);
            }

            function createRenderTarget(w, h) {
                var ret = {
                    'width': w,
                    'height': h,
                    'sizeArray': new Float32Array([w, h, w / h]),
                    'dtxArray': new Float32Array([1.0 / w, 1.0 / h])
                };
                ret.frameBuffer = gl.createFramebuffer();
                ret.renderBuffer = gl.createRenderbuffer();
                ret.texture = gl.createTexture();

                gl.bindTexture(gl.TEXTURE_2D, ret.texture);
                gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, w, h, 0, gl.RGBA, gl.UNSIGNED_BYTE, null);
                gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_WRAP_S, gl.CLAMP_TO_EDGE);
                gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_WRAP_T, gl.CLAMP_TO_EDGE);
                gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
                gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);

                gl.bindFramebuffer(gl.FRAMEBUFFER, ret.frameBuffer);
                gl.framebufferTexture2D(gl.FRAMEBUFFER, gl.COLOR_ATTACHMENT0, gl.TEXTURE_2D, ret.texture, 0);

                gl.bindRenderbuffer(gl.RENDERBUFFER, ret.renderBuffer);
                gl.renderbufferStorage(gl.RENDERBUFFER, gl.DEPTH_COMPONENT16, w, h);
                gl.framebufferRenderbuffer(gl.FRAMEBUFFER, gl.DEPTH_ATTACHMENT, gl.RENDERBUFFER, ret.renderBuffer);

                gl.bindTexture(gl.TEXTURE_2D, null);
                gl.bindRenderbuffer(gl.RENDERBUFFER, null);
                gl.bindFramebuffer(gl.FRAMEBUFFER, null);

                return ret;
            }
        </script>
        <script>
            function compileShader(shtype, shsrc) {
                var retsh = gl.createShader(shtype);

                gl.shaderSource(retsh, shsrc);
                gl.compileShader(retsh);

                if (!gl.getShaderParameter(retsh, gl.COMPILE_STATUS)) {
                    var errlog = gl.getShaderInfoLog(retsh);
                    gl.deleteShader(retsh);
                    console.error(errlog);
                    return null;
                }
                return retsh;
            }

            function createShader(vtxsrc, frgsrc, uniformlist, attrlist) {
                var vsh = compileShader(gl.VERTEX_SHADER, vtxsrc);
                var fsh = compileShader(gl.FRAGMENT_SHADER, frgsrc);

                if (vsh == null || fsh == null) {
                    return null;
                }

                var prog = gl.createProgram();
                gl.attachShader(prog, vsh);
                gl.attachShader(prog, fsh);

                gl.deleteShader(vsh);
                gl.deleteShader(fsh);

                gl.linkProgram(prog);
                if (!gl.getProgramParameter(prog, gl.LINK_STATUS)) {
                    var errlog = gl.getProgramInfoLog(prog);
                    console.error(errlog);
                    return null;
                }

                if (uniformlist) {
                    prog.uniforms = {};
                    for (var i = 0; i < uniformlist.length; i++) {
                        prog.uniforms[uniformlist[i]] = gl.getUniformLocation(prog, uniformlist[i]);
                    }
                }

                if (attrlist) {
                    prog.attributes = {};
                    for (var i = 0; i < attrlist.length; i++) {
                        var attr = attrlist[i];
                        prog.attributes[attr] = gl.getAttribLocation(prog, attr);
                    }
                }

                return prog;
            }

            function useShader(prog) {
                gl.useProgram(prog);
                for (var attr in prog.attributes) {
                    gl.enableVertexAttribArray(prog.attributes[attr]);;
                }
            }

            function unuseShader(prog) {
                for (var attr in prog.attributes) {
                    gl.disableVertexAttribArray(prog.attributes[attr]);;
                }
                gl.useProgram(null);
            }

            /////
            var projection = {
                'angle': 60,
                'nearfar': new Float32Array([0.1, 100.0]),
                'matrix': Matrix44.createIdentity()
            };
            var camera = {
                'position': Vector3.create(0, 0, 100),
                'lookat': Vector3.create(0, 0, 0),
                'up': Vector3.create(0, 1, 0),
                'dof': Vector3.create(10.0, 4.0, 8.0),
                'matrix': Matrix44.createIdentity()
            };

            var pointFlower = {};
            var meshFlower = {};
            var sceneStandBy = false;

            var BlossomParticle = function () {
                this.velocity = new Array(3);
                this.rotation = new Array(3);
                this.position = new Array(3);
                this.euler = new Array(3);
                this.size = 1.0;
                this.alpha = 1.0;
                this.zkey = 0.0;
            };

            BlossomParticle.prototype.setVelocity = function (vx, vy, vz) {
                this.velocity[0] = vx;
                this.velocity[1] = vy;
                this.velocity[2] = vz;
            };

            BlossomParticle.prototype.setRotation = function (rx, ry, rz) {
                this.rotation[0] = rx;
                this.rotation[1] = ry;
                this.rotation[2] = rz;
            };

            BlossomParticle.prototype.setPosition = function (nx, ny, nz) {
                this.position[0] = nx;
                this.position[1] = ny;
                this.position[2] = nz;
            };

            BlossomParticle.prototype.setEulerAngles = function (rx, ry, rz) {
                this.euler[0] = rx;
                this.euler[1] = ry;
                this.euler[2] = rz;
            };

            BlossomParticle.prototype.setSize = function (s) {
                this.size = s;
            };

            BlossomParticle.prototype.update = function (dt, et) {
                this.position[0] += this.velocity[0] * dt;
                this.position[1] += this.velocity[1] * dt;
                this.position[2] += this.velocity[2] * dt;

                this.euler[0] += this.rotation[0] * dt;
                this.euler[1] += this.rotation[1] * dt;
                this.euler[2] += this.rotation[2] * dt;
            };

            function createPointFlowers() {
                // get point sizes
                var prm = gl.getParameter(gl.ALIASED_POINT_SIZE_RANGE);
                renderSpec.pointSize = { 'min': prm[0], 'max': prm[1] };

                var vtxsrc = document.getElementById("sakura_point_vsh").textContent;
                var frgsrc = document.getElementById("sakura_point_fsh").textContent;

                pointFlower.program = createShader(
                    vtxsrc, frgsrc,
                    ['uProjection', 'uModelview', 'uResolution', 'uOffset', 'uDOF', 'uFade'],
                    ['aPosition', 'aEuler', 'aMisc']
                );

                useShader(pointFlower.program);
                pointFlower.offset = new Float32Array([0.0, 0.0, 0.0]);
                pointFlower.fader = Vector3.create(0.0, 10.0, 0.0);

                // paramerters: velocity[3], rotate[3]
                pointFlower.numFlowers = 1600;
                pointFlower.particles = new Array(pointFlower.numFlowers);
                // vertex attributes {position[3], euler_xyz[3], size[1]}
                pointFlower.dataArray = new Float32Array(pointFlower.numFlowers * (3 + 3 + 2));
                pointFlower.positionArrayOffset = 0;
                pointFlower.eulerArrayOffset = pointFlower.numFlowers * 3;
                pointFlower.miscArrayOffset = pointFlower.numFlowers * 6;

                pointFlower.buffer = gl.createBuffer();
                gl.bindBuffer(gl.ARRAY_BUFFER, pointFlower.buffer);
                gl.bufferData(gl.ARRAY_BUFFER, pointFlower.dataArray, gl.DYNAMIC_DRAW);
                gl.bindBuffer(gl.ARRAY_BUFFER, null);

                unuseShader(pointFlower.program);

                for (var i = 0; i < pointFlower.numFlowers; i++) {
                    pointFlower.particles[i] = new BlossomParticle();
                }
            }

            function initPointFlowers() {
                //area
                pointFlower.area = Vector3.create(20.0, 20.0, 20.0);
                pointFlower.area.x = pointFlower.area.y * renderSpec.aspect;

                pointFlower.fader.x = 10.0; //env fade start
                pointFlower.fader.y = pointFlower.area.z; //env fade half
                pointFlower.fader.z = 0.1;  //near fade start

                //particles
                var PI2 = Math.PI * 2.0;
                var tmpv3 = Vector3.create(0, 0, 0);
                var tmpv = 0;
                var symmetryrand = function () { return (Math.random() * 2.0 - 1.0); };
                for (var i = 0; i < pointFlower.numFlowers; i++) {
                    var tmpprtcl = pointFlower.particles[i];

                    //velocity
                    tmpv3.x = symmetryrand() * 0.3 + 0.8;
                    tmpv3.y = symmetryrand() * 0.2 - 1.0;
                    tmpv3.z = symmetryrand() * 0.3 + 0.5;
                    Vector3.normalize(tmpv3);
                    tmpv = 2.0 + Math.random() * 1.0;
                    tmpprtcl.setVelocity(tmpv3.x * tmpv, tmpv3.y * tmpv, tmpv3.z * tmpv);

                    //rotation
                    tmpprtcl.setRotation(
                        symmetryrand() * PI2 * 0.5,
                        symmetryrand() * PI2 * 0.5,
                        symmetryrand() * PI2 * 0.5
                    );

                    //position
                    tmpprtcl.setPosition(
                        symmetryrand() * pointFlower.area.x,
                        symmetryrand() * pointFlower.area.y,
                        symmetryrand() * pointFlower.area.z
                    );

                    //euler
                    tmpprtcl.setEulerAngles(
                        Math.random() * Math.PI * 2.0,
                        Math.random() * Math.PI * 2.0,
                        Math.random() * Math.PI * 2.0
                    );

                    //size
                    tmpprtcl.setSize(0.9 + Math.random() * 0.1);
                }
            }

            function renderPointFlowers() {
                //update
                var PI2 = Math.PI * 2.0;
                var limit = [pointFlower.area.x, pointFlower.area.y, pointFlower.area.z];
                var repeatPos = function (prt, cmp, limit) {
                    if (Math.abs(prt.position[cmp]) - prt.size * 0.5 > limit) {
                        //out of area
                        if (prt.position[cmp] > 0) {
                            prt.position[cmp] -= limit * 2.0;
                        }
                        else {
                            prt.position[cmp] += limit * 2.0;
                        }
                    }
                };
                var repeatEuler = function (prt, cmp) {
                    prt.euler[cmp] = prt.euler[cmp] % PI2;
                    if (prt.euler[cmp] < 0.0) {
                        prt.euler[cmp] += PI2;
                    }
                };

                for (var i = 0; i < pointFlower.numFlowers; i++) {
                    var prtcl = pointFlower.particles[i];
                    prtcl.update(timeInfo.delta, timeInfo.elapsed);
                    repeatPos(prtcl, 0, pointFlower.area.x);
                    repeatPos(prtcl, 1, pointFlower.area.y);
                    repeatPos(prtcl, 2, pointFlower.area.z);
                    repeatEuler(prtcl, 0);
                    repeatEuler(prtcl, 1);
                    repeatEuler(prtcl, 2);

                    prtcl.alpha = 1.0;//(pointFlower.area.z - prtcl.position[2]) * 0.5;

                    prtcl.zkey = (camera.matrix[2] * prtcl.position[0]
                        + camera.matrix[6] * prtcl.position[1]
                        + camera.matrix[10] * prtcl.position[2]
                        + camera.matrix[14]);
                }

                // sort
                pointFlower.particles.sort(function (p0, p1) { return p0.zkey - p1.zkey; });

                // update data
                var ipos = pointFlower.positionArrayOffset;
                var ieuler = pointFlower.eulerArrayOffset;
                var imisc = pointFlower.miscArrayOffset;
                for (var i = 0; i < pointFlower.numFlowers; i++) {
                    var prtcl = pointFlower.particles[i];
                    pointFlower.dataArray[ipos] = prtcl.position[0];
                    pointFlower.dataArray[ipos + 1] = prtcl.position[1];
                    pointFlower.dataArray[ipos + 2] = prtcl.position[2];
                    ipos += 3;
                    pointFlower.dataArray[ieuler] = prtcl.euler[0];
                    pointFlower.dataArray[ieuler + 1] = prtcl.euler[1];
                    pointFlower.dataArray[ieuler + 2] = prtcl.euler[2];
                    ieuler += 3;
                    pointFlower.dataArray[imisc] = prtcl.size;
                    pointFlower.dataArray[imisc + 1] = prtcl.alpha;
                    imisc += 2;
                }

                //draw
                gl.enable(gl.BLEND);
                //gl.disable(gl.DEPTH_TEST);
                gl.blendFunc(gl.SRC_ALPHA, gl.ONE_MINUS_SRC_ALPHA);

                var prog = pointFlower.program;
                useShader(prog);

                gl.uniformMatrix4fv(prog.uniforms.uProjection, false, projection.matrix);
                gl.uniformMatrix4fv(prog.uniforms.uModelview, false, camera.matrix);
                gl.uniform3fv(prog.uniforms.uResolution, renderSpec.array);
                gl.uniform3fv(prog.uniforms.uDOF, Vector3.arrayForm(camera.dof));
                gl.uniform3fv(prog.uniforms.uFade, Vector3.arrayForm(pointFlower.fader));

                gl.bindBuffer(gl.ARRAY_BUFFER, pointFlower.buffer);
                gl.bufferData(gl.ARRAY_BUFFER, pointFlower.dataArray, gl.DYNAMIC_DRAW);

                gl.vertexAttribPointer(prog.attributes.aPosition, 3, gl.FLOAT, false, 0, pointFlower.positionArrayOffset * Float32Array.BYTES_PER_ELEMENT);
                gl.vertexAttribPointer(prog.attributes.aEuler, 3, gl.FLOAT, false, 0, pointFlower.eulerArrayOffset * Float32Array.BYTES_PER_ELEMENT);
                gl.vertexAttribPointer(prog.attributes.aMisc, 2, gl.FLOAT, false, 0, pointFlower.miscArrayOffset * Float32Array.BYTES_PER_ELEMENT);

                // doubler
                for (var i = 1; i < 2; i++) {
                    var zpos = i * -2.0;
                    pointFlower.offset[0] = pointFlower.area.x * -1.0;
                    pointFlower.offset[1] = pointFlower.area.y * -1.0;
                    pointFlower.offset[2] = pointFlower.area.z * zpos;
                    gl.uniform3fv(prog.uniforms.uOffset, pointFlower.offset);
                    gl.drawArrays(gl.POINT, 0, pointFlower.numFlowers);

                    pointFlower.offset[0] = pointFlower.area.x * -1.0;
                    pointFlower.offset[1] = pointFlower.area.y * 1.0;
                    pointFlower.offset[2] = pointFlower.area.z * zpos;
                    gl.uniform3fv(prog.uniforms.uOffset, pointFlower.offset);
                    gl.drawArrays(gl.POINT, 0, pointFlower.numFlowers);

                    pointFlower.offset[0] = pointFlower.area.x * 1.0;
                    pointFlower.offset[1] = pointFlower.area.y * -1.0;
                    pointFlower.offset[2] = pointFlower.area.z * zpos;
                    gl.uniform3fv(prog.uniforms.uOffset, pointFlower.offset);
                    gl.drawArrays(gl.POINT, 0, pointFlower.numFlowers);

                    pointFlower.offset[0] = pointFlower.area.x * 1.0;
                    pointFlower.offset[1] = pointFlower.area.y * 1.0;
                    pointFlower.offset[2] = pointFlower.area.z * zpos;
                    gl.uniform3fv(prog.uniforms.uOffset, pointFlower.offset);
                    gl.drawArrays(gl.POINT, 0, pointFlower.numFlowers);
                }

                //main
                pointFlower.offset[0] = 0.0;
                pointFlower.offset[1] = 0.0;
                pointFlower.offset[2] = 0.0;
                gl.uniform3fv(prog.uniforms.uOffset, pointFlower.offset);
                gl.drawArrays(gl.POINT, 0, pointFlower.numFlowers);

                gl.bindBuffer(gl.ARRAY_BUFFER, null);
                unuseShader(prog);

                gl.enable(gl.DEPTH_TEST);
                gl.disable(gl.BLEND);
            }

            // effects
            //common util
            function createEffectProgram(vtxsrc, frgsrc, exunifs, exattrs) {
                var ret = {};
                var unifs = ['uResolution', 'uSrc', 'uDelta'];
                if (exunifs) {
                    unifs = unifs.concat(exunifs);
                }
                var attrs = ['aPosition'];
                if (exattrs) {
                    attrs = attrs.concat(exattrs);
                }

                ret.program = createShader(vtxsrc, frgsrc, unifs, attrs);
                useShader(ret.program);

                ret.dataArray = new Float32Array([
                    -1.0, -1.0,
                    1.0, -1.0,
                    -1.0, 1.0,
                    1.0, 1.0
                ]);
                ret.buffer = gl.createBuffer();
                gl.bindBuffer(gl.ARRAY_BUFFER, ret.buffer);
                gl.bufferData(gl.ARRAY_BUFFER, ret.dataArray, gl.STATIC_DRAW);

                gl.bindBuffer(gl.ARRAY_BUFFER, null);
                unuseShader(ret.program);

                return ret;
            }

            // basic usage
            // useEffect(prog, srctex({'texture':texid, 'dtxArray':(f32)[dtx, dty]})); //basic initialize
            // gl.uniform**(...); //additional uniforms
            // drawEffect()
            // unuseEffect(prog)
            // TEXTURE0 makes src
            function useEffect(fxobj, srctex) {
                var prog = fxobj.program;
                useShader(prog);
                gl.uniform3fv(prog.uniforms.uResolution, renderSpec.array);

                if (srctex != null) {
                    gl.uniform2fv(prog.uniforms.uDelta, srctex.dtxArray);
                    gl.uniform1i(prog.uniforms.uSrc, 0);

                    gl.activeTexture(gl.TEXTURE0);
                    gl.bindTexture(gl.TEXTURE_2D, srctex.texture);
                }
            }
            function drawEffect(fxobj) {
                gl.bindBuffer(gl.ARRAY_BUFFER, fxobj.buffer);
                gl.vertexAttribPointer(fxobj.program.attributes.aPosition, 2, gl.FLOAT, false, 0, 0);
                gl.drawArrays(gl.TRIANGLE_STRIP, 0, 4);
            }
            function unuseEffect(fxobj) {
                unuseShader(fxobj.program);
            }

            var effectLib = {};
            function createEffectLib() {

                var vtxsrc, frgsrc;
                //common
                var cmnvtxsrc = document.getElementById("fx_common_vsh").textContent;

                //background
                frgsrc = document.getElementById("bg_fsh").textContent;
                effectLib.sceneBg = createEffectProgram(cmnvtxsrc, frgsrc, ['uTimes'], null);

                // make brightpixels buffer
                frgsrc = document.getElementById("fx_brightbuf_fsh").textContent;
                effectLib.mkBrightBuf = createEffectProgram(cmnvtxsrc, frgsrc, null, null);

                // direction blur
                frgsrc = document.getElementById("fx_dirblur_r4_fsh").textContent;
                effectLib.dirBlur = createEffectProgram(cmnvtxsrc, frgsrc, ['uBlurDir'], null);

                //final composite
                vtxsrc = document.getElementById("pp_final_vsh").textContent;
                frgsrc = document.getElementById("pp_final_fsh").textContent;
                effectLib.finalComp = createEffectProgram(vtxsrc, frgsrc, ['uBloom'], null);
            }

            // background
            function createBackground() {
                //console.log("create background");
            }
            function initBackground() {
                //console.log("init background");
            }
            function renderBackground() {
                gl.disable(gl.DEPTH_TEST);

                useEffect(effectLib.sceneBg, null);
                gl.uniform2f(effectLib.sceneBg.program.uniforms.uTimes, timeInfo.elapsed, timeInfo.delta);
                drawEffect(effectLib.sceneBg);
                unuseEffect(effectLib.sceneBg);

                gl.enable(gl.DEPTH_TEST);
            }

            // post process
            var postProcess = {};
            function createPostProcess() {
                //console.log("create post process");
            }
            function initPostProcess() {
                //console.log("init post process");
            }

            function renderPostProcess() {
                gl.enable(gl.TEXTURE_2D);
                gl.disable(gl.DEPTH_TEST);
                var bindRT = function (rt, isclear) {
                    gl.bindFramebuffer(gl.FRAMEBUFFER, rt.frameBuffer);
                    gl.viewport(0, 0, rt.width, rt.height);
                    if (isclear) {
                        gl.clearColor(0, 0, 0, 0);
                        gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);
                    }
                };

                //make bright buff
                bindRT(renderSpec.wHalfRT0, true);
                useEffect(effectLib.mkBrightBuf, renderSpec.mainRT);
                drawEffect(effectLib.mkBrightBuf);
                unuseEffect(effectLib.mkBrightBuf);

                // make bloom
                for (var i = 0; i < 2; i++) {
                    var p = 1.5 + 1 * i;
                    var s = 2.0 + 1 * i;
                    bindRT(renderSpec.wHalfRT1, true);
                    useEffect(effectLib.dirBlur, renderSpec.wHalfRT0);
                    gl.uniform4f(effectLib.dirBlur.program.uniforms.uBlurDir, p, 0.0, s, 0.0);
                    drawEffect(effectLib.dirBlur);
                    unuseEffect(effectLib.dirBlur);

                    bindRT(renderSpec.wHalfRT0, true);
                    useEffect(effectLib.dirBlur, renderSpec.wHalfRT1);
                    gl.uniform4f(effectLib.dirBlur.program.uniforms.uBlurDir, 0.0, p, 0.0, s);
                    drawEffect(effectLib.dirBlur);
                    unuseEffect(effectLib.dirBlur);
                }

                //display
                gl.bindFramebuffer(gl.FRAMEBUFFER, null);
                gl.viewport(0, 0, renderSpec.width, renderSpec.height);
                gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);

                useEffect(effectLib.finalComp, renderSpec.mainRT);
                gl.uniform1i(effectLib.finalComp.program.uniforms.uBloom, 1);
                gl.activeTexture(gl.TEXTURE1);
                gl.bindTexture(gl.TEXTURE_2D, renderSpec.wHalfRT0.texture);
                drawEffect(effectLib.finalComp);
                unuseEffect(effectLib.finalComp);

                gl.enable(gl.DEPTH_TEST);
            }

            /////
            var SceneEnv = {};
            function createScene() {
                createEffectLib();
                createBackground();
                createPointFlowers();
                createPostProcess();
                sceneStandBy = true;
            }

            function initScene() {
                initBackground();
                initPointFlowers();
                initPostProcess();

                //camera.position.z = 17.320508;
                camera.position.z = pointFlower.area.z + projection.nearfar[0];
                projection.angle = Math.atan2(pointFlower.area.y, camera.position.z + pointFlower.area.z) * 180.0 / Math.PI * 2.0;
                Matrix44.loadProjection(projection.matrix, renderSpec.aspect, projection.angle, projection.nearfar[0], projection.nearfar[1]);
            }

            function renderScene() {
                //draw
                Matrix44.loadLookAt(camera.matrix, camera.position, camera.lookat, camera.up);

                gl.enable(gl.DEPTH_TEST);

                //gl.bindFramebuffer(gl.FRAMEBUFFER, null);
                gl.bindFramebuffer(gl.FRAMEBUFFER, renderSpec.mainRT.frameBuffer);
                gl.viewport(0, 0, renderSpec.mainRT.width, renderSpec.mainRT.height);
                gl.clearColor(0.005, 0, 0.05, 0);
                gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);

                renderBackground();
                renderPointFlowers();
                renderPostProcess();
            }

            /////
            function onResize(e) {
                makeCanvasFullScreen(document.getElementById("sakura"));
                setViewports();
                if (sceneStandBy) {
                    initScene();
                }
            }

            function setViewports() {
                renderSpec.setSize(gl.canvas.width, gl.canvas.height);

                gl.clearColor(0.2, 0.2, 0.5, 1.0);
                gl.viewport(0, 0, renderSpec.width, renderSpec.height);

                var rtfunc = function (rtname, rtw, rth) {
                    var rt = renderSpec[rtname];
                    if (rt) deleteRenderTarget(rt);
                    renderSpec[rtname] = createRenderTarget(rtw, rth);
                };
                rtfunc('mainRT', renderSpec.width, renderSpec.height);
                rtfunc('wFullRT0', renderSpec.width, renderSpec.height);
                rtfunc('wFullRT1', renderSpec.width, renderSpec.height);
                rtfunc('wHalfRT0', renderSpec.halfWidth, renderSpec.halfHeight);
                rtfunc('wHalfRT1', renderSpec.halfWidth, renderSpec.halfHeight);
            }

            function render() {
                renderScene();
            }

            var animating = true;
            function toggleAnimation(elm) {
                animating ^= true;
                if (animating) animate();
                if (elm) {
                    elm.innerHTML = animating ? "Stop" : "Start";
                }
            }

            function stepAnimation() {
                if (!animating) animate();
            }

            function animate() {
                var curdate = new Date();
                timeInfo.elapsed = (curdate - timeInfo.start) / 1000.0;
                timeInfo.delta = (curdate - timeInfo.prev) / 1000.0;
                timeInfo.prev = curdate;

                if (animating) requestAnimationFrame(animate);
                render();
            }

            function makeCanvasFullScreen(canvas) {
                var b = document.body;
                var d = document.documentElement;
                fullw = Math.max(b.clientWidth, b.scrollWidth, d.scrollWidth, d.clientWidth);
                fullh = Math.max(b.clientHeight, b.scrollHeight, d.scrollHeight, d.clientHeight);
                canvas.width = fullw;
                canvas.height = fullh;
            }

            window.addEventListener('load', function (e) {
                var canvas = document.getElementById("sakura");
                try {
                    makeCanvasFullScreen(canvas);
                    gl = canvas.getContext('experimental-webgl');
                } catch (e) {
                    alert("WebGL not supported." + e);
                    console.error(e);
                    return;
                }

                window.addEventListener('resize', onResize);

                setViewports();
                createScene();
                initScene();

                timeInfo.start = new Date();
                timeInfo.prev = timeInfo.start;
                animate();
            });

            //set window.requestAnimationFrame
            (function (w, r) {
                w['r' + r] = w['r' + r] || w['webkitR' + r] || w['mozR' + r] || w['msR' + r] || w['oR' + r] || function (c) { w.setTimeout(c, 1000 / 60); };
            })(window, 'equestAnimationFrame');
        </script>

    </form>
</body>
</html>
