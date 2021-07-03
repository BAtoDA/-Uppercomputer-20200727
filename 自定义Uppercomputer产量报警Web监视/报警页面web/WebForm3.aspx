<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="HTML布局学习.报警页面web.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- 引入jquery前后端互交 -->
    <script src="Echarts/jquery-3.5.1.min.js"></script>
    <!-- 引入 echarts.js -->
    <script src="Echarts/Echarts/echarts.js"></script>
    <script src="Echarts/customed.js"></script>
    <script src="JavaScript.js"></script>
    <%--引入布局样式--%>
    <link rel="stylesheet" href="报警界面布局样式.css" />
    <!-- 引入 雪花飘落特效 -->
    <link rel="stylesheet" href="樱花特效css/style.css" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no" />
    <title>报警界面监控</title>
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

        </div>
        <%--布局一个用于展示滚动报警的数据的div--%>
        <div class="t_box2">
        </div>
        <%--布局一个用于展示当天报警数据的2个小方块--%>
        <div class="t_boxbig">
        </div>
        <div class="t_boxbig">
        </div>
    </form>
</body>
</html>
