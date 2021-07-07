//用户请求后端进行上一页操作
function Alarmregisterprevious() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'WebForm2.aspx/Alarmregisterprevious',
        dataType: 'json',
        async: false,
        success: function (data) {

            var dataObj = eval("(" + data.d + ")");
            if ((typeof dataObj).toString() != "boolean") {
                //实例化获取表格对象
                var tbody = document.getElementById('tbMain');
                //进行删除操作
                var len = tbody.rows.length;
                for (var i = 0; i < len; i++) {
                    tbody.deleteRow(0);//也可以写成table.deleteRow(0);
                }
                $.each(dataObj, function (i, item) {
                    var row = document.createElement('tr');//创建行
                    //添加ID
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.ID;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加类型
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.类型;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加设备
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.设备;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加设备_地址
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.设备_地址;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加设备_具体地址
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.设备_具体地址;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加位触发条件
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.位触发条件;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加字触发条件
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.字触发条件;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加字触发条件_具体
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.字触发条件_具体;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加报警内容
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.报警内容;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加行
                    tbody.appendChild(row);
                })
            }
            else
                alert("已经达到首页");

        }
    });
}
//用户请求后端进行下一页操作
function Alarmregisternext() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'WebForm2.aspx/Alarmregisternext',
        dataType: 'json',
        async: false,
        success: function (data) {

            var dataObj = eval("(" + data.d + ")");
            if ((typeof dataObj).toString() != "boolean") {
                //实例化获取表格对象
                var tbody = document.getElementById('tbMain');
                //进行删除操作
                var len = tbody.rows.length;
                for (var i = 0; i < len; i++) {
                    tbody.deleteRow(0);//也可以写成table.deleteRow(0);  
                }
                $.each(dataObj, function (i, item) {
                    var row = document.createElement('tr');//创建行
                    //添加ID
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.ID;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加类型
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.类型;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加设备
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.设备;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加设备_地址
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.设备_地址;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加设备_具体地址
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.设备_具体地址;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加位触发条件
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.位触发条件;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加字触发条件
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.字触发条件;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加字触发条件_具体
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.字触发条件_具体;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加报警内容
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.报警内容;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加行
                    tbody.appendChild(row);
                })
            }
            else
                alert("已经到达最后一页");
        }
    });
}