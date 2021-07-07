<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="手机产量页面.aspx.cs" Inherits="HTML布局学习.WebForm22" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes" />
    <title>产量页面</title>
    <%-- 处理页面大小与比例--%>
    <style>
        /*简单初始化*/
        html {
            font-size: 10px; /*设置html字体大小以便rem*/
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
    </style>
</head>
<body style="width:100%;height:100%; background:url('图片/bg.png') no-repeat;background-size:100% 100%;">
    <form id="form1" runat="server">
       <%-- 标题--%>
        <header style="width:100%;height:100%;font-size:40%; color:#ffffff; text-align:center; background:url('图片/bg_title.png') no-repeat;background-size:100% 100%; ">
            产量显示
        </header>
        <div >
        </div>
    </form>
</body>
</html>
