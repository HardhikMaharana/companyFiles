$(document).ready(function(){
    $("#inputarea").on("keydown",function(){
        var inpval=$(this).val();

        $("#list li").filter(function(){
            $(this).toggle($(this).charAt(0).toLowerCase().indexOf(inpval)>-1)
        })
    })
})