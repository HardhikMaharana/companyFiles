$(document).ready(function(){
    $("#inputarea").on("keydown",function(){
        var inpval=$(this).val();

        $("#list li").filter(function(){
            $(this).toggle($(this).text().toLowerCase().indexOf(inpval)>-1)
        })
    })
})