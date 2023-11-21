$(document).ready(function(){
    $("#btn").click(function(){
        $("div:first").hide(1000,function(){
            alert("Div is hidden");
        });
    });
});


    $("#shbtn").click(function(){
        $("#d2").show(1000,function(){
            alert("div visible")
        });
    });


$("#tglbtn").click(function(){
    $("#d3").toggle(1000);
});

$("#fin").click(function(){
    $("#d4").fadeIn(1000)
})

$("#fou").click(function(){
    $("#d5").fadeOut(1000)
})
$("#ft").click(function(){
    $("#d6").fadeToggle(1000)
})

$("#fto").click(function(){
    $("#d7").fadeTo(1000,0.5)
})