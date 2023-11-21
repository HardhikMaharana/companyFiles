$(document).ready(function(){
    var y=new Date()
    var day=y.getDay()
    $("button").click(function(){
        var x = $("input[type='number']").val();
        var days=["sunday","monday","tuesday","wednesday","thursday","friday","saturday"]
        var dt=Math.floor(x%7);
        
        if(dt==0){
            console.log(y)
        }
        else{
            console.log(days[day+dt])
        }
        
    })
    
})