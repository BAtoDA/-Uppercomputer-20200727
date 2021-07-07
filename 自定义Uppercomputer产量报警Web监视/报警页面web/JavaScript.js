 function  GetRandom() {
    $.ajax({
        type:
            "Post",
        url:
            "WebForm1.aspx/GetRandom",
        ////方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字 
        //data:
        //    "{'str':'我是','str2':'xiaod '}",
        contentType:
            "application/json;charset=utf - 8",
        dataType: "json",
        success:
            function (data) {
                datas = data.d;
                alert(data.d);
                return data.d;
            },
        error:
            function (err) {
                alert(err);
            }
    });

}