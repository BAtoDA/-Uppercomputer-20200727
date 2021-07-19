var Index = 0;
var valie = 0;
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
                if (data.d == "true") {                   
                    //表明无报警隐藏所有报警条
                    var presenterr1 = document.getElementById('presenterr1');
                    presenterr1.style.visibility = "hidden";//隐藏该项
                    var presenterr2 = document.getElementById('presenterr2');
                    presenterr2.style.visibility = "hidden";//隐藏该项
                    var presenterr3 = document.getElementById('presenterr3');
                    presenterr3.style.visibility = "hidden";//隐藏该项
                    var presenterr3 = document.getElementById('presenterr4');
                    presenterr3.style.visibility = "hidden";//隐藏该项
                }
                else {
                    //有数据上传
                    //if (dataObj.ID > 2) {
                    //    RollIndex(dataObj);
                    //}
                    //else {
                    //遍历数据
                    $.each(dataObj, function (i, item) {
                        var presenterr = document.getElementById('presenttitle' + (i + 1));
                        var presentlevel = document.getElementById('presentlevel' + (i + 1));
                        var presentTime = document.getElementById('presentTime' + (i + 1));
                        var presentValue = document.getElementById('presentValue' + (i + 1));
                        presenterr.innerHTML = item.设备地址 + item.设备_具体地址;
                        if (item.类型) {
                            presentlevel.innerHTML = "位触发"
                        }
                        else {
                            presentlevel.innerHTML = "字触发"
                        }
                        presentTime.innerHTML = item.报警时间;
                        presentValue.innerHTML = item.报警内容;
                        var presenterr1 = document.getElementById('presenterr' + (i+1));
                        presenterr1.style.visibility = "visible";//显示
                        valie = dataObj.length;
                    })
                    //如果长度不足4隐藏数据
                    for (var i = valie; i < 4; i++) {
                        var presenterr1 = document.getElementById('presenterr' + (i+1));
                        presenterr1.style.visibility = "hidden";//隐藏该项
                    }
                   // }
                }

            }
    });
   // var T = setInterval(TimeControl, 3000);    //开始定时
}
function RollIndex(Data) {
    //根据索引改变内容
    switch (Index) {
        case 0:
            var presenterr = document.getElementById('presenttitle4');
            var presentlevel = document.getElementById('presentlevel4');
            var presentTime = document.getElementById('presentTime4');
            var presentValue = document.getElementById('presentValue4');
            presenterr.innerHTML = Data.设备地址 + Data.设备_具体地址;
            if (Data.类型) {
                presentlevel.innerHTML = "位触发"
            }
            else {
                presentlevel.innerHTML = "字触发"
            }
            presentTime.innerHTML = Data.报警时间;
            presentValue.innerHTML = Data.报警内容;
            //var presenterr1 = document.getElementById('presenterr4');
            //presenterr1.style.visibility = "visible";//显示
            if (Data.ID > 1) {
                $(".message_scroll_box1").animate({ marginTop: 76 }, 1200,
                    function () {
                        var presenterr1 = document.getElementById('presenterr4');
                        presenterr1.style.visibility = "visible";//显示
                        $(".message_scroll_box1 .message_scroll1:first").before($(".message_scroll_box1 .message_scroll1:last"));    //在第一个新闻后面插入最后一个新闻
                        $(".message_scroll_box1").css({ marginTop: 0 });    //把顶部的边界清零
                        var presenterr1 = document.getElementById('presenterr3');
                        presenterr1.style.visibility = "hidden";//隐藏该项
                    });
            }
            break;
        case 1:
            var presenterr = document.getElementById('presenttitle3');
            var presentlevel = document.getElementById('presentlevel3');
            var presentTime = document.getElementById('presentTime3');
            var presentValue = document.getElementById('presentValue3');
            presenterr.innerHTML = Data.设备地址 + Data.设备_具体地址;
            if (Data.类型) {
                presentlevel.innerHTML = "位触发"
            }
            else {
                presentlevel.innerHTML = "字触发"
            }
            presentTime.innerHTML = Data.报警时间;
            presentValue.innerHTML = Data.报警内容;
            //var presenterr1 = document.getElementById('presenterr3');
            //presenterr1.style.visibility = "visible";//显示
            if (Data.ID >1) {
                $(".message_scroll_box1").animate({ marginTop: 76 }, 1200,
                    function () {
                        var presenterr1 = document.getElementById('presenterr3');
                        presenterr1.style.visibility = "visible";//显示
                        $(".message_scroll_box1 .message_scroll1:first").before($(".message_scroll_box1 .message_scroll1:last"));    //在第一个新闻后面插入最后一个新闻
                        $(".message_scroll_box1").css({ marginTop: 0 });    //把顶部的边界清零
                        var presenterr1 = document.getElementById('presenterr2');
                        presenterr1.style.visibility = "hidden";//隐藏该项
                    });
            }
            break;
        case 2:
            var presenterr = document.getElementById('presenttitle2');
            var presentlevel = document.getElementById('presentlevel2');
            var presentTime = document.getElementById('presentTime2');
            var presentValue = document.getElementById('presentValue2');
            presenterr.innerHTML = Data.设备地址 + Data.设备_具体地址;
            if (Data.类型) {
                presentlevel.innerHTML = "位触发"
            }
            else {
                presentlevel.innerHTML = "字触发"
            }
            presentTime.innerHTML = Data.报警时间;
            presentValue.innerHTML = Data.报警内容;
            //var presenterr1 = document.getElementById('presenterr2');
            //presenterr1.style.visibility = "visible";//显示
            if (Data.ID > 1) {
                $(".message_scroll_box1").animate({ marginTop: 76 }, 1200,
                    function () {
                        var presenterr1 = document.getElementById('presenterr2');
                        presenterr1.style.visibility = "visible";//显示
                        $(".message_scroll_box1 .message_scroll1:first").before($(".message_scroll_box1 .message_scroll1:last"));    //在第一个新闻后面插入最后一个新闻
                        $(".message_scroll_box1").css({ marginTop: 0 });    //把顶部的边界清零
                        var presenterr1 = document.getElementById('presenterr1');
                        presenterr1.style.visibility = "hidden";//隐藏该项
                    });
            }
            break;
        case 3:
            var presenterr = document.getElementById('presenttitle1');
            var presentlevel = document.getElementById('presentlevel1');
            var presentTime = document.getElementById('presentTime1');
            var presentValue = document.getElementById('presentValue1');
            presenterr.innerHTML = Data.设备地址 + Data.设备_具体地址;
            if (Data.类型) {
                presentlevel.innerHTML = "位触发"
            }
            else {
                presentlevel.innerHTML = "字触发"
            }
            presentTime.innerHTML = Data.报警时间;
            presentValue.innerHTML = Data.报警内容;
            //var presenterr1 = document.getElementById('presenterr1');
            //presenterr1.style.visibility = "visible";//显示
            if (Data.ID > 1) {
                $(".message_scroll_box1").animate({ marginTop: 76 }, 1200,
                    function () {
                        var presenterr1 = document.getElementById('presenterr1');
                        presenterr1.style.visibility = "visible";//显示
                        $(".message_scroll_box1 .message_scroll1:first").before($(".message_scroll_box1 .message_scroll1:last"));    //在第一个新闻后面插入最后一个新闻
                        $(".message_scroll_box1").css({ marginTop: 0 });    //把顶部的边界清零
                        var presenterr1 = document.getElementById('presenterr4');
                        presenterr1.style.visibility = "hidden";//隐藏该项
                    });
            }
            break;
    }
    //判断后面还有多少数据如果空 则

    if (Index >= 3) {
        Index = 0;
    }
    else {
        Index += 1;
    }
    if (Data.ID > 1) {
       // TimeControl();
    }
}
//定时刷新数据
setInterval(function () {
    PresentRoll();
  
}, 2500);
function TimeControl() {
    $(".message_scroll_box").animate({ marginTop: 76 }, 800,
        function () {
            $(".message_scroll_box .message_scroll:first").before($(".message_scroll_box .message_scroll:last"));    //在第一个新闻后面插入最后一个新闻
            $(".message_scroll_box").css({ marginTop: 0 });    //把顶部的边界清零

        });
}

//$(".message_scroll_box").mouseenter(function () {
//    clearInterval(T);    //停止定时
//})
//    .mouseleave(function () {
//        T = setInterval(TimeControl, 3800);    //再次定时
//    })


//报警历史滚动报警条
var Index1 = 0;
//处理当前滚动报警
function PresentRollhistory() {
    //AXAJ请求获取后端当前报警数据
    $.ajax({
        type: "Post",
        url: "WebForm3.aspx/PresentRollhistory",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        
        success:
            function (data) {
                //反序列化
                var dataObj = eval("(" + data.d + ")");
                if (data.d == "true") {
                    //表明无报警隐藏所有报警条
                    var presenterr1 = document.getElementById('presenterr10');
                    presenterr1.style.visibility = "hidden";//隐藏该项
                    var presenterr2 = document.getElementById('presenterr11');
                    presenterr2.style.visibility = "hidden";//隐藏该项
                    var presenterr3 = document.getElementById('presenterr12');
                    presenterr3.style.visibility = "hidden";//隐藏该项
                    var presenterr3 = document.getElementById('presenterr13');
                    presenterr3.style.visibility = "hidden";//隐藏该项
                }
                else {
                    //有数据上传
                    RollIndexhistory(dataObj);
                }

            }
    });
}
function RollIndexhistory(Data) {
    //根据索引改变内容
    switch (Index1) {
        case 0:
            var presenterr = document.getElementById('presenttitle13');
            var presentlevel = document.getElementById('presentlevel13');
            var presentTime = document.getElementById('presentTime13');
            var presentValue = document.getElementById('presentValue13');
            presenterr.innerHTML = Data.设备_地址 + Data.设备_具体地址;
            if (Data.类型) {
                presentlevel.innerHTML = "位触发"
            }
            else {
                presentlevel.innerHTML = "字触发"
            }
            presentTime.innerHTML = Data.报警时间;
            presentValue.innerHTML = Data.报警内容;
            if (Data.ID > 1) {
                $(".message_scroll_box1").animate({ marginTop: 76 }, 1200,
                    function () {
                        var presenterr1 = document.getElementById('presenterr13');
                        presenterr1.style.visibility = "visible";//显示
                        $(".message_scroll_box1 .message_scroll1:first").before($(".message_scroll_box1 .message_scroll1:last"));    //在第一个新闻后面插入最后一个新闻
                        $(".message_scroll_box1").css({ marginTop: 0 });    //把顶部的边界清零
                        var presenterr1 = document.getElementById('presenterr12');
                        presenterr1.style.visibility = "hidden";//隐藏该项
                    });
            }
          
            break;
        case 1:
            var presenterr = document.getElementById('presenttitle12');
            var presentlevel = document.getElementById('presentlevel12');
            var presentTime = document.getElementById('presentTime12');
            var presentValue = document.getElementById('presentValue12');
            presenterr.innerHTML = Data.设备_地址 + Data.设备_具体地址;
            if (Data.类型) {
                presentlevel.innerHTML = "位触发"
            }
            else {
                presentlevel.innerHTML = "字触发"
            }
            presentTime.innerHTML = Data.报警时间;
            presentValue.innerHTML = Data.报警内容;
            //var presenterr1 = document.getElementById('presenterr11');
            //presenterr1.style.visibility = "hidden";//隐藏该项
            //var presenterr1 = document.getElementById('presenterr12');
            //presenterr1.style.visibility = "visible";//显示
            if (Data.ID > 1) {
                $(".message_scroll_box1").animate({ marginTop: 76 }, 1200,
                    function () {
                        var presenterr1 = document.getElementById('presenterr12');
                        presenterr1.style.visibility = "visible";//显示
                        $(".message_scroll_box1 .message_scroll1:first").before($(".message_scroll_box1 .message_scroll1:last"));    //在第一个新闻后面插入最后一个新闻
                        $(".message_scroll_box1").css({ marginTop: 0 });    //把顶部的边界清零
                        var presenterr1 = document.getElementById('presenterr11');
                        presenterr1.style.visibility = "hidden";//隐藏该项
                    });
            }
            break;
        case 2:
            var presenterr = document.getElementById('presenttitle11');
            var presentlevel = document.getElementById('presentlevel11');
            var presentTime = document.getElementById('presentTime11');
            var presentValue = document.getElementById('presentValue11');
            presenterr.innerHTML = Data.设备_地址 + Data.设备_具体地址;
            if (Data.类型) {
                presentlevel.innerHTML = "位触发"
            }
            else {
                presentlevel.innerHTML = "字触发"
            }
            presentTime.innerHTML = Data.报警时间;
            presentValue.innerHTML = Data.报警内容;
            //var presenterr1 = document.getElementById('presenterr10');
            //presenterr1.style.visibility = "hidden";//隐藏该项
            //var presenterr1 = document.getElementById('presenterr11');
            //presenterr1.style.visibility = "visible";//显示
            if (Data.ID > 1) {
                $(".message_scroll_box1").animate({ marginTop: 76 }, 1200,
                    function () {
                        var presenterr1 = document.getElementById('presenterr11');
                        presenterr1.style.visibility = "visible";//显示
                        $(".message_scroll_box1 .message_scroll1:first").before($(".message_scroll_box1 .message_scroll1:last"));    //在第一个新闻后面插入最后一个新闻
                        $(".message_scroll_box1").css({ marginTop: 0 });    //把顶部的边界清零
                        var presenterr1 = document.getElementById('presenterr10');
                        presenterr1.style.visibility = "hidden";//隐藏该项
                    });
            }
            break;
        case 3:
            var presenterr = document.getElementById('presenttitle10');
            var presentlevel = document.getElementById('presentlevel10');
            var presentTime = document.getElementById('presentTime10');
            var presentValue = document.getElementById('presentValue10');
            presenterr.innerHTML = Data.设备_地址 + Data.设备_具体地址;
            if (Data.类型) {
                presentlevel.innerHTML = "位触发"
            }
            else {
                presentlevel.innerHTML = "字触发"
            }
            presentTime.innerHTML = Data.报警时间;
            presentValue.innerHTML = Data.报警内容;

            //var presenterr1 = document.getElementById('presenterr13');
            //presenterr1.style.visibility = "hidden";//隐藏该项
            //var presenterr1 = document.getElementById('presenterr10');
            //presenterr1.style.visibility = "visible";//显示
            if (Data.ID > 1) {
                $(".message_scroll_box1").animate({ marginTop: 76 }, 1200,
                    function () {
                        var presenterr1 = document.getElementById('presenterr10');
                        presenterr1.style.visibility = "visible";//显示
                        $(".message_scroll_box1 .message_scroll1:first").before($(".message_scroll_box1 .message_scroll1:last"));    //在第一个新闻后面插入最后一个新闻
                        $(".message_scroll_box1").css({ marginTop: 0 });    //把顶部的边界清零
                        var presenterr1 = document.getElementById('presenterr13');
                        presenterr1.style.visibility = "hidden";//隐藏该项
                    });
            }
          
            break;
    }
    //判断后面还有多少数据如果空 则
    if (Index1 >= 3) {
        Index1 = 0;
    }
    else {
        Index1 += 1;
    }
   
}
//定时刷新数据
setInterval(function () {
    PresentRollhistory();

}, 5000);
function TimeControl1() {
    $(".message_scroll_box1").animate({ marginTop: 76 }, 1200,
        function () {
            $(".message_scroll_box1 .message_scroll1:first").before($(".message_scroll_box1 .message_scroll1:last"));    //在第一个新闻后面插入最后一个新闻
            $(".message_scroll_box1").css({ marginTop: 0 });    //把顶部的边界清零

        });
}
//var T1 = setInterval(TimeControl1, 2000);    //开始定时
//$(".message_scroll_box1").mouseenter(function () {
//    clearInterval(T1);    //停止定时
//})
    //.mouseleave(function () {
    //    T1 = setInterval(TimeControl1, 2000);    //再次定时
    //})