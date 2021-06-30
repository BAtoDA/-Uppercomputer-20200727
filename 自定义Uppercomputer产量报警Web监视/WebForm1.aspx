<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HTML布局学习.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="布局样式.css" />
    <!-- 引入数值显示 -->
    <link rel="stylesheet" href="数值显示jsPOST/numeriheadline.css" />
    <script src="数值显示jsPOST/numerical.js"></script>
    <!-- 引入jquery前后端互交 -->
    <script src="Echarts/jquery-3.5.1.min.js"></script>
    <!-- 引入 echarts.js -->
    <script src="Echarts/Echarts/echarts.js"></script>
    <script src="Echarts/customed.js"></script>
    <script src="JavaScript.js"></script>
    <!-- 引入 周折线图 -->
    <script src="折线图显示jsPSOT/周折线图.js"></script>
    <script src="折线图显示jsPSOT/小时折线图.js"></script>
    <script src="折线图显示jsPSOT/月折线图.js"></script>
    <link rel="stylesheet" href="折线图显示jsPSOT/weekSheet.css" />
    <!-- 引入 小时与设备异常次数指针表盘 -->
    <script src="表盘显示jsPOST/小时指针显示.js"></script>
    <script src="表盘显示jsPOST/停机指针显示.js"></script>
    <!-- 引入 报警显示条 -->
    <link rel="stylesheet" href="报警视图jsPOST/AbnormalSheet.css" />
    <script src="报警视图jsPOST/Alarm_View.js"></script>
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no">
    <title>XXX线数据展示</title>
</head>
<body class="t_container">
    <form id="form1" runat="server">
        <header class=" t_h_bg">
            <span class="t_h_bg_frin">XXX线数据展示</span>
        </header>


        <div class="t_box_little">

            <div class="t_box">
                <div class="headline">当班目标</div>
                <div id="Squad_target" class="headline_content">55550000</div>

                <div class="headline">当班产量</div>
                <div id="Squad_output" class="headline_content">44444400</div>
            </div>

            <div class="t_box">
                <div class="weekheadline">周生产数据</div>
                <%-- 使用ECharts生成周折线图--%>
                <div id="mainweek" class="echart" style="width: 100%; height: 3rem;"></div>
            </div>

            <div class="t_box">
                <div class="headline">当月目标</div>
                <div id="headline_target" class="headline_content">66660000</div>

                <div class="headline">当月产量</div>
                <div id="headline_output" class="headline_content">666664400</div>
            </div>

            <div class="t_box">
                <div class="weekheadline">每时生产数据</div>
                <%-- 使用ECharts生成周折线图--%>
                <div id="mainhour" class="echart" style="width: 100%; height: 3rem;"></div>
            </div>

            <div class="t_box">
                <div class="headline1">全年产量</div>
                <div id="headline1_output" class="headline_content1">66666660000</div>
            </div>

            <div class="t_box">
                <div class="weekheadline">每月生产数据</div>
                <%-- 使用ECharts生成周折线图--%>
                <div id="mainmonth" class="echart" style="width: 100%; height: 2.8rem;"></div>
            </div>
        </div>

        <div class="t_box_big">
            <div class="t_boxbig">
                <div class="weekheadline">设备生产状态</div>
                <div id="mainhourly" style="width: 50%; height: 4.5rem; float: left;"></div>
                <div id="mainabnormal" style="width: 50%; height: 4.5rem; float: left;"></div>
            </div>
            <div class="t_boxbig">
                <div class="t_Abnorma">
                    <table class="t_Abnorma">
                        <thead class="t_h_Abnorma">
                            <tr>
                                <th>页号</th>
                                <th>报警时间</th>
                                <th>报警ID</th>
                                <th>报警内容</th>
                            </tr>
                        </thead>
                        <tbody id="tbMain" class="main_table">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            //定时刷新数值显示块数据
            setInterval(function () {
                //使用AJAX Post请求获取后端数据
                numerical_Post();

            }, 1000);
            //定时刷新获取设备报警视图
            setInterval(function () {
                Alarm();
            }, 1000);
        </script>
    </form>
</body>
</html>
