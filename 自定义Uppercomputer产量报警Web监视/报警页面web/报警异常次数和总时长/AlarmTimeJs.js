AlarmEchartsLoad();
//设备监控 显示报警总次数与报警时长
function AlarmEchartsLoad() {
    var chartDom = document.getElementById('AlarmTime');
    var myChart = echarts.init(chartDom);
    var option;

    setTimeout(function () {

        option = {
            legend: {
                textStyle: {
                    fontSize: 10,
                    color: "#ffffff"
                }
            },
            tooltip: {
                trigger: 'axis',
                showContent: false
            },
            dataset: {
                source: [
                    ['product', '2012', '2013', '2014', '2015', '2016', '2017'],
                    ['Milk Tea', 56.5, 82.1, 88.7, 70.1, 53.4, 85.1],
                    ['Matcha Latte', 51.1, 51.4, 55.1, 53.3, 73.8, 68.7],
                    ['Cheese Cocoa', 40.1, 62.2, 69.5, 36.4, 45.2, 32.5],
                    ['Walnut Brownie', 25.2, 37.1, 41.2, 18, 33.9, 49.1]
                ]
            },
            textStyle: {
                fontSize: 10,
                color: "#ffffff"
            },
            xAxis: {
                type: 'category',
                axisLabel: {
                    color: "#ffffff"
                }
            },
            yAxis: {
                gridIndex: 0,
                axisLabel: {
                    color: "#ffffff"
                }
            },
            grid: { top: '55%' },
            series: [
                { type: 'line', smooth: true, seriesLayoutBy: 'row', emphasis: { focus: 'series' } },
                { type: 'line', smooth: true, seriesLayoutBy: 'row', emphasis: { focus: 'series' } },
                { type: 'line', smooth: true, seriesLayoutBy: 'row', emphasis: { focus: 'series' } },
                { type: 'line', smooth: true, seriesLayoutBy: 'row', emphasis: { focus: 'series' } },
                {
                    type: 'pie',
                    id: 'pie',
                    radius: '30%',
                    center: ['50%', '25%'],
                    emphasis: { focus: 'data' },
                    label: {
                        formatter: '{b}: {@2012} ({d}%)'
                    },
                    encode: {
                        itemName: 'product',
                        value: '2012',
                        tooltip: '2012'
                    }
                }
            ]
        };


        myChart.on('updateAxisPointer', function (event) {
            var xAxisInfo = event.axesInfo[0];
            if (xAxisInfo) {
                var dimension = xAxisInfo.value + 1;
                myChart.setOption({
                    series: {
                        id: 'pie',
                        label: {
                            formatter: '{b}: {@[' + dimension + ']} ({d}%)'
                        },
                        encode: {
                            value: dimension,
                            tooltip: dimension
                        }
                    }
                });
            }
        });
        myChart.setOption(option);

    });
    //从后端读取数据
    //定时刷新数据
    setInterval(function () {
        $.ajax({//定时Post请求访问后端获取周数据
            type: "Post",
            url: "WebForm3.aspx/Alarmcomplete",
            contentType: "application/json;charset=utf - 8",
            dataType: "json",
            success:
                function (data) {
                    //反序列化
                    var dataObj = eval("(" + data.d + ")");
                    var le1 = dataObj[0].Item1;
                    var le2 = dataObj[1].Item1;
                    var le3 = dataObj[2].Item1;
                    var le4 = dataObj[3].Item1;
                    //获取图表之前绑定的数据
                    var data = option.dataset.source;
                    //填充默认名称：
                    option.dataset.source[0][0] = 'product';
                    option.dataset.source[1][0] = 'Milk Tea';
                    option.dataset.source[2][0] = 'Matcha Latte';
                    option.dataset.source[3][0] = 'Cheese Cocoa';
                    option.dataset.source[4][0] = 'Walnut Brownie';
                    //填充数据
                    for (var i = 1; i < le4.length; i++) {
                        option.dataset.source[0][i] = le4[i - 1].Name;
                        option.dataset.source[1][i] = le4[i - 1].Data;
                        option.dataset.source[2][i] = le2[i - 1].Data;
                        option.dataset.source[3][i] = le3[i - 1].Data;
                        option.dataset.source[4][i] = le4[i - 1].Data;
                    }
                    //圆形图属性
                    var ww = option.series[4];
                    ww.encode.value = le4[0].Name;
                    ww.encode.tooltip = le4[0].Name;
                    myChart.setOption(option, true);

                }
        });
    }, 1000);
    option && myChart.setOption(option);

}
//用于显示设备节拍
MeterLoad();
function MeterLoad() {
    var chartDom = document.getElementById('meter');
    var myChart = echarts.init(chartDom);
    var option;

    option = {
        series: [{
            type: 'gauge',
            startAngle: 180,
            endAngle: 0,
            min: 0,
            max: 700,
            splitNumber: 5,
            itemStyle: {
                color: '#58D9F9',
                shadowColor: 'rgba(0,138,255,0.45)',
                shadowBlur: 10,
                shadowOffsetX: 2,
                shadowOffsetY: 2
            },
            progress: {
                show: true,
                roundCap: true,
                width: 18
            },
            pointer: {
                icon: 'path://M2090.36389,615.30999 L2090.36389,615.30999 C2091.48372,615.30999 2092.40383,616.194028 2092.44859,617.312956 L2096.90698,728.755929 C2097.05155,732.369577 2094.2393,735.416212 2090.62566,735.56078 C2090.53845,735.564269 2090.45117,735.566014 2090.36389,735.566014 L2090.36389,735.566014 C2086.74736,735.566014 2083.81557,732.63423 2083.81557,729.017692 C2083.81557,728.930412 2083.81732,728.84314 2083.82081,728.755929 L2088.2792,617.312956 C2088.32396,616.194028 2089.24407,615.30999 2090.36389,615.30999 Z',
                length: '75%',
                width: 16,
                offsetCenter: [0, '5%']
            },
            axisLine: {
                roundCap: true,
                lineStyle: {
                    width: 18
                }
            },
            axisTick: {
                splitNumber: 2,
                lineStyle: {
                    width: 2,
                    color: '#999'
                }
            },
            splitLine: {
                length: 12,
                lineStyle: {
                    width: 3,
                    color: '#999'
                }
            },
            axisLabel: {
                distance: 30,
                color: "#ffffff",
                fontSize: 20
            },
            title: {
                show: false
            },
            detail: {
                backgroundColor: '#fff',
                borderColor: "#ffffff",
                borderWidth: 2,
                width: '80%',
                lineHeight: 40,
                height: 40,
                borderRadius: 8,
                offsetCenter: [0, '35%'],
                valueAnimation: true,
                formatter: function (value) {
                    return '{value|' + value.toFixed(0) + '}{unit|Pcs/Min}';
                },
                rich: {
                    value: {
                        fontSize: 50,
                        fontWeight: 'bolder',
                        color: '#777'
                    },
                    unit: {
                        fontSize: 20,
                        color: '#999',
                        padding: [0, 0, -20, 10]
                    }
                }
            },
            data: [{
                value:20
            }]
        }]
    };
    //定时刷新数据
    setInterval(function () {
        $.ajax({//定时Post请求访问后端获取周数据
            type: "Post",
            url: "WebForm3.aspx/Weboutput",
            contentType: "application/json;charset=utf - 8",
            dataType: "json",
            success:
                function (data) {
                    //反序列化
                    var dataObj = eval("(" + data.d + ")");
                    option.series[0].data[0].value = dataObj.设备速率;

                }
        });
        option && myChart.setOption(option, true);
    }, 1000);
    option && myChart.setOption(option);
}
//用于显示设备速率
//SpeedLoad();
//function SpeedLoad() {
//    var ROOT_PATH = 'https://cdn.jsdelivr.net/gh/apache/echarts-website@asf-site/examples';

//    var chartDom = document.getElementById('speed');
//    var myChart = echarts.init(chartDom);
//    var option;

//    var _panelImageURL = ROOT_PATH + '/data/asset/img/custom-gauge-panel.png';
//    var _animationDuration = 1000;
//    var _animationDurationUpdate = 1000;
//    var _animationEasingUpdate = 'quarticInOut';
//    var _valOnRadianMax = 200;
//    var _outerRadius = 200;
//    var _innerRadius = 170;
//    var _pointerInnerRadius = 40;
//    var _insidePanelRadius = 140;
//    var _currentDataIndex = 0;

//    function renderItem(params, api) {
//        var valOnRadian = api.value(1);
//        var coords = api.coord([api.value(0), valOnRadian]);
//        var polarEndRadian = coords[3];
//        var imageStyle = {
//            image: _panelImageURL,
//            x: params.coordSys.cx - _outerRadius,
//            y: params.coordSys.cy - _outerRadius,
//            width: _outerRadius * 2,
//            height: _outerRadius * 2
//        };

//        return {
//            type: 'group',
//            children: [{
//                type: 'image',
//                style: imageStyle,
//                clipPath: {
//                    type: 'sector',
//                    shape: {
//                        cx: params.coordSys.cx,
//                        cy: params.coordSys.cy,
//                        r: _outerRadius,
//                        r0: _innerRadius,
//                        startAngle: 0,
//                        endAngle: -polarEndRadian,
//                        transition: 'endAngle',
//                        enterFrom: { endAngle: 0 }
//                    }
//                }
//            }, {
//                type: 'image',
//                style: imageStyle,
//                clipPath: {
//                    type: 'polygon',
//                    shape: {
//                        points: makePionterPoints(params, polarEndRadian)
//                    },
//                    extra: {
//                        polarEndRadian: polarEndRadian,
//                        transition: 'polarEndRadian',
//                        enterFrom: { polarEndRadian: 0 }
//                    },
//                    during: function (apiDuring) {
//                        apiDuring.setShape(
//                            'points',
//                            makePionterPoints(params, apiDuring.getExtra('polarEndRadian'))
//                        );
//                    }
//                }
//            }, {
//                type: 'circle',
//                shape: {
//                    cx: params.coordSys.cx,
//                    cy: params.coordSys.cy,
//                    r: _insidePanelRadius
//                },
//                style: {
//                    fill: '#fff',
//                    shadowBlur: 25,
//                    shadowOffsetX: 0,
//                    shadowOffsetY: 0,
//                    shadowColor: 'rgba(76,107,167,0.4)'
//                }
//            }, {
//                type: 'text',
//                extra: {
//                    valOnRadian: valOnRadian,
//                    transition: 'valOnRadian',
//                    enterFrom: { valOnRadian: 0 }
//                },
//                style: {
//                    text: makeText(valOnRadian),
//                    fontSize: 50,
//                    fontWeight: 700,
//                    x: params.coordSys.cx,
//                    y: params.coordSys.cy,
//                    fill: 'rgb(0,50,190)',
//                    align: 'center',
//                    verticalAlign: 'middle',
//                    enterFrom: { opacity: 0 }
//                },
//                during: function (apiDuring) {
//                    apiDuring.setStyle('text', makeText(apiDuring.getExtra('valOnRadian')));
//                }
//            }]
//        };
//    }

//    function convertToPolarPoint(renderItemParams, radius, radian) {
//        return [
//            Math.cos(radian) * radius + renderItemParams.coordSys.cx,
//            -Math.sin(radian) * radius + renderItemParams.coordSys.cy
//        ];
//    }

//    function makePionterPoints(renderItemParams, polarEndRadian) {
//        return [
//            convertToPolarPoint(renderItemParams, _outerRadius, polarEndRadian),
//            convertToPolarPoint(renderItemParams, _outerRadius, polarEndRadian + Math.PI * 0.03),
//            convertToPolarPoint(renderItemParams, _pointerInnerRadius, polarEndRadian)
//        ];
//    }

//    function makeText(valOnRadian) {
//        // Validate additive animation calc.
//        if (valOnRadian < -10) {
//            alert('illegal during val: ' + valOnRadian);
//        }
//        return (valOnRadian / _valOnRadianMax * 100).toFixed(0) + '%';
//    }

//    option = {
//        animationEasing: _animationEasingUpdate,
//        animationDuration: _animationDuration,
//        animationDurationUpdate: _animationDurationUpdate,
//        animationEasingUpdate: _animationEasingUpdate,
//        dataset: {
//            source: [[1, 156]]
//        },
//        tooltip: {},
//        angleAxis: {
//            type: 'value',
//            startAngle: 0,
//            axisLine: { show: false },
//            axisTick: { show: false },
//            axisLabel: { show: false },
//            splitLine: { show: false },
//            min: 0,
//            max: _valOnRadianMax
//        },
//        radiusAxis: {
//            type: 'value',
//            axisLine: { show: false },
//            axisTick: { show: false },
//            axisLabel: { show: false },
//            splitLine: { show: false }
//        },
//        polar: {},
//        series: [{
//            type: 'custom',
//            coordinateSystem: 'polar',
//            renderItem: renderItem
//        }]
//    };

//    setInterval(function () {
//        var nextSource = [[1, Math.round(Math.random() * _valOnRadianMax)]];
//        myChart.setOption({
//            dataset: {
//                source: nextSource
//            }
//        });
//    }, 3000);

//    option && myChart.setOption(option);

//}