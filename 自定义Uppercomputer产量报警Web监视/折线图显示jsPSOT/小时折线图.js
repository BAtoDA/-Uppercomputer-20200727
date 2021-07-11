$(function () {
    mainhour();//加载时启动js方法
    function mainhour() {
        // 基于准备好的dom，初始化echarts实例
        var myChart10 = echarts.init(document.getElementById('mainhour'), 'customed');
        var data10 = [];//定义每小时数据
        var Name10 = [];//定义每小时名称
        var myDate = new Date();//实例化时间
        for (let i = 0; i < 6; ++i) {
            Name10.push(myDate.getHours());//获取当前时间
            Name10[i] += + myDate.getMinutes();
            data10.push(Math.round(Math.random() * 200));
        }
        // 指定图表的配置项和数据
        var option10 = {
            tooltip: {},
            //legend: {
            //    data: ['小时产量']
            //},
            xAxis: [{
                type: "category",
                data: Name10,
                axisLine: {
                    lineStyle: {
                        color: "rgba(248, 248, 248, 1)"
                    }
                },
                axisLabel: {
                    color: '#FFFFFF',
                    fontWeight: "bold",
                    fontSize: 14
                }
            }],
            yAxis: {
                axisLine: {
                    lineStyle: {
                        color: "rgba(248, 248, 248, 1)"
                    }
                },
                axisLabel: {
                    color: '#FFFFFF',
                    fontWeight: "bold",
                    fontSize: 15
                }
            },
            series: [{
                name: '小时产量',
                type: 'line',
                data: data10,
                inverse: true,
                animationDuration: 300,
                animationDurationUpdate: 300,
                max: 2 // only the largest 3 bars will be displayed
            }],
            label: {
                show: true,
                position: 'top',
                valueAnimation: true,
                color: '#FFFFFF'
            },
            roseType: 'angle',
            itemStyle: {
                normal: {
                    shadowBlur: 200,
                    shadowColor: 'rgba(0, 0, 0, 0.5)'
                },
            },
            color: '#FFFFFF',
            textBorderColor: '#FFFFFF'
        };
        setInterval(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: 'WebForm1.aspx/Houryield',
                dataType: 'json',
                async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
                success: function (data) {

                    var dataObj = eval("(" + data.d + ")");

                    $.each(dataObj, function (i, item) {
                        $("#imageslist").append("<li><img alt=\"" + item.HourData + "\" src=\"" + item.HourName + "\"/></li>");
                        Name10[i] = item.HourName;
                        data10[i] = item.HourData;
                    })

                },
                error: function () {
                    //  alert("error!");
                }
            });
            // 使用刚指定的配置项和数据显示图表。
            myChart10.setOption(option10);
        }, 2000);
        // 使用刚指定的配置项和数据显示图表。
        myChart10.setOption(option10);
    }
});