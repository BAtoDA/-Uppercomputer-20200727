<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="手机报警页面1.aspx.cs" Inherits="HTML布局学习.手机访问页面.手机报警页面1" %>

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
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <meta name="viewport" content="width=640, maximum-scale=1.0, user-scalable=no" />
     <!-- 引入 报警图表 -->
    <script src="报警次数与用时图表/报警次数与处理用时Echarts.js"></script>
    <title>报警页面</title>
    <%-- 处理页面大小与比例--%>
    <style>
        /*简单初始化*/
        html {
            font-size: 100px; /*设置html字体大小以便rem*/
        }

        html, body {
            margin: 0;
            padding: 0;
            width: 100%;
            height: 100%;
        }

        ul {
            list-style: none;
            margin: 0;
            padding: 0;
        }

        a {
            text-decoration: none;
        }

        html {
            font-size: 625%; /*100 ÷ 16 × 100% = 625%*/
        }

        @media screen and (min-width:360px) and (max-width:374px) and (orientation:portrait) {
            html {
                font-size: 703%;
            }
        }

        @media screen and (min-width:375px) and (max-width:383px) and (orientation:portrait) {
            html {
                font-size: 732.4%;
            }
        }

        @media screen and (min-width:384px) and (max-width:399px) and (orientation:portrait) {
            html {
                font-size: 750%;
            }
        }

        @media screen and (min-width:400px) and (max-width:413px) and (orientation:portrait) {
            html {
                font-size: 781.25%;
            }
        }

        @media screen and (min-width:414px) and (max-width:431px) and (orientation:portrait) {
            html {
                font-size: 808.6%;
            }
        }

        @media screen and (min-width:432px) and (max-width:479px) and (orientation:portrait) {
            html {
                font-size: 843.75%;
            }
        }
    </style>

</head>
<body id="cheshi" style="width: 100%; height: 101%; background: url('图片/bg.png') no-repeat; background-size: 100% 100%;">
    <form id="form1" runat="server">

        <%-- 标题--%>
        <header style="width: 100%; float: left; height: 10%; font-size: 40%; color: #ffffff; text-align: center; background: url('图片/bg_title.png') no-repeat; background-size: 100% 100%;">
            报警页面
        </header>
        <%-- 布局报警次数--%>
        <div id="cheshi1" style="float: left; width: 100%; height: 30%; position:relative;">
            <%--先显示报警时长--%>
            <%-- 显示今日报警 7天报警 本月报警--%>
            <div style="width: 31%; height: 1.5rem; margin-left: 1%; margin-top: 1%; background: url('图片/leftbg01.png') no-repeat; background-size: 100% 100%; float: inherit; text-align: center;">
                <header style="width: 100%; height: 10%; text-align: center; font-size: 40%; color: #ffffff; position: relative; top: 2%;">
                    今日报警
                </header>
                <span id="TodayAlarmData" style="width: 100%; height: 50%; font-size: 40%; color: #4862ed;">999</span>
            </div>

            <div style="width: 33%; height: 1.5rem; margin-left: 2%; margin-top: 1%; background: url('图片/leftbg01.png') no-repeat; background-size: 100% 100%; float: inherit; text-align: center;">
                <header style="width: 100%; height: 10%; text-align: center; font-size: 40%; color: #ffffff; position: relative; top: 2%;">
                    7天报警
                </header>
                <span id="DaysAlarmData" style="width: 100%; height: 50%; font-size: 40%; color: #4862ed;">999</span>
            </div>

            <div style="width:30%; height: 1.5rem; margin-left: 2%; margin-top: 1%; background: url('图片/leftbg01.png') no-repeat; background-size: 100% 100%; float: inherit; text-align: center;">
                <header style="width: 100%; height: 10%; text-align: center; font-size: 40%; color: #ffffff; position: relative; top: 2%;">
                    本月报警
                </header>
                <span id="MonthAlarmData" style="width: 100%; height: 50%; font-size: 40%; color: #4862ed;">999</span>
            </div>

        </div>
          <%-- 布局报警处理图表--%>
          <div style="float: left; text-align:left; position:relative;  width: 100%; height: 100%; ">
          <div id="Alarmcharts" style="width: 100%; height: 250%; float:left; ">
          </div>
          </div>

        <%-- 布局报警处理用时--%>
          <div id="cheshi2" style="float: left; width: 100%; height: 30%; position:relative;">
            <%-- 显示今日处理用时 7天处理用时 本月处理用时--%>
            <div style="width: 31%; height: 1.5rem; margin-left: 1%; margin-top: 1%; background: url('图片/leftbg01.png') no-repeat; background-size: 100% 100%; float: inherit; text-align: center;">
                <header style="width: 100%; height: 10%; text-align: center; font-size: 40%; color: #ffffff; position: relative; top: 2%;">
                    今日用时
                </header>
                <span id="TodayDisposeData" style="width: 100%; height: 50%; font-size: 40%; color: #4862ed;">00:99:99</span>
            </div>

            <div style="width: 33%; height: 1.5rem; margin-left: 2%; margin-top: 1%; background: url('图片/leftbg01.png') no-repeat; background-size: 100% 100%; float: inherit; text-align: center;">
                <header style="width: 100%; height: 10%; text-align: center; font-size: 40%; color: #ffffff; position: relative; top: 2%;">
                    7天用时
                </header>
                <span id="DaysDisposeData" style="width: 100%; height: 50%; font-size: 40%; color: #4862ed;">00:99:99</span>
            </div>

            <div style="width:30%; height: 1.5rem; margin-left: 2%; margin-top: 1%; background: url('图片/leftbg01.png') no-repeat; background-size: 100% 100%; float: inherit; text-align: center;">
                <header style="width: 100%; height: 10%; text-align: center; font-size: 40%; color: #ffffff; position: relative; top: 2%;">
                    本月用时
                </header>
                <span id="MonthDisposeData" style="width: 100%; height: 50%; font-size: 40%; color: #4862ed;">00:99:99</span>
            </div>
          </div>

           <%-- 布局报警处理图表--%>
          <div id="tuxin" style="float: left; text-align:left; position:relative;  width: 100%; height: 100%; ">
          <div id="Disposeecharts" style="width: 100%; height: 250%; float:left; ">
          </div>
          </div>

        <%--  手机访问自适应--%>
        <script type="text/javascript">
            //获取手机宽度
            //判断该手机是否苹果手机
            var userAgentInfo = navigator.userAgent;
            console.log(navigator.userAgent);
            var Agents = new Array("Android", "iPhone", "SymbianOS", "Windows Phone", "iPad", "iPod");
            var flag = true;
            for (var v = 0; v < Agents.length; v++) {
                if (userAgentInfo.indexOf(Agents[v]) > 0) {
                    if (Agents[v] == "iPhone" || Agents[v] == "iPad") {
                        flag = false;
                    }
                    break;
                }
            }
            ////正常手机宽度是 360宽==由于布局是100px =做单位 那个偏移10% 就是 0.36个rem
            if (flag) {
                //电脑与安卓手机布局
                document.getElementById('cheshi1').style.top = '-4%';
                document.getElementById('cheshi2').style.top = '-50%';
                document.getElementById('Disposeecharts').style.height = '350%';
                document.getElementById('Alarmcharts').style.height = '350%';
            }
            else {
                //苹果手机布局
                document.getElementById('cheshi1').style.top = '-4%';
                document.getElementById('cheshi2').style.top = '-50%';
                document.getElementById('Disposeecharts').style.height = '300%';
                document.getElementById('Alarmcharts').style.height = '300%';
            }
            if (/Android (\d+\.\d+)/.test(navigator.userAgent)) {
                var version = parseFloat(RegExp.$1);
                if (version > 2.3) {
                    var phoneScale = parseInt(window.screen.width) / 640;
                    document.write('<meta name="viewport" content="width=640, minimum-scale = ' + phoneScale + ', maximum-scale = ' + phoneScale + ', target-densitydpi=device-dpi">');
                } else {
                    document.write('<meta name="viewport" content="width=640, target-densitydpi=device-dpi">');
                }
            } else {
                document.write('<meta name="viewport" content="width=640, user-scalable=no, target-densitydpi=device-dpi">');
            }

            //修改目标产量位置

        </script>
    </form>
</body>
</html>
