$(function () {
    mainweek();//加载时启动js方法
    function mainweek() {
        // 基于准备好的dom，初始化echarts实例
        var myChart20 = echarts.init(document.getElementById('mainweek'), 'customed');
        var data20 = [];
        for (let i = 0; i < 7; ++i) {
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
                data: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sunday"],
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
                name: '周产量',
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
            $.ajax({//定时Post请求访问后端获取周数据
                type: "Post",
                url: "手机产量页面.aspx/GetWeekData",
                contentType: "application/json;charset=utf - 8",
                dataType: "json",
                success:
                    function (data) {
                        for (let i = 0; i < data.d.length; i++) {
                            data20[i] = data.d[i];
                        }
                        // 使用刚指定的配置项和数据显示图表。
                        myChart20.setOption(option20);
                    }
            });
            // 使用刚指定的配置项和数据显示图表。
            myChart20.setOption(option20);
        }, 1000);
        // 使用刚指定的配置项和数据显示图表。
        myChart20.setOption(option20);
        $.ajax({//定时Post请求访问后端获取周数据
            type: "Post",
            url: "手机产量页面.aspx/GetWeekData",
            contentType: "application/json;charset=utf - 8",
            dataType: "json",
            success:
                function (data) {
                    for (let i = 0; i < data.d.length; i++) {
                        data20[i] = data.d[i];
                    }
                    // 使用刚指定的配置项和数据显示图表。
                    myChart20.setOption(option20);
                }
        });
    }
});