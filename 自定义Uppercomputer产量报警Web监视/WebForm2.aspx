<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="HTML布局学习.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="参数页面布局样式.css" />
    <link rel="stylesheet" href="参数设置界面css/参数设置button区域布局.css" />
    <link rel="stylesheet" href="参数设置界面css/主显示区样式.css" />
    <script src="报警视图jsPOST/AlarmSQL_View.js"></script>
    <script src="报警视图jsPOST/Alarmhistory_View.js"></script>
    <title>页面参数设置</title>
    <!-- 引入jquery前后端互交 -->
    <script src="Echarts/jquery-3.5.1.min.js"></script>
    <!-- 引入 echarts.js -->
    <script src="Echarts/Echarts/echarts.js"></script>
    <script src="Echarts/customed.js"></script>
    <script src="JavaScript.js"></script>
    <script src="控件特效样式/Navigation.js"></script>
</head>
<body class="t_container">
    <form id="form1" runat="server">
        <header class=" t_h_bg">
            <span class="t_h_bg_frin">数据展示参数设置</span>
        </header>
        <div class="t_box_little">
            <div class="t_box">
                <%--导航栏按钮--%>
                <asp:Button ID="Button2" runat="server" Text="参数设置" BorderStyle="None" CssClass="Crystalbutton" ToolTip="参数设置" OnClick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" Text="报警查询" BorderStyle="None" CssClass="Crystalbutton" ToolTip="报警查询" OnClick="Button3_Click" />
                <asp:Button ID="Button4" runat="server" Text="报警历史" BorderStyle="None" CssClass="Crystalbutton" ToolTip="报警历史" OnClick="Button4_Click" />
                <asp:Button ID="Button5" runat="server" Text="产量查询" BorderStyle="None" CssClass="Crystalbutton" ToolTip="产量查询" />
                <asp:Button ID="Button6" runat="server" Text="产量预设" BorderStyle="None" CssClass="Crystalbutton" ToolTip="产量预设" />
                <asp:Button ID="Button7" runat="server" Text="关于" BorderStyle="None" CssClass="Crystalbutton" ToolTip="关于" OnClick="Button7_Click" />
        <script type='text/javascript'>
            //处理导航栏按钮特效
            Navigationcss();
        </script>
            </div>
        </div>
        <div class="t_box_big">
            <div class="t_boxbig">
                <%--该控件用于动态生成按钮类型的内容与布局--%>
                <%--     <header class="t_h_bgText" >
            <span >软件说明</span>
             </header>
                <div runat="server" id="myDiv1" class="regard" >本软件适用于工业自动化作为上位机对下位设备进行监控与控制使用简易通过拖拽控件修改参数实现对设备的监控。
                    后续会持续添加控件实现多元化,更贴合，更方便，更快捷的设计理念目前支持简单常用的控件-支持三菱PLC--MC协议(3E帧)--西门子S7协议MODBUS TCP协议--或者通过宏指令简易的编写代码实现串口--以太网特定协议的通讯。
  关于对其他设备的数据库对接目前可以通过宏指令实现简易的去处理后续会做一个特定的控件去对接实现。</div>--%>
   <%--             <div style='width: 4rem; height: 8rem; display: inline-block; float: left; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; left: 80px;'>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter1' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter2' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                </div>
                <div style='width: 4rem; height: 8rem; display: inline-block; float: inherit; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; right: -200px;'>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter3' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter4' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                </div>
                <div style='width: 4rem; height: 8rem; display: inline-block; float: right; position: relative; margin-left: 0.1rem; margin-top: 0.0rem; color: azure; top: 0px; right: 0px;'>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter5' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                    <label style='float: left; font-size: 25%; text-align: left; margin-left: 0.1rem; margin-top: 0.3rem;'>
                        参数设置1
                        <input id='parameter6' type='text' value='请输入内容' style='margin-left: 0.0rem; margin-top: 0.3rem; position: relative; top: -2px; font-size: 40%; height: 30px; border-radius: 0.1rem;'></input></label>
                </div>
                <script type='text/javascript'>
                    var tbody1 = document.getElementById('parameter1');
                    tbody1.onmouseenter = function () {
                        tbody1.style.backgroundColor = '#FFFFB0';
                    }
                    tbody1.onmouseleave = function () {
                        tbody1.style.backgroundColor = '#FFF';
                    }
                    var tbody2 = document.getElementById('parameter2');
                    tbody2.onmouseenter = function () {
                        tbody2.style.backgroundColor = '#FFFFB0';
                    }
                    tbody2.onmouseleave = function () {
                        tbody2.style.backgroundColor = '#FFF';
                    }
                    var tbody3 = document.getElementById('parameter3');
                    tbody3.onmouseenter = function () {
                        tbody3.style.backgroundColor = '#FFFFB0';
                    }
                    tbody3.onmouseleave = function () {
                        tbody3.style.backgroundColor = '#FFF';
                    }
                    var tbody4 = document.getElementById('parameter4');
                    tbody4.onmouseenter = function () {
                        tbody4.style.backgroundColor = '#FFFFB0';
                    }
                    tbody4.onmouseleave = function () {
                        tbody4.style.backgroundColor = '#FFF';
                    }
                    var tbody5 = document.getElementById('parameter5');
                    tbody5.onmouseenter = function () {
                        tbody5.style.backgroundColor = '#FFFFB0';
                    }
                    tbody5.onmouseleave = function () {
                        tbody5.style.backgroundColor = '#FFF';
                    }
                    var tbody6 = document.getElementById('parameter6');
                    tbody6.onmouseenter = function () {
                        tbody6.style.backgroundColor = '#FFFFB0';
                    }
                    tbody6.onmouseleave = function () {
                        tbody6.style.backgroundColor = '#FFF';
                    }
                </script>--%>
            <%--                 <div style='color: #fff; font-size: 50%; border-top: none; border-bottom: none; border-left: none; border-right: none; width: 15rem; height: 7.5rem; color: aliceblue; margin-left: 0.1rem; margin-top: 0.1rem;'>
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
                    <button id='previous' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.5rem; width:0.8rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:-2rem;' onclick='previous()'>上一页</button>
                    <button id='home' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.5rem; width:0.8rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:0rem;' onclick='Home()'>首页</button>
                    <button id='page' style='color:#fff; float: initial; font-size: 50%; text-align:center; margin-left: 0.0rem; margin-top: 0.0rem; height:0.5rem; width:0.8rem; background:
    url(../img/bg_box2.png); no-repeat; background-size: 100% 100%; border:none;  position: relative; left:2rem;' onclick='next()'>下一页</button>
                  </header>
                </div>
                <script type='text/javascript'>
                    //下方导航栏按钮特效
                    Tablecss();
                    //鼠标移到子项 子项变色s
                    Itembackground();
                    //上一页触发方法
                    function previous() {
                        alert("正在请求后端获取上一页数据");
                    }
                    function Home() {
                        alert("正在请求后端获取首页数据");
                    }
                    function next() {
                        alert("正在请求后端获取下一页数据");
                    }
                </script>--%>

                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>
        </div>

    </form>
</body>
</html>
