$(document).ready(function(){
  $("input[type=radio]").click(function(){
          
    gen=$(this).val()
})
    
    $("#btn").click(function(){
      var named=$("input[type='text']").val()
      console.log(named)
      var mail=$("input[type='email']").val()
      console.log(mail)
      var numb=$("input[type='number']").val()
      console.log(numb)
      var age=$("#age").val()
      console.log(age)
      var addr=$("textarea").val()
      console.log(addr)
      gen
      console.log(gen)

      if($.trim(named)=="" || $.trim(mail)=="" || $.trim(numb)=="" ||  $.trim(age)=="" || $.trim(addr)=="" || $.trim(gen)=="" ){
       alert("error")
      }
      else{
     
        var x =$("#t2").append(
          "<tr>  <td>"+named+"</td>  <td>"+mail+"</td> <td>"+numb+"</td>  <td>"+age+"</td> <td>"+addr+"</td>  <td>"+gen+"</td> </tr>",
         
      )

      $("#t3").append(x)
      $("#t3 tr:odd").css({"background-color": "red", "color": "yellow"})

       $("form").trigger("reset")
       $(gen).val(" ");
      }

       
        

        
      
       
    })

   
   
})