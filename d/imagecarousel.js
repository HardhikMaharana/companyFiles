
$(document).ready(function(){
    im=[]
     im=$(".imgcards ").html()
     var i=1;
     
    console.log(im)
    $(".imgdiv").click(function(){
        var did=$(this).data("id");
        var htm=$(this).html()
       
        $("#mainimgdiv").html(htm)
       
    })
  

    
    $("#next").click(function(){
        
     if(i<4)  {
        
        $("#mainimgdiv img").animate({width:'0px'},function(){
            $("#mainimgdiv img").animate({width:'100%'})
            i++;
            $(".mainimgdivcontainer img").attr("src","img"+i+".jpg")
            
        })
       
     }
     else{
        i=1
        
        $("#mainimgdiv img").animate({width:'0px'},function(){
            
            $("#mainimgdiv img").animate({width:'100%'})
           
            $(".mainimgdivcontainer img").attr("src","img"+i+".jpg")
            i++;
        })
        }
    })


 
   
    $("#prev").click(function(){
        $("#mainimgdiv img").animate({width:'0px'},function(){
            $("#mainimgdiv img").animate({width:'100%'})
            i--;
            $(".mainimgdivcontainer img").attr("src","img"+i+".jpg")
            
        })
    })
 
    

 
})


