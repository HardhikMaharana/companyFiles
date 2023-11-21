
function btnvalue(){
    
var btmval=document.querySelectorAll("button.symbol").innerHTML
document.getElementById("area2").value=btmval
console.log(btmval);
}


// function numval(){
//     var num=document.querySelector("button").innerHTML;
//     document.getElementById("area1").value=num
// }



function calc(x,y,op){ 


    var x=document.getElementById("area1").value
var y=document.getElementById("area3").value

op=document.getElementById("area2").value
    switch (op){
        case '+':document.getElementById("par").innerHTML=x+y;
        break
        case '-':document.getElementById("par").innerHTML=x-y;
        break
        case '*':document.getElementById("par").innerHTML=x*y;
        break
        case '/':document.getElementById("par").innerHTML=x/y;
        break
        case '%':document.getElementById("par").innerHTML=x%y;
        break
    }
}