//用于处理导航栏按钮的特效样式
function Navigationcss() {
    //导航栏按钮特性样式
    var buuton1 = document.getElementById('Button2');
    buuton1.onmouseenter = function () {
        buuton1.style.opacity = 0.7;
    }
    buuton1.onmouseleave = function () {
        buuton1.style.opacity = 10;
    }
    var buuton2 = document.getElementById('Button3');
    buuton2.onmouseenter = function () {
        buuton2.style.opacity = 0.7;
    }
    buuton2.onmouseleave = function () {
        buuton2.style.opacity = 10;
    }
    var buuton3 = document.getElementById('Button4');
    buuton3.onmouseenter = function () {
        buuton3.style.opacity = 0.7;
    }
    buuton3.onmouseleave = function () {
        buuton3.style.opacity = 10;
    }
    var buuton4 = document.getElementById('Button5');
    buuton4.onmouseenter = function () {
        buuton4.style.opacity = 0.7;
    }
    buuton4.onmouseleave = function () {
        buuton4.style.opacity = 10;
    }
    var buuton5 = document.getElementById('Button6');
    buuton5.onmouseenter = function () {
        buuton5.style.opacity = 0.7;
    }
    buuton5.onmouseleave = function () {
        buuton5.style.opacity = 10;
    }
    var buuton6 = document.getElementById('Button7');
    buuton6.onmouseenter = function () {
        buuton6.style.opacity = 0.7;
    }
    buuton6.onmouseleave = function () {
        buuton6.style.opacity = 10;
    }
}
//用于处理参数设置的特效
function Parametertext() {
    var tbody1 = document.getElementById('parameter1');
    tbody1.onmouseenter = function () {
        tbody1.style.backgroundColor = '#FFFFB0';
    }
    tbody1.onmouseleave = function () {
        tbody1.style.backgroundColor = '#FFF';
    }
    var tbody2 = document.getElementById('parameter2');
    tbody2.onmouseenter = function () {
        tbody2.style.backgroundColor = '#FFFFB0';
    }
    tbody2.onmouseleave = function () {
        tbody2.style.backgroundColor = '#FFF';
    }
    var tbody3 = document.getElementById('parameter3');
    tbody3.onmouseenter = function () {
        tbody3.style.backgroundColor = '#FFFFB0';
    }
    tbody3.onmouseleave = function () {
        tbody3.style.backgroundColor = '#FFF';
    }
    var tbody4 = document.getElementById('parameter4');
    tbody4.onmouseenter = function () {
        tbody4.style.backgroundColor = '#FFFFB0';
    }
    tbody4.onmouseleave = function () {
        tbody4.style.backgroundColor = '#FFF';
    }
    var tbody5 = document.getElementById('parameter5');
    tbody5.onmouseenter = function () {
        tbody5.style.backgroundColor = '#FFFFB0';
    }
    tbody5.onmouseleave = function () {
        tbody5.style.backgroundColor = '#FFF';
    }
    var tbody6 = document.getElementById('parameter6');
    tbody6.onmouseenter = function () {
        tbody6.style.backgroundColor = '#FFFFB0';
    }
    tbody6.onmouseleave = function () {
        tbody6.style.backgroundColor = '#FFF';
    }
}
//用于处理表格按钮的特效
function Tablecss() {
    var buuton1 = document.getElementById('previous');
    buuton1.onmouseenter = function () {
        buuton1.style.opacity = 0.7;
    }
    buuton1.onmouseleave = function () {
        buuton1.style.opacity = 10;
    }
    var buuton2 = document.getElementById('home');
    buuton2.onmouseenter = function () {
        buuton2.style.opacity = 0.7;
    }
    buuton2.onmouseleave = function () {
        buuton2.style.opacity = 10;
    }
    var buuton3 = document.getElementById('page');
    buuton3.onmouseenter = function () {
        buuton3.style.opacity = 0.7;
    }
    buuton3.onmouseleave = function () {
        buuton3.style.opacity = 10;
    }
}
//鼠标移到子项 子项变色
function Itembackground() {
    var Table = document.getElementById('Abnorma1');
    var Item = Table.getElementsByTagName('tr');
    for (var i = 0; i < Item.length; i++) {
        Item[i].style.backgroundColor = "transparent";
        Item[i].onmouseover = function () {
            this.style.backgroundColor = "#0099FF";
        }
        Item[i].onmouseout = function () {
            this.style.backgroundColor = "transparent";
        }
    }

}