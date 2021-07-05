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