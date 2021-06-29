//读取后端报警内容信息
function GetAlarm() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'WebForm1.aspx/DisplayImagesInfo',
        dataType: 'json',
        async: false,
        success: function (data) {

            var dataObj = eval("(" + data.d + ")");
            //实例化获取表格对象
            var tbody = document.getElementById('tbMain');
            //进行删除操作
            var len = tbody.rows.length;
            for (var i = 0; i < len; i++) {
                tbody.deleteRow(0);//也可以写成table.deleteRow(0);  
            }
            $.each(dataObj, function (i, item) {
                $("#imageslist").append("<li><img alt=\"" + item.AlarmPage + "\" src=\"" + item.AlarmTime + "\"/></li>");
                var row = document.createElement('tr');//创建行
                //添加页号
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.AlarmPage;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加报警时间
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.AlarmTime;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加报警ID
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.AlarmID;//填充数据
                row.appendChild(idCell);//加入行，下面类似
                //添加报警内容
                var idCell = document.createElement('td');//创建第一列id
                idCell.innerHTML = item.AlarmContent;//填充数据
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
//操作表格对象方法
function Alarm() {
    GetAlarm();//获取后端数据
}