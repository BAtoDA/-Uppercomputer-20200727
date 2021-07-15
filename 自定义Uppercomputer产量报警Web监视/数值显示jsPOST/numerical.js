function numerical_Post() {
    $.ajax({//定时Post请求访问后端获取当班目标
        type: "Post",
        url: "WebForm1.aspx/GetSquad_target",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
        success:
            function (data) {
                document.getElementById('Squad_target').innerHTML = data.d;
            }
    });
    $.ajax({//定时Post请求访问后端获取当班产量
        type: "Post",
        url: "WebForm1.aspx/Squad_output",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
        success:
            function (data) {
                document.getElementById('Squad_output').innerHTML = data.d;
            }
    });
    $.ajax({//定时Post请求访问后端获取当月目标产量
        type: "Post",
        url: "WebForm1.aspx/headline_target",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
        success:
            function (data) {
                document.getElementById('headline_target').innerHTML = data.d;
            }
    });
    $.ajax({//定时Post请求访问后端获取当月产量
        type: "Post",
        url: "WebForm1.aspx/headline_output",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
        success:
            function (data) {
                document.getElementById('headline_output').innerHTML = data.d;
            }
    });
    $.ajax({//定时Post请求访问后端获取全年产量
        type: "Post",
        url: "WebForm1.aspx/headline1_output",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
        success:
            function (data) {
                document.getElementById('headline1_output').innerHTML = data.d;
            }
    });
}