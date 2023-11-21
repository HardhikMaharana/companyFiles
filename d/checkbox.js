$(document).ready(function(){
    
    $("input[type='checkbox']").click(function(){
       
        if($(this).is(":checked")){
            var idvalue=$(this).data('id');
            console.log(idvalue)
            $("#div2").append("<li  id='idvalue"+ idvalue +"'>"+$(this).val()+"</li>")
        }
        // else if( $(this).not(":checked")){
        //     var remv=$(this).data('id');
        //     console.log(remv)
        //     $('#div2').remove()
        // }
        else{
            var data_id = $(this).data("id");
            $("#idvalue"+data_id).remove();
        }
        
            
        
    })

   
})