
    $(function () {
        speed()();//加载时启动js方法
        function speed() {
            // 基于准备好的dom，初始化echarts实例
            var myChart30 = echarts.init(document.getElementById('speede'), 'customed');
            // 指定图表的配置项和数据
            var option30 = {
                tooltip: {
                    formatter: '{a} <br/>{b} : {c}PCS'
                },
                series: [{
                    name: 'Pressure',
                    type: 'gauge',
                    progress: {
                        show: true
                    },
                    detail: {
                        valueAnimation: true,
                        formatter: '{value}'
                    },
                    data: [{
                        value: 20,
                        name: '小时产量'
                    }],
                    max: 1500,
                    min: 0,
                    title: {//显示当前标题
                        fontStyle: "normal",
                        fontWeight: "bold",
                        fontSize: 25,
                        offsetCenter: [0, '72%'],
                        color: '#67e0e3'
                    },
                    detail: {//显示当前数值
                        valueAnimation: true,
                        fontSize: 38,
                        offsetCenter: [0, '100%'],
                        color: '#67e0e3'
                    },
                    itemStyle: {//显示是否描边
                        borderColor: '#67e0e3',
                        borderWidth: 1
                    },
                    axisLabel: {//显示状态大小
                        color: '#67e0e3',
                        fontSize: 15,
                        width: 92,
                        textBorderWidth: 0.5
                    },
                    splitLine: {//小方格颜色属性
                        lineStyle: {
                            type: "solid",
                            width: 6.5,
                            color: '#67e0e3'
                        }
                    },
                    axisTick: {//刻度个数属性
                        show: true,
                        length: 10.5,
                        splitNumber: 6,

                    },
                    pointer: {//指针长度
                        length: "84%"
                    }
                }]
            };

            // 刷新调整
            window.onresize = function () {
                myChart30.resize();
            }
            // 使用刚指定的配置项和数据显示图表。
            myChart30.setOption(option30);
        }
    });