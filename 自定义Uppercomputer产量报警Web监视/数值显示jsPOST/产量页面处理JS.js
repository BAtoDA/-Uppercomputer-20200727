//读取后端报警内容信息
function GetSQLoutput() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'WebForm2.aspx/GetSQLoutput',
        dataType: 'json',
        async: false,
        success: function (data) {

            var dataObj = eval("(" + data.d + ")");
            //实例化获取表格对象
            var tbody = document.getElementById('tbMaincl');
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
                //添加生产时间
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.生产时间;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加当天产量
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.当天产量;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加当天目标
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.当天目标;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加异常次数
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.异常次数;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加异常时长
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.异常时长;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加行
                tbody.appendChild(row);
            })

        }
    });
}
//刷新页面数据--返回首页
function Outputrefresh() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'WebForm2.aspx/Outputrefresh',
        dataType: 'json',
        async: false,
        success: function (data) {

            var dataObj = eval("(" + data.d + ")");
            //实例化获取表格对象
            var tbody = document.getElementById('tbMaincl');
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
                //添加生产时间
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.生产时间;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加当天产量
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.当天产量;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加当天目标
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.当天目标;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加异常次数
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.异常次数;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加异常时长
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.异常时长;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加行
                tbody.appendChild(row);
            })

        }
    });
}
//用户请求后端进行上一页操作
function Outputprevious() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'WebForm2.aspx/Outputprevious',
        dataType: 'json',
        async: false,
        success: function (data) {

            var dataObj = eval("(" + data.d + ")");
            if ((typeof dataObj).toString() != "boolean") {
                //实例化获取表格对象
                var tbody = document.getElementById('tbMaincl');
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
                    //添加生产时间
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.生产时间;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加当天产量
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.当天产量;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加当天目标
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.当天目标;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加异常次数
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.异常次数;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加异常时长
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.异常时长;//填充数据
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
function Outputnext() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'WebForm2.aspx/Outputnext',
        dataType: 'json',
        async: false,
        success: function (data) {

            var dataObj = eval("(" + data.d + ")");
            if ((typeof dataObj).toString() != "boolean") {
                //实例化获取表格对象
                var tbody = document.getElementById('tbMaincl');
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
                    //添加生产时间
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.生产时间;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加当天产量
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.当天产量;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加当天目标
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.当天目标;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加异常次数
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.异常次数;//填充数据
                    row.appendChild(idCell);//加入行，下面类似
                    //添加异常时长
                    var idCell = document.createElement('td');//创建第一列id
                    idCell.innerHTML = item.异常时长;//填充数据
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