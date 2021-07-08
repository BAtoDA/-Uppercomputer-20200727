<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="手机产量页面.aspx.cs" Inherits="HTML布局学习.WebForm22" %>

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
    <script src="设备速率图标/设备速率Echarts.js"></script>
    <script src="7天产量图表/7天产量Echarts.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <meta name="viewport" content="width=640, maximum-scale=1.0, user-scalable=no" />
    <title>产量页面</title>
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
<body id="cheshi" style="width: 100%; height: 100%; background: url('图片/bg.png') no-repeat; background-size: 100% 100%;">
    <form id="form1" runat="server">

        <%-- 标题--%>
        <header style="width: 100%; float: left; height: 10%; font-size: 25%; color: #ffffff; text-align: center; background: url('图片/bg_title.png') no-repeat; background-size: 100% 100%;">
            产量显示
        </header>
        <%-- 下拉布局--%>
        <div id="cheshi1" style="float: left; width: 100%; height: 200%; background-size: 100% 100%; text-align: center; float: left;">
            <%--   先显示当前产量与目标产量--%>
            <nav>
                <ul>
                    <li>
                        <div style="width: 50px; height: 40px; float: left; background: url('图片/pic_ico_01.png') no-repeat; background-size: 100% 100%;"></div>
                        <header style="text-align: left; color: #ffffff; font-size: 20%; width: 100%; height: 50%;">
                            目标产量
                        </header>
                        <header id="target" style="margin-top: 1%; position: relative; left: -0%; text-align: center; color: #1c7df5; font-size: 60%; width: 100%; height: 50%;">
                            9999
                        </header>
                    </li>
                    <li>
                        <div style="width: 50px; height: 40px; float: left; background: url('图片/pic_ico_01.png') no-repeat; background-size: 100% 100%;"></div>
                        <header style="text-align: left; color: #ffffff; font-size: 20%; width: 100%; height: 50%;">
                            当前产量
                        </header>
                        <header id="present" style="margin-top: 1%; position: relative; text-align: center; color: #1c7df5; font-size: 60%; width: 100%; height: 50%;">
                            7777
                        </header>
                    </li>
                    <li>
                        <div style="width: 50px; height: 40px; float: left; background: url('图片/pic_ico_01.png') no-repeat; background-size: 100% 100%;"></div>
                        <header style="text-align: left; color: #ffffff; font-size: 20%; width: 70%; height: 50%;">
                            当月目标产量
                        </header>
                        <header id="monthtarget" style="margin-top: 1%; position: relative; text-align: center; color: #1c7df5; font-size: 60%; width: 100%; height: 50%;">
                            999999
                        </header>

                    </li>
                    <li>
                        <div style="width: 50px; height: 40px; float: left; background: url('图片/pic_ico_01.png') no-repeat; background-size: 100% 100%;"></div>
                        <header style="text-align: left; color: #ffffff; font-size: 20%; width: 70%; height: 50%;">
                            当月产量
                        </header>
                        <header id="month" style="margin-top: 1%; position: relative; text-align: center; color: #1c7df5; font-size: 60%; width: 100%; height: 50%;">
                            6666666
                        </header>
                    </li>
                    <li>
                        <div style="width: 50px; height: 40px; float: left; background: url('图片/pic_ico_01.png') no-repeat; background-size: 100% 100%;"></div>
                        <header style="text-align: left; color: #ffffff; font-size: 20%; width: 70%; height: 50%;">
                            全年产量
                        </header>
                        <header id="yearly" style="margin-top: 1%; position: relative; text-align: center; color: #1c7df5; font-size: 60%; width: 100%; height: 50%;">
                            666666666
                        </header>
                    </li>
                </ul>
            </nav>
        </div>
        <div style="width: 100%; height: 100%; background: url('图片/bg.png') no-repeat; background-size: 100% 100%;">
            <%--显示7天产量--%>
            <div style="width: 100%; height: 100%;">
                <div style="width: 50px; height: 40px; float: left; background: url('图片/pic_ico_01.png') no-repeat; background-size: 100% 100%;"></div>
                <header style="text-align: left; color: #ffffff; font-size: 20%; width: 100%; height: 50%;">
                    7天产量监控
                </header>
                <header style="margin-top: 1%; position: relative; left: -0%; text-align: center; float: initial; color: #1c7df5; font-size: 70%; width: 100%; height: 100%;">
                    <div id="mainweek" style="margin-top: 1%; width: 90%; height: 400%; position: relative; float: initial; position: relative; left: 5%;">
                    </div>
                </header>

            </div>
            <%--    显示速率图标--%>
            <div style="width: 100%; height: 100%;">
                <div style="width: 50px; height: 40px; float: left; background: url('图片/pic_ico_01.png') no-repeat; background-size: 100% 100%;"></div>
                <header style="text-align: left; color: #ffffff; font-size: 20%; width: 100%; height: 50%;">
                    当前设备速率
                </header>
                <header style="margin-top: 1%; position: relative; left: -0%; text-align: center; float: initial; color: #1c7df5; font-size: 70%; width: 100%; height: 100%;">
                    <div id="speede" style="margin-top: 1%; width: 90%; height: 400%; position: relative; float: initial; position: relative; left: 5%;">
                    </div>
                </header>

            </div>
        </div>
        <div>
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
            //正常手机宽度是 360宽==由于布局是100px =做单位 那个偏移10% 就是 0.36个rem
            if (document.body.clientWidth >= 300 && document.body.clientWidth < 1700 && flag) {
                document.getElementById('target').style.left = '-4%';
                document.getElementById('present').style.left = '-4%';
                document.getElementById('monthtarget').style.left = '-4%';
                document.getElementById('month').style.left = '-4%';
                document.getElementById('yearly').style.left = '-4%';
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
