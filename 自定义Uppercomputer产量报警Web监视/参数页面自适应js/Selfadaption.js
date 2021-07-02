
function Webselfadaption() {
    //判断按钮导航栏屏幕宽度 标准是1920*969 已知整体Html 1个rem等于100px
    if (document.body.clientWidth >= 600 && document.body.clientWidth < 6000) {
        var navigation = document.getElementById('Buttonnavigation');
        navigation.style.width = (((document.body.clientWidth / 300) / 2) - 0.2) + 'rem';
        //改变导航栏按钮宽度
        for (var i = 2; i < 8; i++) {
            var Name = ('Button' + i.toString()).toString();
            var navigationbutton1 = document.getElementById(Name);
            navigationbutton1.style.width = (document.body.clientWidth / 800) + 'rem';
            navigationbutton1.style.left = (document.body.clientWidth / 7680) + 'rem';
        }
    }
    //判断高度
    if (document.body.clientHeight >= 200 && document.body.clientHeight < 3000) {
        var navigation = document.getElementById('Buttonnavigation');
        navigation.style.height = (document.body.clientHeight / 114) + 'rem';
        //改变导航栏按钮宽度
        for (var i = 2; i < 8; i++) {
            var Name = ('Button' + i.toString()).toString();
            var navigationbutton1 = document.getElementById(Name);
            navigationbutton1.style.height = (document.body.clientHeight / 1211.25) + 'rem';
            navigationbutton1.style.top = (document.body.clientHeight / 9690) + 'rem';
            navigationbutton1.style.marginTop = (document.body.clientHeight / 1938) + 'rem';
        }
    }
    ////判断MainActivity主页面
    //if (document.body.clientWidth >= 600 && document.body.clientWidth < 6000) {
    //    var navigation = document.getElementById('MainActivity');
    //    navigation.style.width = (document.body.clientWidth / 123.87) + 'rem';
    //}
    ////判断高度
    //if (document.body.clientHeight >= 200 && document.body.clientHeight < 3000) {
    //    var navigation = document.getElementById('MainActivity');
    //    navigation.style.height = (document.body.clientHeight / 114) + 'rem';
    //}
}
//定时刷新自适应代码
setInterval(function () {
    Webselfadaption();
    isFullscreenForNoScroll();
}, 300);

function isFullscreenForNoScroll() {
    var explorer = window.navigator.userAgent.toLowerCase();
    if (explorer.indexOf('chrome') > 0) {//webkit
        if (document.body.scrollHeight === window.screen.height && document.body.scrollWidth === window.screen.width) {
            $.ajax({//改读后端值--表示已经处理完成任务
                type: "post",
                url: "WebForm2.aspx/Fullscreenee",
                contentType: "application/json;charset=utf - 8",
                dataType: "json",
                async: false,
                success:
                    function (data) {
                        if (data.d.toString() == "true") {
                            // alert(data.d + '进入全屏');
                            $.ajax({//改写后端值--表示已经处理完成任务
                                type: "post",
                                url: "WebForm2.aspx/Fullscreene",
                                contentType: "application/json;charset=utf - 8",
                                dataType: "json",
                                data: "{ 'name':false}",
                                async: false,
                                success:
                                    function (data) {
                                        // alert(data.d + '改写值完成');
                                        location.reload();//重新刷新网页
                                    }
                            });
                        }
                    }
            });
        } else {
            $.ajax({//改读后端值--表示已经处理完成任务
                type: "post",
                url: "WebForm2.aspx/Fullscreenee",
                contentType: "application/json;charset=utf - 8",
                dataType: "json",
                async: false,
                success:
                    function (data) {
                        if (data.d.toString() != "true") {
                            //  alert(data.d + '退出全屏');
                            $.ajax({//改写后端值--表示已经处理完成任务
                                type: "post",
                                url: "WebForm2.aspx/Fullscreene",
                                contentType: "application/json;charset=utf - 8",
                                dataType: "json",
                                data: "{ 'name':true}",
                                async: false,
                                success:
                                    function (data) {
                                        //alert(data.d + '退出全屏 改写值完成');
                                        location.reload();//重新刷新网页
                                    }
                            });
                        }
                    }
            });


        }
    } else {//IE 9+  fireFox
        if (window.outerHeight === window.screen.height && window.outerWidth === window.screen.width) {
            $.ajax({//改读后端值--表示已经处理完成任务
                type: "post",
                url: "WebForm2.aspx/Fullscreenee",
                contentType: "application/json;charset=utf - 8",
                dataType: "json",
                async: false,
                success:
                    function (data) {
                        if (data.d.toString() == "true") {
                            // alert(data.d + '进入全屏');
                            $.ajax({//改写后端值--表示已经处理完成任务
                                type: "post",
                                url: "WebForm2.aspx/Fullscreene",
                                contentType: "application/json;charset=utf - 8",
                                dataType: "json",
                                data: "{ 'name':false}",
                                async: false,
                                success:
                                    function (data) {
                                        // alert(data.d + '改写值完成');
                                        location.reload();//重新刷新网页
                                    }
                            });
                        }
                    }
            });
        } else {
            $.ajax({//改读后端值--表示已经处理完成任务
                type: "post",
                url: "WebForm2.aspx/Fullscreenee",
                contentType: "application/json;charset=utf - 8",
                dataType: "json",
                async: false,
                success:
                    function (data) {
                        if (data.d.toString() != "true") {
                            //  alert(data.d + '退出全屏');
                            $.ajax({//改写后端值--表示已经处理完成任务
                                type: "post",
                                url: "WebForm2.aspx/Fullscreene",
                                contentType: "application/json;charset=utf - 8",
                                dataType: "json",
                                data: "{ 'name':true}",
                                async: false,
                                success:
                                    function (data) {
                                        //alert(data.d + '退出全屏 改写值完成');
                                        location.reload();//重新刷新网页
                                    }
                            });
                        }
                    }
            });
        }
    }
}