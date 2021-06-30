//读取后端报警历史数据查询
function GetAlarmhistory() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'WebForm2.aspx/Displayhistory',
        dataType: 'json',
        async: false,
        success: function (data) {

            var dataObj = eval("(" + data.d + ")");
            //实例化获取表格对象
            var tbody = document.getElementById('tbMain1');
            //进行删除操作
            var len = tbody.rows.length;
            for (var i = 1; i < len; i++) {
                tbody.deleteRow(0);//也可以写成table.deleteRow(0);  
            }
            $.each(dataObj, function (i, item) {
           /*     $("#imageslist").append("<li><img alt=\"" + item.AlarmPage + "\" src=\"" + item.AlarmTime + "\"/></li>");*/
                var row = document.createElement('tr');//创建行
                //添加ID
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.ID ;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加报警时间
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.报警时间;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加处理完成时间
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.处理完成时间;//填充数据
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
                //添加报警内容
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.报警内容;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加事件关联ID
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.事件关联ID;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加是否处理报警--废弃
                //添加行
                tbody.appendChild(row);
            })

        },
        error: function () {
            alert("error!");
        }
    });
}