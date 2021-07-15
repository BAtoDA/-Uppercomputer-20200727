$(function () {
    mainmonth();//加载时启动js方法
    function mainmonth() {
        // 基于准备好的dom，初始化echarts实例
        var myChart201 = echarts.init(document.getElementById('mainmonth'), 'customed');
        var data20 = [];//定义每小时数据
        var Name20 = [];//定义每小时名称
        var myDate = new Date();//实例化时间
        for (let i = 0; i < 5; ++i) {
            Name20.push(myDate.getHours());//获取当前时间
            Name20[i] += + myDate.getMinutes();
            data20.push(Math.round(Math.random() * 200));
        }

        // 指定图表的配置项和数据
        var option20 = {
            tooltip: {},
            //legend: {
            //    data: ['小时产量']
            //},
            xAxis: [{
                type: "category",
                data: Name20,
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
                name: '月产量',
                type: 'line',
                data: data20,
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
                url: 'WebForm1.aspx/Yearyield',
                dataType: 'json',
                async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
                success: function (data) {

                    var dataObj = eval("(" + data.d + ")");

                    $.each(dataObj, function (i, item) {
                        $("#imageslist").append("<li><img alt=\"" + item.HourData + "\" src=\"" + item.HourName + "\"/></li>");
                        Name20[i] = item.HourName;
                        data20[i] = item.HourData;
                        // 使用刚指定的配置项和数据显示图表。
                        myChart201.setOption(option20);
                    })

                }
            });
            // 使用刚指定的配置项和数据显示图表。
            myChart201.setOption(option20);
        }, 3500);
        // 使用刚指定的配置项和数据显示图表。
        myChart201.setOption(option20);
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: 'WebForm1.aspx/Yearyield',
            dataType: 'json',
            async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
            success: function (data) {

                var dataObj = eval("(" + data.d + ")");

                $.each(dataObj, function (i, item) {
                    $("#imageslist").append("<li><img alt=\"" + item.HourData + "\" src=\"" + item.HourName + "\"/></li>");
                    Name20[i] = item.HourName;
                    data20[i] = item.HourData;
                    // 使用刚指定的配置项和数据显示图表。
                    myChart201.setOption(option20);
                })

            }
        });
    }
});