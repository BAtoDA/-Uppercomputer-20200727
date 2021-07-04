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
                data: ['2015 降水量', '2016 降水量'],
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
                                return '降水量  ' + params.value
                                    + (params.seriesData.length ? '：' + params.seriesData[0].data : '');
                            }
                        }
                    },
                    data: ['2016-1', '2016-2', '2016-3', '2016-4', '2016-5', '2016-6', '2016-7', '2016-8', '2016-9', '2016-10', '2016-11', '2016-12']
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
                                return '降水量  ' + params.value
                                    + (params.seriesData.length ? '：' + params.seriesData[0].data : '');
                            }
                        }
                    },
                    data: ['2015-1', '2015-2', '2015-3', '2015-4', '2015-5', '2015-6', '2015-7', '2015-8', '2015-9', '2015-10', '2015-11', '2015-12']
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
                    name: '2015 降水量',
                    type: 'line',
                    xAxisIndex: 1,
                    smooth: true,
                    emphasis: {
                        focus: 'series'
                    },
                    data: [2.6, 5.9, 9.0, 26.4, 28.7, 70.7, 175.6, 182.2, 48.7, 18.8, 6.0, 2.3]
                },
                {
                    name: '2016 降水量',
                    type: 'line',
                    smooth: true,
                    emphasis: {
                        focus: 'series'
                    },
                    data: [3.9, 5.9, 11.1, 18.7, 48.3, 69.2, 231.6, 46.6, 55.4, 18.4, 10.3, 0.7]
                }
            ]
        };
        // 使用刚指定的配置项和数据显示图表。
        myChart22.setOption(option);
    }
    DisposeechartsLoad();//启动加载绘制方法
    //报警次数图表
    function AlarmchartsLoad() {
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('Alarmcharts'), 'customed');
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
                                return '报警次数  ' + params.value
                                    + (params.seriesData.length ? '：' + params.seriesData[0].data : '');
                            }
                        }
                    },
                    data: ['2016-1', '2016-2', '2016-3', '2016-4', '2016-5', '2016-6', '2016-7', '2016-8', '2016-9', '2016-10', '2016-11', '2016-12']
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
                                return '报警次数  ' + params.value
                                    + (params.seriesData.length ? '：' + params.seriesData[0].data : '');
                            }
                        }
                    },
                    data: ['2015-1', '2015-2', '2015-3', '2015-4', '2015-5', '2015-6', '2015-7', '2015-8', '2015-9', '2015-10', '2015-11', '2015-12']
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
                    data: [2.6, 5.9, 9.0, 26.4, 28.7, 70.7, 175.6, 182.2, 48.7, 18.8, 6.0, 2.3]
                },
                {
                    name: '月度报警',   
                    type: 'line',
                    smooth: true,
                    emphasis: {
                        focus: 'series'
                    },
                    data: [3.9, 5.9, 11.1, 18.7, 48.3, 69.2, 231.6, 46.6, 55.4, 18.4, 10.3, 0.7]
                }
            ]
        };                  
        // 使用刚指定的配置项和数据显示图表。
        myChart.setOption(option);
    }
    AlarmchartsLoad();//加载图表
});