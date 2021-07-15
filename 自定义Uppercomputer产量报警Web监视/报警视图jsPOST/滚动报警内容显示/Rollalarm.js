var Index = 0;
//处理当前滚动报警
function PresentRoll() {
    //AXAJ请求获取后端当前报警数据
    $.ajax({
        type: "Post",
        url: "WebForm3.aspx/PresentRoll",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: true,
        success:
            function (data) {
                //反序列化
                var dataObj = eval("(" + data.d + ")");
                if (data.d =="true") {
                    clearInterval(T);    //停止定时
                    //表明无报警隐藏所有报警条
                    var presenterr1 = document.getElementById('presenterr1');
                    presenterr1.style.visibility = "hidden";//隐藏该项
                    var presenterr2 = document.getElementById('presenterr2');
                    presenterr2.style.visibility = "hidden";//隐藏该项
                    var presenterr3 = document.getElementById('presenterr3');
                    presenterr3.style.visibility = "hidden";//隐藏该项
                }


            }
    });
    var T = setInterval(TimeControl, 3000);    //开始定时
}
function TimeControl() {
    $(".message_scroll_box").animate({ marginTop: 76 }, 800,
        function () {
            $(".message_scroll_box .message_scroll:first").before($(".message_scroll_box .message_scroll:last"));    //在第一个新闻后面插入最后一个新闻
            $(".message_scroll_box").css({ marginTop: 0 });    //把顶部的边界清零

        });
}

$(".message_scroll_box").mouseenter(function () {
    clearInterval(T);    //停止定时
})
    .mouseleave(function () {
        T = setInterval(TimeControl, 3800);    //再次定时
    })