$(document).ready(function(){
   
   $("#sub").click(function(){
  
     var nam=$(".namet").val();
       
     var ag=$(".aget").val();

        var x=$("#appendertb").append("<tr><td>"+nam+"</td><td>"+ag+"</td></tr>")
        $(".appender").append(x)
   })

   $("#ad").click(function(){
    var y=$("#main").html()
    console.log(y)
    $("#main").append(y);
   })
   
})

        
