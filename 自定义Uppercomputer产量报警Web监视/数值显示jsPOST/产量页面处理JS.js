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

        },
        error: function () {
            alert("error!");
        }
    });
}