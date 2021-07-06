//请求后端PLC类型数据
function PLCpost() {
    $.ajax({//Post请求访问后端获取PLC类型名称
        type: "Post",
        url: "WebForm2.aspx/PLCload",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        async: false,
        success:
            function (data) {
                document.getElementById('PLCname').innerHTML = data.d;
                //下拉菜单选中事件
                var Table = document.getElementById('PLCname');
                var Item = Table.getElementsByTagName('li');
                for (var i = 0; i < Item.length; i++) {
                    Item[i].onclick = function () {
                        document.getElementById('pitchText1').innerHTML = this.id;
                        //当用户改变PLC类型时 触点和 寄存器等地址相应改变
                        PLCpostM();
                        PLCpostM1();
                        PLCpostD();
                        PLCpostD1();
                    }
                }
            }
    });
}

//Post请求后端PLC D区类型数据
function PLCpostD() {
    $.ajax({
        type: "Post",
        url: "WebForm2.aspx/PLCDLoad",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        data: "{ 'Data':'" + document.getElementById('pitchText1').innerHTML.toString() + "'}",
        async: false,
        success:
            function (data) {
                document.getElementById('PLCDname').innerHTML = data.d;
                //下拉菜单选中事件
                var Table = document.getElementById('PLCDname');
                var Item = Table.getElementsByTagName('li');
                for (var i = 0; i < Item.length; i++) {
                    Item[i].onclick = function () {
                        document.getElementById('pitchText2').innerHTML = this.id;
                    }
                }
                //默认选择项
                document.getElementById('pitchText2').innerHTML = Item[0].id;
            }
    });
}

//Post请求后端PLC D区类型数据
function PLCpostD1() {
    $.ajax({
        type: "Post",
        url: "WebForm2.aspx/PLCDLoad",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        data: "{ 'Data':'" + document.getElementById('pitchText1').innerHTML.toString() + "'}",
        async: false,
        success:
            function (data) {
                document.getElementById('PLCDname1').innerHTML = data.d;
                //下拉菜单选中事件
                var Table = document.getElementById('PLCDname1');
                var Item = Table.getElementsByTagName('li');
                for (var i = 0; i < Item.length; i++) {
                    Item[i].onclick = function () {
                        document.getElementById('pitchText4').innerHTML = this.id;
                    }
                }
                //默认选择项
                document.getElementById('pitchText4').innerHTML = Item[0].id;
            }
    });
}

//请求后端PLC类型数据
function PLCpostM() {
    $.ajax({//Post请求访问后端获取PLC类型名称
        type: "Post",
        url: "WebForm2.aspx/PLCDLoad",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        data: "{ 'Data':'" + document.getElementById('pitchText1').innerHTML.toString() + "'}",
        async: false,
        success:
            function (data) {
                document.getElementById('PLCDname2').innerHTML = data.d;
                //下拉菜单选中事件
                var Table = document.getElementById('PLCDname2');
                var Item = Table.getElementsByTagName('li');
                for (var i = 0; i < Item.length; i++) {
                    Item[i].onclick = function () {
                        document.getElementById('pitchText3').innerHTML = this.id;
                    }
                }
                //默认选择项
                document.getElementById('pitchText3').innerHTML = Item[0].id;
            }
    });
}

//请求后端PLC类型数据
function PLCpostM1() {
    $.ajax({//Post请求访问后端获取PLC类型名称
        type: "Post",
        url: "WebForm2.aspx/PLCMLoad",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        data: "{ 'Data':'" + document.getElementById('pitchText1').innerHTML.toString() + "'}",
        async: false,
        success:
            function (data) {
                document.getElementById('PLCDname10').innerHTML = data.d;
                //下拉菜单选中事件
                var Table = document.getElementById('PLCDname10');
                var Item = Table.getElementsByTagName('li');
                for (var i = 0; i < Item.length; i++) {
                    Item[i].onclick = function () {
                        document.getElementById('pitchText10').innerHTML = this.id;
                    }
                }
                //默认选择项
                document.getElementById('pitchText10').innerHTML = Item[0].id;
            }
    });
}
//请求后端修改SQL数据中的数据
function ParameterTOSQL() {
    //根据固定ID查询参数
    $.ajax({
        type: "Post",
        url: "WebForm2.aspx/ParameterTOSQL",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        data: "{ 'pitchText1':'" + document.getElementById('pitchText1').innerHTML + "' , 'parameter2':'" + document.getElementById('parameter2').value
            + "', 'parameter6':'" + document.getElementById('parameter6').value + "' , 'parameter7':'" + document.getElementById('parameter7').value
            + "', 'pitchText2':'" + document.getElementById('pitchText2').innerHTML 
            + "', 'parameter3':'" + document.getElementById('parameter3').value + "' , 'pitchText4':'" + document.getElementById('pitchText4').innerHTML
            + "', 'parameter8':'" + document.getElementById('parameter8').value + "' , 'pitchText3':'" + document.getElementById('pitchText3').innerHTML
            + "', 'parameter4':'" + document.getElementById('parameter4').value + "' , 'pitchText10':'" + document.getElementById('pitchText10').innerHTML
            + "', 'parameter11':'" + document.getElementById('parameter11').value+"'}",
        async: false,
        success:
            function (data) {
                if (data.d) {
                    alert('提交表单成功：' + this.data);
                }
                else {
                    alert('提交表单失败：' + this.data);
                }
            }
    });
}
//请求后端获取SQL中保存的数据
function SQLTOParameter() {
    $.ajax({//Post请求访问后端获取保存在SQL中的数据表
        type: "Post",
        url: "WebForm2.aspx/SQLTOParameter",
        contentType: "application/json;charset=utf - 8",
        dataType: "json",
        data: "{ 'Data':'" + document.getElementById('pitchText1').innerHTML.toString() + "'}",
        async: false,
        success:
            function (data) {
                var dataObj = eval("(" + data.d + ")");
                document.getElementById('pitchText1').innerHTML = dataObj.设备;
                document.getElementById('parameter2').value = dataObj.全年产量目标;
                document.getElementById('parameter6').value = dataObj.当班目标;
                document.getElementById('parameter7').value = dataObj.当月目标;
                document.getElementById('pitchText2').innerHTML = dataObj.产量地址;
                document.getElementById('parameter3').value = dataObj.产量具体地址;
                document.getElementById('pitchText4').innerHTML = dataObj.物料编码;
                document.getElementById('parameter8').value = dataObj.编码具体地址;
                document.getElementById('pitchText3').innerHTML = dataObj.设备速率地址;
                document.getElementById('parameter4').value = dataObj.设备速率具体地址;
                document.getElementById('pitchText10').innerHTML = dataObj.自动运行地址;
                document.getElementById('parameter11').value = dataObj.自动运行具体地址;
            }
    });
}
