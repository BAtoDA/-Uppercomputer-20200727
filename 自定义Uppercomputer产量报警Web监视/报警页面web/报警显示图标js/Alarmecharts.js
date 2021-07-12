$(function () {
    function DisposeechartsLoad() {
        // 基于准备好的dom，初始化echarts实例
        var myChart22 = echarts.init(document.getElementById('Disposeecharts'), 'customed');
        var colors = ['#5470C6', '#EE6666'];
        var option;
        option = {
            color: colors,

            tooltip: {
                trigger: 'none',
                axisPointer: {
                    type: 'cross'
                }
            },
            legend: {
                data: ['7天处理用时', '月度处理用时'],
                textStyle: {
                    color: "#ffffff"
                }
            },
            grid: {
                top: 70,
                bottom: 50
            },
            textStyle: {
                fontSize: 15,
                color: "#ffffff"
            },
            xAxis: [
                {
                    type: 'category',
                    axisLabel: {
                        color: "#ffffff"
                    },
                    axisLabel: {
                        color: "#ffffff"
                    },
                    axisTick: {
                        alignWithLabel: true
                    },
                    axisLine: {
                        onZero: false,
                        lineStyle: {
                            color: colors[1]
                        }
                    },
                    axisPointer: {
                        label: {
                            formatter: function (params) {
                                return '月度处理用时' + params.value
                                    + (params.seriesData.length ? '：' + params.seriesData[0].data : '') + '/分钟';
                            }
                        }
                    },
                    data: ['2016-1', '2016-2', '2016-3', '2016-4', '2016-5', '2016-6', '2016-7']
                },
                {
                    type: 'category',
                    axisLabel: {
                        color: "#ffffff"
                    },
                    axisLabel: {
                        color: "#ffffff"
                    },
                    axisTick: {
                        alignWithLabel: true
                    },
                    axisLine: {
                        onZero: false,
                        lineStyle: {
                            color: colors[0]
                        }
                    },
                    axisPointer: {
                        label: {
                            formatter: function (params) {
                                return '7天处理用时' + params.value
                                    + (params.seriesData.length ? '：' + params.seriesData[0].data : '') +'/分钟';
                            }
                        }
                    },
                    data: ['2015-1', '2015-2', '2015-3', '2015-4', '2015-5', '2015-6', '2015-7']
                }
            ],
            yAxis: [
                {
                    type: 'value',
                    axisLabel: {
                        color: "#ffffff"
                    }

                }
            ],
            series: [
                {
                    name: '7天处理用时',
                    type: 'line',
                    xAxisIndex: 1,
                    smooth: true,
                    emphasis: {
                        focus: 'series'
                    },
                    data: [2.6, 5.9, 9.0, 26.4, 28.7, 70.7, 175.6]
                },
                {
                    name: '月度处理用时',
                    type: 'line',
                    smooth: true,
                    emphasis: {
                        focus: 'series'
                    },
                    data: [3.9, 5.9, 11.1, 18.7, 48.3, 69.2, 231.6]
                }
            ]
        };
        //定时刷新数据
        setInterval(function () {
            $.ajax({//定时Post请求访问后端获取周数据
                type: "Post",
                url: "WebForm3.aspx/AlarDisposemnumber",
                contentType: "application/json;charset=utf - 8",
                dataType: "json",
                async: true,
                success:
                    function (data) {
                        //反序列化
                        var dataObj = eval("(" + data.d + ")");
                        var dataObj1 = eval("(" + dataObj + ")");
                        var r = dataObj1[0].Item1;
                        for (var i = 0; i < r.length; i++) {
                            option.xAxis[1].data[i] = r[i].Name;
                            option.series[0].data[i] = r[i].Data;
                        }
                        var q = dataObj1[1].Item1;
                        for (var i = 0; i < q.length; i++) {
                            option.xAxis[0].data[i] = q[i].Name;
                            option.series[1].data[i] = q[i].Data;
                        }

                    }
            });
            myChart22.setOption(option, true);
        }, 5000);
        // 使用刚指定的配置项和数据显示图表。
        myChart22.setOption(option);
        $.ajax({//定时Post请求访问后端获取周数据
            type: "Post",
            url: "WebForm3.aspx/AlarDisposemnumber",
            contentType: "application/json;charset=utf - 8",
            dataType: "json",
            async: true,
            success:
                function (data) {
                    //反序列化
                    var dataObj = eval("(" + data.d + ")");
                    var dataObj1 = eval("(" + dataObj + ")");
                    var r = dataObj1[0].Item1;
                    for (var i = 0; i < r.length; i++) {
                        option.xAxis[1].data[i] = r[i].Name;
                        option.series[0].data[i] = r[i].Data;
                    }
                    var q = dataObj1[1].Item1;
                    for (var i = 0; i < q.length; i++) {
                        option.xAxis[0].data[i] = q[i].Name;
                        option.series[1].data[i] = q[i].Data;
                    }
                    myChart22.setOption(option, true);
                }
        });
    }
    DisposeechartsLoad();//启动加载绘制方法
    //报警次数图表
    function AlarmchartsLoad() {
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('Alarmcharts'), 'customed');
        var colors = ['#A52A2A', '#EE6666'];
        var option;
        option = {
            color: colors,

            tooltip: {
                trigger: 'none',
                axisPointer: {
                    type: 'cross'
                }
            },
            legend: {
                data: ['7天报警', '月度报警'],
                textStyle: {
                    color: "#ffffff"
                }
            },
            grid: {
                top: 70,
                bottom: 50
            },
            textStyle: {
                fontSize: 15,
                color: "#ffffff"
            },
            xAxis: [
                {
                    type: 'category',
                    axisLabel: {
                        color: "#ffffff"
                    },
                    axisLabel: {
                        color: "#ffffff"
                    },
                    axisTick: {
                        alignWithLabel: true
                    },
                    axisLine: {
                        onZero: false,
                        lineStyle: {
                            color: colors[1]
                        }
                    },
                    axisPointer: {
                        label: {
                            formatter: function (params) {
                                return '月度报警次数  ' + params.value
                                    + (params.seriesData.length ? '：' + params.seriesData[0].data : '') + '/PCS';
                            }
                        }
                    },
                    data: ['2016-1', '2016-2', '2016-3', '2016-4', '2016-5', '2016-6', '2016-7']
                },
                {
                    type: 'category',
                    axisLabel: {
                        color: "#ffffff"
                    },
                    axisLabel: {
                        color: "#ffffff"
                    },
                    axisTick: {
                        alignWithLabel: true
                    },
                    axisLine: {
                        onZero: false,
                        lineStyle: {
                            color: colors[0]
                        }
                    },
                    axisPointer: {
                        label: {
                            formatter: function (params) {
                                return '7天报警次数 ' + params.value
                                    + (params.seriesData.length ? '：' + params.seriesData[0].data : '') + '/PCS';
                            }
                        }
                    },
                    data: ['2015-1', '2015-2', '2015-3', '2015-4', '2015-5', '2015-6', '2015-7']
                }
            ],
            yAxis: [
                {
                    type: 'value',
                    axisLabel: {
                        color: "#ffffff"
                    }

                }
            ],
            series: [
                {
                    name: '7天报警',
                    type: 'line',
                    xAxisIndex: 1,
                    smooth: true,
                    emphasis: {
                        focus: 'series'
                    },
                    data: [2.6, 5.9, 9.0, 26.4, 28.7, 70.7, 175.6]
                },
                {
                    name: '月度报警',   
                    type: 'line',
                    smooth: true,
                    emphasis: {
                        focus: 'series'
                    },
                    data: [3.9, 5.9, 11.1, 18.7, 48.3, 69.2, 231.6]
                }
            ]
        };
        //定时刷新数据
        setInterval(function () {
            $.ajax({//定时Post请求访问后端获取周数据
                type: "Post",
                url: "WebForm3.aspx/Alarmnumber",
                contentType: "application/json;charset=utf - 8",
                dataType: "json",
                async: true,
                success:
                    function (data) {
                        //反序列化
                        var dataObj = eval("(" + data.d + ")");
                        var r = dataObj[0].Item1;
                        for (var i = 0; i < r.length; i++) {
                            option.xAxis[1].data[i] = r[i].Name;
                            option.series[0].data[i] = r[i].Data;
                        }
                        var q = dataObj[1].Item1;
                        for (var i = 0; i < q.length; i++) {
                            option.xAxis[0].data[i] = q[i].Name;
                            option.series[1].data[i] = q[i].Data;
                        }                                            
                       
                    }
            });
            myChart.setOption(option, true);
        }, 6000);
        // 刷新调整
        window.onresize = function () {
            myChart.resize();
        }
        // 使用刚指定的配置项和数据显示图表。
        myChart.setOption(option);
        $.ajax({//定时Post请求访问后端获取周数据
            type: "Post",
            url: "WebForm3.aspx/Alarmnumber",
            contentType: "application/json;charset=utf - 8",
            dataType: "json",
            async: true,
            success:
                function (data) {
                    //反序列化
                    var dataObj = eval("(" + data.d + ")");
                    var r = dataObj[0].Item1;
                    for (var i = 0; i < r.length; i++) {
                        option.xAxis[1].data[i] = r[i].Name;
                        option.series[0].data[i] = r[i].Data;
                    }
                    var q = dataObj[1].Item1;
                    for (var i = 0; i < q.length; i++) {
                        option.xAxis[0].data[i] = q[i].Name;
                        option.series[1].data[i] = q[i].Data;
                    }
                    myChart.setOption(option, true);
                }
        });
    }
    AlarmchartsLoad();//加载图表
    //处理 报警次数 和报警用时
    function frequency() {
        $.ajax({//定时Post请求访问后端获取当班目标
            type: "Post",
            url: "WebForm3.aspx/MonthDisposeData",
            contentType: "application/json;charset=utf - 8",
            dataType: "json",
            async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
            success:
                function (data) {
                    //反序列化
                    var dataObj = eval("(" + data.d + ")");
                    document.getElementById('TodayAlarmData').innerHTML = dataObj.今日报警次数;
                    document.getElementById('DaysAlarmData').innerHTML = dataObj.week报警次数;
                    document.getElementById('MonthAlarmData').innerHTML = dataObj.本月报警次数;
                    document.getElementById('TodayDisposeData').innerHTML = dataObj.今日处理用时;
                    document.getElementById('DaysDisposeData').innerHTML = dataObj.week处理用时;
                    document.getElementById('MonthDisposeData').innerHTML = dataObj.本月处理用时;
                }
        });
    }
    //定时刷新读取次数 和用时
    setInterval(function () {
        frequency();
    }, 1000);
    frequency();
});
