<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="HTML布局学习.报警页面web.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- 引入jquery前后端互交 -->
    <script src="Echarts/jquery-3.5.1.min.js"></script>
    <!-- 引入 echarts.js -->
    <script src="Echarts/echarts.js"></script>
    <script src="Echarts/customed.js"></script>
    <script src="JavaScript.js"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <%--引入布局样式--%>
    <link rel="stylesheet" href="报警界面布局样式.css" />
    <!-- 引入 雪花飘落特效 -->
    <link rel="stylesheet" href="樱花特效css/style.css" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no" />
    <link href="Security_operation.css" rel="stylesheet" type="text/css" />
    <title>报警界面监控</title>
    <%-- 引入加载处理用时图表--%>
    <script src="报警显示图标js/Alarmecharts.js"></script>
    <%-- 引入加载报警次数和处理总时图表--%>
    <script src="报警异常次数和总时长/AlarmTimeJs.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes" />
</head>
<body class="body_main">
    <form id="form1" runat="server">
        <%-- 雪花飘落特效--%>
        <div class="snow" count="4000"></div>
        <script src='樱花特效js/Stats.min.js'></script>
        <script src="樱花特效js/index.js"></script>
        <%-- 布局标题--%>
        <div class="t_h_bg">
            <header class="t_h_bg_frin">
                报警界面监控
            </header>
        </div>
        <%--布局一个用于展示滚动报警的数据的div--%>
        <div class="t_box">
            <header style="font-size: 30%; text-align: center; float: initial; position: relative; top: 0%; color: #ffffff;">设备异常监控</header>
            <div style="width: 100%; height: 50%; position: relative; top: 0%;">
            <div class="dataAllBorder01 cage_cl" style="margin-top: 1.5% !important; height: 35%; position: relative;">
                <div class="dataAllBorder02" style="padding: 1.2%; overflow: hidden">

                    <div class="message_scroll_box">
                        <div class="message_scroll">
                            <div class="scroll_top">
                                <span class="scroll_title">数据流量警示</span>
                                <span class="scroll_level scroll_level01">一级</span>
                                <a class="localize"></a>
                                <span class="scroll_timer">17-09-13/9:52</span>
                            </div>
                            <header class="mess_cage">dddd</header>
                        </div>
                        <div class="message_scroll">
                            <div class="scroll_top">
                                <span class="scroll_title">数据流量警示</span>
                                <span class="scroll_level scroll_level03">三级</span>
                                <a class="localize"></a>
                                <span class="scroll_timer">17-09-13/9:52</span>
                            </div>
                              <header class="mess_cage">dddd</header>
   
                        </div>
                        <div class="message_scroll">
                            <div class="scroll_top">
                                <span class="scroll_title">数据流量警示</span>
                                <span class="scroll_level scroll_level02">二级</span>
                                <a class="localize"></a>
                                <span class="scroll_timer">17-09-13/9:52</span>
                            </div>
                            <header class="mess_cage">dddd</header>
         
                        </div>
                    </div>

                </div>
                <%--<div class="scroll_tool_outbox">
                    <div class="scroll_tool_box">
                        <a class="scroll_tool" href="#">查看历史推送</a>
                    </div>
                </div>--%>
                </div>
                </div>
                   <div style="width: 100%; height: 50%; position: relative; top: -5%;">
                        <header style="font-size: 30%; text-align: center; float: initial; position: relative; top: -2%; color: #ffffff;">设备历史异常</header>
                       <div class="dataAllBorder02" style="padding: 1.2%; overflow: hidden">

                    <div class="message_scroll_box1">
                        <div class="message_scroll1">
                            <div class="scroll_top1">
                                <span class="scroll_title">数据流量警示</span>
                                <span class="scroll_level scroll_level01">一级</span>
                                <a class="localize"></a>
                                <span class="scroll_timer">17-09-13/9:52</span>
                            </div>
                              <header class="mess_cage">dddd</header>
                        </div>
                        <div class="message_scroll1">
                            <div class="scroll_top1">
                                <span class="scroll_title">数据流量警示</span>
                                <span class="scroll_level scroll_level03">三级</span>
                                <a class="localize"></a>
                                <span class="scroll_timer">17-09-13/9:52</span>
                            </div>
                               <header class="mess_cage">dddd</header>
                        </div>
                        <div class="message_scroll1">
                            <div class="scroll_top1">
                                <span class="scroll_title">数据流量警示</span>
                                <span class="scroll_level scroll_level02">二级</span>
                                <a class="localize"></a>
                                <span class="scroll_timer">17-09-13/9:52</span>
                            </div>
                          <header class="mess_cage">dddd</header>
                        </div>
                    </div>

                </div>
                        </div>
            </div>

            <script type="text/javascript">
                function TimeControl() {
                    $(".message_scroll_box").animate({ marginTop: 76 }, 800,
                        function () {
                            $(".message_scroll_box .message_scroll:first").before($(".message_scroll_box .message_scroll:last"));    //在第一个新闻后面插入最后一个新闻
                            $(".message_scroll_box").css({ marginTop: 0 });    //把顶部的边界清零

                        });
                }
                var T = setInterval(TimeControl, 3000);    //开始定时
                $(".message_scroll_box").mouseenter(function () {
                    clearInterval(T);    //停止定时
                })
                    .mouseleave(function () {
                        T = setInterval(TimeControl, 3800);    //再次定时
                    })



                function TimeControl1() {
                    $(".message_scroll_box1").animate({ marginTop: 76 }, 1200,
                        //function () {
                            $(".message_scroll_box1 .message_scroll1:first").before($(".message_scroll_box1 .message_scroll1:last"));    //在第一个新闻后面插入最后一个新闻
                            $(".message_scroll_box1").css({ marginTop: 0 });    //把顶部的边界清零

                        });
                }
                var T1 = setInterval(TimeControl1, 2000);    //开始定时
                $(".message_scroll_box1").mouseenter(function () {
                    clearInterval(T1);    //停止定时
                })
                    .mouseleave(function () {
                        T1 = setInterval(TimeControl1, 2000);    //再次定时
                    })
            </script>
        </div>
        <%--布局一个用于展示设备节拍速率的数据的div--%>
        <div class="t_box2">
            <header style="font-size: 30%; text-align: center; float: initial; color: #ffffff;">设备监控</header>
            <%--  显示总异常和总时间表--%>
            <div id="AlarmTime" style="width: 100%; height: 53%;"></div>
            <%--  显示设备节拍--%>
            <header style="font-size: 30%; text-align: center; float: initial; position: relative; top: -4%; color: #ffffff;">设备节拍速率</header>
            <div id="meter" style="width: 100%; height: 70%; position: relative; top: -10%;"></div>
            <script type="text/javascript"> 
                AlarmEchartsLoad();
                //用于显示设备节拍
                MeterLoad();
            </script>
        </div>
        <%--布局一个用于展示当天报警数据的2个小方块--%>
        <div class="t_boxbig">
            <%--今日主报警显示--%>
            <div class="pane1">
                <%--      显示该方格的标题--%>
                <header id="TodayAlarm" style="font-size: 27%; width: 100%; text-align: center; color: #ffffff; width: 100%; height: 10%; margin-top: 1%; float: initial; position: relative; margin-left: 0%;">
                    今日报警
                </header>
                <%-- 显示图标--%>
                <header id="TodayAlarmData" style="font-size: 50%; width: 100%; text-align: center; color: #4862ed; float: inherit; position: relative; margin-top: 10%; left: 00%;">
                    0
                </header>
            </div>
            <%--   7天主报警显示--%>
            <div class="pane2">
                <header id="DaysAlarm" style="font-size: 27%; width: 100%; text-align: center; color: #ffffff; width: 100%; height: 10%; margin-top: 1%; float: initial; position: relative; margin-left: 0%;">
                    7天报警
                </header>
                <%-- 显示图标--%>
                <header id="DaysAlarmData" style="font-size: 50%; width: 100%; text-align: center; color: #4862ed; float: inherit; position: relative; margin-top: 10%; left: 00%;">
                    0
                </header>
            </div>
            <%-- 当月主报警显示--%>
            <div class="pane3">
                <header id="MonthAlarm" style="font-size: 27%; color: #ffffff; width: 100%; height: 10%; margin-top: 1%; float: initial; position: relative; margin-left: 27%;">
                    本月报警
                </header>
                <%-- 显示图标--%>
                <header id="MonthAlarmData" style="font-size: 50%; width: 100%; text-align: center; color: #4862ed; float: inherit; position: relative; margin-top: 10%; left: 0%;">
                    0
                </header>
            </div>
            <script type="text/javascript">
                //定时刷新自适应代码
                setInterval(function () {

                }, 2000);
                AlarmchartsLoad();//加载报警图表
            </script>
            <%--    添加Echarts图标--%>
            <div id="Alarmcharts" style="width: 100%; height: 70%; position: relative; top: 35%">
            </div>
        </div>
        <div class="t_boxbig">
            <div class="pane1">
                <%--      显示该方格的标题--%>
                <header id="TodayDispose" style="font-size: 27%; width: 100%; text-align: center; color: #ffffff; width: 100%; height: 10%; margin-top: 1%; float: initial; position: relative; margin-left: 0%;">
                    今日处理用时
                </header>
                <%-- 显示图标--%>
                <header id="TodayDisposeData" style="font-size: 45%; width: 100%; text-align: center; color: #4862ed; float: inherit; position: relative; margin-top: 10%; left: 0%;">
                    0
                </header>
            </div>
            <%--   7天主报警显示--%>
            <div class="pane2">
                <header id="DaysDispose" style="font-size: 27%; width: 100%; text-align: center; color: #ffffff; width: 100%; height: 10%; margin-top: 1%; float: initial; position: relative; margin-left: 0%;">
                    7天处理用时
                </header>
                <%-- 显示图标--%>
                <header id="DaysDisposeData" style="font-size: 45%; width: 100%; text-align: center; color: #4862ed; float: inherit; position: relative; margin-top: 10%; left: 0%;">
                    0
                </header>
            </div>
            <%-- 当月主报警显示--%>
            <div class="pane3">
                <header id="MonthDispose" style="font-size: 27%; width: 100%; text-align: center; color: #ffffff; width: 100%; height: 10%; margin-top: 1%; float: initial; position: relative; margin-left: 0%;">
                    本月处理用时
                </header>
                <%-- 显示图标--%>
                <header id="MonthDisposeData" style="font-size: 45%; width: 100%; text-align: center; color: #4862ed; float: inherit; position: relative; margin-top: 10%; left: 0%;">
                    0
                </header>
            </div>
            <script type="text/javascript">
                //定时刷新自适应代码
                setInterval(function () {

                }, 2000);
                //加载图表
                DisposeechartsLoad();
            </script>
            <%--    添加Echarts图标--%>
            <div id="Disposeecharts" style="width: 100%; height: 70%; position: relative; top: 35%">
            </div>
        </div>
    </form>
</body>
</html>
