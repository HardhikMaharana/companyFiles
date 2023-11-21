// $(document).ready(function(){
//     $("#btn").click(function(){
//         $("div").animate({
//             backgroundColor:"#aa0000",
//             height:"200px",
//             width:"100px"
//         })
//     })
// })

$("#btn").click(function(){
    $("#div1").delay("fast").animate({width:"400px",height:"40px"})
    $("#div2").delay("slow").animate({width:"400px",height:"40px"})
    $("#div3").delay(3000).animate({width:"400px",height:"40px"})
    $("#div4").delay(4000).animate({width:"400px",height:"40px"})
})