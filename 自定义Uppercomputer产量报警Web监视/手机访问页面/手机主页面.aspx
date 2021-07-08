<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="手机主页面.aspx.cs" Inherits="HTML布局学习.手机访问页面.手机主页面" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
    <title>主页面</title>
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
        <header style="width: 100%; float: left; height: 5%; font-size: 40%; color: #ffffff; text-align: center; ">
            主页面
        </header>
        <%-- 左边布局--%>
        <div style="width: 45%; height: 90%; float: left; text-align: left;">
            <header style='width: 100%; height: 10%; color: #ffffff; font-size: 40%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                <span>产量界面</span>
            </header>
            <div style='width: 100%; height: 50%; display: inline-block; float: left; position: relative; margin-left: 0.1rem; margin-top: 0.1rem; color: azure; top: 0rem; left: 0rem; border: none;'>
                <video id='video_id1' style='position: relative; top: -0.0rem;' width='100%;' height='70%;' controls='controls'>
                    你的浏览器不能支持HTML5视频
                      <source src='/网页播放的视频/source1.mp4' type='video/mp4' />
                </video>
                <p id="outputText" style='font-size: 25%; position: relative; margin-top: 0%;'>
                    本界面主要用于：预设当班目标产量,当月目标产量,全年目标产量, 判断当班当天是否完成任务 配合MES系统制定目标有计划的进行生产‘排产’ 
                                内置小时产量动态图表与本周产量动态显示，当月生产数量查询，支持初步查看设备状态与是否进入报警状态和报警发生</p>
                 <div style='color: #fff; font-size: 100%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 100%; height: 15%; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; float: inline-end; position: relative; top: -0.16rem;'>
                    <header style='color: #fff; font-size: 30%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                        <button id='Alarm'  type="button"; style='color: #fff; float: initial; font-size: 70%; font-weight: 900; text-align: center; margin-right: 0%; margin-top: 0.2rem; height: 0.8rem; width: 2.5rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: 0rem;'
                            onclick='GOAlarm()'>
                            进入产量页面</button>
                    </header>
                     <script type="text/javascript">
                         function GOAlarm() {
                             //跳转页面
                             location.assign('手机产量页面.aspx');
                         }                        
                     </script>
                </div>
            </div>
        </div>
        <%-- 右边布局--%>
        <div style="width: 45%; height: 70%; float: right; text-align: left; position: relative; right: 3%;">
            <header style='color: #ffffff; font-size: 40%; text-align: center; position: relative; margin-top: 0.1rem; top: 0px; text-align: center; font-weight: bold;'>
                <span>异常界面</span>
            </header>
            <div style='width: 100%; height: 70%; display: inline-block; float: left; position: relative; margin-left: 0.1rem; margin-top: 0.1rem; color: azure; top: -0px; left: 0rem;  border: none;'>
                <video id='video_id2' style='position: relative; top: -0.0rem;' width='100%;' height='100%;' src='../网页播放的视频/source2.mp4' controls='controls'>
                    你的浏览器不能支持HTML5视频
                                 <source src='../网页播放的视频/source2.mp4' type='video/mp4'/>
                </video>
                <p id="alarmText" style='font-size: 25%; position: relative; margin-top: -1%;''>
                    本界面主要用于：当天报警次数，7天报警次数，当月报警次数，支持用户对报警处理用时进行监控内置当天报警处理用时，7天报警处理用时
                                ，当月报警处理用时，并且把出现次数最多的异常内容显示给用户这样可使用户快速找到设备问题所在提高生产效率。
                </p>
                <div style='color: #fff; font-size: 100%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 100%; height: 15%; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem; float: inline-end; position: relative; top: -0.13rem;'>
                    <header style='color: #fff; font-size: 30%; text-align: center; position: relative; margin-top: 0.1rem; top: -5px; text-align: center; font-weight: bold;'>
                        <button id='Alarm1' type="button"; style='color: #fff; float: initial; font-size: 70%; font-weight: 900; text-align: center; margin-right: 0%; margin-top: 0.2rem; height: 0.8rem; width: 2.5rem; background: url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border: none; position: relative; left: 0rem;'
                            onclick='GOAlarm1()'>
                            进入异常监控页面</button>
                    </header>
                      <script type="text/javascript">
                          function GOAlarm1() {
                              //跳转页面
                              location.assign('手机报警页面1.aspx');
                          }
                      </script>
                </div>
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
            //正常手机宽度是 360宽==由于布局是100px =做单位 那个偏移10% 就是 0.36个rem
            if (flag) {
                //标识 该设备是电脑 或者 安卓手机
                var outputTex = document.getElementById('outputText');
                outputTex.style.fontSize = '35%';
                var outputTex = document.getElementById('alarmText');
                outputTex.style.fontSize = '35%';
            }
            else {
                //标识 该设备是苹果手机
                var outputTex = document.getElementById('outputText');
                outputTex.style.fontSize = '25%';
                var outputTex = document.getElementById('alarmText');
                outputTex.style.fontSize = '25%';
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
