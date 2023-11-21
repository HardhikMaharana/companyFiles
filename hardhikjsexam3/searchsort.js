$(document).ready(function(){
    $("#textar").on("keyup",function(){
        var textarval=$(this).val();
        
        $("tbody tr").filter(function(){
            $(this).toggle($(this).text().toLowerCase().indexOf(textarval)>-1)
        })
    })
    $("button").click(function(){
     
        fn=$(".fname").text()
        var arr=fn.split(" ")
        arr.sort()
        console.log(arr)
        $(".tb1").hide()
        $("#t2").css("display","inline-block")
        var x
        for(i=0;i<arr.length;i++){
            x=$("#t2").append("<tr><td>"+arr[i]+"</td></tr> ")
            console.log(x)
        }
        $(".tbc").append(x)


    })
})