$(document).ready(function(){
    
    if($("#div1").width()<=600){

        $("#div1").css("display","none")

        $("#btntogler").on("click",function(){

            $("#div1").slideDown(1000)
        })
    }
    else{
        $("#btntogler").on("click",function(){

            $("#div1").slideUp(1000)

        })
    }

   
})