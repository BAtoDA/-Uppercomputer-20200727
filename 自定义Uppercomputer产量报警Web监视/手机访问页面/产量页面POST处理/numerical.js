function numerical_Post() {
    $.ajax({//定时Post请求访问后端获取当班目标
        type: "Post",
        url: "手机产量页面.aspx/GetSquad_target",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
        success:
            function (data) {
                document.getElementById('target').innerHTML = data.d;
            }
    });
    $.ajax({//定时Post请求访问后端获取当班产量
        type: "Post",
        url: "手机产量页面.aspx/Squad_output",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
        success:
            function (data) {
                document.getElementById('present').innerHTML = data.d;
            }
    });
    $.ajax({//定时Post请求访问后端获取当月目标产量
        type: "Post",
        url: "手机产量页面.aspx/headline_target",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
        success:
            function (data) {
                document.getElementById('monthtarget').innerHTML = data.d;
            }
    });
    $.ajax({//定时Post请求访问后端获取当月产量
        type: "Post",
        url: "手机产量页面.aspx/headline_output",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
        success:
            function (data) {
                document.getElementById('month').innerHTML = data.d;
            }
    });
    $.ajax({//定时Post请求访问后端获取全年产量
        type: "Post",
        url: "手机产量页面.aspx/headline1_output",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
        success:
            function (data) {
                document.getElementById('yearly').innerHTML = data.d;
            }
    });
}
//定时刷新数据
setInterval(function () {
    numerical_Post();

}, 800);